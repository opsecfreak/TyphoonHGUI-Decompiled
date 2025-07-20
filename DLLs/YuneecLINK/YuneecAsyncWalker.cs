// Decompiled with JetBrains decompiler
// Type: YuneecLinkNet.YuneecAsyncWalker
// Assembly: YuneecLINK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CFB54D17-6788-4CFB-B24E-B7975B945505
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\YuneecLINK.dll

using System.IO;
using System.Threading;

#nullable disable
namespace YuneecLinkNet;

public class YuneecAsyncWalker : MavLinkGenericPacketWalker
{
  public const int DefaultCircularBufferSize = 409600 /*0x064000*/;
  private BlockingCircularStream mProcessStream;

  public YuneecAsyncWalker()
  {
    this.mProcessStream = new BlockingCircularStream(409600 /*0x064000*/);
    ThreadPool.QueueUserWorkItem(new WaitCallback(this.PacketProcessingWorker));
  }

  public override void ProcessReceivedBytes(byte[] buffer, int start, int length)
  {
    this.mProcessStream.Write(buffer, 0, buffer.Length);
  }

  private void PacketProcessingWorker(object state)
  {
    using (BinaryReader binaryReader = YuneecLinkPacket.GetBinaryReader((Stream) this.mProcessStream))
    {
      while (true)
      {
        this.SyncStream(binaryReader);
        YuneecLinkPacket packet = YuneecLinkPacket.Deserialize(binaryReader, (byte) 0);
        if (packet.IsValid)
          this.NotifyPacketReceived(packet);
        else
          this.NotifyPacketDiscarded(packet);
      }
    }
  }

  private void SyncStream(BinaryReader s)
  {
    do
      ;
    while (s.ReadByte() != (byte) 254);
  }
}
