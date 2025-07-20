// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavParamUidDecryptCmd
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

#nullable disable
namespace MavLinkNet;

public enum MavParamUidDecryptCmd
{
  MavParamUidDecryptCmdNone = 0,
  MavParamUidDecryptCmdClear = 1,
  MavParamUidDecryptCmdDisNoFlyZone = 2,
  MavParamUidDecryptCmdCaliData = 3,
  MavParamUidDecryptCmdEnNoFlyZone = 8,
  MavParamUidDecryptCmdUnLock = 13138, // 0x00003352
}
