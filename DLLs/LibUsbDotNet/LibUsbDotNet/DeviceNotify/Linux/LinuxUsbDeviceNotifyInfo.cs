// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.DeviceNotify.Linux.LinuxUsbDeviceNotifyInfo
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Descriptors;
using LibUsbDotNet.DeviceNotify.Info;
using LibUsbDotNet.Main;
using System;

#nullable disable
namespace LibUsbDotNet.DeviceNotify.Linux;

public class LinuxUsbDeviceNotifyInfo : IUsbDeviceNotifyInfo
{
  private readonly LinuxDevItem mLinuxDevItem;

  internal LinuxUsbDeviceNotifyInfo(LinuxDevItem linuxDevItem) => this.mLinuxDevItem = linuxDevItem;

  public UsbDeviceDescriptor DeviceDescriptor => this.mLinuxDevItem.DeviceDescriptor;

  public byte BusNumber => this.mLinuxDevItem.BusNumber;

  public byte DeviceAddress => this.mLinuxDevItem.DeviceAddress;

  public UsbSymbolicName SymbolicName => (UsbSymbolicName) null;

  public string Name => this.mLinuxDevItem.DeviceFileName;

  public Guid ClassGuid => Guid.Empty;

  public int IdVendor => (int) (ushort) this.mLinuxDevItem.DeviceDescriptor.VendorID;

  public int IdProduct => (int) (ushort) this.mLinuxDevItem.DeviceDescriptor.ProductID;

  public string SerialNumber => string.Empty;

  public override string ToString()
  {
    return $"Name:{this.Name} BusNumber:{this.BusNumber} DeviceAddress:{this.DeviceAddress}\n{this.DeviceDescriptor.ToString()}";
  }
}
