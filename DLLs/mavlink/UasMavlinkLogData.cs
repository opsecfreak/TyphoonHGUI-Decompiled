// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasMavlinkLogData
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasMavlinkLogData : UasMessage
{
  private uint mOffset;
  private ushort mId;
  private byte mCount;
  private byte[] mData = new byte[90];

  public uint Offset
  {
    get => this.mOffset;
    set
    {
      this.mOffset = value;
      this.NotifyUpdated();
    }
  }

  public ushort Id
  {
    get => this.mId;
    set
    {
      this.mId = value;
      this.NotifyUpdated();
    }
  }

  public byte Count
  {
    get => this.mCount;
    set
    {
      this.mCount = value;
      this.NotifyUpdated();
    }
  }

  public byte[] Data
  {
    get => this.mData;
    set
    {
      this.mData = value;
      this.NotifyUpdated();
    }
  }

  public UasMavlinkLogData()
  {
    this.mMessageId = (byte) 120;
    this.CrcExtra = (byte) 134;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mOffset = s.ReadUInt32();
    this.mId = s.ReadUInt16();
    this.mCount = s.ReadByte();
    this.mData = s.ReadBytes(90);
  }

  protected override void InitMetadata()
  {
  }
}
