// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Internal.LibUsb.BusQueryID
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.Internal.LibUsb;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct BusQueryID
{
  public ushort IDType;
}
