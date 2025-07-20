// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Main.UsbSymbolicName
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Internal.UsbRegex;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

#nullable disable
namespace LibUsbDotNet.Main;

public class UsbSymbolicName
{
  private static RegHardwareID _regHardwareId;
  private static RegSymbolicName _regSymbolicName;
  private readonly string mSymbolicName;
  private Guid mClassGuid = Guid.Empty;
  private bool mIsParsed;
  private int mProductID;
  private int mRevisionCode;
  private string mSerialNumber = string.Empty;
  private int mVendorID;

  internal UsbSymbolicName(string symbolicName) => this.mSymbolicName = symbolicName;

  private static RegSymbolicName RegSymbolicName
  {
    get
    {
      if (UsbSymbolicName._regSymbolicName == null)
        UsbSymbolicName._regSymbolicName = new RegSymbolicName();
      return UsbSymbolicName._regSymbolicName;
    }
  }

  private static RegHardwareID RegHardwareId
  {
    get
    {
      if (UsbSymbolicName._regHardwareId == null)
        UsbSymbolicName._regHardwareId = new RegHardwareID();
      return UsbSymbolicName._regHardwareId;
    }
  }

  public string FullName
  {
    get
    {
      if (this.mSymbolicName == null)
        return string.Empty;
      return this.mSymbolicName.TrimStart('\\', '?');
    }
  }

  public int Vid
  {
    get
    {
      this.Parse();
      return this.mVendorID;
    }
  }

  public int Pid
  {
    get
    {
      this.Parse();
      return this.mProductID;
    }
  }

  public string SerialNumber
  {
    get
    {
      this.Parse();
      return this.mSerialNumber;
    }
  }

  public Guid ClassGuid
  {
    get
    {
      this.Parse();
      return this.mClassGuid;
    }
  }

  public int Rev
  {
    get
    {
      this.Parse();
      return this.mRevisionCode;
    }
  }

  public static UsbSymbolicName Parse(string identifiers) => new UsbSymbolicName(identifiers);

  public override string ToString()
  {
    return $"FullName:{this.FullName}\r\nVid:0x{this.Vid.ToString("X4")}\r\nPid:0x{this.Pid.ToString("X4")}\r\nSerialNumber:{this.SerialNumber}\r\nClassGuid:{this.ClassGuid}\r\n";
  }

  private void Parse()
  {
    if (this.mIsParsed)
      return;
    this.mIsParsed = true;
    if (this.mSymbolicName == null)
      return;
    foreach (Match match in UsbSymbolicName.RegSymbolicName.Matches(this.mSymbolicName))
    {
      Group group1 = match.Groups[1];
      Group group2 = match.Groups[2];
      Group group3 = match.Groups[3];
      Group group4 = match.Groups[5];
      Group group5 = match.Groups[4];
      if (group1.Success && this.mVendorID == 0)
        int.TryParse(group1.Captures[0].Value, NumberStyles.HexNumber, (IFormatProvider) null, out this.mVendorID);
      if (group2.Success && this.mProductID == 0)
        int.TryParse(group2.Captures[0].Value, NumberStyles.HexNumber, (IFormatProvider) null, out this.mProductID);
      if (group3.Success && this.mRevisionCode == 0)
        int.TryParse(group3.Captures[0].Value, out this.mRevisionCode);
      if (group4.Success && this.mSerialNumber == string.Empty)
        this.mSerialNumber = group4.Captures[0].Value;
      if (group5.Success)
      {
        if (this.mClassGuid == Guid.Empty)
        {
          try
          {
            this.mClassGuid = new Guid(group5.Captures[0].Value);
          }
          catch (Exception ex)
          {
            this.mClassGuid = Guid.Empty;
          }
        }
      }
    }
  }
}
