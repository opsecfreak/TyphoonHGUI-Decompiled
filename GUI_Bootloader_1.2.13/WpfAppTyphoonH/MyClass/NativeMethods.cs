// Decompiled with JetBrains decompiler
// Type: WpfAppTyphoonH.MyClass.NativeMethods
// Assembly: WpfAppTyphoonH, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 3524D12E-4BA5-4A95-813C-BA8CEFA4F2FA
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\WpfAppTyphoonH.exe

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace WpfAppTyphoonH.MyClass;

public class NativeMethods
{
  public const long WS_CAPTION = 12582912 /*0xC00000*/;
  public const long WS_CAPTION_2 = 786432 /*0x0C0000*/;
  public const long WS_EX_LAYERED = 524288 /*0x080000*/;
  public const long WS_CHILD = 1073741824 /*0x40000000*/;
  public const long LWA_ALPHA = 2;
  public const long LWA_COLORKEY = 1;
  public const int GWL_STYLE = -16;
  public const int GWL_EXSTYLE = -20;

  [DllImport("User32.dll")]
  public static extern void SetWindowLong(IntPtr handle, int oldStyle, long newStyle);

  [DllImport("User32.dll")]
  public static extern long GetWindowLong(IntPtr handle, int style);

  [DllImport("User32.dll")]
  public static extern int SetWindowRgn(IntPtr handle, IntPtr handleRegion, bool regraw);

  [DllImport("gdi32.dll")]
  public static extern IntPtr CreateRoundRectRgn(
    int x1,
    int y1,
    int x2,
    int y2,
    int width,
    int height);

  [DllImport("User32.dll")]
  public static extern bool SetLayeredWindowAttributes(
    IntPtr handle,
    ulong colorKey,
    byte alpha,
    long flags);

  public static void SetWindowNoBorder(IntPtr hWnd)
  {
    long windowLong = NativeMethods.GetWindowLong(hWnd, -16);
    NativeMethods.SetWindowLong(hWnd, -16, windowLong & -13369345L);
  }
}
