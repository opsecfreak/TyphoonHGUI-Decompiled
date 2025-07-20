// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.DeviceNotify.Internal.DevNotifyNativeWindow
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System;
using System.Windows.Forms;

#nullable disable
namespace LibUsbDotNet.DeviceNotify.Internal;

internal sealed class DevNotifyNativeWindow : NativeWindow
{
  private const string WINDOW_CAPTION = "{18662f14-0871-455c-bf99-eff135425e3a}";
  private const int WM_DEVICECHANGE = 537;
  private readonly DevNotifyNativeWindow.OnDeviceChangeDelegate mDelDeviceChange;
  private readonly DevNotifyNativeWindow.OnHandleChangeDelegate mDelHandleChanged;

  internal DevNotifyNativeWindow(
    DevNotifyNativeWindow.OnHandleChangeDelegate delHandleChanged,
    DevNotifyNativeWindow.OnDeviceChangeDelegate delDeviceChange)
  {
    this.mDelHandleChanged = delHandleChanged;
    this.mDelDeviceChange = delDeviceChange;
    this.CreateHandle(new CreateParams()
    {
      Caption = "{18662f14-0871-455c-bf99-eff135425e3a}",
      X = -100,
      Y = -100,
      Width = 50,
      Height = 50
    });
  }

  protected override void OnHandleChange()
  {
    this.mDelHandleChanged(this.Handle);
    base.OnHandleChange();
  }

  protected override void WndProc(ref Message m)
  {
    if (m.Msg == 537)
      this.mDelDeviceChange(ref m);
    base.WndProc(ref m);
  }

  internal delegate void OnDeviceChangeDelegate(ref Message m);

  internal delegate void OnHandleChangeDelegate(IntPtr windowHandle);
}
