// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasSetpoint6dof
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasSetpoint6dof : UasMessage
{
  private float mTransX;
  private float mTransY;
  private float mTransZ;
  private float mRotX;
  private float mRotY;
  private float mRotZ;
  private byte mTargetSystem;

  public float TransX
  {
    get => this.mTransX;
    set
    {
      this.mTransX = value;
      this.NotifyUpdated();
    }
  }

  public float TransY
  {
    get => this.mTransY;
    set
    {
      this.mTransY = value;
      this.NotifyUpdated();
    }
  }

  public float TransZ
  {
    get => this.mTransZ;
    set
    {
      this.mTransZ = value;
      this.NotifyUpdated();
    }
  }

  public float RotX
  {
    get => this.mRotX;
    set
    {
      this.mRotX = value;
      this.NotifyUpdated();
    }
  }

  public float RotY
  {
    get => this.mRotY;
    set
    {
      this.mRotY = value;
      this.NotifyUpdated();
    }
  }

  public float RotZ
  {
    get => this.mRotZ;
    set
    {
      this.mRotZ = value;
      this.NotifyUpdated();
    }
  }

  public byte TargetSystem
  {
    get => this.mTargetSystem;
    set
    {
      this.mTargetSystem = value;
      this.NotifyUpdated();
    }
  }

  public UasSetpoint6dof()
  {
    this.mMessageId = (byte) 149;
    this.CrcExtra = (byte) 15;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTransX);
    s.Write(this.mTransY);
    s.Write(this.mTransZ);
    s.Write(this.mRotX);
    s.Write(this.mRotY);
    s.Write(this.mRotZ);
    s.Write(this.mTargetSystem);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTransX = s.ReadSingle();
    this.mTransY = s.ReadSingle();
    this.mTransZ = s.ReadSingle();
    this.mRotX = s.ReadSingle();
    this.mRotY = s.ReadSingle();
    this.mRotZ = s.ReadSingle();
    this.mTargetSystem = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Set the 6 DOF setpoint for a attitude and position controller."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TransX",
      Description = "Translational Component in x",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TransY",
      Description = "Translational Component in y",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TransZ",
      Description = "Translational Component in z",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "RotX",
      Description = "Rotational Component in x",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "RotY",
      Description = "Rotational Component in y",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "RotZ",
      Description = "Rotational Component in z",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TargetSystem",
      Description = "System ID",
      NumElements = 1
    });
  }
}
