// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavLinkUdpTransport
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;

#nullable disable
namespace MavLinkNet;

public class MavLinkUdpTransport : MavLinkGenericTransport
{
  public int UdpListeningPort = 10;
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
  private MavLinkAsyncWalker mMavLink = new MavLinkAsyncWalker();
  private UdpClient mUdpClient;
  private const ushort X25CrcSeed = 65535 /*0xFFFF*/;

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
    this.mMavLink.PacketReceived += new PacketReceivedDelegate(((MavLinkGenericTransport) this).HandlePacketReceived);
  }

  private void InitializeUdpListener(int port)
  {
    IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, port);
    this.mUdpClient = new UdpClient(ipEndPoint);
    this.mUdpClient.BeginReceive(new AsyncCallback(this.ReceiveCallback), (object) ipEndPoint);
    new Thread(new ParameterizedThreadStart(this.ProcessReceiveQueue))
    {
      IsBackground = true
    }.Start();
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
    catch
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
    byte[] bytes = this.BtyesToBytes(this.mMavLink.SerializeMessage(msg, this.MavlinkSystemId, this.MavlinkComponentId, true));
    this.mUdpClient.Send(bytes, bytes.Length, ep);
  }

  private byte[] BtyesToBytes(byte[] buffer)
  {
    byte[] bytes = new byte[buffer.Length + 10];
    bytes[0] = (byte) 254;
    bytes[1] = (byte) buffer.Length;
    bytes[2] = (byte) 0;
    bytes[3] = (byte) 10;
    bytes[4] = (byte) 0;
    bytes[5] = (byte) 1;
    bytes[6] = (byte) 0;
    bytes[7] = byte.MaxValue;
    Array.Copy((Array) buffer, 0, (Array) bytes, 8, buffer.Length);
    ushort packetCrc = MavLinkUdpTransport.GetPacketCrc(bytes);
    bytes[8 + buffer.Length] = (byte) ((uint) packetCrc & (uint) byte.MaxValue);
    bytes[9 + buffer.Length] = (byte) ((uint) packetCrc >> 8);
    return bytes;
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

  public static ushort X25CrcAccumulate(byte b, ushort crc)
  {
    byte num1 = (byte) ((uint) b ^ (uint) (byte) ((uint) crc & (uint) byte.MaxValue));
    byte num2 = (byte) ((uint) num1 ^ (uint) num1 << 4);
    return (ushort) ((int) crc >> 8 ^ (int) num2 << 8 ^ (int) num2 << 3 ^ (int) num2 >> 4);
  }

  public static ushort GetPacketCrc(byte[] p)
  {
    ushort crc = ushort.MaxValue;
    for (int index = 1; index < p.Length - 2; ++index)
      crc = MavLinkUdpTransport.X25CrcAccumulate(p[index], crc);
    return MavLinkUdpTransport.X25CrcAccumulate((byte) 0, crc);
  }
}
