// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.MonoUsbSessionHandle
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Main;
using System;

#nullable disable
namespace MonoLibUsb;

public class MonoUsbSessionHandle : SafeContextHandle
{
  private static object sessionLOCK = new object();
  private static MonoUsbError mLastReturnCode;
  private static string mLastReturnString = string.Empty;
  private static int mSessionCount;
  private static string DLL_NOT_FOUND_LINUX = "libusb-1.0 library not found.  This is often an indication that libusb-1.0 was installed to '/usr/local/lib' and mono.net is not looking for it there. To resolve this, add the path '/usr/local/lib' to '/etc/ld.so.conf' and run 'ldconfig' as root. (http://www.mono-project.com/DllNotFoundException)";
  private static string DLL_NOT_FOUND_WINDOWS = "libusb-1.0.dll not found. If this is a 64bit operating system, ensure that the 64bit version of libusb-1.0.dll exists in the '\\Windows\\System32' directory.";

  public static MonoUsbError LastErrorCode
  {
    get
    {
      lock (MonoUsbSessionHandle.sessionLOCK)
        return MonoUsbSessionHandle.mLastReturnCode;
    }
  }

  public static string LastErrorString
  {
    get
    {
      lock (MonoUsbSessionHandle.sessionLOCK)
        return MonoUsbSessionHandle.mLastReturnString;
    }
  }

  public MonoUsbSessionHandle()
    : base(IntPtr.Zero, true)
  {
    lock (MonoUsbSessionHandle.sessionLOCK)
    {
      IntPtr zero = IntPtr.Zero;
      try
      {
        MonoUsbSessionHandle.mLastReturnCode = (MonoUsbError) MonoUsbApi.Init(ref zero);
      }
      catch (DllNotFoundException ex)
      {
        if (Helper.IsLinux)
          throw new DllNotFoundException(MonoUsbSessionHandle.DLL_NOT_FOUND_LINUX, (Exception) ex);
        throw new DllNotFoundException(MonoUsbSessionHandle.DLL_NOT_FOUND_WINDOWS, (Exception) ex);
      }
      if (MonoUsbSessionHandle.mLastReturnCode < MonoUsbError.Success)
      {
        MonoUsbSessionHandle.mLastReturnString = MonoUsbApi.StrError(MonoUsbSessionHandle.mLastReturnCode);
        this.SetHandleAsInvalid();
      }
      else
      {
        this.SetHandle(zero);
        ++MonoUsbSessionHandle.mSessionCount;
      }
    }
  }

  protected override bool ReleaseHandle()
  {
    if (!this.IsInvalid)
    {
      lock (MonoUsbSessionHandle.sessionLOCK)
      {
        MonoUsbApi.Exit(this.handle);
        this.SetHandleAsInvalid();
        --MonoUsbSessionHandle.mSessionCount;
      }
    }
    return true;
  }
}
