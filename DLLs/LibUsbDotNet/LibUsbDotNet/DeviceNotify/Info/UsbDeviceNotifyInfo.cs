// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.DeviceNotify.Info.UsbDeviceNotifyInfo
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.DeviceNotify.Internal;
using LibUsbDotNet.Main;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.DeviceNotify.Info;

public class UsbDeviceNotifyInfo : IUsbDeviceNotifyInfo
{
  private readonly DevBroadcastDeviceinterface mBaseHdr = new DevBroadcastDeviceinterface();
  private readonly string mName;
  private UsbSymbolicName mSymbolicName;

  internal UsbDeviceNotifyInfo(IntPtr lParam)
  {
    Marshal.PtrToStructure(lParam, (object) this.mBaseHdr);
    this.mName = Marshal.PtrToStringAuto(new IntPtr(lParam.ToInt64() + Marshal.OffsetOf(typeof (DevBroadcastDeviceinterface), "mNameHolder").ToInt64()));
  }

  public UsbSymbolicName SymbolicName
  {
    get
    {
      if (this.mSymbolicName == null)
        this.mSymbolicName = new UsbSymbolicName(this.mName);
      return this.mSymbolicName;
    }
  }

  public string Name => this.mName;

  public Guid ClassGuid => this.SymbolicName.ClassGuid;

  public int IdVendor => this.SymbolicName.Vid;

  public int IdProduct => this.SymbolicName.Pid;

  public string SerialNumber => this.SymbolicName.SerialNumber;

  public override string ToString() => this.SymbolicName.ToString();
}
