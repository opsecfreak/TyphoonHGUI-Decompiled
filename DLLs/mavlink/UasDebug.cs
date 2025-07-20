// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasDebug
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasDebug : UasMessage
{
  private uint mTimeBootMs;
  private byte mInd;
  private float mValue;

  public uint TimeBootMs
  {
    get => this.mTimeBootMs;
    set
    {
      this.mTimeBootMs = value;
      this.NotifyUpdated();
    }
  }

  public byte Ind
  {
    get => this.mInd;
    set
    {
      this.mInd = value;
      this.NotifyUpdated();
    }
  }

  public float Value
  {
    get => this.mValue;
    set
    {
      this.mValue = value;
      this.NotifyUpdated();
    }
  }

  public UasDebug()
  {
    this.mMessageId = (byte) 254;
    this.CrcExtra = (byte) 86;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeBootMs);
    s.Write(this.mInd);
    s.Write(this.mValue);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeBootMs = s.ReadUInt32();
    this.mInd = s.ReadByte();
    this.mValue = s.ReadSingle();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Send a debug value. The index is used to discriminate between values. These values show up in the plot of QGroundControl as DEBUG N."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeBootMs",
      Description = "Timestamp (milliseconds since system boot)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Ind",
      Description = "index of debug variable",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Value",
      Description = "DEBUG value",
      NumElements = 1
    });
  }
}
