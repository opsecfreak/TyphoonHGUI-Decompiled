// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.DeviceNotify.Info.IUsbDeviceNotifyInfo
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Main;
using System;

#nullable disable
namespace LibUsbDotNet.DeviceNotify.Info;

public interface IUsbDeviceNotifyInfo
{
  UsbSymbolicName SymbolicName { get; }

  string Name { get; }

  Guid ClassGuid { get; }

  int IdVendor { get; }

  int IdProduct { get; }

  string SerialNumber { get; }

  string ToString();
}
