// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.Transfer.MonoUsbControlSetup
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Main;
using MonoLibUsb.Transfer.Internal;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace MonoLibUsb.Transfer;

[StructLayout(LayoutKind.Sequential)]
public class MonoUsbControlSetup
{
  public static int SETUP_PACKET_SIZE = Marshal.SizeOf(typeof (libusb_control_setup));
  private static readonly int OfsRequestType = Marshal.OffsetOf(typeof (libusb_control_setup), "bmRequestType").ToInt32();
  private static readonly int OfsRequest = Marshal.OffsetOf(typeof (libusb_control_setup), "bRequest").ToInt32();
  private static readonly int OfsValue = Marshal.OffsetOf(typeof (libusb_control_setup), "wValue").ToInt32();
  private static readonly int OfsIndex = Marshal.OffsetOf(typeof (libusb_control_setup), "wIndex").ToInt32();
  private static readonly int OfsLength = Marshal.OffsetOf(typeof (libusb_control_setup), "wLength").ToInt32();
  private static readonly int OfsPtrData = MonoUsbControlSetup.SETUP_PACKET_SIZE;
  private IntPtr handle;

  public MonoUsbControlSetup(IntPtr pControlSetup) => this.handle = pControlSetup;

  public byte RequestType
  {
    get => Marshal.ReadByte(this.handle, MonoUsbControlSetup.OfsRequestType);
    set => Marshal.WriteByte(this.handle, MonoUsbControlSetup.OfsRequestType, value);
  }

  public byte Request
  {
    get => Marshal.ReadByte(this.handle, MonoUsbControlSetup.OfsRequest);
    set => Marshal.WriteByte(this.handle, MonoUsbControlSetup.OfsRequest, value);
  }

  public short Value
  {
    get => Helper.HostEndianToLE16(Marshal.ReadInt16(this.handle, MonoUsbControlSetup.OfsValue));
    set
    {
      Marshal.WriteInt16(this.handle, MonoUsbControlSetup.OfsValue, Helper.HostEndianToLE16(value));
    }
  }

  public short Index
  {
    get => Helper.HostEndianToLE16(Marshal.ReadInt16(this.handle, MonoUsbControlSetup.OfsIndex));
    set
    {
      Marshal.WriteInt16(this.handle, MonoUsbControlSetup.OfsIndex, Helper.HostEndianToLE16(value));
    }
  }

  public short Length
  {
    get => Helper.HostEndianToLE16(Marshal.ReadInt16(this.handle, MonoUsbControlSetup.OfsLength));
    set
    {
      Marshal.WriteInt16(this.handle, MonoUsbControlSetup.OfsLength, Helper.HostEndianToLE16(value));
    }
  }

  public IntPtr PtrData
  {
    get => new IntPtr(this.handle.ToInt64() + (long) MonoUsbControlSetup.OfsPtrData);
  }

  public void SetData(object data, int offset, int length)
  {
    PinnedHandle pinnedHandle = new PinnedHandle(data);
    byte[] numArray = new byte[length];
    Marshal.Copy(pinnedHandle.Handle, numArray, offset, length);
    pinnedHandle.Dispose();
    Marshal.Copy(numArray, 0, this.PtrData, length);
  }

  public byte[] GetData(int transferLength)
  {
    byte[] destination = new byte[transferLength];
    Marshal.Copy(this.PtrData, destination, 0, destination.Length);
    return destination;
  }
}
