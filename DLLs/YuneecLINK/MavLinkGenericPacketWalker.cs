// Decompiled with JetBrains decompiler
// Type: YuneecLinkNet.MavLinkGenericPacketWalker
// Assembly: YuneecLINK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CFB54D17-6788-4CFB-B24E-B7975B945505
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\YuneecLINK.dll

#nullable disable
namespace YuneecLinkNet;

public abstract class MavLinkGenericPacketWalker
{
  public const byte PacketSignalByte = 254;

  public event PacketReceivedDelegate PacketReceived;

  public event PacketReceivedDelegate PacketDiscarded;

  public abstract void ProcessReceivedBytes(byte[] buffer, int start, int length);

  public byte[] SerializeMessage(UasMessage msg, bool includeSignalMark)
  {
    byte signalMark = includeSignalMark ? (byte) 254 : (byte) 0;
    return YuneecLinkPacket.GetBytesForMessage(msg, signalMark);
  }

  protected void NotifyPacketReceived(YuneecLinkPacket packet)
  {
    if (packet == null || this.PacketReceived == null)
      return;
    this.PacketReceived((object) this, packet);
  }

  protected void NotifyPacketDiscarded(YuneecLinkPacket packet)
  {
    if (packet == null || this.PacketDiscarded == null)
      return;
    this.PacketDiscarded((object) this, packet);
  }
}
