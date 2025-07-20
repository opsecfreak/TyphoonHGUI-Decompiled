// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasData32
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasData32 : UasMessage
{
  private byte mType;
  private byte mLen;
  private byte[] mData = new byte[32 /*0x20*/];

  public byte Type
  {
    get => this.mType;
    set
    {
      this.mType = value;
      this.NotifyUpdated();
    }
  }

  public byte Len
  {
    get => this.mLen;
    set
    {
      this.mLen = value;
      this.NotifyUpdated();
    }
  }

  public byte[] Data
  {
    get => this.mData;
    set
    {
      this.mData = value;
      this.NotifyUpdated();
    }
  }

  public UasData32()
  {
    this.mMessageId = (byte) 170;
    this.CrcExtra = (byte) 73;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mType);
    s.Write(this.mLen);
    s.Write(this.mData[0]);
    s.Write(this.mData[1]);
    s.Write(this.mData[2]);
    s.Write(this.mData[3]);
    s.Write(this.mData[4]);
    s.Write(this.mData[5]);
    s.Write(this.mData[6]);
    s.Write(this.mData[7]);
    s.Write(this.mData[8]);
    s.Write(this.mData[9]);
    s.Write(this.mData[10]);
    s.Write(this.mData[11]);
    s.Write(this.mData[12]);
    s.Write(this.mData[13]);
    s.Write(this.mData[14]);
    s.Write(this.mData[15]);
    s.Write(this.mData[16 /*0x10*/]);
    s.Write(this.mData[17]);
    s.Write(this.mData[18]);
    s.Write(this.mData[19]);
    s.Write(this.mData[20]);
    s.Write(this.mData[21]);
    s.Write(this.mData[22]);
    s.Write(this.mData[23]);
    s.Write(this.mData[24]);
    s.Write(this.mData[25]);
    s.Write(this.mData[26]);
    s.Write(this.mData[27]);
    s.Write(this.mData[28]);
    s.Write(this.mData[29]);
    s.Write(this.mData[30]);
    s.Write(this.mData[31 /*0x1F*/]);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mType = s.ReadByte();
    this.mLen = s.ReadByte();
    this.mData[0] = s.ReadByte();
    this.mData[1] = s.ReadByte();
    this.mData[2] = s.ReadByte();
    this.mData[3] = s.ReadByte();
    this.mData[4] = s.ReadByte();
    this.mData[5] = s.ReadByte();
    this.mData[6] = s.ReadByte();
    this.mData[7] = s.ReadByte();
    this.mData[8] = s.ReadByte();
    this.mData[9] = s.ReadByte();
    this.mData[10] = s.ReadByte();
    this.mData[11] = s.ReadByte();
    this.mData[12] = s.ReadByte();
    this.mData[13] = s.ReadByte();
    this.mData[14] = s.ReadByte();
    this.mData[15] = s.ReadByte();
    this.mData[16 /*0x10*/] = s.ReadByte();
    this.mData[17] = s.ReadByte();
    this.mData[18] = s.ReadByte();
    this.mData[19] = s.ReadByte();
    this.mData[20] = s.ReadByte();
    this.mData[21] = s.ReadByte();
    this.mData[22] = s.ReadByte();
    this.mData[23] = s.ReadByte();
    this.mData[24] = s.ReadByte();
    this.mData[25] = s.ReadByte();
    this.mData[26] = s.ReadByte();
    this.mData[27] = s.ReadByte();
    this.mData[28] = s.ReadByte();
    this.mData[29] = s.ReadByte();
    this.mData[30] = s.ReadByte();
    this.mData[31 /*0x1F*/] = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Data packet, size 32"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Type",
      Description = "data type",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Len",
      Description = "data length",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Data",
      Description = "raw data",
      NumElements = 32 /*0x20*/
    });
  }
}
