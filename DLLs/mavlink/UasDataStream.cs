// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasDataStream
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasDataStream : UasMessage
{
  private ushort mMessageRate;
  private MavDataStream mStreamId;
  private byte mOnOff;

  public ushort MessageRate
  {
    get => this.mMessageRate;
    set
    {
      this.mMessageRate = value;
      this.NotifyUpdated();
    }
  }

  public MavDataStream StreamId
  {
    get => this.mStreamId;
    set
    {
      this.mStreamId = value;
      this.NotifyUpdated();
    }
  }

  public byte OnOff
  {
    get => this.mOnOff;
    set
    {
      this.mOnOff = value;
      this.NotifyUpdated();
    }
  }

  public UasDataStream()
  {
    this.mMessageId = (byte) 67;
    this.CrcExtra = (byte) 21;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mMessageRate);
    s.Write((byte) this.mStreamId);
    s.Write(this.mOnOff);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mMessageRate = s.ReadUInt16();
    this.mStreamId = (MavDataStream) s.ReadByte();
    this.mOnOff = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = ""
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "MessageRate",
      Description = "The requested interval between two messages of this type.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "StreamId",
      Description = "The ID of the requested data stream. MAV_DATA_STREAM enum.",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("MavDataStream")
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "OnOff",
      Description = "1 stream is enabled, 0 stream is stopped.",
      NumElements = 1
    });
  }
}
