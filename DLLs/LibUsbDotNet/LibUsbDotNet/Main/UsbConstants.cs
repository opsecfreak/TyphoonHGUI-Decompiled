// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Main.UsbConstants
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

#nullable disable
namespace LibUsbDotNet.Main;

public static class UsbConstants
{
  public const int DEFAULT_TIMEOUT = 1000;
  internal const bool EXIT_CONTEXT = false;
  public const int MAX_CONFIG_SIZE = 4096 /*0x1000*/;
  public const int MAX_DEVICES = 128 /*0x80*/;
  public const int MAX_ENDPOINTS = 32 /*0x20*/;
  public const byte ENDPOINT_DIR_MASK = 128 /*0x80*/;
  public const byte ENDPOINT_NUMBER_MASK = 15;
}
