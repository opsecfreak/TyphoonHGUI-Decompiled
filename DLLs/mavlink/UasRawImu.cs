// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasRawImu
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasRawImu : UasMessage
{
  private ulong mTimeUsec;
  private short mXacc;
  private short mYacc;
  private short mZacc;
  private short mXgyro;
  private short mYgyro;
  private short mZgyro;
  private short mXmag;
  private short mYmag;
  private short mZmag;

  public ulong TimeUsec
  {
    get => this.mTimeUsec;
    set
    {
      this.mTimeUsec = value;
      this.NotifyUpdated();
    }
  }

  public short Xacc
  {
    get => this.mXacc;
    set
    {
      this.mXacc = value;
      this.NotifyUpdated();
    }
  }

  public short Yacc
  {
    get => this.mYacc;
    set
    {
      this.mYacc = value;
      this.NotifyUpdated();
    }
  }

  public short Zacc
  {
    get => this.mZacc;
    set
    {
      this.mZacc = value;
      this.NotifyUpdated();
    }
  }

  public short Xgyro
  {
    get => this.mXgyro;
    set
    {
      this.mXgyro = value;
      this.NotifyUpdated();
    }
  }

  public short Ygyro
  {
    get => this.mYgyro;
    set
    {
      this.mYgyro = value;
      this.NotifyUpdated();
    }
  }

  public short Zgyro
  {
    get => this.mZgyro;
    set
    {
      this.mZgyro = value;
      this.NotifyUpdated();
    }
  }

  public short Xmag
  {
    get => this.mXmag;
    set
    {
      this.mXmag = value;
      this.NotifyUpdated();
    }
  }

  public short Ymag
  {
    get => this.mYmag;
    set
    {
      this.mYmag = value;
      this.NotifyUpdated();
    }
  }

  public short Zmag
  {
    get => this.mZmag;
    set
    {
      this.mZmag = value;
      this.NotifyUpdated();
    }
  }

  public UasRawImu()
  {
    this.mMessageId = (byte) 27;
    this.CrcExtra = (byte) 144 /*0x90*/;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeUsec);
    s.Write(this.mXacc);
    s.Write(this.mYacc);
    s.Write(this.mZacc);
    s.Write(this.mXgyro);
    s.Write(this.mYgyro);
    s.Write(this.mZgyro);
    s.Write(this.mXmag);
    s.Write(this.mYmag);
    s.Write(this.mZmag);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeUsec = s.ReadUInt64();
    this.mXacc = s.ReadInt16();
    this.mYacc = s.ReadInt16();
    this.mZacc = s.ReadInt16();
    this.mXgyro = s.ReadInt16();
    this.mYgyro = s.ReadInt16();
    this.mZgyro = s.ReadInt16();
    this.mXmag = s.ReadInt16();
    this.mYmag = s.ReadInt16();
    this.mZmag = s.ReadInt16();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "RawImu;The RAW IMU readings for the usual 9DOF sensor setup. This message should always contain the true raw values without any scaling to allow data capture and system debugging."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeUsec",
      Value = this.TimeUsec.ToString(),
      Description = "Timestamp (microseconds since UNIX epoch or microseconds since system boot)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Xacc",
      Value = this.Xacc.ToString(),
      Description = "X acceleration (raw)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Yacc",
      Value = this.Yacc.ToString(),
      Description = "Y acceleration (raw)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Zacc",
      Value = this.Zacc.ToString(),
      Description = "Z acceleration (raw)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Xgyro",
      Value = this.Xgyro.ToString(),
      Description = "Angular speed around X axis (raw)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Ygyro",
      Value = this.Ygyro.ToString(),
      Description = "Angular speed around Y axis (raw)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Zgyro",
      Value = this.Zgyro.ToString(),
      Description = "Angular speed around Z axis (raw)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Xmag",
      Value = this.Xmag.ToString(),
      Description = "X Magnetic field (raw)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Ymag",
      Value = this.Ymag.ToString(),
      Description = "Y Magnetic field (raw)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Zmag",
      Value = this.Zmag.ToString(),
      Description = "Z Magnetic field (raw)",
      NumElements = 1
    });
  }
}
