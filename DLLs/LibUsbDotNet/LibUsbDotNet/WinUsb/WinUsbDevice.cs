// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.WinUsb.WinUsbDevice
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Descriptors;
using LibUsbDotNet.Internal;
using LibUsbDotNet.Internal.WinUsb;
using LibUsbDotNet.Main;
using LibUsbDotNet.WinUsb.Internal;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.WinUsb;

public class WinUsbDevice : UsbDevice, IUsbInterface
{
  private readonly string mDevicePath;
  private PowerPolicies mPowerPolicies;
  private SafeFileHandle mSafeDevHandle;

  internal WinUsbDevice(
    UsbApiBase usbApi,
    SafeFileHandle usbHandle,
    SafeHandle handle,
    string devicePath)
    : base(usbApi, handle)
  {
    this.mDevicePath = devicePath;
    this.mSafeDevHandle = usbHandle;
    this.mPowerPolicies = new PowerPolicies(this);
  }

  public PowerPolicies PowerPolicy => this.mPowerPolicies;

  public string DevicePath => this.mDevicePath;

  public override UsbDevice.DriverModeType DriverMode => UsbDevice.DriverModeType.WinUsb;

  public override bool Close()
  {
    if (this.IsOpen)
    {
      this.ActiveEndpoints.Clear();
      this.mUsbHandle.Close();
      if (this.mSafeDevHandle != null && !this.mSafeDevHandle.IsClosed)
        this.mSafeDevHandle.Close();
    }
    return true;
  }

  public override bool Open()
  {
    if (this.IsOpen)
      return true;
    SafeFileHandle sfhDevice;
    bool flag = WinUsbAPI.OpenDevice(out sfhDevice, this.mDevicePath);
    if (flag)
    {
      SafeWinUsbInterfaceHandle InterfaceHandle = new SafeWinUsbInterfaceHandle();
      if (flag = WinUsbAPI.WinUsb_Initialize((SafeHandle) sfhDevice, ref InterfaceHandle))
      {
        this.mSafeDevHandle = sfhDevice;
        this.mUsbHandle = (SafeHandle) InterfaceHandle;
        this.mPowerPolicies = new PowerPolicies(this);
      }
      else
        UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), "Open:Initialize", (object) typeof (UsbDevice));
    }
    else
      UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (Open), (object) typeof (UsbDevice));
    return flag;
  }

  public static bool Open(string devicePath, out WinUsbDevice usbDevice)
  {
    usbDevice = (WinUsbDevice) null;
    SafeFileHandle sfhDevice;
    bool flag = WinUsbAPI.OpenDevice(out sfhDevice, devicePath);
    if (flag)
    {
      SafeWinUsbInterfaceHandle InterfaceHandle = new SafeWinUsbInterfaceHandle();
      flag = WinUsbAPI.WinUsb_Initialize((SafeHandle) sfhDevice, ref InterfaceHandle);
      if (flag)
        usbDevice = new WinUsbDevice((UsbApiBase) UsbDevice.WinUsbApi, sfhDevice, (SafeHandle) InterfaceHandle, devicePath);
      else
        UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), "Open:Initialize", (object) typeof (UsbDevice));
    }
    else
      UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (Open), (object) typeof (UsbDevice));
    return flag;
  }

  public PipePolicies EndpointPolicies(ReadEndpointID epNum)
  {
    return new PipePolicies(this.mUsbHandle, (byte) epNum);
  }

  public PipePolicies EndpointPolicies(WriteEndpointID epNum)
  {
    return new PipePolicies(this.mUsbHandle, (byte) epNum);
  }

  public bool GetAssociatedInterface(byte associatedInterfaceIndex, out WinUsbDevice usbDevice)
  {
    usbDevice = (WinUsbDevice) null;
    IntPtr zero = IntPtr.Zero;
    int num = WinUsbAPI.WinUsb_GetAssociatedInterface(this.mUsbHandle, associatedInterfaceIndex, ref zero) ? 1 : 0;
    if (num != 0)
    {
      SafeWinUsbInterfaceHandle handle = new SafeWinUsbInterfaceHandle(zero);
      usbDevice = new WinUsbDevice(this.mUsbApi, (SafeFileHandle) null, (SafeHandle) handle, this.mDevicePath);
    }
    if (num != 0)
      return num != 0;
    UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (GetAssociatedInterface), (object) this);
    return num != 0;
  }

  public bool GetCurrentAlternateSetting(out byte settingNumber)
  {
    int num = WinUsbAPI.WinUsb_GetCurrentAlternateSetting(this.mUsbHandle, out settingNumber) ? 1 : 0;
    if (num != 0)
      return num != 0;
    UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (GetCurrentAlternateSetting), (object) this);
    return num != 0;
  }

  public bool QueryDeviceSpeed(out DeviceSpeedTypes deviceSpeed)
  {
    deviceSpeed = DeviceSpeedTypes.Undefined;
    byte[] Buffer = new byte[1];
    int BufferLength = 1;
    int num = WinUsbAPI.WinUsb_QueryDeviceInformation(this.mUsbHandle, DeviceInformationTypes.DeviceSpeed, ref BufferLength, (object) Buffer) ? 1 : 0;
    if (num != 0)
    {
      deviceSpeed = (DeviceSpeedTypes) Buffer[0];
      return num != 0;
    }
    UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), "QueryDeviceInformation:QueryDeviceSpeed", (object) this);
    return num != 0;
  }

  public bool QueryInterfaceSettings(
    byte alternateInterfaceNumber,
    ref UsbInterfaceDescriptor usbAltInterfaceDescriptor)
  {
    int num = WinUsbAPI.WinUsb_QueryInterfaceSettings(this.Handle, alternateInterfaceNumber, usbAltInterfaceDescriptor) ? 1 : 0;
    if (num != 0)
      return num != 0;
    UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (QueryInterfaceSettings), (object) this);
    return num != 0;
  }

  internal bool GetPowerPolicy(PowerPolicyType policyType, ref int valueLength, IntPtr pBuffer)
  {
    int num = WinUsbAPI.WinUsb_GetPowerPolicy(this.mUsbHandle, policyType, ref valueLength, pBuffer) ? 1 : 0;
    if (num != 0)
      return num != 0;
    UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (GetPowerPolicy), (object) this);
    return num != 0;
  }

  public static bool GetDevicePathList(Guid interfaceGuid, out List<string> devicePathList)
  {
    return WinUsbRegistry.GetDevicePathList(interfaceGuid, out devicePathList);
  }

  internal bool SetPowerPolicy(PowerPolicyType policyType, int valueLength, IntPtr pBuffer)
  {
    int num = WinUsbAPI.WinUsb_SetPowerPolicy(this.mUsbHandle, policyType, valueLength, pBuffer) ? 1 : 0;
    if (num != 0)
      return num != 0;
    UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (SetPowerPolicy), (object) this);
    return num != 0;
  }

  ~WinUsbDevice() => this.Close();
}
