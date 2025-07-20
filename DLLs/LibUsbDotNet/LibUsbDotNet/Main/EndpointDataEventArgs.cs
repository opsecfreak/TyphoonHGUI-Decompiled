// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Main.EndpointDataEventArgs
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System;

#nullable disable
namespace LibUsbDotNet.Main;

public class EndpointDataEventArgs : EventArgs
{
  private readonly byte[] mBytesReceived;
  private readonly int mCount;

  internal EndpointDataEventArgs(byte[] bytes, int size)
  {
    this.mBytesReceived = bytes;
    this.mCount = size;
  }

  public byte[] Buffer => this.mBytesReceived;

  public int Count => this.mCount;
}
