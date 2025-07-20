// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Info.UsbInterfaceInfo
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Descriptors;
using LibUsbDotNet.Main;
using MonoLibUsb.Descriptors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#nullable disable
namespace LibUsbDotNet.Info;

public class UsbInterfaceInfo : UsbBaseInfo
{
  internal readonly UsbInterfaceDescriptor mUsbInterfaceDescriptor;
  internal List<UsbEndpointInfo> mEndpointInfo = new List<UsbEndpointInfo>();
  private string mInterfaceString;
  internal UsbDevice mUsbDevice;

  internal UsbInterfaceInfo(UsbDevice usbDevice, byte[] descriptor)
  {
    this.mUsbDevice = usbDevice;
    this.mUsbInterfaceDescriptor = new UsbInterfaceDescriptor();
    Helper.BytesToObject(descriptor, 0, Math.Min(UsbInterfaceDescriptor.Size, (int) descriptor[0]), (object) this.mUsbInterfaceDescriptor);
  }

  internal UsbInterfaceInfo(
    UsbDevice usbDevice,
    MonoUsbAltInterfaceDescriptor monoUSBAltInterfaceDescriptor)
  {
    this.mUsbDevice = usbDevice;
    this.mUsbInterfaceDescriptor = new UsbInterfaceDescriptor(monoUSBAltInterfaceDescriptor);
    foreach (MonoUsbEndpointDescriptor endpoint in monoUSBAltInterfaceDescriptor.EndpointList)
      this.mEndpointInfo.Add(new UsbEndpointInfo(endpoint));
  }

  public UsbInterfaceDescriptor Descriptor => this.mUsbInterfaceDescriptor;

  public ReadOnlyCollection<UsbEndpointInfo> EndpointInfoList => this.mEndpointInfo.AsReadOnly();

  public string InterfaceString
  {
    get
    {
      if (this.mInterfaceString == null)
      {
        this.mInterfaceString = string.Empty;
        if (this.Descriptor.StringIndex > (byte) 0)
          this.mUsbDevice.GetString(out this.mInterfaceString, this.mUsbDevice.Info.CurrentCultureLangID, this.Descriptor.StringIndex);
      }
      return this.mInterfaceString;
    }
  }

  public override string ToString()
  {
    return this.ToString("", UsbDescriptor.ToStringParamValueSeperator, UsbDescriptor.ToStringFieldSeperator);
  }

  public string ToString(string prefixSeperator, string entitySperator, string suffixSeperator)
  {
    object[] values = new object[1]
    {
      (object) this.InterfaceString
    };
    string[] names = new string[1]{ "InterfaceString" };
    return this.Descriptor.ToString(prefixSeperator, entitySperator, suffixSeperator) + Helper.ToString(prefixSeperator, names, entitySperator, values, suffixSeperator);
  }
}
