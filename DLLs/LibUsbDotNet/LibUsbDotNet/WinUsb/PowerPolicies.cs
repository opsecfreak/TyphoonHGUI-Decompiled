// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.WinUsb.PowerPolicies
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.WinUsb;

public class PowerPolicies
{
  private const int MAX_SIZE = 4;
  private readonly WinUsbDevice mUsbDevice;
  private IntPtr mBufferPtr = IntPtr.Zero;

  internal PowerPolicies(WinUsbDevice usbDevice)
  {
    this.mBufferPtr = Marshal.AllocCoTaskMem(4);
    this.mUsbDevice = usbDevice;
  }

  public bool AutoSuspend
  {
    get
    {
      int valueLength = 1;
      Marshal.WriteByte(this.mBufferPtr, (byte) 0);
      return this.mUsbDevice.GetPowerPolicy(PowerPolicyType.AutoSuspend, ref valueLength, this.mBufferPtr) && Marshal.ReadByte(this.mBufferPtr) != (byte) 0;
    }
    set
    {
      int valueLength = 1;
      Marshal.WriteByte(this.mBufferPtr, value ? (byte) 1 : (byte) 0);
      this.mUsbDevice.SetPowerPolicy(PowerPolicyType.AutoSuspend, valueLength, this.mBufferPtr);
    }
  }

  public int SuspendDelay
  {
    get
    {
      int valueLength = Marshal.SizeOf(typeof (int));
      Marshal.WriteInt32(this.mBufferPtr, 0);
      return this.mUsbDevice.GetPowerPolicy(PowerPolicyType.SuspendDelay, ref valueLength, this.mBufferPtr) ? Marshal.ReadInt32(this.mBufferPtr) : -1;
    }
    set
    {
      int valueLength = Marshal.SizeOf(typeof (int));
      Marshal.WriteInt32(this.mBufferPtr, value);
      this.mUsbDevice.SetPowerPolicy(PowerPolicyType.SuspendDelay, valueLength, this.mBufferPtr);
    }
  }

  ~PowerPolicies()
  {
    if (this.mBufferPtr != IntPtr.Zero)
      Marshal.FreeCoTaskMem(this.mBufferPtr);
    this.mBufferPtr = IntPtr.Zero;
  }
}
