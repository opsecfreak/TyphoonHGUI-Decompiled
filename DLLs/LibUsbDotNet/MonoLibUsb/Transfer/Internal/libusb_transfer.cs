// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.Transfer.Internal.libusb_transfer
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Main;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace MonoLibUsb.Transfer.Internal;

[StructLayout(LayoutKind.Sequential)]
internal class libusb_transfer
{
  private IntPtr deviceHandle;
  private MonoUsbTransferFlags flags;
  private byte endpoint;
  private EndpointType type;
  private uint timeout;
  private MonoUsbTansferStatus status;
  private int length;
  private int actual_length;
  private IntPtr pCallbackFn;
  private IntPtr pUserData;
  private IntPtr pBuffer;
  private int num_iso_packets;
  private IntPtr iso_packets;

  private libusb_transfer()
  {
  }
}
