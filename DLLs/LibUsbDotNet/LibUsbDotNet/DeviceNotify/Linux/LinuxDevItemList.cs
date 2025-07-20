// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.DeviceNotify.Linux.LinuxDevItemList
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System.Collections.Generic;

#nullable disable
namespace LibUsbDotNet.DeviceNotify.Linux;

internal class LinuxDevItemList : List<LinuxDevItem>
{
  public LinuxDevItem FindByName(string deviceFileName)
  {
    foreach (LinuxDevItem byName in (List<LinuxDevItem>) this)
    {
      if (byName.DeviceFileName == deviceFileName)
        return byName;
    }
    return (LinuxDevItem) null;
  }
}
