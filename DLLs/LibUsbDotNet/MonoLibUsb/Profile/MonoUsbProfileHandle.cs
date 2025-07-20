// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.Profile.MonoUsbProfileHandle
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Main;
using System;

#nullable disable
namespace MonoLibUsb.Profile;

public class MonoUsbProfileHandle : SafeContextHandle
{
  private static int mDeviceProfileRefCount;
  private static readonly object oDeviceProfileRefLock = new object();

  public MonoUsbProfileHandle(IntPtr pProfileHandle)
    : base(pProfileHandle, true)
  {
    lock (MonoUsbProfileHandle.oDeviceProfileRefLock)
    {
      MonoUsbApi.RefDevice(pProfileHandle);
      ++MonoUsbProfileHandle.mDeviceProfileRefCount;
    }
  }

  protected override bool ReleaseHandle()
  {
    lock (MonoUsbProfileHandle.oDeviceProfileRefLock)
    {
      if (!this.IsInvalid)
      {
        MonoUsbApi.UnrefDevice(this.handle);
        --MonoUsbProfileHandle.mDeviceProfileRefCount;
        this.SetHandleAsInvalid();
      }
      return true;
    }
  }

  internal static int DeviceProfileRefCount
  {
    get
    {
      lock (MonoUsbProfileHandle.oDeviceProfileRefLock)
        return MonoUsbProfileHandle.mDeviceProfileRefCount;
    }
  }
}
