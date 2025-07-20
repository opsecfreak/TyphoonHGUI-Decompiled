// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Main.UsbCtrlFlags
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System;

#nullable disable
namespace LibUsbDotNet.Main;

[Flags]
public enum UsbCtrlFlags : byte
{
  Direction_In = 128, // 0x80
  Direction_Out = 0,
  Recipient_Device = 0,
  Recipient_Endpoint = 2,
  Recipient_Interface = 1,
  Recipient_Other = Recipient_Interface | Recipient_Endpoint, // 0x03
  RequestType_Class = 32, // 0x20
  RequestType_Reserved = 96, // 0x60
  RequestType_Standard = 0,
  RequestType_Vendor = 64, // 0x40
}
