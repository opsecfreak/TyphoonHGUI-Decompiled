// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Internal.UsbRegex.RegHardwareID
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System.Text.RegularExpressions;

#nullable disable
namespace LibUsbDotNet.Internal.UsbRegex;

internal class RegHardwareID : Regex
{
  private const RegexOptions OPTIONS = RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace | RegexOptions.CultureInvariant;
  private const string PATTERN = "(Vid_(?<Vid>[0-9A-F]{1,4}))|(Pid_(?<Pid>[0-9A-F]{1,4}))|(Rev_(?<Rev>[0-9]{1,4}))|(MI_(?<MI>[0-9A-F]{1,2}))";
  public static readonly NamedGroup[] NAMED_GROUPS = new NamedGroup[4]
  {
    new NamedGroup(1, "Vid"),
    new NamedGroup(2, "Pid"),
    new NamedGroup(3, "Rev"),
    new NamedGroup(4, "MI")
  };
  private static RegHardwareID __globalInstance;

  public RegHardwareID()
    : base("(Vid_(?<Vid>[0-9A-F]{1,4}))|(Pid_(?<Pid>[0-9A-F]{1,4}))|(Rev_(?<Rev>[0-9]{1,4}))|(MI_(?<MI>[0-9A-F]{1,2}))", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace | RegexOptions.CultureInvariant)
  {
  }

  public static RegHardwareID GlobalInstance
  {
    get
    {
      if (RegHardwareID.__globalInstance == null)
        RegHardwareID.__globalInstance = new RegHardwareID();
      return RegHardwareID.__globalInstance;
    }
  }

  public new string[] GetGroupNames()
  {
    return new string[4]{ "Vid", "Pid", "Rev", "MI" };
  }

  public new int[] GetGroupNumbers()
  {
    return new int[4]{ 1, 2, 3, 4 };
  }

  public new string GroupNameFromNumber(int GroupNumber)
  {
    switch (GroupNumber)
    {
      case 1:
        return "Vid";
      case 2:
        return "Pid";
      case 3:
        return "Rev";
      case 4:
        return "MI";
      default:
        return "";
    }
  }

  public new int GroupNumberFromName(string GroupName)
  {
    switch (GroupName)
    {
      case "Vid":
        return 1;
      case "Pid":
        return 2;
      case "Rev":
        return 3;
      case "MI":
        return 4;
      default:
        return -1;
    }
  }

  public enum ENamedGroups
  {
    Vid = 1,
    Pid = 2,
    Rev = 3,
    MI = 4,
  }
}
