// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Info.UsbEndpointInfo
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Descriptors;
using LibUsbDotNet.Main;
using MonoLibUsb.Descriptors;
using System;

#nullable disable
namespace LibUsbDotNet.Info;

public class UsbEndpointInfo : UsbBaseInfo
{
  internal UsbEndpointDescriptor mUsbEndpointDescriptor;

  internal UsbEndpointInfo(byte[] descriptor)
  {
    this.mUsbEndpointDescriptor = new UsbEndpointDescriptor();
    Helper.BytesToObject(descriptor, 0, Math.Min(UsbEndpointDescriptor.Size, (int) descriptor[0]), (object) this.mUsbEndpointDescriptor);
  }

  internal UsbEndpointInfo(
    MonoUsbEndpointDescriptor monoUsbEndpointDescriptor)
  {
    this.mUsbEndpointDescriptor = new UsbEndpointDescriptor(monoUsbEndpointDescriptor);
  }

  public UsbEndpointDescriptor Descriptor => this.mUsbEndpointDescriptor;

  public override string ToString() => this.Descriptor.ToString();

  public string ToString(string prefixSeperator, string entitySperator, string suffixSeperator)
  {
    return this.Descriptor.ToString(prefixSeperator, entitySperator, suffixSeperator);
  }
}
