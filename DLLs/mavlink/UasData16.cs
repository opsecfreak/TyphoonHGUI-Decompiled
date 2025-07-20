// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasData16
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasData16 : UasMessage
{
  private byte mType;
  private byte mLen;
  private byte[] mData = new byte[16 /*0x10*/];

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

  public UasData16()
  {
    this.mMessageId = (byte) 169;
    this.CrcExtra = (byte) 234;
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
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Data packet, size 16"
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
      NumElements = 16 /*0x10*/
    });
  }
}
