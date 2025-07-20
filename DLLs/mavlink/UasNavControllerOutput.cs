// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasNavControllerOutput
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasNavControllerOutput : UasMessage
{
  private float mNavRoll;
  private float mNavPitch;
  private float mAltError;
  private float mAspdError;
  private float mXtrackError;
  private short mNavBearing;
  private short mTargetBearing;
  private ushort mWpDist;

  public float NavRoll
  {
    get => this.mNavRoll;
    set
    {
      this.mNavRoll = value;
      this.NotifyUpdated();
    }
  }

  public float NavPitch
  {
    get => this.mNavPitch;
    set
    {
      this.mNavPitch = value;
      this.NotifyUpdated();
    }
  }

  public float AltError
  {
    get => this.mAltError;
    set
    {
      this.mAltError = value;
      this.NotifyUpdated();
    }
  }

  public float AspdError
  {
    get => this.mAspdError;
    set
    {
      this.mAspdError = value;
      this.NotifyUpdated();
    }
  }

  public float XtrackError
  {
    get => this.mXtrackError;
    set
    {
      this.mXtrackError = value;
      this.NotifyUpdated();
    }
  }

  public short NavBearing
  {
    get => this.mNavBearing;
    set
    {
      this.mNavBearing = value;
      this.NotifyUpdated();
    }
  }

  public short TargetBearing
  {
    get => this.mTargetBearing;
    set
    {
      this.mTargetBearing = value;
      this.NotifyUpdated();
    }
  }

  public ushort WpDist
  {
    get => this.mWpDist;
    set
    {
      this.mWpDist = value;
      this.NotifyUpdated();
    }
  }

  public UasNavControllerOutput()
  {
    this.mMessageId = (byte) 62;
    this.CrcExtra = (byte) 183;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mNavRoll);
    s.Write(this.mNavPitch);
    s.Write(this.mAltError);
    s.Write(this.mAspdError);
    s.Write(this.mXtrackError);
    s.Write(this.mNavBearing);
    s.Write(this.mTargetBearing);
    s.Write(this.mWpDist);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mNavRoll = s.ReadSingle();
    this.mNavPitch = s.ReadSingle();
    this.mAltError = s.ReadSingle();
    this.mAspdError = s.ReadSingle();
    this.mXtrackError = s.ReadSingle();
    this.mNavBearing = s.ReadInt16();
    this.mTargetBearing = s.ReadInt16();
    this.mWpDist = s.ReadUInt16();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "NavControllerOutput;Outputs of the APM navigation controller. The primary use of this message is to check the response and signs of the controller before actual flight and to assist with tuning controller parameters."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "NavRoll",
      Value = this.NavRoll.ToString(),
      Description = "Current desired roll in degrees",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "NavPitch",
      Value = this.NavPitch.ToString(),
      Description = "Current desired pitch in degrees",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "AltError",
      Value = this.AltError.ToString(),
      Description = "Current altitude error in meters",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "AspdError",
      Value = this.AspdError.ToString(),
      Description = "Current airspeed error in meters/second",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "XtrackError",
      Value = this.XtrackError.ToString(),
      Description = "Current crosstrack error on x-y plane in meters",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "NavBearing",
      Value = this.NavBearing.ToString(),
      Description = "Current desired heading in degrees",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TargetBearing",
      Value = this.TargetBearing.ToString(),
      Description = "Bearing to current MISSION/target in degrees",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "WpDist",
      Value = this.WpDist.ToString(),
      Description = "Distance to active MISSION in meters",
      NumElements = 1
    });
  }
}
