// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.UsbDevice
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Descriptors;
using LibUsbDotNet.Info;
using LibUsbDotNet.Internal;
using LibUsbDotNet.Internal.LibUsb;
using LibUsbDotNet.LibUsb;
using LibUsbDotNet.LudnMonoLibUsb;
using LibUsbDotNet.Main;
using LibUsbDotNet.WinUsb;
using LibUsbDotNet.WinUsb.Internal;
using MonoLibUsb;
using MonoLibUsb.Profile;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet;

public abstract class UsbDevice
{
  private static LibUsbAPI _libUsbApi;
  private static WinUsbAPI _winUsbApi;
  private static object mHasWinUsbDriver;
  private static object mHasLibUsbWinBackDriver;
  private static LibUsbKernelType mLibUsbKernelType;
  private static UsbKernelVersion mUsbKernelVersion;
  private static readonly bool ForceLegacyLibUsb = UsbDevice.IsLinux;
  public static bool ForceLibUsbWinBack = false;
  internal readonly UsbEndpointList mActiveEndpoints;
  internal readonly UsbApiBase mUsbApi;
  internal UsbDeviceDescriptor mCachedDeviceDescriptor;
  internal List<UsbConfigInfo> mConfigs;
  internal int mCurrentConfigValue = -1;
  internal UsbDeviceInfo mDeviceInfo;
  internal SafeHandle mUsbHandle;
  internal UsbRegistry mUsbRegistry;

  public static UsbRegDeviceList AllDevices
  {
    get
    {
      UsbRegDeviceList allDevices = new UsbRegDeviceList();
      foreach (UsbRegistry allWinUsbDevice in UsbDevice.AllWinUsbDevices)
        allDevices.Add(allWinUsbDevice);
      foreach (UsbRegistry allLibUsbDevice in UsbDevice.AllLibUsbDevices)
        allDevices.Add(allLibUsbDevice);
      return allDevices;
    }
  }

  public static UsbRegDeviceList AllLibUsbDevices
  {
    get
    {
      UsbRegDeviceList allLibUsbDevices = new UsbRegDeviceList();
      if (UsbDevice.HasLibUsbWinBackDriver && UsbDevice.ForceLibUsbWinBack)
      {
        foreach (MonoUsbDevice monoUsbDevice in MonoUsbDevice.MonoUsbDeviceList)
          allLibUsbDevices.Add((UsbRegistry) new LegacyUsbRegistry((UsbDevice) monoUsbDevice));
      }
      else if (!UsbDevice.ForceLegacyLibUsb && UsbDevice.KernelType == LibUsbKernelType.NativeLibUsb)
      {
        foreach (LibUsbRegistry device in LibUsbRegistry.DeviceList)
          allLibUsbDevices.Add((UsbRegistry) device);
      }
      else
      {
        foreach (LegacyUsbRegistry device in LegacyUsbRegistry.DeviceList)
          allLibUsbDevices.Add((UsbRegistry) device);
      }
      return allLibUsbDevices;
    }
  }

  public static int LastErrorNumber => UsbError.mLastErrorNumber;

  public static string LastErrorString => UsbError.mLastErrorString;

  internal static LibUsbAPI LibUsbApi
  {
    get
    {
      if (UsbDevice._libUsbApi == null)
        UsbDevice._libUsbApi = new LibUsbAPI();
      return UsbDevice._libUsbApi;
    }
  }

  internal static WinUsbAPI WinUsbApi
  {
    get
    {
      if (UsbDevice._winUsbApi == null)
        UsbDevice._winUsbApi = new WinUsbAPI();
      return UsbDevice._winUsbApi;
    }
  }

  public static UsbDevice OpenUsbDevice(UsbDeviceFinder usbDeviceFinder)
  {
    return UsbDevice.OpenUsbDevice(new Predicate<UsbRegistry>(usbDeviceFinder.Check));
  }

  public static UsbDevice OpenUsbDevice(Predicate<UsbRegistry> findDevicePredicate)
  {
    return UsbDevice.AllDevices.Find(findDevicePredicate)?.Device;
  }

  public static bool OpenUsbDevice(ref Guid devInterfaceGuid, out UsbDevice usbDevice)
  {
    usbDevice = (UsbDevice) null;
    foreach (UsbRegistry allDevice in UsbDevice.AllDevices)
    {
      foreach (Guid deviceInterfaceGuid in allDevice.DeviceInterfaceGuids)
      {
        if (deviceInterfaceGuid == devInterfaceGuid)
        {
          usbDevice = allDevice.Device;
          if (usbDevice != null)
            return true;
        }
      }
    }
    return false;
  }

  public static event EventHandler<UsbError> UsbErrorEvent;

  internal static void FireUsbError(object sender, UsbError usbError)
  {
    EventHandler<UsbError> usbErrorEvent = UsbDevice.UsbErrorEvent;
    if (usbErrorEvent == null)
      return;
    usbErrorEvent(sender, usbError);
  }

  public static UsbRegDeviceList AllWinUsbDevices
  {
    get
    {
      UsbRegDeviceList allWinUsbDevices = new UsbRegDeviceList();
      if (UsbDevice.IsLinux || UsbDevice.ForceLibUsbWinBack || !UsbDevice.HasWinUsbDriver)
        return allWinUsbDevices;
      foreach (WinUsbRegistry device in WinUsbRegistry.DeviceList)
        allWinUsbDevices.Add((UsbRegistry) device);
      return allWinUsbDevices;
    }
  }

  [Obsolete("Always returns true")]
  public static bool HasLibUsbDriver => true;

  public static bool HasWinUsbDriver
  {
    get
    {
      if (UsbDevice.mHasWinUsbDriver == null)
      {
        if (UsbDevice.IsLinux)
        {
          UsbDevice.mHasWinUsbDriver = (object) false;
        }
        else
        {
          try
          {
            WinUsbAPI.WinUsb_Free(IntPtr.Zero);
            UsbDevice.mHasWinUsbDriver = (object) true;
          }
          catch (Exception ex)
          {
            UsbDevice.mHasWinUsbDriver = (object) false;
          }
        }
      }
      return (bool) UsbDevice.mHasWinUsbDriver;
    }
  }

  public static bool HasLibUsbWinBackDriver
  {
    get
    {
      if (UsbDevice.mHasLibUsbWinBackDriver == null)
      {
        if (UsbDevice.IsLinux)
        {
          UsbDevice.mHasLibUsbWinBackDriver = (object) false;
        }
        else
        {
          try
          {
            MonoUsbApi.StrError(MonoUsbError.Success);
            UsbDevice.mHasLibUsbWinBackDriver = (object) true;
          }
          catch (Exception ex)
          {
            UsbDevice.mHasLibUsbWinBackDriver = (object) false;
          }
        }
      }
      return (bool) UsbDevice.mHasLibUsbWinBackDriver;
    }
  }

  public static bool IsLinux => Helper.IsLinux;

  public static LibUsbKernelType KernelType
  {
    get
    {
      if (UsbDevice.mLibUsbKernelType == LibUsbKernelType.Unknown)
      {
        if (UsbDevice.IsLinux)
        {
          UsbDevice.mLibUsbKernelType = LibUsbKernelType.MonoLibUsb;
        }
        else
        {
          UsbKernelVersion kernelVersion = UsbDevice.KernelVersion;
          if (!kernelVersion.IsEmpty)
            UsbDevice.mLibUsbKernelType = kernelVersion.BcdLibUsbDotNetKernelMod != 0 ? LibUsbKernelType.NativeLibUsb : LibUsbKernelType.LegacyLibUsb;
        }
      }
      return UsbDevice.mLibUsbKernelType;
    }
  }

  public static UsbKernelVersion KernelVersion
  {
    get
    {
      if (UsbDevice.mUsbKernelVersion.IsEmpty)
      {
        if (UsbDevice.IsLinux)
        {
          UsbDevice.mUsbKernelVersion = new UsbKernelVersion(1, 0, 0, 0, 0);
        }
        else
        {
          for (int index = 1; index < 128 /*0x80*/; ++index)
          {
            LibUsbDevice usbDevice;
            if (LibUsbDevice.Open(LibUsbDriverIO.GetDeviceNameString(index), out usbDevice))
            {
              LibUsbRequest inBuffer = new LibUsbRequest();
              GCHandle gcHandle = GCHandle.Alloc((object) inBuffer, GCHandleType.Pinned);
              int ret;
              int num = usbDevice.UsbIoSync(LibUsbIoCtl.GET_VERSION, (object) inBuffer, LibUsbRequest.Size, gcHandle.AddrOfPinnedObject(), LibUsbRequest.Size, out ret) ? 1 : 0;
              gcHandle.Free();
              usbDevice.Close();
              if (num != 0 && ret == LibUsbRequest.Size)
              {
                UsbDevice.mUsbKernelVersion = inBuffer.Version;
                break;
              }
            }
          }
        }
      }
      return UsbDevice.mUsbKernelVersion;
    }
  }

  public static OperatingSystem OSVersion => Helper.OSVersion;

  internal UsbDevice(UsbApiBase usbApi, SafeHandle usbHandle)
  {
    this.mUsbApi = usbApi;
    this.mUsbHandle = usbHandle;
    this.mActiveEndpoints = new UsbEndpointList();
  }

  public virtual ReadOnlyCollection<UsbConfigInfo> Configs
  {
    get
    {
      if (this.mConfigs == null)
        this.mConfigs = UsbDevice.GetDeviceConfigs(this);
      return this.mConfigs.AsReadOnly();
    }
  }

  public virtual UsbDeviceInfo Info
  {
    get
    {
      if (this.mDeviceInfo == null)
        this.mDeviceInfo = new UsbDeviceInfo(this);
      return this.mDeviceInfo;
    }
  }

  public virtual UsbRegistry UsbRegistryInfo => this.mUsbRegistry;

  public bool IsOpen
  {
    get => this.mUsbHandle != null && !this.mUsbHandle.IsClosed && !this.mUsbHandle.IsInvalid;
  }

  public UsbEndpointList ActiveEndpoints => this.mActiveEndpoints;

  internal SafeHandle Handle => this.mUsbHandle;

  public abstract UsbDevice.DriverModeType DriverMode { get; }

  public abstract bool Close();

  public abstract bool Open();

  public virtual bool ControlTransfer(
    ref UsbSetupPacket setupPacket,
    IntPtr buffer,
    int bufferLength,
    out int lengthTransferred)
  {
    int num = this.mUsbApi.ControlTransfer(this.mUsbHandle, setupPacket, buffer, bufferLength, out lengthTransferred) ? 1 : 0;
    if (num != 0)
      return num != 0;
    UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (ControlTransfer), (object) this);
    return num != 0;
  }

  public virtual bool ControlTransfer(
    ref UsbSetupPacket setupPacket,
    object buffer,
    int bufferLength,
    out int lengthTransferred)
  {
    PinnedHandle pinnedHandle = new PinnedHandle(buffer);
    int num = this.ControlTransfer(ref setupPacket, pinnedHandle.Handle, bufferLength, out lengthTransferred) ? 1 : 0;
    pinnedHandle.Dispose();
    return num != 0;
  }

  public virtual bool GetConfiguration(out byte config)
  {
    config = (byte) 0;
    byte[] buffer = new byte[1];
    int lengthTransferred;
    if (this.ControlTransfer(ref new UsbSetupPacket()
    {
      RequestType = (byte) 128 /*0x80*/,
      Request = (byte) 8,
      Value = (short) 0,
      Index = (short) 0,
      Length = (short) 1
    }, (object) buffer, buffer.Length, out lengthTransferred) && lengthTransferred == 1)
    {
      config = buffer[0];
      this.mCurrentConfigValue = (int) config;
      return true;
    }
    UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (GetConfiguration), (object) this);
    return false;
  }

  public virtual bool GetDescriptor(
    byte descriptorType,
    byte index,
    short langId,
    IntPtr buffer,
    int bufferLength,
    out int transferLength)
  {
    transferLength = 0;
    bool isOpen = this.IsOpen;
    if (!isOpen)
      this.Open();
    if (!this.IsOpen)
      return false;
    int num = this.mUsbApi.GetDescriptor(this.mUsbHandle, descriptorType, index, (ushort) langId, buffer, bufferLength, out transferLength) ? 1 : 0;
    if (num == 0)
      UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (GetDescriptor), (object) this);
    if (isOpen)
      return num != 0;
    if (!this.IsOpen)
      return num != 0;
    this.Close();
    return num != 0;
  }

  public virtual UsbEndpointWriter OpenEndpointWriter(WriteEndpointID writeEndpointID)
  {
    return this.OpenEndpointWriter(writeEndpointID, EndpointType.Bulk);
  }

  public virtual UsbEndpointWriter OpenEndpointWriter(
    WriteEndpointID writeEndpointID,
    EndpointType endpointType)
  {
    foreach (UsbEndpointBase activeEndpoint in this.ActiveEndpoints)
    {
      if ((WriteEndpointID) activeEndpoint.EpNum == writeEndpointID)
        return (UsbEndpointWriter) activeEndpoint;
    }
    return (UsbEndpointWriter) this.mActiveEndpoints.Add((UsbEndpointBase) new UsbEndpointWriter(this, writeEndpointID, endpointType));
  }

  internal static List<UsbConfigInfo> GetDeviceConfigs(UsbDevice usbDevice)
  {
    List<UsbConfigInfo> deviceConfigs = new List<UsbConfigInfo>();
    byte[] numArray = new byte[4096 /*0x1000*/];
    int configurationCount = (int) usbDevice.Info.Descriptor.ConfigurationCount;
    for (int index = 0; index < configurationCount; ++index)
    {
      int transferLength;
      if (usbDevice.GetDescriptor((byte) 2, (byte) 0, (short) 0, (object) numArray, numArray.Length, out transferLength))
      {
        if (transferLength >= UsbConfigDescriptor.Size && numArray[1] == (byte) 2)
        {
          UsbConfigDescriptor configDescriptor = new UsbConfigDescriptor();
          Helper.BytesToObject(numArray, 0, Math.Min(UsbConfigDescriptor.Size, (int) numArray[0]), (object) configDescriptor);
          if ((int) configDescriptor.TotalLength == transferLength)
          {
            List<byte[]> rawDescriptors = new List<byte[]>();
            byte[] destinationArray;
            for (int length = (int) configDescriptor.Length; length < (int) configDescriptor.TotalLength; length += destinationArray.Length)
            {
              destinationArray = new byte[(int) numArray[length]];
              if (length + destinationArray.Length > transferLength)
                throw new UsbException((object) usbDevice, "Descriptor length is out of range.");
              Array.Copy((Array) numArray, length, (Array) destinationArray, 0, destinationArray.Length);
              rawDescriptors.Add(destinationArray);
            }
            deviceConfigs.Add(new UsbConfigInfo(usbDevice, configDescriptor, ref rawDescriptors));
          }
          else
            UsbError.Error(ErrorCode.InvalidConfig, 0, "GetDeviceConfigs: USB config descriptor length doesn't match the length received.", (object) usbDevice);
        }
        else
          UsbError.Error(ErrorCode.InvalidConfig, 0, "GetDeviceConfigs: USB config descriptor is invalid.", (object) usbDevice);
      }
      else
        UsbError.Error(ErrorCode.InvalidConfig, 0, nameof (GetDeviceConfigs), (object) usbDevice);
    }
    return deviceConfigs;
  }

  public bool GetDescriptor(
    byte descriptorType,
    byte index,
    short langId,
    object buffer,
    int bufferLength,
    out int transferLength)
  {
    PinnedHandle pinnedHandle = new PinnedHandle(buffer);
    int num = this.GetDescriptor(descriptorType, index, langId, pinnedHandle.Handle, bufferLength, out transferLength) ? 1 : 0;
    pinnedHandle.Dispose();
    return num != 0;
  }

  public bool GetLangIDs(out short[] langIDs)
  {
    LangStringDescriptor stringDescriptor = new LangStringDescriptor(UsbDescriptor.Size + 32 /*0x20*/);
    int transferLength;
    bool descriptor = this.GetDescriptor((byte) 3, (byte) 0, (short) 0, stringDescriptor.Ptr, stringDescriptor.MaxSize, out transferLength);
    if (descriptor && transferLength == (int) stringDescriptor.Length)
    {
      descriptor = stringDescriptor.Get(out langIDs);
    }
    else
    {
      langIDs = new short[0];
      UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (GetLangIDs), (object) this);
    }
    stringDescriptor.Free();
    return descriptor;
  }

  public bool GetString(out string stringData, short langId, byte stringIndex)
  {
    stringData = (string) null;
    LangStringDescriptor stringDescriptor = new LangStringDescriptor((int) byte.MaxValue);
    int transferLength;
    bool descriptor = this.GetDescriptor((byte) 3, stringIndex, langId, stringDescriptor.Ptr, stringDescriptor.MaxSize, out transferLength);
    if (descriptor && transferLength > UsbDescriptor.Size && (int) stringDescriptor.Length == transferLength)
      descriptor = stringDescriptor.Get(out stringData);
    else if (!descriptor)
      UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), "GetString:GetDescriptor", (object) this);
    else
      stringData = string.Empty;
    return descriptor;
  }

  public UsbEndpointReader OpenEndpointReader(ReadEndpointID readEndpointID)
  {
    return this.OpenEndpointReader(readEndpointID, UsbEndpointReader.DefReadBufferSize);
  }

  public UsbEndpointReader OpenEndpointReader(ReadEndpointID readEndpointID, int readBufferSize)
  {
    return this.OpenEndpointReader(readEndpointID, readBufferSize, EndpointType.Bulk);
  }

  public virtual UsbEndpointReader OpenEndpointReader(
    ReadEndpointID readEndpointID,
    int readBufferSize,
    EndpointType endpointType)
  {
    foreach (UsbEndpointBase mActiveEndpoint in this.mActiveEndpoints)
    {
      if ((ReadEndpointID) mActiveEndpoint.EpNum == readEndpointID)
        return (UsbEndpointReader) mActiveEndpoint;
    }
    return (UsbEndpointReader) this.mActiveEndpoints.Add((UsbEndpointBase) new UsbEndpointReader(this, readBufferSize, readEndpointID, endpointType));
  }

  public bool GetAltInterfaceSetting(byte interfaceID, out byte selectedAltInterfaceID)
  {
    byte[] buffer = new byte[1];
    int lengthTransferred;
    int num = this.ControlTransfer(ref new UsbSetupPacket()
    {
      RequestType = (byte) 129,
      Request = (byte) 10,
      Value = (short) 0,
      Index = (short) interfaceID,
      Length = (short) 1
    }, (object) buffer, buffer.Length, out lengthTransferred) ? 1 : 0;
    if (num != 0 && lengthTransferred == 1)
    {
      selectedAltInterfaceID = buffer[0];
      return num != 0;
    }
    selectedAltInterfaceID = (byte) 0;
    return num != 0;
  }

  public static void Exit()
  {
    lock (MonoUsbDevice.OLockDeviceList)
    {
      if (MonoUsbDevice.mMonoUSBProfileList != null)
        MonoUsbDevice.mMonoUSBProfileList.Close();
      MonoUsbDevice.mMonoUSBProfileList = (MonoUsbProfileList) null;
    }
    MonoUsbApi.StopAndExit();
  }

  public enum DriverModeType
  {
    Unknown,
    LibUsb,
    WinUsb,
    MonoLibUsb,
    LibUsbWinBack,
  }
}
