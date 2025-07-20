// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Main.UsbStandardRequest
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System;

#nullable disable
namespace LibUsbDotNet.Main;

[Flags]
public enum UsbStandardRequest : byte
{
  ClearFeature = 1,
  GetConfiguration = 8,
  GetDescriptor = 6,
  GetInterface = 10, // 0x0A
  GetStatus = 0,
  SetAddress = 5,
  SetConfiguration = GetConfiguration | ClearFeature, // 0x09
  SetDescriptor = 7,
  SetFeature = 3,
  SetInterface = SetFeature | GetConfiguration, // 0x0B
  SynchFrame = 12, // 0x0C
}
