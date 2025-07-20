// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasVfrHud
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasVfrHud : UasMessage
{
  private float mAirspeed;
  private float mGroundspeed;
  private float mAlt;
  private float mClimb;
  private short mHeading;
  private ushort mThrottle;

  public float Airspeed
  {
    get => this.mAirspeed;
    set
    {
      this.mAirspeed = value;
      this.NotifyUpdated();
    }
  }

  public float Groundspeed
  {
    get => this.mGroundspeed;
    set
    {
      this.mGroundspeed = value;
      this.NotifyUpdated();
    }
  }

  public float Alt
  {
    get => this.mAlt;
    set
    {
      this.mAlt = value;
      this.NotifyUpdated();
    }
  }

  public float Climb
  {
    get => this.mClimb;
    set
    {
      this.mClimb = value;
      this.NotifyUpdated();
    }
  }

  public short Heading
  {
    get => this.mHeading;
    set
    {
      this.mHeading = value;
      this.NotifyUpdated();
    }
  }

  public ushort Throttle
  {
    get => this.mThrottle;
    set
    {
      this.mThrottle = value;
      this.NotifyUpdated();
    }
  }

  public UasVfrHud()
  {
    this.mMessageId = (byte) 74;
    this.CrcExtra = (byte) 20;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mAirspeed);
    s.Write(this.mGroundspeed);
    s.Write(this.mAlt);
    s.Write(this.mClimb);
    s.Write(this.mHeading);
    s.Write(this.mThrottle);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mAirspeed = s.ReadSingle();
    this.mGroundspeed = s.ReadSingle();
    this.mAlt = s.ReadSingle();
    this.mClimb = s.ReadSingle();
    this.mHeading = s.ReadInt16();
    this.mThrottle = s.ReadUInt16();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "VfrHud;Metrics typically displayed on a HUD for fixed wing aircraft"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Airspeed",
      Value = this.Airspeed.ToString(),
      Description = "Current airspeed in m/s",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Groundspeed",
      Value = this.Groundspeed.ToString(),
      Description = "Current ground speed in m/s",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Alt",
      Value = this.Alt.ToString(),
      Description = "Current altitude (MSL), in meters",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Climb",
      Value = this.Climb.ToString(),
      Description = "Current climb rate in meters/second",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Heading",
      Value = this.Heading.ToString(),
      Description = "Current heading in degrees, in compass units (0..360, 0=north)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Throttle",
      Value = this.Throttle.ToString(),
      Description = "Current throttle setting in integer percent, 0 to 100",
      NumElements = 1
    });
  }
}
