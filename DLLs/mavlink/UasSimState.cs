// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasSimState
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasSimState : UasMessage
{
  private float mQ1;
  private float mQ2;
  private float mQ3;
  private float mQ4;
  private float mRoll;
  private float mPitch;
  private float mYaw;
  private float mXacc;
  private float mYacc;
  private float mZacc;
  private float mXgyro;
  private float mYgyro;
  private float mZgyro;
  private float mLat;
  private float mLon;
  private float mAlt;
  private float mStdDevHorz;
  private float mStdDevVert;
  private float mVn;
  private float mVe;
  private float mVd;

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

  public float Xacc
  {
    get => this.mXacc;
    set
    {
      this.mXacc = value;
      this.NotifyUpdated();
    }
  }

  public float Yacc
  {
    get => this.mYacc;
    set
    {
      this.mYacc = value;
      this.NotifyUpdated();
    }
  }

  public float Zacc
  {
    get => this.mZacc;
    set
    {
      this.mZacc = value;
      this.NotifyUpdated();
    }
  }

  public float Xgyro
  {
    get => this.mXgyro;
    set
    {
      this.mXgyro = value;
      this.NotifyUpdated();
    }
  }

  public float Ygyro
  {
    get => this.mYgyro;
    set
    {
      this.mYgyro = value;
      this.NotifyUpdated();
    }
  }

  public float Zgyro
  {
    get => this.mZgyro;
    set
    {
      this.mZgyro = value;
      this.NotifyUpdated();
    }
  }

  public float Lat
  {
    get => this.mLat;
    set
    {
      this.mLat = value;
      this.NotifyUpdated();
    }
  }

  public float Lon
  {
    get => this.mLon;
    set
    {
      this.mLon = value;
      this.NotifyUpdated();
    }
  }

  public float Alt
  {
    get => this.mAlt;
    set
    {
      this.mAlt = value;
      this.NotifyUpdated();
    }
  }

  public float StdDevHorz
  {
    get => this.mStdDevHorz;
    set
    {
      this.mStdDevHorz = value;
      this.NotifyUpdated();
    }
  }

  public float StdDevVert
  {
    get => this.mStdDevVert;
    set
    {
      this.mStdDevVert = value;
      this.NotifyUpdated();
    }
  }

  public float Vn
  {
    get => this.mVn;
    set
    {
      this.mVn = value;
      this.NotifyUpdated();
    }
  }

  public float Ve
  {
    get => this.mVe;
    set
    {
      this.mVe = value;
      this.NotifyUpdated();
    }
  }

  public float Vd
  {
    get => this.mVd;
    set
    {
      this.mVd = value;
      this.NotifyUpdated();
    }
  }

  public UasSimState()
  {
    this.mMessageId = (byte) 108;
    this.CrcExtra = (byte) 32 /*0x20*/;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mQ1);
    s.Write(this.mQ2);
    s.Write(this.mQ3);
    s.Write(this.mQ4);
    s.Write(this.mRoll);
    s.Write(this.mPitch);
    s.Write(this.mYaw);
    s.Write(this.mXacc);
    s.Write(this.mYacc);
    s.Write(this.mZacc);
    s.Write(this.mXgyro);
    s.Write(this.mYgyro);
    s.Write(this.mZgyro);
    s.Write(this.mLat);
    s.Write(this.mLon);
    s.Write(this.mAlt);
    s.Write(this.mStdDevHorz);
    s.Write(this.mStdDevVert);
    s.Write(this.mVn);
    s.Write(this.mVe);
    s.Write(this.mVd);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mQ1 = s.ReadSingle();
    this.mQ2 = s.ReadSingle();
    this.mQ3 = s.ReadSingle();
    this.mQ4 = s.ReadSingle();
    this.mRoll = s.ReadSingle();
    this.mPitch = s.ReadSingle();
    this.mYaw = s.ReadSingle();
    this.mXacc = s.ReadSingle();
    this.mYacc = s.ReadSingle();
    this.mZacc = s.ReadSingle();
    this.mXgyro = s.ReadSingle();
    this.mYgyro = s.ReadSingle();
    this.mZgyro = s.ReadSingle();
    this.mLat = s.ReadSingle();
    this.mLon = s.ReadSingle();
    this.mAlt = s.ReadSingle();
    this.mStdDevHorz = s.ReadSingle();
    this.mStdDevVert = s.ReadSingle();
    this.mVn = s.ReadSingle();
    this.mVe = s.ReadSingle();
    this.mVd = s.ReadSingle();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Status of simulation environment, if used"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Q1",
      Description = "True attitude quaternion component 1",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Q2",
      Description = "True attitude quaternion component 2",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Q3",
      Description = "True attitude quaternion component 3",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Q4",
      Description = "True attitude quaternion component 4",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Roll",
      Description = "Attitude roll expressed as Euler angles, not recommended except for human-readable outputs",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Pitch",
      Description = "Attitude pitch expressed as Euler angles, not recommended except for human-readable outputs",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Yaw",
      Description = "Attitude yaw expressed as Euler angles, not recommended except for human-readable outputs",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Xacc",
      Description = "X acceleration m/s/s",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Yacc",
      Description = "Y acceleration m/s/s",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Zacc",
      Description = "Z acceleration m/s/s",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Xgyro",
      Description = "Angular speed around X axis rad/s",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Ygyro",
      Description = "Angular speed around Y axis rad/s",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Zgyro",
      Description = "Angular speed around Z axis rad/s",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Lat",
      Description = "Latitude in degrees",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Lon",
      Description = "Longitude in degrees",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Alt",
      Description = "Altitude in meters",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "StdDevHorz",
      Description = "Horizontal position standard deviation",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "StdDevVert",
      Description = "Vertical position standard deviation",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Vn",
      Description = "True velocity in m/s in NORTH direction in earth-fixed NED frame",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Ve",
      Description = "True velocity in m/s in EAST direction in earth-fixed NED frame",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Vd",
      Description = "True velocity in m/s in DOWN direction in earth-fixed NED frame",
      NumElements = 1
    });
  }
}
