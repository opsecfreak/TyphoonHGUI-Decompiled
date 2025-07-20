// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Main.UsbSetupPacket
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.Main;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct UsbSetupPacket(
  byte requestType,
  byte request,
  short value,
  short index,
  short length)
{
  public byte RequestType = requestType;
  public byte Request = request;
  public short Value = value;
  public short Index = index;
  public short Length = length;
}
