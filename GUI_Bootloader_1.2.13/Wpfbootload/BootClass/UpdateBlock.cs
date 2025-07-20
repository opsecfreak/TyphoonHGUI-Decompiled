// Decompiled with JetBrains decompiler
// Type: Wpfbootload.BootClass.UpdateBlock
// Assembly: Wpfbootload, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4FEF84E1-06E0-4569-8BB0-07C571E890DC
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\Wpfbootload.exe

#nullable disable
namespace Wpfbootload.BootClass;

public enum UpdateBlock
{
  None = 0,
  Sync = 32, // 0x00000020
  Erase = 33, // 0x00000021
  Program = 34, // 0x00000022
  CRC = 35, // 0x00000023
  Reboot = 36, // 0x00000024
}
