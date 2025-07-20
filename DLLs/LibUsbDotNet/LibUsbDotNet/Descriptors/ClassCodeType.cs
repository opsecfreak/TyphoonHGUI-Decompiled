// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Descriptors.ClassCodeType
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System;

#nullable disable
namespace LibUsbDotNet.Descriptors;

[Flags]
public enum ClassCodeType : byte
{
  PerInterface = 0,
  Audio = 1,
  Comm = 2,
  Hid = Comm | Audio, // 0x03
  Printer = 7,
  Ptp = 6,
  MassStorage = 8,
  Hub = MassStorage | Audio, // 0x09
  Data = MassStorage | Comm, // 0x0A
  VendorSpec = 255, // 0xFF
}
