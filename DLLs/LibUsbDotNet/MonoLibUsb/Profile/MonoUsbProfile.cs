// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.Profile.MonoUsbProfile
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet;
using LibUsbDotNet.Main;
using MonoLibUsb.Descriptors;

#nullable disable
namespace MonoLibUsb.Profile;

public class MonoUsbProfile
{
  private readonly byte mBusNumber;
  private readonly byte mDeviceAddress;
  private readonly MonoUsbDeviceDescriptor mMonoUsbDeviceDescriptor = new MonoUsbDeviceDescriptor();
  private readonly MonoUsbProfileHandle mMonoUSBProfileHandle;
  internal bool mDiscovered;

  internal MonoUsbProfile(MonoUsbProfileHandle monoUSBProfileHandle)
  {
    this.mMonoUSBProfileHandle = monoUSBProfileHandle;
    this.mBusNumber = MonoUsbApi.GetBusNumber(this.mMonoUSBProfileHandle);
    this.mDeviceAddress = MonoUsbApi.GetDeviceAddress(this.mMonoUSBProfileHandle);
    int deviceDescriptor = (int) this.GetDeviceDescriptor(out this.mMonoUsbDeviceDescriptor);
  }

  public MonoUsbDeviceDescriptor DeviceDescriptor => this.mMonoUsbDeviceDescriptor;

  public byte BusNumber => this.mBusNumber;

  public byte DeviceAddress => this.mDeviceAddress;

  public MonoUsbProfileHandle ProfileHandle => this.mMonoUSBProfileHandle;

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    if ((object) this == obj)
      return true;
    return (object) obj.GetType() == (object) typeof (MonoUsbProfile) && this.Equals((MonoUsbProfile) obj);
  }

  public override int GetHashCode()
  {
    byte num1 = this.mBusNumber;
    int num2 = num1.GetHashCode() * 397;
    num1 = this.mDeviceAddress;
    int hashCode = num1.GetHashCode();
    return num2 ^ hashCode;
  }

  public static bool operator ==(MonoUsbProfile left, MonoUsbProfile right)
  {
    return object.Equals((object) left, (object) right);
  }

  public static bool operator !=(MonoUsbProfile left, MonoUsbProfile right)
  {
    return !object.Equals((object) left, (object) right);
  }

  private MonoUsbError GetDeviceDescriptor(
    out MonoUsbDeviceDescriptor monoUsbDeviceDescriptor)
  {
    monoUsbDeviceDescriptor = new MonoUsbDeviceDescriptor();
    MonoUsbError deviceDescriptor = (MonoUsbError) MonoUsbApi.GetDeviceDescriptor(this.mMonoUSBProfileHandle, monoUsbDeviceDescriptor);
    if (deviceDescriptor != MonoUsbError.Success)
    {
      UsbError.Error(ErrorCode.MonoApiError, (int) deviceDescriptor, "GetDeviceDescriptor Failed", (object) this);
      monoUsbDeviceDescriptor = (MonoUsbDeviceDescriptor) null;
    }
    return deviceDescriptor;
  }

  public void Close()
  {
    if (this.mMonoUSBProfileHandle.IsClosed)
      return;
    this.mMonoUSBProfileHandle.Close();
  }

  public MonoUsbDeviceHandle OpenDeviceHandle() => new MonoUsbDeviceHandle(this.ProfileHandle);

  public bool Equals(MonoUsbProfile other)
  {
    if ((object) other == null)
      return false;
    if ((object) this == (object) other)
      return true;
    return (int) other.mBusNumber == (int) this.mBusNumber && (int) other.mDeviceAddress == (int) this.mDeviceAddress;
  }
}
