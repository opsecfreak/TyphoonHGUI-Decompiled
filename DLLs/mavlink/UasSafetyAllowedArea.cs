// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasSafetyAllowedArea
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasSafetyAllowedArea : UasMessage
{
  private float mP1x;
  private float mP1y;
  private float mP1z;
  private float mP2x;
  private float mP2y;
  private float mP2z;
  private MavFrame mFrame;

  public float P1x
  {
    get => this.mP1x;
    set
    {
      this.mP1x = value;
      this.NotifyUpdated();
    }
  }

  public float P1y
  {
    get => this.mP1y;
    set
    {
      this.mP1y = value;
      this.NotifyUpdated();
    }
  }

  public float P1z
  {
    get => this.mP1z;
    set
    {
      this.mP1z = value;
      this.NotifyUpdated();
    }
  }

  public float P2x
  {
    get => this.mP2x;
    set
    {
      this.mP2x = value;
      this.NotifyUpdated();
    }
  }

  public float P2y
  {
    get => this.mP2y;
    set
    {
      this.mP2y = value;
      this.NotifyUpdated();
    }
  }

  public float P2z
  {
    get => this.mP2z;
    set
    {
      this.mP2z = value;
      this.NotifyUpdated();
    }
  }

  public MavFrame Frame
  {
    get => this.mFrame;
    set
    {
      this.mFrame = value;
      this.NotifyUpdated();
    }
  }

  public UasSafetyAllowedArea()
  {
    this.mMessageId = (byte) 55;
    this.CrcExtra = (byte) 3;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mP1x);
    s.Write(this.mP1y);
    s.Write(this.mP1z);
    s.Write(this.mP2x);
    s.Write(this.mP2y);
    s.Write(this.mP2z);
    s.Write((byte) this.mFrame);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mP1x = s.ReadSingle();
    this.mP1y = s.ReadSingle();
    this.mP1z = s.ReadSingle();
    this.mP2x = s.ReadSingle();
    this.mP2y = s.ReadSingle();
    this.mP2z = s.ReadSingle();
    this.mFrame = (MavFrame) s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Read out the safety zone the MAV currently assumes."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "P1x",
      Description = "x position 1 / Latitude 1",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "P1y",
      Description = "y position 1 / Longitude 1",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "P1z",
      Description = "z position 1 / Altitude 1",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "P2x",
      Description = "x position 2 / Latitude 2",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "P2y",
      Description = "y position 2 / Longitude 2",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "P2z",
      Description = "z position 2 / Altitude 2",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Frame",
      Description = "Coordinate frame, as defined by MAV_FRAME enum in mavlink_types.h. Can be either global, GPS, right-handed with Z axis up or local, right handed, Z axis down.",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("MavFrame")
    });
  }
}
