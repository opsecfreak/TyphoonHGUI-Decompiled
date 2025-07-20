// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Main.LegacyUsbRegistry
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Internal;
using LibUsbDotNet.Internal.LibUsb;
using LibUsbDotNet.LibUsb;
using LibUsbDotNet.LudnMonoLibUsb;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.Main;

public class LegacyUsbRegistry : UsbRegistry
{
  private readonly UsbDevice mUSBDevice;

  internal LegacyUsbRegistry(UsbDevice usbDevice)
  {
    this.mUSBDevice = usbDevice;
    LegacyUsbRegistry.GetPropertiesSPDRP(this.mUSBDevice, this.mDeviceProperties);
  }

  public override UsbDevice Device
  {
    get
    {
      UsbDevice usbDevice;
      this.Open(out usbDevice);
      return usbDevice;
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

  public override bool IsAlive
  {
    get
    {
      if (string.IsNullOrEmpty(this.SymbolicName))
        throw new UsbException((object) this, "A symbolic name is required for this property.");
      foreach (LegacyUsbRegistry device in LegacyUsbRegistry.DeviceList)
      {
        if (!string.IsNullOrEmpty(device.SymbolicName) && device.SymbolicName == this.SymbolicName)
          return true;
      }
      return false;
    }
  }

  public static List<LegacyUsbRegistry> DeviceList
  {
    get
    {
      List<LegacyUsbRegistry> deviceList = new List<LegacyUsbRegistry>();
      if (UsbDevice.IsLinux)
      {
        foreach (MonoUsbDevice monoUsbDevice in MonoUsbDevice.MonoUsbDeviceList)
          deviceList.Add(new LegacyUsbRegistry((UsbDevice) monoUsbDevice));
      }
      else
      {
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
                LegacyUsbRegistry legacyUsbRegistry = new LegacyUsbRegistry((UsbDevice) new LibUsbDevice((UsbApiBase) UsbDevice.LibUsbApi, (SafeHandle) usbHandle, deviceNameString));
                deviceList.Add(legacyUsbRegistry);
              }
              catch (Exception ex)
              {
              }
            }
          }
          if (usbHandle != null && !usbHandle.IsClosed)
            usbHandle.Close();
        }
      }
      return deviceList;
    }
  }

  public override int Rev
  {
    get
    {
      int result;
      return int.TryParse(this.mUSBDevice.Info.Descriptor.BcdDevice.ToString("X4"), out result) ? result : (int) (ushort) this.mUSBDevice.Info.Descriptor.BcdDevice;
    }
  }

  internal static string GetRegistryHardwareID(ushort vid, ushort pid, ushort rev)
  {
    return $"Vid_{vid:X4}&Pid_{pid:X4}&Rev_{rev.ToString("0000")}";
  }

  public override bool Open(out UsbDevice usbDevice)
  {
    usbDevice = (UsbDevice) null;
    int num = this.mUSBDevice.Open() ? 1 : 0;
    if (num == 0)
      return num != 0;
    usbDevice = this.mUSBDevice;
    usbDevice.mUsbRegistry = (UsbRegistry) this;
    return num != 0;
  }

  internal static void GetPropertiesSPDRP(
    UsbDevice usbDevice,
    Dictionary<string, object> deviceProperties)
  {
    Dictionary<string, object> dictionary1 = deviceProperties;
    DevicePropertyType devicePropertyType = DevicePropertyType.Mfg;
    string key1 = devicePropertyType.ToString();
    string str1 = usbDevice.Info.Descriptor.ManufacturerStringIndex > (byte) 0 ? usbDevice.Info.ManufacturerString : string.Empty;
    dictionary1.Add(key1, (object) str1);
    Dictionary<string, object> dictionary2 = deviceProperties;
    devicePropertyType = DevicePropertyType.DeviceDesc;
    string key2 = devicePropertyType.ToString();
    string str2 = usbDevice.Info.Descriptor.ProductStringIndex > (byte) 0 ? usbDevice.Info.ProductString : string.Empty;
    dictionary2.Add(key2, (object) str2);
    deviceProperties.Add("SerialNumber", usbDevice.Info.Descriptor.SerialStringIndex > (byte) 0 ? (object) usbDevice.Info.SerialString : (object) string.Empty);
    string registryHardwareId = LegacyUsbRegistry.GetRegistryHardwareID((ushort) usbDevice.Info.Descriptor.VendorID, (ushort) usbDevice.Info.Descriptor.ProductID, (ushort) usbDevice.Info.Descriptor.BcdDevice);
    Dictionary<string, object> dictionary3 = deviceProperties;
    devicePropertyType = DevicePropertyType.HardwareId;
    string key3 = devicePropertyType.ToString();
    string[] strArray = new string[1]{ registryHardwareId };
    dictionary3.Add(key3, (object) strArray);
    string str3 = $"{registryHardwareId}{{{(object) Guid.Empty} }}";
    if (usbDevice.Info.Descriptor.SerialStringIndex > (byte) 0)
      str3 = $"{str3}#{deviceProperties["SerialNumber"]}#";
    deviceProperties.Add("SymbolicName", (object) str3);
  }
}
