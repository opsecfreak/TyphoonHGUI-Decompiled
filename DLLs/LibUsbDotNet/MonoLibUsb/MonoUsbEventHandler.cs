// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.MonoUsbEventHandler
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Main;
using System.Threading;

#nullable disable
namespace MonoLibUsb;

public static class MonoUsbEventHandler
{
  private static readonly ManualResetEvent mIsStoppedEvent = new ManualResetEvent(true);
  private static bool mRunning;
  private static MonoUsbSessionHandle mSessionHandle;
  internal static Thread mUsbEventThread;
  private static ThreadPriority mPriority = ThreadPriority.Normal;
  private static UnixNativeTimeval mWaitUnixNativeTimeval;

  public static MonoUsbSessionHandle SessionHandle => MonoUsbEventHandler.mSessionHandle;

  public static bool IsStopped => MonoUsbEventHandler.mIsStoppedEvent.WaitOne(0, false);

  public static ThreadPriority Priority
  {
    get => MonoUsbEventHandler.mPriority;
    set => MonoUsbEventHandler.mPriority = value;
  }

  public static void Exit()
  {
    MonoUsbEventHandler.Stop(true);
    if (MonoUsbEventHandler.mSessionHandle == null || MonoUsbEventHandler.mSessionHandle.IsInvalid)
      return;
    MonoUsbEventHandler.mSessionHandle.Close();
    MonoUsbEventHandler.mSessionHandle = (MonoUsbSessionHandle) null;
  }

  private static void HandleEventFn(object oHandle)
  {
    MonoUsbSessionHandle sessionHandle = oHandle as MonoUsbSessionHandle;
    MonoUsbEventHandler.mIsStoppedEvent.Reset();
    while (MonoUsbEventHandler.mRunning)
      MonoUsbApi.HandleEventsTimeout(sessionHandle, ref MonoUsbEventHandler.mWaitUnixNativeTimeval);
    MonoUsbEventHandler.mIsStoppedEvent.Set();
  }

  public static void Init(long tvSec, long tvUsec)
  {
    MonoUsbEventHandler.Init(new UnixNativeTimeval(tvSec, tvUsec));
  }

  public static void Init() => MonoUsbEventHandler.Init(UnixNativeTimeval.Default);

  private static void Init(UnixNativeTimeval unixNativeTimeval)
  {
    if (!MonoUsbEventHandler.IsStopped || MonoUsbEventHandler.mRunning || MonoUsbEventHandler.mSessionHandle != null)
      return;
    MonoUsbEventHandler.mWaitUnixNativeTimeval = unixNativeTimeval;
    MonoUsbEventHandler.mSessionHandle = new MonoUsbSessionHandle();
    if (MonoUsbEventHandler.mSessionHandle.IsInvalid)
    {
      MonoUsbEventHandler.mSessionHandle = (MonoUsbSessionHandle) null;
      throw new UsbException((object) typeof (MonoUsbApi), string.Format("Init:libusb_init Failed:Invalid Session Handle"));
    }
  }

  public static bool Start()
  {
    if (MonoUsbEventHandler.IsStopped && !MonoUsbEventHandler.mRunning && MonoUsbEventHandler.mSessionHandle != null)
    {
      MonoUsbEventHandler.mRunning = true;
      MonoUsbEventHandler.mUsbEventThread = new Thread(new ParameterizedThreadStart(MonoUsbEventHandler.HandleEventFn));
      MonoUsbEventHandler.mUsbEventThread.Priority = MonoUsbEventHandler.mPriority;
      MonoUsbEventHandler.mUsbEventThread.Start((object) MonoUsbEventHandler.mSessionHandle);
    }
    return true;
  }

  public static void Stop(bool bWait)
  {
    if (MonoUsbEventHandler.IsStopped || !MonoUsbEventHandler.mRunning)
      return;
    MonoUsbEventHandler.mRunning = false;
    if (bWait && !MonoUsbEventHandler.mUsbEventThread.Join((int) ((double) (MonoUsbEventHandler.mWaitUnixNativeTimeval.tv_sec * 1000L + MonoUsbEventHandler.mWaitUnixNativeTimeval.tv_usec) * 1.2)))
    {
      MonoUsbEventHandler.mUsbEventThread.Abort();
      throw new UsbException((object) typeof (MonoUsbEventHandler), "Critical timeout failure! MonoUsbApi.HandleEventsTimeout did not return within the allotted time.");
    }
    MonoUsbEventHandler.mUsbEventThread = (Thread) null;
  }
}
