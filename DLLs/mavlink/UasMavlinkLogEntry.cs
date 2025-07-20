// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasMavlinkLogEntry
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasMavlinkLogEntry : UasMessage
{
  private uint mTime;
  private uint mSize;
  private ushort mId;
  private ushort mNumlogs;
  private ushort mLastlognum;

  public uint Time
  {
    get => this.mTime;
    set
    {
      this.mTime = value;
      this.NotifyUpdated();
    }
  }

  public uint Size
  {
    get => this.mSize;
    set
    {
      this.mSize = value;
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

  public ushort Numlogs
  {
    get => this.mNumlogs;
    set
    {
      this.mNumlogs = value;
      this.NotifyUpdated();
    }
  }

  public ushort Lastlognum
  {
    get => this.mLastlognum;
    set
    {
      this.mLastlognum = value;
      this.NotifyUpdated();
    }
  }

  public UasMavlinkLogEntry()
  {
    this.mMessageId = (byte) 118;
    this.CrcExtra = (byte) 56;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTime = s.ReadUInt32();
    this.mSize = s.ReadUInt32();
    this.mId = s.ReadUInt16();
    this.mNumlogs = s.ReadUInt16();
    this.mLastlognum = s.ReadUInt16();
  }

  protected override void InitMetadata()
  {
  }
}
