// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavParamType
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

#nullable disable
namespace MavLinkNet;

public enum MavParamType
{
  Uint8 = 1,
  Int8 = 2,
  Uint16 = 3,
  Int16 = 4,
  Uint32 = 5,
  Int32 = 6,
  Uint64 = 7,
  Int64 = 8,
  Float = 9,
  Double = 10, // 0x0000000A
}
