// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasSetGpsGlobalOrigin
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasSetGpsGlobalOrigin : UasMessage
{
  private int mLatitude;
  private int mLongitude;
  private int mAltitude;
  private byte mTargetSystem;

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

  public byte TargetSystem
  {
    get => this.mTargetSystem;
    set
    {
      this.mTargetSystem = value;
      this.NotifyUpdated();
    }
  }

  public UasSetGpsGlobalOrigin()
  {
    this.mMessageId = (byte) 48 /*0x30*/;
    this.CrcExtra = (byte) 41;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mLatitude);
    s.Write(this.mLongitude);
    s.Write(this.mAltitude);
    s.Write(this.mTargetSystem);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mLatitude = s.ReadInt32();
    this.mLongitude = s.ReadInt32();
    this.mAltitude = s.ReadInt32();
    this.mTargetSystem = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "As local waypoints exist, the global MISSION reference allows to transform between the local coordinate frame and the global (GPS) coordinate frame. This can be necessary when e.g. in- and outdoor settings are connected and the MAV should move from in- to outdoor."
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
      Description = "Longitude (WGS84, in degrees * 1E7",
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
      Name = "TargetSystem",
      Description = "System ID",
      NumElements = 1
    });
  }
}
