// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavLinkSerialPortTransport
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System;
using System.Collections.Concurrent;
using System.IO.Ports;
using System.Threading;

#nullable disable
namespace MavLinkNet;

public class MavLinkSerialPortTransport : MavLinkGenericTransport
{
  public string SerialPortName = "COM1";
  public int BaudRate = 115200;
  public int HeartBeatUpdateRateMs = 1000;
  private ConcurrentQueue<byte[]> mReceiveQueue = new ConcurrentQueue<byte[]>();
  private ConcurrentQueue<UasMessage> mSendQueue = new ConcurrentQueue<UasMessage>();
  private AutoResetEvent mReceiveSignal = new AutoResetEvent(true);
  private AutoResetEvent mSendSignal = new AutoResetEvent(true);
  private MavLinkAsyncWalker mMavLink = new MavLinkAsyncWalker();
  private SerialPort mSerialPort;

  public override void Initialize()
  {
    this.InitializeMavLink();
    this.InitializeSerialPort(this.SerialPortName);
  }

  public override void Dispose()
  {
    this.mIsActive = false;
    this.mSerialPort.DataReceived -= new SerialDataReceivedEventHandler(this.DataReceived);
    this.mSerialPort.Close();
    this.mReceiveSignal.Set();
    this.mSendSignal.Set();
  }

  private void InitializeMavLink()
  {
    this.mMavLink.PacketReceived += new PacketReceivedDelegate(((MavLinkGenericTransport) this).HandlePacketReceived);
  }

  private void InitializeSerialPort(string serialPortName)
  {
    this.mSerialPort = new SerialPort(serialPortName)
    {
      BaudRate = this.BaudRate
    };
    this.mSerialPort.ReceivedBytesThreshold = 17;
    this.mSerialPort.Open();
    this.mSerialPort.DataReceived += new SerialDataReceivedEventHandler(this.DataReceived);
    new Thread(new ParameterizedThreadStart(this.ProcessReceiveQueue))
    {
      IsBackground = true
    }.Start();
    ThreadPool.QueueUserWorkItem(new WaitCallback(this.ProcessSendQueue));
  }

  private void DataReceived(object sender, SerialDataReceivedEventArgs e)
  {
    try
    {
      SerialPort serialPort = (SerialPort) sender;
      int bytesToRead = serialPort.BytesToRead;
      byte[] buffer = new byte[bytesToRead];
      serialPort.Read(buffer, 0, bytesToRead);
      this.mReceiveQueue.Enqueue(buffer);
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
    byte[] buffer = this.mMavLink.SerializeMessage(msg, this.MavlinkSystemId, this.MavlinkComponentId, true);
    try
    {
      this.mSerialPort.Write(buffer, 0, buffer.Length);
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
}
