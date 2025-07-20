// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasAttitudeQuaternion
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasAttitudeQuaternion : UasMessage
{
  private uint mTimeBootMs;
  private float mQ1;
  private float mQ2;
  private float mQ3;
  private float mQ4;
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

  public float Q1
  {
    get => this.mQ1;
    set
    {
      this.mQ1 = value;
      this.NotifyUpdated();
    }
  }

  public float Q2
  {
    get => this.mQ2;
    set
    {
      this.mQ2 = value;
      this.NotifyUpdated();
    }
  }

  public float Q3
  {
    get => this.mQ3;
    set
    {
      this.mQ3 = value;
      this.NotifyUpdated();
    }
  }

  public float Q4
  {
    get => this.mQ4;
    set
    {
      this.mQ4 = value;
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

  public UasAttitudeQuaternion()
  {
    this.mMessageId = (byte) 31 /*0x1F*/;
    this.CrcExtra = (byte) 246;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeBootMs);
    s.Write(this.mQ1);
    s.Write(this.mQ2);
    s.Write(this.mQ3);
    s.Write(this.mQ4);
    s.Write(this.mRollspeed);
    s.Write(this.mPitchspeed);
    s.Write(this.mYawspeed);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeBootMs = s.ReadUInt32();
    this.mQ1 = s.ReadSingle();
    this.mQ2 = s.ReadSingle();
    this.mQ3 = s.ReadSingle();
    this.mQ4 = s.ReadSingle();
    this.mRollspeed = s.ReadSingle();
    this.mPitchspeed = s.ReadSingle();
    this.mYawspeed = s.ReadSingle();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "The attitude in the aeronautical frame (right-handed, Z-down, X-front, Y-right), expressed as quaternion."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeBootMs",
      Description = "Timestamp (milliseconds since system boot)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Q1",
      Description = "Quaternion component 1",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Q2",
      Description = "Quaternion component 2",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Q3",
      Description = "Quaternion component 3",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Q4",
      Description = "Quaternion component 4",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Rollspeed",
      Description = "Roll angular speed (rad/s)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Pitchspeed",
      Description = "Pitch angular speed (rad/s)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Yawspeed",
      Description = "Yaw angular speed (rad/s)",
      NumElements = 1
    });
  }
}
