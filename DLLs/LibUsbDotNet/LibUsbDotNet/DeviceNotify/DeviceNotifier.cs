// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.DeviceNotify.DeviceNotifier
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.DeviceNotify.Linux;

#nullable disable
namespace LibUsbDotNet.DeviceNotify;

public static class DeviceNotifier
{
  public static IDeviceNotifier OpenDeviceNotifier()
  {
    return UsbDevice.IsLinux ? (IDeviceNotifier) new LinuxDeviceNotifier() : (IDeviceNotifier) new WindowsDeviceNotifier();
  }
}
