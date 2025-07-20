// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Internal.UsbApiBase
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Main;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.Internal;

internal abstract class UsbApiBase
{
  public abstract bool AbortPipe(SafeHandle interfaceHandle, byte pipeID);

  public abstract bool ControlTransfer(
    SafeHandle interfaceHandle,
    UsbSetupPacket setupPacket,
    IntPtr buffer,
    int bufferLength,
    out int lengthTransferred);

  public abstract bool FlushPipe(SafeHandle interfaceHandle, byte pipeID);

  public abstract bool GetDescriptor(
    SafeHandle interfaceHandle,
    byte descriptorType,
    byte index,
    ushort languageID,
    IntPtr buffer,
    int bufferLength,
    out int lengthTransferred);

  public abstract bool GetOverlappedResult(
    SafeHandle interfaceHandle,
    IntPtr pOverlapped,
    out int numberOfBytesTransferred,
    bool wait);

  public abstract bool ReadPipe(
    UsbEndpointBase endPointBase,
    IntPtr pBuffer,
    int bufferLength,
    out int lengthTransferred,
    int isoPacketSize,
    IntPtr pOverlapped);

  public abstract bool ResetPipe(SafeHandle interfaceHandle, byte pipeID);

  public abstract bool WritePipe(
    UsbEndpointBase endPointBase,
    IntPtr pBuffer,
    int bufferLength,
    out int lengthTransferred,
    int isoPacketSize,
    IntPtr pOverlapped);
}
