// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.DeviceNotify.Internal.DevBroadcastVolume
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.DeviceNotify.Internal;

[StructLayout(LayoutKind.Sequential)]
internal class DevBroadcastVolume : DevBroadcastHdr
{
  public int UnitMask;
  public short Flags;

  public DevBroadcastVolume()
  {
    this.Size = Marshal.SizeOf((object) this);
    this.DeviceType = DeviceType.Volume;
  }
}
