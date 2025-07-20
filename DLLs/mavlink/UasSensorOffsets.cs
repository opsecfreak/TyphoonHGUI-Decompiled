// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasSensorOffsets
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasSensorOffsets : UasMessage
{
  private float mMagDeclination;
  private int mRawPress;
  private int mRawTemp;
  private float mGyroCalX;
  private float mGyroCalY;
  private float mGyroCalZ;
  private float mAccelCalX;
  private float mAccelCalY;
  private float mAccelCalZ;
  private short mMagOfsX;
  private short mMagOfsY;
  private short mMagOfsZ;

  public float MagDeclination
  {
    get => this.mMagDeclination;
    set
    {
      this.mMagDeclination = value;
      this.NotifyUpdated();
    }
  }

  public int RawPress
  {
    get => this.mRawPress;
    set
    {
      this.mRawPress = value;
      this.NotifyUpdated();
    }
  }

  public int RawTemp
  {
    get => this.mRawTemp;
    set
    {
      this.mRawTemp = value;
      this.NotifyUpdated();
    }
  }

  public float GyroCalX
  {
    get => this.mGyroCalX;
    set
    {
      this.mGyroCalX = value;
      this.NotifyUpdated();
    }
  }

  public float GyroCalY
  {
    get => this.mGyroCalY;
    set
    {
      this.mGyroCalY = value;
      this.NotifyUpdated();
    }
  }

  public float GyroCalZ
  {
    get => this.mGyroCalZ;
    set
    {
      this.mGyroCalZ = value;
      this.NotifyUpdated();
    }
  }

  public float AccelCalX
  {
    get => this.mAccelCalX;
    set
    {
      this.mAccelCalX = value;
      this.NotifyUpdated();
    }
  }

  public float AccelCalY
  {
    get => this.mAccelCalY;
    set
    {
      this.mAccelCalY = value;
      this.NotifyUpdated();
    }
  }

  public float AccelCalZ
  {
    get => this.mAccelCalZ;
    set
    {
      this.mAccelCalZ = value;
      this.NotifyUpdated();
    }
  }

  public short MagOfsX
  {
    get => this.mMagOfsX;
    set
    {
      this.mMagOfsX = value;
      this.NotifyUpdated();
    }
  }

  public short MagOfsY
  {
    get => this.mMagOfsY;
    set
    {
      this.mMagOfsY = value;
      this.NotifyUpdated();
    }
  }

  public short MagOfsZ
  {
    get => this.mMagOfsZ;
    set
    {
      this.mMagOfsZ = value;
      this.NotifyUpdated();
    }
  }

  public UasSensorOffsets()
  {
    this.mMessageId = (byte) 150;
    this.CrcExtra = (byte) 134;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mMagDeclination);
    s.Write(this.mRawPress);
    s.Write(this.mRawTemp);
    s.Write(this.mGyroCalX);
    s.Write(this.mGyroCalY);
    s.Write(this.mGyroCalZ);
    s.Write(this.mAccelCalX);
    s.Write(this.mAccelCalY);
    s.Write(this.mAccelCalZ);
    s.Write(this.mMagOfsX);
    s.Write(this.mMagOfsY);
    s.Write(this.mMagOfsZ);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mMagDeclination = s.ReadSingle();
    this.mRawPress = s.ReadInt32();
    this.mRawTemp = s.ReadInt32();
    this.mGyroCalX = s.ReadSingle();
    this.mGyroCalY = s.ReadSingle();
    this.mGyroCalZ = s.ReadSingle();
    this.mAccelCalX = s.ReadSingle();
    this.mAccelCalY = s.ReadSingle();
    this.mAccelCalZ = s.ReadSingle();
    this.mMagOfsX = s.ReadInt16();
    this.mMagOfsY = s.ReadInt16();
    this.mMagOfsZ = s.ReadInt16();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "SensorOffsets;Offsets and calibrations values for hardware          sensors. This makes it easier to debug the calibration process."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "MagDeclination",
      Value = this.MagDeclination.ToString(),
      Description = "magnetic declination (radians)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "RawPress",
      Value = this.RawPress.ToString(),
      Description = "raw pressure from barometer",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "RawTemp",
      Value = this.RawTemp.ToString(),
      Description = "raw temperature from barometer",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "GyroCalX",
      Value = this.GyroCalX.ToString(),
      Description = "gyro X calibration",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "GyroCalY",
      Value = this.GyroCalY.ToString(),
      Description = "gyro Y calibration",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "GyroCalZ",
      Value = this.GyroCalZ.ToString(),
      Description = "gyro Z calibration",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "AccelCalX",
      Value = this.AccelCalX.ToString(),
      Description = "accel X calibration",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "AccelCalY",
      Value = this.AccelCalY.ToString(),
      Description = "accel Y calibration",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "AccelCalZ",
      Value = this.AccelCalZ.ToString(),
      Description = "accel Z calibration",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "MagOfsX",
      Value = this.MagOfsX.ToString(),
      Description = "magnetometer X offset",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "MagOfsY",
      Value = this.MagOfsY.ToString(),
      Description = "magnetometer Y offset",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "MagOfsZ",
      Value = this.MagOfsZ.ToString(),
      Description = "magnetometer Z offset",
      NumElements = 1
    });
  }
}
