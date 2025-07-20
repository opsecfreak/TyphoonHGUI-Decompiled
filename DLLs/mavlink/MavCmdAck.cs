// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavCmdAck
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

#nullable disable
namespace MavLinkNet;

public enum MavCmdAck
{
  Ok = 1,
  ErrFail = 2,
  ErrAccessDenied = 3,
  ErrNotSupported = 4,
  ErrCoordinateFrameNotSupported = 5,
  ErrCoordinatesOutOfRange = 6,
  ErrXLatOutOfRange = 7,
  ErrYLonOutOfRange = 8,
  ErrZAltOutOfRange = 9,
}
