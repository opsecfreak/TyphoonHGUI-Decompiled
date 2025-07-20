// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.MonoUsbTransferDelegate
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using MonoLibUsb.Transfer;
using System.Runtime.InteropServices;

#nullable disable
namespace MonoLibUsb;

[UnmanagedFunctionPointer((CallingConvention) 0)]
public delegate void MonoUsbTransferDelegate(MonoUsbTransfer transfer);
