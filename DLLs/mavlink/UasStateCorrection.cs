// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasStateCorrection
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasStateCorrection : UasMessage
{
  private float mXerr;
  private float mYerr;
  private float mZerr;
  private float mRollerr;
  private float mPitcherr;
  private float mYawerr;
  private float mVxerr;
  private float mVyerr;
  private float mVzerr;

  public float Xerr
  {
    get => this.mXerr;
    set
    {
      this.mXerr = value;
      this.NotifyUpdated();
    }
  }

  public float Yerr
  {
    get => this.mYerr;
    set
    {
      this.mYerr = value;
      this.NotifyUpdated();
    }
  }

  public float Zerr
  {
    get => this.mZerr;
    set
    {
      this.mZerr = value;
      this.NotifyUpdated();
    }
  }

  public float Rollerr
  {
    get => this.mRollerr;
    set
    {
      this.mRollerr = value;
      this.NotifyUpdated();
    }
  }

  public float Pitcherr
  {
    get => this.mPitcherr;
    set
    {
      this.mPitcherr = value;
      this.NotifyUpdated();
    }
  }

  public float Yawerr
  {
    get => this.mYawerr;
    set
    {
      this.mYawerr = value;
      this.NotifyUpdated();
    }
  }

  public float Vxerr
  {
    get => this.mVxerr;
    set
    {
      this.mVxerr = value;
      this.NotifyUpdated();
    }
  }

  public float Vyerr
  {
    get => this.mVyerr;
    set
    {
      this.mVyerr = value;
      this.NotifyUpdated();
    }
  }

  public float Vzerr
  {
    get => this.mVzerr;
    set
    {
      this.mVzerr = value;
      this.NotifyUpdated();
    }
  }

  public UasStateCorrection()
  {
    this.mMessageId = (byte) 64 /*0x40*/;
    this.CrcExtra = (byte) 130;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mXerr);
    s.Write(this.mYerr);
    s.Write(this.mZerr);
    s.Write(this.mRollerr);
    s.Write(this.mPitcherr);
    s.Write(this.mYawerr);
    s.Write(this.mVxerr);
    s.Write(this.mVyerr);
    s.Write(this.mVzerr);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mXerr = s.ReadSingle();
    this.mYerr = s.ReadSingle();
    this.mZerr = s.ReadSingle();
    this.mRollerr = s.ReadSingle();
    this.mPitcherr = s.ReadSingle();
    this.mYawerr = s.ReadSingle();
    this.mVxerr = s.ReadSingle();
    this.mVyerr = s.ReadSingle();
    this.mVzerr = s.ReadSingle();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Corrects the systems state by adding an error correction term to the position and velocity, and by rotating the attitude by a correction angle."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Xerr",
      Description = "x position error",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Yerr",
      Description = "y position error",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Zerr",
      Description = "z position error",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Rollerr",
      Description = "roll error (radians)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Pitcherr",
      Description = "pitch error (radians)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Yawerr",
      Description = "yaw error (radians)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Vxerr",
      Description = "x velocity",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Vyerr",
      Description = "y velocity",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Vzerr",
      Description = "z velocity",
      NumElements = 1
    });
  }
}
