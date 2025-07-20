// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.Transfer.Internal.libusb_control_setup
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System.Runtime.InteropServices;

#nullable disable
namespace MonoLibUsb.Transfer.Internal;

[StructLayout(LayoutKind.Sequential)]
internal class libusb_control_setup
{
  public readonly byte bmRequestType;
  public readonly byte bRequest;
  public readonly short wValue;
  public readonly short wIndex;
  public readonly short wLength;
}
