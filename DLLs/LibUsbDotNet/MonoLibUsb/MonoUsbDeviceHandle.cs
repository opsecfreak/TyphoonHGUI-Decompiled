// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.MonoUsbDeviceHandle
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Main;
using MonoLibUsb.Profile;
using System;

#nullable disable
namespace MonoLibUsb;

public class MonoUsbDeviceHandle : SafeContextHandle
{
  private static object handleLOCK = new object();
  private static MonoUsbError mLastReturnCode;
  private static string mLastReturnString = string.Empty;

  public static string LastErrorString
  {
    get
    {
      lock (MonoUsbDeviceHandle.handleLOCK)
        return MonoUsbDeviceHandle.mLastReturnString;
    }
  }

  public static MonoUsbError LastErrorCode
  {
    get
    {
      lock (MonoUsbDeviceHandle.handleLOCK)
        return MonoUsbDeviceHandle.mLastReturnCode;
    }
  }

  public MonoUsbDeviceHandle(MonoUsbProfileHandle profileHandle)
    : base(IntPtr.Zero)
  {
    IntPtr zero = IntPtr.Zero;
    int num = MonoUsbApi.Open(profileHandle, ref zero);
    if (num < 0 || zero == IntPtr.Zero)
    {
      lock (MonoUsbDeviceHandle.handleLOCK)
      {
        MonoUsbDeviceHandle.mLastReturnCode = (MonoUsbError) num;
        MonoUsbDeviceHandle.mLastReturnString = MonoUsbApi.StrError(MonoUsbDeviceHandle.mLastReturnCode);
      }
      this.SetHandleAsInvalid();
    }
    else
      this.SetHandle(zero);
  }

  internal MonoUsbDeviceHandle(IntPtr pDeviceHandle)
    : base(pDeviceHandle)
  {
  }

  protected override bool ReleaseHandle()
  {
    if (!this.IsInvalid)
    {
      MonoUsbApi.Close(this.handle);
      this.SetHandleAsInvalid();
    }
    return true;
  }

  public new void Close() => base.Close();
}
