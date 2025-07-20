// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.DeviceNotify.Info.IVolumeNotifyInfo
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

#nullable disable
namespace LibUsbDotNet.DeviceNotify.Info;

public interface IVolumeNotifyInfo
{
  string Letter { get; }

  bool ChangeAffectsMediaInDrive { get; }

  bool IsNetworkVolume { get; }

  short Flags { get; }

  int Unitmask { get; }

  string ToString();
}
