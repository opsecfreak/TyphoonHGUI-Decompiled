// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Main.UsbRequestType
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System;

#nullable disable
namespace LibUsbDotNet.Main;

[Flags]
public enum UsbRequestType : byte
{
  TypeClass = 32, // 0x20
  TypeReserved = 96, // 0x60
  TypeStandard = 0,
  TypeVendor = 64, // 0x40
}
