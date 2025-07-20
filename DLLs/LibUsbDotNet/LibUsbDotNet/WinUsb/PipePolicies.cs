// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.WinUsb.PipePolicies
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Main;
using LibUsbDotNet.WinUsb.Internal;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.WinUsb;

public class PipePolicies
{
  private const int MAX_SIZE = 4;
  private readonly byte mEpNum;
  private readonly SafeHandle mUsbHandle;
  private IntPtr mBufferPtr = IntPtr.Zero;

  internal PipePolicies(SafeHandle usbHandle, byte epNum)
  {
    this.mBufferPtr = Marshal.AllocCoTaskMem(4);
    this.mEpNum = epNum;
    this.mUsbHandle = usbHandle;
  }

  public bool AllowPartialReads
  {
    get
    {
      int valueLength = 1;
      Marshal.WriteByte(this.mBufferPtr, (byte) 0);
      return this.GetPipePolicy(PipePolicyType.AllowPartialReads, ref valueLength, this.mBufferPtr) && Marshal.ReadByte(this.mBufferPtr) != (byte) 0;
    }
    set
    {
      int valueLength = 1;
      Marshal.WriteByte(this.mBufferPtr, value ? (byte) 1 : (byte) 0);
      this.SetPipePolicy(PipePolicyType.AllowPartialReads, valueLength, this.mBufferPtr);
    }
  }

  public bool ShortPacketTerminate
  {
    get
    {
      int valueLength = 1;
      Marshal.WriteByte(this.mBufferPtr, (byte) 0);
      return this.GetPipePolicy(PipePolicyType.ShortPacketTerminate, ref valueLength, this.mBufferPtr) && Marshal.ReadByte(this.mBufferPtr) != (byte) 0;
    }
    set
    {
      int valueLength = 1;
      Marshal.WriteByte(this.mBufferPtr, value ? (byte) 1 : (byte) 0);
      this.SetPipePolicy(PipePolicyType.ShortPacketTerminate, valueLength, this.mBufferPtr);
    }
  }

  public bool AutoClearStall
  {
    get
    {
      int valueLength = 1;
      Marshal.WriteByte(this.mBufferPtr, (byte) 0);
      return this.GetPipePolicy(PipePolicyType.AutoClearStall, ref valueLength, this.mBufferPtr) && Marshal.ReadByte(this.mBufferPtr) != (byte) 0;
    }
    set
    {
      int valueLength = 1;
      Marshal.WriteByte(this.mBufferPtr, value ? (byte) 1 : (byte) 0);
      this.SetPipePolicy(PipePolicyType.AutoClearStall, valueLength, this.mBufferPtr);
    }
  }

  public bool AutoFlush
  {
    get
    {
      int valueLength = 1;
      Marshal.WriteByte(this.mBufferPtr, (byte) 0);
      return this.GetPipePolicy(PipePolicyType.AutoFlush, ref valueLength, this.mBufferPtr) && Marshal.ReadByte(this.mBufferPtr) != (byte) 0;
    }
    set
    {
      int valueLength = 1;
      Marshal.WriteByte(this.mBufferPtr, value ? (byte) 1 : (byte) 0);
      this.SetPipePolicy(PipePolicyType.AutoFlush, valueLength, this.mBufferPtr);
    }
  }

  public bool IgnoreShortPackets
  {
    get
    {
      int valueLength = 1;
      Marshal.WriteByte(this.mBufferPtr, (byte) 0);
      return this.GetPipePolicy(PipePolicyType.IgnoreShortPackets, ref valueLength, this.mBufferPtr) && Marshal.ReadByte(this.mBufferPtr) != (byte) 0;
    }
    set
    {
      int valueLength = 1;
      Marshal.WriteByte(this.mBufferPtr, value ? (byte) 1 : (byte) 0);
      this.SetPipePolicy(PipePolicyType.IgnoreShortPackets, valueLength, this.mBufferPtr);
    }
  }

  public bool RawIo
  {
    get
    {
      int valueLength = 1;
      Marshal.WriteByte(this.mBufferPtr, (byte) 0);
      return this.GetPipePolicy(PipePolicyType.RawIo, ref valueLength, this.mBufferPtr) && Marshal.ReadByte(this.mBufferPtr) != (byte) 0;
    }
    set
    {
      int valueLength = 1;
      Marshal.WriteByte(this.mBufferPtr, value ? (byte) 1 : (byte) 0);
      this.SetPipePolicy(PipePolicyType.RawIo, valueLength, this.mBufferPtr);
    }
  }

  public int PipeTransferTimeout
  {
    get
    {
      int valueLength = 4;
      Marshal.WriteInt32(this.mBufferPtr, 0);
      return this.GetPipePolicy(PipePolicyType.PipeTransferTimeout, ref valueLength, this.mBufferPtr) ? Marshal.ReadInt32(this.mBufferPtr) : -1;
    }
    set
    {
      int valueLength = 4;
      Marshal.WriteInt32(this.mBufferPtr, value);
      this.SetPipePolicy(PipePolicyType.PipeTransferTimeout, valueLength, this.mBufferPtr);
    }
  }

  public int MaxTransferSize
  {
    get
    {
      int valueLength = 4;
      Marshal.WriteInt32(this.mBufferPtr, 0);
      return this.GetPipePolicy(PipePolicyType.MaximumTransferSize, ref valueLength, this.mBufferPtr) ? Marshal.ReadInt32(this.mBufferPtr) : -1;
    }
  }

  public override string ToString()
  {
    return $"AllowPartialReads:{this.AllowPartialReads}\r\nShortPacketTerminate:{this.ShortPacketTerminate}\r\nAutoClearStall:{this.AutoClearStall}\r\nAutoFlush:{this.AutoFlush}\r\nIgnoreShortPackets:{this.IgnoreShortPackets}\r\nRawIO:{this.RawIo}\r\nPipeTransferTimeout:{this.PipeTransferTimeout}\r\nMaxTransferSize:{this.MaxTransferSize}\r\n";
  }

  internal bool GetPipePolicy(PipePolicyType policyType, ref int valueLength, IntPtr pBuffer)
  {
    int num = WinUsbAPI.WinUsb_GetPipePolicy(this.mUsbHandle, this.mEpNum, policyType, ref valueLength, pBuffer) ? 1 : 0;
    if (num != 0)
      return num != 0;
    UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (GetPipePolicy), (object) this);
    return num != 0;
  }

  internal bool SetPipePolicy(PipePolicyType policyType, int valueLength, IntPtr pBuffer)
  {
    int num = WinUsbAPI.WinUsb_SetPipePolicy(this.mUsbHandle, this.mEpNum, policyType, valueLength, pBuffer) ? 1 : 0;
    if (num != 0)
      return num != 0;
    UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (SetPipePolicy), (object) this);
    return num != 0;
  }

  ~PipePolicies()
  {
    if (this.mBufferPtr != IntPtr.Zero)
      Marshal.FreeCoTaskMem(this.mBufferPtr);
    this.mBufferPtr = IntPtr.Zero;
  }
}
