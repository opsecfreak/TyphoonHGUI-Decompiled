// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasScaledPressure
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasScaledPressure : UasMessage
{
  private uint mTimeBootMs;
  private float mPressAbs;
  private float mPressDiff;
  private short mTemperature;

  public uint TimeBootMs
  {
    get => this.mTimeBootMs;
    set
    {
      this.mTimeBootMs = value;
      this.NotifyUpdated();
    }
  }

  public float PressAbs
  {
    get => this.mPressAbs;
    set
    {
      this.mPressAbs = value;
      this.NotifyUpdated();
    }
  }

  public float PressDiff
  {
    get => this.mPressDiff;
    set
    {
      this.mPressDiff = value;
      this.NotifyUpdated();
    }
  }

  public short Temperature
  {
    get => this.mTemperature;
    set
    {
      this.mTemperature = value;
      this.NotifyUpdated();
    }
  }

  public UasScaledPressure()
  {
    this.mMessageId = (byte) 29;
    this.CrcExtra = (byte) 115;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeBootMs);
    s.Write(this.mPressAbs);
    s.Write(this.mPressDiff);
    s.Write(this.mTemperature);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeBootMs = s.ReadUInt32();
    this.mPressAbs = s.ReadSingle();
    this.mPressDiff = s.ReadSingle();
    this.mTemperature = s.ReadInt16();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "ScaledPressure;ScaledPressureThe pressure readings for the typical setup of one absolute and differential pressure sensor. The units are as specified in each field."
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
      Name = "PressAbs",
      Value = this.PressAbs.ToString(),
      Description = "Absolute pressure (hectopascal)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "PressDiff",
      Value = this.PressDiff.ToString(),
      Description = "Differential pressure 1 (hectopascal)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Temperature",
      Value = this.Temperature.ToString(),
      Description = "Temperature measurement (0.01 degrees celsius)",
      NumElements = 1
    });
  }
}
