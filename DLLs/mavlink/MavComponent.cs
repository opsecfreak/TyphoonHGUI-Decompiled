// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavComponent
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

#nullable disable
namespace MavLinkNet;

public enum MavComponent
{
  MavCompIdAll = 0,
  MavCompIdCamera = 100, // 0x00000064
  MavCompIdServo1 = 140, // 0x0000008C
  MavCompIdServo2 = 141, // 0x0000008D
  MavCompIdServo3 = 142, // 0x0000008E
  MavCompIdServo4 = 143, // 0x0000008F
  MavCompIdServo5 = 144, // 0x00000090
  MavCompIdServo6 = 145, // 0x00000091
  MavCompIdServo7 = 146, // 0x00000092
  MavCompIdServo8 = 147, // 0x00000093
  MavCompIdServo9 = 148, // 0x00000094
  MavCompIdServo10 = 149, // 0x00000095
  MavCompIdServo11 = 150, // 0x00000096
  MavCompIdServo12 = 151, // 0x00000097
  MavCompIdServo13 = 152, // 0x00000098
  MavCompIdServo14 = 153, // 0x00000099
  MavCompIdMapper = 180, // 0x000000B4
  MavCompIdMissionplanner = 190, // 0x000000BE
  MavCompIdPathplanner = 195, // 0x000000C3
  MavCompIdImu = 200, // 0x000000C8
  MavCompIdImu2 = 201, // 0x000000C9
  MavCompIdImu3 = 202, // 0x000000CA
  MavCompIdGps = 220, // 0x000000DC
  MavCompIdUdpBridge = 240, // 0x000000F0
  MavCompIdUartBridge = 241, // 0x000000F1
  MavCompIdSystemControl = 250, // 0x000000FA
}
