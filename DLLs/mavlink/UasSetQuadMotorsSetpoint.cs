// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasSetQuadMotorsSetpoint
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasSetQuadMotorsSetpoint : UasMessage
{
  private ushort mMotorFrontNw;
  private ushort mMotorRightNe;
  private ushort mMotorBackSe;
  private ushort mMotorLeftSw;
  private byte mTargetSystem;

  public ushort MotorFrontNw
  {
    get => this.mMotorFrontNw;
    set
    {
      this.mMotorFrontNw = value;
      this.NotifyUpdated();
    }
  }

  public ushort MotorRightNe
  {
    get => this.mMotorRightNe;
    set
    {
      this.mMotorRightNe = value;
      this.NotifyUpdated();
    }
  }

  public ushort MotorBackSe
  {
    get => this.mMotorBackSe;
    set
    {
      this.mMotorBackSe = value;
      this.NotifyUpdated();
    }
  }

  public ushort MotorLeftSw
  {
    get => this.mMotorLeftSw;
    set
    {
      this.mMotorLeftSw = value;
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

  public UasSetQuadMotorsSetpoint()
  {
    this.mMessageId = (byte) 60;
    this.CrcExtra = (byte) 30;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mMotorFrontNw);
    s.Write(this.mMotorRightNe);
    s.Write(this.mMotorBackSe);
    s.Write(this.mMotorLeftSw);
    s.Write(this.mTargetSystem);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mMotorFrontNw = s.ReadUInt16();
    this.mMotorRightNe = s.ReadUInt16();
    this.mMotorBackSe = s.ReadUInt16();
    this.mMotorLeftSw = s.ReadUInt16();
    this.mTargetSystem = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Setpoint in the four motor speeds"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "MotorFrontNw",
      Description = "Front motor in + configuration, front left motor in x configuration",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "MotorRightNe",
      Description = "Right motor in + configuration, front right motor in x configuration",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "MotorBackSe",
      Description = "Back motor in + configuration, back right motor in x configuration",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "MotorLeftSw",
      Description = "Left motor in + configuration, back left motor in x configuration",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TargetSystem",
      Description = "System ID of the system that should set these motor commands",
      NumElements = 1
    });
  }
}
