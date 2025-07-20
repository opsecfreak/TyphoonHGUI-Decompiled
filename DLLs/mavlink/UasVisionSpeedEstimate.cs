// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasVisionSpeedEstimate
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasVisionSpeedEstimate : UasMessage
{
  private ulong mUsec;
  private float mX;
  private float mY;
  private float mZ;

  public ulong Usec
  {
    get => this.mUsec;
    set
    {
      this.mUsec = value;
      this.NotifyUpdated();
    }
  }

  public float X
  {
    get => this.mX;
    set
    {
      this.mX = value;
      this.NotifyUpdated();
    }
  }

  public float Y
  {
    get => this.mY;
    set
    {
      this.mY = value;
      this.NotifyUpdated();
    }
  }

  public float Z
  {
    get => this.mZ;
    set
    {
      this.mZ = value;
      this.NotifyUpdated();
    }
  }

  public UasVisionSpeedEstimate()
  {
    this.mMessageId = (byte) 103;
    this.CrcExtra = (byte) 208 /*0xD0*/;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mUsec);
    s.Write(this.mX);
    s.Write(this.mY);
    s.Write(this.mZ);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mUsec = s.ReadUInt64();
    this.mX = s.ReadSingle();
    this.mY = s.ReadSingle();
    this.mZ = s.ReadSingle();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = ""
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Usec",
      Description = "Timestamp (microseconds, synced to UNIX time or since system boot)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "X",
      Description = "Global X speed",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Y",
      Description = "Global Y speed",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Z",
      Description = "Global Z speed",
      NumElements = 1
    });
  }
}
