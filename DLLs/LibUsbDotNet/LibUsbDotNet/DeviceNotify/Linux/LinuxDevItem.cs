// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.DeviceNotify.Linux.LinuxDevItem
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Descriptors;
using MonoLibUsb.Descriptors;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.DeviceNotify.Linux;

internal class LinuxDevItem
{
  public readonly byte BusNumber;
  public readonly byte DeviceAddress;
  public readonly UsbDeviceDescriptor DeviceDescriptor;
  public readonly string DeviceFileName;

  public LinuxDevItem(
    string deviceFileName,
    byte busNumber,
    byte deviceAddress,
    byte[] fileDescriptor)
  {
    this.DeviceFileName = deviceFileName;
    this.BusNumber = busNumber;
    this.DeviceAddress = deviceAddress;
    this.DeviceDescriptor = new UsbDeviceDescriptor();
    GCHandle gcHandle = GCHandle.Alloc((object) this.DeviceDescriptor, GCHandleType.Pinned);
    Marshal.Copy(fileDescriptor, 0, gcHandle.AddrOfPinnedObject(), Marshal.SizeOf((object) this.DeviceDescriptor));
    gcHandle.Free();
  }

  public LinuxDevItem(
    string deviceFileName,
    byte busNumber,
    byte deviceAddress,
    MonoUsbDeviceDescriptor monoUsbDeviceDescriptor)
  {
    this.DeviceFileName = deviceFileName;
    this.BusNumber = busNumber;
    this.DeviceAddress = deviceAddress;
    this.DeviceDescriptor = new UsbDeviceDescriptor(monoUsbDeviceDescriptor);
  }

  public bool Equals(LinuxDevItem other)
  {
    if ((object) other == null)
      return false;
    if ((object) this == (object) other)
      return true;
    return object.Equals((object) other.DeviceFileName, (object) this.DeviceFileName) && (int) other.BusNumber == (int) this.BusNumber && (int) other.DeviceAddress == (int) this.DeviceAddress && object.Equals((object) other.DeviceDescriptor, (object) this.DeviceDescriptor);
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    if ((object) this == obj)
      return true;
    return (object) obj.GetType() == (object) typeof (LinuxDevItem) && this.Equals((LinuxDevItem) obj);
  }

  public override int GetHashCode()
  {
    int num1 = (this.DeviceFileName != null ? this.DeviceFileName.GetHashCode() : 0) * 397;
    byte num2 = this.BusNumber;
    int hashCode1 = num2.GetHashCode();
    int num3 = (num1 ^ hashCode1) * 397;
    num2 = this.DeviceAddress;
    int hashCode2 = num2.GetHashCode();
    return (num3 ^ hashCode2) * 397 ^ (this.DeviceDescriptor != (UsbDeviceDescriptor) null ? this.DeviceDescriptor.GetHashCode() : 0);
  }

  public static bool operator ==(LinuxDevItem left, LinuxDevItem right)
  {
    return object.Equals((object) left, (object) right);
  }

  public static bool operator !=(LinuxDevItem left, LinuxDevItem right)
  {
    return !object.Equals((object) left, (object) right);
  }
}
