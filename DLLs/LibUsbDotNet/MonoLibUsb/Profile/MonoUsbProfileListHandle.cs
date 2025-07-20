// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.Profile.MonoUsbProfileListHandle
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Main;
using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace MonoLibUsb.Profile;

public class MonoUsbProfileListHandle : 
  SafeContextHandle,
  IEnumerable<MonoUsbProfileHandle>,
  IEnumerable
{
  private MonoUsbProfileListHandle()
    : base(IntPtr.Zero)
  {
  }

  internal MonoUsbProfileListHandle(IntPtr pHandleToOwn)
    : base(pHandleToOwn)
  {
  }

  public IEnumerator<MonoUsbProfileHandle> GetEnumerator()
  {
    return (IEnumerator<MonoUsbProfileHandle>) new MonoUsbProfileHandleEnumerator(this);
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

  protected override bool ReleaseHandle()
  {
    if (!this.IsInvalid)
    {
      MonoUsbApi.FreeDeviceList(this.handle, 1);
      this.SetHandleAsInvalid();
    }
    return true;
  }
}
