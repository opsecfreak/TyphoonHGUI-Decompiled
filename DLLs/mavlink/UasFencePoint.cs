// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasFencePoint
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasFencePoint : UasMessage
{
  private float mLat;
  private float mLng;
  private byte mTargetSystem;
  private byte mTargetComponent;
  private byte mIdx;
  private byte mCount;

  public float Lat
  {
    get => this.mLat;
    set
    {
      this.mLat = value;
      this.NotifyUpdated();
    }
  }

  public float Lng
  {
    get => this.mLng;
    set
    {
      this.mLng = value;
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

  public UasFencePoint()
  {
    this.mMessageId = (byte) 160 /*0xA0*/;
    this.CrcExtra = (byte) 78;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mLat);
    s.Write(this.mLng);
    s.Write(this.mTargetSystem);
    s.Write(this.mTargetComponent);
    s.Write(this.mIdx);
    s.Write(this.mCount);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mLat = s.ReadSingle();
    this.mLng = s.ReadSingle();
    this.mTargetSystem = s.ReadByte();
    this.mTargetComponent = s.ReadByte();
    this.mIdx = s.ReadByte();
    this.mCount = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "A fence point. Used to set a point when from  \t      GCS -> MAV. Also used to return a point from MAV -> GCS"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Lat",
      Description = "Latitude of point",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Lng",
      Description = "Longitude of point",
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
      Description = "point index (first point is 1, 0 is for return point)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Count",
      Description = "total number of points (for sanity checking)",
      NumElements = 1
    });
  }
}
