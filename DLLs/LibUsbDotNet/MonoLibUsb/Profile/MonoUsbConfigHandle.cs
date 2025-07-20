// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.Profile.MonoUsbConfigHandle
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Main;
using System;

#nullable disable
namespace MonoLibUsb.Profile;

public class MonoUsbConfigHandle : SafeContextHandle
{
  private MonoUsbConfigHandle()
    : base(IntPtr.Zero, true)
  {
  }

  protected override bool ReleaseHandle()
  {
    if (!this.IsInvalid)
    {
      MonoUsbApi.FreeConfigDescriptor(this.handle);
      this.SetHandleAsInvalid();
    }
    return true;
  }
}
