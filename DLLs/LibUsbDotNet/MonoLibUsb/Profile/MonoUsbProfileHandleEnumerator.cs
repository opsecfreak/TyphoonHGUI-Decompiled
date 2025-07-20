// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.Profile.MonoUsbProfileHandleEnumerator
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace MonoLibUsb.Profile;

internal class MonoUsbProfileHandleEnumerator : 
  IEnumerator<MonoUsbProfileHandle>,
  IDisposable,
  IEnumerator
{
  private readonly MonoUsbProfileListHandle mProfileListHandle;
  private MonoUsbProfileHandle mCurrentProfile;
  private int mNextDeviceProfilePos;

  internal MonoUsbProfileHandleEnumerator(MonoUsbProfileListHandle profileListHandle)
  {
    this.mProfileListHandle = profileListHandle;
    this.Reset();
  }

  public void Dispose() => this.Reset();

  public bool MoveNext()
  {
    IntPtr pProfileHandle = Marshal.ReadIntPtr(new IntPtr(this.mProfileListHandle.DangerousGetHandle().ToInt64() + (long) (this.mNextDeviceProfilePos * IntPtr.Size)));
    if (pProfileHandle != IntPtr.Zero)
    {
      this.mCurrentProfile = new MonoUsbProfileHandle(pProfileHandle);
      ++this.mNextDeviceProfilePos;
      return true;
    }
    this.mCurrentProfile = (MonoUsbProfileHandle) null;
    return false;
  }

  public void Reset()
  {
    this.mNextDeviceProfilePos = 0;
    this.mCurrentProfile = (MonoUsbProfileHandle) null;
  }

  public MonoUsbProfileHandle Current => this.mCurrentProfile;

  object IEnumerator.Current => (object) this.Current;
}
