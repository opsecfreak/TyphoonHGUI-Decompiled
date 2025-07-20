// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.Descriptors.MonoUsbEndpointDescriptor
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Descriptors;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace MonoLibUsb.Descriptors;

[StructLayout(LayoutKind.Sequential)]
public class MonoUsbEndpointDescriptor
{
  public readonly byte bLength;
  public readonly DescriptorType bDescriptorType;
  public readonly byte bEndpointAddress;
  public readonly byte bmAttributes;
  public readonly short wMaxPacketSize;
  public readonly byte bInterval;
  public readonly byte bRefresh;
  public readonly byte bSynchAddress;
  private readonly IntPtr pExtraBytes;
  public readonly int ExtraLength;

  public byte[] ExtraBytes
  {
    get
    {
      byte[] destination = new byte[this.ExtraLength];
      Marshal.Copy(this.pExtraBytes, destination, 0, destination.Length);
      return destination;
    }
  }
}
