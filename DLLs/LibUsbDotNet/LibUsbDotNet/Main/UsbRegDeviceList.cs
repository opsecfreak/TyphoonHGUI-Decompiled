// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Main.UsbRegDeviceList
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace LibUsbDotNet.Main;

public class UsbRegDeviceList : IEnumerable<UsbRegistry>, IEnumerable
{
  private readonly List<UsbRegistry> mUsbRegistryList;

  public UsbRegDeviceList() => this.mUsbRegistryList = new List<UsbRegistry>();

  private UsbRegDeviceList(IEnumerable<UsbRegistry> usbRegDeviceList)
  {
    this.mUsbRegistryList = new List<UsbRegistry>(usbRegDeviceList);
  }

  public UsbRegistry this[int index] => this.mUsbRegistryList[index];

  public int Count => this.mUsbRegistryList.Count;

  IEnumerator<UsbRegistry> IEnumerable<UsbRegistry>.GetEnumerator()
  {
    return (IEnumerator<UsbRegistry>) this.mUsbRegistryList.GetEnumerator();
  }

  public IEnumerator GetEnumerator()
  {
    return (IEnumerator) ((IEnumerable<UsbRegistry>) this).GetEnumerator();
  }

  public UsbRegistry Find(Predicate<UsbRegistry> findUsbPredicate)
  {
    return this.mUsbRegistryList.Find(findUsbPredicate);
  }

  public UsbRegDeviceList FindAll(Predicate<UsbRegistry> findUsbPredicate)
  {
    return new UsbRegDeviceList((IEnumerable<UsbRegistry>) this.mUsbRegistryList.FindAll(findUsbPredicate));
  }

  public UsbRegistry FindLast(Predicate<UsbRegistry> findUsbPredicate)
  {
    return this.mUsbRegistryList.FindLast(findUsbPredicate);
  }

  public UsbRegistry Find(UsbDeviceFinder usbDeviceFinder)
  {
    return this.mUsbRegistryList.Find(new Predicate<UsbRegistry>(usbDeviceFinder.Check));
  }

  public UsbRegDeviceList FindAll(UsbDeviceFinder usbDeviceFinder)
  {
    return this.FindAll(new Predicate<UsbRegistry>(usbDeviceFinder.Check));
  }

  public UsbRegistry FindLast(UsbDeviceFinder usbDeviceFinder)
  {
    return this.mUsbRegistryList.FindLast(new Predicate<UsbRegistry>(usbDeviceFinder.Check));
  }

  public bool Contains(UsbRegistry item) => this.mUsbRegistryList.Contains(item);

  public void CopyTo(UsbRegistry[] array, int offset)
  {
    this.mUsbRegistryList.CopyTo(array, offset);
  }

  public int IndexOf(UsbRegistry item) => this.mUsbRegistryList.IndexOf(item);

  internal bool Add(UsbRegistry item)
  {
    this.mUsbRegistryList.Add(item);
    return true;
  }
}
