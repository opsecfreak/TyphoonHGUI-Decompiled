// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasRollPitchYawRatesThrustSetpoint
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasRollPitchYawRatesThrustSetpoint : UasMessage
{
  private uint mTimeBootMs;
  private float mRollRate;
  private float mPitchRate;
  private float mYawRate;
  private float mThrust;

  public uint TimeBootMs
  {
    get => this.mTimeBootMs;
    set
    {
      this.mTimeBootMs = value;
      this.NotifyUpdated();
    }
  }

  public float RollRate
  {
    get => this.mRollRate;
    set
    {
      this.mRollRate = value;
      this.NotifyUpdated();
    }
  }

  public float PitchRate
  {
    get => this.mPitchRate;
    set
    {
      this.mPitchRate = value;
      this.NotifyUpdated();
    }
  }

  public float YawRate
  {
    get => this.mYawRate;
    set
    {
      this.mYawRate = value;
      this.NotifyUpdated();
    }
  }

  public float Thrust
  {
    get => this.mThrust;
    set
    {
      this.mThrust = value;
      this.NotifyUpdated();
    }
  }

  public UasRollPitchYawRatesThrustSetpoint()
  {
    this.mMessageId = (byte) 80 /*0x50*/;
    this.CrcExtra = (byte) 127 /*0x7F*/;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeBootMs);
    s.Write(this.mRollRate);
    s.Write(this.mPitchRate);
    s.Write(this.mYawRate);
    s.Write(this.mThrust);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeBootMs = s.ReadUInt32();
    this.mRollRate = s.ReadSingle();
    this.mPitchRate = s.ReadSingle();
    this.mYawRate = s.ReadSingle();
    this.mThrust = s.ReadSingle();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Setpoint in roll, pitch, yaw rates and thrust currently active on the system."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeBootMs",
      Description = "Timestamp in milliseconds since system boot",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "RollRate",
      Description = "Desired roll rate in radians per second",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "PitchRate",
      Description = "Desired pitch rate in radians per second",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "YawRate",
      Description = "Desired yaw rate in radians per second",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Thrust",
      Description = "Collective thrust, normalized to 0 .. 1",
      NumElements = 1
    });
  }
}
