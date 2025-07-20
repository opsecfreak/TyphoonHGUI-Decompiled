// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Internal.WinUsb.SafeWinUsbInterfaceHandle
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.WinUsb.Internal;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.Internal.WinUsb;

internal class SafeWinUsbInterfaceHandle : SafeHandle
{
  public SafeWinUsbInterfaceHandle()
    : base(IntPtr.Zero, true)
  {
  }

  public SafeWinUsbInterfaceHandle(IntPtr handle)
    : base(handle, true)
  {
  }

  public override bool IsInvalid => this.handle == IntPtr.Zero || this.handle.ToInt64() == -1L;

  protected override bool ReleaseHandle()
  {
    bool flag = true;
    if (!this.IsInvalid)
    {
      flag = WinUsbAPI.WinUsb_Free(this.handle);
      this.handle = IntPtr.Zero;
    }
    return flag;
  }
}
