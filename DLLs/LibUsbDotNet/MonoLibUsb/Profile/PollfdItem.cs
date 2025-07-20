// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.Profile.PollfdItem
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace MonoLibUsb.Profile;

[StructLayout(LayoutKind.Sequential)]
public class PollfdItem
{
  public readonly int fd;
  public readonly short events;

  internal PollfdItem(IntPtr pPollfd) => Marshal.PtrToStructure(pPollfd, (object) this);
}
