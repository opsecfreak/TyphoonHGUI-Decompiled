// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.WinUsb.PowerPolicyType
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

#nullable disable
namespace LibUsbDotNet.WinUsb;

internal enum PowerPolicyType : byte
{
  AutoSuspend = 129, // 0x81
  EnableWake = 130, // 0x82
  SuspendDelay = 131, // 0x83
}
