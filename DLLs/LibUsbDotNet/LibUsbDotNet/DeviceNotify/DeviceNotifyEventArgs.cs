// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.DeviceNotify.DeviceNotifyEventArgs
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.DeviceNotify.Info;
using System;

#nullable disable
namespace LibUsbDotNet.DeviceNotify;

public abstract class DeviceNotifyEventArgs : EventArgs
{
  internal IUsbDeviceNotifyInfo mDevice;
  internal DeviceType mDeviceType;
  internal EventType mEventType;
  internal object mObject;
  internal IPortNotifyInfo mPort;
  internal IVolumeNotifyInfo mVolume;

  public IVolumeNotifyInfo Volume => this.mVolume;

  public IPortNotifyInfo Port => this.mPort;

  public IUsbDeviceNotifyInfo Device => this.mDevice;

  public EventType EventType => this.mEventType;

  public DeviceType DeviceType => this.mDeviceType;

  public object Object => this.mObject;

  public override string ToString()
  {
    return $"[DeviceType:{this.DeviceType}] [EventType:{this.EventType}] {this.mObject.ToString()}";
  }
}
