// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasMissionItemReached
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasMissionItemReached : UasMessage
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

  public UasMissionItemReached()
  {
    this.mMessageId = (byte) 46;
    this.CrcExtra = (byte) 11;
  }

  internal override void SerializeBody(BinaryWriter s) => s.Write(this.mSeq);

  internal override void DeserializeBody(BinaryReader s) => this.mSeq = s.ReadUInt16();

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "A certain mission item has been reached. The system will either hold this position (or circle on the orbit) or (if the autocontinue on the WP was set) continue to the next MISSION."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Seq",
      Description = "Sequence",
      NumElements = 1
    });
  }
}
