// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Descriptors.UsbEndpointDescriptor
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Main;
using MonoLibUsb.Descriptors;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.Descriptors;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class UsbEndpointDescriptor : UsbDescriptor
{
  public new static readonly int Size = Marshal.SizeOf(typeof (UsbEndpointDescriptor));
  public readonly byte EndpointID;
  public readonly byte Attributes;
  public readonly short MaxPacketSize;
  public readonly byte Interval;
  public readonly byte Refresh;
  public readonly byte SynchAddress;

  internal UsbEndpointDescriptor()
  {
  }

  internal UsbEndpointDescriptor(MonoUsbEndpointDescriptor descriptor)
  {
    this.Attributes = descriptor.bmAttributes;
    this.DescriptorType = descriptor.bDescriptorType;
    this.EndpointID = descriptor.bEndpointAddress;
    this.Interval = descriptor.bInterval;
    this.Length = descriptor.bLength;
    this.MaxPacketSize = descriptor.wMaxPacketSize;
    this.SynchAddress = descriptor.bSynchAddress;
  }

  public override string ToString()
  {
    return this.ToString("", UsbDescriptor.ToStringParamValueSeperator, UsbDescriptor.ToStringFieldSeperator);
  }

  public string ToString(string prefixSeperator, string entitySperator, string suffixSeperator)
  {
    object[] values = new object[8]
    {
      (object) this.Length,
      (object) this.DescriptorType,
      (object) ("0x" + this.EndpointID.ToString("X2")),
      (object) ("0x" + this.Attributes.ToString("X2")),
      (object) this.MaxPacketSize,
      (object) this.Interval,
      (object) this.Refresh,
      (object) ("0x" + this.SynchAddress.ToString("X2"))
    };
    string[] names = new string[8]
    {
      "Length",
      "DescriptorType",
      "EndpointID",
      "Attributes",
      "MaxPacketSize",
      "Interval",
      "Refresh",
      "SynchAddress"
    };
    return Helper.ToString(prefixSeperator, names, entitySperator, values, suffixSeperator);
  }
}
