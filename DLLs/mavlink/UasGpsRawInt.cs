// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasGpsRawInt
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasGpsRawInt : UasMessage
{
  private ulong mTimeUsec;
  private int mLat;
  private int mLon;
  private int mAlt;
  private ushort mEph;
  private ushort mEpv;
  private ushort mVel;
  private ushort mCog;
  private byte mFixType;
  private byte mSatellitesVisible;

  public ulong TimeUsec
  {
    get => this.mTimeUsec;
    set
    {
      this.mTimeUsec = value;
      this.NotifyUpdated();
    }
  }

  public int Lat
  {
    get => this.mLat;
    set
    {
      this.mLat = value;
      this.NotifyUpdated();
    }
  }

  public int Lon
  {
    get => this.mLon;
    set
    {
      this.mLon = value;
      this.NotifyUpdated();
    }
  }

  public int Alt
  {
    get => this.mAlt;
    set
    {
      this.mAlt = value;
      this.NotifyUpdated();
    }
  }

  public ushort Eph
  {
    get => this.mEph;
    set
    {
      this.mEph = value;
      this.NotifyUpdated();
    }
  }

  public ushort Epv
  {
    get => this.mEpv;
    set
    {
      this.mEpv = value;
      this.NotifyUpdated();
    }
  }

  public ushort Vel
  {
    get => this.mVel;
    set
    {
      this.mVel = value;
      this.NotifyUpdated();
    }
  }

  public ushort Cog
  {
    get => this.mCog;
    set
    {
      this.mCog = value;
      this.NotifyUpdated();
    }
  }

  public byte FixType
  {
    get => this.mFixType;
    set
    {
      this.mFixType = value;
      this.NotifyUpdated();
    }
  }

  public byte SatellitesVisible
  {
    get => this.mSatellitesVisible;
    set
    {
      this.mSatellitesVisible = value;
      this.NotifyUpdated();
    }
  }

  public UasGpsRawInt()
  {
    this.mMessageId = (byte) 24;
    this.CrcExtra = (byte) 24;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeUsec);
    s.Write(this.mLat);
    s.Write(this.mLon);
    s.Write(this.mAlt);
    s.Write(this.mEph);
    s.Write(this.mEpv);
    s.Write(this.mVel);
    s.Write(this.mCog);
    s.Write(this.mFixType);
    s.Write(this.mSatellitesVisible);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeUsec = s.ReadUInt64();
    this.mLat = s.ReadInt32();
    this.mLon = s.ReadInt32();
    this.mAlt = s.ReadInt32();
    this.mEph = s.ReadUInt16();
    this.mEpv = s.ReadUInt16();
    this.mVel = s.ReadUInt16();
    this.mCog = s.ReadUInt16();
    this.mFixType = s.ReadByte();
    this.mSatellitesVisible = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "GpsRawInt;The global position, as returned by the Global Positioning System (GPS). This is                  NOT the global position estimate of the sytem, but rather a RAW sensor value. See message GLOBAL_POSITION for the global position estimate. Coordinate frame is right-handed, Z-axis up (GPS frame)."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeUsec",
      Value = this.TimeUsec.ToString(),
      Description = "Timestamp (microseconds since UNIX epoch or microseconds since system boot)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Lat",
      Value = this.Lat.ToString(),
      Description = "Latitude (WGS84), in degrees * 1E7",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Lon",
      Value = this.Lon.ToString(),
      Description = "Longitude (WGS84), in degrees * 1E7",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Alt",
      Value = this.Alt.ToString(),
      Description = "Altitude (WGS84), in meters * 1000 (positive for up)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Eph",
      Value = this.Eph.ToString(),
      Description = "GPS HDOP horizontal dilution of position in cm (m*100). If unknown, set to: UINT16_MAX",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Epv",
      Value = this.Epv.ToString(),
      Description = "GPS VDOP vertical dilution of position in cm (m*100). If unknown, set to: UINT16_MAX",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Vel",
      Value = this.Vel.ToString(),
      Description = "GPS ground speed (m/s * 100). If unknown, set to: UINT16_MAX",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Cog",
      Value = this.Cog.ToString(),
      Description = "Course over ground (NOT heading, but direction of movement) in degrees * 100, 0.0..359.99 degrees. If unknown, set to: UINT16_MAX",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "FixType",
      Value = this.FixType.ToString(),
      Description = "0-1: no fix, 2: 2D fix, 3: 3D fix. Some applications will not use the value of this field unless it is at least two, so always correctly fill in the fix.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "SatellitesVisible",
      Value = this.SatellitesVisible.ToString(),
      Description = "Number of satellites visible. If unknown, set to 255",
      NumElements = 1
    });
  }
}
