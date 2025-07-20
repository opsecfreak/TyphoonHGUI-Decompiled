// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasApAdc
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasApAdc : UasMessage
{
  private ushort mAdc1;
  private ushort mAdc2;
  private ushort mAdc3;
  private ushort mAdc4;
  private ushort mAdc5;
  private ushort mAdc6;

  public ushort Adc1
  {
    get => this.mAdc1;
    set
    {
      this.mAdc1 = value;
      this.NotifyUpdated();
    }
  }

  public ushort Adc2
  {
    get => this.mAdc2;
    set
    {
      this.mAdc2 = value;
      this.NotifyUpdated();
    }
  }

  public ushort Adc3
  {
    get => this.mAdc3;
    set
    {
      this.mAdc3 = value;
      this.NotifyUpdated();
    }
  }

  public ushort Adc4
  {
    get => this.mAdc4;
    set
    {
      this.mAdc4 = value;
      this.NotifyUpdated();
    }
  }

  public ushort Adc5
  {
    get => this.mAdc5;
    set
    {
      this.mAdc5 = value;
      this.NotifyUpdated();
    }
  }

  public ushort Adc6
  {
    get => this.mAdc6;
    set
    {
      this.mAdc6 = value;
      this.NotifyUpdated();
    }
  }

  public UasApAdc()
  {
    this.mMessageId = (byte) 153;
    this.CrcExtra = (byte) 188;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mAdc1);
    s.Write(this.mAdc2);
    s.Write(this.mAdc3);
    s.Write(this.mAdc4);
    s.Write(this.mAdc5);
    s.Write(this.mAdc6);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mAdc1 = s.ReadUInt16();
    this.mAdc2 = s.ReadUInt16();
    this.mAdc3 = s.ReadUInt16();
    this.mAdc4 = s.ReadUInt16();
    this.mAdc5 = s.ReadUInt16();
    this.mAdc6 = s.ReadUInt16();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "raw ADC output"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Adc1",
      Description = "ADC output 1",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Adc2",
      Description = "ADC output 2",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Adc3",
      Description = "ADC output 3",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Adc4",
      Description = "ADC output 4",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Adc5",
      Description = "ADC output 5",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Adc6",
      Description = "ADC output 6",
      NumElements = 1
    });
  }
}
