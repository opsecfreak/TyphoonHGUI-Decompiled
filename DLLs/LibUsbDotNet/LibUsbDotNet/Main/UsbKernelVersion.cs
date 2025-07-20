// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Main.UsbKernelVersion
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.Main;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct UsbKernelVersion
{
  public readonly int Major;
  public readonly int Minor;
  public readonly int Micro;
  public readonly int Nano;
  public readonly int BcdLibUsbDotNetKernelMod;

  public bool IsEmpty => this.Major == 0 && this.Minor == 0 && this.Micro == 0 && this.Nano == 0;

  internal UsbKernelVersion(
    int major,
    int minor,
    int micro,
    int nano,
    int bcdLibUsbDotNetKernelMod)
  {
    this.Major = major;
    this.Minor = minor;
    this.Micro = micro;
    this.Nano = nano;
    this.BcdLibUsbDotNetKernelMod = bcdLibUsbDotNetKernelMod;
  }

  public override string ToString() => $"{this.Major}.{this.Minor}.{this.Micro}.{this.Nano}";
}
