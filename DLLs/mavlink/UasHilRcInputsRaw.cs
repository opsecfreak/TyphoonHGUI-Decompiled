// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasHilRcInputsRaw
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasHilRcInputsRaw : UasMessage
{
  private ulong mTimeUsec;
  private ushort mChan1Raw;
  private ushort mChan2Raw;
  private ushort mChan3Raw;
  private ushort mChan4Raw;
  private ushort mChan5Raw;
  private ushort mChan6Raw;
  private ushort mChan7Raw;
  private ushort mChan8Raw;
  private ushort mChan9Raw;
  private ushort mChan10Raw;
  private ushort mChan11Raw;
  private ushort mChan12Raw;
  private byte mRssi;

  public ulong TimeUsec
  {
    get => this.mTimeUsec;
    set
    {
      this.mTimeUsec = value;
      this.NotifyUpdated();
    }
  }

  public ushort Chan1Raw
  {
    get => this.mChan1Raw;
    set
    {
      this.mChan1Raw = value;
      this.NotifyUpdated();
    }
  }

  public ushort Chan2Raw
  {
    get => this.mChan2Raw;
    set
    {
      this.mChan2Raw = value;
      this.NotifyUpdated();
    }
  }

  public ushort Chan3Raw
  {
    get => this.mChan3Raw;
    set
    {
      this.mChan3Raw = value;
      this.NotifyUpdated();
    }
  }

  public ushort Chan4Raw
  {
    get => this.mChan4Raw;
    set
    {
      this.mChan4Raw = value;
      this.NotifyUpdated();
    }
  }

  public ushort Chan5Raw
  {
    get => this.mChan5Raw;
    set
    {
      this.mChan5Raw = value;
      this.NotifyUpdated();
    }
  }

  public ushort Chan6Raw
  {
    get => this.mChan6Raw;
    set
    {
      this.mChan6Raw = value;
      this.NotifyUpdated();
    }
  }

  public ushort Chan7Raw
  {
    get => this.mChan7Raw;
    set
    {
      this.mChan7Raw = value;
      this.NotifyUpdated();
    }
  }

  public ushort Chan8Raw
  {
    get => this.mChan8Raw;
    set
    {
      this.mChan8Raw = value;
      this.NotifyUpdated();
    }
  }

  public ushort Chan9Raw
  {
    get => this.mChan9Raw;
    set
    {
      this.mChan9Raw = value;
      this.NotifyUpdated();
    }
  }

  public ushort Chan10Raw
  {
    get => this.mChan10Raw;
    set
    {
      this.mChan10Raw = value;
      this.NotifyUpdated();
    }
  }

  public ushort Chan11Raw
  {
    get => this.mChan11Raw;
    set
    {
      this.mChan11Raw = value;
      this.NotifyUpdated();
    }
  }

  public ushort Chan12Raw
  {
    get => this.mChan12Raw;
    set
    {
      this.mChan12Raw = value;
      this.NotifyUpdated();
    }
  }

  public byte Rssi
  {
    get => this.mRssi;
    set
    {
      this.mRssi = value;
      this.NotifyUpdated();
    }
  }

  public UasHilRcInputsRaw()
  {
    this.mMessageId = (byte) 92;
    this.CrcExtra = (byte) 54;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeUsec);
    s.Write(this.mChan1Raw);
    s.Write(this.mChan2Raw);
    s.Write(this.mChan3Raw);
    s.Write(this.mChan4Raw);
    s.Write(this.mChan5Raw);
    s.Write(this.mChan6Raw);
    s.Write(this.mChan7Raw);
    s.Write(this.mChan8Raw);
    s.Write(this.mChan9Raw);
    s.Write(this.mChan10Raw);
    s.Write(this.mChan11Raw);
    s.Write(this.mChan12Raw);
    s.Write(this.mRssi);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeUsec = s.ReadUInt64();
    this.mChan1Raw = s.ReadUInt16();
    this.mChan2Raw = s.ReadUInt16();
    this.mChan3Raw = s.ReadUInt16();
    this.mChan4Raw = s.ReadUInt16();
    this.mChan5Raw = s.ReadUInt16();
    this.mChan6Raw = s.ReadUInt16();
    this.mChan7Raw = s.ReadUInt16();
    this.mChan8Raw = s.ReadUInt16();
    this.mChan9Raw = s.ReadUInt16();
    this.mChan10Raw = s.ReadUInt16();
    this.mChan11Raw = s.ReadUInt16();
    this.mChan12Raw = s.ReadUInt16();
    this.mRssi = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Sent from simulation to autopilot. The RAW values of the RC channels received. The standard PPM modulation is as follows: 1000 microseconds: 0%, 2000 microseconds: 100%. Individual receivers/transmitters might violate this specification."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeUsec",
      Description = "Timestamp (microseconds since UNIX epoch or microseconds since system boot)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan1Raw",
      Description = "RC channel 1 value, in microseconds",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan2Raw",
      Description = "RC channel 2 value, in microseconds",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan3Raw",
      Description = "RC channel 3 value, in microseconds",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan4Raw",
      Description = "RC channel 4 value, in microseconds",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan5Raw",
      Description = "RC channel 5 value, in microseconds",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan6Raw",
      Description = "RC channel 6 value, in microseconds",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan7Raw",
      Description = "RC channel 7 value, in microseconds",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan8Raw",
      Description = "RC channel 8 value, in microseconds",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan9Raw",
      Description = "RC channel 9 value, in microseconds",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan10Raw",
      Description = "RC channel 10 value, in microseconds",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan11Raw",
      Description = "RC channel 11 value, in microseconds",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan12Raw",
      Description = "RC channel 12 value, in microseconds",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Rssi",
      Description = "Receive signal strength indicator, 0: 0%, 255: 100%",
      NumElements = 1
    });
  }
}
