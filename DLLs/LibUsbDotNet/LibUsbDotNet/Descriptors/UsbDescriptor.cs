// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Descriptors.UsbDescriptor
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Main;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.Descriptors;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public abstract class UsbDescriptor
{
  public static string ToStringParamValueSeperator = ":";
  public static string ToStringFieldSeperator = "\r\n";
  public static readonly int Size = Marshal.SizeOf(typeof (UsbDescriptor));
  public byte Length;
  public DescriptorType DescriptorType;

  public override string ToString()
  {
    object[] values = new object[2]
    {
      (object) this.Length,
      (object) this.DescriptorType
    };
    return Helper.ToString("", new string[2]
    {
      "Length",
      "DescriptorType"
    }, UsbDescriptor.ToStringParamValueSeperator, values, UsbDescriptor.ToStringFieldSeperator);
  }
}
