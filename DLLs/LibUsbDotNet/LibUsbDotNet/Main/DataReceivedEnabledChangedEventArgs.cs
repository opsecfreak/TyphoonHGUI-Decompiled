// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Main.DataReceivedEnabledChangedEventArgs
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System;

#nullable disable
namespace LibUsbDotNet.Main;

public class DataReceivedEnabledChangedEventArgs : EventArgs
{
  private readonly bool mEnabled;
  private readonly ErrorCode mErrorCode;

  internal DataReceivedEnabledChangedEventArgs(bool enabled, ErrorCode errorCode)
  {
    this.mEnabled = enabled;
    this.mErrorCode = errorCode;
  }

  internal DataReceivedEnabledChangedEventArgs(bool enabled)
    : this(enabled, ErrorCode.None)
  {
  }

  public ErrorCode ErrorCode => this.mErrorCode;

  public bool Enabled => this.mEnabled;
}
