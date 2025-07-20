// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.DeviceNotify.Linux.LinuxDeviceNotifyEventArgs
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.DeviceNotify.Info;
using System;

#nullable disable
namespace LibUsbDotNet.DeviceNotify.Linux;

public class LinuxDeviceNotifyEventArgs : DeviceNotifyEventArgs
{
  internal LinuxDeviceNotifyEventArgs(
    LinuxDevItem linuxDevItem,
    DeviceType deviceType,
    EventType eventType)
  {
    this.mEventType = eventType;
    this.mDeviceType = deviceType;
    switch (this.mDeviceType)
    {
      case DeviceType.Volume:
        throw new NotImplementedException(this.mDeviceType.ToString());
      case DeviceType.Port:
        throw new NotImplementedException(this.mDeviceType.ToString());
      case DeviceType.DeviceInterface:
        this.mDevice = (IUsbDeviceNotifyInfo) new LinuxUsbDeviceNotifyInfo(linuxDevItem);
        this.mObject = (object) this.mDevice;
        break;
    }
  }
}
