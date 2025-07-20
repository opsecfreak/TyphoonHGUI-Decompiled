// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.WinUsb.PipePolicyType
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

#nullable disable
namespace LibUsbDotNet.WinUsb;

internal enum PipePolicyType : byte
{
  ShortPacketTerminate = 1,
  AutoClearStall = 2,
  PipeTransferTimeout = 3,
  IgnoreShortPackets = 4,
  AllowPartialReads = 5,
  AutoFlush = 6,
  RawIo = 7,
  MaximumTransferSize = 8,
}
