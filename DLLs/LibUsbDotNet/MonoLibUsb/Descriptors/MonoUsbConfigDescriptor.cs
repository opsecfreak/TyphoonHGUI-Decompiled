// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.Descriptors.MonoUsbConfigDescriptor
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Descriptors;
using MonoLibUsb.Profile;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace MonoLibUsb.Descriptors;

[StructLayout(LayoutKind.Sequential)]
public class MonoUsbConfigDescriptor
{
  public readonly byte bLength;
  public readonly DescriptorType bDescriptorType;
  public readonly short wTotalLength;
  public readonly byte bNumInterfaces;
  public readonly byte bConfigurationValue;
  public readonly byte iConfiguration;
  public readonly byte bmAttributes;
  public readonly byte MaxPower;
  private readonly IntPtr pInterfaces;
  private readonly IntPtr pExtraBytes;
  public readonly int ExtraLength;

  internal MonoUsbConfigDescriptor()
  {
  }

  public MonoUsbConfigDescriptor(MonoUsbConfigHandle configHandle)
  {
    Marshal.PtrToStructure(configHandle.DangerousGetHandle(), (object) this);
  }

  public byte[] ExtraBytes
  {
    get
    {
      byte[] destination = new byte[this.ExtraLength];
      Marshal.Copy(this.pExtraBytes, destination, 0, destination.Length);
      return destination;
    }
  }

  public List<MonoUsbInterface> InterfaceList
  {
    get
    {
      List<MonoUsbInterface> interfaceList = new List<MonoUsbInterface>();
      for (int index = 0; index < (int) this.bNumInterfaces; ++index)
      {
        IntPtr ptr = new IntPtr(this.pInterfaces.ToInt64() + (long) (Marshal.SizeOf(typeof (MonoUsbInterface)) * index));
        MonoUsbInterface monoUsbInterface = new MonoUsbInterface();
        MonoUsbInterface structure = monoUsbInterface;
        Marshal.PtrToStructure(ptr, (object) structure);
        interfaceList.Add(monoUsbInterface);
      }
      return interfaceList;
    }
  }
}
