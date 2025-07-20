// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.LibUsb.LibUsbDevice
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Info;
using LibUsbDotNet.Internal;
using LibUsbDotNet.Internal.LibUsb;
using LibUsbDotNet.Main;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.LibUsb;

public class LibUsbDevice : UsbDevice, IUsbDevice, IUsbInterface
{
  private readonly List<int> mClaimedInterfaces = new List<int>();
  private readonly string mDeviceFilename;

  internal LibUsbDevice(UsbApiBase api, SafeHandle usbHandle, string deviceFilename)
    : base(api, usbHandle)
  {
    this.mDeviceFilename = deviceFilename;
  }

  public static List<LibUsbDevice> LegacyLibUsbDeviceList
  {
    get
    {
      List<LibUsbDevice> libUsbDeviceList = new List<LibUsbDevice>();
      for (int index = 1; index < 128 /*0x80*/; ++index)
      {
        LibUsbDevice usbDevice;
        if (LibUsbDevice.Open(LibUsbDriverIO.GetDeviceNameString(index), out usbDevice))
        {
          usbDevice.mDeviceInfo = new UsbDeviceInfo((UsbDevice) usbDevice);
          usbDevice.Close();
          libUsbDeviceList.Add(usbDevice);
        }
      }
      return libUsbDeviceList;
    }
  }

  public string DeviceFilename => this.mDeviceFilename;

  public override bool Open()
  {
    if (this.IsOpen)
      return true;
    this.mUsbHandle = (SafeHandle) LibUsbDriverIO.OpenDevice(this.mDeviceFilename);
    if (this.IsOpen)
      return true;
    UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), "LibUsbDevice.Open Failed", (object) this);
    return false;
  }

  public bool ClaimInterface(int interfaceID)
  {
    if (this.mClaimedInterfaces.Contains(interfaceID))
      return true;
    int num = this.UsbIoSync(LibUsbIoCtl.CLAIM_INTERFACE, (object) new LibUsbRequest()
    {
      Iface = {
        ID = interfaceID
      },
      Timeout = 1000
    }, LibUsbRequest.Size, IntPtr.Zero, 0, out int _) ? 1 : 0;
    if (num == 0)
      return num != 0;
    this.mClaimedInterfaces.Add(interfaceID);
    return num != 0;
  }

  public override UsbDevice.DriverModeType DriverMode => UsbDevice.DriverModeType.LibUsb;

  public override bool Close()
  {
    if (this.IsOpen)
    {
      this.ReleaseAllInterfaces();
      this.ActiveEndpoints.Clear();
      this.mUsbHandle.Close();
    }
    return true;
  }

  public bool ReleaseInterface(int interfaceID)
  {
    LibUsbRequest inBuffer = new LibUsbRequest();
    inBuffer.Iface.ID = interfaceID;
    if (!this.mClaimedInterfaces.Remove(interfaceID))
      return true;
    inBuffer.Timeout = 1000;
    return this.UsbIoSync(LibUsbIoCtl.RELEASE_INTERFACE, (object) inBuffer, LibUsbRequest.Size, IntPtr.Zero, 0, out int _);
  }

  public bool SetAltInterface(int alternateID)
  {
    if (this.mClaimedInterfaces.Count == 0)
      throw new UsbException((object) this, "You must claim an interface before setting an alternate interface.");
    return this.SetAltInterface(this.mClaimedInterfaces[this.mClaimedInterfaces.Count - 1], alternateID);
  }

  public bool SetConfiguration(byte config)
  {
    int num = this.ControlTransfer(ref new UsbSetupPacket()
    {
      RequestType = (byte) 0,
      Request = (byte) 9,
      Value = (short) config,
      Index = (short) 0,
      Length = (short) 0
    }, (object) null, 0, out int _) ? 1 : 0;
    if (num != 0)
    {
      this.mCurrentConfigValue = (int) config;
      return num != 0;
    }
    UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (SetConfiguration), (object) this);
    return num != 0;
  }

  public static bool Open(string deviceFilename, out LibUsbDevice usbDevice)
  {
    usbDevice = (LibUsbDevice) null;
    SafeFileHandle usbHandle = LibUsbDriverIO.OpenDevice(deviceFilename);
    if (usbHandle.IsClosed || usbHandle.IsInvalid)
      return false;
    usbDevice = new LibUsbDevice((UsbApiBase) UsbDevice.LibUsbApi, (SafeHandle) usbHandle, deviceFilename);
    return true;
  }

  public int ReleaseAllInterfaces()
  {
    int num = 0;
    while (this.mClaimedInterfaces.Count > 0)
    {
      ++num;
      this.ReleaseInterface(this.mClaimedInterfaces[this.mClaimedInterfaces.Count - num]);
    }
    return num;
  }

  public bool ReleaseInterface()
  {
    return this.mClaimedInterfaces.Count == 0 || this.ReleaseInterface(this.mClaimedInterfaces[this.mClaimedInterfaces.Count - 1]);
  }

  public bool SetAltInterface(int interfaceID, int alternateID)
  {
    if (!this.mClaimedInterfaces.Contains(interfaceID))
      throw new UsbException((object) this, $"You must claim interface {interfaceID} before setting an alternate interface.");
    return this.UsbIoSync(LibUsbIoCtl.SET_INTERFACE, (object) new LibUsbRequest()
    {
      Iface = {
        ID = interfaceID,
        AlternateID = alternateID
      },
      Timeout = 1000
    }, LibUsbRequest.Size, IntPtr.Zero, 0, out int _);
  }

  public bool ResetDevice()
  {
    if (!this.IsOpen)
      throw new UsbException((object) this, "Device is not opened.");
    this.ActiveEndpoints.Clear();
    int num = UsbDevice.LibUsbApi.ResetDevice(this.mUsbHandle) ? 1 : 0;
    if (num == 0)
    {
      UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), "ResetDevice Failed", (object) this);
      return num != 0;
    }
    this.Close();
    return num != 0;
  }

  internal bool ControlTransferEx(
    UsbSetupPacket setupPacket,
    IntPtr buffer,
    int bufferLength,
    out int lengthTransferred,
    int timeout)
  {
    return LibUsbDriverIO.ControlTransferEx(this.mUsbHandle, setupPacket, buffer, bufferLength, out lengthTransferred, timeout);
  }

  internal bool UsbIoSync(
    int controlCode,
    object inBuffer,
    int inSize,
    IntPtr outBuffer,
    int outSize,
    out int ret)
  {
    return LibUsbDriverIO.UsbIOSync(this.mUsbHandle, controlCode, inBuffer, inSize, outBuffer, outSize, out ret);
  }
}
