// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Main.SPDRP
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System;

#nullable disable
namespace LibUsbDotNet.Main;

[Flags]
public enum SPDRP
{
  DeviceDesc = 0,
  HardwareId = 1,
  CompatibleIds = 2,
  Class = 7,
  ClassGuid = 8,
  Driver = ClassGuid | HardwareId, // 0x00000009
  Mfg = Driver | CompatibleIds, // 0x0000000B
  FriendlyName = 12, // 0x0000000C
  LocationInformation = FriendlyName | HardwareId, // 0x0000000D
  PhysicalDeviceObjectName = FriendlyName | CompatibleIds, // 0x0000000E
  UiNumber = 16, // 0x00000010
  BusTypeGuid = UiNumber | CompatibleIds | HardwareId, // 0x00000013
  LegacyBusType = 20, // 0x00000014
  BusNumber = LegacyBusType | HardwareId, // 0x00000015
  EnumeratorName = LegacyBusType | CompatibleIds, // 0x00000016
  Address = LegacyBusType | ClassGuid, // 0x0000001C
  RemovalPolicy = Address | CompatibleIds | HardwareId, // 0x0000001F
  InstallState = 34, // 0x00000022
  LocationPaths = InstallState | HardwareId, // 0x00000023
}
