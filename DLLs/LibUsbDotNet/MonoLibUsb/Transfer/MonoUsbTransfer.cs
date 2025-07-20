// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.Transfer.MonoUsbTransfer
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Main;
using MonoLibUsb.Transfer.Internal;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace MonoLibUsb.Transfer;

public struct MonoUsbTransfer
{
  private static readonly int OfsActualLength = Marshal.OffsetOf(typeof (libusb_transfer), "actual_length").ToInt32();
  private static readonly int OfsEndpoint = Marshal.OffsetOf(typeof (libusb_transfer), "endpoint").ToInt32();
  private static readonly int OfsFlags = Marshal.OffsetOf(typeof (libusb_transfer), "flags").ToInt32();
  private static readonly int OfsLength = Marshal.OffsetOf(typeof (libusb_transfer), "length").ToInt32();
  private static readonly int OfsPtrBuffer = Marshal.OffsetOf(typeof (libusb_transfer), "pBuffer").ToInt32();
  private static readonly int OfsPtrCallbackFn = Marshal.OffsetOf(typeof (libusb_transfer), "pCallbackFn").ToInt32();
  private static readonly int OfsPtrDeviceHandle = Marshal.OffsetOf(typeof (libusb_transfer), "deviceHandle").ToInt32();
  private static readonly int OfsPtrUserData = Marshal.OffsetOf(typeof (libusb_transfer), "pUserData").ToInt32();
  private static readonly int OfsStatus = Marshal.OffsetOf(typeof (libusb_transfer), "status").ToInt32();
  private static readonly int OfsTimeout = Marshal.OffsetOf(typeof (libusb_transfer), "timeout").ToInt32();
  private static readonly int OfsType = Marshal.OffsetOf(typeof (libusb_transfer), "type").ToInt32();
  private static readonly int OfsNumIsoPackets = Marshal.OffsetOf(typeof (libusb_transfer), "num_iso_packets").ToInt32();
  private static readonly int OfsIsoPackets = Marshal.OffsetOf(typeof (libusb_transfer), "iso_packets").ToInt32();
  private IntPtr handle;

  public MonoUsbTransfer(int numIsoPackets)
  {
    this.handle = MonoUsbApi.AllocTransfer(numIsoPackets);
  }

  internal MonoUsbTransfer(IntPtr pTransfer) => this.handle = pTransfer;

  public IntPtr PtrBuffer
  {
    get => Marshal.ReadIntPtr(this.handle, MonoUsbTransfer.OfsPtrBuffer);
    set => Marshal.WriteIntPtr(this.handle, MonoUsbTransfer.OfsPtrBuffer, value);
  }

  public IntPtr PtrUserData
  {
    get => Marshal.ReadIntPtr(this.handle, MonoUsbTransfer.OfsPtrUserData);
    set => Marshal.WriteIntPtr(this.handle, MonoUsbTransfer.OfsPtrUserData, value);
  }

  public IntPtr PtrCallbackFn
  {
    get => Marshal.ReadIntPtr(this.handle, MonoUsbTransfer.OfsPtrCallbackFn);
    set => Marshal.WriteIntPtr(this.handle, MonoUsbTransfer.OfsPtrCallbackFn, value);
  }

  public int ActualLength
  {
    get => Marshal.ReadInt32(this.handle, MonoUsbTransfer.OfsActualLength);
    set => Marshal.WriteInt32(this.handle, MonoUsbTransfer.OfsActualLength, value);
  }

  public int Length
  {
    get => Marshal.ReadInt32(this.handle, MonoUsbTransfer.OfsLength);
    set => Marshal.WriteInt32(this.handle, MonoUsbTransfer.OfsLength, value);
  }

  public MonoUsbTansferStatus Status
  {
    get => (MonoUsbTansferStatus) Marshal.ReadInt32(this.handle, MonoUsbTransfer.OfsStatus);
    set => Marshal.WriteInt32(this.handle, MonoUsbTransfer.OfsStatus, (int) value);
  }

  public int Timeout
  {
    get => Marshal.ReadInt32(this.handle, MonoUsbTransfer.OfsTimeout);
    set => Marshal.WriteInt32(this.handle, MonoUsbTransfer.OfsTimeout, value);
  }

  public EndpointType Type
  {
    get => (EndpointType) Marshal.ReadByte(this.handle, MonoUsbTransfer.OfsType);
    set => Marshal.WriteByte(this.handle, MonoUsbTransfer.OfsType, (byte) value);
  }

  public byte Endpoint
  {
    get => Marshal.ReadByte(this.handle, MonoUsbTransfer.OfsEndpoint);
    set => Marshal.WriteByte(this.handle, MonoUsbTransfer.OfsEndpoint, value);
  }

  public MonoUsbTransferFlags Flags
  {
    get => (MonoUsbTransferFlags) Marshal.ReadByte(this.handle, MonoUsbTransfer.OfsFlags);
    set => Marshal.WriteByte(this.handle, MonoUsbTransfer.OfsFlags, (byte) value);
  }

  public IntPtr PtrDeviceHandle
  {
    get => Marshal.ReadIntPtr(this.handle, MonoUsbTransfer.OfsPtrDeviceHandle);
    set => Marshal.WriteIntPtr(this.handle, MonoUsbTransfer.OfsPtrDeviceHandle, value);
  }

  public int NumIsoPackets
  {
    get => Marshal.ReadInt32(this.handle, MonoUsbTransfer.OfsNumIsoPackets);
    set => Marshal.WriteInt32(this.handle, MonoUsbTransfer.OfsNumIsoPackets, value);
  }

  public void Free()
  {
    if (!(this.handle != IntPtr.Zero))
      return;
    MonoUsbApi.FreeTransfer(this.handle);
    this.handle = IntPtr.Zero;
  }

  public string UniqueName() => $"_-EP[{this.handle}]EP-_";

  public MonoUsbIsoPacket IsoPacket(int packetNumber)
  {
    if (packetNumber > this.NumIsoPackets)
      throw new ArgumentOutOfRangeException(nameof (packetNumber));
    return new MonoUsbIsoPacket(new IntPtr(this.handle.ToInt64() + (long) MonoUsbTransfer.OfsIsoPackets + (long) (packetNumber * Marshal.SizeOf(typeof (libusb_iso_packet_descriptor)))));
  }

  public bool IsInvalid => this.handle == IntPtr.Zero;

  public MonoUsbError Cancel()
  {
    return this.IsInvalid ? MonoUsbError.ErrorNoMem : (MonoUsbError) MonoUsbApi.CancelTransfer(this.handle);
  }

  public void FillBulk(
    MonoUsbDeviceHandle devHandle,
    byte endpoint,
    IntPtr buffer,
    int length,
    Delegate callback,
    IntPtr userData,
    int timeout)
  {
    this.PtrDeviceHandle = devHandle.DangerousGetHandle();
    this.Endpoint = endpoint;
    this.PtrBuffer = buffer;
    this.Length = length;
    this.PtrCallbackFn = Marshal.GetFunctionPointerForDelegate(callback);
    this.PtrUserData = userData;
    this.Timeout = timeout;
    this.Type = EndpointType.Bulk;
    this.Flags = MonoUsbTransferFlags.None;
    this.NumIsoPackets = 0;
    this.ActualLength = 0;
  }

  public void FillInterrupt(
    MonoUsbDeviceHandle devHandle,
    byte endpoint,
    IntPtr buffer,
    int length,
    Delegate callback,
    IntPtr userData,
    int timeout)
  {
    this.PtrDeviceHandle = devHandle.DangerousGetHandle();
    this.Endpoint = endpoint;
    this.PtrBuffer = buffer;
    this.Length = length;
    this.PtrCallbackFn = Marshal.GetFunctionPointerForDelegate(callback);
    this.PtrUserData = userData;
    this.Timeout = timeout;
    this.Type = EndpointType.Interrupt;
    this.Flags = MonoUsbTransferFlags.None;
  }

  public void FillIsochronous(
    MonoUsbDeviceHandle devHandle,
    byte endpoint,
    IntPtr buffer,
    int length,
    int numIsoPackets,
    Delegate callback,
    IntPtr userData,
    int timeout)
  {
    this.PtrDeviceHandle = devHandle.DangerousGetHandle();
    this.Endpoint = endpoint;
    this.PtrBuffer = buffer;
    this.Length = length;
    this.PtrCallbackFn = Marshal.GetFunctionPointerForDelegate(callback);
    this.PtrUserData = userData;
    this.Timeout = timeout;
    this.Type = EndpointType.Isochronous;
    this.Flags = MonoUsbTransferFlags.None;
    this.NumIsoPackets = numIsoPackets;
  }

  public IntPtr GetIsoPacketBuffer(int packet)
  {
    if (packet >= this.NumIsoPackets)
      throw new ArgumentOutOfRangeException(nameof (packet), "GetIsoPacketBuffer: packet must be < NumIsoPackets");
    long int64 = this.PtrBuffer.ToInt64();
    for (int packetNumber = 0; packetNumber < packet; ++packetNumber)
      int64 += (long) this.IsoPacket(packetNumber).Length;
    return new IntPtr(int64);
  }

  public IntPtr GetIsoPacketBufferSimple(int packet)
  {
    if (packet >= this.NumIsoPackets)
      throw new ArgumentOutOfRangeException(nameof (packet), "GetIsoPacketBufferSimple: packet must be < NumIsoPackets");
    return new IntPtr(this.PtrBuffer.ToInt64() + (long) (this.IsoPacket(0).Length * packet));
  }

  public void SetIsoPacketLengths(int length)
  {
    int numIsoPackets = this.NumIsoPackets;
    for (int packetNumber = 0; packetNumber < numIsoPackets; ++packetNumber)
      this.IsoPacket(packetNumber).Length = length;
  }

  public MonoUsbError Submit()
  {
    return this.IsInvalid ? MonoUsbError.ErrorNoMem : (MonoUsbError) MonoUsbApi.SubmitTransfer(this.handle);
  }

  public static MonoUsbTransfer Alloc(int numIsoPackets)
  {
    IntPtr pTransfer = MonoUsbApi.AllocTransfer(numIsoPackets);
    return !(pTransfer == IntPtr.Zero) ? new MonoUsbTransfer(pTransfer) : throw new OutOfMemoryException("AllocTransfer");
  }

  public void FillControl(
    MonoUsbDeviceHandle devHandle,
    MonoUsbControlSetupHandle controlSetupHandle,
    Delegate callback,
    IntPtr userData,
    int timeout)
  {
    this.PtrDeviceHandle = devHandle.DangerousGetHandle();
    this.Endpoint = (byte) 0;
    this.PtrCallbackFn = Marshal.GetFunctionPointerForDelegate(callback);
    this.PtrUserData = userData;
    this.Timeout = timeout;
    this.Type = EndpointType.Control;
    this.Flags = MonoUsbTransferFlags.None;
    IntPtr handle = controlSetupHandle.DangerousGetHandle();
    this.PtrBuffer = handle;
    MonoUsbControlSetup monoUsbControlSetup = new MonoUsbControlSetup(handle);
    this.Length = MonoUsbControlSetup.SETUP_PACKET_SIZE + (int) monoUsbControlSetup.Length;
  }
}
