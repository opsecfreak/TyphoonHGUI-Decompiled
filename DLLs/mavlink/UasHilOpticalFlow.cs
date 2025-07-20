// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasHilOpticalFlow
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasHilOpticalFlow : UasMessage
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

  public UasHilOpticalFlow()
  {
    this.mMessageId = (byte) 114;
    this.CrcExtra = (byte) 119;
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
      Description = "Simulated optical flow from a flow sensor (e.g. optical mouse sensor)"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeUsec",
      Description = "Timestamp (UNIX)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "FlowCompMX",
      Description = "Flow in meters in x-sensor direction, angular-speed compensated",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "FlowCompMY",
      Description = "Flow in meters in y-sensor direction, angular-speed compensated",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "GroundDistance",
      Description = "Ground distance in meters. Positive value: distance known. Negative value: Unknown distance",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "FlowX",
      Description = "Flow in pixels in x-sensor direction",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "FlowY",
      Description = "Flow in pixels in y-sensor direction",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "SensorId",
      Description = "Sensor ID",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Quality",
      Description = "Optical flow quality / confidence. 0: bad, 255: maximum quality",
      NumElements = 1
    });
  }
}
