// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasSetLocalPositionSetpoint
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasSetLocalPositionSetpoint : UasMessage
{
  private float mX;
  private float mY;
  private float mZ;
  private float mYaw;
  private byte mTargetSystem;
  private byte mTargetComponent;
  private MavFrame mCoordinateFrame;

  public float X
  {
    get => this.mX;
    set
    {
      this.mX = value;
      this.NotifyUpdated();
    }
  }

  public float Y
  {
    get => this.mY;
    set
    {
      this.mY = value;
      this.NotifyUpdated();
    }
  }

  public float Z
  {
    get => this.mZ;
    set
    {
      this.mZ = value;
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

  public byte TargetSystem
  {
    get => this.mTargetSystem;
    set
    {
      this.mTargetSystem = value;
      this.NotifyUpdated();
    }
  }

  public byte TargetComponent
  {
    get => this.mTargetComponent;
    set
    {
      this.mTargetComponent = value;
      this.NotifyUpdated();
    }
  }

  public MavFrame CoordinateFrame
  {
    get => this.mCoordinateFrame;
    set
    {
      this.mCoordinateFrame = value;
      this.NotifyUpdated();
    }
  }

  public UasSetLocalPositionSetpoint()
  {
    this.mMessageId = (byte) 50;
    this.CrcExtra = (byte) 214;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mX);
    s.Write(this.mY);
    s.Write(this.mZ);
    s.Write(this.mYaw);
    s.Write(this.mTargetSystem);
    s.Write(this.mTargetComponent);
    s.Write((byte) this.mCoordinateFrame);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mX = s.ReadSingle();
    this.mY = s.ReadSingle();
    this.mZ = s.ReadSingle();
    this.mYaw = s.ReadSingle();
    this.mTargetSystem = s.ReadByte();
    this.mTargetComponent = s.ReadByte();
    this.mCoordinateFrame = (MavFrame) s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Set the setpoint for a local position controller. This is the position in local coordinates the MAV should fly to. This message is sent by the path/MISSION planner to the onboard position controller. As some MAVs have a degree of freedom in yaw (e.g. all helicopters/quadrotors), the desired yaw angle is part of the message."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "X",
      Description = "x position",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Y",
      Description = "y position",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Z",
      Description = "z position",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Yaw",
      Description = "Desired yaw angle",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TargetSystem",
      Description = "System ID",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TargetComponent",
      Description = "Component ID",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "CoordinateFrame",
      Description = "Coordinate frame - valid values are only MAV_FRAME_LOCAL_NED or MAV_FRAME_LOCAL_ENU",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("MavFrame")
    });
  }
}
