// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasSummary
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.Collections.Generic;

#nullable disable
namespace MavLinkNet;

public class UasSummary
{
  private static Dictionary<string, UasEnumMetadata> mEnums;

  public static UasMessage CreateFromId(byte id)
  {
    switch (id)
    {
      case 0:
        return (UasMessage) new UasHeartbeat();
      case 1:
        return (UasMessage) new UasSysStatus();
      case 2:
        return (UasMessage) new UasSystemTime();
      case 4:
        return (UasMessage) new UasPing();
      case 5:
        return (UasMessage) new UasChangeOperatorControl();
      case 6:
        return (UasMessage) new UasChangeOperatorControlAck();
      case 7:
        return (UasMessage) new MavLinkCalibrationData();
      case 11:
        return (UasMessage) new UasSetMode();
      case 20:
        return (UasMessage) new UasParamRequestRead();
      case 21:
        return (UasMessage) new UasParamRequestList();
      case 22:
        return (UasMessage) new UasParamValue();
      case 23:
        return (UasMessage) new UasParamSet();
      case 24:
        return (UasMessage) new UasGpsRawInt();
      case 25:
        return (UasMessage) new UasGpsStatus();
      case 26:
        return (UasMessage) new UasScaledImu();
      case 27:
        return (UasMessage) new UasRawImu();
      case 28:
        return (UasMessage) new UasRawPressure();
      case 29:
        return (UasMessage) new UasScaledPressure();
      case 30:
        return (UasMessage) new UasAttitude();
      case 31 /*0x1F*/:
        return (UasMessage) new UasAttitudeQuaternion();
      case 32 /*0x20*/:
        return (UasMessage) new UasLocalPositionNed();
      case 33:
        return (UasMessage) new UasGlobalPositionInt();
      case 34:
        return (UasMessage) new UasRcChannelsScaled();
      case 35:
        return (UasMessage) new UasRcChannelsRaw();
      case 36:
        return (UasMessage) new UasServoOutputRaw();
      case 37:
        return (UasMessage) new UasMissionRequestPartialList();
      case 38:
        return (UasMessage) new UasMissionWritePartialList();
      case 39:
        return (UasMessage) new UasMissionItem();
      case 40:
        return (UasMessage) new UasMissionRequest();
      case 41:
        return (UasMessage) new UasMissionSetCurrent();
      case 42:
        return (UasMessage) new UasMissionCurrent();
      case 43:
        return (UasMessage) new UasMissionRequestList();
      case 44:
        return (UasMessage) new UasMissionCount();
      case 45:
        return (UasMessage) new UasMissionClearAll();
      case 46:
        return (UasMessage) new UasMissionItemReached();
      case 47:
        return (UasMessage) new UasMissionAck();
      case 48 /*0x30*/:
        return (UasMessage) new UasSetGpsGlobalOrigin();
      case 49:
        return (UasMessage) new UasGpsGlobalOrigin();
      case 50:
        return (UasMessage) new UasSetLocalPositionSetpoint();
      case 51:
        return (UasMessage) new MavlinkRequestInfoCmd();
      case 52:
        return (UasMessage) new MavlinkRequestInfoFeedback();
      case 53:
        return (UasMessage) new UasSetGlobalPositionSetpointInt();
      case 54:
        return (UasMessage) new UasSafetySetAllowedArea();
      case 55:
        return (UasMessage) new UasSafetyAllowedArea();
      case 56:
        return (UasMessage) new MavLinkMsgIdSendUid();
      case 57:
        return (UasMessage) new MavlinkUidDecryptCmd();
      case 58:
        return (UasMessage) new MavlinkAckUidDecryptCmd();
      case 59:
        return (UasMessage) new UasRollPitchYawSpeedThrustSetpoint();
      case 60:
        return (UasMessage) new UasSetQuadMotorsSetpoint();
      case 61:
        return (UasMessage) new UasSetQuadSwarmRollPitchYawThrust();
      case 62:
        return (UasMessage) new UasNavControllerOutput();
      case 63 /*0x3F*/:
        return (UasMessage) new UasSetQuadSwarmLedRollPitchYawThrust();
      case 64 /*0x40*/:
        return (UasMessage) new UasStateCorrection();
      case 65:
        return (UasMessage) new MavLinkMsgIdRcChannels();
      case 66:
        return (UasMessage) new UasRequestDataStream();
      case 67:
        return (UasMessage) new UasDataStream();
      case 69:
        return (UasMessage) new UasManualControl();
      case 70:
        return (UasMessage) new UasRcChannelsOverride();
      case 74:
        return (UasMessage) new UasVfrHud();
      case 76:
        return (UasMessage) new UasCommandLong();
      case 77:
        return (UasMessage) new UasCommandAck();
      case 80 /*0x50*/:
        return (UasMessage) new UasRollPitchYawRatesThrustSetpoint();
      case 81:
        return (UasMessage) new UasManualSetpoint();
      case 89:
        return (UasMessage) new UasLocalPositionNedSystemGlobalOffset();
      case 90:
        return (UasMessage) new UasHilState();
      case 91:
        return (UasMessage) new UasHilControls();
      case 92:
        return (UasMessage) new UasHilRcInputsRaw();
      case 100:
        return (UasMessage) new UasOpticalFlow();
      case 101:
        return (UasMessage) new UasGlobalVisionPositionEstimate();
      case 102:
        return (UasMessage) new UasVisionPositionEstimate();
      case 103:
        return (UasMessage) new UasVisionSpeedEstimate();
      case 104:
        return (UasMessage) new UasViconPositionEstimate();
      case 105:
        return (UasMessage) new UasHighresImu();
      case 106:
        return (UasMessage) new UasOmnidirectionalFlow();
      case 107:
        return (UasMessage) new UasHilSensor();
      case 108:
        return (UasMessage) new UasSimState();
      case 109:
        return (UasMessage) new UasRadioStatus();
      case 110:
        return (UasMessage) new UasFileTransferStart();
      case 111:
        return (UasMessage) new UasFileTransferDirList();
      case 112 /*0x70*/:
        return (UasMessage) new UasFileTransferRes();
      case 113:
        return (UasMessage) new UasHilGps();
      case 114:
        return (UasMessage) new UasHilOpticalFlow();
      case 115:
        return (UasMessage) new UasHilStateQuaternion();
      case 117:
        return (UasMessage) new UasMavlinkLogRequestList();
      case 118:
        return (UasMessage) new UasMavlinkLogEntry();
      case 119:
        return (UasMessage) new UasMavlinkLogRequestData();
      case 120:
        return (UasMessage) new UasMavlinkLogData();
      case 139:
        return (UasMessage) new UasSetActuatorControlTarget();
      case 147:
        return (UasMessage) new UasBatteryStatus();
      case 148:
        return (UasMessage) new UasSetpoint8dof();
      case 149:
        return (UasMessage) new UasSetpoint6dof();
      case 150:
        return (UasMessage) new UasSensorOffsets();
      case 151:
        return (UasMessage) new UasSetMagOffsets();
      case 152:
        return (UasMessage) new UasMeminfo();
      case 153:
        return (UasMessage) new UasApAdc();
      case 154:
        return (UasMessage) new UasDigicamConfigure();
      case 155:
        return (UasMessage) new UasDigicamControl();
      case 156:
        return (UasMessage) new UasMountConfigure();
      case 157:
        return (UasMessage) new UasMountControl();
      case 158:
        return (UasMessage) new UasMountStatus();
      case 160 /*0xA0*/:
        return (UasMessage) new UasFencePoint();
      case 161:
        return (UasMessage) new UasFenceFetchPoint();
      case 162:
        return (UasMessage) new UasFenceStatus();
      case 163:
        return (UasMessage) new UasAhrs();
      case 164:
        return (UasMessage) new UasSimstate();
      case 165:
        return (UasMessage) new UasHwstatus();
      case 166:
        return (UasMessage) new UasRadio();
      case 167:
        return (UasMessage) new UasLimitsStatus();
      case 168:
        return (UasMessage) new UasWind();
      case 169:
        return (UasMessage) new UasData16();
      case 170:
        return (UasMessage) new UasData32();
      case 171:
        return (UasMessage) new UasData64();
      case 172:
        return (UasMessage) new UasData96();
      case 173:
        return (UasMessage) new UasRangefinder();
      case 174:
        return (UasMessage) new UasAirspeedAutocal();
      case 175:
        return (UasMessage) new UasRallyPoint();
      case 176 /*0xB0*/:
        return (UasMessage) new UasRallyFetchPoint();
      case 193:
        return (UasMessage) new MavlinkEkfStatusReport();
      case 249:
        return (UasMessage) new UasMemoryVect();
      case 250:
        return (UasMessage) new UasDebugVect();
      case 251:
        return (UasMessage) new UasNamedValueFloat();
      case 252:
        return (UasMessage) new UasNamedValueInt();
      case 253:
        return (UasMessage) new UasStatustext();
      case 254:
        return (UasMessage) new UasDebug();
      default:
        return (UasMessage) null;
    }
  }

  public static byte GetCrcExtraForId(byte id)
  {
    switch (id)
    {
      case 0:
        return 50;
      case 1:
        return 124;
      case 2:
        return 137;
      case 4:
        return 237;
      case 5:
        return 217;
      case 6:
        return 104;
      case 7:
        return 119;
      case 11:
        return 89;
      case 20:
        return 214;
      case 21:
        return 159;
      case 22:
        return 220;
      case 23:
        return 168;
      case 24:
        return 24;
      case 25:
        return 23;
      case 26:
        return 170;
      case 27:
        return 144 /*0x90*/;
      case 28:
        return 67;
      case 29:
        return 115;
      case 30:
        return 39;
      case 31 /*0x1F*/:
        return 246;
      case 32 /*0x20*/:
        return 185;
      case 33:
        return 104;
      case 34:
        return 237;
      case 35:
        return 244;
      case 36:
        return 222;
      case 37:
        return 212;
      case 38:
        return 9;
      case 39:
        return 254;
      case 40:
        return 230;
      case 41:
        return 28;
      case 42:
        return 28;
      case 43:
        return 132;
      case 44:
        return 221;
      case 45:
        return 232;
      case 46:
        return 11;
      case 47:
        return 153;
      case 48 /*0x30*/:
        return 41;
      case 49:
        return 39;
      case 50:
        return 214;
      case 51:
        return 132;
      case 52:
        return 218;
      case 53:
        return 33;
      case 54:
        return 15;
      case 55:
        return 3;
      case 56:
        return 7;
      case 57:
        return 24;
      case 58:
        return 239;
      case 59:
        return 238;
      case 60:
        return 30;
      case 61:
        return 240 /*0xF0*/;
      case 62:
        return 183;
      case 63 /*0x3F*/:
        return 130;
      case 64 /*0x40*/:
        return 130;
      case 66:
        return 148;
      case 67:
        return 21;
      case 69:
        return 243;
      case 70:
        return 124;
      case 74:
        return 20;
      case 76:
        return 152;
      case 77:
        return 143;
      case 80 /*0x50*/:
        return 127 /*0x7F*/;
      case 81:
        return 106;
      case 89:
        return 231;
      case 90:
        return 183;
      case 91:
        return 63 /*0x3F*/;
      case 92:
        return 54;
      case 100:
        return 175;
      case 101:
        return 102;
      case 102:
        return 158;
      case 103:
        return 208 /*0xD0*/;
      case 104:
        return 56;
      case 105:
        return 93;
      case 106:
        return 211;
      case 107:
        return 108;
      case 108:
        return 32 /*0x20*/;
      case 109:
        return 185;
      case 110:
        return 235;
      case 111:
        return 93;
      case 112 /*0x70*/:
        return 124;
      case 113:
        return 124;
      case 114:
        return 119;
      case 115:
        return 4;
      case 117:
        return 128 /*0x80*/;
      case 118:
        return 56;
      case 119:
        return 116;
      case 120:
        return 134;
      case 139:
        return 168;
      case 147:
        return 177;
      case 148:
        return 241;
      case 149:
        return 15;
      case 150:
        return 134;
      case 151:
        return 219;
      case 152:
        return 208 /*0xD0*/;
      case 153:
        return 188;
      case 154:
        return 84;
      case 155:
        return 22;
      case 156:
        return 19;
      case 157:
        return 21;
      case 158:
        return 134;
      case 160 /*0xA0*/:
        return 78;
      case 161:
        return 68;
      case 162:
        return 189;
      case 163:
        return 127 /*0x7F*/;
      case 164:
        return 154;
      case 165:
        return 21;
      case 166:
        return 21;
      case 167:
        return 144 /*0x90*/;
      case 168:
        return 1;
      case 169:
        return 234;
      case 170:
        return 73;
      case 171:
        return 181;
      case 172:
        return 22;
      case 173:
        return 83;
      case 174:
        return 167;
      case 175:
        return 138;
      case 176 /*0xB0*/:
        return 234;
      case 249:
        return 204;
      case 250:
        return 49;
      case 251:
        return 170;
      case 252:
        return 44;
      case 253:
        return 83;
      case 254:
        return 86;
      default:
        return 0;
    }
  }

  public static UasEnumMetadata GetEnumMetadata(string enumName)
  {
    if (UasSummary.mEnums == null)
      UasSummary.InitEnumMetadata();
    return UasSummary.mEnums[enumName];
  }

  private static void InitEnumMetadata()
  {
    UasSummary.mEnums = new Dictionary<string, UasEnumMetadata>();
    UasEnumMetadata uasEnumMetadata1 = new UasEnumMetadata()
    {
      Name = "MavAutopilot",
      Description = "Micro air vehicle / autopilot classes. This identifies the individual model."
    };
    UasEnumEntryMetadata enumEntryMetadata1 = new UasEnumEntryMetadata()
    {
      Value = 0,
      Name = "Generic",
      Description = "Generic autopilot, full support for everything"
    };
    uasEnumMetadata1.Entries.Add(enumEntryMetadata1);
    UasEnumEntryMetadata enumEntryMetadata2 = new UasEnumEntryMetadata()
    {
      Value = 1,
      Name = "Pixhawk",
      Description = "PIXHAWK autopilot, http://pixhawk.ethz.ch"
    };
    uasEnumMetadata1.Entries.Add(enumEntryMetadata2);
    UasEnumEntryMetadata enumEntryMetadata3 = new UasEnumEntryMetadata()
    {
      Value = 2,
      Name = "Slugs",
      Description = "SLUGS autopilot, http://slugsuav.soe.ucsc.edu"
    };
    uasEnumMetadata1.Entries.Add(enumEntryMetadata3);
    UasEnumEntryMetadata enumEntryMetadata4 = new UasEnumEntryMetadata()
    {
      Value = 3,
      Name = "Ardupilotmega",
      Description = "ArduPilotMega / ArduCopter, http://diydrones.com"
    };
    uasEnumMetadata1.Entries.Add(enumEntryMetadata4);
    UasEnumEntryMetadata enumEntryMetadata5 = new UasEnumEntryMetadata()
    {
      Value = 4,
      Name = "Openpilot",
      Description = "OpenPilot, http://openpilot.org"
    };
    uasEnumMetadata1.Entries.Add(enumEntryMetadata5);
    UasEnumEntryMetadata enumEntryMetadata6 = new UasEnumEntryMetadata()
    {
      Value = 5,
      Name = "GenericWaypointsOnly",
      Description = "Generic autopilot only supporting simple waypoints"
    };
    uasEnumMetadata1.Entries.Add(enumEntryMetadata6);
    UasEnumEntryMetadata enumEntryMetadata7 = new UasEnumEntryMetadata()
    {
      Value = 6,
      Name = "GenericWaypointsAndSimpleNavigationOnly",
      Description = "Generic autopilot supporting waypoints and other simple navigation commands"
    };
    uasEnumMetadata1.Entries.Add(enumEntryMetadata7);
    UasEnumEntryMetadata enumEntryMetadata8 = new UasEnumEntryMetadata()
    {
      Value = 7,
      Name = "GenericMissionFull",
      Description = "Generic autopilot supporting the full mission command set"
    };
    uasEnumMetadata1.Entries.Add(enumEntryMetadata8);
    UasEnumEntryMetadata enumEntryMetadata9 = new UasEnumEntryMetadata()
    {
      Value = 8,
      Name = "Invalid",
      Description = "No valid autopilot, e.g. a GCS or other MAVLink component"
    };
    uasEnumMetadata1.Entries.Add(enumEntryMetadata9);
    UasEnumEntryMetadata enumEntryMetadata10 = new UasEnumEntryMetadata()
    {
      Value = 9,
      Name = "Ppz",
      Description = "PPZ UAV - http://nongnu.org/paparazzi"
    };
    uasEnumMetadata1.Entries.Add(enumEntryMetadata10);
    UasEnumEntryMetadata enumEntryMetadata11 = new UasEnumEntryMetadata()
    {
      Value = 10,
      Name = "Udb",
      Description = "UAV Dev Board"
    };
    uasEnumMetadata1.Entries.Add(enumEntryMetadata11);
    UasEnumEntryMetadata enumEntryMetadata12 = new UasEnumEntryMetadata()
    {
      Value = 11,
      Name = "Fp",
      Description = "FlexiPilot"
    };
    uasEnumMetadata1.Entries.Add(enumEntryMetadata12);
    UasEnumEntryMetadata enumEntryMetadata13 = new UasEnumEntryMetadata()
    {
      Value = 12,
      Name = "Px4",
      Description = "PX4 Autopilot - http://pixhawk.ethz.ch/px4/"
    };
    uasEnumMetadata1.Entries.Add(enumEntryMetadata13);
    UasEnumEntryMetadata enumEntryMetadata14 = new UasEnumEntryMetadata()
    {
      Value = 13,
      Name = "Smaccmpilot",
      Description = "SMACCMPilot - http://smaccmpilot.org"
    };
    uasEnumMetadata1.Entries.Add(enumEntryMetadata14);
    UasEnumEntryMetadata enumEntryMetadata15 = new UasEnumEntryMetadata()
    {
      Value = 14,
      Name = "Autoquad",
      Description = "AutoQuad -- http://autoquad.org"
    };
    uasEnumMetadata1.Entries.Add(enumEntryMetadata15);
    UasEnumEntryMetadata enumEntryMetadata16 = new UasEnumEntryMetadata()
    {
      Value = 15,
      Name = "Armazila",
      Description = "Armazila -- http://armazila.com"
    };
    uasEnumMetadata1.Entries.Add(enumEntryMetadata16);
    UasEnumEntryMetadata enumEntryMetadata17 = new UasEnumEntryMetadata()
    {
      Value = 16 /*0x10*/,
      Name = "Aerob",
      Description = "Aerob -- http://aerob.ru"
    };
    uasEnumMetadata1.Entries.Add(enumEntryMetadata17);
    UasSummary.mEnums.Add(uasEnumMetadata1.Name, uasEnumMetadata1);
    UasEnumMetadata uasEnumMetadata2 = new UasEnumMetadata()
    {
      Name = "MavType",
      Description = ""
    };
    UasEnumEntryMetadata enumEntryMetadata18 = new UasEnumEntryMetadata()
    {
      Value = 0,
      Name = "Generic",
      Description = "Generic micro air vehicle."
    };
    uasEnumMetadata2.Entries.Add(enumEntryMetadata18);
    UasEnumEntryMetadata enumEntryMetadata19 = new UasEnumEntryMetadata()
    {
      Value = 1,
      Name = "FixedWing",
      Description = "Fixed wing aircraft."
    };
    uasEnumMetadata2.Entries.Add(enumEntryMetadata19);
    UasEnumEntryMetadata enumEntryMetadata20 = new UasEnumEntryMetadata()
    {
      Value = 2,
      Name = "Quadrotor",
      Description = "Quadrotor"
    };
    uasEnumMetadata2.Entries.Add(enumEntryMetadata20);
    UasEnumEntryMetadata enumEntryMetadata21 = new UasEnumEntryMetadata()
    {
      Value = 3,
      Name = "Coaxial",
      Description = "Coaxial helicopter"
    };
    uasEnumMetadata2.Entries.Add(enumEntryMetadata21);
    UasEnumEntryMetadata enumEntryMetadata22 = new UasEnumEntryMetadata()
    {
      Value = 4,
      Name = "Helicopter",
      Description = "Normal helicopter with tail rotor."
    };
    uasEnumMetadata2.Entries.Add(enumEntryMetadata22);
    UasEnumEntryMetadata enumEntryMetadata23 = new UasEnumEntryMetadata()
    {
      Value = 5,
      Name = "AntennaTracker",
      Description = "Ground installation"
    };
    uasEnumMetadata2.Entries.Add(enumEntryMetadata23);
    UasEnumEntryMetadata enumEntryMetadata24 = new UasEnumEntryMetadata()
    {
      Value = 6,
      Name = "Gcs",
      Description = "Operator control unit / ground control station"
    };
    uasEnumMetadata2.Entries.Add(enumEntryMetadata24);
    UasEnumEntryMetadata enumEntryMetadata25 = new UasEnumEntryMetadata()
    {
      Value = 7,
      Name = "Airship",
      Description = "Airship, controlled"
    };
    uasEnumMetadata2.Entries.Add(enumEntryMetadata25);
    UasEnumEntryMetadata enumEntryMetadata26 = new UasEnumEntryMetadata()
    {
      Value = 8,
      Name = "FreeBalloon",
      Description = "Free balloon, uncontrolled"
    };
    uasEnumMetadata2.Entries.Add(enumEntryMetadata26);
    UasEnumEntryMetadata enumEntryMetadata27 = new UasEnumEntryMetadata()
    {
      Value = 9,
      Name = "Rocket",
      Description = "Rocket"
    };
    uasEnumMetadata2.Entries.Add(enumEntryMetadata27);
    UasEnumEntryMetadata enumEntryMetadata28 = new UasEnumEntryMetadata()
    {
      Value = 10,
      Name = "GroundRover",
      Description = "Ground rover"
    };
    uasEnumMetadata2.Entries.Add(enumEntryMetadata28);
    UasEnumEntryMetadata enumEntryMetadata29 = new UasEnumEntryMetadata()
    {
      Value = 11,
      Name = "SurfaceBoat",
      Description = "Surface vessel, boat, ship"
    };
    uasEnumMetadata2.Entries.Add(enumEntryMetadata29);
    UasEnumEntryMetadata enumEntryMetadata30 = new UasEnumEntryMetadata()
    {
      Value = 12,
      Name = "Submarine",
      Description = "Submarine"
    };
    uasEnumMetadata2.Entries.Add(enumEntryMetadata30);
    UasEnumEntryMetadata enumEntryMetadata31 = new UasEnumEntryMetadata()
    {
      Value = 13,
      Name = "Hexarotor",
      Description = "Hexarotor"
    };
    uasEnumMetadata2.Entries.Add(enumEntryMetadata31);
    UasEnumEntryMetadata enumEntryMetadata32 = new UasEnumEntryMetadata()
    {
      Value = 14,
      Name = "Octorotor",
      Description = "Octorotor"
    };
    uasEnumMetadata2.Entries.Add(enumEntryMetadata32);
    UasEnumEntryMetadata enumEntryMetadata33 = new UasEnumEntryMetadata()
    {
      Value = 15,
      Name = "Tricopter",
      Description = "Octorotor"
    };
    uasEnumMetadata2.Entries.Add(enumEntryMetadata33);
    UasEnumEntryMetadata enumEntryMetadata34 = new UasEnumEntryMetadata()
    {
      Value = 16 /*0x10*/,
      Name = "FlappingWing",
      Description = "Flapping wing"
    };
    uasEnumMetadata2.Entries.Add(enumEntryMetadata34);
    UasEnumEntryMetadata enumEntryMetadata35 = new UasEnumEntryMetadata()
    {
      Value = 17,
      Name = "Kite",
      Description = "Flapping wing"
    };
    uasEnumMetadata2.Entries.Add(enumEntryMetadata35);
    UasSummary.mEnums.Add(uasEnumMetadata2.Name, uasEnumMetadata2);
    UasEnumMetadata uasEnumMetadata3 = new UasEnumMetadata()
    {
      Name = "MavModeFlag",
      Description = "These flags encode the MAV mode."
    };
    UasEnumEntryMetadata enumEntryMetadata36 = new UasEnumEntryMetadata()
    {
      Value = 128 /*0x80*/,
      Name = "SafetyArmed",
      Description = "0b10000000 MAV safety set to armed. Motors are enabled / running / can start. Ready to fly."
    };
    uasEnumMetadata3.Entries.Add(enumEntryMetadata36);
    UasEnumEntryMetadata enumEntryMetadata37 = new UasEnumEntryMetadata()
    {
      Value = 64 /*0x40*/,
      Name = "ManualInputEnabled",
      Description = "0b01000000 remote control input is enabled."
    };
    uasEnumMetadata3.Entries.Add(enumEntryMetadata37);
    UasEnumEntryMetadata enumEntryMetadata38 = new UasEnumEntryMetadata()
    {
      Value = 32 /*0x20*/,
      Name = "HilEnabled",
      Description = "0b00100000 hardware in the loop simulation. All motors / actuators are blocked, but internal software is full operational."
    };
    uasEnumMetadata3.Entries.Add(enumEntryMetadata38);
    UasEnumEntryMetadata enumEntryMetadata39 = new UasEnumEntryMetadata()
    {
      Value = 16 /*0x10*/,
      Name = "StabilizeEnabled",
      Description = "0b00010000 system stabilizes electronically its attitude (and optionally position). It needs however further control inputs to move around."
    };
    uasEnumMetadata3.Entries.Add(enumEntryMetadata39);
    UasEnumEntryMetadata enumEntryMetadata40 = new UasEnumEntryMetadata()
    {
      Value = 8,
      Name = "GuidedEnabled",
      Description = "0b00001000 guided mode enabled, system flies MISSIONs / mission items."
    };
    uasEnumMetadata3.Entries.Add(enumEntryMetadata40);
    UasEnumEntryMetadata enumEntryMetadata41 = new UasEnumEntryMetadata()
    {
      Value = 4,
      Name = "AutoEnabled",
      Description = "0b00000100 autonomous mode enabled, system finds its own goal positions. Guided flag can be set or not, depends on the actual implementation."
    };
    uasEnumMetadata3.Entries.Add(enumEntryMetadata41);
    UasEnumEntryMetadata enumEntryMetadata42 = new UasEnumEntryMetadata()
    {
      Value = 2,
      Name = "TestEnabled",
      Description = "0b00000010 system has a test mode enabled. This flag is intended for temporary system tests and should not be used for stable implementations."
    };
    uasEnumMetadata3.Entries.Add(enumEntryMetadata42);
    UasEnumEntryMetadata enumEntryMetadata43 = new UasEnumEntryMetadata()
    {
      Value = 1,
      Name = "CustomModeEnabled",
      Description = "0b00000001 Reserved for future use."
    };
    uasEnumMetadata3.Entries.Add(enumEntryMetadata43);
    UasSummary.mEnums.Add(uasEnumMetadata3.Name, uasEnumMetadata3);
    UasEnumMetadata uasEnumMetadata4 = new UasEnumMetadata()
    {
      Name = "MavModeFlagDecodePosition",
      Description = "These values encode the bit positions of the decode position. These values can be used to read the value of a flag bit by combining the base_mode variable with AND with the flag position value. The result will be either 0 or 1, depending on if the flag is set or not."
    };
    UasEnumEntryMetadata enumEntryMetadata44 = new UasEnumEntryMetadata()
    {
      Value = 128 /*0x80*/,
      Name = "Safety",
      Description = "First bit:  10000000"
    };
    uasEnumMetadata4.Entries.Add(enumEntryMetadata44);
    UasEnumEntryMetadata enumEntryMetadata45 = new UasEnumEntryMetadata()
    {
      Value = 64 /*0x40*/,
      Name = "Manual",
      Description = "Second bit: 01000000"
    };
    uasEnumMetadata4.Entries.Add(enumEntryMetadata45);
    UasEnumEntryMetadata enumEntryMetadata46 = new UasEnumEntryMetadata()
    {
      Value = 32 /*0x20*/,
      Name = "Hil",
      Description = "Third bit:  00100000"
    };
    uasEnumMetadata4.Entries.Add(enumEntryMetadata46);
    UasEnumEntryMetadata enumEntryMetadata47 = new UasEnumEntryMetadata()
    {
      Value = 16 /*0x10*/,
      Name = "Stabilize",
      Description = "Fourth bit: 00010000"
    };
    uasEnumMetadata4.Entries.Add(enumEntryMetadata47);
    UasEnumEntryMetadata enumEntryMetadata48 = new UasEnumEntryMetadata()
    {
      Value = 8,
      Name = "Guided",
      Description = "Fifth bit:  00001000"
    };
    uasEnumMetadata4.Entries.Add(enumEntryMetadata48);
    UasEnumEntryMetadata enumEntryMetadata49 = new UasEnumEntryMetadata()
    {
      Value = 4,
      Name = "Auto",
      Description = "Sixt bit:   00000100"
    };
    uasEnumMetadata4.Entries.Add(enumEntryMetadata49);
    UasEnumEntryMetadata enumEntryMetadata50 = new UasEnumEntryMetadata()
    {
      Value = 2,
      Name = "Test",
      Description = "Seventh bit: 00000010"
    };
    uasEnumMetadata4.Entries.Add(enumEntryMetadata50);
    UasEnumEntryMetadata enumEntryMetadata51 = new UasEnumEntryMetadata()
    {
      Value = 1,
      Name = "CustomMode",
      Description = "Eighth bit: 00000001"
    };
    uasEnumMetadata4.Entries.Add(enumEntryMetadata51);
    UasSummary.mEnums.Add(uasEnumMetadata4.Name, uasEnumMetadata4);
    UasEnumMetadata uasEnumMetadata5 = new UasEnumMetadata()
    {
      Name = "MavGoto",
      Description = "Override command, pauses current mission execution and moves immediately to a position"
    };
    UasEnumEntryMetadata enumEntryMetadata52 = new UasEnumEntryMetadata()
    {
      Value = 0,
      Name = "DoHold",
      Description = "Hold at the current position."
    };
    uasEnumMetadata5.Entries.Add(enumEntryMetadata52);
    UasEnumEntryMetadata enumEntryMetadata53 = new UasEnumEntryMetadata()
    {
      Value = 1,
      Name = "DoContinue",
      Description = "Continue with the next item in mission execution."
    };
    uasEnumMetadata5.Entries.Add(enumEntryMetadata53);
    UasEnumEntryMetadata enumEntryMetadata54 = new UasEnumEntryMetadata()
    {
      Value = 2,
      Name = "HoldAtCurrentPosition",
      Description = "Hold at the current position of the system"
    };
    uasEnumMetadata5.Entries.Add(enumEntryMetadata54);
    UasEnumEntryMetadata enumEntryMetadata55 = new UasEnumEntryMetadata()
    {
      Value = 3,
      Name = "HoldAtSpecifiedPosition",
      Description = "Hold at the position specified in the parameters of the DO_HOLD action"
    };
    uasEnumMetadata5.Entries.Add(enumEntryMetadata55);
    UasSummary.mEnums.Add(uasEnumMetadata5.Name, uasEnumMetadata5);
    UasEnumMetadata uasEnumMetadata6 = new UasEnumMetadata()
    {
      Name = "MavMode",
      Description = "These defines are predefined OR-combined mode flags. There is no need to use values from this enum, but it                 simplifies the use of the mode flags. Note that manual input is enabled in all modes as a safety override."
    };
    UasEnumEntryMetadata enumEntryMetadata56 = new UasEnumEntryMetadata()
    {
      Value = 0,
      Name = "Preflight",
      Description = "System is not ready to fly, booting, calibrating, etc. No flag is set."
    };
    uasEnumMetadata6.Entries.Add(enumEntryMetadata56);
    UasEnumEntryMetadata enumEntryMetadata57 = new UasEnumEntryMetadata()
    {
      Value = 80 /*0x50*/,
      Name = "StabilizeDisarmed",
      Description = "System is allowed to be active, under assisted RC control."
    };
    uasEnumMetadata6.Entries.Add(enumEntryMetadata57);
    UasEnumEntryMetadata enumEntryMetadata58 = new UasEnumEntryMetadata()
    {
      Value = 208 /*0xD0*/,
      Name = "StabilizeArmed",
      Description = "System is allowed to be active, under assisted RC control."
    };
    uasEnumMetadata6.Entries.Add(enumEntryMetadata58);
    UasEnumEntryMetadata enumEntryMetadata59 = new UasEnumEntryMetadata()
    {
      Value = 64 /*0x40*/,
      Name = "ManualDisarmed",
      Description = "System is allowed to be active, under manual (RC) control, no stabilization"
    };
    uasEnumMetadata6.Entries.Add(enumEntryMetadata59);
    UasEnumEntryMetadata enumEntryMetadata60 = new UasEnumEntryMetadata()
    {
      Value = 192 /*0xC0*/,
      Name = "ManualArmed",
      Description = "System is allowed to be active, under manual (RC) control, no stabilization"
    };
    uasEnumMetadata6.Entries.Add(enumEntryMetadata60);
    UasEnumEntryMetadata enumEntryMetadata61 = new UasEnumEntryMetadata()
    {
      Value = 88,
      Name = "GuidedDisarmed",
      Description = "System is allowed to be active, under autonomous control, manual setpoint"
    };
    uasEnumMetadata6.Entries.Add(enumEntryMetadata61);
    UasEnumEntryMetadata enumEntryMetadata62 = new UasEnumEntryMetadata()
    {
      Value = 216,
      Name = "GuidedArmed",
      Description = "System is allowed to be active, under autonomous control, manual setpoint"
    };
    uasEnumMetadata6.Entries.Add(enumEntryMetadata62);
    UasEnumEntryMetadata enumEntryMetadata63 = new UasEnumEntryMetadata()
    {
      Value = 92,
      Name = "AutoDisarmed",
      Description = "System is allowed to be active, under autonomous control and navigation (the trajectory is decided onboard and not pre-programmed by MISSIONs)"
    };
    uasEnumMetadata6.Entries.Add(enumEntryMetadata63);
    UasEnumEntryMetadata enumEntryMetadata64 = new UasEnumEntryMetadata()
    {
      Value = 220,
      Name = "AutoArmed",
      Description = "System is allowed to be active, under autonomous control and navigation (the trajectory is decided onboard and not pre-programmed by MISSIONs)"
    };
    uasEnumMetadata6.Entries.Add(enumEntryMetadata64);
    UasEnumEntryMetadata enumEntryMetadata65 = new UasEnumEntryMetadata()
    {
      Value = 66,
      Name = "TestDisarmed",
      Description = "UNDEFINED mode. This solely depends on the autopilot - use with caution, intended for developers only."
    };
    uasEnumMetadata6.Entries.Add(enumEntryMetadata65);
    UasEnumEntryMetadata enumEntryMetadata66 = new UasEnumEntryMetadata()
    {
      Value = 194,
      Name = "TestArmed",
      Description = "UNDEFINED mode. This solely depends on the autopilot - use with caution, intended for developers only."
    };
    uasEnumMetadata6.Entries.Add(enumEntryMetadata66);
    UasSummary.mEnums.Add(uasEnumMetadata6.Name, uasEnumMetadata6);
    UasEnumMetadata uasEnumMetadata7 = new UasEnumMetadata()
    {
      Name = "MavState",
      Description = ""
    };
    UasEnumEntryMetadata enumEntryMetadata67 = new UasEnumEntryMetadata()
    {
      Value = 0,
      Name = "Uninit",
      Description = "Uninitialized system, state is unknown."
    };
    uasEnumMetadata7.Entries.Add(enumEntryMetadata67);
    UasEnumEntryMetadata enumEntryMetadata68 = new UasEnumEntryMetadata()
    {
      Value = 1,
      Name = "Boot",
      Description = "System is booting up."
    };
    uasEnumMetadata7.Entries.Add(enumEntryMetadata68);
    UasEnumEntryMetadata enumEntryMetadata69 = new UasEnumEntryMetadata()
    {
      Value = 2,
      Name = "Calibrating",
      Description = "System is calibrating and not flight-ready."
    };
    uasEnumMetadata7.Entries.Add(enumEntryMetadata69);
    UasEnumEntryMetadata enumEntryMetadata70 = new UasEnumEntryMetadata()
    {
      Value = 3,
      Name = "Standby",
      Description = "System is grounded and on standby. It can be launched any time."
    };
    uasEnumMetadata7.Entries.Add(enumEntryMetadata70);
    UasEnumEntryMetadata enumEntryMetadata71 = new UasEnumEntryMetadata()
    {
      Value = 4,
      Name = "Active",
      Description = "System is active and might be already airborne. Motors are engaged."
    };
    uasEnumMetadata7.Entries.Add(enumEntryMetadata71);
    UasEnumEntryMetadata enumEntryMetadata72 = new UasEnumEntryMetadata()
    {
      Value = 5,
      Name = "Critical",
      Description = "System is in a non-normal flight mode. It can however still navigate."
    };
    uasEnumMetadata7.Entries.Add(enumEntryMetadata72);
    UasEnumEntryMetadata enumEntryMetadata73 = new UasEnumEntryMetadata()
    {
      Value = 6,
      Name = "Emergency",
      Description = "System is in a non-normal flight mode. It lost control over parts or over the whole airframe. It is in mayday and going down."
    };
    uasEnumMetadata7.Entries.Add(enumEntryMetadata73);
    UasEnumEntryMetadata enumEntryMetadata74 = new UasEnumEntryMetadata()
    {
      Value = 7,
      Name = "Poweroff",
      Description = "System just initialized its power-down sequence, will shut down now."
    };
    uasEnumMetadata7.Entries.Add(enumEntryMetadata74);
    UasSummary.mEnums.Add(uasEnumMetadata7.Name, uasEnumMetadata7);
    UasEnumMetadata uasEnumMetadata8 = new UasEnumMetadata()
    {
      Name = "MavComponent",
      Description = ""
    };
    UasEnumEntryMetadata enumEntryMetadata75 = new UasEnumEntryMetadata()
    {
      Value = 0,
      Name = "MavCompIdAll",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata75);
    UasEnumEntryMetadata enumEntryMetadata76 = new UasEnumEntryMetadata()
    {
      Value = 220,
      Name = "MavCompIdGps",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata76);
    UasEnumEntryMetadata enumEntryMetadata77 = new UasEnumEntryMetadata()
    {
      Value = 190,
      Name = "MavCompIdMissionplanner",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata77);
    UasEnumEntryMetadata enumEntryMetadata78 = new UasEnumEntryMetadata()
    {
      Value = 195,
      Name = "MavCompIdPathplanner",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata78);
    UasEnumEntryMetadata enumEntryMetadata79 = new UasEnumEntryMetadata()
    {
      Value = 180,
      Name = "MavCompIdMapper",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata79);
    UasEnumEntryMetadata enumEntryMetadata80 = new UasEnumEntryMetadata()
    {
      Value = 100,
      Name = "MavCompIdCamera",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata80);
    UasEnumEntryMetadata enumEntryMetadata81 = new UasEnumEntryMetadata()
    {
      Value = 200,
      Name = "MavCompIdImu",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata81);
    UasEnumEntryMetadata enumEntryMetadata82 = new UasEnumEntryMetadata()
    {
      Value = 201,
      Name = "MavCompIdImu2",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata82);
    UasEnumEntryMetadata enumEntryMetadata83 = new UasEnumEntryMetadata()
    {
      Value = 202,
      Name = "MavCompIdImu3",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata83);
    UasEnumEntryMetadata enumEntryMetadata84 = new UasEnumEntryMetadata()
    {
      Value = 240 /*0xF0*/,
      Name = "MavCompIdUdpBridge",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata84);
    UasEnumEntryMetadata enumEntryMetadata85 = new UasEnumEntryMetadata()
    {
      Value = 241,
      Name = "MavCompIdUartBridge",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata85);
    UasEnumEntryMetadata enumEntryMetadata86 = new UasEnumEntryMetadata()
    {
      Value = 250,
      Name = "MavCompIdSystemControl",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata86);
    UasEnumEntryMetadata enumEntryMetadata87 = new UasEnumEntryMetadata()
    {
      Value = 140,
      Name = "MavCompIdServo1",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata87);
    UasEnumEntryMetadata enumEntryMetadata88 = new UasEnumEntryMetadata()
    {
      Value = 141,
      Name = "MavCompIdServo2",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata88);
    UasEnumEntryMetadata enumEntryMetadata89 = new UasEnumEntryMetadata()
    {
      Value = 142,
      Name = "MavCompIdServo3",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata89);
    UasEnumEntryMetadata enumEntryMetadata90 = new UasEnumEntryMetadata()
    {
      Value = 143,
      Name = "MavCompIdServo4",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata90);
    UasEnumEntryMetadata enumEntryMetadata91 = new UasEnumEntryMetadata()
    {
      Value = 144 /*0x90*/,
      Name = "MavCompIdServo5",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata91);
    UasEnumEntryMetadata enumEntryMetadata92 = new UasEnumEntryMetadata()
    {
      Value = 145,
      Name = "MavCompIdServo6",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata92);
    UasEnumEntryMetadata enumEntryMetadata93 = new UasEnumEntryMetadata()
    {
      Value = 146,
      Name = "MavCompIdServo7",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata93);
    UasEnumEntryMetadata enumEntryMetadata94 = new UasEnumEntryMetadata()
    {
      Value = 147,
      Name = "MavCompIdServo8",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata94);
    UasEnumEntryMetadata enumEntryMetadata95 = new UasEnumEntryMetadata()
    {
      Value = 148,
      Name = "MavCompIdServo9",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata95);
    UasEnumEntryMetadata enumEntryMetadata96 = new UasEnumEntryMetadata()
    {
      Value = 149,
      Name = "MavCompIdServo10",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata96);
    UasEnumEntryMetadata enumEntryMetadata97 = new UasEnumEntryMetadata()
    {
      Value = 150,
      Name = "MavCompIdServo11",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata97);
    UasEnumEntryMetadata enumEntryMetadata98 = new UasEnumEntryMetadata()
    {
      Value = 151,
      Name = "MavCompIdServo12",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata98);
    UasEnumEntryMetadata enumEntryMetadata99 = new UasEnumEntryMetadata()
    {
      Value = 152,
      Name = "MavCompIdServo13",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata99);
    UasEnumEntryMetadata enumEntryMetadata100 = new UasEnumEntryMetadata()
    {
      Value = 153,
      Name = "MavCompIdServo14",
      Description = ""
    };
    uasEnumMetadata8.Entries.Add(enumEntryMetadata100);
    UasSummary.mEnums.Add(uasEnumMetadata8.Name, uasEnumMetadata8);
    UasEnumMetadata uasEnumMetadata9 = new UasEnumMetadata()
    {
      Name = "MavSysStatusSensor",
      Description = "These encode the sensors whose status is sent as part of the SYS_STATUS message."
    };
    UasEnumEntryMetadata enumEntryMetadata101 = new UasEnumEntryMetadata()
    {
      Value = 1,
      Name = "_3dGyro",
      Description = "0x01 3D gyro"
    };
    uasEnumMetadata9.Entries.Add(enumEntryMetadata101);
    UasEnumEntryMetadata enumEntryMetadata102 = new UasEnumEntryMetadata()
    {
      Value = 2,
      Name = "_3dAccel",
      Description = "0x02 3D accelerometer"
    };
    uasEnumMetadata9.Entries.Add(enumEntryMetadata102);
    UasEnumEntryMetadata enumEntryMetadata103 = new UasEnumEntryMetadata()
    {
      Value = 4,
      Name = "_3dMag",
      Description = "0x04 3D magnetometer"
    };
    uasEnumMetadata9.Entries.Add(enumEntryMetadata103);
    UasEnumEntryMetadata enumEntryMetadata104 = new UasEnumEntryMetadata()
    {
      Value = 8,
      Name = "AbsolutePressure",
      Description = "0x08 absolute pressure"
    };
    uasEnumMetadata9.Entries.Add(enumEntryMetadata104);
    UasEnumEntryMetadata enumEntryMetadata105 = new UasEnumEntryMetadata()
    {
      Value = 16 /*0x10*/,
      Name = "DifferentialPressure",
      Description = "0x10 differential pressure"
    };
    uasEnumMetadata9.Entries.Add(enumEntryMetadata105);
    UasEnumEntryMetadata enumEntryMetadata106 = new UasEnumEntryMetadata()
    {
      Value = 32 /*0x20*/,
      Name = "Gps",
      Description = "0x20 GPS"
    };
    uasEnumMetadata9.Entries.Add(enumEntryMetadata106);
    UasEnumEntryMetadata enumEntryMetadata107 = new UasEnumEntryMetadata()
    {
      Value = 64 /*0x40*/,
      Name = "OpticalFlow",
      Description = "0x40 optical flow"
    };
    uasEnumMetadata9.Entries.Add(enumEntryMetadata107);
    UasEnumEntryMetadata enumEntryMetadata108 = new UasEnumEntryMetadata()
    {
      Value = 128 /*0x80*/,
      Name = "VisionPosition",
      Description = "0x80 computer vision position"
    };
    uasEnumMetadata9.Entries.Add(enumEntryMetadata108);
    UasEnumEntryMetadata enumEntryMetadata109 = new UasEnumEntryMetadata()
    {
      Value = 256 /*0x0100*/,
      Name = "LaserPosition",
      Description = "0x100 laser based position"
    };
    uasEnumMetadata9.Entries.Add(enumEntryMetadata109);
    UasEnumEntryMetadata enumEntryMetadata110 = new UasEnumEntryMetadata()
    {
      Value = 512 /*0x0200*/,
      Name = "ExternalGroundTruth",
      Description = "0x200 external ground truth (Vicon or Leica)"
    };
    uasEnumMetadata9.Entries.Add(enumEntryMetadata110);
    UasEnumEntryMetadata enumEntryMetadata111 = new UasEnumEntryMetadata()
    {
      Value = 1024 /*0x0400*/,
      Name = "AngularRateControl",
      Description = "0x400 3D angular rate control"
    };
    uasEnumMetadata9.Entries.Add(enumEntryMetadata111);
    UasEnumEntryMetadata enumEntryMetadata112 = new UasEnumEntryMetadata()
    {
      Value = 2048 /*0x0800*/,
      Name = "AttitudeStabilization",
      Description = "0x800 attitude stabilization"
    };
    uasEnumMetadata9.Entries.Add(enumEntryMetadata112);
    UasEnumEntryMetadata enumEntryMetadata113 = new UasEnumEntryMetadata()
    {
      Value = 4096 /*0x1000*/,
      Name = "YawPosition",
      Description = "0x1000 yaw position"
    };
    uasEnumMetadata9.Entries.Add(enumEntryMetadata113);
    UasEnumEntryMetadata enumEntryMetadata114 = new UasEnumEntryMetadata()
    {
      Value = 8192 /*0x2000*/,
      Name = "ZAltitudeControl",
      Description = "0x2000 z/altitude control"
    };
    uasEnumMetadata9.Entries.Add(enumEntryMetadata114);
    UasEnumEntryMetadata enumEntryMetadata115 = new UasEnumEntryMetadata()
    {
      Value = 16384 /*0x4000*/,
      Name = "XyPositionControl",
      Description = "0x4000 x/y position control"
    };
    uasEnumMetadata9.Entries.Add(enumEntryMetadata115);
    UasEnumEntryMetadata enumEntryMetadata116 = new UasEnumEntryMetadata()
    {
      Value = 32768 /*0x8000*/,
      Name = "MotorOutputs",
      Description = "0x8000 motor outputs / control"
    };
    uasEnumMetadata9.Entries.Add(enumEntryMetadata116);
    UasEnumEntryMetadata enumEntryMetadata117 = new UasEnumEntryMetadata()
    {
      Value = 65536 /*0x010000*/,
      Name = "RcReceiver",
      Description = "0x10000 rc receiver"
    };
    uasEnumMetadata9.Entries.Add(enumEntryMetadata117);
    UasSummary.mEnums.Add(uasEnumMetadata9.Name, uasEnumMetadata9);
    UasEnumMetadata uasEnumMetadata10 = new UasEnumMetadata()
    {
      Name = "MavFrame",
      Description = ""
    };
    UasEnumEntryMetadata enumEntryMetadata118 = new UasEnumEntryMetadata()
    {
      Value = 0,
      Name = "Global",
      Description = "Global coordinate frame, WGS84 coordinate system. First value / x: latitude, second value / y: longitude, third value / z: positive altitude over mean sea level (MSL)"
    };
    uasEnumMetadata10.Entries.Add(enumEntryMetadata118);
    UasEnumEntryMetadata enumEntryMetadata119 = new UasEnumEntryMetadata()
    {
      Value = 1,
      Name = "LocalNed",
      Description = "Local coordinate frame, Z-up (x: north, y: east, z: down)."
    };
    uasEnumMetadata10.Entries.Add(enumEntryMetadata119);
    UasEnumEntryMetadata enumEntryMetadata120 = new UasEnumEntryMetadata()
    {
      Value = 2,
      Name = "Mission",
      Description = "NOT a coordinate frame, indicates a mission command."
    };
    uasEnumMetadata10.Entries.Add(enumEntryMetadata120);
    UasEnumEntryMetadata enumEntryMetadata121 = new UasEnumEntryMetadata()
    {
      Value = 3,
      Name = "GlobalRelativeAlt",
      Description = "Global coordinate frame, WGS84 coordinate system, relative altitude over ground with respect to the home position. First value / x: latitude, second value / y: longitude, third value / z: positive altitude with 0 being at the altitude of the home location."
    };
    uasEnumMetadata10.Entries.Add(enumEntryMetadata121);
    UasEnumEntryMetadata enumEntryMetadata122 = new UasEnumEntryMetadata()
    {
      Value = 4,
      Name = "LocalEnu",
      Description = "Local coordinate frame, Z-down (x: east, y: north, z: up)"
    };
    uasEnumMetadata10.Entries.Add(enumEntryMetadata122);
    UasSummary.mEnums.Add(uasEnumMetadata10.Name, uasEnumMetadata10);
    UasEnumMetadata uasEnumMetadata11 = new UasEnumMetadata()
    {
      Name = "MavlinkDataStreamType",
      Description = ""
    };
    UasEnumEntryMetadata enumEntryMetadata123 = new UasEnumEntryMetadata()
    {
      Value = 1,
      Name = "MavlinkDataStreamImgJpeg",
      Description = ""
    };
    uasEnumMetadata11.Entries.Add(enumEntryMetadata123);
    UasEnumEntryMetadata enumEntryMetadata124 = new UasEnumEntryMetadata()
    {
      Value = 2,
      Name = "MavlinkDataStreamImgBmp",
      Description = ""
    };
    uasEnumMetadata11.Entries.Add(enumEntryMetadata124);
    UasEnumEntryMetadata enumEntryMetadata125 = new UasEnumEntryMetadata()
    {
      Value = 3,
      Name = "MavlinkDataStreamImgRaw8u",
      Description = ""
    };
    uasEnumMetadata11.Entries.Add(enumEntryMetadata125);
    UasEnumEntryMetadata enumEntryMetadata126 = new UasEnumEntryMetadata()
    {
      Value = 4,
      Name = "MavlinkDataStreamImgRaw32u",
      Description = ""
    };
    uasEnumMetadata11.Entries.Add(enumEntryMetadata126);
    UasEnumEntryMetadata enumEntryMetadata127 = new UasEnumEntryMetadata()
    {
      Value = 5,
      Name = "MavlinkDataStreamImgPgm",
      Description = ""
    };
    uasEnumMetadata11.Entries.Add(enumEntryMetadata127);
    UasEnumEntryMetadata enumEntryMetadata128 = new UasEnumEntryMetadata()
    {
      Value = 6,
      Name = "MavlinkDataStreamImgPng",
      Description = ""
    };
    uasEnumMetadata11.Entries.Add(enumEntryMetadata128);
    UasSummary.mEnums.Add(uasEnumMetadata11.Name, uasEnumMetadata11);
    UasEnumMetadata uasEnumMetadata12 = new UasEnumMetadata()
    {
      Name = "MavCmd",
      Description = "Commands to be executed by the MAV. They can be executed on user request, or as part of a mission script. If the action is used in a mission, the parameter mapping to the waypoint/mission message is as follows: Param 1, Param 2, Param 3, Param 4, X: Param 5, Y:Param 6, Z:Param 7. This command list is similar what ARINC 424 is for commercial aircraft: A data format how to interpret waypoint/mission data."
    };
    UasEnumEntryMetadata enumEntryMetadata129 = new UasEnumEntryMetadata()
    {
      Value = 16 /*0x10*/,
      Name = "NavWaypoint",
      Description = "Navigate to MISSION."
    };
    enumEntryMetadata129.Params = new List<string>();
    enumEntryMetadata129.Params.Add("Hold time in decimal seconds. (ignored by fixed wing, time to stay at MISSION for rotary wing)");
    enumEntryMetadata129.Params.Add("Acceptance radius in meters (if the sphere with this radius is hit, the MISSION counts as reached)");
    enumEntryMetadata129.Params.Add("0 to pass through the WP, if > 0 radius in meters to pass by WP. Positive value for clockwise orbit, negative value for counter-clockwise orbit. Allows trajectory control.");
    enumEntryMetadata129.Params.Add("Desired yaw angle at MISSION (rotary wing)");
    enumEntryMetadata129.Params.Add("Latitude");
    enumEntryMetadata129.Params.Add("Longitude");
    enumEntryMetadata129.Params.Add("Altitude");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata129);
    UasEnumEntryMetadata enumEntryMetadata130 = new UasEnumEntryMetadata()
    {
      Value = 17,
      Name = "NavLoiterUnlim",
      Description = "Loiter around this MISSION an unlimited amount of time"
    };
    enumEntryMetadata130.Params = new List<string>();
    enumEntryMetadata130.Params.Add("Empty");
    enumEntryMetadata130.Params.Add("Empty");
    enumEntryMetadata130.Params.Add("Radius around MISSION, in meters. If positive loiter clockwise, else counter-clockwise");
    enumEntryMetadata130.Params.Add("Desired yaw angle.");
    enumEntryMetadata130.Params.Add("Latitude");
    enumEntryMetadata130.Params.Add("Longitude");
    enumEntryMetadata130.Params.Add("Altitude");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata130);
    UasEnumEntryMetadata enumEntryMetadata131 = new UasEnumEntryMetadata()
    {
      Value = 18,
      Name = "NavLoiterTurns",
      Description = "Loiter around this MISSION for X turns"
    };
    enumEntryMetadata131.Params = new List<string>();
    enumEntryMetadata131.Params.Add("Turns");
    enumEntryMetadata131.Params.Add("Empty");
    enumEntryMetadata131.Params.Add("Radius around MISSION, in meters. If positive loiter clockwise, else counter-clockwise");
    enumEntryMetadata131.Params.Add("Desired yaw angle.");
    enumEntryMetadata131.Params.Add("Latitude");
    enumEntryMetadata131.Params.Add("Longitude");
    enumEntryMetadata131.Params.Add("Altitude");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata131);
    UasEnumEntryMetadata enumEntryMetadata132 = new UasEnumEntryMetadata()
    {
      Value = 19,
      Name = "NavLoiterTime",
      Description = "Loiter around this MISSION for X seconds"
    };
    enumEntryMetadata132.Params = new List<string>();
    enumEntryMetadata132.Params.Add("Seconds (decimal)");
    enumEntryMetadata132.Params.Add("Empty");
    enumEntryMetadata132.Params.Add("Radius around MISSION, in meters. If positive loiter clockwise, else counter-clockwise");
    enumEntryMetadata132.Params.Add("Desired yaw angle.");
    enumEntryMetadata132.Params.Add("Latitude");
    enumEntryMetadata132.Params.Add("Longitude");
    enumEntryMetadata132.Params.Add("Altitude");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata132);
    UasEnumEntryMetadata enumEntryMetadata133 = new UasEnumEntryMetadata()
    {
      Value = 20,
      Name = "NavReturnToLaunch",
      Description = "Return to launch location"
    };
    enumEntryMetadata133.Params = new List<string>();
    enumEntryMetadata133.Params.Add("Empty");
    enumEntryMetadata133.Params.Add("Empty");
    enumEntryMetadata133.Params.Add("Empty");
    enumEntryMetadata133.Params.Add("Empty");
    enumEntryMetadata133.Params.Add("Empty");
    enumEntryMetadata133.Params.Add("Empty");
    enumEntryMetadata133.Params.Add("Empty");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata133);
    UasEnumEntryMetadata enumEntryMetadata134 = new UasEnumEntryMetadata()
    {
      Value = 21,
      Name = "NavLand",
      Description = "Land at location"
    };
    enumEntryMetadata134.Params = new List<string>();
    enumEntryMetadata134.Params.Add("Empty");
    enumEntryMetadata134.Params.Add("Empty");
    enumEntryMetadata134.Params.Add("Empty");
    enumEntryMetadata134.Params.Add("Desired yaw angle.");
    enumEntryMetadata134.Params.Add("Latitude");
    enumEntryMetadata134.Params.Add("Longitude");
    enumEntryMetadata134.Params.Add("Altitude");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata134);
    UasEnumEntryMetadata enumEntryMetadata135 = new UasEnumEntryMetadata()
    {
      Value = 22,
      Name = "NavTakeoff",
      Description = "Takeoff from ground / hand"
    };
    enumEntryMetadata135.Params = new List<string>();
    enumEntryMetadata135.Params.Add("Minimum pitch (if airspeed sensor present), desired pitch without sensor");
    enumEntryMetadata135.Params.Add("Empty");
    enumEntryMetadata135.Params.Add("Empty");
    enumEntryMetadata135.Params.Add("Yaw angle (if magnetometer present), ignored without magnetometer");
    enumEntryMetadata135.Params.Add("Latitude");
    enumEntryMetadata135.Params.Add("Longitude");
    enumEntryMetadata135.Params.Add("Altitude");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata135);
    UasEnumEntryMetadata enumEntryMetadata136 = new UasEnumEntryMetadata()
    {
      Value = 80 /*0x50*/,
      Name = "NavRoi",
      Description = "Sets the region of interest (ROI) for a sensor set or the vehicle itself. This can then be used by the vehicles control system to control the vehicle attitude and the attitude of various sensors such as cameras."
    };
    enumEntryMetadata136.Params = new List<string>();
    enumEntryMetadata136.Params.Add("Region of intereset mode. (see MAV_ROI enum)");
    enumEntryMetadata136.Params.Add("MISSION index/ target ID. (see MAV_ROI enum)");
    enumEntryMetadata136.Params.Add("ROI index (allows a vehicle to manage multiple ROI's)");
    enumEntryMetadata136.Params.Add("Empty");
    enumEntryMetadata136.Params.Add("x the location of the fixed ROI (see MAV_FRAME)");
    enumEntryMetadata136.Params.Add("y");
    enumEntryMetadata136.Params.Add("z");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata136);
    UasEnumEntryMetadata enumEntryMetadata137 = new UasEnumEntryMetadata()
    {
      Value = 81,
      Name = "NavPathplanning",
      Description = "Control autonomous path planning on the MAV."
    };
    enumEntryMetadata137.Params = new List<string>();
    enumEntryMetadata137.Params.Add("0: Disable local obstacle avoidance / local path planning (without resetting map), 1: Enable local path planning, 2: Enable and reset local path planning");
    enumEntryMetadata137.Params.Add("0: Disable full path planning (without resetting map), 1: Enable, 2: Enable and reset map/occupancy grid, 3: Enable and reset planned route, but not occupancy grid");
    enumEntryMetadata137.Params.Add("Empty");
    enumEntryMetadata137.Params.Add("Yaw angle at goal, in compass degrees, [0..360]");
    enumEntryMetadata137.Params.Add("Latitude/X of goal");
    enumEntryMetadata137.Params.Add("Longitude/Y of goal");
    enumEntryMetadata137.Params.Add("Altitude/Z of goal");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata137);
    UasEnumEntryMetadata enumEntryMetadata138 = new UasEnumEntryMetadata()
    {
      Value = 95,
      Name = "NavLast",
      Description = "NOP - This command is only used to mark the upper limit of the NAV/ACTION commands in the enumeration"
    };
    enumEntryMetadata138.Params = new List<string>();
    enumEntryMetadata138.Params.Add("Empty");
    enumEntryMetadata138.Params.Add("Empty");
    enumEntryMetadata138.Params.Add("Empty");
    enumEntryMetadata138.Params.Add("Empty");
    enumEntryMetadata138.Params.Add("Empty");
    enumEntryMetadata138.Params.Add("Empty");
    enumEntryMetadata138.Params.Add("Empty");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata138);
    UasEnumEntryMetadata enumEntryMetadata139 = new UasEnumEntryMetadata()
    {
      Value = 112 /*0x70*/,
      Name = "ConditionDelay",
      Description = "Delay mission state machine."
    };
    enumEntryMetadata139.Params = new List<string>();
    enumEntryMetadata139.Params.Add("Delay in seconds (decimal)");
    enumEntryMetadata139.Params.Add("Empty");
    enumEntryMetadata139.Params.Add("Empty");
    enumEntryMetadata139.Params.Add("Empty");
    enumEntryMetadata139.Params.Add("Empty");
    enumEntryMetadata139.Params.Add("Empty");
    enumEntryMetadata139.Params.Add("Empty");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata139);
    UasEnumEntryMetadata enumEntryMetadata140 = new UasEnumEntryMetadata()
    {
      Value = 113,
      Name = "ConditionChangeAlt",
      Description = "Ascend/descend at rate.  Delay mission state machine until desired altitude reached."
    };
    enumEntryMetadata140.Params = new List<string>();
    enumEntryMetadata140.Params.Add("Descent / Ascend rate (m/s)");
    enumEntryMetadata140.Params.Add("Empty");
    enumEntryMetadata140.Params.Add("Empty");
    enumEntryMetadata140.Params.Add("Empty");
    enumEntryMetadata140.Params.Add("Empty");
    enumEntryMetadata140.Params.Add("Empty");
    enumEntryMetadata140.Params.Add("Finish Altitude");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata140);
    UasEnumEntryMetadata enumEntryMetadata141 = new UasEnumEntryMetadata()
    {
      Value = 114,
      Name = "ConditionDistance",
      Description = "Delay mission state machine until within desired distance of next NAV point."
    };
    enumEntryMetadata141.Params = new List<string>();
    enumEntryMetadata141.Params.Add("Distance (meters)");
    enumEntryMetadata141.Params.Add("Empty");
    enumEntryMetadata141.Params.Add("Empty");
    enumEntryMetadata141.Params.Add("Empty");
    enumEntryMetadata141.Params.Add("Empty");
    enumEntryMetadata141.Params.Add("Empty");
    enumEntryMetadata141.Params.Add("Empty");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata141);
    UasEnumEntryMetadata enumEntryMetadata142 = new UasEnumEntryMetadata()
    {
      Value = 115,
      Name = "ConditionYaw",
      Description = "Reach a certain target angle."
    };
    enumEntryMetadata142.Params = new List<string>();
    enumEntryMetadata142.Params.Add("target angle: [0-360], 0 is north");
    enumEntryMetadata142.Params.Add("speed during yaw change:[deg per second]");
    enumEntryMetadata142.Params.Add("direction: negative: counter clockwise, positive: clockwise [-1,1]");
    enumEntryMetadata142.Params.Add("relative offset or absolute angle: [ 1,0]");
    enumEntryMetadata142.Params.Add("Empty");
    enumEntryMetadata142.Params.Add("Empty");
    enumEntryMetadata142.Params.Add("Empty");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata142);
    UasEnumEntryMetadata enumEntryMetadata143 = new UasEnumEntryMetadata()
    {
      Value = 159,
      Name = "ConditionLast",
      Description = "NOP - This command is only used to mark the upper limit of the CONDITION commands in the enumeration"
    };
    enumEntryMetadata143.Params = new List<string>();
    enumEntryMetadata143.Params.Add("Empty");
    enumEntryMetadata143.Params.Add("Empty");
    enumEntryMetadata143.Params.Add("Empty");
    enumEntryMetadata143.Params.Add("Empty");
    enumEntryMetadata143.Params.Add("Empty");
    enumEntryMetadata143.Params.Add("Empty");
    enumEntryMetadata143.Params.Add("Empty");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata143);
    UasEnumEntryMetadata enumEntryMetadata144 = new UasEnumEntryMetadata()
    {
      Value = 176 /*0xB0*/,
      Name = "DoSetMode",
      Description = "Set system mode."
    };
    enumEntryMetadata144.Params = new List<string>();
    enumEntryMetadata144.Params.Add("Mode, as defined by ENUM MAV_MODE");
    enumEntryMetadata144.Params.Add("Empty");
    enumEntryMetadata144.Params.Add("Empty");
    enumEntryMetadata144.Params.Add("Empty");
    enumEntryMetadata144.Params.Add("Empty");
    enumEntryMetadata144.Params.Add("Empty");
    enumEntryMetadata144.Params.Add("Empty");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata144);
    UasEnumEntryMetadata enumEntryMetadata145 = new UasEnumEntryMetadata()
    {
      Value = 177,
      Name = "DoJump",
      Description = "Jump to the desired command in the mission list.  Repeat this action only the specified number of times"
    };
    enumEntryMetadata145.Params = new List<string>();
    enumEntryMetadata145.Params.Add("Sequence number");
    enumEntryMetadata145.Params.Add("Repeat count");
    enumEntryMetadata145.Params.Add("Empty");
    enumEntryMetadata145.Params.Add("Empty");
    enumEntryMetadata145.Params.Add("Empty");
    enumEntryMetadata145.Params.Add("Empty");
    enumEntryMetadata145.Params.Add("Empty");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata145);
    UasEnumEntryMetadata enumEntryMetadata146 = new UasEnumEntryMetadata()
    {
      Value = 178,
      Name = "DoChangeSpeed",
      Description = "Change speed and/or throttle set points."
    };
    enumEntryMetadata146.Params = new List<string>();
    enumEntryMetadata146.Params.Add("Speed type (0=Airspeed, 1=Ground Speed)");
    enumEntryMetadata146.Params.Add("Speed  (m/s, -1 indicates no change)");
    enumEntryMetadata146.Params.Add("Throttle  ( Percent, -1 indicates no change)");
    enumEntryMetadata146.Params.Add("Empty");
    enumEntryMetadata146.Params.Add("Empty");
    enumEntryMetadata146.Params.Add("Empty");
    enumEntryMetadata146.Params.Add("Empty");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata146);
    UasEnumEntryMetadata enumEntryMetadata147 = new UasEnumEntryMetadata()
    {
      Value = 179,
      Name = "DoSetHome",
      Description = "Changes the home location either to the current location or a specified location."
    };
    enumEntryMetadata147.Params = new List<string>();
    enumEntryMetadata147.Params.Add("Use current (1=use current location, 0=use specified location)");
    enumEntryMetadata147.Params.Add("Empty");
    enumEntryMetadata147.Params.Add("Empty");
    enumEntryMetadata147.Params.Add("Empty");
    enumEntryMetadata147.Params.Add("Latitude");
    enumEntryMetadata147.Params.Add("Longitude");
    enumEntryMetadata147.Params.Add("Altitude");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata147);
    UasEnumEntryMetadata enumEntryMetadata148 = new UasEnumEntryMetadata()
    {
      Value = 180,
      Name = "DoSetParameter",
      Description = "Set a system parameter.  Caution!  Use of this command requires knowledge of the numeric enumeration value of the parameter."
    };
    enumEntryMetadata148.Params = new List<string>();
    enumEntryMetadata148.Params.Add("Parameter number");
    enumEntryMetadata148.Params.Add("Parameter value");
    enumEntryMetadata148.Params.Add("Empty");
    enumEntryMetadata148.Params.Add("Empty");
    enumEntryMetadata148.Params.Add("Empty");
    enumEntryMetadata148.Params.Add("Empty");
    enumEntryMetadata148.Params.Add("Empty");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata148);
    UasEnumEntryMetadata enumEntryMetadata149 = new UasEnumEntryMetadata()
    {
      Value = 181,
      Name = "DoSetRelay",
      Description = "Set a relay to a condition."
    };
    enumEntryMetadata149.Params = new List<string>();
    enumEntryMetadata149.Params.Add("Relay number");
    enumEntryMetadata149.Params.Add("Setting (1=on, 0=off, others possible depending on system hardware)");
    enumEntryMetadata149.Params.Add("Empty");
    enumEntryMetadata149.Params.Add("Empty");
    enumEntryMetadata149.Params.Add("Empty");
    enumEntryMetadata149.Params.Add("Empty");
    enumEntryMetadata149.Params.Add("Empty");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata149);
    UasEnumEntryMetadata enumEntryMetadata150 = new UasEnumEntryMetadata()
    {
      Value = 182,
      Name = "DoRepeatRelay",
      Description = "Cycle a relay on and off for a desired number of cyles with a desired period."
    };
    enumEntryMetadata150.Params = new List<string>();
    enumEntryMetadata150.Params.Add("Relay number");
    enumEntryMetadata150.Params.Add("Cycle count");
    enumEntryMetadata150.Params.Add("Cycle time (seconds, decimal)");
    enumEntryMetadata150.Params.Add("Empty");
    enumEntryMetadata150.Params.Add("Empty");
    enumEntryMetadata150.Params.Add("Empty");
    enumEntryMetadata150.Params.Add("Empty");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata150);
    UasEnumEntryMetadata enumEntryMetadata151 = new UasEnumEntryMetadata()
    {
      Value = 183,
      Name = "DoSetServo",
      Description = "Set a servo to a desired PWM value."
    };
    enumEntryMetadata151.Params = new List<string>();
    enumEntryMetadata151.Params.Add("Servo number");
    enumEntryMetadata151.Params.Add("PWM (microseconds, 1000 to 2000 typical)");
    enumEntryMetadata151.Params.Add("Empty");
    enumEntryMetadata151.Params.Add("Empty");
    enumEntryMetadata151.Params.Add("Empty");
    enumEntryMetadata151.Params.Add("Empty");
    enumEntryMetadata151.Params.Add("Empty");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata151);
    UasEnumEntryMetadata enumEntryMetadata152 = new UasEnumEntryMetadata()
    {
      Value = 184,
      Name = "DoRepeatServo",
      Description = "Cycle a between its nominal setting and a desired PWM for a desired number of cycles with a desired period."
    };
    enumEntryMetadata152.Params = new List<string>();
    enumEntryMetadata152.Params.Add("Servo number");
    enumEntryMetadata152.Params.Add("PWM (microseconds, 1000 to 2000 typical)");
    enumEntryMetadata152.Params.Add("Cycle count");
    enumEntryMetadata152.Params.Add("Cycle time (seconds)");
    enumEntryMetadata152.Params.Add("Empty");
    enumEntryMetadata152.Params.Add("Empty");
    enumEntryMetadata152.Params.Add("Empty");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata152);
    UasEnumEntryMetadata enumEntryMetadata153 = new UasEnumEntryMetadata()
    {
      Value = 200,
      Name = "DoControlVideo",
      Description = "Control onboard camera system."
    };
    enumEntryMetadata153.Params = new List<string>();
    enumEntryMetadata153.Params.Add("Camera ID (-1 for all)");
    enumEntryMetadata153.Params.Add("Transmission: 0: disabled, 1: enabled compressed, 2: enabled raw");
    enumEntryMetadata153.Params.Add("Transmission mode: 0: video stream, >0: single images every n seconds (decimal)");
    enumEntryMetadata153.Params.Add("Recording: 0: disabled, 1: enabled compressed, 2: enabled raw");
    enumEntryMetadata153.Params.Add("Empty");
    enumEntryMetadata153.Params.Add("Empty");
    enumEntryMetadata153.Params.Add("Empty");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata153);
    UasEnumEntryMetadata enumEntryMetadata154 = new UasEnumEntryMetadata()
    {
      Value = 201,
      Name = "DoSetRoi",
      Description = "Sets the region of interest (ROI) for a sensor set or the vehicle itself. This can then be used by the vehicles control system to control the vehicle attitude and the attitude of various sensors such as cameras."
    };
    enumEntryMetadata154.Params = new List<string>();
    enumEntryMetadata154.Params.Add("Region of intereset mode. (see MAV_ROI enum)");
    enumEntryMetadata154.Params.Add("MISSION index/ target ID. (see MAV_ROI enum)");
    enumEntryMetadata154.Params.Add("ROI index (allows a vehicle to manage multiple ROI's)");
    enumEntryMetadata154.Params.Add("Empty");
    enumEntryMetadata154.Params.Add("x the location of the fixed ROI (see MAV_FRAME)");
    enumEntryMetadata154.Params.Add("y");
    enumEntryMetadata154.Params.Add("z");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata154);
    UasEnumEntryMetadata enumEntryMetadata155 = new UasEnumEntryMetadata()
    {
      Value = 240 /*0xF0*/,
      Name = "DoLast",
      Description = "NOP - This command is only used to mark the upper limit of the DO commands in the enumeration"
    };
    enumEntryMetadata155.Params = new List<string>();
    enumEntryMetadata155.Params.Add("Empty");
    enumEntryMetadata155.Params.Add("Empty");
    enumEntryMetadata155.Params.Add("Empty");
    enumEntryMetadata155.Params.Add("Empty");
    enumEntryMetadata155.Params.Add("Empty");
    enumEntryMetadata155.Params.Add("Empty");
    enumEntryMetadata155.Params.Add("Empty");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata155);
    UasEnumEntryMetadata enumEntryMetadata156 = new UasEnumEntryMetadata()
    {
      Value = 241,
      Name = "PreflightCalibration",
      Description = "Trigger calibration. This command will be only accepted if in pre-flight mode."
    };
    enumEntryMetadata156.Params = new List<string>();
    enumEntryMetadata156.Params.Add("Gyro calibration: 0: no, 1: yes");
    enumEntryMetadata156.Params.Add("Magnetometer calibration: 0: no, 1: yes");
    enumEntryMetadata156.Params.Add("Ground pressure: 0: no, 1: yes");
    enumEntryMetadata156.Params.Add("Radio calibration: 0: no, 1: yes");
    enumEntryMetadata156.Params.Add("Accelerometer calibration: 0: no, 1: yes");
    enumEntryMetadata156.Params.Add("Empty");
    enumEntryMetadata156.Params.Add("Empty");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata156);
    UasEnumEntryMetadata enumEntryMetadata157 = new UasEnumEntryMetadata()
    {
      Value = 242,
      Name = "PreflightSetSensorOffsets",
      Description = "Set sensor offsets. This command will be only accepted if in pre-flight mode."
    };
    enumEntryMetadata157.Params = new List<string>();
    enumEntryMetadata157.Params.Add("Sensor to adjust the offsets for: 0: gyros, 1: accelerometer, 2: magnetometer, 3: barometer, 4: optical flow");
    enumEntryMetadata157.Params.Add("X axis offset (or generic dimension 1), in the sensor's raw units");
    enumEntryMetadata157.Params.Add("Y axis offset (or generic dimension 2), in the sensor's raw units");
    enumEntryMetadata157.Params.Add("Z axis offset (or generic dimension 3), in the sensor's raw units");
    enumEntryMetadata157.Params.Add("Generic dimension 4, in the sensor's raw units");
    enumEntryMetadata157.Params.Add("Generic dimension 5, in the sensor's raw units");
    enumEntryMetadata157.Params.Add("Generic dimension 6, in the sensor's raw units");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata157);
    UasEnumEntryMetadata enumEntryMetadata158 = new UasEnumEntryMetadata()
    {
      Value = 245,
      Name = "PreflightStorage",
      Description = "Request storage of different parameter values and logs. This command will be only accepted if in pre-flight mode."
    };
    enumEntryMetadata158.Params = new List<string>();
    enumEntryMetadata158.Params.Add("Parameter storage: 0: READ FROM FLASH/EEPROM, 1: WRITE CURRENT TO FLASH/EEPROM");
    enumEntryMetadata158.Params.Add("Mission storage: 0: READ FROM FLASH/EEPROM, 1: WRITE CURRENT TO FLASH/EEPROM");
    enumEntryMetadata158.Params.Add("Reserved");
    enumEntryMetadata158.Params.Add("Reserved");
    enumEntryMetadata158.Params.Add("Empty");
    enumEntryMetadata158.Params.Add("Empty");
    enumEntryMetadata158.Params.Add("Empty");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata158);
    UasEnumEntryMetadata enumEntryMetadata159 = new UasEnumEntryMetadata()
    {
      Value = 246,
      Name = "PreflightRebootShutdown",
      Description = "Request the reboot or shutdown of system components."
    };
    enumEntryMetadata159.Params = new List<string>();
    enumEntryMetadata159.Params.Add("0: Do nothing for autopilot, 1: Reboot autopilot, 2: Shutdown autopilot.");
    enumEntryMetadata159.Params.Add("0: Do nothing for onboard computer, 1: Reboot onboard computer, 2: Shutdown onboard computer.");
    enumEntryMetadata159.Params.Add("Reserved");
    enumEntryMetadata159.Params.Add("Reserved");
    enumEntryMetadata159.Params.Add("Empty");
    enumEntryMetadata159.Params.Add("Empty");
    enumEntryMetadata159.Params.Add("Empty");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata159);
    UasEnumEntryMetadata enumEntryMetadata160 = new UasEnumEntryMetadata()
    {
      Value = 252,
      Name = "OverrideGoto",
      Description = "Hold / continue the current action"
    };
    enumEntryMetadata160.Params = new List<string>();
    enumEntryMetadata160.Params.Add("MAV_GOTO_DO_HOLD: hold MAV_GOTO_DO_CONTINUE: continue with next item in mission plan");
    enumEntryMetadata160.Params.Add("MAV_GOTO_HOLD_AT_CURRENT_POSITION: Hold at current position MAV_GOTO_HOLD_AT_SPECIFIED_POSITION: hold at specified position");
    enumEntryMetadata160.Params.Add("MAV_FRAME coordinate frame of hold point");
    enumEntryMetadata160.Params.Add("Desired yaw angle in degrees");
    enumEntryMetadata160.Params.Add("Latitude / X position");
    enumEntryMetadata160.Params.Add("Longitude / Y position");
    enumEntryMetadata160.Params.Add("Altitude / Z position");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata160);
    UasEnumEntryMetadata enumEntryMetadata161 = new UasEnumEntryMetadata()
    {
      Value = 300,
      Name = "MissionStart",
      Description = "start running a mission"
    };
    enumEntryMetadata161.Params = new List<string>();
    enumEntryMetadata161.Params.Add("first_item: the first mission item to run");
    enumEntryMetadata161.Params.Add("last_item:  the last mission item to run (after this item is run, the mission ends)");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata161);
    UasEnumEntryMetadata enumEntryMetadata162 = new UasEnumEntryMetadata()
    {
      Value = 400,
      Name = "ComponentArmDisarm",
      Description = "Arms / Disarms a component"
    };
    enumEntryMetadata162.Params = new List<string>();
    enumEntryMetadata162.Params.Add("1 to arm, 0 to disarm");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata162);
    UasEnumEntryMetadata enumEntryMetadata163 = new UasEnumEntryMetadata()
    {
      Value = 500,
      Name = "StartRxPair",
      Description = "Starts receiver pairing"
    };
    enumEntryMetadata163.Params = new List<string>();
    enumEntryMetadata163.Params.Add("0:Spektrum");
    enumEntryMetadata163.Params.Add("0:Spektrum DSM2, 1:Spektrum DSMX");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata163);
    UasEnumEntryMetadata enumEntryMetadata164 = new UasEnumEntryMetadata()
    {
      Value = 202,
      Name = "DoDigicamConfigure",
      Description = "Mission command to configure an on-board camera controller system."
    };
    enumEntryMetadata164.Params = new List<string>();
    enumEntryMetadata164.Params.Add("Modes: P, TV, AV, M, Etc");
    enumEntryMetadata164.Params.Add("Shutter speed: Divisor number for one second");
    enumEntryMetadata164.Params.Add("Aperture: F stop number");
    enumEntryMetadata164.Params.Add("ISO number e.g. 80, 100, 200, Etc");
    enumEntryMetadata164.Params.Add("Exposure type enumerator");
    enumEntryMetadata164.Params.Add("Command Identity");
    enumEntryMetadata164.Params.Add("Main engine cut-off time before camera trigger in seconds/10 (0 means no cut-off)");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata164);
    UasEnumEntryMetadata enumEntryMetadata165 = new UasEnumEntryMetadata()
    {
      Value = 203,
      Name = "DoDigicamControl",
      Description = "Mission command to control an on-board camera controller system."
    };
    enumEntryMetadata165.Params = new List<string>();
    enumEntryMetadata165.Params.Add("Session control e.g. show/hide lens");
    enumEntryMetadata165.Params.Add("Zoom's absolute position");
    enumEntryMetadata165.Params.Add("Zooming step value to offset zoom from the current position");
    enumEntryMetadata165.Params.Add("Focus Locking, Unlocking or Re-locking");
    enumEntryMetadata165.Params.Add("Shooting Command");
    enumEntryMetadata165.Params.Add("Command Identity");
    enumEntryMetadata165.Params.Add("Empty");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata165);
    UasEnumEntryMetadata enumEntryMetadata166 = new UasEnumEntryMetadata()
    {
      Value = 204,
      Name = "DoMountConfigure",
      Description = "Mission command to configure a camera or antenna mount"
    };
    enumEntryMetadata166.Params = new List<string>();
    enumEntryMetadata166.Params.Add("Mount operation mode (see MAV_MOUNT_MODE enum)");
    enumEntryMetadata166.Params.Add("stabilize roll? (1 = yes, 0 = no)");
    enumEntryMetadata166.Params.Add("stabilize pitch? (1 = yes, 0 = no)");
    enumEntryMetadata166.Params.Add("stabilize yaw? (1 = yes, 0 = no)");
    enumEntryMetadata166.Params.Add("Empty");
    enumEntryMetadata166.Params.Add("Empty");
    enumEntryMetadata166.Params.Add("Empty");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata166);
    UasEnumEntryMetadata enumEntryMetadata167 = new UasEnumEntryMetadata()
    {
      Value = 205,
      Name = "DoMountControl",
      Description = "Mission command to control a camera or antenna mount"
    };
    enumEntryMetadata167.Params = new List<string>();
    enumEntryMetadata167.Params.Add("pitch(deg*100) or lat, depending on mount mode.");
    enumEntryMetadata167.Params.Add("roll(deg*100) or lon depending on mount mode");
    enumEntryMetadata167.Params.Add("yaw(deg*100) or alt (in cm) depending on mount mode");
    enumEntryMetadata167.Params.Add("Empty");
    enumEntryMetadata167.Params.Add("Empty");
    enumEntryMetadata167.Params.Add("Empty");
    enumEntryMetadata167.Params.Add("Empty");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata167);
    UasEnumEntryMetadata enumEntryMetadata168 = new UasEnumEntryMetadata()
    {
      Value = 206,
      Name = "DoSetCamTriggDist",
      Description = "Mission command to set CAM_TRIGG_DIST for this flight"
    };
    enumEntryMetadata168.Params = new List<string>();
    enumEntryMetadata168.Params.Add("Camera trigger distance (meters)");
    enumEntryMetadata168.Params.Add("Empty");
    enumEntryMetadata168.Params.Add("Empty");
    enumEntryMetadata168.Params.Add("Empty");
    enumEntryMetadata168.Params.Add("Empty");
    enumEntryMetadata168.Params.Add("Empty");
    enumEntryMetadata168.Params.Add("Empty");
    uasEnumMetadata12.Entries.Add(enumEntryMetadata168);
    UasSummary.mEnums.Add(uasEnumMetadata12.Name, uasEnumMetadata12);
    UasEnumMetadata uasEnumMetadata13 = new UasEnumMetadata()
    {
      Name = "MavDataStream",
      Description = "Data stream IDs. A data stream is not a fixed set of messages, but rather a       recommendation to the autopilot software. Individual autopilots may or may not obey       the recommended messages."
    };
    UasEnumEntryMetadata enumEntryMetadata169 = new UasEnumEntryMetadata()
    {
      Value = 0,
      Name = "All",
      Description = "Enable all data streams"
    };
    uasEnumMetadata13.Entries.Add(enumEntryMetadata169);
    UasEnumEntryMetadata enumEntryMetadata170 = new UasEnumEntryMetadata()
    {
      Value = 1,
      Name = "RawSensors",
      Description = "Enable IMU_RAW, GPS_RAW, GPS_STATUS packets."
    };
    uasEnumMetadata13.Entries.Add(enumEntryMetadata170);
    UasEnumEntryMetadata enumEntryMetadata171 = new UasEnumEntryMetadata()
    {
      Value = 2,
      Name = "ExtendedStatus",
      Description = "Enable GPS_STATUS, CONTROL_STATUS, AUX_STATUS"
    };
    uasEnumMetadata13.Entries.Add(enumEntryMetadata171);
    UasEnumEntryMetadata enumEntryMetadata172 = new UasEnumEntryMetadata()
    {
      Value = 3,
      Name = "RcChannels",
      Description = "Enable RC_CHANNELS_SCALED, RC_CHANNELS_RAW, SERVO_OUTPUT_RAW"
    };
    uasEnumMetadata13.Entries.Add(enumEntryMetadata172);
    UasEnumEntryMetadata enumEntryMetadata173 = new UasEnumEntryMetadata()
    {
      Value = 4,
      Name = "RawController",
      Description = "Enable ATTITUDE_CONTROLLER_OUTPUT, POSITION_CONTROLLER_OUTPUT, NAV_CONTROLLER_OUTPUT."
    };
    uasEnumMetadata13.Entries.Add(enumEntryMetadata173);
    UasEnumEntryMetadata enumEntryMetadata174 = new UasEnumEntryMetadata()
    {
      Value = 6,
      Name = "Position",
      Description = "Enable LOCAL_POSITION, GLOBAL_POSITION/GLOBAL_POSITION_INT messages."
    };
    uasEnumMetadata13.Entries.Add(enumEntryMetadata174);
    UasEnumEntryMetadata enumEntryMetadata175 = new UasEnumEntryMetadata()
    {
      Value = 10,
      Name = "Extra1",
      Description = "Dependent on the autopilot"
    };
    uasEnumMetadata13.Entries.Add(enumEntryMetadata175);
    UasEnumEntryMetadata enumEntryMetadata176 = new UasEnumEntryMetadata()
    {
      Value = 11,
      Name = "Extra2",
      Description = "Dependent on the autopilot"
    };
    uasEnumMetadata13.Entries.Add(enumEntryMetadata176);
    UasEnumEntryMetadata enumEntryMetadata177 = new UasEnumEntryMetadata()
    {
      Value = 12,
      Name = "Extra3",
      Description = "Dependent on the autopilot"
    };
    uasEnumMetadata13.Entries.Add(enumEntryMetadata177);
    UasSummary.mEnums.Add(uasEnumMetadata13.Name, uasEnumMetadata13);
    UasEnumMetadata uasEnumMetadata14 = new UasEnumMetadata()
    {
      Name = "MavRoi",
      Description = " The ROI (region of interest) for the vehicle. This can be                  be used by the vehicle for camera/vehicle attitude alignment (see                  MAV_CMD_NAV_ROI)."
    };
    UasEnumEntryMetadata enumEntryMetadata178 = new UasEnumEntryMetadata()
    {
      Value = 0,
      Name = "None",
      Description = "No region of interest."
    };
    uasEnumMetadata14.Entries.Add(enumEntryMetadata178);
    UasEnumEntryMetadata enumEntryMetadata179 = new UasEnumEntryMetadata()
    {
      Value = 1,
      Name = "Wpnext",
      Description = "Point toward next MISSION."
    };
    uasEnumMetadata14.Entries.Add(enumEntryMetadata179);
    UasEnumEntryMetadata enumEntryMetadata180 = new UasEnumEntryMetadata()
    {
      Value = 2,
      Name = "Wpindex",
      Description = "Point toward given MISSION."
    };
    uasEnumMetadata14.Entries.Add(enumEntryMetadata180);
    UasEnumEntryMetadata enumEntryMetadata181 = new UasEnumEntryMetadata()
    {
      Value = 3,
      Name = "Location",
      Description = "Point toward fixed location."
    };
    uasEnumMetadata14.Entries.Add(enumEntryMetadata181);
    UasEnumEntryMetadata enumEntryMetadata182 = new UasEnumEntryMetadata()
    {
      Value = 4,
      Name = "Target",
      Description = "Point toward of given id."
    };
    uasEnumMetadata14.Entries.Add(enumEntryMetadata182);
    UasSummary.mEnums.Add(uasEnumMetadata14.Name, uasEnumMetadata14);
    UasEnumMetadata uasEnumMetadata15 = new UasEnumMetadata()
    {
      Name = "MavCmdAck",
      Description = "ACK / NACK / ERROR values as a result of MAV_CMDs and for mission item transmission."
    };
    UasEnumEntryMetadata enumEntryMetadata183 = new UasEnumEntryMetadata()
    {
      Value = 1,
      Name = "Ok",
      Description = "Command / mission item is ok."
    };
    uasEnumMetadata15.Entries.Add(enumEntryMetadata183);
    UasEnumEntryMetadata enumEntryMetadata184 = new UasEnumEntryMetadata()
    {
      Value = 2,
      Name = "ErrFail",
      Description = "Generic error message if none of the other reasons fails or if no detailed error reporting is implemented."
    };
    uasEnumMetadata15.Entries.Add(enumEntryMetadata184);
    UasEnumEntryMetadata enumEntryMetadata185 = new UasEnumEntryMetadata()
    {
      Value = 3,
      Name = "ErrAccessDenied",
      Description = "The system is refusing to accept this command from this source / communication partner."
    };
    uasEnumMetadata15.Entries.Add(enumEntryMetadata185);
    UasEnumEntryMetadata enumEntryMetadata186 = new UasEnumEntryMetadata()
    {
      Value = 4,
      Name = "ErrNotSupported",
      Description = "Command or mission item is not supported, other commands would be accepted."
    };
    uasEnumMetadata15.Entries.Add(enumEntryMetadata186);
    UasEnumEntryMetadata enumEntryMetadata187 = new UasEnumEntryMetadata()
    {
      Value = 5,
      Name = "ErrCoordinateFrameNotSupported",
      Description = "The coordinate frame of this command / mission item is not supported."
    };
    uasEnumMetadata15.Entries.Add(enumEntryMetadata187);
    UasEnumEntryMetadata enumEntryMetadata188 = new UasEnumEntryMetadata()
    {
      Value = 6,
      Name = "ErrCoordinatesOutOfRange",
      Description = "The coordinate frame of this command is ok, but he coordinate values exceed the safety limits of this system. This is a generic error, please use the more specific error messages below if possible."
    };
    uasEnumMetadata15.Entries.Add(enumEntryMetadata188);
    UasEnumEntryMetadata enumEntryMetadata189 = new UasEnumEntryMetadata()
    {
      Value = 7,
      Name = "ErrXLatOutOfRange",
      Description = "The X or latitude value is out of range."
    };
    uasEnumMetadata15.Entries.Add(enumEntryMetadata189);
    UasEnumEntryMetadata enumEntryMetadata190 = new UasEnumEntryMetadata()
    {
      Value = 8,
      Name = "ErrYLonOutOfRange",
      Description = "The Y or longitude value is out of range."
    };
    uasEnumMetadata15.Entries.Add(enumEntryMetadata190);
    UasEnumEntryMetadata enumEntryMetadata191 = new UasEnumEntryMetadata()
    {
      Value = 9,
      Name = "ErrZAltOutOfRange",
      Description = "The Z or altitude value is out of range."
    };
    uasEnumMetadata15.Entries.Add(enumEntryMetadata191);
    UasSummary.mEnums.Add(uasEnumMetadata15.Name, uasEnumMetadata15);
    UasEnumMetadata uasEnumMetadata16 = new UasEnumMetadata()
    {
      Name = "MavParamType",
      Description = "Specifies the datatype of a MAVLink parameter."
    };
    UasEnumEntryMetadata enumEntryMetadata192 = new UasEnumEntryMetadata()
    {
      Value = 1,
      Name = "Uint8",
      Description = "8-bit unsigned integer"
    };
    uasEnumMetadata16.Entries.Add(enumEntryMetadata192);
    UasEnumEntryMetadata enumEntryMetadata193 = new UasEnumEntryMetadata()
    {
      Value = 2,
      Name = "Int8",
      Description = "8-bit signed integer"
    };
    uasEnumMetadata16.Entries.Add(enumEntryMetadata193);
    UasEnumEntryMetadata enumEntryMetadata194 = new UasEnumEntryMetadata()
    {
      Value = 3,
      Name = "Uint16",
      Description = "16-bit unsigned integer"
    };
    uasEnumMetadata16.Entries.Add(enumEntryMetadata194);
    UasEnumEntryMetadata enumEntryMetadata195 = new UasEnumEntryMetadata()
    {
      Value = 4,
      Name = "Int16",
      Description = "16-bit signed integer"
    };
    uasEnumMetadata16.Entries.Add(enumEntryMetadata195);
    UasEnumEntryMetadata enumEntryMetadata196 = new UasEnumEntryMetadata()
    {
      Value = 5,
      Name = "Uint32",
      Description = "32-bit unsigned integer"
    };
    uasEnumMetadata16.Entries.Add(enumEntryMetadata196);
    UasEnumEntryMetadata enumEntryMetadata197 = new UasEnumEntryMetadata()
    {
      Value = 6,
      Name = "Int32",
      Description = "32-bit signed integer"
    };
    uasEnumMetadata16.Entries.Add(enumEntryMetadata197);
    UasEnumEntryMetadata enumEntryMetadata198 = new UasEnumEntryMetadata()
    {
      Value = 7,
      Name = "Uint64",
      Description = "64-bit unsigned integer"
    };
    uasEnumMetadata16.Entries.Add(enumEntryMetadata198);
    UasEnumEntryMetadata enumEntryMetadata199 = new UasEnumEntryMetadata()
    {
      Value = 8,
      Name = "Int64",
      Description = "64-bit signed integer"
    };
    uasEnumMetadata16.Entries.Add(enumEntryMetadata199);
    UasEnumEntryMetadata enumEntryMetadata200 = new UasEnumEntryMetadata()
    {
      Value = 9,
      Name = "Real32",
      Description = "32-bit floating-point"
    };
    uasEnumMetadata16.Entries.Add(enumEntryMetadata200);
    UasEnumEntryMetadata enumEntryMetadata201 = new UasEnumEntryMetadata()
    {
      Value = 10,
      Name = "Real64",
      Description = "64-bit floating-point"
    };
    uasEnumMetadata16.Entries.Add(enumEntryMetadata201);
    UasSummary.mEnums.Add(uasEnumMetadata16.Name, uasEnumMetadata16);
    UasEnumMetadata uasEnumMetadata17 = new UasEnumMetadata()
    {
      Name = "MavResult",
      Description = "result from a mavlink command"
    };
    UasEnumEntryMetadata enumEntryMetadata202 = new UasEnumEntryMetadata()
    {
      Value = 0,
      Name = "Accepted",
      Description = "Command ACCEPTED and EXECUTED"
    };
    uasEnumMetadata17.Entries.Add(enumEntryMetadata202);
    UasEnumEntryMetadata enumEntryMetadata203 = new UasEnumEntryMetadata()
    {
      Value = 1,
      Name = "TemporarilyRejected",
      Description = "Command TEMPORARY REJECTED/DENIED"
    };
    uasEnumMetadata17.Entries.Add(enumEntryMetadata203);
    UasEnumEntryMetadata enumEntryMetadata204 = new UasEnumEntryMetadata()
    {
      Value = 2,
      Name = "Denied",
      Description = "Command PERMANENTLY DENIED"
    };
    uasEnumMetadata17.Entries.Add(enumEntryMetadata204);
    UasEnumEntryMetadata enumEntryMetadata205 = new UasEnumEntryMetadata()
    {
      Value = 3,
      Name = "Unsupported",
      Description = "Command UNKNOWN/UNSUPPORTED"
    };
    uasEnumMetadata17.Entries.Add(enumEntryMetadata205);
    UasEnumEntryMetadata enumEntryMetadata206 = new UasEnumEntryMetadata()
    {
      Value = 4,
      Name = "Failed",
      Description = "Command executed, but failed"
    };
    uasEnumMetadata17.Entries.Add(enumEntryMetadata206);
    UasSummary.mEnums.Add(uasEnumMetadata17.Name, uasEnumMetadata17);
    UasEnumMetadata uasEnumMetadata18 = new UasEnumMetadata()
    {
      Name = "MavMissionResult",
      Description = "result in a mavlink mission ack"
    };
    UasEnumEntryMetadata enumEntryMetadata207 = new UasEnumEntryMetadata()
    {
      Value = 0,
      Name = "MavMissionAccepted",
      Description = "mission accepted OK"
    };
    uasEnumMetadata18.Entries.Add(enumEntryMetadata207);
    UasEnumEntryMetadata enumEntryMetadata208 = new UasEnumEntryMetadata()
    {
      Value = 1,
      Name = "MavMissionError",
      Description = "generic error / not accepting mission commands at all right now"
    };
    uasEnumMetadata18.Entries.Add(enumEntryMetadata208);
    UasEnumEntryMetadata enumEntryMetadata209 = new UasEnumEntryMetadata()
    {
      Value = 2,
      Name = "MavMissionUnsupportedFrame",
      Description = "coordinate frame is not supported"
    };
    uasEnumMetadata18.Entries.Add(enumEntryMetadata209);
    UasEnumEntryMetadata enumEntryMetadata210 = new UasEnumEntryMetadata()
    {
      Value = 3,
      Name = "MavMissionUnsupported",
      Description = "command is not supported"
    };
    uasEnumMetadata18.Entries.Add(enumEntryMetadata210);
    UasEnumEntryMetadata enumEntryMetadata211 = new UasEnumEntryMetadata()
    {
      Value = 4,
      Name = "MavMissionNoSpace",
      Description = "mission item exceeds storage space"
    };
    uasEnumMetadata18.Entries.Add(enumEntryMetadata211);
    UasEnumEntryMetadata enumEntryMetadata212 = new UasEnumEntryMetadata()
    {
      Value = 5,
      Name = "MavMissionInvalid",
      Description = "one of the parameters has an invalid value"
    };
    uasEnumMetadata18.Entries.Add(enumEntryMetadata212);
    UasEnumEntryMetadata enumEntryMetadata213 = new UasEnumEntryMetadata()
    {
      Value = 6,
      Name = "MavMissionInvalidParam1",
      Description = "param1 has an invalid value"
    };
    uasEnumMetadata18.Entries.Add(enumEntryMetadata213);
    UasEnumEntryMetadata enumEntryMetadata214 = new UasEnumEntryMetadata()
    {
      Value = 7,
      Name = "MavMissionInvalidParam2",
      Description = "param2 has an invalid value"
    };
    uasEnumMetadata18.Entries.Add(enumEntryMetadata214);
    UasEnumEntryMetadata enumEntryMetadata215 = new UasEnumEntryMetadata()
    {
      Value = 8,
      Name = "MavMissionInvalidParam3",
      Description = "param3 has an invalid value"
    };
    uasEnumMetadata18.Entries.Add(enumEntryMetadata215);
    UasEnumEntryMetadata enumEntryMetadata216 = new UasEnumEntryMetadata()
    {
      Value = 9,
      Name = "MavMissionInvalidParam4",
      Description = "param4 has an invalid value"
    };
    uasEnumMetadata18.Entries.Add(enumEntryMetadata216);
    UasEnumEntryMetadata enumEntryMetadata217 = new UasEnumEntryMetadata()
    {
      Value = 10,
      Name = "MavMissionInvalidParam5X",
      Description = "x/param5 has an invalid value"
    };
    uasEnumMetadata18.Entries.Add(enumEntryMetadata217);
    UasEnumEntryMetadata enumEntryMetadata218 = new UasEnumEntryMetadata()
    {
      Value = 11,
      Name = "MavMissionInvalidParam6Y",
      Description = "y/param6 has an invalid value"
    };
    uasEnumMetadata18.Entries.Add(enumEntryMetadata218);
    UasEnumEntryMetadata enumEntryMetadata219 = new UasEnumEntryMetadata()
    {
      Value = 12,
      Name = "MavMissionInvalidParam7",
      Description = "param7 has an invalid value"
    };
    uasEnumMetadata18.Entries.Add(enumEntryMetadata219);
    UasEnumEntryMetadata enumEntryMetadata220 = new UasEnumEntryMetadata()
    {
      Value = 13,
      Name = "MavMissionInvalidSequence",
      Description = "received waypoint out of sequence"
    };
    uasEnumMetadata18.Entries.Add(enumEntryMetadata220);
    UasEnumEntryMetadata enumEntryMetadata221 = new UasEnumEntryMetadata()
    {
      Value = 14,
      Name = "MavMissionDenied",
      Description = "not accepting any mission commands from this communication partner"
    };
    uasEnumMetadata18.Entries.Add(enumEntryMetadata221);
    UasSummary.mEnums.Add(uasEnumMetadata18.Name, uasEnumMetadata18);
    UasEnumMetadata uasEnumMetadata19 = new UasEnumMetadata()
    {
      Name = "MavSeverity",
      Description = "Indicates the severity level, generally used for status messages to indicate their relative urgency. Based on RFC-5424 using expanded definitions at: http://www.kiwisyslog.com/kb/info:-syslog-message-levels/."
    };
    UasEnumEntryMetadata enumEntryMetadata222 = new UasEnumEntryMetadata()
    {
      Value = 0,
      Name = "Emergency",
      Description = "System is unusable. This is a 'panic' condition."
    };
    uasEnumMetadata19.Entries.Add(enumEntryMetadata222);
    UasEnumEntryMetadata enumEntryMetadata223 = new UasEnumEntryMetadata()
    {
      Value = 1,
      Name = "Alert",
      Description = "Action should be taken immediately. Indicates error in non-critical systems."
    };
    uasEnumMetadata19.Entries.Add(enumEntryMetadata223);
    UasEnumEntryMetadata enumEntryMetadata224 = new UasEnumEntryMetadata()
    {
      Value = 2,
      Name = "Critical",
      Description = "Action must be taken immediately. Indicates failure in a primary system."
    };
    uasEnumMetadata19.Entries.Add(enumEntryMetadata224);
    UasEnumEntryMetadata enumEntryMetadata225 = new UasEnumEntryMetadata()
    {
      Value = 3,
      Name = "Error",
      Description = "Indicates an error in secondary/redundant systems."
    };
    uasEnumMetadata19.Entries.Add(enumEntryMetadata225);
    UasEnumEntryMetadata enumEntryMetadata226 = new UasEnumEntryMetadata()
    {
      Value = 4,
      Name = "Warning",
      Description = "Indicates about a possible future error if this is not resolved within a given timeframe. Example would be a low battery warning."
    };
    uasEnumMetadata19.Entries.Add(enumEntryMetadata226);
    UasEnumEntryMetadata enumEntryMetadata227 = new UasEnumEntryMetadata()
    {
      Value = 5,
      Name = "Notice",
      Description = "An unusual event has occured, though not an error condition. This should be investigated for the root cause."
    };
    uasEnumMetadata19.Entries.Add(enumEntryMetadata227);
    UasEnumEntryMetadata enumEntryMetadata228 = new UasEnumEntryMetadata()
    {
      Value = 6,
      Name = "Info",
      Description = "Normal operational messages. Useful for logging. No action is required for these messages."
    };
    uasEnumMetadata19.Entries.Add(enumEntryMetadata228);
    UasEnumEntryMetadata enumEntryMetadata229 = new UasEnumEntryMetadata()
    {
      Value = 7,
      Name = "Debug",
      Description = "Useful non-operational messages that can assist in debugging. These should not occur during normal operation."
    };
    uasEnumMetadata19.Entries.Add(enumEntryMetadata229);
    UasSummary.mEnums.Add(uasEnumMetadata19.Name, uasEnumMetadata19);
    UasEnumMetadata uasEnumMetadata20 = new UasEnumMetadata()
    {
      Name = "MavMountMode",
      Description = "Enumeration of possible mount operation modes"
    };
    UasEnumEntryMetadata enumEntryMetadata230 = new UasEnumEntryMetadata()
    {
      Value = 0,
      Name = "Retract",
      Description = "Load and keep safe position (Roll,Pitch,Yaw) from EEPROM and stop stabilization"
    };
    uasEnumMetadata20.Entries.Add(enumEntryMetadata230);
    UasEnumEntryMetadata enumEntryMetadata231 = new UasEnumEntryMetadata()
    {
      Value = 1,
      Name = "Neutral",
      Description = "Load and keep neutral position (Roll,Pitch,Yaw) from EEPROM."
    };
    uasEnumMetadata20.Entries.Add(enumEntryMetadata231);
    UasEnumEntryMetadata enumEntryMetadata232 = new UasEnumEntryMetadata()
    {
      Value = 2,
      Name = "MavlinkTargeting",
      Description = "Load neutral position and start MAVLink Roll,Pitch,Yaw control with stabilization"
    };
    uasEnumMetadata20.Entries.Add(enumEntryMetadata232);
    UasEnumEntryMetadata enumEntryMetadata233 = new UasEnumEntryMetadata()
    {
      Value = 3,
      Name = "RcTargeting",
      Description = "Load neutral position and start RC Roll,Pitch,Yaw control with stabilization"
    };
    uasEnumMetadata20.Entries.Add(enumEntryMetadata233);
    UasEnumEntryMetadata enumEntryMetadata234 = new UasEnumEntryMetadata()
    {
      Value = 4,
      Name = "GpsPoint",
      Description = "Load neutral position and start to point to Lat,Lon,Alt"
    };
    uasEnumMetadata20.Entries.Add(enumEntryMetadata234);
    UasSummary.mEnums.Add(uasEnumMetadata20.Name, uasEnumMetadata20);
    UasEnumMetadata uasEnumMetadata21 = new UasEnumMetadata()
    {
      Name = "FenceAction",
      Description = ""
    };
    UasEnumEntryMetadata enumEntryMetadata235 = new UasEnumEntryMetadata()
    {
      Value = 0,
      Name = "None",
      Description = "Disable fenced mode"
    };
    uasEnumMetadata21.Entries.Add(enumEntryMetadata235);
    UasEnumEntryMetadata enumEntryMetadata236 = new UasEnumEntryMetadata()
    {
      Value = 1,
      Name = "Guided",
      Description = "Switched to guided mode to return point (fence point 0)"
    };
    uasEnumMetadata21.Entries.Add(enumEntryMetadata236);
    UasEnumEntryMetadata enumEntryMetadata237 = new UasEnumEntryMetadata()
    {
      Value = 2,
      Name = "Report",
      Description = "Report fence breach, but don't take action"
    };
    uasEnumMetadata21.Entries.Add(enumEntryMetadata237);
    UasEnumEntryMetadata enumEntryMetadata238 = new UasEnumEntryMetadata()
    {
      Value = 3,
      Name = "GuidedThrPass",
      Description = "Switched to guided mode to return point (fence point 0) with manual throttle control"
    };
    uasEnumMetadata21.Entries.Add(enumEntryMetadata238);
    UasSummary.mEnums.Add(uasEnumMetadata21.Name, uasEnumMetadata21);
    UasEnumMetadata uasEnumMetadata22 = new UasEnumMetadata()
    {
      Name = "FenceBreach",
      Description = ""
    };
    UasEnumEntryMetadata enumEntryMetadata239 = new UasEnumEntryMetadata()
    {
      Value = 0,
      Name = "None",
      Description = "No last fence breach"
    };
    uasEnumMetadata22.Entries.Add(enumEntryMetadata239);
    UasEnumEntryMetadata enumEntryMetadata240 = new UasEnumEntryMetadata()
    {
      Value = 1,
      Name = "Minalt",
      Description = "Breached minimum altitude"
    };
    uasEnumMetadata22.Entries.Add(enumEntryMetadata240);
    UasEnumEntryMetadata enumEntryMetadata241 = new UasEnumEntryMetadata()
    {
      Value = 2,
      Name = "Maxalt",
      Description = "Breached maximum altitude"
    };
    uasEnumMetadata22.Entries.Add(enumEntryMetadata241);
    UasEnumEntryMetadata enumEntryMetadata242 = new UasEnumEntryMetadata()
    {
      Value = 3,
      Name = "Boundary",
      Description = "Breached fence boundary"
    };
    uasEnumMetadata22.Entries.Add(enumEntryMetadata242);
    UasSummary.mEnums.Add(uasEnumMetadata22.Name, uasEnumMetadata22);
    UasEnumMetadata uasEnumMetadata23 = new UasEnumMetadata()
    {
      Name = "LimitsState",
      Description = ""
    };
    UasEnumEntryMetadata enumEntryMetadata243 = new UasEnumEntryMetadata()
    {
      Value = 0,
      Name = "LimitsInit",
      Description = " pre-initialization"
    };
    uasEnumMetadata23.Entries.Add(enumEntryMetadata243);
    UasEnumEntryMetadata enumEntryMetadata244 = new UasEnumEntryMetadata()
    {
      Value = 1,
      Name = "LimitsDisabled",
      Description = " disabled"
    };
    uasEnumMetadata23.Entries.Add(enumEntryMetadata244);
    UasEnumEntryMetadata enumEntryMetadata245 = new UasEnumEntryMetadata()
    {
      Value = 2,
      Name = "LimitsEnabled",
      Description = " checking limits"
    };
    uasEnumMetadata23.Entries.Add(enumEntryMetadata245);
    UasEnumEntryMetadata enumEntryMetadata246 = new UasEnumEntryMetadata()
    {
      Value = 3,
      Name = "LimitsTriggered",
      Description = " a limit has been breached"
    };
    uasEnumMetadata23.Entries.Add(enumEntryMetadata246);
    UasEnumEntryMetadata enumEntryMetadata247 = new UasEnumEntryMetadata()
    {
      Value = 4,
      Name = "LimitsRecovering",
      Description = " taking action eg. RTL"
    };
    uasEnumMetadata23.Entries.Add(enumEntryMetadata247);
    UasEnumEntryMetadata enumEntryMetadata248 = new UasEnumEntryMetadata()
    {
      Value = 5,
      Name = "LimitsRecovered",
      Description = " we're no longer in breach of a limit"
    };
    uasEnumMetadata23.Entries.Add(enumEntryMetadata248);
    UasSummary.mEnums.Add(uasEnumMetadata23.Name, uasEnumMetadata23);
    UasEnumMetadata uasEnumMetadata24 = new UasEnumMetadata()
    {
      Name = "LimitModule",
      Description = ""
    };
    UasEnumEntryMetadata enumEntryMetadata249 = new UasEnumEntryMetadata()
    {
      Value = 1,
      Name = "LimitGpslock",
      Description = " pre-initialization"
    };
    uasEnumMetadata24.Entries.Add(enumEntryMetadata249);
    UasEnumEntryMetadata enumEntryMetadata250 = new UasEnumEntryMetadata()
    {
      Value = 2,
      Name = "LimitGeofence",
      Description = " disabled"
    };
    uasEnumMetadata24.Entries.Add(enumEntryMetadata250);
    UasEnumEntryMetadata enumEntryMetadata251 = new UasEnumEntryMetadata()
    {
      Value = 4,
      Name = "LimitAltitude",
      Description = " checking limits"
    };
    uasEnumMetadata24.Entries.Add(enumEntryMetadata251);
    UasSummary.mEnums.Add(uasEnumMetadata24.Name, uasEnumMetadata24);
    UasEnumMetadata uasEnumMetadata25 = new UasEnumMetadata()
    {
      Name = "RallyFlags",
      Description = "Flags in RALLY_POINT message"
    };
    UasEnumEntryMetadata enumEntryMetadata252 = new UasEnumEntryMetadata()
    {
      Value = 1,
      Name = "FavorableWind",
      Description = "Flag set when requiring favorable winds for landing. "
    };
    uasEnumMetadata25.Entries.Add(enumEntryMetadata252);
    UasEnumEntryMetadata enumEntryMetadata253 = new UasEnumEntryMetadata()
    {
      Value = 2,
      Name = "LandImmediately",
      Description = "Flag set when plane is to immediately descend to break altitude and land without GCS intervention.  Flag not set when plane is to loiter at Rally point until commanded to land."
    };
    uasEnumMetadata25.Entries.Add(enumEntryMetadata253);
    UasSummary.mEnums.Add(uasEnumMetadata25.Name, uasEnumMetadata25);
  }
}
