// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavModeFlagDecodePosition
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

#nullable disable
namespace MavLinkNet;

public enum MavModeFlagDecodePosition
{
  CustomMode = 1,
  Test = 2,
  Auto = 4,
  Guided = 8,
  Stabilize = 16, // 0x00000010
  Hil = 32, // 0x00000020
  Manual = 64, // 0x00000040
  Safety = 128, // 0x00000080
}
