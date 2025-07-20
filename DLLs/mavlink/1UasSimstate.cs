// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasSimstate
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasSimstate : UasMessage
{
  private float mRoll;
  private float mPitch;
  private float mYaw;
  private float mXacc;
  private float mYacc;
  private float mZacc;
  private float mXgyro;
  private float mYgyro;
  private float mZgyro;
  private int mLat;
  private int mLng;

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

  public int Lat
  {
    get => this.mLat;
    set
    {
      this.mLat = value;
      this.NotifyUpdated();
    }
  }

  public int Lng
  {
    get => this.mLng;
    set
    {
      this.mLng = value;
      this.NotifyUpdated();
    }
  }

  public UasSimstate()
  {
    this.mMessageId = (byte) 164;
    this.CrcExtra = (byte) 154;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
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
    s.Write(this.mLng);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mRoll = s.ReadSingle();
    this.mPitch = s.ReadSingle();
    this.mYaw = s.ReadSingle();
    this.mXacc = s.ReadSingle();
    this.mYacc = s.ReadSingle();
    this.mZacc = s.ReadSingle();
    this.mXgyro = s.ReadSingle();
    this.mYgyro = s.ReadSingle();
    this.mZgyro = s.ReadSingle();
    this.mLat = s.ReadInt32();
    this.mLng = s.ReadInt32();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Status of simulation environment, if used"
    };
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
      Description = "Latitude in degrees * 1E7",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Lng",
      Description = "Longitude in degrees * 1E7",
      NumElements = 1
    });
  }
}
