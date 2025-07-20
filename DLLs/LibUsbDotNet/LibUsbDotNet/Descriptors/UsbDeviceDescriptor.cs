// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Descriptors.UsbDeviceDescriptor
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Main;
using MonoLibUsb.Descriptors;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.Descriptors;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class UsbDeviceDescriptor : UsbDescriptor
{
  public new static readonly int Size = Marshal.SizeOf(typeof (UsbDeviceDescriptor));
  public short BcdUsb;
  public ClassCodeType Class;
  public byte SubClass;
  public byte Protocol;
  public byte MaxPacketSize0;
  public short VendorID;
  public short ProductID;
  public short BcdDevice;
  public byte ManufacturerStringIndex;
  public byte ProductStringIndex;
  public byte SerialStringIndex;
  public byte ConfigurationCount;

  internal UsbDeviceDescriptor()
  {
  }

  internal UsbDeviceDescriptor(MonoUsbDeviceDescriptor usbDeviceDescriptor)
  {
    this.BcdDevice = usbDeviceDescriptor.BcdDevice;
    this.BcdUsb = usbDeviceDescriptor.BcdUsb;
    this.Class = usbDeviceDescriptor.Class;
    this.ConfigurationCount = usbDeviceDescriptor.ConfigurationCount;
    this.DescriptorType = usbDeviceDescriptor.DescriptorType;
    this.Length = usbDeviceDescriptor.Length;
    this.ManufacturerStringIndex = usbDeviceDescriptor.ManufacturerStringIndex;
    this.MaxPacketSize0 = usbDeviceDescriptor.MaxPacketSize0;
    this.ProductID = usbDeviceDescriptor.ProductID;
    this.ProductStringIndex = usbDeviceDescriptor.ProductStringIndex;
    this.Protocol = usbDeviceDescriptor.Protocol;
    this.SerialStringIndex = usbDeviceDescriptor.SerialStringIndex;
    this.SubClass = usbDeviceDescriptor.SubClass;
    this.VendorID = usbDeviceDescriptor.VendorID;
  }

  public override string ToString()
  {
    return this.ToString("", UsbDescriptor.ToStringParamValueSeperator, UsbDescriptor.ToStringFieldSeperator);
  }

  public string ToString(string prefixSeperator, string entitySperator, string suffixSeperator)
  {
    object[] values = new object[14]
    {
      (object) this.Length,
      (object) this.DescriptorType,
      (object) ("0x" + this.BcdUsb.ToString("X4")),
      (object) this.Class,
      (object) ("0x" + this.SubClass.ToString("X2")),
      (object) ("0x" + this.Protocol.ToString("X2")),
      (object) this.MaxPacketSize0,
      (object) ("0x" + this.VendorID.ToString("X4")),
      (object) ("0x" + this.ProductID.ToString("X4")),
      (object) ("0x" + this.BcdDevice.ToString("X4")),
      (object) this.ManufacturerStringIndex,
      (object) this.ProductStringIndex,
      (object) this.SerialStringIndex,
      (object) this.ConfigurationCount
    };
    string[] names = new string[14]
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
    };
    return Helper.ToString(prefixSeperator, names, entitySperator, values, suffixSeperator);
  }

  public bool Equals(UsbDeviceDescriptor other)
  {
    if ((object) other == null)
      return false;
    if ((object) this == (object) other)
      return true;
    return (int) other.BcdUsb == (int) this.BcdUsb && other.Class == this.Class && (int) other.SubClass == (int) this.SubClass && (int) other.Protocol == (int) this.Protocol && (int) other.MaxPacketSize0 == (int) this.MaxPacketSize0 && (int) other.VendorID == (int) this.VendorID && (int) other.ProductID == (int) this.ProductID && (int) other.BcdDevice == (int) this.BcdDevice && (int) other.ManufacturerStringIndex == (int) this.ManufacturerStringIndex && (int) other.ProductStringIndex == (int) this.ProductStringIndex && (int) other.SerialStringIndex == (int) this.SerialStringIndex && (int) other.ConfigurationCount == (int) this.ConfigurationCount;
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    if ((object) this == obj)
      return true;
    return (object) obj.GetType() == (object) typeof (UsbDeviceDescriptor) && this.Equals((UsbDeviceDescriptor) obj);
  }

  public override int GetHashCode()
  {
    return ((((((((((this.BcdUsb.GetHashCode() * 397 ^ this.Class.GetHashCode()) * 397 ^ this.SubClass.GetHashCode()) * 397 ^ this.Protocol.GetHashCode()) * 397 ^ this.MaxPacketSize0.GetHashCode()) * 397 ^ this.VendorID.GetHashCode()) * 397 ^ this.ProductID.GetHashCode()) * 397 ^ this.BcdDevice.GetHashCode()) * 397 ^ this.ManufacturerStringIndex.GetHashCode()) * 397 ^ this.ProductStringIndex.GetHashCode()) * 397 ^ this.SerialStringIndex.GetHashCode()) * 397 ^ this.ConfigurationCount.GetHashCode();
  }

  public static bool operator ==(UsbDeviceDescriptor left, UsbDeviceDescriptor right)
  {
    return object.Equals((object) left, (object) right);
  }

  public static bool operator !=(UsbDeviceDescriptor left, UsbDeviceDescriptor right)
  {
    return !object.Equals((object) left, (object) right);
  }
}
