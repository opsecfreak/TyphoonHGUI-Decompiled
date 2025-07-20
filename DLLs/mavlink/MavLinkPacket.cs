// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavLinkPacket
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;
using System.Text;

#nullable disable
namespace MavLinkNet;

public class MavLinkPacket
{
  public const int PacketOverheadNumBytes = 7;
  public bool IsValid;
  public byte PayLoadLength;
  public byte PacketSequenceNumber;
  public byte SystemId;
  public byte ComponentId;
  public byte MessageId;
  public byte[] Payload;
  public byte Checksum1;
  public byte Checksum2;
  public UasMessage Message;
  private const ushort X25CrcSeed = 65535 /*0xFFFF*/;

  public static MavLinkPacket Deserialize(BinaryReader s, byte payloadLength)
  {
    MavLinkPacket mavLinkPacket = new MavLinkPacket()
    {
      PayLoadLength = payloadLength == (byte) 0 ? s.ReadByte() : payloadLength,
      PacketSequenceNumber = s.ReadByte(),
      SystemId = s.ReadByte(),
      ComponentId = s.ReadByte(),
      MessageId = s.ReadByte()
    };
    mavLinkPacket.Payload = s.ReadBytes((int) mavLinkPacket.PayLoadLength);
    mavLinkPacket.Checksum1 = s.ReadByte();
    mavLinkPacket.Checksum2 = s.ReadByte();
    if (mavLinkPacket.IsValidCrc())
      mavLinkPacket.DeserializeMessage();
    return mavLinkPacket;
  }

  public int GetPacketSize() => 7 + (int) this.PayLoadLength;

  private bool IsValidCrc()
  {
    ushort packetCrc = MavLinkPacket.GetPacketCrc(this);
    return (int) (byte) ((uint) packetCrc & (uint) byte.MaxValue) == (int) this.Checksum1 && (int) (byte) ((uint) packetCrc >> 8) == (int) this.Checksum2;
  }

  private void DeserializeMessage()
  {
    UasMessage fromId = UasSummary.CreateFromId(this.MessageId);
    if (fromId == null)
      return;
    using (MemoryStream s = new MemoryStream(this.Payload))
    {
      using (BinaryReader binaryReader = MavLinkPacket.GetBinaryReader((Stream) s))
        fromId.DeserializeBody(binaryReader);
    }
    this.Message = fromId;
    this.IsValid = true;
  }

  public static BinaryReader GetBinaryReader(Stream s) => new BinaryReader(s, Encoding.ASCII);

  public static MavLinkPacket GetPacketForMessage(
    UasMessage msg,
    byte systemId,
    byte componentId,
    byte sequenceNumber)
  {
    MavLinkPacket packetForMessage = new MavLinkPacket()
    {
      SystemId = systemId,
      ComponentId = componentId,
      PacketSequenceNumber = sequenceNumber,
      MessageId = msg.MessageId,
      Message = msg
    };
    using (MemoryStream output = new MemoryStream())
    {
      using (BinaryWriter s = new BinaryWriter((Stream) output))
        msg.SerializeBody(s);
      packetForMessage.Payload = output.ToArray();
      packetForMessage.PayLoadLength = (byte) packetForMessage.Payload.Length;
      packetForMessage.UpdateCrc();
    }
    return packetForMessage;
  }

  public static byte[] GetBytesForMessage(
    UasMessage msg,
    byte systemId,
    byte componentId,
    byte sequenceNumber,
    byte signalMark)
  {
    MavLinkPacket packetForMessage = MavLinkPacket.GetPacketForMessage(msg, systemId, componentId, sequenceNumber);
    int packetSize = packetForMessage.GetPacketSize();
    if (signalMark != (byte) 0)
      ++packetSize;
    byte[] buffer = new byte[packetSize];
    using (MemoryStream output = new MemoryStream(buffer))
    {
      using (BinaryWriter w = new BinaryWriter((Stream) output))
      {
        if (signalMark != (byte) 0)
          w.Write(signalMark);
        packetForMessage.Serialize(w);
      }
    }
    return buffer;
  }

  public void Serialize(BinaryWriter w)
  {
    w.Write(this.PayLoadLength);
    w.Write(this.PacketSequenceNumber);
    w.Write(this.SystemId);
    w.Write(this.ComponentId);
    w.Write(this.MessageId);
    w.Write(this.Payload);
    w.Write(this.Checksum1);
    w.Write(this.Checksum2);
  }

  private void UpdateCrc()
  {
    ushort packetCrc = MavLinkPacket.GetPacketCrc(this);
    this.Checksum1 = (byte) ((uint) packetCrc & (uint) byte.MaxValue);
    this.Checksum2 = (byte) ((uint) packetCrc >> 8);
  }

  public static ushort GetPacketCrc(MavLinkPacket p)
  {
    ushort maxValue = ushort.MaxValue;
    ushort crc1 = MavLinkPacket.X25CrcAccumulate(p.PayLoadLength, maxValue);
    ushort crc2 = MavLinkPacket.X25CrcAccumulate(p.PacketSequenceNumber, crc1);
    ushort crc3 = MavLinkPacket.X25CrcAccumulate(p.SystemId, crc2);
    ushort crc4 = MavLinkPacket.X25CrcAccumulate(p.ComponentId, crc3);
    ushort crc5 = MavLinkPacket.X25CrcAccumulate(p.MessageId, crc4);
    for (int index = 0; index < p.Payload.Length; ++index)
      crc5 = MavLinkPacket.X25CrcAccumulate(p.Payload[index], crc5);
    return crc5;
  }

  public static ushort X25CrcAccumulate(byte b, ushort crc)
  {
    byte num1 = (byte) ((uint) b ^ (uint) (byte) ((uint) crc & (uint) byte.MaxValue));
    byte num2 = (byte) ((uint) num1 ^ (uint) num1 << 4);
    return (ushort) ((int) crc >> 8 ^ (int) num2 << 8 ^ (int) num2 << 3 ^ (int) num2 >> 4);
  }
}
