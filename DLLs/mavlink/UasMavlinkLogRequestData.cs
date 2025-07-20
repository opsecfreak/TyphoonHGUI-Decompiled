// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasMavlinkLogRequestData
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasMavlinkLogRequestData : UasMessage
{
  private uint mOffset;
  private uint mCount;
  private ushort mId;
  private byte mTargetsystem;
  private byte mTargetcomponent;

  public uint Offset
  {
    get => this.mOffset;
    set
    {
      this.mOffset = value;
      this.NotifyUpdated();
    }
  }

  public uint Count
  {
    get => this.mCount;
    set
    {
      this.mCount = value;
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

  public byte Targetsystem
  {
    get => this.mTargetsystem;
    set
    {
      this.mTargetsystem = value;
      this.NotifyUpdated();
    }
  }

  public byte Targetcomponent
  {
    get => this.mTargetcomponent;
    set
    {
      this.mTargetcomponent = value;
      this.NotifyUpdated();
    }
  }

  public UasMavlinkLogRequestData()
  {
    this.mMessageId = (byte) 119;
    this.CrcExtra = (byte) 116;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mOffset = s.ReadUInt32();
    this.mCount = s.ReadUInt32();
    this.mId = s.ReadUInt16();
    this.mTargetsystem = s.ReadByte();
    this.mTargetcomponent = s.ReadByte();
  }

  protected override void InitMetadata()
  {
  }
}
