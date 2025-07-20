// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavModeFlag
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

#nullable disable
namespace MavLinkNet;

public enum MavModeFlag
{
  CustomModeEnabled = 1,
  TestEnabled = 2,
  AutoEnabled = 4,
  GuidedEnabled = 8,
  StabilizeEnabled = 16, // 0x00000010
  HilEnabled = 32, // 0x00000020
  ManualInputEnabled = 64, // 0x00000040
  SafetyArmed = 128, // 0x00000080
}
