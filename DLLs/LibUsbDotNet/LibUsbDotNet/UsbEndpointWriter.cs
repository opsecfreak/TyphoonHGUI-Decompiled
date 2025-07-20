// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.UsbEndpointWriter
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Internal;
using LibUsbDotNet.Main;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet;

public class UsbEndpointWriter : UsbEndpointBase
{
  internal UsbEndpointWriter(
    UsbDevice usbDevice,
    WriteEndpointID writeEndpointID,
    EndpointType endpointType)
    : base(usbDevice, (byte) writeEndpointID, endpointType)
  {
  }

  public virtual ErrorCode Write(byte[] buffer, int timeout, out int transferLength)
  {
    return this.Write(buffer, 0, buffer.Length, timeout, out transferLength);
  }

  public virtual ErrorCode Write(
    IntPtr pBuffer,
    int offset,
    int count,
    int timeout,
    out int transferLength)
  {
    return this.Transfer(pBuffer, offset, count, timeout, out transferLength);
  }

  public virtual ErrorCode Write(
    byte[] buffer,
    int offset,
    int count,
    int timeout,
    out int transferLength)
  {
    return this.Transfer((object) buffer, offset, count, timeout, out transferLength);
  }

  public virtual ErrorCode Write(
    object buffer,
    int offset,
    int count,
    int timeout,
    out int transferLength)
  {
    return this.Transfer(buffer, offset, count, timeout, out transferLength);
  }

  public virtual ErrorCode Write(object buffer, int timeout, out int transferLength)
  {
    return this.Write(buffer, 0, Marshal.SizeOf(buffer), timeout, out transferLength);
  }

  internal override UsbTransfer CreateTransferContext()
  {
    return (UsbTransfer) new OverlappedTransferContext((UsbEndpointBase) this);
  }
}
