// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.IUsbInterface
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Info;
using LibUsbDotNet.Main;
using System;
using System.Collections.ObjectModel;

#nullable disable
namespace LibUsbDotNet;

public interface IUsbInterface
{
  UsbEndpointList ActiveEndpoints { get; }

  ReadOnlyCollection<UsbConfigInfo> Configs { get; }

  UsbDevice.DriverModeType DriverMode { get; }

  UsbDeviceInfo Info { get; }

  bool IsOpen { get; }

  UsbRegistry UsbRegistryInfo { get; }

  bool Close();

  bool ControlTransfer(
    ref UsbSetupPacket setupPacket,
    IntPtr buffer,
    int bufferLength,
    out int lengthTransferred);

  bool ControlTransfer(
    ref UsbSetupPacket setupPacket,
    object buffer,
    int bufferLength,
    out int lengthTransferred);

  bool GetDescriptor(
    byte descriptorType,
    byte index,
    short langId,
    IntPtr buffer,
    int bufferLength,
    out int transferLength);

  bool GetDescriptor(
    byte descriptorType,
    byte index,
    short langId,
    object buffer,
    int bufferLength,
    out int transferLength);

  bool GetLangIDs(out short[] langIDs);

  bool GetString(out string stringData, short langId, byte stringIndex);

  bool Open();

  UsbEndpointReader OpenEndpointReader(ReadEndpointID readEndpointID, int readBufferSize);

  UsbEndpointReader OpenEndpointReader(
    ReadEndpointID readEndpointID,
    int readBufferSize,
    EndpointType endpointType);

  UsbEndpointReader OpenEndpointReader(ReadEndpointID readEndpointID);

  UsbEndpointWriter OpenEndpointWriter(WriteEndpointID writeEndpointID);

  UsbEndpointWriter OpenEndpointWriter(WriteEndpointID writeEndpointID, EndpointType endpointType);
}
