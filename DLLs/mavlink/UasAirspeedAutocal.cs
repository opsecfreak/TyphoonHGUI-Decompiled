// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasAirspeedAutocal
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasAirspeedAutocal : UasMessage
{
  private float mVx;
  private float mVy;
  private float mVz;
  private float mDiffPressure;
  private float mEas2tas;
  private float mRatio;
  private float mStateX;
  private float mStateY;
  private float mStateZ;
  private float mPax;
  private float mPby;
  private float mPcz;

  public float Vx
  {
    get => this.mVx;
    set
    {
      this.mVx = value;
      this.NotifyUpdated();
    }
  }

  public float Vy
  {
    get => this.mVy;
    set
    {
      this.mVy = value;
      this.NotifyUpdated();
    }
  }

  public float Vz
  {
    get => this.mVz;
    set
    {
      this.mVz = value;
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

  public float Eas2tas
  {
    get => this.mEas2tas;
    set
    {
      this.mEas2tas = value;
      this.NotifyUpdated();
    }
  }

  public float Ratio
  {
    get => this.mRatio;
    set
    {
      this.mRatio = value;
      this.NotifyUpdated();
    }
  }

  public float StateX
  {
    get => this.mStateX;
    set
    {
      this.mStateX = value;
      this.NotifyUpdated();
    }
  }

  public float StateY
  {
    get => this.mStateY;
    set
    {
      this.mStateY = value;
      this.NotifyUpdated();
    }
  }

  public float StateZ
  {
    get => this.mStateZ;
    set
    {
      this.mStateZ = value;
      this.NotifyUpdated();
    }
  }

  public float Pax
  {
    get => this.mPax;
    set
    {
      this.mPax = value;
      this.NotifyUpdated();
    }
  }

  public float Pby
  {
    get => this.mPby;
    set
    {
      this.mPby = value;
      this.NotifyUpdated();
    }
  }

  public float Pcz
  {
    get => this.mPcz;
    set
    {
      this.mPcz = value;
      this.NotifyUpdated();
    }
  }

  public UasAirspeedAutocal()
  {
    this.mMessageId = (byte) 174;
    this.CrcExtra = (byte) 167;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mVx);
    s.Write(this.mVy);
    s.Write(this.mVz);
    s.Write(this.mDiffPressure);
    s.Write(this.mEas2tas);
    s.Write(this.mRatio);
    s.Write(this.mStateX);
    s.Write(this.mStateY);
    s.Write(this.mStateZ);
    s.Write(this.mPax);
    s.Write(this.mPby);
    s.Write(this.mPcz);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mVx = s.ReadSingle();
    this.mVy = s.ReadSingle();
    this.mVz = s.ReadSingle();
    this.mDiffPressure = s.ReadSingle();
    this.mEas2tas = s.ReadSingle();
    this.mRatio = s.ReadSingle();
    this.mStateX = s.ReadSingle();
    this.mStateY = s.ReadSingle();
    this.mStateZ = s.ReadSingle();
    this.mPax = s.ReadSingle();
    this.mPby = s.ReadSingle();
    this.mPcz = s.ReadSingle();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Airspeed auto-calibration"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Vx",
      Description = "GPS velocity north m/s",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Vy",
      Description = "GPS velocity east m/s",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Vz",
      Description = "GPS velocity down m/s",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "DiffPressure",
      Description = "Differential pressure pascals",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Eas2tas",
      Description = "Estimated to true airspeed ratio",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Ratio",
      Description = "Airspeed ratio",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "StateX",
      Description = "EKF state x",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "StateY",
      Description = "EKF state y",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "StateZ",
      Description = "EKF state z",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Pax",
      Description = "EKF Pax",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Pby",
      Description = "EKF Pby",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Pcz",
      Description = "EKF Pcz",
      NumElements = 1
    });
  }
}
