// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Info.UsbConfigInfo
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Descriptors;
using LibUsbDotNet.LudnMonoLibUsb;
using LibUsbDotNet.Main;
using MonoLibUsb.Descriptors;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#nullable disable
namespace LibUsbDotNet.Info;

public class UsbConfigInfo : UsbBaseInfo
{
  private readonly List<UsbInterfaceInfo> mInterfaceList = new List<UsbInterfaceInfo>();
  internal readonly UsbConfigDescriptor mUsbConfigDescriptor;
  private string mConfigString;
  internal UsbDevice mUsbDevice;

  internal UsbConfigInfo(
    UsbDevice usbDevice,
    UsbConfigDescriptor descriptor,
    ref List<byte[]> rawDescriptors)
  {
    this.mUsbDevice = usbDevice;
    this.mUsbConfigDescriptor = descriptor;
    this.mRawDescriptors = rawDescriptors;
    UsbInterfaceInfo usbInterfaceInfo = (UsbInterfaceInfo) null;
    for (int index = 0; index < rawDescriptors.Count; ++index)
    {
      byte[] descriptor1 = rawDescriptors[index];
      switch (descriptor1[1])
      {
        case 4:
          usbInterfaceInfo = new UsbInterfaceInfo(usbDevice, descriptor1);
          this.mRawDescriptors.RemoveAt(index);
          this.mInterfaceList.Add(usbInterfaceInfo);
          --index;
          break;
        case 5:
          if (usbInterfaceInfo == null)
            throw new UsbException((object) this, "Recieved and endpoint descriptor before receiving an interface descriptor.");
          usbInterfaceInfo.mEndpointInfo.Add(new UsbEndpointInfo(descriptor1));
          this.mRawDescriptors.RemoveAt(index);
          --index;
          break;
        default:
          if (usbInterfaceInfo != null)
          {
            usbInterfaceInfo.mRawDescriptors.Add(descriptor1);
            this.mRawDescriptors.RemoveAt(index);
            --index;
            break;
          }
          break;
      }
    }
  }

  internal UsbConfigInfo(MonoUsbDevice usbDevice, MonoUsbConfigDescriptor configDescriptor)
  {
    this.mUsbDevice = (UsbDevice) usbDevice;
    this.mUsbConfigDescriptor = new UsbConfigDescriptor(configDescriptor);
    foreach (MonoUsbInterface monoUsbInterface in configDescriptor.InterfaceList)
    {
      foreach (MonoUsbAltInterfaceDescriptor altInterface in monoUsbInterface.AltInterfaceList)
        this.mInterfaceList.Add(new UsbInterfaceInfo(this.mUsbDevice, altInterface));
    }
  }

  public UsbConfigDescriptor Descriptor => this.mUsbConfigDescriptor;

  public string ConfigString
  {
    get
    {
      if (this.mConfigString == null)
      {
        this.mConfigString = string.Empty;
        if (this.Descriptor.StringIndex > (byte) 0)
          this.mUsbDevice.GetString(out this.mConfigString, this.mUsbDevice.Info.CurrentCultureLangID, this.Descriptor.StringIndex);
      }
      return this.mConfigString;
    }
  }

  public ReadOnlyCollection<UsbInterfaceInfo> InterfaceInfoList => this.mInterfaceList.AsReadOnly();

  public override string ToString()
  {
    return this.ToString("", UsbDescriptor.ToStringParamValueSeperator, UsbDescriptor.ToStringFieldSeperator);
  }

  public string ToString(string prefixSeperator, string entitySperator, string suffixSeperator)
  {
    object[] values = new object[1]
    {
      (object) this.ConfigString
    };
    string[] names = new string[1]{ "ConfigString" };
    return this.Descriptor.ToString(prefixSeperator, entitySperator, suffixSeperator) + Helper.ToString(prefixSeperator, names, entitySperator, values, suffixSeperator);
  }
}
