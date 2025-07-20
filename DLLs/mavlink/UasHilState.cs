// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasHilState
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasHilState : UasMessage
{
  private ulong mTimeUsec;
  private float mRoll;
  private float mPitch;
  private float mYaw;
  private float mRollspeed;
  private float mPitchspeed;
  private float mYawspeed;
  private int mLat;
  private int mLon;
  private int mAlt;
  private short mVx;
  private short mVy;
  private short mVz;
  private short mXacc;
  private short mYacc;
  private short mZacc;

  public ulong TimeUsec
  {
    get => this.mTimeUsec;
    set
    {
      this.mTimeUsec = value;
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

  public int Lat
  {
    get => this.mLat;
    set
    {
      this.mLat = value;
      this.NotifyUpdated();
    }
  }

  public int Lon
  {
    get => this.mLon;
    set
    {
      this.mLon = value;
      this.NotifyUpdated();
    }
  }

  public int Alt
  {
    get => this.mAlt;
    set
    {
      this.mAlt = value;
      this.NotifyUpdated();
    }
  }

  public short Vx
  {
    get => this.mVx;
    set
    {
      this.mVx = value;
      this.NotifyUpdated();
    }
  }

  public short Vy
  {
    get => this.mVy;
    set
    {
      this.mVy = value;
      this.NotifyUpdated();
    }
  }

  public short Vz
  {
    get => this.mVz;
    set
    {
      this.mVz = value;
      this.NotifyUpdated();
    }
  }

  public short Xacc
  {
    get => this.mXacc;
    set
    {
      this.mXacc = value;
      this.NotifyUpdated();
    }
  }

  public short Yacc
  {
    get => this.mYacc;
    set
    {
      this.mYacc = value;
      this.NotifyUpdated();
    }
  }

  public short Zacc
  {
    get => this.mZacc;
    set
    {
      this.mZacc = value;
      this.NotifyUpdated();
    }
  }

  public UasHilState()
  {
    this.mMessageId = (byte) 90;
    this.CrcExtra = (byte) 183;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeUsec);
    s.Write(this.mRoll);
    s.Write(this.mPitch);
    s.Write(this.mYaw);
    s.Write(this.mRollspeed);
    s.Write(this.mPitchspeed);
    s.Write(this.mYawspeed);
    s.Write(this.mLat);
    s.Write(this.mLon);
    s.Write(this.mAlt);
    s.Write(this.mVx);
    s.Write(this.mVy);
    s.Write(this.mVz);
    s.Write(this.mXacc);
    s.Write(this.mYacc);
    s.Write(this.mZacc);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeUsec = s.ReadUInt64();
    this.mRoll = s.ReadSingle();
    this.mPitch = s.ReadSingle();
    this.mYaw = s.ReadSingle();
    this.mRollspeed = s.ReadSingle();
    this.mPitchspeed = s.ReadSingle();
    this.mYawspeed = s.ReadSingle();
    this.mLat = s.ReadInt32();
    this.mLon = s.ReadInt32();
    this.mAlt = s.ReadInt32();
    this.mVx = s.ReadInt16();
    this.mVy = s.ReadInt16();
    this.mVz = s.ReadInt16();
    this.mXacc = s.ReadInt16();
    this.mYacc = s.ReadInt16();
    this.mZacc = s.ReadInt16();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "DEPRECATED PACKET! Suffers from missing airspeed fields and singularities due to Euler angles. Please use HIL_STATE_QUATERNION instead. Sent from simulation to autopilot. This packet is useful for high throughput applications such as hardware in the loop simulations."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeUsec",
      Description = "Timestamp (microseconds since UNIX epoch or microseconds since system boot)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Roll",
      Description = "Roll angle (rad)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Pitch",
      Description = "Pitch angle (rad)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Yaw",
      Description = "Yaw angle (rad)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Rollspeed",
      Description = "Body frame roll / phi angular speed (rad/s)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Pitchspeed",
      Description = "Body frame pitch / theta angular speed (rad/s)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Yawspeed",
      Description = "Body frame yaw / psi angular speed (rad/s)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Lat",
      Description = "Latitude, expressed as * 1E7",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Lon",
      Description = "Longitude, expressed as * 1E7",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Alt",
      Description = "Altitude in meters, expressed as * 1000 (millimeters)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Vx",
      Description = "Ground X Speed (Latitude), expressed as m/s * 100",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Vy",
      Description = "Ground Y Speed (Longitude), expressed as m/s * 100",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Vz",
      Description = "Ground Z Speed (Altitude), expressed as m/s * 100",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Xacc",
      Description = "X acceleration (mg)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Yacc",
      Description = "Y acceleration (mg)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Zacc",
      Description = "Z acceleration (mg)",
      NumElements = 1
    });
  }
}
