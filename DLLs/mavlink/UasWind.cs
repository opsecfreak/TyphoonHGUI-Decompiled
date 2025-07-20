// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasWind
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasWind : UasMessage
{
  private float mDirection;
  private float mSpeed;
  private float mSpeedZ;

  public float Direction
  {
    get => this.mDirection;
    set
    {
      this.mDirection = value;
      this.NotifyUpdated();
    }
  }

  public float Speed
  {
    get => this.mSpeed;
    set
    {
      this.mSpeed = value;
      this.NotifyUpdated();
    }
  }

  public float SpeedZ
  {
    get => this.mSpeedZ;
    set
    {
      this.mSpeedZ = value;
      this.NotifyUpdated();
    }
  }

  public UasWind()
  {
    this.mMessageId = (byte) 168;
    this.CrcExtra = (byte) 1;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mDirection);
    s.Write(this.mSpeed);
    s.Write(this.mSpeedZ);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mDirection = s.ReadSingle();
    this.mSpeed = s.ReadSingle();
    this.mSpeedZ = s.ReadSingle();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Wind estimation"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Direction",
      Description = "wind direction that wind is coming from (degrees)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Speed",
      Description = "wind speed in ground plane (m/s)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "SpeedZ",
      Description = "vertical wind speed (m/s)",
      NumElements = 1
    });
  }
}
