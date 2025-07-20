// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Main.Helper
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace LibUsbDotNet.Main;

public static class Helper
{
  private static object mIsLinux;
  private static OperatingSystem mOs;

  public static OperatingSystem OSVersion
  {
    get
    {
      if (Helper.mOs == null)
        Helper.mOs = Environment.OSVersion;
      return Helper.mOs;
    }
  }

  public static bool IsLinux
  {
    get
    {
      if (Helper.mIsLinux == null)
      {
        switch (Helper.OSVersion.Platform.ToString())
        {
          case "MacOSX":
          case "Unix":
            Helper.mIsLinux = (object) true;
            break;
          case "Win32NT":
          case "Win32S":
          case "Win32Windows":
          case "WinCE":
          case "Xbox":
            Helper.mIsLinux = (object) false;
            break;
          default:
            throw new NotSupportedException($"Operating System:{Helper.OSVersion} not supported.");
        }
      }
      return (bool) Helper.mIsLinux;
    }
  }

  public static void BytesToObject(
    byte[] sourceBytes,
    int iStartIndex,
    int iLength,
    object destObject)
  {
    GCHandle gcHandle = GCHandle.Alloc(destObject, GCHandleType.Pinned);
    IntPtr destination = gcHandle.AddrOfPinnedObject();
    Marshal.Copy(sourceBytes, iStartIndex, destination, iLength);
    gcHandle.Free();
  }

  public static Dictionary<string, int> GetEnumData(Type type)
  {
    Dictionary<string, int> enumData = new Dictionary<string, int>();
    FieldInfo[] fields = type.GetFields();
    for (int index = 1; index < fields.Length; ++index)
    {
      object rawConstantValue = fields[index].GetRawConstantValue();
      enumData.Add(fields[index].Name, Convert.ToInt32(rawConstantValue));
    }
    return enumData;
  }

  public static short HostEndianToLE16(short swapValue)
  {
    return (short) new Helper.HostEndian16BitValue(swapValue).U16;
  }

  public static string ShowAsHex(object standardValue)
  {
    switch (standardValue)
    {
      case null:
        return "";
      case long num1:
        return "0x" + num1.ToString("X16");
      case uint num2:
        return "0x" + num2.ToString("X8");
      case int num3:
        return "0x" + num3.ToString("X8");
      case ushort num4:
        return "0x" + num4.ToString("X4");
      case short num5:
        return "0x" + num5.ToString("X4");
      case byte num6:
        return "0x" + num6.ToString("X2");
      case string _:
        return Helper.HexString(standardValue as byte[], "", " ");
      default:
        return "";
    }
  }

  public static string ToString(
    string sep0,
    string[] names,
    string sep1,
    object[] values,
    string sep2)
  {
    StringBuilder stringBuilder = new StringBuilder();
    for (int index = 0; index < names.Length; ++index)
      stringBuilder.Append(sep0 + names[index] + sep1 + values[index] + sep2);
    return stringBuilder.ToString();
  }

  public static string HexString(byte[] data, string prefix, string suffix)
  {
    if (prefix == null)
      prefix = string.Empty;
    if (suffix == null)
      suffix = string.Empty;
    StringBuilder stringBuilder = new StringBuilder(data.Length * 2 + data.Length * prefix.Length + data.Length * suffix.Length);
    foreach (byte num in data)
      stringBuilder.Append(prefix + num.ToString("X2") + suffix);
    return stringBuilder.ToString();
  }

  [StructLayout(LayoutKind.Explicit, Pack = 1)]
  internal struct HostEndian16BitValue(short x)
  {
    [FieldOffset(0)]
    public readonly ushort U16 = 0;
    [FieldOffset(0)]
    public readonly byte B0 = (byte) ((uint) x & (uint) byte.MaxValue);
    [FieldOffset(1)]
    public readonly byte B1 = (byte) ((uint) x >> 8);
  }
}
