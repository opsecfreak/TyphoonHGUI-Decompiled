// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Internal.OverlappedTransferContext
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Main;
using System.Runtime.InteropServices;
using System.Threading;

#nullable disable
namespace LibUsbDotNet.Internal;

internal class OverlappedTransferContext(UsbEndpointBase endpointBase) : UsbTransfer(endpointBase)
{
  private readonly SafeOverlapped mOverlapped = new SafeOverlapped();

  public SafeOverlapped Overlapped => this.mOverlapped;

  public override ErrorCode Submit()
  {
    ErrorCode errorCode = ErrorCode.None;
    if (this.mTransferCancelEvent.WaitOne(0, false))
      return ErrorCode.IoCancelled;
    if (!this.mTransferCompleteEvent.WaitOne(0, false))
      return ErrorCode.ResourceBusy;
    this.mHasWaitBeenCalled = false;
    this.mTransferCompleteEvent.Reset();
    this.Overlapped.ClearAndSetEvent(this.mTransferCompleteEvent.SafeWaitHandle.DangerousGetHandle());
    int lengthTransferred;
    switch (this.EndpointBase.PipeTransferSubmit(this.NextBufPtr, this.RequestCount, out lengthTransferred, this.mIsoPacketSize, this.Overlapped.GlobalOverlapped))
    {
      case 0:
      case 997:
        return errorCode;
      default:
        this.mTransferCompleteEvent.Set();
        errorCode = UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), "PipeTransferSubmit", (object) this.EndpointBase).ErrorCode;
        goto case 0;
    }
  }

  public override ErrorCode Wait(out int transferredCount, bool cancel)
  {
    if (this.mHasWaitBeenCalled)
      throw new UsbException((object) this, "Repeated calls to wait with a submit is not allowed.");
    transferredCount = 0;
    int num1 = WaitHandle.WaitAny(new WaitHandle[2]
    {
      (WaitHandle) this.mTransferCompleteEvent,
      (WaitHandle) this.mTransferCancelEvent
    }, this.mTimeout, false);
    if (num1 == 258 && !cancel)
      return ErrorCode.IoTimedOut;
    this.mHasWaitBeenCalled = true;
    if (num1 != 0)
    {
      bool flag1 = this.EndpointBase.mUsbApi.AbortPipe(this.EndpointBase.Handle, this.EndpointBase.EpNum);
      bool flag2 = this.mTransferCompleteEvent.WaitOne(100, false);
      this.mTransferCompleteEvent.Set();
      if (!flag1 || !flag2)
      {
        int num2 = flag1 ? -16367 : -16373;
        UsbError.Error((ErrorCode) num2, Marshal.GetLastWin32Error(), "Wait:AbortPipe Failed", (object) this);
        return (ErrorCode) num2;
      }
      return num1 == 258 ? ErrorCode.IoTimedOut : ErrorCode.IoCancelled;
    }
    return !this.EndpointBase.mUsbApi.GetOverlappedResult(this.EndpointBase.Handle, this.Overlapped.GlobalOverlapped, out transferredCount, true) ? UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), "GetOverlappedResult", (object) this.EndpointBase).ErrorCode : ErrorCode.None;
  }
}
