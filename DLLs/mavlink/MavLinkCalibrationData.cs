// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavLinkCalibrationData
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class MavLinkCalibrationData : UasMessage
{
  private byte mSeq;
  private byte mCount;
  private float[] mData = new float[8];

  public byte Seq
  {
    get => this.mSeq;
    set
    {
      this.mSeq = value;
      this.NotifyUpdated();
    }
  }

  public byte Count
  {
    get => this.mCount;
    set
    {
      this.mCount = value;
      this.NotifyUpdated();
    }
  }

  public float[] Data
  {
    get => this.mData;
    set
    {
      this.mData = value;
      this.NotifyUpdated();
    }
  }

  public MavLinkCalibrationData()
  {
    this.mMessageId = (byte) 7;
    this.CrcExtra = (byte) 89;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    for (int index = 0; index < this.mData.Length; ++index)
      s.Write(this.mData[index]);
    s.Write(this.mSeq);
    s.Write(this.mCount);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    for (int index = 0; index < this.mData.Length; ++index)
      this.mData[index] = s.ReadSingle();
    this.mSeq = s.ReadByte();
    this.mCount = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "MavLinkCalibrationData;Temperature Calibration Data,70 packets."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Seq",
      Description = "The sequence of the packet.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Count",
      Description = "The number of the packet.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Data",
      Description = "The datas.",
      NumElements = 8
    });
  }
}
