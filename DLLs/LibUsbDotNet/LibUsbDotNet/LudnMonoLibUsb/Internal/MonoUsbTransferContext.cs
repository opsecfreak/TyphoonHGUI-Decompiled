// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.LudnMonoLibUsb.Internal.MonoUsbTransferContext
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Main;
using MonoLibUsb;
using MonoLibUsb.Transfer;
using System;
using System.Runtime.InteropServices;
using System.Threading;

#nullable disable
namespace LibUsbDotNet.LudnMonoLibUsb.Internal;

internal class MonoUsbTransferContext(UsbEndpointBase endpointBase) : UsbTransfer(endpointBase), IDisposable
{
  private bool mOwnsTransfer;
  private static readonly MonoUsbTransferDelegate mMonoUsbTransferCallbackDelegate = new MonoUsbTransferDelegate(MonoUsbTransferContext.TransferCallback);
  private GCHandle mCompleteEventHandle;
  private MonoUsbTransfer mTransfer;

  public new void Dispose() => this.freeTransfer();

  private void allocTransfer(
    UsbEndpointBase endpointBase,
    bool ownsTransfer,
    int isoPacketSize,
    int count)
  {
    int numIsoPackets = 0;
    if (isoPacketSize > 0)
      numIsoPackets = count / isoPacketSize;
    this.freeTransfer();
    this.mTransfer = MonoUsbTransfer.Alloc(numIsoPackets);
    this.mOwnsTransfer = ownsTransfer;
    this.mTransfer.Type = endpointBase.Type;
    this.mTransfer.Endpoint = endpointBase.EpNum;
    this.mTransfer.NumIsoPackets = numIsoPackets;
    if (!this.mCompleteEventHandle.IsAllocated)
      this.mCompleteEventHandle = GCHandle.Alloc((object) this.mTransferCompleteEvent);
    this.mTransfer.PtrUserData = GCHandle.ToIntPtr(this.mCompleteEventHandle);
    if (numIsoPackets <= 0)
      return;
    this.mTransfer.SetIsoPacketLengths(isoPacketSize);
  }

  private void freeTransfer()
  {
    if (this.mTransfer.IsInvalid || !this.mOwnsTransfer)
      return;
    this.mTransferCancelEvent.Set();
    this.mTransferCompleteEvent.WaitOne(200, false);
    this.mTransfer.Free();
    if (!this.mCompleteEventHandle.IsAllocated)
      return;
    this.mCompleteEventHandle.Free();
  }

  public override void Fill(IntPtr buffer, int offset, int count, int timeout)
  {
    this.allocTransfer(this.EndpointBase, true, 0, count);
    base.Fill(buffer, offset, count, timeout);
    this.mTransfer.Timeout = timeout;
    this.mTransfer.PtrDeviceHandle = this.EndpointBase.Handle.DangerousGetHandle();
    this.mTransfer.PtrCallbackFn = Marshal.GetFunctionPointerForDelegate((Delegate) MonoUsbTransferContext.mMonoUsbTransferCallbackDelegate);
    this.mTransfer.Type = this.EndpointBase.Type;
    this.mTransfer.Endpoint = this.EndpointBase.EpNum;
    this.mTransfer.ActualLength = 0;
    this.mTransfer.Status = MonoUsbTansferStatus.TransferCompleted;
    this.mTransfer.Flags = MonoUsbTransferFlags.None;
  }

  public override void Fill(IntPtr buffer, int offset, int count, int timeout, int isoPacketSize)
  {
    this.allocTransfer(this.EndpointBase, true, isoPacketSize, count);
    base.Fill(buffer, offset, count, timeout, isoPacketSize);
    this.mTransfer.Timeout = timeout;
    this.mTransfer.PtrDeviceHandle = this.EndpointBase.Handle.DangerousGetHandle();
    this.mTransfer.PtrCallbackFn = Marshal.GetFunctionPointerForDelegate((Delegate) MonoUsbTransferContext.mMonoUsbTransferCallbackDelegate);
    this.mTransfer.Type = this.EndpointBase.Type;
    this.mTransfer.Endpoint = this.EndpointBase.EpNum;
    this.mTransfer.ActualLength = 0;
    this.mTransfer.Status = MonoUsbTansferStatus.TransferCompleted;
    this.mTransfer.Flags = MonoUsbTransferFlags.None;
  }

  ~MonoUsbTransferContext() => this.Dispose();

  public override ErrorCode Submit()
  {
    if (this.mTransferCancelEvent.WaitOne(0, false))
      return ErrorCode.IoCancelled;
    if (!this.mTransferCompleteEvent.WaitOne(0, false))
      return ErrorCode.ResourceBusy;
    this.mTransfer.PtrBuffer = this.NextBufPtr;
    this.mTransfer.Length = this.RequestCount;
    this.mTransferCompleteEvent.Reset();
    int ret = (int) this.mTransfer.Submit();
    if (ret >= 0)
      return ErrorCode.None;
    this.mTransferCompleteEvent.Set();
    return UsbError.Error(ErrorCode.MonoApiError, ret, "SubmitTransfer", (object) this.EndpointBase).ErrorCode;
  }

  public override ErrorCode Wait(out int transferredCount, bool cancel)
  {
    transferredCount = 0;
    int ret1 = 0;
    switch (WaitHandle.WaitAny(new WaitHandle[2]
    {
      (WaitHandle) this.mTransferCompleteEvent,
      (WaitHandle) this.mTransferCancelEvent
    }, -1, false))
    {
      case 0:
        if (this.mTransfer.Status == MonoUsbTansferStatus.TransferCompleted)
        {
          transferredCount = this.mTransfer.ActualLength;
          return ErrorCode.None;
        }
        MonoUsbError ret2 = MonoUsbApi.MonoLibUsbErrorFromTransferStatus(this.mTransfer.Status);
        string description;
        ErrorCode errorCode1 = MonoUsbApi.ErrorCodeFromLibUsbError((int) ret2, out description);
        UsbError.Error(ErrorCode.MonoApiError, (int) ret2, "Wait:" + description, (object) this.EndpointBase);
        return errorCode1;
      case 1:
        int ret3 = (int) this.mTransfer.Cancel();
        bool flag = this.mTransferCompleteEvent.WaitOne(100, false);
        this.mTransferCompleteEvent.Set();
        if (ret3 == 0 && flag)
          return ErrorCode.IoCancelled;
        ErrorCode errorCode2 = ret3 == 0 ? ErrorCode.CancelIoFailed : ErrorCode.MonoApiError;
        UsbError.Error(errorCode2, ret3, $"Wait:Unable to cancel transfer or the transfer did not return after it was cancelled. Cancelled:{(Enum) (MonoUsbError) ret3} TransferCompleted:{flag}", (object) this.EndpointBase);
        return errorCode2;
      default:
        int num = (int) this.mTransfer.Cancel();
        ErrorCode errorCode3 = ((int) this.EndpointBase.mEpNum & 128 /*0x80*/) > 0 ? ErrorCode.ReadFailed : ErrorCode.WriteFailed;
        this.mTransferCompleteEvent.Set();
        UsbError.Error(errorCode3, ret1, string.Format("Wait:Critical timeout failure! The transfer callback function was not called within the allotted time."), (object) this.EndpointBase);
        return errorCode3;
    }
  }

  private static void TransferCallback(MonoUsbTransfer pTransfer)
  {
    (GCHandle.FromIntPtr(pTransfer.PtrUserData).Target as ManualResetEvent).Set();
  }
}
