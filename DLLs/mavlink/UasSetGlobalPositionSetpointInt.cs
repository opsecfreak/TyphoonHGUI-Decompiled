// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasSetGlobalPositionSetpointInt
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasSetGlobalPositionSetpointInt : UasMessage
{
  private int mLatitude;
  private int mLongitude;
  private int mAltitude;
  private short mYaw;
  private MavFrame mCoordinateFrame;

  public int Latitude
  {
    get => this.mLatitude;
    set
    {
      this.mLatitude = value;
      this.NotifyUpdated();
    }
  }

  public int Longitude
  {
    get => this.mLongitude;
    set
    {
      this.mLongitude = value;
      this.NotifyUpdated();
    }
  }

  public int Altitude
  {
    get => this.mAltitude;
    set
    {
      this.mAltitude = value;
      this.NotifyUpdated();
    }
  }

  public short Yaw
  {
    get => this.mYaw;
    set
    {
      this.mYaw = value;
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

  public UasSetGlobalPositionSetpointInt()
  {
    this.mMessageId = (byte) 53;
    this.CrcExtra = (byte) 33;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mLatitude);
    s.Write(this.mLongitude);
    s.Write(this.mAltitude);
    s.Write(this.mYaw);
    s.Write((byte) this.mCoordinateFrame);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mLatitude = s.ReadInt32();
    this.mLongitude = s.ReadInt32();
    this.mAltitude = s.ReadInt32();
    this.mYaw = s.ReadInt16();
    this.mCoordinateFrame = (MavFrame) s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Set the current global position setpoint."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Latitude",
      Description = "Latitude (WGS84), in degrees * 1E7",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Longitude",
      Description = "Longitude (WGS84), in degrees * 1E7",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Altitude",
      Description = "Altitude (WGS84), in meters * 1000 (positive for up)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Yaw",
      Description = "Desired yaw angle in degrees * 100",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "CoordinateFrame",
      Description = "Coordinate frame - valid values are only MAV_FRAME_GLOBAL or MAV_FRAME_GLOBAL_RELATIVE_ALT",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("MavFrame")
    });
  }
}
