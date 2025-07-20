// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Internal.LibUsb.LibUsbAPI
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Main;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.Internal.LibUsb;

internal class LibUsbAPI : UsbApiBase
{
  public override bool AbortPipe(SafeHandle interfaceHandle, byte pipeID)
  {
    LibUsbRequest inBuffer = new LibUsbRequest();
    inBuffer.Endpoint.ID = (int) pipeID;
    inBuffer.Timeout = 1000;
    try
    {
      return LibUsbDriverIO.UsbIOSync(interfaceHandle, LibUsbIoCtl.ABORT_ENDPOINT, (object) inBuffer, LibUsbRequest.Size, IntPtr.Zero, 0, out int _);
    }
    catch
    {
      return false;
    }
  }

  public bool ResetDevice(SafeHandle interfaceHandle)
  {
    return LibUsbDriverIO.UsbIOSync(interfaceHandle, LibUsbIoCtl.RESET_DEVICE, (object) new LibUsbRequest()
    {
      Timeout = 1000
    }, LibUsbRequest.Size, IntPtr.Zero, 0, out int _);
  }

  public override bool ControlTransfer(
    SafeHandle interfaceHandle,
    UsbSetupPacket setupPacket,
    IntPtr buffer,
    int bufferLength,
    out int lengthTransferred)
  {
    return LibUsbDriverIO.ControlTransfer(interfaceHandle, setupPacket, buffer, bufferLength, out lengthTransferred, 1000);
  }

  public override bool FlushPipe(SafeHandle interfaceHandle, byte pipeID) => true;

  public override bool GetDescriptor(
    SafeHandle interfaceHandle,
    byte descriptorType,
    byte index,
    ushort languageID,
    IntPtr buffer,
    int bufferLength,
    out int lengthTransferred)
  {
    return LibUsbDriverIO.UsbIOSync(interfaceHandle, LibUsbIoCtl.GET_DESCRIPTOR, (object) new LibUsbRequest()
    {
      Descriptor = {
        Index = (int) index,
        LangID = (int) languageID,
        Recipient = 0,
        Type = (int) descriptorType
      }
    }, LibUsbRequest.Size, buffer, bufferLength, out lengthTransferred);
  }

  public override bool GetOverlappedResult(
    SafeHandle interfaceHandle,
    IntPtr pOverlapped,
    out int numberOfBytesTransferred,
    bool wait)
  {
    return Kernel32.GetOverlappedResult(interfaceHandle, pOverlapped, out numberOfBytesTransferred, wait);
  }

  public override bool ReadPipe(
    UsbEndpointBase endPointBase,
    IntPtr buffer,
    int bufferLength,
    out int lengthTransferred,
    int isoPacketSize,
    IntPtr pOverlapped)
  {
    LibUsbRequest InBuffer = new LibUsbRequest();
    InBuffer.Endpoint.ID = (int) endPointBase.EpNum;
    InBuffer.Endpoint.PacketSize = isoPacketSize;
    InBuffer.Timeout = 1000;
    int IoControlCode = endPointBase.Type == EndpointType.Isochronous ? LibUsbIoCtl.ISOCHRONOUS_READ : LibUsbIoCtl.INTERRUPT_OR_BULK_READ;
    return Kernel32.DeviceIoControl(endPointBase.Device.Handle, IoControlCode, (object) InBuffer, LibUsbRequest.Size, buffer, bufferLength, out lengthTransferred, pOverlapped);
  }

  public override bool ResetPipe(SafeHandle interfaceHandle, byte pipeID)
  {
    return LibUsbDriverIO.UsbIOSync(interfaceHandle, LibUsbIoCtl.RESET_ENDPOINT, (object) new LibUsbRequest()
    {
      Endpoint = {
        ID = (int) pipeID
      },
      Timeout = 1000
    }, LibUsbRequest.Size, IntPtr.Zero, 0, out int _);
  }

  public override bool WritePipe(
    UsbEndpointBase endPointBase,
    IntPtr buffer,
    int bufferLength,
    out int lengthTransferred,
    int isoPacketSize,
    IntPtr pOverlapped)
  {
    LibUsbRequest InBuffer = new LibUsbRequest();
    InBuffer.Endpoint.ID = (int) endPointBase.EpNum;
    InBuffer.Endpoint.PacketSize = isoPacketSize;
    InBuffer.Timeout = 1000;
    int IoControlCode = endPointBase.Type == EndpointType.Isochronous ? LibUsbIoCtl.ISOCHRONOUS_WRITE : LibUsbIoCtl.INTERRUPT_OR_BULK_WRITE;
    return Kernel32.DeviceIoControl(endPointBase.Handle, IoControlCode, (object) InBuffer, LibUsbRequest.Size, buffer, bufferLength, out lengthTransferred, pOverlapped);
  }
}
