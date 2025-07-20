// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasRallyPoint
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasRallyPoint : UasMessage
{
  private int mLat;
  private int mLng;
  private short mAlt;
  private short mBreakAlt;
  private ushort mLandDir;
  private byte mTargetSystem;
  private byte mTargetComponent;
  private byte mIdx;
  private byte mCount;
  private RallyFlags mFlags;

  public int Lat
  {
    get => this.mLat;
    set
    {
      this.mLat = value;
      this.NotifyUpdated();
    }
  }

  public int Lng
  {
    get => this.mLng;
    set
    {
      this.mLng = value;
      this.NotifyUpdated();
    }
  }

  public short Alt
  {
    get => this.mAlt;
    set
    {
      this.mAlt = value;
      this.NotifyUpdated();
    }
  }

  public short BreakAlt
  {
    get => this.mBreakAlt;
    set
    {
      this.mBreakAlt = value;
      this.NotifyUpdated();
    }
  }

  public ushort LandDir
  {
    get => this.mLandDir;
    set
    {
      this.mLandDir = value;
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

  public byte Idx
  {
    get => this.mIdx;
    set
    {
      this.mIdx = value;
      this.NotifyUpdated();
    }
  }

  public byte Count
  {
    get => this.mCount;
    set
    {
      this.mCount = value;
      this.NotifyUpdated();
    }
  }

  public RallyFlags Flags
  {
    get => this.mFlags;
    set
    {
      this.mFlags = value;
      this.NotifyUpdated();
    }
  }

  public UasRallyPoint()
  {
    this.mMessageId = (byte) 175;
    this.CrcExtra = (byte) 138;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mLat);
    s.Write(this.mLng);
    s.Write(this.mAlt);
    s.Write(this.mBreakAlt);
    s.Write(this.mLandDir);
    s.Write(this.mTargetSystem);
    s.Write(this.mTargetComponent);
    s.Write(this.mIdx);
    s.Write(this.mCount);
    s.Write((byte) this.mFlags);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mLat = s.ReadInt32();
    this.mLng = s.ReadInt32();
    this.mAlt = s.ReadInt16();
    this.mBreakAlt = s.ReadInt16();
    this.mLandDir = s.ReadUInt16();
    this.mTargetSystem = s.ReadByte();
    this.mTargetComponent = s.ReadByte();
    this.mIdx = s.ReadByte();
    this.mCount = s.ReadByte();
    this.mFlags = (RallyFlags) s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "A rally point. Used to set a point when from GCS -> MAV. Also used to return a point from MAV -> GCS"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Lat",
      Description = "Latitude of point in degrees * 1E7",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Lng",
      Description = "Longitude of point in degrees * 1E7",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Alt",
      Description = "Transit / loiter altitude in meters relative to home",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "BreakAlt",
      Description = "Break altitude in meters relative to home",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "LandDir",
      Description = "Heading to aim for when landing. In centi-degrees.",
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
      Name = "Idx",
      Description = "point index (first point is 0)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Count",
      Description = "total number of points (for sanity checking)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Flags",
      Description = "See RALLY_FLAGS enum for definition of the bitmask.",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("RallyFlags")
    });
  }
}
