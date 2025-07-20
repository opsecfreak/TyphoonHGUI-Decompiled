// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.DeviceNotify.EventType
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

#nullable disable
namespace LibUsbDotNet.DeviceNotify;

public enum EventType
{
  DeviceArrival = 32768, // 0x00008000
  DeviceQueryRemove = 32769, // 0x00008001
  DeviceQueryRemoveFailed = 32770, // 0x00008002
  DeviceRemovePending = 32771, // 0x00008003
  DeviceRemoveComplete = 32772, // 0x00008004
  DeviceTypeSpecific = 32773, // 0x00008005
  CustomEvent = 32774, // 0x00008006
}
