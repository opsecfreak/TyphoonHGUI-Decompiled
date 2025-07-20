// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasData96
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System;
using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasData96 : UasMessage
{
  private MavParamType mType;
  private byte mLen;
  private byte[] mData = new byte[96 /*0x60*/];
  private float[] _fData = new float[24];

  public MavParamType Type
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

  public UasData96()
  {
    this.mMessageId = (byte) 172;
    this.CrcExtra = (byte) 22;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write((byte) this.mType);
    if (this.mType == MavParamType.Float)
    {
      s.Write((byte) ((uint) this.mLen * 4U));
      for (int index = 0; index < (int) this.mLen; ++index)
        s.Write(this._fData[index]);
    }
    else
    {
      this.mLen = (byte) 96 /*0x60*/;
      s.Write(this.mLen);
      for (int index = 0; index < (int) this.mLen; ++index)
        s.Write(this.mData[index]);
    }
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mType = (MavParamType) s.ReadByte();
    this.mLen = s.ReadByte();
    if (this.mType == MavParamType.Float)
    {
      this.mLen /= (byte) 4;
      for (int index = 0; index < (int) this.mLen; ++index)
        this._fData[index] = s.ReadSingle();
    }
    else
    {
      for (int index = 0; index < (int) this.mLen; ++index)
        this.Data[index] = s.ReadByte();
    }
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "UasData96;Data packet, size 96"
    };
    for (int index = 0; index < (int) this.mLen; ++index)
    {
      UasFieldMetadata uasFieldMetadata1 = new UasFieldMetadata();
      // ISSUE: variable of a boxed type
      __Boxed<MavParamType> mType = (Enum) this.mType;
      int num = index + 1;
      string str = num.ToString();
      uasFieldMetadata1.Name = mType.ToString() + str;
      num = index + 1;
      uasFieldMetadata1.Description = "raw data" + num.ToString();
      uasFieldMetadata1.Value = this.mData[index].ToString();
      uasFieldMetadata1.NumElements = 1;
      UasFieldMetadata uasFieldMetadata2 = uasFieldMetadata1;
      uasFieldMetadata2.Value = this.mType != MavParamType.Float ? this.mData[index].ToString() : this._fData[index].ToString();
      this.mMetadata.Fields.Add(uasFieldMetadata2);
    }
  }
}
