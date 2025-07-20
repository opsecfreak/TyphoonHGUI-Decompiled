// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Info.UsbBaseInfo
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System.Collections.Generic;
using System.Collections.ObjectModel;

#nullable disable
namespace LibUsbDotNet.Info;

public abstract class UsbBaseInfo
{
  internal List<byte[]> mRawDescriptors = new List<byte[]>();

  public ReadOnlyCollection<byte[]> CustomDescriptors => this.mRawDescriptors.AsReadOnly();
}
