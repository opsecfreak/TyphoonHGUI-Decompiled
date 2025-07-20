// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Main.UsbEndpointBase
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Info;
using LibUsbDotNet.Internal;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.Main;

public abstract class UsbEndpointBase : IDisposable
{
  public static int MaxReadWrite = 65536 /*0x010000*/;
  internal readonly byte mEpNum;
  internal readonly UsbApiBase mUsbApi;
  private readonly UsbDevice mUsbDevice;
  private readonly SafeHandle mUsbHandle;
  private bool mIsDisposed;
  internal UsbEndpointBase.TransferDelegate mPipeTransferSubmit;
  private UsbTransfer mTransferContext;
  private UsbEndpointInfo mUsbEndpointInfo;
  private EndpointType mEndpointType;
  private UsbInterfaceInfo mUsbInterfacetInfo;

  internal UsbEndpointBase(UsbDevice usbDevice, byte epNum, EndpointType endpointType)
  {
    this.mUsbDevice = usbDevice;
    this.mUsbApi = this.mUsbDevice.mUsbApi;
    this.mUsbHandle = this.mUsbDevice.Handle;
    this.mEpNum = epNum;
    this.mEndpointType = endpointType;
    if (((int) this.mEpNum & 128 /*0x80*/) > 0)
      this.mPipeTransferSubmit = new UsbEndpointBase.TransferDelegate(this.ReadPipe);
    else
      this.mPipeTransferSubmit = new UsbEndpointBase.TransferDelegate(this.WritePipe);
  }

  internal virtual UsbEndpointBase.TransferDelegate PipeTransferSubmit => this.mPipeTransferSubmit;

  internal UsbTransfer TransferContext
  {
    get
    {
      if (this.mTransferContext == null)
        this.mTransferContext = this.CreateTransferContext();
      return this.mTransferContext;
    }
  }

  public bool IsDisposed => this.mIsDisposed;

  public UsbDevice Device => this.mUsbDevice;

  internal SafeHandle Handle => this.mUsbHandle;

  public byte EpNum => this.mEpNum;

  public EndpointType Type => this.mEndpointType;

  public UsbEndpointInfo EndpointInfo
  {
    get
    {
      return this.mUsbEndpointInfo == null && !UsbEndpointBase.LookupEndpointInfo(this.Device.Configs[0], this.mEpNum, out this.mUsbInterfacetInfo, out this.mUsbEndpointInfo) ? (UsbEndpointInfo) null : this.mUsbEndpointInfo;
    }
  }

  public virtual void Dispose() => this.DisposeAndRemoveFromList();

  internal abstract UsbTransfer CreateTransferContext();

  public virtual bool Abort()
  {
    if (this.mIsDisposed)
      throw new ObjectDisposedException(this.GetType().Name);
    return this.TransferContext.Cancel() == ErrorCode.None;
  }

  public virtual bool Flush()
  {
    if (this.mIsDisposed)
      throw new ObjectDisposedException(this.GetType().Name);
    int num = this.mUsbApi.FlushPipe(this.mUsbHandle, this.EpNum) ? 1 : 0;
    if (num != 0)
      return num != 0;
    UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), "FlushPipe", (object) this);
    return num != 0;
  }

  public virtual bool Reset()
  {
    if (this.mIsDisposed)
      throw new ObjectDisposedException(this.GetType().Name);
    int num = this.mUsbApi.ResetPipe(this.mUsbHandle, this.EpNum) ? 1 : 0;
    if (num != 0)
      return num != 0;
    UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), "ResetPipe", (object) this);
    return num != 0;
  }

  public virtual ErrorCode Transfer(
    IntPtr buffer,
    int offset,
    int length,
    int timeout,
    out int transferLength)
  {
    return UsbTransfer.SyncTransfer(this.TransferContext, buffer, offset, length, timeout, out transferLength);
  }

  public virtual ErrorCode SubmitAsyncTransfer(
    object buffer,
    int offset,
    int length,
    int timeout,
    out UsbTransfer transferContext)
  {
    transferContext = this.CreateTransferContext();
    transferContext.Fill(buffer, offset, length, timeout);
    ErrorCode errorCode = transferContext.Submit();
    if (errorCode != ErrorCode.None)
    {
      transferContext.Dispose();
      transferContext = (UsbTransfer) null;
      UsbError.Error(errorCode, 0, "SubmitAsyncTransfer Failed", (object) this);
    }
    return errorCode;
  }

  public virtual ErrorCode SubmitAsyncTransfer(
    IntPtr buffer,
    int offset,
    int length,
    int timeout,
    out UsbTransfer transferContext)
  {
    transferContext = this.CreateTransferContext();
    transferContext.Fill(buffer, offset, length, timeout);
    ErrorCode errorCode = transferContext.Submit();
    if (errorCode != ErrorCode.None)
    {
      transferContext.Dispose();
      transferContext = (UsbTransfer) null;
      UsbError.Error(errorCode, 0, "SubmitAsyncTransfer Failed", (object) this);
    }
    return errorCode;
  }

  public UsbTransfer NewAsyncTransfer() => this.CreateTransferContext();

  public static bool LookupEndpointInfo(
    UsbConfigInfo currentConfigInfo,
    byte endpointAddress,
    out UsbInterfaceInfo usbInterfaceInfo,
    out UsbEndpointInfo usbEndpointInfo)
  {
    bool flag = false;
    usbInterfaceInfo = (UsbInterfaceInfo) null;
    usbEndpointInfo = (UsbEndpointInfo) null;
    foreach (UsbInterfaceInfo interfaceInfo in currentConfigInfo.InterfaceInfoList)
    {
      foreach (UsbEndpointInfo endpointInfo in interfaceInfo.EndpointInfoList)
      {
        if (((int) endpointAddress & 15) == 0)
        {
          if (((int) endpointAddress & 128 /*0x80*/) == 0 && ((int) endpointInfo.Descriptor.EndpointID & 128 /*0x80*/) == 0)
            flag = true;
          if (((int) endpointAddress & 128 /*0x80*/) != 0 && ((int) endpointInfo.Descriptor.EndpointID & 128 /*0x80*/) != 0)
            flag = true;
        }
        else if ((int) endpointInfo.Descriptor.EndpointID == (int) endpointAddress)
          flag = true;
        if (flag)
        {
          usbInterfaceInfo = interfaceInfo;
          usbEndpointInfo = endpointInfo;
          return true;
        }
      }
    }
    return false;
  }

  public ErrorCode Transfer(
    object buffer,
    int offset,
    int length,
    int timeout,
    out int transferLength)
  {
    PinnedHandle pinnedHandle = new PinnedHandle(buffer);
    int num = (int) this.Transfer(pinnedHandle.Handle, offset, length, timeout, out transferLength);
    pinnedHandle.Dispose();
    return (ErrorCode) num;
  }

  private void DisposeAndRemoveFromList()
  {
    if (!this.mIsDisposed)
    {
      if (this is UsbEndpointReader usbEndpointReader && usbEndpointReader.DataReceivedEnabled)
        usbEndpointReader.DataReceivedEnabled = false;
      this.Abort();
      this.mUsbDevice.ActiveEndpoints.RemoveFromList(this);
    }
    this.mIsDisposed = true;
  }

  private int ReadPipe(
    IntPtr pBuffer,
    int bufferLength,
    out int lengthTransferred,
    int isoPacketSize,
    IntPtr pOverlapped)
  {
    return !this.mUsbApi.ReadPipe(this, pBuffer, bufferLength, out lengthTransferred, isoPacketSize, pOverlapped) ? Marshal.GetLastWin32Error() : 0;
  }

  private int WritePipe(
    IntPtr pBuffer,
    int bufferLength,
    out int lengthTransferred,
    int isoPacketSize,
    IntPtr pOverlapped)
  {
    return !this.mUsbApi.WritePipe(this, pBuffer, bufferLength, out lengthTransferred, isoPacketSize, pOverlapped) ? Marshal.GetLastWin32Error() : 0;
  }

  internal delegate int TransferDelegate(
    IntPtr pBuffer,
    int bufferLength,
    out int lengthTransferred,
    int isoPacketSize,
    IntPtr pOverlapped);
}
