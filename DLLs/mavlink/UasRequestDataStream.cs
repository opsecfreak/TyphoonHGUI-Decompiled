// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasRequestDataStream
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasRequestDataStream : UasMessage
{
  private ushort mReqMessageRate;
  private byte mTargetSystem;
  private byte mTargetComponent;
  private MavDataStream mReqStreamId;
  private byte mStartStop;

  public ushort ReqMessageRate
  {
    get => this.mReqMessageRate;
    set
    {
      this.mReqMessageRate = value;
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

  public MavDataStream ReqStreamId
  {
    get => this.mReqStreamId;
    set
    {
      this.mReqStreamId = value;
      this.NotifyUpdated();
    }
  }

  public byte StartStop
  {
    get => this.mStartStop;
    set
    {
      this.mStartStop = value;
      this.NotifyUpdated();
    }
  }

  public UasRequestDataStream()
  {
    this.mMessageId = (byte) 66;
    this.CrcExtra = (byte) 148;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mReqMessageRate);
    s.Write(this.mTargetSystem);
    s.Write(this.mTargetComponent);
    s.Write((byte) this.mReqStreamId);
    s.Write(this.mStartStop);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mReqMessageRate = s.ReadUInt16();
    this.mTargetSystem = s.ReadByte();
    this.mTargetComponent = s.ReadByte();
    this.mReqStreamId = (MavDataStream) s.ReadByte();
    this.mStartStop = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = ""
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ReqMessageRate",
      Description = "The requested interval between two messages of this type.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TargetSystem",
      Description = "The target requested to send the message stream.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TargetComponent",
      Description = "The target requested to send the message stream.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ReqStreamId",
      Description = "The ID of the requested data stream. MAV_DATA_STREAM enum.",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("MavDataStream")
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "StartStop",
      Description = "1 to start sending, 0 to stop sending.",
      NumElements = 1
    });
  }
}
