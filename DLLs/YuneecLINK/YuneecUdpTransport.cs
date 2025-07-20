// Decompiled with JetBrains decompiler
// Type: YuneecLinkNet.YuneecUdpTransport
// Assembly: YuneecLINK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CFB54D17-6788-4CFB-B24E-B7975B945505
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\YuneecLINK.dll

using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;

#nullable disable
namespace YuneecLinkNet;

public class YuneecUdpTransport : YuneecGenericTransport
{
  public int UdpListeningPort;
  public int UdpTargetPort = 14550;
  public IPAddress TargetIpAddress = new IPAddress(new byte[4]
  {
    (byte) 127 /*0x7F*/,
    (byte) 0,
    (byte) 0,
    (byte) 1
  });
  public int HeartBeatUpdateRateMs = 1000;
  private ConcurrentQueue<byte[]> mReceiveQueue = new ConcurrentQueue<byte[]>();
  private ConcurrentQueue<UasMessage> mSendQueue = new ConcurrentQueue<UasMessage>();
  private AutoResetEvent mReceiveSignal = new AutoResetEvent(true);
  private AutoResetEvent mSendSignal = new AutoResetEvent(true);
  private YuneecAsyncWalker mMavLink = new YuneecAsyncWalker();
  private UdpClient mUdpClient;
  private bool mIsActive = true;

  public override void Initialize()
  {
    this.InitializeMavLink();
    this.InitializeUdpListener(this.UdpListeningPort);
    this.InitializeUdpSender(this.TargetIpAddress, this.UdpTargetPort);
  }

  public override void Dispose()
  {
    this.mIsActive = false;
    this.mUdpClient.Close();
    this.mReceiveSignal.Set();
    this.mSendSignal.Set();
  }

  private void InitializeMavLink()
  {
    this.mMavLink.PacketReceived += new PacketReceivedDelegate(((YuneecGenericTransport) this).HandlePacketReceived);
  }

  private void InitializeUdpListener(int port)
  {
    IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, port);
    this.mUdpClient = new UdpClient(ipEndPoint);
    this.mUdpClient.BeginReceive(new AsyncCallback(this.ReceiveCallback), (object) ipEndPoint);
    ThreadPool.QueueUserWorkItem(new WaitCallback(this.ProcessReceiveQueue), (object) null);
  }

  private void InitializeUdpSender(IPAddress targetIp, int targetPort)
  {
    ThreadPool.QueueUserWorkItem(new WaitCallback(this.ProcessSendQueue), (object) new IPEndPoint(targetIp, targetPort));
  }

  private void ReceiveCallback(IAsyncResult ar)
  {
    try
    {
      IPEndPoint asyncState = ar.AsyncState as IPEndPoint;
      this.mReceiveQueue.Enqueue(this.mUdpClient.EndReceive(ar, ref asyncState));
      if (!this.mIsActive)
      {
        this.mReceiveSignal.Set();
      }
      else
      {
        this.mUdpClient.BeginReceive(new AsyncCallback(this.ReceiveCallback), (object) ar);
        this.mReceiveSignal.Set();
      }
    }
    catch (SocketException ex)
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
      this.SendMavlinkMessage(state as IPEndPoint, result);
    }
  }

  private void SendMavlinkMessage(IPEndPoint ep, UasMessage msg)
  {
    byte[] dgram = this.mMavLink.SerializeMessage(msg, true);
    this.mUdpClient.Send(dgram, dgram.Length, ep);
  }

  public override void SendMessage(UasMessage msg)
  {
    this.mSendQueue.Enqueue(msg);
    this.mSendSignal.Set();
  }
}
