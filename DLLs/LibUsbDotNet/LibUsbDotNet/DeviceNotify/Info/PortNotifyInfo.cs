// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.DeviceNotify.Info.PortNotifyInfo
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.DeviceNotify.Internal;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.DeviceNotify.Info;

public class PortNotifyInfo : IPortNotifyInfo
{
  private readonly DevBroadcastPort mBaseHdr = new DevBroadcastPort();
  private readonly string mName;

  internal PortNotifyInfo(IntPtr lParam)
  {
    Marshal.PtrToStructure(lParam, (object) this.mBaseHdr);
    this.mName = Marshal.PtrToStringAuto(new IntPtr(lParam.ToInt64() + Marshal.OffsetOf(typeof (DevBroadcastPort), "mNameHolder").ToInt64()));
  }

  public string Name => this.mName;

  public override string ToString() => $"[Port Name:{this.Name}] ";
}
