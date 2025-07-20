// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasAhrs
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasAhrs : UasMessage
{
  private float mOmegaix;
  private float mOmegaiy;
  private float mOmegaiz;
  private float mAccelWeight;
  private float mRenormVal;
  private float mErrorRp;
  private float mErrorYaw;

  public float Omegaix
  {
    get => this.mOmegaix;
    set
    {
      this.mOmegaix = value;
      this.NotifyUpdated();
    }
  }

  public float Omegaiy
  {
    get => this.mOmegaiy;
    set
    {
      this.mOmegaiy = value;
      this.NotifyUpdated();
    }
  }

  public float Omegaiz
  {
    get => this.mOmegaiz;
    set
    {
      this.mOmegaiz = value;
      this.NotifyUpdated();
    }
  }

  public float AccelWeight
  {
    get => this.mAccelWeight;
    set
    {
      this.mAccelWeight = value;
      this.NotifyUpdated();
    }
  }

  public float RenormVal
  {
    get => this.mRenormVal;
    set
    {
      this.mRenormVal = value;
      this.NotifyUpdated();
    }
  }

  public float ErrorRp
  {
    get => this.mErrorRp;
    set
    {
      this.mErrorRp = value;
      this.NotifyUpdated();
    }
  }

  public float ErrorYaw
  {
    get => this.mErrorYaw;
    set
    {
      this.mErrorYaw = value;
      this.NotifyUpdated();
    }
  }

  public UasAhrs()
  {
    this.mMessageId = (byte) 163;
    this.CrcExtra = (byte) 127 /*0x7F*/;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mOmegaix);
    s.Write(this.mOmegaiy);
    s.Write(this.mOmegaiz);
    s.Write(this.mAccelWeight);
    s.Write(this.mRenormVal);
    s.Write(this.mErrorRp);
    s.Write(this.mErrorYaw);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mOmegaix = s.ReadSingle();
    this.mOmegaiy = s.ReadSingle();
    this.mOmegaiz = s.ReadSingle();
    this.mAccelWeight = s.ReadSingle();
    this.mRenormVal = s.ReadSingle();
    this.mErrorRp = s.ReadSingle();
    this.mErrorYaw = s.ReadSingle();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Ahrs;Status of DCM attitude estimator"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Omegaix",
      Value = this.Omegaix.ToString(),
      Description = "X gyro drift estimate rad/s",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Omegaiy",
      Value = this.Omegaiy.ToString(),
      Description = "Y gyro drift estimate rad/s",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Omegaiz",
      Value = this.Omegaiz.ToString(),
      Description = "Z gyro drift estimate rad/s",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "AccelWeight",
      Value = this.AccelWeight.ToString(),
      Description = "average accel_weight",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "RenormVal",
      Value = this.RenormVal.ToString(),
      Description = "average renormalisation value",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ErrorRp",
      Value = this.ErrorRp.ToString(),
      Description = "average error_roll_pitch value",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ErrorYaw",
      Value = this.ErrorYaw.ToString(),
      Description = "average error_yaw value",
      NumElements = 1
    });
  }
}
