// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.UnixNativeTimeval
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Main;
using System;

#nullable disable
namespace MonoLibUsb;

public struct UnixNativeTimeval(long tvSec, long tvUsec)
{
  private IntPtr mTvSecInternal = new IntPtr(tvSec);
  private IntPtr mTvUSecInternal = new IntPtr(tvUsec);

  public static UnixNativeTimeval WindowsDefault => new UnixNativeTimeval(2L, 0L);

  public static UnixNativeTimeval LinuxDefault => new UnixNativeTimeval(2L, 0L);

  public static UnixNativeTimeval Default
  {
    get => !Helper.IsLinux ? UnixNativeTimeval.WindowsDefault : UnixNativeTimeval.LinuxDefault;
  }

  public long tv_sec
  {
    get => this.mTvSecInternal.ToInt64();
    set => this.mTvSecInternal = new IntPtr(value);
  }

  public long tv_usec
  {
    get => this.mTvUSecInternal.ToInt64();
    set => this.mTvUSecInternal = new IntPtr(value);
  }
}
