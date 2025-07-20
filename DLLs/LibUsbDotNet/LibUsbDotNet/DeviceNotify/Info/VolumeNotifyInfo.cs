// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.DeviceNotify.Info.VolumeNotifyInfo
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.DeviceNotify.Internal;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.DeviceNotify.Info;

public class VolumeNotifyInfo : IVolumeNotifyInfo
{
  private const int DBTF_MEDIA = 1;
  private const int DBTF_NET = 2;
  private readonly DevBroadcastVolume mBaseHdr = new DevBroadcastVolume();

  internal VolumeNotifyInfo(IntPtr lParam)
  {
    Marshal.PtrToStructure(lParam, (object) this.mBaseHdr);
  }

  public string Letter
  {
    get
    {
      int unitmask = this.Unitmask;
      for (byte index = 65; index < (byte) 97; ++index)
      {
        byte num = index;
        if (num > (byte) 90)
          num -= (byte) 43;
        if ((unitmask & 1) == 1)
          return ((char) num).ToString();
        unitmask >>= 1;
      }
      return '?'.ToString();
    }
  }

  public bool ChangeAffectsMediaInDrive => ((int) this.Flags & 1) == 1;

  public bool IsNetworkVolume => ((int) this.Flags & 2) == 2;

  public short Flags => this.mBaseHdr.Flags;

  public int Unitmask => this.mBaseHdr.UnitMask;

  public override string ToString()
  {
    return $"[Letter:{this.Letter}] [IsNetworkVolume:{this.IsNetworkVolume}] [ChangeAffectsMediaInDrive:{this.ChangeAffectsMediaInDrive}] ";
  }
}
