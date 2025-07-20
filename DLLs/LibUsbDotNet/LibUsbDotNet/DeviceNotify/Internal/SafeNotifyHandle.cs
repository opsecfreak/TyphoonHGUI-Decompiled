// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.DeviceNotify.Internal.SafeNotifyHandle
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using Microsoft.Win32.SafeHandles;
using System;

#nullable disable
namespace LibUsbDotNet.DeviceNotify.Internal;

internal class SafeNotifyHandle : SafeHandleZeroOrMinusOneIsInvalid
{
  public SafeNotifyHandle()
    : base(true)
  {
  }

  public SafeNotifyHandle(IntPtr pHandle)
    : base(true)
  {
    this.SetHandle(pHandle);
  }

  protected override bool ReleaseHandle()
  {
    if (this.handle != IntPtr.Zero)
    {
      WindowsDeviceNotifier.UnregisterDeviceNotification(this.handle);
      this.handle = IntPtr.Zero;
    }
    return true;
  }
}
