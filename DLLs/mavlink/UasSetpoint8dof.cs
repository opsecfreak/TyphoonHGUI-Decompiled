// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasSetpoint8dof
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasSetpoint8dof : UasMessage
{
  private float mVal1;
  private float mVal2;
  private float mVal3;
  private float mVal4;
  private float mVal5;
  private float mVal6;
  private float mVal7;
  private float mVal8;
  private byte mTargetSystem;

  public float Val1
  {
    get => this.mVal1;
    set
    {
      this.mVal1 = value;
      this.NotifyUpdated();
    }
  }

  public float Val2
  {
    get => this.mVal2;
    set
    {
      this.mVal2 = value;
      this.NotifyUpdated();
    }
  }

  public float Val3
  {
    get => this.mVal3;
    set
    {
      this.mVal3 = value;
      this.NotifyUpdated();
    }
  }

  public float Val4
  {
    get => this.mVal4;
    set
    {
      this.mVal4 = value;
      this.NotifyUpdated();
    }
  }

  public float Val5
  {
    get => this.mVal5;
    set
    {
      this.mVal5 = value;
      this.NotifyUpdated();
    }
  }

  public float Val6
  {
    get => this.mVal6;
    set
    {
      this.mVal6 = value;
      this.NotifyUpdated();
    }
  }

  public float Val7
  {
    get => this.mVal7;
    set
    {
      this.mVal7 = value;
      this.NotifyUpdated();
    }
  }

  public float Val8
  {
    get => this.mVal8;
    set
    {
      this.mVal8 = value;
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

  public UasSetpoint8dof()
  {
    this.mMessageId = (byte) 148;
    this.CrcExtra = (byte) 241;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mVal1);
    s.Write(this.mVal2);
    s.Write(this.mVal3);
    s.Write(this.mVal4);
    s.Write(this.mVal5);
    s.Write(this.mVal6);
    s.Write(this.mVal7);
    s.Write(this.mVal8);
    s.Write(this.mTargetSystem);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mVal1 = s.ReadSingle();
    this.mVal2 = s.ReadSingle();
    this.mVal3 = s.ReadSingle();
    this.mVal4 = s.ReadSingle();
    this.mVal5 = s.ReadSingle();
    this.mVal6 = s.ReadSingle();
    this.mVal7 = s.ReadSingle();
    this.mVal8 = s.ReadSingle();
    this.mTargetSystem = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Set the 8 DOF setpoint for a controller."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Val1",
      Description = "Value 1",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Val2",
      Description = "Value 2",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Val3",
      Description = "Value 3",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Val4",
      Description = "Value 4",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Val5",
      Description = "Value 5",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Val6",
      Description = "Value 6",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Val7",
      Description = "Value 7",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Val8",
      Description = "Value 8",
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
