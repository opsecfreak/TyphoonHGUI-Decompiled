// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavLinkUSBTransport
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using LibUsbDotNet;
using LibUsbDotNet.DeviceNotify;
using LibUsbDotNet.LibUsb;
using LibUsbDotNet.Main;
using System;
using System.Collections.Concurrent;
using System.Threading;

#nullable disable
namespace MavLinkNet;

public class MavLinkUSBTransport : MavLinkGenericTransport
{
  public int myVID;
  public int myPID;
  public UsbDevice MyUsbDevice;
  public WindowsDeviceNotifier DeviceNotifier = new WindowsDeviceNotifier();
  public UsbEndpointWriter writer;
  public UsbEndpointReader reader;
  public string usbstate = "";
  private bool EnbaleInt = true;
  public bool EnbaleAuto = true;
  public int HeartBeatUpdateRateMs = 1000;
  private ConcurrentQueue<byte[]> mReceiveQueue = new ConcurrentQueue<byte[]>();
  private ConcurrentQueue<UasMessage> mSendQueue = new ConcurrentQueue<UasMessage>();
  private AutoResetEvent mReceiveSignal = new AutoResetEvent(true);
  private AutoResetEvent mSendSignal = new AutoResetEvent(true);
  private MavLinkAsyncWalker mMavLink = new MavLinkAsyncWalker();

  public override void Initialize()
  {
    this.InitializeMavLink();
    this.InitializeUSB(this.myVID, this.myPID);
  }

  public override void Dispose()
  {
    this.DeviceNotifier.OnDeviceNotify -= new EventHandler<DeviceNotifyEventArgs>(this.OnDeviceNotifyEvent);
    this.CloseUSB();
    this.mIsActive = false;
    this.mReceiveSignal.Set();
    this.mSendSignal.Set();
  }

  private void InitializeMavLink()
  {
    this.mMavLink.PacketReceived += new PacketReceivedDelegate(((MavLinkGenericTransport) this).HandlePacketReceived);
  }

  private void InitializeUSB(int myVID, int myPID)
  {
    if (this.FindAndOpenUSB(myVID, myPID))
    {
      this.usbstate = "Device is connected.";
      this.writer = this.MyUsbDevice.OpenEndpointWriter(WriteEndpointID.Ep01);
      this.reader = this.MyUsbDevice.OpenEndpointReader(ReadEndpointID.Ep02);
      if (this.EnbaleInt)
      {
        this.reader.DataReceived += new EventHandler<EndpointDataEventArgs>(this.OnRxEndPointData);
        this.reader.DataReceivedEnabled = true;
      }
      this.BeginHeartBeatLoop();
    }
    else
      this.usbstate = "Device is not connected.";
    if (this.EnbaleAuto)
      this.DeviceNotifier.OnDeviceNotify += new EventHandler<DeviceNotifyEventArgs>(this.OnDeviceNotifyEvent);
    ThreadPool.QueueUserWorkItem(new WaitCallback(this.ProcessReceiveQueue), (object) null);
    ThreadPool.QueueUserWorkItem(new WaitCallback(this.ProcessSendQueue));
  }

  private void ProcessReceiveQueue(object state)
  {
    while (true)
    {
      byte[] result;
      while (!this.mReceiveQueue.TryDequeue(out result))
      {
        this.mReceiveSignal.WaitOne();
        if (!this.mIsActive)
        {
          this.HandleReceptionEnded((object) this);
          return;
        }
      }
      this.mMavLink.ProcessReceivedBytes(result, 0, result.Length);
    }
  }

  private void ProcessSendQueue(object state)
  {
    while (true)
    {
      UasMessage result;
      while (!this.mSendQueue.TryDequeue(out result))
      {
        this.mSendSignal.WaitOne();
        if (!this.mIsActive)
          return;
      }
      this.SendMavlinkMessage(result);
    }
  }

  private void SendMavlinkMessage(UasMessage msg)
  {
    try
    {
      byte[] buffer = this.mMavLink.SerializeMessage(msg, this.MavlinkSystemId, this.MavlinkComponentId, true);
      if (this.writer.Write(buffer, 0, buffer.Length, -1, out int _) != ErrorCode.None)
        throw new Exception(UsbDevice.LastErrorString);
    }
    catch
    {
    }
  }

  public override void BeginHeartBeatLoop()
  {
    ThreadPool.QueueUserWorkItem(new WaitCallback(this.HeartBeatLoop), (object) null);
  }

  private void HeartBeatLoop(object state)
  {
    while (true)
    {
      foreach (UasMessage heartBeatObject in this.UavState.GetHeartBeatObjects())
        this.SendMessage(heartBeatObject);
      Thread.Sleep(this.HeartBeatUpdateRateMs);
    }
  }

  public override void SendMessage(UasMessage msg)
  {
    this.mSendQueue.Enqueue(msg);
    this.mSendSignal.Set();
  }

  private bool FindAndOpenUSB(int VID, int PID)
  {
    UsbRegistry usbRegistry = UsbDevice.AllDevices.Find(new UsbDeviceFinder(VID, PID));
    if (usbRegistry == null || !usbRegistry.Open(out this.MyUsbDevice))
      return false;
    ((LibUsbDevice) this.MyUsbDevice).SetConfiguration((byte) 1);
    ((LibUsbDevice) this.MyUsbDevice).ClaimInterface(0);
    this.usbstate += $"{usbRegistry[SPDRP.DeviceDesc]}";
    return true;
  }

  public void CloseUSB()
  {
    try
    {
      if (this.reader != null)
        this.reader.Dispose();
      if (this.writer != null)
        this.writer.Dispose();
      if (this.MyUsbDevice == null)
        return;
      this.MyUsbDevice.Close();
    }
    catch
    {
    }
  }

  public string GetLastError() => UsbDevice.LastErrorString;

  private void OnDeviceNotifyEvent(object sender, DeviceNotifyEventArgs e)
  {
    if (e.EventType == EventType.DeviceArrival)
    {
      this.usbstate = $"Find a new USB device connection,PID = 0x{e.Device.IdProduct:X},VID = 0x{e.Device.IdVendor:X}.";
      if (e.Device.IdProduct == this.myPID && e.Device.IdVendor == this.myVID)
      {
        this.usbstate += "The USB device is the target device.";
        if (this.FindAndOpenUSB(this.myVID, this.myPID))
        {
          this.usbstate += "Device is connected.";
          this.writer = this.MyUsbDevice.OpenEndpointWriter(WriteEndpointID.Ep01);
          this.reader = this.MyUsbDevice.OpenEndpointReader(ReadEndpointID.Ep02);
          if (this.EnbaleInt)
          {
            this.reader.DataReceived += new EventHandler<EndpointDataEventArgs>(this.OnRxEndPointData);
            this.reader.DataReceivedEnabled = true;
          }
          this.BeginHeartBeatLoop();
        }
        else
          this.usbstate += "Device is not connected.";
      }
      else
        this.usbstate += "The USB device is not a goal.";
    }
    else
    {
      if (e.EventType != EventType.DeviceRemoveComplete)
        return;
      this.usbstate = $"Found that device removed,PID = 0x{e.Device.IdProduct:X},VID = 0x{e.Device.IdVendor:X}.";
      if (e.Device.IdProduct == this.myPID && e.Device.IdVendor == this.myVID)
      {
        this.usbstate += string.Format("Remove the USB device is the target device.");
        this.CloseUSB();
      }
      else
        this.usbstate += string.Format("Remove the USB device is not a goal.");
    }
  }

  private void OnRxEndPointData(object sender, EndpointDataEventArgs e)
  {
    try
    {
      byte[] destinationArray = new byte[e.Count];
      Array.Copy((Array) e.Buffer, (Array) destinationArray, e.Count);
      this.mReceiveQueue.Enqueue(destinationArray);
      this.mReceiveSignal.Set();
    }
    catch (TimeoutException ex)
    {
      this.mIsActive = false;
    }
    catch (InvalidOperationException ex)
    {
      this.mIsActive = false;
    }
  }
}
