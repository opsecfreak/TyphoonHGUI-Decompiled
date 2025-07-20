// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasGpsGlobalOrigin
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasGpsGlobalOrigin : UasMessage
{
  private int mLatitude;
  private int mLongitude;
  private int mAltitude;

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

  public UasGpsGlobalOrigin()
  {
    this.mMessageId = (byte) 49;
    this.CrcExtra = (byte) 39;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mLatitude);
    s.Write(this.mLongitude);
    s.Write(this.mAltitude);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mLatitude = s.ReadInt32();
    this.mLongitude = s.ReadInt32();
    this.mAltitude = s.ReadInt32();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Once the MAV sets a new GPS-Local correspondence, this message announces the origin (0,0,0) position"
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
  }
}
