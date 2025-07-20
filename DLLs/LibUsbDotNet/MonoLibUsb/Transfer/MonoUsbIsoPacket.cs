// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.Transfer.MonoUsbIsoPacket
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using MonoLibUsb.Transfer.Internal;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace MonoLibUsb.Transfer;

[StructLayout(LayoutKind.Sequential)]
public class MonoUsbIsoPacket
{
  private static readonly int OfsActualLength = Marshal.OffsetOf(typeof (libusb_iso_packet_descriptor), "actual_length").ToInt32();
  private static readonly int OfsLength = Marshal.OffsetOf(typeof (libusb_iso_packet_descriptor), "length").ToInt32();
  private static readonly int OfsStatus = Marshal.OffsetOf(typeof (libusb_iso_packet_descriptor), "status").ToInt32();
  private IntPtr mpMonoUsbIsoPacket = IntPtr.Zero;

  public MonoUsbIsoPacket(IntPtr isoPacketPtr) => this.mpMonoUsbIsoPacket = isoPacketPtr;

  public IntPtr PtrIsoPacket => this.mpMonoUsbIsoPacket;

  public int ActualLength
  {
    get => Marshal.ReadInt32(this.mpMonoUsbIsoPacket, MonoUsbIsoPacket.OfsActualLength);
    set => Marshal.WriteInt32(this.mpMonoUsbIsoPacket, MonoUsbIsoPacket.OfsActualLength, value);
  }

  public int Length
  {
    get => Marshal.ReadInt32(this.mpMonoUsbIsoPacket, MonoUsbIsoPacket.OfsLength);
    set => Marshal.WriteInt32(this.mpMonoUsbIsoPacket, MonoUsbIsoPacket.OfsLength, value);
  }

  public MonoUsbTansferStatus Status
  {
    get
    {
      return (MonoUsbTansferStatus) Marshal.ReadInt32(this.mpMonoUsbIsoPacket, MonoUsbIsoPacket.OfsStatus);
    }
    set => Marshal.WriteInt32(this.mpMonoUsbIsoPacket, MonoUsbIsoPacket.OfsStatus, (int) value);
  }
}
