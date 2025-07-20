// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.Transfer.MonoUsbControlSetupHandle
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Main;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace MonoLibUsb.Transfer;

public class MonoUsbControlSetupHandle : SafeContextHandle
{
  private MonoUsbControlSetup mSetupPacket;

  public MonoUsbControlSetupHandle(
    byte requestType,
    byte request,
    short value,
    short index,
    object data,
    int length)
    : this(requestType, request, value, index, (short) (ushort) length)
  {
    if (data == null)
      return;
    this.mSetupPacket.SetData(data, 0, length);
  }

  public MonoUsbControlSetupHandle(
    byte requestType,
    byte request,
    short value,
    short index,
    short length)
    : base(IntPtr.Zero, true)
  {
    ushort num1 = (ushort) length;
    int cb = num1 <= (ushort) 0 ? MonoUsbControlSetup.SETUP_PACKET_SIZE : MonoUsbControlSetup.SETUP_PACKET_SIZE + (int) num1 + (IntPtr.Size - (int) num1 % IntPtr.Size);
    IntPtr num2 = Marshal.AllocHGlobal(cb);
    if (num2 == IntPtr.Zero)
      throw new OutOfMemoryException($"Marshal.AllocHGlobal failed allocating {cb} bytes");
    this.SetHandle(num2);
    this.mSetupPacket = new MonoUsbControlSetup(num2);
    this.mSetupPacket.RequestType = requestType;
    this.mSetupPacket.Request = request;
    this.mSetupPacket.Value = value;
    this.mSetupPacket.Index = index;
    this.mSetupPacket.Length = (short) num1;
  }

  public MonoUsbControlSetup ControlSetup => this.mSetupPacket;

  protected override bool ReleaseHandle()
  {
    if (!this.IsInvalid)
    {
      Marshal.FreeHGlobal(this.handle);
      this.SetHandleAsInvalid();
    }
    return true;
  }
}
