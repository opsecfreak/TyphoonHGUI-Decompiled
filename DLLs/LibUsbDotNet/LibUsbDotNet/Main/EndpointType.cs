// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Main.EndpointType
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System;

#nullable disable
namespace LibUsbDotNet.Main;

[Flags]
public enum EndpointType : byte
{
  Control = 0,
  Isochronous = 1,
  Bulk = 2,
  Interrupt = Bulk | Isochronous, // 0x03
}
