// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.Descriptors.MonoUsbAltInterfaceDescriptor
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Descriptors;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace MonoLibUsb.Descriptors;

[StructLayout(LayoutKind.Sequential)]
public class MonoUsbAltInterfaceDescriptor
{
  public readonly byte bLength;
  public readonly DescriptorType bDescriptorType;
  public readonly byte bInterfaceNumber;
  public readonly byte bAlternateSetting;
  public readonly byte bNumEndpoints;
  public readonly ClassCodeType bInterfaceClass;
  public readonly byte bInterfaceSubClass;
  public readonly byte bInterfaceProtocol;
  public readonly byte iInterface;
  private readonly IntPtr pEndpointDescriptors;
  private IntPtr pExtraBytes;
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

  public List<MonoUsbEndpointDescriptor> EndpointList
  {
    get
    {
      List<MonoUsbEndpointDescriptor> endpointList = new List<MonoUsbEndpointDescriptor>();
      for (int index = 0; index < (int) this.bNumEndpoints; ++index)
      {
        IntPtr ptr = new IntPtr(this.pEndpointDescriptors.ToInt64() + (long) (Marshal.SizeOf(typeof (MonoUsbEndpointDescriptor)) * index));
        MonoUsbEndpointDescriptor endpointDescriptor = new MonoUsbEndpointDescriptor();
        MonoUsbEndpointDescriptor structure = endpointDescriptor;
        Marshal.PtrToStructure(ptr, (object) structure);
        endpointList.Add(endpointDescriptor);
      }
      return endpointList;
    }
  }
}
