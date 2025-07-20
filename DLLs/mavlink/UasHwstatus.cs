// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasHwstatus
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasHwstatus : UasMessage
{
  private ushort mVcc;
  private byte mI2cerr;

  public ushort Vcc
  {
    get => this.mVcc;
    set
    {
      this.mVcc = value;
      this.NotifyUpdated();
    }
  }

  public byte I2cerr
  {
    get => this.mI2cerr;
    set
    {
      this.mI2cerr = value;
      this.NotifyUpdated();
    }
  }

  public UasHwstatus()
  {
    this.mMessageId = (byte) 165;
    this.CrcExtra = (byte) 21;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mVcc);
    s.Write(this.mI2cerr);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mVcc = s.ReadUInt16();
    this.mI2cerr = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Hwstatus;Status of key hardware"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Vcc",
      Value = this.Vcc.ToString(),
      Description = "board voltage (mV)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "I2cerr",
      Value = this.I2cerr.ToString(),
      Description = "I2C error count",
      NumElements = 1
    });
  }
}
