// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Descriptors.UsbConfigDescriptor
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Main;
using MonoLibUsb.Descriptors;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.Descriptors;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class UsbConfigDescriptor : UsbDescriptor
{
  public new static readonly int Size = Marshal.SizeOf(typeof (UsbConfigDescriptor));
  public readonly short TotalLength;
  public readonly byte InterfaceCount;
  public readonly byte ConfigID;
  public readonly byte StringIndex;
  public readonly byte Attributes;
  public readonly byte MaxPower;

  internal UsbConfigDescriptor(MonoUsbConfigDescriptor descriptor)
  {
    this.Attributes = descriptor.bmAttributes;
    this.ConfigID = descriptor.bConfigurationValue;
    this.DescriptorType = descriptor.bDescriptorType;
    this.InterfaceCount = descriptor.bNumInterfaces;
    this.Length = descriptor.bLength;
    this.MaxPower = descriptor.MaxPower;
    this.StringIndex = descriptor.iConfiguration;
    this.TotalLength = descriptor.wTotalLength;
  }

  internal UsbConfigDescriptor()
  {
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
      (object) this.TotalLength,
      (object) this.InterfaceCount,
      (object) this.ConfigID,
      (object) this.StringIndex,
      (object) ("0x" + this.Attributes.ToString("X2")),
      (object) this.MaxPower
    };
    string[] names = new string[8]
    {
      "Length",
      "DescriptorType",
      "TotalLength",
      "InterfaceCount",
      "ConfigID",
      "StringIndex",
      "Attributes",
      "MaxPower"
    };
    return Helper.ToString(prefixSeperator, names, entitySperator, values, suffixSeperator);
  }
}
