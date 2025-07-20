// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasDebugVect
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasDebugVect : UasMessage
{
  private ulong mTimeUsec;
  private float mX;
  private float mY;
  private float mZ;
  private char[] mName = new char[10];

  public ulong TimeUsec
  {
    get => this.mTimeUsec;
    set
    {
      this.mTimeUsec = value;
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

  public char[] Name
  {
    get => this.mName;
    set
    {
      this.mName = value;
      this.NotifyUpdated();
    }
  }

  public UasDebugVect()
  {
    this.mMessageId = (byte) 250;
    this.CrcExtra = (byte) 49;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeUsec);
    s.Write(this.mX);
    s.Write(this.mY);
    s.Write(this.mZ);
    s.Write(this.mName[0]);
    s.Write(this.mName[1]);
    s.Write(this.mName[2]);
    s.Write(this.mName[3]);
    s.Write(this.mName[4]);
    s.Write(this.mName[5]);
    s.Write(this.mName[6]);
    s.Write(this.mName[7]);
    s.Write(this.mName[8]);
    s.Write(this.mName[9]);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeUsec = s.ReadUInt64();
    this.mX = s.ReadSingle();
    this.mY = s.ReadSingle();
    this.mZ = s.ReadSingle();
    this.mName[0] = s.ReadChar();
    this.mName[1] = s.ReadChar();
    this.mName[2] = s.ReadChar();
    this.mName[3] = s.ReadChar();
    this.mName[4] = s.ReadChar();
    this.mName[5] = s.ReadChar();
    this.mName[6] = s.ReadChar();
    this.mName[7] = s.ReadChar();
    this.mName[8] = s.ReadChar();
    this.mName[9] = s.ReadChar();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = ""
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeUsec",
      Description = "Timestamp",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "X",
      Description = "x",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Y",
      Description = "y",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Z",
      Description = "z",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Name",
      Description = "Name",
      NumElements = 10
    });
  }
}
