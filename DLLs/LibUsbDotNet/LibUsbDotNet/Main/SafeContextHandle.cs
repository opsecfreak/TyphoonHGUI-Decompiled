// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Main.SafeContextHandle
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.Main;

public abstract class SafeContextHandle : SafeHandle
{
  protected SafeContextHandle(IntPtr pHandle, bool ownsHandle)
    : base(IntPtr.Zero, ownsHandle)
  {
    this.SetHandle(pHandle);
  }

  protected SafeContextHandle(IntPtr pHandleToOwn)
    : this(pHandleToOwn, true)
  {
  }

  public override bool IsInvalid => !(this.handle != IntPtr.Zero) || this.handle == new IntPtr(-1);
}
