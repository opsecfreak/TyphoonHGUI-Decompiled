// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavCmd
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

#nullable disable
namespace MavLinkNet;

public enum MavCmd
{
  NavWaypoint = 16, // 0x00000010
  NavLoiterUnlim = 17, // 0x00000011
  NavLoiterTurns = 18, // 0x00000012
  NavLoiterTime = 19, // 0x00000013
  NavReturnToLaunch = 20, // 0x00000014
  NavLand = 21, // 0x00000015
  NavTakeoff = 22, // 0x00000016
  NavRoi = 80, // 0x00000050
  NavPathplanning = 81, // 0x00000051
  NavLast = 95, // 0x0000005F
  ConditionDelay = 112, // 0x00000070
  ConditionChangeAlt = 113, // 0x00000071
  ConditionDistance = 114, // 0x00000072
  ConditionYaw = 115, // 0x00000073
  ConditionLast = 159, // 0x0000009F
  DoSetMode = 176, // 0x000000B0
  DoJump = 177, // 0x000000B1
  DoChangeSpeed = 178, // 0x000000B2
  DoSetHome = 179, // 0x000000B3
  DoSetParameter = 180, // 0x000000B4
  DoSetRelay = 181, // 0x000000B5
  DoRepeatRelay = 182, // 0x000000B6
  DoSetServo = 183, // 0x000000B7
  DoRepeatServo = 184, // 0x000000B8
  DoControlVideo = 200, // 0x000000C8
  DoSetRoi = 201, // 0x000000C9
  DoDigicamConfigure = 202, // 0x000000CA
  DoDigicamControl = 203, // 0x000000CB
  DoMountConfigure = 204, // 0x000000CC
  DoMountControl = 205, // 0x000000CD
  DoSetCamTriggDist = 206, // 0x000000CE
  DoTestMotor = 209, // 0x000000D1
  DoLast = 240, // 0x000000F0
  PreflightCalibration = 241, // 0x000000F1
  PreflightSetSensorOffsets = 242, // 0x000000F2
  PreflightStorage = 245, // 0x000000F5
  PreflightRebootShutdown = 246, // 0x000000F6
  OverrideGoto = 252, // 0x000000FC
  MissionStart = 300, // 0x0000012C
  ComponentArmDisarm = 400, // 0x00000190
  StartRxPair = 500, // 0x000001F4
}
