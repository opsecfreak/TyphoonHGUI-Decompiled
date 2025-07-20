// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasMissionRequest
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasMissionRequest : UasMessage
{
  private ushort mSeq;
  private byte mTargetSystem;
  private byte mTargetComponent;

  public ushort Seq
  {
    get => this.mSeq;
    set
    {
      this.mSeq = value;
      this.NotifyUpdated();
    }
  }

  public byte TargetSystem
  {
    get => this.mTargetSystem;
    set
    {
      this.mTargetSystem = value;
      this.NotifyUpdated();
    }
  }

  public byte TargetComponent
  {
    get => this.mTargetComponent;
    set
    {
      this.mTargetComponent = value;
      this.NotifyUpdated();
    }
  }

  public UasMissionRequest()
  {
    this.mMessageId = (byte) 40;
    this.CrcExtra = (byte) 230;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mSeq);
    s.Write(this.mTargetSystem);
    s.Write(this.mTargetComponent);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mSeq = s.ReadUInt16();
    this.mTargetSystem = s.ReadByte();
    this.mTargetComponent = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Request the information of the mission item with the sequence number seq. The response of the system to this message should be a MISSION_ITEM message. http://qgroundcontrol.org/mavlink/waypoint_protocol"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Seq",
      Description = "Sequence",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TargetSystem",
      Description = "System ID",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TargetComponent",
      Description = "Component ID",
      NumElements = 1
    });
  }
}
