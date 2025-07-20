// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasScaledImu
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasScaledImu : UasMessage
{
  private uint mTimeBootMs;
  private short mXacc;
  private short mYacc;
  private short mZacc;
  private short mXgyro;
  private short mYgyro;
  private short mZgyro;
  private short mXmag;
  private short mYmag;
  private short mZmag;

  public uint TimeBootMs
  {
    get => this.mTimeBootMs;
    set
    {
      this.mTimeBootMs = value;
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

  public UasScaledImu()
  {
    this.mMessageId = (byte) 26;
    this.CrcExtra = (byte) 170;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeBootMs);
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
    this.mTimeBootMs = s.ReadUInt32();
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
      Description = "The RAW IMU readings for the usual 9DOF sensor setup. This message should contain the scaled values to the described units"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeBootMs",
      Description = "Timestamp (milliseconds since system boot)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Xacc",
      Description = "X acceleration (mg)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Yacc",
      Description = "Y acceleration (mg)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Zacc",
      Description = "Z acceleration (mg)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Xgyro",
      Description = "Angular speed around X axis (millirad /sec)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Ygyro",
      Description = "Angular speed around Y axis (millirad /sec)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Zgyro",
      Description = "Angular speed around Z axis (millirad /sec)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Xmag",
      Description = "X Magnetic field (milli tesla)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Ymag",
      Description = "Y Magnetic field (milli tesla)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Zmag",
      Description = "Z Magnetic field (milli tesla)",
      NumElements = 1
    });
  }
}
