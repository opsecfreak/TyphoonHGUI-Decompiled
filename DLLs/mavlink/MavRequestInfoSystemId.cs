// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavRequestInfoSystemId
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

#nullable disable
namespace MavLinkNet;

public enum MavRequestInfoSystemId
{
  Autopilot = 1,
  Gimbal = 2,
  Camera = 3,
  Remote = 4,
  Optflow = 5,
  Pc = 10, // 0x0000000A
  Uid = 11, // 0x0000000B
  GpsDbTest = 12, // 0x0000000C
}
