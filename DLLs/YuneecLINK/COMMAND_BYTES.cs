// Decompiled with JetBrains decompiler
// Type: YuneecLinkNet.COMMAND_BYTES
// Assembly: YuneecLINK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CFB54D17-6788-4CFB-B24E-B7975B945505
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\YuneecLINK.dll

#nullable disable
namespace YuneecLinkNet;

public enum COMMAND_BYTES
{
  PROTO_GET_SYNC = 33, // 0x00000021
  PROTO_GET_DEVICE = 34, // 0x00000022
  PROTO_CHIP_ERASE = 35, // 0x00000023
  PROTO_PROG_MULTI = 39, // 0x00000027
  PROTO_GET_CRC = 41, // 0x00000029
  PROTO_GET_OTP = 42, // 0x0000002A
  PROTO_GET_SN = 43, // 0x0000002B
  PROTO_BOOT = 48, // 0x00000030
  PROTO_DEBUG = 49, // 0x00000031
  PROTO_GET_SOFTWARE_VERSION = 64, // 0x00000040
}
