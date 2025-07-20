// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasRcChannelsRaw
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasRcChannelsRaw : UasMessage
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

  public UasRcChannelsRaw()
  {
    this.mMessageId = (byte) 35;
    this.CrcExtra = (byte) 244;
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
    this.mPort = s.ReadByte();
    this.mRssi = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "RcChannelsRaw;The RAW values of the RC channels received. The standard PPM modulation is as follows: 1000 microseconds: 0%, 2000 microseconds: 100%. Individual receivers/transmitters might violate this specification."
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
