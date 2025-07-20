// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Main.DevicePropertyType
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

#nullable disable
namespace LibUsbDotNet.Main;

public enum DevicePropertyType
{
  DeviceDesc = 0,
  HardwareId = 1,
  CompatibleIds = 2,
  Class = 5,
  ClassGuid = 6,
  Driver = 7,
  Mfg = 8,
  FriendlyName = 9,
  LocationInformation = 10, // 0x0000000A
  PhysicalDeviceObjectName = 11, // 0x0000000B
  BusTypeGuid = 12, // 0x0000000C
  LegacyBusType = 13, // 0x0000000D
  BusNumber = 14, // 0x0000000E
  EnumeratorName = 15, // 0x0000000F
  Address = 16, // 0x00000010
  UiNumber = 17, // 0x00000011
  InstallState = 18, // 0x00000012
  RemovalPolicy = 19, // 0x00000013
}
