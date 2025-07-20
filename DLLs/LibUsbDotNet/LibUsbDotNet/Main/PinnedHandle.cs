// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Main.PinnedHandle
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.Main;

public class PinnedHandle : IDisposable
{
  private readonly IntPtr mPtr = IntPtr.Zero;
  private bool mFreeGcBuffer;
  private GCHandle mGcObject;

  public PinnedHandle(object objectToPin)
  {
    if (objectToPin == null)
      return;
    this.mFreeGcBuffer = PinnedHandle.GetPinnedObjectHandle(objectToPin, out this.mGcObject);
    this.mPtr = this.mGcObject.AddrOfPinnedObject();
  }

  public IntPtr Handle => this.mPtr;

  public void Dispose()
  {
    if (this.mFreeGcBuffer && this.mGcObject.IsAllocated)
    {
      this.mFreeGcBuffer = false;
      this.mGcObject.Free();
    }
    GC.SuppressFinalize((object) this);
  }

  ~PinnedHandle() => this.Dispose();

  private static bool GetPinnedObjectHandle(object objectToPin, out GCHandle pinnedObject)
  {
    bool pinnedObjectHandle = false;
    if (objectToPin is GCHandle gcHandle)
    {
      pinnedObject = gcHandle;
    }
    else
    {
      pinnedObject = GCHandle.Alloc(objectToPin, GCHandleType.Pinned);
      pinnedObjectHandle = true;
    }
    return pinnedObjectHandle;
  }
}
