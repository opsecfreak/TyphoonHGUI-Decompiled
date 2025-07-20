// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasRollPitchYawSpeedThrustSetpoint
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasRollPitchYawSpeedThrustSetpoint : UasMessage
{
  private uint mTimeBootMs;
  private float mRollSpeed;
  private float mPitchSpeed;
  private float mYawSpeed;
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

  public float RollSpeed
  {
    get => this.mRollSpeed;
    set
    {
      this.mRollSpeed = value;
      this.NotifyUpdated();
    }
  }

  public float PitchSpeed
  {
    get => this.mPitchSpeed;
    set
    {
      this.mPitchSpeed = value;
      this.NotifyUpdated();
    }
  }

  public float YawSpeed
  {
    get => this.mYawSpeed;
    set
    {
      this.mYawSpeed = value;
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

  public UasRollPitchYawSpeedThrustSetpoint()
  {
    this.mMessageId = (byte) 59;
    this.CrcExtra = (byte) 238;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeBootMs);
    s.Write(this.mRollSpeed);
    s.Write(this.mPitchSpeed);
    s.Write(this.mYawSpeed);
    s.Write(this.mThrust);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeBootMs = s.ReadUInt32();
    this.mRollSpeed = s.ReadSingle();
    this.mPitchSpeed = s.ReadSingle();
    this.mYawSpeed = s.ReadSingle();
    this.mThrust = s.ReadSingle();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Setpoint in rollspeed, pitchspeed, yawspeed currently active on the system."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeBootMs",
      Description = "Timestamp in milliseconds since system boot",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "RollSpeed",
      Description = "Desired roll angular speed in rad/s",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "PitchSpeed",
      Description = "Desired pitch angular speed in rad/s",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "YawSpeed",
      Description = "Desired yaw angular speed in rad/s",
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
