// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Internal.NativeFileShare
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System;

#nullable disable
namespace LibUsbDotNet.Internal;

[Flags]
internal enum NativeFileShare : uint
{
  NONE = 0,
  FILE_SHARE_READ = 1,
  FILE_SHARE_WRITE = 2,
  FILE_SHARE_DEELETE = 4,
}
