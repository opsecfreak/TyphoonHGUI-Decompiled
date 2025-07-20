// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.UsbError
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Internal;
using LibUsbDotNet.Main;
using MonoLibUsb;
using System;

#nullable disable
namespace LibUsbDotNet;

public class UsbError : EventArgs
{
  internal static int mLastErrorNumber;
  internal static string mLastErrorString = string.Empty;
  internal string mDescription;
  internal ErrorCode mErrorCode;
  private object mSender;
  internal int mWin32ErrorNumber;
  internal string mWin32ErrorString = "None";

  internal UsbError(
    ErrorCode errorCode,
    int win32ErrorNumber,
    string win32ErrorString,
    string description,
    object sender)
  {
    this.mSender = sender;
    string str1 = string.Empty;
    string str2;
    if (this.mSender is UsbEndpointBase || this.mSender is UsbTransfer)
    {
      UsbEndpointBase usbEndpointBase = !(this.mSender is UsbTransfer) ? this.mSender as UsbEndpointBase : ((UsbTransfer) this.mSender).EndpointBase;
      if (usbEndpointBase.mEpNum != (byte) 0)
        str1 = str2 = str1 + $" Ep 0x{usbEndpointBase.mEpNum:X2} ";
    }
    else if ((object) (this.mSender as Type) != null)
    {
      Type mSender = this.mSender as Type;
      str1 = str2 = str1 + $" {mSender.Name} ";
    }
    this.mErrorCode = errorCode;
    this.mWin32ErrorNumber = win32ErrorNumber;
    this.mWin32ErrorString = win32ErrorString;
    this.mDescription = description + str1;
  }

  public object Sender => this.mSender;

  public ErrorCode ErrorCode => this.mErrorCode;

  public int Win32ErrorNumber => this.mWin32ErrorNumber;

  public string Description => this.mDescription;

  public string Win32ErrorString => this.mWin32ErrorString;

  public override string ToString()
  {
    if (this.Win32ErrorNumber == 0)
      return $"{this.ErrorCode}:{this.Description}";
    return $"{this.ErrorCode}:{this.Description}\r\n{this.Win32ErrorNumber}:{this.mWin32ErrorString}";
  }

  internal static UsbError Error(ErrorCode errorCode, int ret, string description, object sender)
  {
    string win32ErrorString = string.Empty;
    if (errorCode == ErrorCode.Win32Error && !UsbDevice.IsLinux && ret != 0)
      win32ErrorString = Kernel32.FormatSystemMessage(ret);
    else if (errorCode == ErrorCode.MonoApiError && ret != 0)
      win32ErrorString = $"{(object) (MonoUsbError) ret}:{MonoUsbApi.StrError((MonoUsbError) ret)}";
    UsbError usbError = new UsbError(errorCode, ret, win32ErrorString, description, sender);
    lock (UsbError.mLastErrorString)
    {
      UsbError.mLastErrorNumber = (int) usbError.ErrorCode;
      UsbError.mLastErrorString = usbError.ToString();
    }
    UsbDevice.FireUsbError(sender, usbError);
    return usbError;
  }
}
