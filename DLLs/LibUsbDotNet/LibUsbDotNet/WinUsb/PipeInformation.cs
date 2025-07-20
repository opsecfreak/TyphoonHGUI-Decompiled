// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.WinUsb.PipeInformation
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Main;
using System.Runtime.InteropServices;

#nullable disable
namespace LibUsbDotNet.WinUsb;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class PipeInformation
{
  public static readonly int Size = Marshal.SizeOf(typeof (PipeInformation));
  public EndpointType PipeType;
  public byte PipeId;
  public short MaximumPacketSize;
  public byte Interval;
}
