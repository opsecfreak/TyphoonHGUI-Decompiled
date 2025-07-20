// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasFenceStatus
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasFenceStatus : UasMessage
{
  private uint mBreachTime;
  private ushort mBreachCount;
  private byte mBreachStatus;
  private FenceBreach mBreachType;

  public uint BreachTime
  {
    get => this.mBreachTime;
    set
    {
      this.mBreachTime = value;
      this.NotifyUpdated();
    }
  }

  public ushort BreachCount
  {
    get => this.mBreachCount;
    set
    {
      this.mBreachCount = value;
      this.NotifyUpdated();
    }
  }

  public byte BreachStatus
  {
    get => this.mBreachStatus;
    set
    {
      this.mBreachStatus = value;
      this.NotifyUpdated();
    }
  }

  public FenceBreach BreachType
  {
    get => this.mBreachType;
    set
    {
      this.mBreachType = value;
      this.NotifyUpdated();
    }
  }

  public UasFenceStatus()
  {
    this.mMessageId = (byte) 162;
    this.CrcExtra = (byte) 189;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mBreachTime);
    s.Write(this.mBreachCount);
    s.Write(this.mBreachStatus);
    s.Write((byte) this.mBreachType);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mBreachTime = s.ReadUInt32();
    this.mBreachCount = s.ReadUInt16();
    this.mBreachStatus = s.ReadByte();
    this.mBreachType = (FenceBreach) s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "FenceStatus;Status of geo-fencing. Sent in extended  \t    status stream when fencing enabled"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "BreachTime",
      Value = this.BreachTime.ToString(),
      Description = "time of last breach in milliseconds since boot",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "BreachCount",
      Value = this.BreachCount.ToString(),
      Description = "number of fence breaches",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "BreachStatus",
      Value = this.BreachStatus.ToString(),
      Description = "0 if currently inside fence, 1 if outside",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "BreachType",
      Value = this.BreachType.ToString(),
      Description = "last breach type (see FENCE_BREACH_* enum)",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("FenceBreach")
    });
  }
}
