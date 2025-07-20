// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.LibUsb.LibUsbRegistry
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Internal;
using LibUsbDotNet.Internal.LibUsb;
using LibUsbDotNet.Main;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace LibUsbDotNet.LibUsb;

public class LibUsbRegistry : UsbRegistry
{
  private readonly string mDeviceFilename;
  private readonly int mDeviceIndex;

  private LibUsbRegistry(SafeFileHandle usbHandle, string deviceFileName, int deviceIndex)
  {
    this.mDeviceFilename = deviceFileName;
    this.mDeviceIndex = deviceIndex;
    this.GetPropertiesSPDRP((SafeHandle) usbHandle);
    string propData1;
    if (this.GetCustomDeviceKeyValue(usbHandle, "SymbolicName", out propData1, 512 /*0x0200*/) == ErrorCode.None)
      this.mDeviceProperties.Add("SymbolicName", (object) propData1);
    if (!this.mDeviceProperties.ContainsKey("SymbolicName") || string.IsNullOrEmpty(propData1))
    {
      if (!(this.mDeviceProperties[SPDRP.HardwareId.ToString()] is string[] mDeviceProperty) || mDeviceProperty.Length == 0)
      {
        LegacyUsbRegistry.GetPropertiesSPDRP((UsbDevice) new LibUsbDevice((UsbApiBase) UsbDevice.LibUsbApi, (SafeHandle) usbHandle, deviceFileName), this.mDeviceProperties);
        return;
      }
      if (mDeviceProperty.Length != 0)
        this.mDeviceProperties.Add("SymbolicName", (object) mDeviceProperty[0]);
    }
    string propData2;
    if (this.GetCustomDeviceKeyValue(usbHandle, "LibUsbInterfaceGUIDs", out propData2, 512 /*0x0200*/) != ErrorCode.None)
      return;
    this.mDeviceProperties.Add("LibUsbInterfaceGUIDs", (object) propData2.Split(new char[1], StringSplitOptions.RemoveEmptyEntries));
  }

  public int DeviceIndex => this.mDeviceIndex;

  public static List<LibUsbRegistry> DeviceList
  {
    get
    {
      List<LibUsbRegistry> deviceList = new List<LibUsbRegistry>();
      for (int index = 1; index < 128 /*0x80*/; ++index)
      {
        string deviceNameString = LibUsbDriverIO.GetDeviceNameString(index);
        SafeFileHandle usbHandle = LibUsbDriverIO.OpenDevice(deviceNameString);
        if (usbHandle != null && !usbHandle.IsInvalid)
        {
          if (!usbHandle.IsClosed)
          {
            try
            {
              LibUsbRegistry libUsbRegistry = new LibUsbRegistry(usbHandle, deviceNameString, index);
              deviceList.Add(libUsbRegistry);
            }
            catch (Exception ex)
            {
            }
          }
        }
        if (usbHandle != null && !usbHandle.IsClosed)
          usbHandle.Close();
      }
      return deviceList;
    }
  }

  public override bool IsAlive
  {
    get
    {
      if (string.IsNullOrEmpty(this.SymbolicName))
        throw new UsbException((object) this, "A symbolic name is required for this property.");
      foreach (LibUsbRegistry device in LibUsbRegistry.DeviceList)
      {
        if (!string.IsNullOrEmpty(device.SymbolicName) && device.SymbolicName == this.SymbolicName)
          return true;
      }
      return false;
    }
  }

  public override UsbDevice Device
  {
    get
    {
      LibUsbDevice usbDevice;
      this.Open(out usbDevice);
      return (UsbDevice) usbDevice;
    }
  }

  public override Guid[] DeviceInterfaceGuids
  {
    get
    {
      if (this.mDeviceInterfaceGuids == null)
      {
        if (!this.mDeviceProperties.ContainsKey("LibUsbInterfaceGUIDs"))
          return new Guid[0];
        if (!(this.mDeviceProperties["LibUsbInterfaceGUIDs"] is string[] mDeviceProperty))
          return new Guid[0];
        this.mDeviceInterfaceGuids = new Guid[mDeviceProperty.Length];
        for (int index = 0; index < mDeviceProperty.Length; ++index)
        {
          string g = mDeviceProperty[index].Trim(' ', '{', '}', '[', ']', char.MinValue);
          this.mDeviceInterfaceGuids[index] = new Guid(g);
        }
      }
      return this.mDeviceInterfaceGuids;
    }
  }

  public bool Open(out LibUsbDevice usbDevice)
  {
    int num = LibUsbDevice.Open(this.mDeviceFilename, out usbDevice) ? 1 : 0;
    if (num == 0)
      return num != 0;
    usbDevice.mUsbRegistry = (UsbRegistry) this;
    return num != 0;
  }

  public override bool Open(out UsbDevice usbDevice)
  {
    usbDevice = (UsbDevice) null;
    LibUsbDevice usbDevice1;
    int num = this.Open(out usbDevice1) ? 1 : 0;
    if (num == 0)
      return num != 0;
    usbDevice = (UsbDevice) usbDevice1;
    return num != 0;
  }

  internal ErrorCode GetCustomDeviceKeyValue(
    SafeFileHandle usbHandle,
    string key,
    out string propData,
    int maxDataLength)
  {
    byte[] propData1;
    ErrorCode customDeviceKeyValue = this.GetCustomDeviceKeyValue(usbHandle, key, out propData1, maxDataLength);
    if (customDeviceKeyValue == ErrorCode.None)
    {
      propData = Encoding.Unicode.GetString(propData1);
      propData.TrimEnd(new char[1]);
    }
    else
      propData = (string) null;
    return customDeviceKeyValue;
  }

  internal ErrorCode GetCustomDeviceKeyValue(
    SafeFileHandle usbHandle,
    string key,
    out byte[] propData,
    int maxDataLength)
  {
    ErrorCode customDeviceKeyValue = ErrorCode.None;
    propData = (byte[]) null;
    byte[] request = LibUsbDeviceRegistryKeyRequest.RegGetRequest(key, maxDataLength);
    GCHandle gcHandle = GCHandle.Alloc((object) request, GCHandleType.Pinned);
    int ret;
    int num = LibUsbDriverIO.UsbIOSync((SafeHandle) usbHandle, LibUsbIoCtl.GET_CUSTOM_REG_PROPERTY, (object) request, request.Length, gcHandle.AddrOfPinnedObject(), request.Length, out ret) ? 1 : 0;
    gcHandle.Free();
    if (num != 0)
    {
      propData = new byte[ret];
      Array.Copy((Array) request, (Array) propData, ret);
    }
    else
      customDeviceKeyValue = ErrorCode.GetDeviceKeyValueFailed;
    return customDeviceKeyValue;
  }

  private void GetPropertiesSPDRP(SafeHandle usbHandle)
  {
    byte[] buffer = new byte[1024 /*0x0400*/];
    GCHandle gcHandle = GCHandle.Alloc((object) buffer, GCHandleType.Pinned);
    LibUsbRequest inBuffer = new LibUsbRequest();
    foreach (KeyValuePair<string, int> keyValuePair in Helper.GetEnumData(typeof (DevicePropertyType)))
    {
      object obj = (object) string.Empty;
      inBuffer.DeviceProperty.ID = keyValuePair.Value;
      int ret;
      if (LibUsbDriverIO.UsbIOSync(usbHandle, LibUsbIoCtl.GET_REG_PROPERTY, (object) inBuffer, LibUsbRequest.Size, gcHandle.AddrOfPinnedObject(), buffer.Length, out ret))
      {
        switch (keyValuePair.Value)
        {
          case 0:
          case 5:
          case 6:
          case 7:
          case 8:
          case 9:
          case 10:
          case 11:
          case 15:
            obj = (object) UsbRegistry.GetAsString(buffer, ret);
            break;
          case 1:
          case 2:
            obj = (object) UsbRegistry.GetAsStringArray(buffer, ret);
            break;
          case 12:
            obj = (object) UsbRegistry.GetAsGuid(buffer, ret);
            break;
          case 13:
          case 14:
          case 16 /*0x10*/:
          case 17:
          case 18:
          case 19:
            obj = (object) UsbRegistry.GetAsStringInt32(buffer, ret);
            break;
        }
      }
      else
        obj = (object) string.Empty;
      this.mDeviceProperties.Add(keyValuePair.Key, obj);
    }
    gcHandle.Free();
  }
}
