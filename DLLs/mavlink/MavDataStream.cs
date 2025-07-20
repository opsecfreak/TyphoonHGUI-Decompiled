// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavDataStream
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

#nullable disable
namespace MavLinkNet;

public enum MavDataStream
{
  All = 0,
  RawSensors = 1,
  ExtendedStatus = 2,
  RcChannels = 3,
  RawController = 4,
  Position = 6,
  Extra1 = 10, // 0x0000000A
  Extra2 = 11, // 0x0000000B
  Extra3 = 12, // 0x0000000C
}
