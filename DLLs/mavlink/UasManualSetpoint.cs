// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasManualSetpoint
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasManualSetpoint : UasMessage
{
  private uint mTimeBootMs;
  private float mRoll;
  private float mPitch;
  private float mYaw;
  private float mThrust;
  private byte mModeSwitch;
  private byte mManualOverrideSwitch;

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

  public float Thrust
  {
    get => this.mThrust;
    set
    {
      this.mThrust = value;
      this.NotifyUpdated();
    }
  }

  public byte ModeSwitch
  {
    get => this.mModeSwitch;
    set
    {
      this.mModeSwitch = value;
      this.NotifyUpdated();
    }
  }

  public byte ManualOverrideSwitch
  {
    get => this.mManualOverrideSwitch;
    set
    {
      this.mManualOverrideSwitch = value;
      this.NotifyUpdated();
    }
  }

  public UasManualSetpoint()
  {
    this.mMessageId = (byte) 81;
    this.CrcExtra = (byte) 106;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeBootMs);
    s.Write(this.mRoll);
    s.Write(this.mPitch);
    s.Write(this.mYaw);
    s.Write(this.mThrust);
    s.Write(this.mModeSwitch);
    s.Write(this.mManualOverrideSwitch);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeBootMs = s.ReadUInt32();
    this.mRoll = s.ReadSingle();
    this.mPitch = s.ReadSingle();
    this.mYaw = s.ReadSingle();
    this.mThrust = s.ReadSingle();
    this.mModeSwitch = s.ReadByte();
    this.mManualOverrideSwitch = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Setpoint in roll, pitch, yaw and thrust from the operator"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeBootMs",
      Description = "Timestamp in milliseconds since system boot",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Roll",
      Description = "Desired roll rate in radians per second",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Pitch",
      Description = "Desired pitch rate in radians per second",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Yaw",
      Description = "Desired yaw rate in radians per second",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Thrust",
      Description = "Collective thrust, normalized to 0 .. 1",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ModeSwitch",
      Description = "Flight mode switch position, 0.. 255",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ManualOverrideSwitch",
      Description = "Override mode switch position, 0.. 255",
      NumElements = 1
    });
  }
}
