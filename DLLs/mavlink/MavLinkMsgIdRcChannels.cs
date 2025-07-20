// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavLinkMsgIdRcChannels
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class MavLinkMsgIdRcChannels : UasMessage
{
  private uint mTimeBootMs;
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
  private ushort mChan13Raw;
  private ushort mChan14Raw;
  private ushort mChan15Raw;
  private ushort mChan16Raw;
  private ushort mChan17Raw;
  private ushort mChan18Raw;
  private byte mPort;
  private byte mRssi;

  public uint TimeBootMs
  {
    get => this.mTimeBootMs;
    set
    {
      this.mTimeBootMs = value;
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

  public ushort Chan13Raw
  {
    get => this.mChan13Raw;
    set
    {
      this.mChan13Raw = value;
      this.NotifyUpdated();
    }
  }

  public ushort Chan14Raw
  {
    get => this.mChan14Raw;
    set
    {
      this.mChan14Raw = value;
      this.NotifyUpdated();
    }
  }

  public ushort Chan15Raw
  {
    get => this.mChan15Raw;
    set
    {
      this.mChan15Raw = value;
      this.NotifyUpdated();
    }
  }

  public ushort Chan16Raw
  {
    get => this.mChan16Raw;
    set
    {
      this.mChan16Raw = value;
      this.NotifyUpdated();
    }
  }

  public ushort Chan17Raw
  {
    get => this.mChan15Raw;
    set
    {
      this.mChan17Raw = value;
      this.NotifyUpdated();
    }
  }

  public ushort Chan18Raw
  {
    get => this.mChan18Raw;
    set
    {
      this.mChan18Raw = value;
      this.NotifyUpdated();
    }
  }

  public byte Port
  {
    get => this.mPort;
    set
    {
      this.mPort = value;
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

  public MavLinkMsgIdRcChannels()
  {
    this.mMessageId = (byte) 65;
    this.CrcExtra = (byte) 118;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeBootMs);
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
    s.Write(this.mChan13Raw);
    s.Write(this.mChan14Raw);
    s.Write(this.mChan15Raw);
    s.Write(this.mChan16Raw);
    s.Write(this.mChan17Raw);
    s.Write(this.mChan18Raw);
    s.Write(this.mPort);
    s.Write(this.mRssi);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeBootMs = s.ReadUInt32();
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
    this.mChan13Raw = s.ReadUInt16();
    this.mChan14Raw = s.ReadUInt16();
    this.mChan15Raw = s.ReadUInt16();
    this.mChan16Raw = s.ReadUInt16();
    this.mChan17Raw = s.ReadUInt16();
    this.mChan18Raw = s.ReadUInt16();
    this.mPort = s.ReadByte();
    this.mRssi = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "MavLinkMsgIdRcChannels;The RAW values of the RC channels received. 18 Channels "
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeBootMs",
      Value = this.TimeBootMs.ToString(),
      Description = "Timestamp (milliseconds since system boot)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan1Raw",
      Value = this.Chan1Raw.ToString(),
      Description = "RC channel 1 value, in microseconds. A value of UINT16_MAX implies the channel is unused.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan2Raw",
      Value = this.Chan2Raw.ToString(),
      Description = "RC channel 2 value, in microseconds. A value of UINT16_MAX implies the channel is unused.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan3Raw",
      Value = this.Chan3Raw.ToString(),
      Description = "RC channel 3 value, in microseconds. A value of UINT16_MAX implies the channel is unused.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan4Raw",
      Value = this.Chan4Raw.ToString(),
      Description = "RC channel 4 value, in microseconds. A value of UINT16_MAX implies the channel is unused.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan5Raw",
      Value = this.Chan5Raw.ToString(),
      Description = "RC channel 5 value, in microseconds. A value of UINT16_MAX implies the channel is unused.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan6Raw",
      Value = this.Chan6Raw.ToString(),
      Description = "RC channel 6 value, in microseconds. A value of UINT16_MAX implies the channel is unused.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan7Raw",
      Value = this.Chan7Raw.ToString(),
      Description = "RC channel 7 value, in microseconds. A value of UINT16_MAX implies the channel is unused.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan8Raw",
      Value = this.Chan8Raw.ToString(),
      Description = "RC channel 8 value, in microseconds. A value of UINT16_MAX implies the channel is unused.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan9Raw",
      Value = this.Chan9Raw.ToString(),
      Description = "RC channel 9 value, in microseconds. A value of UINT16_MAX implies the channel is unused.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan10Raw",
      Value = this.Chan10Raw.ToString(),
      Description = "RC channel 10 value, in microseconds. A value of UINT16_MAX implies the channel is unused.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan11Raw",
      Value = this.Chan11Raw.ToString(),
      Description = "RC channel 11 value, in microseconds. A value of UINT16_MAX implies the channel is unused.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan12Raw",
      Value = this.Chan12Raw.ToString(),
      Description = "RC channel 12 value, in microseconds. A value of UINT16_MAX implies the channel is unused.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan13Raw",
      Value = this.Chan13Raw.ToString(),
      Description = "RC channel 13 value, in microseconds. A value of UINT16_MAX implies the channel is unused.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan14Raw",
      Value = this.Chan14Raw.ToString(),
      Description = "RC channel 14 value, in microseconds. A value of UINT16_MAX implies the channel is unused.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan15Raw",
      Value = this.Chan15Raw.ToString(),
      Description = "RC channel 15 value, in microseconds. A value of UINT16_MAX implies the channel is unused.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan16Raw",
      Value = this.Chan16Raw.ToString(),
      Description = "RC channel 16 value, in microseconds. A value of UINT16_MAX implies the channel is unused.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan17Raw",
      Value = this.Chan17Raw.ToString(),
      Description = "RC channel 17 value, in microseconds. A value of UINT16_MAX implies the channel is unused.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan18Raw",
      Value = this.Chan18Raw.ToString(),
      Description = "RC channel 18 value, in microseconds. A value of UINT16_MAX implies the channel is unused.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Port",
      Value = this.Port.ToString(),
      Description = "Servo output port (set of 8 outputs = 1 port). Most MAVs will just use one, but this allows for more than 8 servos.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Rssi",
      Value = this.Rssi.ToString(),
      Description = "Receive signal strength indicator, 0: 0%, 100: 100%, 255: invalid/unknown.",
      NumElements = 1
    });
  }
}
