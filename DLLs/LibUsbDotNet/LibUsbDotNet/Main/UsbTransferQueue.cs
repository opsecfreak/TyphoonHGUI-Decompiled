// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Main.UsbTransferQueue
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System.Threading;

#nullable disable
namespace LibUsbDotNet.Main;

public class UsbTransferQueue
{
  public readonly UsbEndpointBase EndpointBase;
  public readonly int MaxOutstandingIO;
  public readonly int BufferSize;
  public readonly int Timeout;
  public readonly int IsoPacketSize;
  private int mOutstandingTransferCount;
  private readonly UsbTransferQueue.Handle[] mTransferHandles;
  private readonly byte[][] mBuffer;
  private int mTransferHandleNextIndex;
  private int mTransferHandleWaitIndex;

  public UsbTransferQueue(
    UsbEndpointBase endpointBase,
    int maxOutstandingIO,
    int bufferSize,
    int timeout,
    int isoPacketSize)
  {
    this.EndpointBase = endpointBase;
    this.IsoPacketSize = isoPacketSize;
    this.Timeout = timeout;
    this.BufferSize = bufferSize;
    this.MaxOutstandingIO = maxOutstandingIO;
    this.mTransferHandles = new UsbTransferQueue.Handle[maxOutstandingIO];
    this.mBuffer = new byte[maxOutstandingIO][];
    for (int index = 0; index < maxOutstandingIO; ++index)
      this.mBuffer[index] = new byte[bufferSize];
    this.IsoPacketSize = isoPacketSize > 0 ? isoPacketSize : (int) endpointBase.EndpointInfo.Descriptor.MaxPacketSize;
  }

  public byte[] this[int index] => this.mBuffer[index];

  public byte[][] Buffer => this.mBuffer;

  private static void IncWithRoll(ref int incField, int rollOverValue)
  {
    if (++incField < rollOverValue)
      return;
    incField = 0;
  }

  public ErrorCode Transfer(out UsbTransferQueue.Handle handle)
  {
    return UsbTransferQueue.transfer(this, out handle);
  }

  private static ErrorCode transfer(
    UsbTransferQueue transferParam,
    out UsbTransferQueue.Handle handle)
  {
    handle = (UsbTransferQueue.Handle) null;
    ErrorCode errorCode = ErrorCode.None;
    while (transferParam.mOutstandingTransferCount < transferParam.MaxOutstandingIO)
    {
      if (transferParam.mTransferHandles[transferParam.mTransferHandleNextIndex] == null)
      {
        handle = transferParam.mTransferHandles[transferParam.mTransferHandleNextIndex] = new UsbTransferQueue.Handle(transferParam.EndpointBase.NewAsyncTransfer(), transferParam.mBuffer[transferParam.mTransferHandleNextIndex]);
        handle.Context.Fill((object) handle.Data, 0, handle.Data.Length, transferParam.Timeout, transferParam.IsoPacketSize);
      }
      else
        handle = transferParam.mTransferHandles[transferParam.mTransferHandleNextIndex];
      handle.Transferred = 0;
      handle.Context.Reset();
      errorCode = handle.Context.Submit();
      if (errorCode == ErrorCode.None)
      {
        handle.InUse = true;
        ++transferParam.mOutstandingTransferCount;
        UsbTransferQueue.IncWithRoll(ref transferParam.mTransferHandleNextIndex, transferParam.MaxOutstandingIO);
      }
      else
        goto label_10;
    }
    if (transferParam.mOutstandingTransferCount == transferParam.MaxOutstandingIO)
    {
      handle = transferParam.mTransferHandles[transferParam.mTransferHandleWaitIndex];
      errorCode = handle.Context.Wait(out handle.Transferred, false);
      if (errorCode == ErrorCode.None)
      {
        handle.InUse = false;
        --transferParam.mOutstandingTransferCount;
        UsbTransferQueue.IncWithRoll(ref transferParam.mTransferHandleWaitIndex, transferParam.MaxOutstandingIO);
        return ErrorCode.None;
      }
    }
label_10:
    return errorCode;
  }

  public void Free() => UsbTransferQueue.free(this);

  private static void free(UsbTransferQueue transferParam)
  {
    for (int index = 0; index < transferParam.MaxOutstandingIO; ++index)
    {
      if (transferParam.mTransferHandles[index] != null)
      {
        if (transferParam.mTransferHandles[index].InUse)
        {
          if (!transferParam.mTransferHandles[index].Context.IsCompleted)
          {
            transferParam.EndpointBase.Abort();
            Thread.Sleep(1);
          }
          transferParam.mTransferHandles[index].InUse = false;
          transferParam.mTransferHandles[index].Context.Dispose();
        }
        transferParam.mTransferHandles[index] = (UsbTransferQueue.Handle) null;
      }
    }
    transferParam.mOutstandingTransferCount = 0;
    transferParam.mTransferHandleNextIndex = 0;
    transferParam.mTransferHandleWaitIndex = 0;
  }

  public class Handle
  {
    public readonly UsbTransfer Context;
    public readonly byte[] Data;
    public int Transferred;
    internal bool InUse;

    internal Handle(UsbTransfer context, byte[] data)
    {
      this.Context = context;
      this.Data = data;
    }
  }
}
