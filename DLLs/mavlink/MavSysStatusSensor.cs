// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavSysStatusSensor
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

#nullable disable
namespace MavLinkNet;

public enum MavSysStatusSensor
{
  _3dGyro = 1,
  _3dAccel = 2,
  _3dMag = 4,
  AbsolutePressure = 8,
  DifferentialPressure = 16, // 0x00000010
  Gps = 32, // 0x00000020
  OpticalFlow = 64, // 0x00000040
  VisionPosition = 128, // 0x00000080
  LaserPosition = 256, // 0x00000100
  ExternalGroundTruth = 512, // 0x00000200
  AngularRateControl = 1024, // 0x00000400
  AttitudeStabilization = 2048, // 0x00000800
  YawPosition = 4096, // 0x00001000
  ZAltitudeControl = 8192, // 0x00002000
  XyPositionControl = 16384, // 0x00004000
  MotorOutputs = 32768, // 0x00008000
  RcReceiver = 65536, // 0x00010000
  Sonar = 8388608, // 0x00800000
  Optflow = 16777216, // 0x01000000
  RealSense = 33554432, // 0x02000000
}
