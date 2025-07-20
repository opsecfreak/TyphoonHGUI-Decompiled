// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Main.UsbDeviceFinder
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

#nullable disable
namespace LibUsbDotNet.Main;

public class UsbDeviceFinder : ISerializable
{
  public const int NO_PID = 2147483647 /*0x7FFFFFFF*/;
  public const int NO_REV = 2147483647 /*0x7FFFFFFF*/;
  public const string NO_SERIAL = null;
  public const int NO_VID = 2147483647 /*0x7FFFFFFF*/;
  public static readonly Guid NO_GUID = Guid.Empty;
  private Guid mDeviceInterfaceGuid = Guid.Empty;
  private int mPid = int.MaxValue;
  private int mRevision = int.MaxValue;
  private string mSerialNumber;
  private int mVid = int.MaxValue;

  public UsbDeviceFinder(
    int vid,
    int pid,
    int revision,
    string serialNumber,
    Guid deviceInterfaceGuid)
  {
    this.mVid = vid;
    this.mPid = pid;
    this.mRevision = revision;
    this.mSerialNumber = serialNumber;
    this.mDeviceInterfaceGuid = deviceInterfaceGuid;
  }

  public UsbDeviceFinder(int vid, int pid, string serialNumber)
    : this(vid, pid, int.MaxValue, serialNumber, Guid.Empty)
  {
  }

  public UsbDeviceFinder(int vid, int pid, int revision)
    : this(vid, pid, revision, (string) null, Guid.Empty)
  {
  }

  public UsbDeviceFinder(int vid, int pid)
    : this(vid, pid, int.MaxValue, (string) null, Guid.Empty)
  {
  }

  public UsbDeviceFinder(int vid)
    : this(vid, int.MaxValue, int.MaxValue, (string) null, Guid.Empty)
  {
  }

  public UsbDeviceFinder(string serialNumber)
    : this(int.MaxValue, int.MaxValue, int.MaxValue, serialNumber, Guid.Empty)
  {
  }

  public UsbDeviceFinder(Guid deviceInterfaceGuid)
    : this(int.MaxValue, int.MaxValue, int.MaxValue, (string) null, deviceInterfaceGuid)
  {
  }

  protected UsbDeviceFinder(SerializationInfo info, StreamingContext context)
  {
    this.mVid = info != null ? (int) info.GetValue(nameof (Vid), typeof (int)) : throw new ArgumentNullException(nameof (info));
    this.mPid = (int) info.GetValue(nameof (Pid), typeof (int));
    this.mRevision = (int) info.GetValue(nameof (Revision), typeof (int));
    this.mSerialNumber = (string) info.GetValue(nameof (SerialNumber), typeof (string));
    this.mDeviceInterfaceGuid = (Guid) info.GetValue(nameof (DeviceInterfaceGuid), typeof (Guid));
  }

  protected UsbDeviceFinder()
  {
  }

  public Guid DeviceInterfaceGuid
  {
    get => this.mDeviceInterfaceGuid;
    set => this.mDeviceInterfaceGuid = value;
  }

  public string SerialNumber
  {
    get => this.mSerialNumber;
    set => this.mSerialNumber = value;
  }

  public int Revision
  {
    get => this.mRevision;
    set => this.mRevision = value;
  }

  public int Pid
  {
    get => this.mPid;
    set => this.mPid = value;
  }

  public int Vid
  {
    get => this.mVid;
    set => this.mVid = value;
  }

  public void GetObjectData(SerializationInfo info, StreamingContext context)
  {
    if (info == null)
      throw new ArgumentNullException(nameof (info));
    info.AddValue("Vid", this.mVid);
    info.AddValue("Pid", this.mPid);
    info.AddValue("Revision", this.mRevision);
    info.AddValue("SerialNumber", (object) this.mSerialNumber);
    info.AddValue("DeviceInterfaceGuid", (object) this.mDeviceInterfaceGuid);
  }

  public static UsbDeviceFinder Load(Stream deviceFinderStream)
  {
    return new BinaryFormatter().Deserialize(deviceFinderStream) as UsbDeviceFinder;
  }

  public static void Save(UsbDeviceFinder usbDeviceFinder, Stream outStream)
  {
    new BinaryFormatter().Serialize(outStream, (object) usbDeviceFinder);
  }

  public virtual bool Check(UsbRegistry usbRegistry)
  {
    return (this.mVid == int.MaxValue || usbRegistry.Vid == this.mVid) && (this.mPid == int.MaxValue || usbRegistry.Pid == this.mPid) && (this.mRevision == int.MaxValue || usbRegistry.Rev == this.mRevision) && (string.IsNullOrEmpty(this.mSerialNumber) || !string.IsNullOrEmpty(usbRegistry.SymbolicName) && !(this.mSerialNumber != UsbSymbolicName.Parse(usbRegistry.SymbolicName).SerialNumber)) && (!(this.mDeviceInterfaceGuid != Guid.Empty) || new List<Guid>((IEnumerable<Guid>) usbRegistry.DeviceInterfaceGuids).Contains(this.mDeviceInterfaceGuid));
  }

  public virtual bool Check(UsbDevice usbDevice)
  {
    return (this.mVid == int.MaxValue || (int) (ushort) usbDevice.Info.Descriptor.VendorID == this.mVid) && (this.mPid == int.MaxValue || (int) (ushort) usbDevice.Info.Descriptor.ProductID == this.mPid) && (this.mRevision == int.MaxValue || (int) (ushort) usbDevice.Info.Descriptor.BcdDevice == this.mRevision) && (string.IsNullOrEmpty(this.mSerialNumber) || !(this.mSerialNumber != usbDevice.Info.SerialString));
  }
}
