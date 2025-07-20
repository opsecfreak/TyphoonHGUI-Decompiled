// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavLinkLogFileTransport
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;

#nullable disable
namespace MavLinkNet;

public class MavLinkLogFileTransport : MavLinkGenericTransport
{
  private string mLogFileName;
  private string _recordFileName;
  private ConcurrentQueue<UasMessage> mSendQueue = new ConcurrentQueue<UasMessage>();
  private AutoResetEvent mSendSignal = new AutoResetEvent(true);
  private AutoResetEvent isEndSignal = new AutoResetEvent(false);

  public string RecordFileName => this._recordFileName;

  public string LogFileName => this.mLogFileName;

  public override void Initialize()
  {
    this._recordFileName = $".\\Record\\{DateTime.Now.ToString("MM-dd-hh-mm-ss")}-MavLinkFromY.rec";
    this.mIsActive = true;
    ThreadPool.QueueUserWorkItem(new WaitCallback(this.ProcessSendQueue));
  }

  public void RunLogFile(string logFileName)
  {
    this.mLogFileName = logFileName;
    ThreadPool.QueueUserWorkItem(new WaitCallback(this.Parse));
  }

  public override void Dispose()
  {
    this.mIsActive = false;
    this.mSendSignal.Set();
  }

  public void RefreshNewLogFile()
  {
    if (this.mIsActive)
    {
      this.isEndSignal.Reset();
      this.mIsActive = false;
      this.mSendSignal.Set();
      this._recordFileName = $".\\Record\\{DateTime.Now.ToString("MM-dd-hh-mm-ss")}-MavLinkFromY.rec";
      this.isEndSignal.WaitOne();
      this.mIsActive = true;
      ThreadPool.QueueUserWorkItem(new WaitCallback(this.ProcessSendQueue));
    }
    else
      this._recordFileName = $".\\Record\\{DateTime.Now.ToString("MM-dd-hh-mm-ss")}-MavLinkFromY.rec";
  }

  public override void SendMessage(UasMessage msg)
  {
    this.mSendQueue.Enqueue(msg);
    this.mSendSignal.Set();
  }

  private void ProcessSendQueue(object state)
  {
    byte num = 0;
    using (FileStream output = new FileStream(this._recordFileName, FileMode.Create))
    {
      using (BinaryWriter binaryWriter = new BinaryWriter((Stream) output))
      {
        do
        {
          UasMessage result;
          if (this.mSendQueue.TryDequeue(out result))
            binaryWriter.Write(MavLinkPacket.GetBytesForMessage(result, this.MavlinkSystemId, this.MavlinkComponentId, num++, (byte) 188));
          else
            this.mSendSignal.WaitOne();
        }
        while (this.mIsActive);
      }
    }
    this.isEndSignal.Set();
  }

  private void Parse(object state)
  {
    try
    {
      using (FileStream input = new FileStream(this.mLogFileName, FileMode.Open))
      {
        using (BinaryReader s = new BinaryReader((Stream) input))
        {
          while (true)
          {
            MavLinkPacket e;
            do
            {
              this.SyncStream(s);
              e = MavLinkPacket.Deserialize(s, (byte) 0);
            }
            while (!e.IsValid);
            this.HandlePacketReceived((object) this, e);
          }
        }
      }
    }
    catch (EndOfStreamException ex)
    {
    }
    this.HandleReceptionEnded((object) this);
  }

  private void SyncStream(BinaryReader s)
  {
    do
      ;
    while (s.ReadByte() != (byte) 188);
  }

  public override void BeginHeartBeatLoop()
  {
  }
}
