// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.Transfer.MonoUsbTansferStatus
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

#nullable disable
namespace MonoLibUsb.Transfer;

public enum MonoUsbTansferStatus
{
  TransferCompleted,
  TransferError,
  TransferTimedOut,
  TransferCancelled,
  TransferStall,
  TransferNoDevice,
  TransferOverflow,
}
