// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.PollfdAddedDelegate
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace MonoLibUsb;

[UnmanagedFunctionPointer((CallingConvention) 0)]
public delegate void PollfdAddedDelegate(int fd, short events, IntPtr user_data);
