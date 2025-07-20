// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavLinkGenericPacketWalker
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

#nullable disable
namespace MavLinkNet;

public abstract class MavLinkGenericPacketWalker
{
  public const byte PacketSignalByte = 188;

  public event PacketReceivedDelegate PacketReceived;

  public event PacketReceivedDelegate PacketDiscarded;

  public abstract void ProcessReceivedBytes(byte[] buffer, int start, int length);

  public byte[] SerializeMessage(
    UasMessage msg,
    byte systemId,
    byte componentId,
    bool includeSignalMark,
    byte sequenceNumber = 1)
  {
    byte signalMark = includeSignalMark ? (byte) 188 : (byte) 0;
    return MavLinkPacket.GetBytesForMessage(msg, systemId, componentId, sequenceNumber, signalMark);
  }

  protected void NotifyPacketReceived(MavLinkPacket packet)
  {
    if (packet == null || this.PacketReceived == null)
      return;
    this.PacketReceived((object) this, packet);
  }

  protected void NotifyPacketDiscarded(MavLinkPacket packet)
  {
    if (packet == null || this.PacketDiscarded == null)
      return;
    this.PacketDiscarded((object) this, packet);
  }
}
