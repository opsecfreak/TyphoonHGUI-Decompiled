// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.DeviceNotify.WindowsDeviceNotifier
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.DeviceNotify.Internal;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace LibUsbDotNet.DeviceNotify;

public class WindowsDeviceNotifier : IDeviceNotifier
{
  private readonly DevBroadcastDeviceinterface mDevInterface = new DevBroadcastDeviceinterface(new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED"));
  private SafeNotifyHandle mDevInterfaceHandle;
  private bool mEnabled = true;
  private DevNotifyNativeWindow mNotifyWindow;

  public WindowsDeviceNotifier()
  {
    this.mNotifyWindow = new DevNotifyNativeWindow(new DevNotifyNativeWindow.OnHandleChangeDelegate(this.OnHandleChange), new DevNotifyNativeWindow.OnDeviceChangeDelegate(this.OnDeviceChange));
  }

  public bool Enabled
  {
    get => this.mEnabled;
    set => this.mEnabled = value;
  }

  public event EventHandler<DeviceNotifyEventArgs> OnDeviceNotify;

  [DllImport("user32.dll", EntryPoint = "RegisterDeviceNotificationA", CharSet = CharSet.Ansi, SetLastError = true)]
  private static extern SafeNotifyHandle RegisterDeviceNotification(
    IntPtr hRecipient,
    [MarshalAs(UnmanagedType.AsAny), In] object notificationFilter,
    int flags);

  [DllImport("user32.dll", SetLastError = true)]
  internal static extern bool UnregisterDeviceNotification(IntPtr handle);

  ~WindowsDeviceNotifier()
  {
    if (this.mNotifyWindow != null)
      this.mNotifyWindow.DestroyHandle();
    this.mNotifyWindow = (DevNotifyNativeWindow) null;
    if (this.mDevInterfaceHandle != null)
      this.mDevInterfaceHandle.Dispose();
    this.mDevInterfaceHandle = (SafeNotifyHandle) null;
  }

  internal bool RegisterDeviceInterface(IntPtr windowHandle)
  {
    if (this.mDevInterfaceHandle != null)
    {
      this.mDevInterfaceHandle.Dispose();
      this.mDevInterfaceHandle = (SafeNotifyHandle) null;
    }
    if (!(windowHandle != IntPtr.Zero))
      return false;
    this.mDevInterfaceHandle = WindowsDeviceNotifier.RegisterDeviceNotification(windowHandle, (object) this.mDevInterface, 0);
    return this.mDevInterfaceHandle != null && !this.mDevInterfaceHandle.IsInvalid;
  }

  private void OnDeviceChange(ref Message m)
  {
    if (!this.mEnabled)
      return;
    IntPtr num = m.LParam;
    if (num.ToInt32() == 0)
      return;
    EventHandler<DeviceNotifyEventArgs> onDeviceNotify = this.OnDeviceNotify;
    if (onDeviceNotify == null)
      return;
    DevBroadcastHdr structure = new DevBroadcastHdr();
    Marshal.PtrToStructure(m.LParam, (object) structure);
    DeviceNotifyEventArgs e;
    switch (structure.DeviceType)
    {
      case DeviceType.Volume:
      case DeviceType.Port:
      case DeviceType.DeviceInterface:
        DevBroadcastHdr hdr = structure;
        IntPtr lparam = m.LParam;
        num = m.WParam;
        int int32 = num.ToInt32();
        e = (DeviceNotifyEventArgs) new WindowsDeviceNotifyEventArgs(hdr, lparam, (EventType) int32);
        break;
      default:
        e = (DeviceNotifyEventArgs) null;
        break;
    }
    if (e == null)
      return;
    onDeviceNotify((object) this, e);
  }

  private void OnHandleChange(IntPtr newWindowHandle)
  {
    this.RegisterDeviceInterface(newWindowHandle);
  }
}
