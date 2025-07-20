// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasHilStateQuaternion
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasHilStateQuaternion : UasMessage
{
  private ulong mTimeUsec;
  private float[] mAttitudeQuaternion = new float[4];
  private float mRollspeed;
  private float mPitchspeed;
  private float mYawspeed;
  private int mLat;
  private int mLon;
  private int mAlt;
  private short mVx;
  private short mVy;
  private short mVz;
  private ushort mIndAirspeed;
  private ushort mTrueAirspeed;
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

  public float[] AttitudeQuaternion
  {
    get => this.mAttitudeQuaternion;
    set
    {
      this.mAttitudeQuaternion = value;
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

  public ushort IndAirspeed
  {
    get => this.mIndAirspeed;
    set
    {
      this.mIndAirspeed = value;
      this.NotifyUpdated();
    }
  }

  public ushort TrueAirspeed
  {
    get => this.mTrueAirspeed;
    set
    {
      this.mTrueAirspeed = value;
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

  public UasHilStateQuaternion()
  {
    this.mMessageId = (byte) 115;
    this.CrcExtra = (byte) 4;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeUsec);
    s.Write(this.mAttitudeQuaternion[0]);
    s.Write(this.mAttitudeQuaternion[1]);
    s.Write(this.mAttitudeQuaternion[2]);
    s.Write(this.mAttitudeQuaternion[3]);
    s.Write(this.mRollspeed);
    s.Write(this.mPitchspeed);
    s.Write(this.mYawspeed);
    s.Write(this.mLat);
    s.Write(this.mLon);
    s.Write(this.mAlt);
    s.Write(this.mVx);
    s.Write(this.mVy);
    s.Write(this.mVz);
    s.Write(this.mIndAirspeed);
    s.Write(this.mTrueAirspeed);
    s.Write(this.mXacc);
    s.Write(this.mYacc);
    s.Write(this.mZacc);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeUsec = s.ReadUInt64();
    this.mAttitudeQuaternion[0] = s.ReadSingle();
    this.mAttitudeQuaternion[1] = s.ReadSingle();
    this.mAttitudeQuaternion[2] = s.ReadSingle();
    this.mAttitudeQuaternion[3] = s.ReadSingle();
    this.mRollspeed = s.ReadSingle();
    this.mPitchspeed = s.ReadSingle();
    this.mYawspeed = s.ReadSingle();
    this.mLat = s.ReadInt32();
    this.mLon = s.ReadInt32();
    this.mAlt = s.ReadInt32();
    this.mVx = s.ReadInt16();
    this.mVy = s.ReadInt16();
    this.mVz = s.ReadInt16();
    this.mIndAirspeed = s.ReadUInt16();
    this.mTrueAirspeed = s.ReadUInt16();
    this.mXacc = s.ReadInt16();
    this.mYacc = s.ReadInt16();
    this.mZacc = s.ReadInt16();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Sent from simulation to autopilot, avoids in contrast to HIL_STATE singularities. This packet is useful for high throughput applications such as hardware in the loop simulations."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeUsec",
      Description = "Timestamp (microseconds since UNIX epoch or microseconds since system boot)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "AttitudeQuaternion",
      Description = "Vehicle attitude expressed as normalized quaternion",
      NumElements = 4
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
      Name = "IndAirspeed",
      Description = "Indicated airspeed, expressed as m/s * 100",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TrueAirspeed",
      Description = "True airspeed, expressed as m/s * 100",
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
