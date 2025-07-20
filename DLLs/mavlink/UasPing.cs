// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasPing
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasPing : UasMessage
{
  private ulong mTimeUsec;
  private uint mSeq;
  private byte mTargetSystem;
  private byte mTargetComponent;

  public ulong TimeUsec
  {
    get => this.mTimeUsec;
    set
    {
      this.mTimeUsec = value;
      this.NotifyUpdated();
    }
  }

  public uint Seq
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

  public UasPing()
  {
    this.mMessageId = (byte) 4;
    this.CrcExtra = (byte) 237;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeUsec);
    s.Write(this.mSeq);
    s.Write(this.mTargetSystem);
    s.Write(this.mTargetComponent);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeUsec = s.ReadUInt64();
    this.mSeq = s.ReadUInt32();
    this.mTargetSystem = s.ReadByte();
    this.mTargetComponent = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "A ping message either requesting or responding to a ping. This allows to measure the system latencies, including serial port, radio modem and UDP connections."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeUsec",
      Description = "Unix timestamp in microseconds",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Seq",
      Description = "PING sequence",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TargetSystem",
      Description = "0: request ping from all receiving systems, if greater than 0: message is a ping response and number is the system id of the requesting system",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TargetComponent",
      Description = "0: request ping from all receiving components, if greater than 0: message is a ping response and number is the system id of the requesting system",
      NumElements = 1
    });
  }
}
