// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Descriptors.UsbInterfaceDescriptor
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Main;
using MonoLibUsb.Descriptors;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.Descriptors;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class UsbInterfaceDescriptor : UsbDescriptor
{
  public new static readonly int Size = Marshal.SizeOf(typeof (UsbInterfaceDescriptor));
  public readonly byte InterfaceID;
  public readonly byte AlternateID;
  public readonly byte EndpointCount;
  public readonly ClassCodeType Class;
  public readonly byte SubClass;
  public readonly byte Protocol;
  public readonly byte StringIndex;

  public override string ToString()
  {
    return this.ToString("", UsbDescriptor.ToStringParamValueSeperator, UsbDescriptor.ToStringFieldSeperator);
  }

  public string ToString(string prefixSeperator, string entitySperator, string suffixSeperator)
  {
    object[] values = new object[9]
    {
      (object) this.Length,
      (object) this.DescriptorType,
      (object) this.InterfaceID,
      (object) this.AlternateID,
      (object) this.EndpointCount,
      (object) this.Class,
      (object) ("0x" + this.SubClass.ToString("X2")),
      (object) ("0x" + this.Protocol.ToString("X2")),
      (object) this.StringIndex
    };
    string[] names = new string[9]
    {
      "Length",
      "DescriptorType",
      "InterfaceID",
      "AlternateID",
      "EndpointCount",
      "Class",
      "SubClass",
      "Protocol",
      "StringIndex"
    };
    return Helper.ToString(prefixSeperator, names, entitySperator, values, suffixSeperator);
  }

  internal UsbInterfaceDescriptor()
  {
  }

  internal UsbInterfaceDescriptor(
    MonoUsbAltInterfaceDescriptor altInterfaceDescriptor)
  {
    this.AlternateID = altInterfaceDescriptor.bAlternateSetting;
    this.Class = altInterfaceDescriptor.bInterfaceClass;
    this.DescriptorType = altInterfaceDescriptor.bDescriptorType;
    this.EndpointCount = altInterfaceDescriptor.bNumEndpoints;
    this.InterfaceID = altInterfaceDescriptor.bInterfaceNumber;
    this.Length = altInterfaceDescriptor.bLength;
    this.Protocol = altInterfaceDescriptor.bInterfaceProtocol;
    this.StringIndex = altInterfaceDescriptor.iInterface;
    this.SubClass = altInterfaceDescriptor.bInterfaceSubClass;
  }
}
