// Decompiled with JetBrains decompiler
// Type: YuneecLinkNet.YuneecLinkPacket
// Assembly: YuneecLINK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CFB54D17-6788-4CFB-B24E-B7975B945505
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\YuneecLINK.dll

using System;
using System.IO;
using System.Text;

#nullable disable
namespace YuneecLinkNet;

public class YuneecLinkPacket
{
  public const int PacketOverheadNumBytes = 3;
  public bool IsValid;
  public byte DataLength;
  public byte MessageId;
  public byte[] Data;
  public byte CRC8;
  public UasMessage Message;
  private const byte X25CrcSeed = 0;
  private static byte[] crcTable = new byte[256 /*0x0100*/]
  {
    (byte) 0,
    (byte) 231,
    (byte) 41,
    (byte) 206,
    (byte) 82,
    (byte) 181,
    (byte) 123,
    (byte) 156,
    (byte) 164,
    (byte) 67,
    (byte) 141,
    (byte) 106,
    (byte) 246,
    (byte) 17,
    (byte) 223,
    (byte) 56,
    (byte) 175,
    (byte) 72,
    (byte) 134,
    (byte) 97,
    (byte) 253,
    (byte) 26,
    (byte) 212,
    (byte) 51,
    (byte) 11,
    (byte) 236,
    (byte) 34,
    (byte) 197,
    (byte) 89,
    (byte) 190,
    (byte) 112 /*0x70*/,
    (byte) 151,
    (byte) 185,
    (byte) 94,
    (byte) 144 /*0x90*/,
    (byte) 119,
    (byte) 235,
    (byte) 12,
    (byte) 194,
    (byte) 37,
    (byte) 29,
    (byte) 250,
    (byte) 52,
    (byte) 211,
    (byte) 79,
    (byte) 168,
    (byte) 102,
    (byte) 129,
    (byte) 22,
    (byte) 241,
    (byte) 63 /*0x3F*/,
    (byte) 216,
    (byte) 68,
    (byte) 163,
    (byte) 109,
    (byte) 138,
    (byte) 178,
    (byte) 85,
    (byte) 155,
    (byte) 124,
    (byte) 224 /*0xE0*/,
    (byte) 7,
    (byte) 201,
    (byte) 46,
    (byte) 149,
    (byte) 114,
    (byte) 188,
    (byte) 91,
    (byte) 199,
    (byte) 32 /*0x20*/,
    (byte) 238,
    (byte) 9,
    (byte) 49,
    (byte) 214,
    (byte) 24,
    byte.MaxValue,
    (byte) 99,
    (byte) 132,
    (byte) 74,
    (byte) 173,
    (byte) 58,
    (byte) 221,
    (byte) 19,
    (byte) 244,
    (byte) 104,
    (byte) 143,
    (byte) 65,
    (byte) 166,
    (byte) 158,
    (byte) 121,
    (byte) 183,
    (byte) 80 /*0x50*/,
    (byte) 204,
    (byte) 43,
    (byte) 229,
    (byte) 2,
    (byte) 44,
    (byte) 203,
    (byte) 5,
    (byte) 226,
    (byte) 126,
    (byte) 153,
    (byte) 87,
    (byte) 176 /*0xB0*/,
    (byte) 136,
    (byte) 111,
    (byte) 161,
    (byte) 70,
    (byte) 218,
    (byte) 61,
    (byte) 243,
    (byte) 20,
    (byte) 131,
    (byte) 100,
    (byte) 170,
    (byte) 77,
    (byte) 209,
    (byte) 54,
    (byte) 248,
    (byte) 31 /*0x1F*/,
    (byte) 39,
    (byte) 192 /*0xC0*/,
    (byte) 14,
    (byte) 233,
    (byte) 117,
    (byte) 146,
    (byte) 92,
    (byte) 187,
    (byte) 205,
    (byte) 42,
    (byte) 228,
    (byte) 3,
    (byte) 159,
    (byte) 120,
    (byte) 182,
    (byte) 81,
    (byte) 105,
    (byte) 142,
    (byte) 64 /*0x40*/,
    (byte) 167,
    (byte) 59,
    (byte) 220,
    (byte) 18,
    (byte) 245,
    (byte) 98,
    (byte) 133,
    (byte) 75,
    (byte) 172,
    (byte) 48 /*0x30*/,
    (byte) 215,
    (byte) 25,
    (byte) 254,
    (byte) 198,
    (byte) 33,
    (byte) 239,
    (byte) 8,
    (byte) 148,
    (byte) 115,
    (byte) 189,
    (byte) 90,
    (byte) 116,
    (byte) 147,
    (byte) 93,
    (byte) 186,
    (byte) 38,
    (byte) 193,
    (byte) 15,
    (byte) 232,
    (byte) 208 /*0xD0*/,
    (byte) 55,
    (byte) 249,
    (byte) 30,
    (byte) 130,
    (byte) 101,
    (byte) 171,
    (byte) 76,
    (byte) 219,
    (byte) 60,
    (byte) 242,
    (byte) 21,
    (byte) 137,
    (byte) 110,
    (byte) 160 /*0xA0*/,
    (byte) 71,
    (byte) 127 /*0x7F*/,
    (byte) 152,
    (byte) 86,
    (byte) 177,
    (byte) 45,
    (byte) 202,
    (byte) 4,
    (byte) 227,
    (byte) 88,
    (byte) 191,
    (byte) 113,
    (byte) 150,
    (byte) 10,
    (byte) 237,
    (byte) 35,
    (byte) 196,
    (byte) 252,
    (byte) 27,
    (byte) 213,
    (byte) 50,
    (byte) 174,
    (byte) 73,
    (byte) 135,
    (byte) 96 /*0x60*/,
    (byte) 247,
    (byte) 16 /*0x10*/,
    (byte) 222,
    (byte) 57,
    (byte) 165,
    (byte) 66,
    (byte) 140,
    (byte) 107,
    (byte) 83,
    (byte) 180,
    (byte) 122,
    (byte) 157,
    (byte) 1,
    (byte) 230,
    (byte) 40,
    (byte) 207,
    (byte) 225,
    (byte) 6,
    (byte) 200,
    (byte) 47,
    (byte) 179,
    (byte) 84,
    (byte) 154,
    (byte) 125,
    (byte) 69,
    (byte) 162,
    (byte) 108,
    (byte) 139,
    (byte) 23,
    (byte) 240 /*0xF0*/,
    (byte) 62,
    (byte) 217,
    (byte) 78,
    (byte) 169,
    (byte) 103,
    (byte) 128 /*0x80*/,
    (byte) 28,
    (byte) 251,
    (byte) 53,
    (byte) 210,
    (byte) 234,
    (byte) 13,
    (byte) 195,
    (byte) 36,
    (byte) 184,
    (byte) 95,
    (byte) 145,
    (byte) 118
  };

  public static YuneecLinkPacket Deserialize(BinaryReader s, byte payloadLength)
  {
    YuneecLinkPacket yuneecLinkPacket = new YuneecLinkPacket()
    {
      DataLength = payloadLength == (byte) 0 ? s.ReadByte() : payloadLength,
      MessageId = s.ReadByte()
    };
    yuneecLinkPacket.Data = s.ReadBytes((int) yuneecLinkPacket.DataLength);
    yuneecLinkPacket.CRC8 = s.ReadByte();
    if (yuneecLinkPacket.IsValidCrc())
      yuneecLinkPacket.DeserializeMessage();
    return yuneecLinkPacket;
  }

  public int GetPacketSize() => 3 + (int) this.DataLength;

  private bool IsValidCrc()
  {
    return (int) (byte) ((uint) YuneecLinkPacket.GetPacketCrc(this) & (uint) byte.MaxValue) == (int) this.CRC8;
  }

  private void DeserializeMessage()
  {
    UasMessage fromId = UasSummary.CreateFromId(this.MessageId);
    if (fromId == null)
      return;
    byte[] destinationArray = new byte[this.Data.Length + 1];
    Array.Copy((Array) this.Data, 0, (Array) destinationArray, 1, this.Data.Length);
    destinationArray[0] = (byte) this.Data.Length;
    this.Data = destinationArray;
    using (MemoryStream s = new MemoryStream(this.Data))
    {
      using (BinaryReader binaryReader = YuneecLinkPacket.GetBinaryReader((Stream) s))
        fromId.DeserializeBody(binaryReader);
    }
    this.Message = fromId;
    this.IsValid = true;
  }

  public static BinaryReader GetBinaryReader(Stream s) => new BinaryReader(s, Encoding.ASCII);

  public static YuneecLinkPacket GetPacketForMessage(UasMessage msg)
  {
    YuneecLinkPacket packetForMessage = new YuneecLinkPacket()
    {
      MessageId = msg.MessageId,
      Message = msg
    };
    using (MemoryStream output = new MemoryStream())
    {
      using (BinaryWriter s = new BinaryWriter((Stream) output))
        msg.SerializeBody(s);
      packetForMessage.Data = output.ToArray();
      packetForMessage.DataLength = (byte) packetForMessage.Data.Length;
      packetForMessage.UpdateCrc();
    }
    return packetForMessage;
  }

  public static byte[] GetBytesForMessage(UasMessage msg, byte signalMark)
  {
    YuneecLinkPacket packetForMessage = YuneecLinkPacket.GetPacketForMessage(msg);
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
    w.Write(this.DataLength);
    w.Write(this.MessageId);
    w.Write(this.Data);
    w.Write(this.CRC8);
  }

  private void UpdateCrc() => this.CRC8 = YuneecLinkPacket.GetPacketCrc(this);

  public static byte GetPacketCrc(YuneecLinkPacket p)
  {
    byte crc1 = 0;
    byte crc2 = YuneecLinkPacket.X25CrcAccumulate(p.DataLength, crc1);
    byte crc3 = YuneecLinkPacket.X25CrcAccumulate(p.MessageId, crc2);
    for (int index = 0; index < p.Data.Length; ++index)
      crc3 = YuneecLinkPacket.X25CrcAccumulate(p.Data[index], crc3);
    return crc3;
  }

  public static byte X25CrcAccumulate(byte b, byte crc)
  {
    crc = YuneecLinkPacket.crcTable[(int) (byte) ((uint) crc ^ (uint) b)];
    return crc;
  }

  public static byte PCRC8(byte[] d)
  {
    byte num = 0;
    for (int index = 0; index < d.Length; ++index)
      num = YuneecLinkPacket.crcTable[(int) (byte) ((uint) num ^ (uint) d[index])];
    return num;
  }
}
