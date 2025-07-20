// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavLinkAsyncWalker
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;
using System.Threading;

#nullable disable
namespace MavLinkNet;

public class MavLinkAsyncWalker : MavLinkGenericPacketWalker
{
  public const int DefaultCircularBufferSize = 40960 /*0xA000*/;
  private BlockingCircularStream mProcessStream;

  public MavLinkAsyncWalker()
  {
    this.mProcessStream = new BlockingCircularStream(40960 /*0xA000*/);
    new Thread(new ParameterizedThreadStart(this.PacketProcessingWorker))
    {
      IsBackground = true
    }.Start();
  }

  public override void ProcessReceivedBytes(byte[] buffer, int start, int length)
  {
    this.mProcessStream.Write(buffer, 0, buffer.Length);
  }

  private void PacketProcessingWorker(object state)
  {
    using (BinaryReader binaryReader = MavLinkPacket.GetBinaryReader((Stream) this.mProcessStream))
    {
      while (true)
      {
        this.SyncStream(binaryReader);
        MavLinkPacket packet = MavLinkPacket.Deserialize(binaryReader, (byte) 0);
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
    while (s.ReadByte() != (byte) 188);
  }
}
