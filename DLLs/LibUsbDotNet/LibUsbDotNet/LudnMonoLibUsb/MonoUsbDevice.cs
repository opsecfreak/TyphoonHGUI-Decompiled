// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.LudnMonoLibUsb.MonoUsbDevice
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Descriptors;
using LibUsbDotNet.Info;
using LibUsbDotNet.Internal;
using LibUsbDotNet.Main;
using MonoLibUsb;
using MonoLibUsb.Descriptors;
using MonoLibUsb.Profile;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.LudnMonoLibUsb;

public class MonoUsbDevice : UsbDevice, IUsbDevice, IUsbInterface
{
  internal static readonly object OLockDeviceList = new object();
  internal static MonoUsbProfileList mMonoUSBProfileList;
  private readonly MonoUsbProfile mMonoUSBProfile;
  private int mClaimedInteface;

  internal MonoUsbDevice(ref MonoUsbProfile monoUSBProfile)
    : base((UsbApiBase) null, (SafeHandle) null)
  {
    this.mMonoUSBProfile = monoUSBProfile;
    this.mCachedDeviceDescriptor = new UsbDeviceDescriptor(monoUSBProfile.DeviceDescriptor);
  }

  internal static MonoUsbProfileList ProfileList
  {
    get
    {
      lock (MonoUsbDevice.OLockDeviceList)
      {
        MonoUsbApi.InitAndStart();
        if (MonoUsbDevice.mMonoUSBProfileList == null)
          MonoUsbDevice.mMonoUSBProfileList = new MonoUsbProfileList();
        return MonoUsbDevice.mMonoUSBProfileList;
      }
    }
  }

  public static List<MonoUsbDevice> MonoUsbDeviceList
  {
    get
    {
      lock (MonoUsbDevice.OLockDeviceList)
      {
        MonoUsbApi.InitAndStart();
        if (MonoUsbDevice.mMonoUSBProfileList == null)
          MonoUsbDevice.mMonoUSBProfileList = new MonoUsbProfileList();
        if (MonoUsbDevice.mMonoUSBProfileList.Refresh(MonoUsbEventHandler.SessionHandle) < 0)
          return (List<MonoUsbDevice>) null;
        List<MonoUsbDevice> monoUsbDeviceList = new List<MonoUsbDevice>();
        for (int index = 0; index < MonoUsbDevice.mMonoUSBProfileList.Count; ++index)
        {
          MonoUsbProfile mMonoUsbProfile = MonoUsbDevice.mMonoUSBProfileList[index];
          if (mMonoUsbProfile.DeviceDescriptor.BcdUsb != (short) 0)
          {
            MonoUsbDevice monoUsbDevice = new MonoUsbDevice(ref mMonoUsbProfile);
            monoUsbDeviceList.Add(monoUsbDevice);
          }
        }
        return monoUsbDeviceList;
      }
    }
  }

  public byte DeviceAddress => this.mMonoUSBProfile.DeviceAddress;

  public byte BusNumber => this.mMonoUSBProfile.BusNumber;

  public bool ResetDevice()
  {
    if (!this.IsOpen)
      throw new UsbException((object) this, "Device is not opened.");
    this.ActiveEndpoints.Clear();
    int ret;
    if ((ret = MonoUsbApi.ResetDevice((MonoUsbDeviceHandle) this.mUsbHandle)) != 0)
      UsbError.Error(ErrorCode.MonoApiError, ret, "ResetDevice Failed", (object) this);
    else
      this.Close();
    return ret == 0;
  }

  public override UsbDevice.DriverModeType DriverMode
  {
    get
    {
      return UsbDevice.IsLinux ? UsbDevice.DriverModeType.MonoLibUsb : UsbDevice.DriverModeType.LibUsbWinBack;
    }
  }

  public override bool Close()
  {
    this.ActiveEndpoints.Clear();
    if (this.IsOpen)
      this.mUsbHandle.Close();
    return true;
  }

  public override bool ControlTransfer(
    ref UsbSetupPacket setupPacket,
    IntPtr buffer,
    int bufferLength,
    out int lengthTransferred)
  {
    int ret = MonoUsbApi.ControlTransferAsync((MonoUsbDeviceHandle) this.mUsbHandle, setupPacket.RequestType, setupPacket.Request, setupPacket.Value, setupPacket.Index, buffer, (short) bufferLength, 1000);
    if (ret < 0)
    {
      UsbError.Error(ErrorCode.MonoApiError, ret, "ControlTransfer Failed", (object) this);
      lengthTransferred = 0;
      return false;
    }
    lengthTransferred = ret;
    return true;
  }

  public override bool GetDescriptor(
    byte descriptorType,
    byte index,
    short langId,
    IntPtr buffer,
    int bufferLength,
    out int transferLength)
  {
    transferLength = 0;
    bool descriptor1 = false;
    bool isOpen = this.IsOpen;
    if (!isOpen)
      this.Open();
    if (!this.IsOpen)
      return false;
    int descriptor2 = MonoUsbApi.GetDescriptor((MonoUsbDeviceHandle) this.mUsbHandle, descriptorType, index, buffer, (int) (ushort) bufferLength);
    if (descriptor2 < 0)
    {
      UsbError.Error(ErrorCode.MonoApiError, descriptor2, "GetDescriptor Failed", (object) this);
    }
    else
    {
      descriptor1 = true;
      transferLength = descriptor2;
    }
    if (!isOpen && this.IsOpen)
      this.Close();
    return descriptor1;
  }

  public override bool Open()
  {
    if (this.IsOpen)
      return true;
    MonoUsbDeviceHandle monoUsbDeviceHandle = new MonoUsbDeviceHandle(this.mMonoUSBProfile.ProfileHandle);
    if (monoUsbDeviceHandle.IsInvalid)
    {
      UsbError.Error(ErrorCode.MonoApiError, (int) MonoUsbDeviceHandle.LastErrorCode, "MonoUsbDevice.Open Failed", (object) this);
      this.mUsbHandle = (SafeHandle) null;
      return false;
    }
    this.mUsbHandle = (SafeHandle) monoUsbDeviceHandle;
    if (this.IsOpen)
      return true;
    this.mUsbHandle.Close();
    return false;
  }

  public MonoUsbProfile Profile => this.mMonoUSBProfile;

  public override UsbEndpointReader OpenEndpointReader(
    ReadEndpointID readEndpointID,
    int readBufferSize,
    EndpointType endpointType)
  {
    foreach (UsbEndpointBase mActiveEndpoint in this.mActiveEndpoints)
    {
      if ((ReadEndpointID) mActiveEndpoint.EpNum == readEndpointID)
        return (UsbEndpointReader) mActiveEndpoint;
    }
    return (UsbEndpointReader) this.ActiveEndpoints.Add((UsbEndpointBase) new MonoUsbEndpointReader((UsbDevice) this, readBufferSize, readEndpointID, endpointType));
  }

  public override UsbEndpointWriter OpenEndpointWriter(
    WriteEndpointID writeEndpointID,
    EndpointType endpointType)
  {
    foreach (UsbEndpointBase activeEndpoint in this.ActiveEndpoints)
    {
      if ((WriteEndpointID) activeEndpoint.EpNum == writeEndpointID)
        return (UsbEndpointWriter) activeEndpoint;
    }
    return (UsbEndpointWriter) this.mActiveEndpoints.Add((UsbEndpointBase) new MonoUsbEndpointWriter((UsbDevice) this, writeEndpointID, endpointType));
  }

  public bool SetConfiguration(byte config)
  {
    int ret = MonoUsbApi.SetConfiguration((MonoUsbDeviceHandle) this.mUsbHandle, (int) config);
    if (ret != 0)
    {
      UsbError.Error(ErrorCode.MonoApiError, ret, "SetConfiguration Failed", (object) this);
      return false;
    }
    this.mCurrentConfigValue = (int) config;
    return true;
  }

  public override bool GetConfiguration(out byte config)
  {
    config = (byte) 0;
    int configuration1 = 0;
    int configuration2 = MonoUsbApi.GetConfiguration((MonoUsbDeviceHandle) this.mUsbHandle, ref configuration1);
    if (configuration2 != 0)
    {
      UsbError.Error(ErrorCode.MonoApiError, configuration2, "GetConfiguration Failed", (object) this);
      return false;
    }
    config = (byte) configuration1;
    this.mCurrentConfigValue = (int) config;
    return true;
  }

  public override UsbRegistry UsbRegistryInfo => (UsbRegistry) null;

  public override ReadOnlyCollection<UsbConfigInfo> Configs
  {
    get
    {
      if (this.mConfigs == null)
      {
        if (!this.IsOpen)
          return (ReadOnlyCollection<UsbConfigInfo>) null;
        int configs = (int) MonoUsbDevice.GetConfigs(this, out this.mConfigs);
      }
      return this.mConfigs.AsReadOnly();
    }
  }

  public override UsbDeviceInfo Info
  {
    get
    {
      if (this.mDeviceInfo == null)
        this.mDeviceInfo = new UsbDeviceInfo((UsbDevice) this, this.mMonoUSBProfile.DeviceDescriptor);
      return this.mDeviceInfo;
    }
  }

  public bool ClaimInterface(int interfaceID)
  {
    int ret = MonoUsbApi.ClaimInterface((MonoUsbDeviceHandle) this.mUsbHandle, interfaceID);
    if (ret != 0)
    {
      UsbError.Error(ErrorCode.MonoApiError, ret, "ClaimInterface Failed", (object) this);
      return false;
    }
    this.mClaimedInteface = interfaceID;
    return true;
  }

  public bool ReleaseInterface(int interfaceID)
  {
    int ret = MonoUsbApi.ReleaseInterface((MonoUsbDeviceHandle) this.mUsbHandle, interfaceID);
    if (ret == 0)
      return true;
    UsbError.Error(ErrorCode.MonoApiError, ret, "ReleaseInterface Failed", (object) this);
    return false;
  }

  public bool SetAltInterface(int alternateID)
  {
    int ret = MonoUsbApi.SetInterfaceAltSetting((MonoUsbDeviceHandle) this.mUsbHandle, this.mClaimedInteface, alternateID);
    if (ret == 0)
      return true;
    UsbError.Error(ErrorCode.MonoApiError, ret, "SetAltInterface Failed", (object) this);
    return false;
  }

  private static ErrorCode GetConfigs(
    MonoUsbDevice usbDevice,
    out List<UsbConfigInfo> configInfoListRtn)
  {
    configInfoListRtn = new List<UsbConfigInfo>();
    List<MonoUsbConfigDescriptor> configDescriptorList = new List<MonoUsbConfigDescriptor>();
    int configurationCount = (int) usbDevice.Info.Descriptor.ConfigurationCount;
    for (int configIndex = 0; configIndex < configurationCount; ++configIndex)
    {
      MonoUsbConfigHandle configHandle;
      int configDescriptor1 = MonoUsbApi.GetConfigDescriptor(usbDevice.mMonoUSBProfile.ProfileHandle, (byte) configIndex, out configHandle);
      if (configDescriptor1 == 0)
      {
        if (!configHandle.IsInvalid)
        {
          try
          {
            MonoUsbConfigDescriptor configDescriptor2 = new MonoUsbConfigDescriptor();
            Marshal.PtrToStructure(configHandle.DangerousGetHandle(), (object) configDescriptor2);
            UsbConfigInfo usbConfigInfo = new UsbConfigInfo(usbDevice, configDescriptor2);
            configInfoListRtn.Add(usbConfigInfo);
            continue;
          }
          catch (Exception ex)
          {
            UsbError.Error(ErrorCode.InvalidConfig, Marshal.GetLastWin32Error(), ex.ToString(), (object) usbDevice);
            continue;
          }
          finally
          {
            if (!configHandle.IsInvalid)
              configHandle.Close();
          }
        }
      }
      return UsbError.Error(ErrorCode.MonoApiError, configDescriptor1, $"GetConfigDescriptor Failed at index:{configIndex}", (object) usbDevice).ErrorCode;
    }
    return ErrorCode.None;
  }

  internal static int RefreshProfileList()
  {
    lock (MonoUsbDevice.OLockDeviceList)
    {
      MonoUsbApi.InitAndStart();
      if (MonoUsbDevice.mMonoUSBProfileList == null)
        MonoUsbDevice.mMonoUSBProfileList = new MonoUsbProfileList();
      return MonoUsbDevice.mMonoUSBProfileList.Refresh(MonoUsbEventHandler.SessionHandle);
    }
  }

  public static void Init() => MonoUsbApi.InitAndStart();
}
