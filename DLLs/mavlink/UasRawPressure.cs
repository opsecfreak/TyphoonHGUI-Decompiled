// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasRawPressure
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasRawPressure : UasMessage
{
  private ulong mTimeUsec;
  private short mPressAbs;
  private short mPressDiff1;
  private short mPressDiff2;
  private short mTemperature;

  public ulong TimeUsec
  {
    get => this.mTimeUsec;
    set
    {
      this.mTimeUsec = value;
      this.NotifyUpdated();
    }
  }

  public short PressAbs
  {
    get => this.mPressAbs;
    set
    {
      this.mPressAbs = value;
      this.NotifyUpdated();
    }
  }

  public short PressDiff1
  {
    get => this.mPressDiff1;
    set
    {
      this.mPressDiff1 = value;
      this.NotifyUpdated();
    }
  }

  public short PressDiff2
  {
    get => this.mPressDiff2;
    set
    {
      this.mPressDiff2 = value;
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

  public UasRawPressure()
  {
    this.mMessageId = (byte) 28;
    this.CrcExtra = (byte) 67;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeUsec);
    s.Write(this.mPressAbs);
    s.Write(this.mPressDiff1);
    s.Write(this.mPressDiff2);
    s.Write(this.mTemperature);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeUsec = s.ReadUInt64();
    this.mPressAbs = s.ReadInt16();
    this.mPressDiff1 = s.ReadInt16();
    this.mPressDiff2 = s.ReadInt16();
    this.mTemperature = s.ReadInt16();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "The RAW pressure readings for the typical setup of one absolute pressure and one differential pressure sensor. The sensor values should be the raw, UNSCALED ADC values."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeUsec",
      Description = "Timestamp (microseconds since UNIX epoch or microseconds since system boot)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "PressAbs",
      Description = "Absolute pressure (raw)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "PressDiff1",
      Description = "Differential pressure 1 (raw)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "PressDiff2",
      Description = "Differential pressure 2 (raw)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Temperature",
      Description = "Raw Temperature measurement (raw)",
      NumElements = 1
    });
  }
}
