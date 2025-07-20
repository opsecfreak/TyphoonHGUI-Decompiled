// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Internal.UsbRegex.RegSymbolicName
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

#nullable disable
namespace LibUsbDotNet.Internal.UsbRegex;

internal class RegSymbolicName : BaseRegSymbolicName
{
  public static readonly NamedGroup[] NamedGroups = new NamedGroup[5]
  {
    new NamedGroup(1, "Vid"),
    new NamedGroup(2, "Pid"),
    new NamedGroup(3, "Rev"),
    new NamedGroup(4, "ClassGuid"),
    new NamedGroup(5, "String")
  };

  public new string[] GetGroupNames()
  {
    return new string[5]
    {
      "Vid",
      "Pid",
      "Rev",
      "ClassGuid",
      "String"
    };
  }

  public new int[] GetGroupNumbers()
  {
    return new int[5]{ 1, 2, 3, 4, 5 };
  }

  public new string GroupNameFromNumber(int groupNumber)
  {
    switch (groupNumber)
    {
      case 1:
        return "Vid";
      case 2:
        return "Pid";
      case 3:
        return "Rev";
      case 4:
        return "ClassGuid";
      case 5:
        return "String";
      default:
        return "";
    }
  }

  public new int GroupNumberFromName(string groupName)
  {
    switch (groupName.ToLower())
    {
      case "vid":
        return 1;
      case "pid":
        return 2;
      case "rev":
        return 3;
      case "classguid":
        return 4;
      case "string":
        return 5;
      default:
        return -1;
    }
  }
}
