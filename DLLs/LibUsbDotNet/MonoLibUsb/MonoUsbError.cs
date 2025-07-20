// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.MonoUsbError
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

#nullable disable
namespace MonoLibUsb;

public enum MonoUsbError
{
  ErrorOther = -99, // 0xFFFFFF9D
  ErrorIOCancelled = -13, // 0xFFFFFFF3
  ErrorNotSupported = -12, // 0xFFFFFFF4
  ErrorNoMem = -11, // 0xFFFFFFF5
  ErrorInterrupted = -10, // 0xFFFFFFF6
  ErrorPipe = -9, // 0xFFFFFFF7
  ErrorOverflow = -8, // 0xFFFFFFF8
  ErrorTimeout = -7, // 0xFFFFFFF9
  ErrorBusy = -6, // 0xFFFFFFFA
  ErrorNotFound = -5, // 0xFFFFFFFB
  ErrorNoDevice = -4, // 0xFFFFFFFC
  ErrorAccess = -3, // 0xFFFFFFFD
  ErrorInvalidParam = -2, // 0xFFFFFFFE
  ErrorIO = -1, // 0xFFFFFFFF
  Success = 0,
}
