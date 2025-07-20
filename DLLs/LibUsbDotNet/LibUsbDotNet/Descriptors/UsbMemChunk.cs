// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Descriptors.UsbMemChunk
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.Descriptors;

internal abstract class UsbMemChunk
{
  private readonly int mMaxSize;
  private IntPtr mMemPointer = IntPtr.Zero;

  protected UsbMemChunk(int maxSize)
  {
    this.mMaxSize = maxSize;
    this.mMemPointer = Marshal.AllocHGlobal(maxSize);
  }

  public int MaxSize => this.mMaxSize;

  public IntPtr Ptr => this.mMemPointer;

  public void Free()
  {
    if (!(this.mMemPointer != IntPtr.Zero))
      return;
    Marshal.FreeHGlobal(this.mMemPointer);
    this.mMemPointer = IntPtr.Zero;
  }

  ~UsbMemChunk() => this.Free();
}
