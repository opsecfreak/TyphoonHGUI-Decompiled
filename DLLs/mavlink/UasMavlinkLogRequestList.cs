// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasMavlinkLogRequestList
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasMavlinkLogRequestList : UasMessage
{
  private ushort mStart;
  private ushort mEnd;
  private byte mTargetsystem;
  private byte mTargetcomponent;

  public ushort Start
  {
    get => this.mStart;
    set
    {
      this.mStart = value;
      this.NotifyUpdated();
    }
  }

  public ushort End
  {
    get => this.mEnd;
    set
    {
      this.mEnd = value;
      this.NotifyUpdated();
    }
  }

  public byte Targetsystem
  {
    get => this.mTargetcomponent;
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

  public UasMavlinkLogRequestList()
  {
    this.mMessageId = (byte) 117;
    this.CrcExtra = (byte) 128 /*0x80*/;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mStart = s.ReadUInt16();
    this.mEnd = s.ReadUInt16();
    this.mTargetsystem = s.ReadByte();
    this.mTargetcomponent = s.ReadByte();
  }

  protected override void InitMetadata()
  {
  }
}
