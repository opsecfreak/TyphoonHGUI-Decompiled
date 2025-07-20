// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Internal.SafeOverlapped
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System;
using System.Runtime.InteropServices;
using System.Threading;

#nullable disable
namespace LibUsbDotNet.Internal;

internal class SafeOverlapped : IDisposable
{
  private static readonly int FieldOffsetEventHandle = Marshal.OffsetOf(typeof (NativeOverlapped), nameof (EventHandle)).ToInt32();
  private static readonly int FieldOffsetInternalHigh = Marshal.OffsetOf(typeof (NativeOverlapped), nameof (InternalHigh)).ToInt32();
  private static readonly int FieldOffsetInternalLow = Marshal.OffsetOf(typeof (NativeOverlapped), nameof (InternalLow)).ToInt32();
  private static readonly int FieldOffsetOffsetHigh = Marshal.OffsetOf(typeof (NativeOverlapped), nameof (OffsetHigh)).ToInt32();
  private static readonly int FieldOffsetOffsetLow = Marshal.OffsetOf(typeof (NativeOverlapped), nameof (OffsetLow)).ToInt32();
  private IntPtr mPtrOverlapped = IntPtr.Zero;

  public SafeOverlapped()
  {
    this.mPtrOverlapped = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (NativeOverlapped)));
  }

  public IntPtr InternalLow
  {
    get => Marshal.ReadIntPtr(this.mPtrOverlapped, SafeOverlapped.FieldOffsetInternalLow);
    set => Marshal.WriteIntPtr(this.mPtrOverlapped, SafeOverlapped.FieldOffsetInternalLow, value);
  }

  public IntPtr InternalHigh
  {
    get => Marshal.ReadIntPtr(this.mPtrOverlapped, SafeOverlapped.FieldOffsetInternalHigh);
    set => Marshal.WriteIntPtr(this.mPtrOverlapped, SafeOverlapped.FieldOffsetInternalHigh, value);
  }

  public int OffsetLow
  {
    get => Marshal.ReadInt32(this.mPtrOverlapped, SafeOverlapped.FieldOffsetOffsetLow);
    set => Marshal.WriteInt32(this.mPtrOverlapped, SafeOverlapped.FieldOffsetOffsetLow, value);
  }

  public int OffsetHigh
  {
    get => Marshal.ReadInt32(this.mPtrOverlapped, SafeOverlapped.FieldOffsetOffsetHigh);
    set => Marshal.WriteInt32(this.mPtrOverlapped, SafeOverlapped.FieldOffsetOffsetHigh, value);
  }

  public IntPtr EventHandle
  {
    get => Marshal.ReadIntPtr(this.mPtrOverlapped, SafeOverlapped.FieldOffsetEventHandle);
    set => Marshal.WriteIntPtr(this.mPtrOverlapped, SafeOverlapped.FieldOffsetEventHandle, value);
  }

  public IntPtr GlobalOverlapped => this.mPtrOverlapped;

  public void Dispose()
  {
    if (!(this.mPtrOverlapped != IntPtr.Zero))
      return;
    Marshal.FreeHGlobal(this.mPtrOverlapped);
    this.mPtrOverlapped = IntPtr.Zero;
  }

  public void ClearAndSetEvent(IntPtr hEventOverlapped)
  {
    this.EventHandle = hEventOverlapped;
    this.InternalLow = IntPtr.Zero;
    this.InternalHigh = IntPtr.Zero;
    this.OffsetLow = 0;
    this.OffsetHigh = 0;
  }

  ~SafeOverlapped() => this.Dispose();
}
