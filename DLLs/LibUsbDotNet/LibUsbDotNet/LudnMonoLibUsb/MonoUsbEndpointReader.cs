// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.LudnMonoLibUsb.MonoUsbEndpointReader
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.LudnMonoLibUsb.Internal;
using LibUsbDotNet.Main;
using MonoLibUsb;
using System;

#nullable disable
namespace LibUsbDotNet.LudnMonoLibUsb;

public class MonoUsbEndpointReader : UsbEndpointReader
{
  private MonoUsbTransferContext mMonoTransferContext;

  internal MonoUsbEndpointReader(
    UsbDevice usbDevice,
    int readBufferSize,
    ReadEndpointID readEndpointID,
    EndpointType endpointType)
    : base(usbDevice, readBufferSize, readEndpointID, endpointType)
  {
  }

  public override void Dispose()
  {
    base.Dispose();
    if (this.mMonoTransferContext == null)
      return;
    this.mMonoTransferContext.Dispose();
    this.mMonoTransferContext = (MonoUsbTransferContext) null;
  }

  public override bool Flush()
  {
    if (this.IsDisposed)
      throw new ObjectDisposedException(this.GetType().Name);
    return this.ReadFlush() == ErrorCode.None;
  }

  public override bool Reset()
  {
    if (this.IsDisposed)
      throw new ObjectDisposedException(this.GetType().Name);
    this.Abort();
    int ret = MonoUsbApi.ClearHalt((MonoUsbDeviceHandle) this.Device.Handle, this.EpNum);
    if (ret >= 0)
      return true;
    UsbError.Error(ErrorCode.MonoApiError, ret, "Endpoint Reset Failed", (object) this);
    return false;
  }

  internal override UsbTransfer CreateTransferContext()
  {
    return (UsbTransfer) new MonoUsbTransferContext((UsbEndpointBase) this);
  }
}
