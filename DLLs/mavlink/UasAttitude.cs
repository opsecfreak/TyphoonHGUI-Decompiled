// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasAttitude
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasAttitude : UasMessage
{
  private uint mTimeBootMs;
  private float mRoll;
  private float mPitch;
  private float mYaw;
  private float mRollspeed;
  private float mPitchspeed;
  private float mYawspeed;

  public uint TimeBootMs
  {
    get => this.mTimeBootMs;
    set
    {
      this.mTimeBootMs = value;
      this.NotifyUpdated();
    }
  }

  public float Roll
  {
    get => this.mRoll;
    set
    {
      this.mRoll = value;
      this.NotifyUpdated();
    }
  }

  public float Pitch
  {
    get => this.mPitch;
    set
    {
      this.mPitch = value;
      this.NotifyUpdated();
    }
  }

  public float Yaw
  {
    get => this.mYaw;
    set
    {
      this.mYaw = value;
      this.NotifyUpdated();
    }
  }

  public float Rollspeed
  {
    get => this.mRollspeed;
    set
    {
      this.mRollspeed = value;
      this.NotifyUpdated();
    }
  }

  public float Pitchspeed
  {
    get => this.mPitchspeed;
    set
    {
      this.mPitchspeed = value;
      this.NotifyUpdated();
    }
  }

  public float Yawspeed
  {
    get => this.mYawspeed;
    set
    {
      this.mYawspeed = value;
      this.NotifyUpdated();
    }
  }

  public UasAttitude()
  {
    this.mMessageId = (byte) 30;
    this.CrcExtra = (byte) 39;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeBootMs);
    s.Write(this.mRoll);
    s.Write(this.mPitch);
    s.Write(this.mYaw);
    s.Write(this.mRollspeed);
    s.Write(this.mPitchspeed);
    s.Write(this.mYawspeed);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeBootMs = s.ReadUInt32();
    this.mRoll = s.ReadSingle();
    this.mPitch = s.ReadSingle();
    this.mYaw = s.ReadSingle();
    this.mRollspeed = s.ReadSingle();
    this.mPitchspeed = s.ReadSingle();
    this.mYawspeed = s.ReadSingle();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Attitude;The attitude in the aeronautical frame (right-handed, Z-down, X-front, Y-right)."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeBootMs",
      Value = this.TimeBootMs.ToString(),
      Description = "Timestamp (milliseconds since system boot)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Roll",
      Value = this.Roll.ToString(),
      Description = "Roll angle (rad, -pi..+pi)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Pitch",
      Value = this.Pitch.ToString(),
      Description = "Pitch angle (rad, -pi..+pi)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Yaw",
      Value = this.Yaw.ToString(),
      Description = "Yaw angle (rad, -pi..+pi)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Rollspeed",
      Value = this.Rollspeed.ToString(),
      Description = "Roll angular speed (rad/s)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Pitchspeed",
      Value = this.Pitchspeed.ToString(),
      Description = "Pitch angular speed (rad/s)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Yawspeed",
      Value = this.Yawspeed.ToString(),
      Description = "Yaw angular speed (rad/s)",
      NumElements = 1
    });
  }
}
