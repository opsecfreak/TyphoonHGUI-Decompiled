// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.MonoUsbApi
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.LudnMonoLibUsb;
using LibUsbDotNet.Main;
using MonoLibUsb.Descriptors;
using MonoLibUsb.Profile;
using MonoLibUsb.Transfer;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

#nullable disable
namespace MonoLibUsb;

public static class MonoUsbApi
{
  internal const CallingConvention CC = (CallingConvention) 0;
  internal const string LIBUSB_DLL = "libusb-1.0.dll";
  internal const int LIBUSB_PACK = 0;
  private static readonly MonoUsbTransferDelegate DefaultAsyncDelegate = new MonoUsbTransferDelegate(MonoUsbApi.DefaultAsyncCB);

  private static void DefaultAsyncCB(MonoUsbTransfer transfer)
  {
    (GCHandle.FromIntPtr(transfer.PtrUserData).Target as ManualResetEvent).Set();
  }

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_init")]
  internal static extern int Init(ref IntPtr pContext);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_exit")]
  internal static extern void Exit(IntPtr pContext);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_set_debug")]
  public static extern void SetDebug([In] MonoUsbSessionHandle sessionHandle, int level);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_get_device_list")]
  public static extern int GetDeviceList(
    [In] MonoUsbSessionHandle sessionHandle,
    out MonoUsbProfileListHandle monoUSBProfileListHandle);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_free_device_list")]
  internal static extern void FreeDeviceList(IntPtr pHandleList, int unrefDevices);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_get_bus_number")]
  public static extern byte GetBusNumber([In] MonoUsbProfileHandle deviceProfileHandle);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_get_device_address")]
  public static extern byte GetDeviceAddress([In] MonoUsbProfileHandle deviceProfileHandle);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_get_max_packet_size")]
  public static extern int GetMaxPacketSize([In] MonoUsbProfileHandle deviceProfileHandle, byte endpoint);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_get_max_iso_packet_size")]
  public static extern int GetMaxIsoPacketSize(
    [In] MonoUsbProfileHandle deviceProfileHandle,
    byte endpoint);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_ref_device")]
  internal static extern IntPtr RefDevice(IntPtr pDeviceProfileHandle);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_unref_device")]
  internal static extern IntPtr UnrefDevice(IntPtr pDeviceProfileHandle);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_open")]
  internal static extern int Open([In] MonoUsbProfileHandle deviceProfileHandle, ref IntPtr deviceHandle);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_open_device_with_vid_pid")]
  private static extern IntPtr OpenDeviceWithVidPidInternal(
    [In] MonoUsbSessionHandle sessionHandle,
    short vendorID,
    short productID);

  public static MonoUsbDeviceHandle OpenDeviceWithVidPid(
    [In] MonoUsbSessionHandle sessionHandle,
    short vendorID,
    short productID)
  {
    IntPtr pDeviceHandle = MonoUsbApi.OpenDeviceWithVidPidInternal(sessionHandle, vendorID, productID);
    return pDeviceHandle == IntPtr.Zero ? (MonoUsbDeviceHandle) null : new MonoUsbDeviceHandle(pDeviceHandle);
  }

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_close")]
  internal static extern void Close(IntPtr deviceHandle);

  public static MonoUsbProfileHandle GetDevice(MonoUsbDeviceHandle devicehandle)
  {
    return new MonoUsbProfileHandle(MonoUsbApi.GetDeviceInternal(devicehandle));
  }

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_get_device")]
  private static extern IntPtr GetDeviceInternal([In] MonoUsbDeviceHandle devicehandle);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_get_configuration")]
  public static extern int GetConfiguration([In] MonoUsbDeviceHandle deviceHandle, ref int configuration);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_set_configuration")]
  public static extern int SetConfiguration([In] MonoUsbDeviceHandle deviceHandle, int configuration);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_claim_interface")]
  public static extern int ClaimInterface([In] MonoUsbDeviceHandle deviceHandle, int interfaceNumber);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_release_interface")]
  public static extern int ReleaseInterface([In] MonoUsbDeviceHandle deviceHandle, int interfaceNumber);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_set_interface_alt_setting")]
  public static extern int SetInterfaceAltSetting(
    [In] MonoUsbDeviceHandle deviceHandle,
    int interfaceNumber,
    int alternateSetting);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_clear_halt")]
  public static extern int ClearHalt([In] MonoUsbDeviceHandle deviceHandle, byte endpoint);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_reset_device")]
  public static extern int ResetDevice([In] MonoUsbDeviceHandle deviceHandle);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_kernel_driver_active")]
  public static extern int KernelDriverActive([In] MonoUsbDeviceHandle deviceHandle, int interfaceNumber);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_detach_kernel_driver")]
  public static extern int DetachKernelDriver([In] MonoUsbDeviceHandle deviceHandle, int interfaceNumber);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_attach_kernel_driver")]
  public static extern int AttachKernelDriver([In] MonoUsbDeviceHandle deviceHandle, int interfaceNumber);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_get_device_descriptor")]
  public static extern int GetDeviceDescriptor(
    [In] MonoUsbProfileHandle deviceProfileHandle,
    [Out] MonoUsbDeviceDescriptor deviceDescriptor);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_get_active_config_descriptor")]
  public static extern int GetActiveConfigDescriptor(
    [In] MonoUsbProfileHandle deviceProfileHandle,
    out MonoUsbConfigHandle configHandle);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_get_config_descriptor")]
  public static extern int GetConfigDescriptor(
    [In] MonoUsbProfileHandle deviceProfileHandle,
    byte configIndex,
    out MonoUsbConfigHandle configHandle);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_get_config_descriptor_by_value")]
  public static extern int GetConfigDescriptorByValue(
    [In] MonoUsbProfileHandle deviceProfileHandle,
    byte bConfigurationValue,
    out MonoUsbConfigHandle configHandle);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_free_config_descriptor")]
  internal static extern void FreeConfigDescriptor(IntPtr pConfigDescriptor);

  public static int GetDescriptor(
    MonoUsbDeviceHandle deviceHandle,
    byte descType,
    byte descIndex,
    IntPtr pData,
    int length)
  {
    return MonoUsbApi.ControlTransfer(deviceHandle, (byte) 128 /*0x80*/, (byte) 6, (short) ((int) descType << 8 | (int) descIndex), (short) 0, pData, (short) length, 1000);
  }

  public static int GetDescriptor(
    MonoUsbDeviceHandle deviceHandle,
    byte descType,
    byte descIndex,
    object data,
    int length)
  {
    PinnedHandle pinnedHandle = new PinnedHandle(data);
    return MonoUsbApi.GetDescriptor(deviceHandle, descType, descIndex, pinnedHandle.Handle, length);
  }

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_alloc_transfer")]
  internal static extern IntPtr AllocTransfer(int isoPackets);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_free_transfer")]
  internal static extern void FreeTransfer(IntPtr pTransfer);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_submit_transfer")]
  internal static extern int SubmitTransfer(IntPtr pTransfer);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_cancel_transfer")]
  internal static extern int CancelTransfer(IntPtr pTransfer);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_try_lock_events")]
  public static extern int TryLockEvents([In] MonoUsbSessionHandle sessionHandle);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_lock_events")]
  public static extern void LockEvents([In] MonoUsbSessionHandle sessionHandle);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_unlock_events")]
  public static extern void UnlockEvents([In] MonoUsbSessionHandle sessionHandle);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_event_handling_ok")]
  public static extern int EventHandlingOk([In] MonoUsbSessionHandle sessionHandle);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_event_handler_active")]
  public static extern int EventHandlerActive([In] MonoUsbSessionHandle sessionHandle);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_lock_event_waiters")]
  public static extern void LockEventWaiters([In] MonoUsbSessionHandle sessionHandle);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_unlock_event_waiters")]
  public static extern void UnlockEventWaiters([In] MonoUsbSessionHandle sessionHandle);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_wait_for_event")]
  public static extern int WaitForEvent(
    [In] MonoUsbSessionHandle sessionHandle,
    ref UnixNativeTimeval timeval);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_handle_events_timeout")]
  public static extern int HandleEventsTimeout(
    [In] MonoUsbSessionHandle sessionHandle,
    ref UnixNativeTimeval tv);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_handle_events")]
  public static extern int HandleEvents([In] MonoUsbSessionHandle sessionHandle);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_handle_events")]
  private static extern int HandleEvents(IntPtr pSessionHandle);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_handle_events_locked")]
  public static extern int HandleEventsLocked(
    [In] MonoUsbSessionHandle sessionHandle,
    ref UnixNativeTimeval tv);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_pollfds_handle_timeouts")]
  public static extern int PollfdsHandleTimeouts([In] MonoUsbSessionHandle sessionHandle);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_get_next_timeout")]
  public static extern int GetNextTimeout(
    [In] MonoUsbSessionHandle sessionHandle,
    ref UnixNativeTimeval tv);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_set_pollfd_notifiers")]
  public static extern void SetPollfdNotifiers(
    [In] MonoUsbSessionHandle sessionHandle,
    PollfdAddedDelegate addedDelegate,
    PollfdRemovedDelegate removedDelegate,
    IntPtr pUserData);

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_get_pollfds")]
  private static extern IntPtr GetPollfdsInternal([In] MonoUsbSessionHandle sessionHandle);

  public static List<PollfdItem> GetPollfds(MonoUsbSessionHandle sessionHandle)
  {
    List<PollfdItem> pollfds = new List<PollfdItem>();
    IntPtr pollfdsInternal = MonoUsbApi.GetPollfdsInternal(sessionHandle);
    if (pollfdsInternal == IntPtr.Zero)
      return (List<PollfdItem>) null;
    IntPtr pPollfd;
    for (IntPtr ptr = pollfdsInternal; ptr != IntPtr.Zero && (pPollfd = Marshal.ReadIntPtr(ptr)) != IntPtr.Zero; ptr = new IntPtr(ptr.ToInt64() + (long) IntPtr.Size))
    {
      PollfdItem pollfdItem = new PollfdItem(pPollfd);
      pollfds.Add(pollfdItem);
    }
    Marshal.FreeHGlobal(pollfdsInternal);
    return pollfds;
  }

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_control_transfer")]
  public static extern int ControlTransfer(
    [In] MonoUsbDeviceHandle deviceHandle,
    byte requestType,
    byte request,
    short value,
    short index,
    IntPtr pData,
    short dataLength,
    int timeout);

  public static int ControlTransferAsync(
    [In] MonoUsbDeviceHandle deviceHandle,
    byte requestType,
    byte request,
    short value,
    short index,
    IntPtr pData,
    short dataLength,
    int timeout)
  {
    MonoUsbControlSetupHandle controlSetupHandle = new MonoUsbControlSetupHandle(requestType, request, value, index, (object) pData, (int) dataLength);
    MonoUsbTransfer monoUsbTransfer = new MonoUsbTransfer(0);
    ManualResetEvent manualResetEvent = new ManualResetEvent(false);
    GCHandle gcHandle = GCHandle.Alloc((object) manualResetEvent);
    monoUsbTransfer.FillControl(deviceHandle, controlSetupHandle, (Delegate) MonoUsbApi.DefaultAsyncDelegate, GCHandle.ToIntPtr(gcHandle), timeout);
    int num1 = (int) monoUsbTransfer.Submit();
    if (num1 < 0)
    {
      monoUsbTransfer.Free();
      gcHandle.Free();
      return num1;
    }
    MonoUsbSessionHandle sessionHandle = MonoUsbEventHandler.SessionHandle;
    IntPtr pSessionHandle = sessionHandle != null ? sessionHandle.DangerousGetHandle() : IntPtr.Zero;
    if (MonoUsbEventHandler.IsStopped)
    {
      while (!manualResetEvent.WaitOne(0, false))
      {
        int num2 = MonoUsbApi.HandleEvents(pSessionHandle);
        if (num2 < 0 && num2 != -10)
        {
          int num3 = (int) monoUsbTransfer.Cancel();
          do
            ;
          while (!manualResetEvent.WaitOne(0, false) && MonoUsbApi.HandleEvents(pSessionHandle) >= 0);
          monoUsbTransfer.Free();
          gcHandle.Free();
          return num2;
        }
      }
    }
    else
      manualResetEvent.WaitOne(-1, false);
    int transferLength;
    if (monoUsbTransfer.Status == MonoUsbTansferStatus.TransferCompleted)
    {
      transferLength = monoUsbTransfer.ActualLength;
      if (transferLength > 0)
      {
        byte[] data = controlSetupHandle.ControlSetup.GetData(transferLength);
        Marshal.Copy(data, 0, pData, Math.Min(data.Length, (int) dataLength));
      }
    }
    else
      transferLength = (int) MonoUsbApi.MonoLibUsbErrorFromTransferStatus(monoUsbTransfer.Status);
    monoUsbTransfer.Free();
    gcHandle.Free();
    return transferLength;
  }

  public static int ControlTransfer(
    [In] MonoUsbDeviceHandle deviceHandle,
    byte requestType,
    byte request,
    short value,
    short index,
    object data,
    short dataLength,
    int timeout)
  {
    PinnedHandle pinnedHandle = new PinnedHandle(data);
    int num = MonoUsbApi.ControlTransfer(deviceHandle, requestType, request, value, index, pinnedHandle.Handle, dataLength, timeout);
    pinnedHandle.Dispose();
    return num;
  }

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_bulk_transfer")]
  public static extern int BulkTransfer(
    [In] MonoUsbDeviceHandle deviceHandle,
    byte endpoint,
    IntPtr pData,
    int length,
    out int actualLength,
    int timeout);

  public static int BulkTransfer(
    [In] MonoUsbDeviceHandle deviceHandle,
    byte endpoint,
    object data,
    int length,
    out int actualLength,
    int timeout)
  {
    PinnedHandle pinnedHandle = new PinnedHandle(data);
    int num = MonoUsbApi.BulkTransfer(deviceHandle, endpoint, pinnedHandle.Handle, length, out actualLength, timeout);
    pinnedHandle.Dispose();
    return num;
  }

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_interrupt_transfer")]
  public static extern int InterruptTransfer(
    [In] MonoUsbDeviceHandle deviceHandle,
    byte endpoint,
    IntPtr pData,
    int length,
    out int actualLength,
    int timeout);

  public static int InterruptTransfer(
    [In] MonoUsbDeviceHandle deviceHandle,
    byte endpoint,
    object data,
    int length,
    out int actualLength,
    int timeout)
  {
    PinnedHandle pinnedHandle = new PinnedHandle(data);
    int num = MonoUsbApi.InterruptTransfer(deviceHandle, endpoint, pinnedHandle.Handle, length, out actualLength, timeout);
    pinnedHandle.Dispose();
    return num;
  }

  [DllImport("libusb-1.0.dll", EntryPoint = "libusb_strerror")]
  private static extern IntPtr StrError(int errcode);

  public static string StrError(MonoUsbError errcode)
  {
    switch (errcode)
    {
      case MonoUsbError.ErrorIOCancelled:
        return "Transfer was canceled";
      case MonoUsbError.ErrorNotSupported:
        return "Operation not supported or unimplemented on this platform";
      case MonoUsbError.ErrorNoMem:
        return "Insufficient memory";
      case MonoUsbError.ErrorInterrupted:
        return "System call interrupted (perhaps due to signal)";
      case MonoUsbError.ErrorPipe:
        return "Pipe error or endpoint halted";
      case MonoUsbError.ErrorOverflow:
        return "Overflow";
      case MonoUsbError.ErrorTimeout:
        return "Operation timed out";
      case MonoUsbError.ErrorBusy:
        return "Resource busy";
      case MonoUsbError.ErrorNoDevice:
        return "No such device (it may have been disconnected)";
      case MonoUsbError.ErrorAccess:
        return "Access denied (insufficient permissions)";
      case MonoUsbError.ErrorInvalidParam:
        return "Invalid parameter";
      case MonoUsbError.ErrorIO:
        return "Input/output error";
      case MonoUsbError.Success:
        return "Success";
      default:
        return "Unknown error:" + (object) errcode;
    }
  }

  public static MonoUsbError MonoLibUsbErrorFromTransferStatus(MonoUsbTansferStatus status)
  {
    switch (status)
    {
      case MonoUsbTansferStatus.TransferCompleted:
        return MonoUsbError.Success;
      case MonoUsbTansferStatus.TransferError:
        return MonoUsbError.ErrorPipe;
      case MonoUsbTansferStatus.TransferTimedOut:
        return MonoUsbError.ErrorTimeout;
      case MonoUsbTansferStatus.TransferCancelled:
        return MonoUsbError.ErrorIOCancelled;
      case MonoUsbTansferStatus.TransferStall:
        return MonoUsbError.ErrorPipe;
      case MonoUsbTansferStatus.TransferNoDevice:
        return MonoUsbError.ErrorNoDevice;
      case MonoUsbTansferStatus.TransferOverflow:
        return MonoUsbError.ErrorOverflow;
      default:
        return MonoUsbError.ErrorOther;
    }
  }

  internal static void InitAndStart()
  {
    if (!MonoUsbEventHandler.IsStopped)
      return;
    MonoUsbEventHandler.Init();
    MonoUsbEventHandler.Start();
  }

  internal static void StopAndExit()
  {
    if (MonoUsbDevice.mMonoUSBProfileList != null)
      MonoUsbDevice.mMonoUSBProfileList.Close();
    MonoUsbDevice.mMonoUSBProfileList = (MonoUsbProfileList) null;
    MonoUsbEventHandler.Stop(true);
    MonoUsbEventHandler.Exit();
  }

  internal static ErrorCode ErrorCodeFromLibUsbError(int ret, out string description)
  {
    description = string.Empty;
    if (ret == 0)
      return ErrorCode.None;
    switch (ret - -13)
    {
      case 0:
        description += "Transfer was canceled";
        return ErrorCode.IoCancelled;
      case 1:
        description += "Operation not supported or unimplemented on this platform";
        return ErrorCode.NotSupported;
      case 2:
        description += "Insufficient memory";
        return ErrorCode.InsufficientMemory;
      case 3:
        description += "System call interrupted (perhaps due to signal)";
        return ErrorCode.Interrupted;
      case 4:
        description += "Pipe error or endpoint halted";
        return ErrorCode.PipeError;
      case 5:
        description += "Overflow";
        return ErrorCode.Overflow;
      case 6:
        description += "Operation timed out";
        return ErrorCode.IoTimedOut;
      case 7:
        description += "Resource busy";
        return ErrorCode.ResourceBusy;
      case 9:
        description += "No such device (it may have been disconnected)";
        return ErrorCode.DeviceNotFound;
      case 10:
        description += "Access denied (insufficient permissions)";
        return ErrorCode.AccessDenied;
      case 11:
        description += "Invalid parameter";
        return ErrorCode.InvalidParam;
      case 12:
        description += "Input/output error";
        return ErrorCode.IoSyncFailed;
      case 13:
        description += "Success";
        return ErrorCode.None;
      default:
        description = $"{description}Unknown error:{(object) ret}";
        return ErrorCode.UnknownError;
    }
  }
}
