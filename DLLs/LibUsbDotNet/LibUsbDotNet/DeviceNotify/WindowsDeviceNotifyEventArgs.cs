// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.DeviceNotify.WindowsDeviceNotifyEventArgs
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.DeviceNotify.Info;
using LibUsbDotNet.DeviceNotify.Internal;
using System;

#nullable disable
namespace LibUsbDotNet.DeviceNotify;

public class WindowsDeviceNotifyEventArgs : DeviceNotifyEventArgs
{
  private readonly DevBroadcastHdr mBaseHdr;

  internal WindowsDeviceNotifyEventArgs(DevBroadcastHdr hdr, IntPtr ptrHdr, EventType eventType)
  {
    this.mBaseHdr = hdr;
    this.mEventType = eventType;
    this.mDeviceType = this.mBaseHdr.DeviceType;
    switch (this.mDeviceType)
    {
      case DeviceType.Volume:
        this.mVolume = (IVolumeNotifyInfo) new VolumeNotifyInfo(ptrHdr);
        this.mObject = (object) this.mVolume;
        break;
      case DeviceType.Port:
        this.mPort = (IPortNotifyInfo) new PortNotifyInfo(ptrHdr);
        this.mObject = (object) this.mPort;
        break;
      case DeviceType.DeviceInterface:
        this.mDevice = (IUsbDeviceNotifyInfo) new UsbDeviceNotifyInfo(ptrHdr);
        this.mObject = (object) this.mDevice;
        break;
    }
  }
}
