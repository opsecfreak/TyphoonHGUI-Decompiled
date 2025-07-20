// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasOpticalFlow
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasOpticalFlow : UasMessage
{
  private ulong mTimeUsec;
  private float mFlowCompMX;
  private float mFlowCompMY;
  private float mGroundDistance;
  private short mFlowX;
  private short mFlowY;
  private byte mSensorId;
  private byte mQuality;

  public ulong TimeUsec
  {
    get => this.mTimeUsec;
    set
    {
      this.mTimeUsec = value;
      this.NotifyUpdated();
    }
  }

  public float FlowCompMX
  {
    get => this.mFlowCompMX;
    set
    {
      this.mFlowCompMX = value;
      this.NotifyUpdated();
    }
  }

  public float FlowCompMY
  {
    get => this.mFlowCompMY;
    set
    {
      this.mFlowCompMY = value;
      this.NotifyUpdated();
    }
  }

  public float GroundDistance
  {
    get => this.mGroundDistance;
    set
    {
      this.mGroundDistance = value;
      this.NotifyUpdated();
    }
  }

  public short FlowX
  {
    get => this.mFlowX;
    set
    {
      this.mFlowX = value;
      this.NotifyUpdated();
    }
  }

  public short FlowY
  {
    get => this.mFlowY;
    set
    {
      this.mFlowY = value;
      this.NotifyUpdated();
    }
  }

  public byte SensorId
  {
    get => this.mSensorId;
    set
    {
      this.mSensorId = value;
      this.NotifyUpdated();
    }
  }

  public byte Quality
  {
    get => this.mQuality;
    set
    {
      this.mQuality = value;
      this.NotifyUpdated();
    }
  }

  public UasOpticalFlow()
  {
    this.mMessageId = (byte) 100;
    this.CrcExtra = (byte) 175;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeUsec);
    s.Write(this.mFlowCompMX);
    s.Write(this.mFlowCompMY);
    s.Write(this.mGroundDistance);
    s.Write(this.mFlowX);
    s.Write(this.mFlowY);
    s.Write(this.mSensorId);
    s.Write(this.mQuality);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeUsec = s.ReadUInt64();
    this.mFlowCompMX = s.ReadSingle();
    this.mFlowCompMY = s.ReadSingle();
    this.mGroundDistance = s.ReadSingle();
    this.mFlowX = s.ReadInt16();
    this.mFlowY = s.ReadInt16();
    this.mSensorId = s.ReadByte();
    this.mQuality = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "UasOpticalFlow;Optical flow from a flow sensor (e.g. optical mouse sensor)"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeUsec",
      Description = "Timestamp (UNIX)",
      Value = this.TimeUsec.ToString(),
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "FlowCompMX",
      Description = "Flow in meters in x-sensor direction, angular-speed compensated",
      Value = this.FlowCompMX.ToString(),
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "FlowCompMY",
      Description = "Flow in meters in y-sensor direction, angular-speed compensated",
      Value = this.FlowCompMY.ToString(),
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "GroundDistance",
      Description = "Ground distance in meters. Positive value: distance known. Negative value: Unknown distance",
      Value = this.GroundDistance.ToString(),
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "FlowX",
      Description = "Flow in pixels * 10 in x-sensor direction (dezi-pixels)",
      Value = this.FlowX.ToString(),
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "FlowY",
      Description = "Flow in pixels * 10 in y-sensor direction (dezi-pixels)",
      Value = this.FlowY.ToString(),
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "SensorId",
      Description = "Sensor ID",
      Value = this.SensorId.ToString(),
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Quality",
      Description = "Optical flow quality / confidence. 0: bad, 255: maximum quality",
      Value = this.Quality.ToString(),
      NumElements = 1
    });
  }
}
