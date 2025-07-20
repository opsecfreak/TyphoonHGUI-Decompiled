// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Internal.Kernel32
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using Microsoft.Win32.SafeHandles;
using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

#nullable disable
namespace LibUsbDotNet.Internal;

[SuppressUnmanagedCodeSecurity]
internal static class Kernel32
{
  private const int FORMAT_MESSAGE_FROM_SYSTEM = 4096 /*0x1000*/;
  private static readonly StringBuilder m_sbSysMsg = new StringBuilder(1024 /*0x0400*/);

  [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  public static extern SafeFileHandle CreateFile(
    string fileName,
    [MarshalAs(UnmanagedType.U4)] NativeFileAccess fileAccess,
    [MarshalAs(UnmanagedType.U4)] NativeFileShare fileShare,
    IntPtr securityAttributes,
    [MarshalAs(UnmanagedType.U4)] NativeFileMode creationDisposition,
    NativeFileFlag flags,
    IntPtr template);

  [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  private static extern int FormatMessage(
    int dwFlags,
    IntPtr lpSource,
    int dwMessageId,
    int dwLanguageId,
    [Out] StringBuilder lpBuffer,
    int nSize,
    IntPtr lpArguments);

  [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
  public static extern bool GetOverlappedResult(
    SafeHandle hDevice,
    IntPtr lpOverlapped,
    out int lpNumberOfBytesTransferred,
    bool bWait);

  public static string FormatSystemMessage(int dwMessageId)
  {
    lock (Kernel32.m_sbSysMsg)
    {
      int length = Kernel32.FormatMessage(4096 /*0x1000*/, IntPtr.Zero, dwMessageId, CultureInfo.CurrentCulture.LCID, Kernel32.m_sbSysMsg, Kernel32.m_sbSysMsg.Capacity - 1, IntPtr.Zero);
      return length > 0 ? Kernel32.m_sbSysMsg.ToString(0, length) : (string) null;
    }
  }

  [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
  public static extern bool DeviceIoControl(
    SafeHandle hDevice,
    int IoControlCode,
    [MarshalAs(UnmanagedType.AsAny), In] object InBuffer,
    int nInBufferSize,
    IntPtr OutBuffer,
    int nOutBufferSize,
    out int pBytesReturned,
    IntPtr pOverlapped);

  [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
  public static extern bool DeviceIoControl(
    SafeHandle hDevice,
    int IoControlCode,
    [MarshalAs(UnmanagedType.AsAny), In] object InBuffer,
    int nInBufferSize,
    [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6), Out] byte[] OutBuffer,
    int nOutBufferSize,
    out int pBytesReturned,
    IntPtr Overlapped);

  [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
  public static extern bool DeviceIoControl(
    SafeHandle hDevice,
    int IoControlCode,
    IntPtr InBuffer,
    int nInBufferSize,
    IntPtr OutBuffer,
    int nOutBufferSize,
    out int pBytesReturned,
    IntPtr Overlapped);

  [DllImport("kernel32.dll", EntryPoint = "DeviceIoControl", CharSet = CharSet.Ansi, SetLastError = true)]
  public static extern bool DeviceIoControlAsObject(
    SafeHandle hDevice,
    int IoControlCode,
    [MarshalAs(UnmanagedType.AsAny), In] object InBuffer,
    int nInBufferSize,
    IntPtr OutBuffer,
    int nOutBufferSize,
    ref int pBytesReturned,
    IntPtr Overlapped);
}
