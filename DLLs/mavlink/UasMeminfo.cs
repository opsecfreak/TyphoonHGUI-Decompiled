// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasMeminfo
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasMeminfo : UasMessage
{
  private ushort mBrkval;
  private ushort mFreemem;

  public ushort Brkval
  {
    get => this.mBrkval;
    set
    {
      this.mBrkval = value;
      this.NotifyUpdated();
    }
  }

  public ushort Freemem
  {
    get => this.mFreemem;
    set
    {
      this.mFreemem = value;
      this.NotifyUpdated();
    }
  }

  public UasMeminfo()
  {
    this.mMessageId = (byte) 152;
    this.CrcExtra = (byte) 208 /*0xD0*/;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mBrkval);
    s.Write(this.mFreemem);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mBrkval = s.ReadUInt16();
    this.mFreemem = s.ReadUInt16();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Meminfo;state of APM memory"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Brkval",
      Value = this.Brkval.ToString(),
      Description = "heap top",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Freemem",
      Value = this.Freemem.ToString(),
      Description = "free memory",
      NumElements = 1
    });
  }
}
