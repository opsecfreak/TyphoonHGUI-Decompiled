// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasStatustext
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasStatustext : UasMessage
{
  private MavSeverity mSeverity;
  private char[] mText = new char[50];

  public MavSeverity Severity
  {
    get => this.mSeverity;
    set
    {
      this.mSeverity = value;
      this.NotifyUpdated();
    }
  }

  public char[] Text
  {
    get => this.mText;
    set
    {
      this.mText = value;
      this.NotifyUpdated();
    }
  }

  public UasStatustext()
  {
    this.mMessageId = (byte) 253;
    this.CrcExtra = (byte) 83;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write((byte) this.mSeverity);
    s.Write(this.mText[0]);
    s.Write(this.mText[1]);
    s.Write(this.mText[2]);
    s.Write(this.mText[3]);
    s.Write(this.mText[4]);
    s.Write(this.mText[5]);
    s.Write(this.mText[6]);
    s.Write(this.mText[7]);
    s.Write(this.mText[8]);
    s.Write(this.mText[9]);
    s.Write(this.mText[10]);
    s.Write(this.mText[11]);
    s.Write(this.mText[12]);
    s.Write(this.mText[13]);
    s.Write(this.mText[14]);
    s.Write(this.mText[15]);
    s.Write(this.mText[16 /*0x10*/]);
    s.Write(this.mText[17]);
    s.Write(this.mText[18]);
    s.Write(this.mText[19]);
    s.Write(this.mText[20]);
    s.Write(this.mText[21]);
    s.Write(this.mText[22]);
    s.Write(this.mText[23]);
    s.Write(this.mText[24]);
    s.Write(this.mText[25]);
    s.Write(this.mText[26]);
    s.Write(this.mText[27]);
    s.Write(this.mText[28]);
    s.Write(this.mText[29]);
    s.Write(this.mText[30]);
    s.Write(this.mText[31 /*0x1F*/]);
    s.Write(this.mText[32 /*0x20*/]);
    s.Write(this.mText[33]);
    s.Write(this.mText[34]);
    s.Write(this.mText[35]);
    s.Write(this.mText[36]);
    s.Write(this.mText[37]);
    s.Write(this.mText[38]);
    s.Write(this.mText[39]);
    s.Write(this.mText[40]);
    s.Write(this.mText[41]);
    s.Write(this.mText[42]);
    s.Write(this.mText[43]);
    s.Write(this.mText[44]);
    s.Write(this.mText[45]);
    s.Write(this.mText[46]);
    s.Write(this.mText[47]);
    s.Write(this.mText[48 /*0x30*/]);
    s.Write(this.mText[49]);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mSeverity = (MavSeverity) s.ReadByte();
    this.mText[0] = s.ReadChar();
    this.mText[1] = s.ReadChar();
    this.mText[2] = s.ReadChar();
    this.mText[3] = s.ReadChar();
    this.mText[4] = s.ReadChar();
    this.mText[5] = s.ReadChar();
    this.mText[6] = s.ReadChar();
    this.mText[7] = s.ReadChar();
    this.mText[8] = s.ReadChar();
    this.mText[9] = s.ReadChar();
    this.mText[10] = s.ReadChar();
    this.mText[11] = s.ReadChar();
    this.mText[12] = s.ReadChar();
    this.mText[13] = s.ReadChar();
    this.mText[14] = s.ReadChar();
    this.mText[15] = s.ReadChar();
    this.mText[16 /*0x10*/] = s.ReadChar();
    this.mText[17] = s.ReadChar();
    this.mText[18] = s.ReadChar();
    this.mText[19] = s.ReadChar();
    this.mText[20] = s.ReadChar();
    this.mText[21] = s.ReadChar();
    this.mText[22] = s.ReadChar();
    this.mText[23] = s.ReadChar();
    this.mText[24] = s.ReadChar();
    this.mText[25] = s.ReadChar();
    this.mText[26] = s.ReadChar();
    this.mText[27] = s.ReadChar();
    this.mText[28] = s.ReadChar();
    this.mText[29] = s.ReadChar();
    this.mText[30] = s.ReadChar();
    this.mText[31 /*0x1F*/] = s.ReadChar();
    this.mText[32 /*0x20*/] = s.ReadChar();
    this.mText[33] = s.ReadChar();
    this.mText[34] = s.ReadChar();
    this.mText[35] = s.ReadChar();
    this.mText[36] = s.ReadChar();
    this.mText[37] = s.ReadChar();
    this.mText[38] = s.ReadChar();
    this.mText[39] = s.ReadChar();
    this.mText[40] = s.ReadChar();
    this.mText[41] = s.ReadChar();
    this.mText[42] = s.ReadChar();
    this.mText[43] = s.ReadChar();
    this.mText[44] = s.ReadChar();
    this.mText[45] = s.ReadChar();
    this.mText[46] = s.ReadChar();
    this.mText[47] = s.ReadChar();
    this.mText[48 /*0x30*/] = s.ReadChar();
    this.mText[49] = s.ReadChar();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Statustext;Status text message. These messages are printed in yellow in the COMM console of QGroundControl. WARNING: They consume quite some bandwidth, so use only for important status and error messages. If implemented wisely, these messages are buffered on the MCU and sent only at a limited rate (e.g. 10 Hz)."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Severity",
      Value = this.Severity.ToString(),
      Description = "Severity of status. Relies on the definitions within RFC-5424. See enum MAV_SEVERITY.",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("MavSeverity")
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Text",
      Value = new string(this.Text),
      Description = "Status text message, without null termination character",
      NumElements = 50
    });
  }
}
