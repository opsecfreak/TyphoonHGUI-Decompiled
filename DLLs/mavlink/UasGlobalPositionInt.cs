// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasGlobalPositionInt
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasGlobalPositionInt : UasMessage
{
  private uint mTimeBootMs;
  private int mLat;
  private int mLon;
  private int mAlt;
  private int mRelativeAlt;
  private short mVx;
  private short mVy;
  private short mVz;
  private ushort mHdg;

  public uint TimeBootMs
  {
    get => this.mTimeBootMs;
    set
    {
      this.mTimeBootMs = value;
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

  public int RelativeAlt
  {
    get => this.mRelativeAlt;
    set
    {
      this.mRelativeAlt = value;
      this.NotifyUpdated();
    }
  }

  public short Vx
  {
    get => this.mVx;
    set
    {
      this.mVx = value;
      this.NotifyUpdated();
    }
  }

  public short Vy
  {
    get => this.mVy;
    set
    {
      this.mVy = value;
      this.NotifyUpdated();
    }
  }

  public short Vz
  {
    get => this.mVz;
    set
    {
      this.mVz = value;
      this.NotifyUpdated();
    }
  }

  public ushort Hdg
  {
    get => this.mHdg;
    set
    {
      this.mHdg = value;
      this.NotifyUpdated();
    }
  }

  public UasGlobalPositionInt()
  {
    this.mMessageId = (byte) 33;
    this.CrcExtra = (byte) 104;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeBootMs);
    s.Write(this.mLat);
    s.Write(this.mLon);
    s.Write(this.mAlt);
    s.Write(this.mRelativeAlt);
    s.Write(this.mVx);
    s.Write(this.mVy);
    s.Write(this.mVz);
    s.Write(this.mHdg);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeBootMs = s.ReadUInt32();
    this.mLat = s.ReadInt32();
    this.mLon = s.ReadInt32();
    this.mAlt = s.ReadInt32();
    this.mRelativeAlt = s.ReadInt32();
    this.mVx = s.ReadInt16();
    this.mVy = s.ReadInt16();
    this.mVz = s.ReadInt16();
    this.mHdg = s.ReadUInt16();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "GlobalPositionInt;The filtered global position (e.g. fused GPS and accelerometers). The position is in GPS-frame (right-handed, Z-up). It                 is designed as scaled integer message since the resolution of float is not sufficient."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeBootMs",
      Value = this.TimeBootMs.ToString(),
      Description = "Timestamp (milliseconds since system boot)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Lat",
      Value = this.Lat.ToString(),
      Description = "Latitude, expressed as * 1E7",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Lon",
      Value = this.Lon.ToString(),
      Description = "Longitude, expressed as * 1E7",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Alt",
      Value = this.Alt.ToString(),
      Description = "Altitude in meters, expressed as * 1000 (millimeters), above MSL",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "RelativeAlt",
      Value = this.RelativeAlt.ToString(),
      Description = "Altitude above ground in meters, expressed as * 1000 (millimeters)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Vx",
      Value = this.Vx.ToString(),
      Description = "Ground X Speed (Latitude), expressed as m/s * 100",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Vy",
      Value = this.Vy.ToString(),
      Description = "Ground Y Speed (Longitude), expressed as m/s * 100",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Vz",
      Value = this.Vz.ToString(),
      Description = "Ground Z Speed (Altitude), expressed as m/s * 100",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Hdg",
      Value = this.Hdg.ToString(),
      Description = "Compass heading in degrees * 100, 0.0..359.99 degrees. If unknown, set to: UINT16_MAX",
      NumElements = 1
    });
  }
}
