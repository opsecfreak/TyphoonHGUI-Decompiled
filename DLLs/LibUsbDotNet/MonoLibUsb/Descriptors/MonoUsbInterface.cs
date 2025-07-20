// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.Descriptors.MonoUsbInterface
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace MonoLibUsb.Descriptors;

[StructLayout(LayoutKind.Sequential)]
public class MonoUsbInterface
{
  private IntPtr pAltSetting;
  public readonly int num_altsetting;

  public List<MonoUsbAltInterfaceDescriptor> AltInterfaceList
  {
    get
    {
      List<MonoUsbAltInterfaceDescriptor> altInterfaceList = new List<MonoUsbAltInterfaceDescriptor>();
      for (int index = 0; index < this.num_altsetting; ++index)
      {
        IntPtr ptr = new IntPtr(this.pAltSetting.ToInt64() + (long) (Marshal.SizeOf(typeof (MonoUsbAltInterfaceDescriptor)) * index));
        MonoUsbAltInterfaceDescriptor interfaceDescriptor = new MonoUsbAltInterfaceDescriptor();
        MonoUsbAltInterfaceDescriptor structure = interfaceDescriptor;
        Marshal.PtrToStructure(ptr, (object) structure);
        altInterfaceList.Add(interfaceDescriptor);
      }
      return altInterfaceList;
    }
  }
}
