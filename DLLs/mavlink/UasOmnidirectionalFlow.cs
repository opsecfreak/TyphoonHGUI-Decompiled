// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasOmnidirectionalFlow
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasOmnidirectionalFlow : UasMessage
{
  private ulong mTimeUsec;
  private float mFrontDistanceM;
  private short[] mLeft = new short[10];
  private short[] mRight = new short[10];
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

  public float FrontDistanceM
  {
    get => this.mFrontDistanceM;
    set
    {
      this.mFrontDistanceM = value;
      this.NotifyUpdated();
    }
  }

  public short[] Left
  {
    get => this.mLeft;
    set
    {
      this.mLeft = value;
      this.NotifyUpdated();
    }
  }

  public short[] Right
  {
    get => this.mRight;
    set
    {
      this.mRight = value;
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

  public UasOmnidirectionalFlow()
  {
    this.mMessageId = (byte) 106;
    this.CrcExtra = (byte) 211;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeUsec);
    s.Write(this.mFrontDistanceM);
    s.Write(this.mLeft[0]);
    s.Write(this.mLeft[1]);
    s.Write(this.mLeft[2]);
    s.Write(this.mLeft[3]);
    s.Write(this.mLeft[4]);
    s.Write(this.mLeft[5]);
    s.Write(this.mLeft[6]);
    s.Write(this.mLeft[7]);
    s.Write(this.mLeft[8]);
    s.Write(this.mLeft[9]);
    s.Write(this.mRight[0]);
    s.Write(this.mRight[1]);
    s.Write(this.mRight[2]);
    s.Write(this.mRight[3]);
    s.Write(this.mRight[4]);
    s.Write(this.mRight[5]);
    s.Write(this.mRight[6]);
    s.Write(this.mRight[7]);
    s.Write(this.mRight[8]);
    s.Write(this.mRight[9]);
    s.Write(this.mSensorId);
    s.Write(this.mQuality);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeUsec = s.ReadUInt64();
    this.mFrontDistanceM = s.ReadSingle();
    this.mLeft[0] = s.ReadInt16();
    this.mLeft[1] = s.ReadInt16();
    this.mLeft[2] = s.ReadInt16();
    this.mLeft[3] = s.ReadInt16();
    this.mLeft[4] = s.ReadInt16();
    this.mLeft[5] = s.ReadInt16();
    this.mLeft[6] = s.ReadInt16();
    this.mLeft[7] = s.ReadInt16();
    this.mLeft[8] = s.ReadInt16();
    this.mLeft[9] = s.ReadInt16();
    this.mRight[0] = s.ReadInt16();
    this.mRight[1] = s.ReadInt16();
    this.mRight[2] = s.ReadInt16();
    this.mRight[3] = s.ReadInt16();
    this.mRight[4] = s.ReadInt16();
    this.mRight[5] = s.ReadInt16();
    this.mRight[6] = s.ReadInt16();
    this.mRight[7] = s.ReadInt16();
    this.mRight[8] = s.ReadInt16();
    this.mRight[9] = s.ReadInt16();
    this.mSensorId = s.ReadByte();
    this.mQuality = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Optical flow from an omnidirectional flow sensor (e.g. PX4FLOW with wide angle lens)"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeUsec",
      Description = "Timestamp (microseconds, synced to UNIX time or since system boot)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "FrontDistanceM",
      Description = "Front distance in meters. Positive value (including zero): distance known. Negative value: Unknown distance",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Left",
      Description = "Flow in deci pixels (1 = 0.1 pixel) on left hemisphere",
      NumElements = 10
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Right",
      Description = "Flow in deci pixels (1 = 0.1 pixel) on right hemisphere",
      NumElements = 10
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
