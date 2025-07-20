// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasManualControl
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasManualControl : UasMessage
{
  private short mX;
  private short mY;
  private short mZ;
  private short mR;
  private ushort mButtons;
  private byte mTarget;

  public short X
  {
    get => this.mX;
    set
    {
      this.mX = value;
      this.NotifyUpdated();
    }
  }

  public short Y
  {
    get => this.mY;
    set
    {
      this.mY = value;
      this.NotifyUpdated();
    }
  }

  public short Z
  {
    get => this.mZ;
    set
    {
      this.mZ = value;
      this.NotifyUpdated();
    }
  }

  public short R
  {
    get => this.mR;
    set
    {
      this.mR = value;
      this.NotifyUpdated();
    }
  }

  public ushort Buttons
  {
    get => this.mButtons;
    set
    {
      this.mButtons = value;
      this.NotifyUpdated();
    }
  }

  public byte Target
  {
    get => this.mTarget;
    set
    {
      this.mTarget = value;
      this.NotifyUpdated();
    }
  }

  public UasManualControl()
  {
    this.mMessageId = (byte) 69;
    this.CrcExtra = (byte) 243;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mX);
    s.Write(this.mY);
    s.Write(this.mZ);
    s.Write(this.mR);
    s.Write(this.mButtons);
    s.Write(this.mTarget);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mX = s.ReadInt16();
    this.mY = s.ReadInt16();
    this.mZ = s.ReadInt16();
    this.mR = s.ReadInt16();
    this.mButtons = s.ReadUInt16();
    this.mTarget = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "This message provides an API for manually controlling the vehicle using standard joystick axes nomenclature, along with a joystick-like input device. Unused axes can be disabled an buttons are also transmit as boolean values of their "
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "X",
      Description = "X-axis, normalized to the range [-1000,1000]. A value of INT16_MAX indicates that this axis is invalid. Generally corresponds to forward(1000)-backward(-1000) movement on a joystick and the pitch of a vehicle.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Y",
      Description = "Y-axis, normalized to the range [-1000,1000]. A value of INT16_MAX indicates that this axis is invalid. Generally corresponds to left(-1000)-right(1000) movement on a joystick and the roll of a vehicle.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Z",
      Description = "Z-axis, normalized to the range [-1000,1000]. A value of INT16_MAX indicates that this axis is invalid. Generally corresponds to a separate slider movement with maximum being 1000 and minimum being -1000 on a joystick and the thrust of a vehicle.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "R",
      Description = "R-axis, normalized to the range [-1000,1000]. A value of INT16_MAX indicates that this axis is invalid. Generally corresponds to a twisting of the joystick, with counter-clockwise being 1000 and clockwise being -1000, and the yaw of a vehicle.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Buttons",
      Description = "A bitfield corresponding to the joystick buttons' current state, 1 for pressed, 0 for released. The lowest bit corresponds to Button 1.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Target",
      Description = "The system to be controlled.",
      NumElements = 1
    });
  }
}
