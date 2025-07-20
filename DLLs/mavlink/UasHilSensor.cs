// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasHilSensor
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasHilSensor : UasMessage
{
  private ulong mTimeUsec;
  private float mXacc;
  private float mYacc;
  private float mZacc;
  private float mXgyro;
  private float mYgyro;
  private float mZgyro;
  private float mXmag;
  private float mYmag;
  private float mZmag;
  private float mAbsPressure;
  private float mDiffPressure;
  private float mPressureAlt;
  private float mTemperature;
  private uint mFieldsUpdated;

  public ulong TimeUsec
  {
    get => this.mTimeUsec;
    set
    {
      this.mTimeUsec = value;
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

  public float Xmag
  {
    get => this.mXmag;
    set
    {
      this.mXmag = value;
      this.NotifyUpdated();
    }
  }

  public float Ymag
  {
    get => this.mYmag;
    set
    {
      this.mYmag = value;
      this.NotifyUpdated();
    }
  }

  public float Zmag
  {
    get => this.mZmag;
    set
    {
      this.mZmag = value;
      this.NotifyUpdated();
    }
  }

  public float AbsPressure
  {
    get => this.mAbsPressure;
    set
    {
      this.mAbsPressure = value;
      this.NotifyUpdated();
    }
  }

  public float DiffPressure
  {
    get => this.mDiffPressure;
    set
    {
      this.mDiffPressure = value;
      this.NotifyUpdated();
    }
  }

  public float PressureAlt
  {
    get => this.mPressureAlt;
    set
    {
      this.mPressureAlt = value;
      this.NotifyUpdated();
    }
  }

  public float Temperature
  {
    get => this.mTemperature;
    set
    {
      this.mTemperature = value;
      this.NotifyUpdated();
    }
  }

  public uint FieldsUpdated
  {
    get => this.mFieldsUpdated;
    set
    {
      this.mFieldsUpdated = value;
      this.NotifyUpdated();
    }
  }

  public UasHilSensor()
  {
    this.mMessageId = (byte) 107;
    this.CrcExtra = (byte) 108;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeUsec);
    s.Write(this.mXacc);
    s.Write(this.mYacc);
    s.Write(this.mZacc);
    s.Write(this.mXgyro);
    s.Write(this.mYgyro);
    s.Write(this.mZgyro);
    s.Write(this.mXmag);
    s.Write(this.mYmag);
    s.Write(this.mZmag);
    s.Write(this.mAbsPressure);
    s.Write(this.mDiffPressure);
    s.Write(this.mPressureAlt);
    s.Write(this.mTemperature);
    s.Write(this.mFieldsUpdated);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeUsec = s.ReadUInt64();
    this.mXacc = s.ReadSingle();
    this.mYacc = s.ReadSingle();
    this.mZacc = s.ReadSingle();
    this.mXgyro = s.ReadSingle();
    this.mYgyro = s.ReadSingle();
    this.mZgyro = s.ReadSingle();
    this.mXmag = s.ReadSingle();
    this.mYmag = s.ReadSingle();
    this.mZmag = s.ReadSingle();
    this.mAbsPressure = s.ReadSingle();
    this.mDiffPressure = s.ReadSingle();
    this.mPressureAlt = s.ReadSingle();
    this.mTemperature = s.ReadSingle();
    this.mFieldsUpdated = s.ReadUInt32();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "The IMU readings in SI units in NED body frame"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeUsec",
      Description = "Timestamp (microseconds, synced to UNIX time or since system boot)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Xacc",
      Description = "X acceleration (m/s^2)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Yacc",
      Description = "Y acceleration (m/s^2)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Zacc",
      Description = "Z acceleration (m/s^2)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Xgyro",
      Description = "Angular speed around X axis in body frame (rad / sec)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Ygyro",
      Description = "Angular speed around Y axis in body frame (rad / sec)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Zgyro",
      Description = "Angular speed around Z axis in body frame (rad / sec)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Xmag",
      Description = "X Magnetic field (Gauss)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Ymag",
      Description = "Y Magnetic field (Gauss)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Zmag",
      Description = "Z Magnetic field (Gauss)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "AbsPressure",
      Description = "Absolute pressure in millibar",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "DiffPressure",
      Description = "Differential pressure (airspeed) in millibar",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "PressureAlt",
      Description = "Altitude calculated from pressure",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Temperature",
      Description = "Temperature in degrees celsius",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "FieldsUpdated",
      Description = "Bitmask for fields that have updated since last message, bit 0 = xacc, bit 12: temperature",
      NumElements = 1
    });
  }
}
