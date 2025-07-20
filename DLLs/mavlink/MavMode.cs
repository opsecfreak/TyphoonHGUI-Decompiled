// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavMode
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

#nullable disable
namespace MavLinkNet;

public enum MavMode
{
  Preflight = 0,
  ManualDisarmed = 64, // 0x00000040
  TestDisarmed = 66, // 0x00000042
  StabilizeDisarmed = 80, // 0x00000050
  GuidedDisarmed = 88, // 0x00000058
  AutoDisarmed = 92, // 0x0000005C
  ManualArmed = 192, // 0x000000C0
  TestArmed = 194, // 0x000000C2
  StabilizeArmed = 208, // 0x000000D0
  GuidedArmed = 216, // 0x000000D8
  AutoArmed = 220, // 0x000000DC
}
