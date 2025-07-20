// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.Descriptors.MonoUsbDeviceDescriptor
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Descriptors;
using LibUsbDotNet.Main;
using System.Runtime.InteropServices;

#nullable disable
namespace MonoLibUsb.Descriptors;

[StructLayout(LayoutKind.Sequential)]
public class MonoUsbDeviceDescriptor
{
  public static readonly int Size = Marshal.SizeOf(typeof (MonoUsbDeviceDescriptor));
  public byte Length;
  public DescriptorType DescriptorType;
  public readonly short BcdUsb;
  public readonly ClassCodeType Class;
  public readonly byte SubClass;
  public readonly byte Protocol;
  public readonly byte MaxPacketSize0;
  public readonly short VendorID;
  public readonly short ProductID;
  public readonly short BcdDevice;
  public readonly byte ManufacturerStringIndex;
  public readonly byte ProductStringIndex;
  public readonly byte SerialStringIndex;
  public readonly byte ConfigurationCount;

  public override string ToString()
  {
    return Helper.ToString("", new string[14]
    {
      "Length",
      "DescriptorType",
      "BcdUsb",
      "Class",
      "SubClass",
      "Protocol",
      "MaxPacketSize0",
      "VendorID",
      "ProductID",
      "BcdDevice",
      "ManufacturerStringIndex",
      "ProductStringIndex",
      "SerialStringIndex",
      "ConfigurationCount"
    }, ":", new object[14]
    {
      (object) this.Length,
      (object) this.DescriptorType,
      (object) ("0x" + this.BcdUsb.ToString("X4")),
      (object) this.Class,
      (object) this.SubClass,
      (object) this.Protocol,
      (object) this.MaxPacketSize0,
      (object) ("0x" + this.VendorID.ToString("X4")),
      (object) ("0x" + this.ProductID.ToString("X4")),
      (object) this.BcdDevice,
      (object) this.ManufacturerStringIndex,
      (object) this.ProductStringIndex,
      (object) this.SerialStringIndex,
      (object) this.ConfigurationCount
    }, "\r\n");
  }
}
