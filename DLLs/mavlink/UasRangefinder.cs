// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasRangefinder
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasRangefinder : UasMessage
{
  private float mDistance;
  private float mVoltage;

  public float Distance
  {
    get => this.mDistance;
    set
    {
      this.mDistance = value;
      this.NotifyUpdated();
    }
  }

  public float Voltage
  {
    get => this.mVoltage;
    set
    {
      this.mVoltage = value;
      this.NotifyUpdated();
    }
  }

  public UasRangefinder()
  {
    this.mMessageId = (byte) 173;
    this.CrcExtra = (byte) 83;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mDistance);
    s.Write(this.mVoltage);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mDistance = s.ReadSingle();
    this.mVoltage = s.ReadSingle();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "UasRangefinder;Rangefinder reporting"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Distance",
      Description = "distance in meters",
      Value = this.Distance.ToString(),
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Voltage",
      Description = "raw voltage if available, zero otherwise",
      Value = this.Voltage.ToString(),
      NumElements = 1
    });
  }
}
