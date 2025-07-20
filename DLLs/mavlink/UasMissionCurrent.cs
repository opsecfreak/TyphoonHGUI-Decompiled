// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasMissionCurrent
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasMissionCurrent : UasMessage
{
  private ushort mSeq;

  public ushort Seq
  {
    get => this.mSeq;
    set
    {
      this.mSeq = value;
      this.NotifyUpdated();
    }
  }

  public UasMissionCurrent()
  {
    this.mMessageId = (byte) 42;
    this.CrcExtra = (byte) 28;
  }

  internal override void SerializeBody(BinaryWriter s) => s.Write(this.mSeq);

  internal override void DeserializeBody(BinaryReader s) => this.mSeq = s.ReadUInt16();

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "MissionCurrent;Message that announces the sequence number of the current active mission item. The MAV will fly towards this mission item."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Seq",
      Value = this.Seq.ToString(),
      Description = "Sequence",
      NumElements = 1
    });
  }
}
