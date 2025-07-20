// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasRcChannelsOverride
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasRcChannelsOverride : UasMessage
{
  private ushort mChan1Raw;
  private ushort mChan2Raw;
  private ushort mChan3Raw;
  private ushort mChan4Raw;
  private ushort mChan5Raw;
  private ushort mChan6Raw;
  private ushort mChan7Raw;
  private ushort mChan8Raw;
  private byte mTargetSystem;
  private byte mTargetComponent;

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

  public byte TargetSystem
  {
    get => this.mTargetSystem;
    set
    {
      this.mTargetSystem = value;
      this.NotifyUpdated();
    }
  }

  public byte TargetComponent
  {
    get => this.mTargetComponent;
    set
    {
      this.mTargetComponent = value;
      this.NotifyUpdated();
    }
  }

  public UasRcChannelsOverride()
  {
    this.mMessageId = (byte) 70;
    this.CrcExtra = (byte) 124;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mChan1Raw);
    s.Write(this.mChan2Raw);
    s.Write(this.mChan3Raw);
    s.Write(this.mChan4Raw);
    s.Write(this.mChan5Raw);
    s.Write(this.mChan6Raw);
    s.Write(this.mChan7Raw);
    s.Write(this.mChan8Raw);
    s.Write(this.mTargetSystem);
    s.Write(this.mTargetComponent);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mChan1Raw = s.ReadUInt16();
    this.mChan2Raw = s.ReadUInt16();
    this.mChan3Raw = s.ReadUInt16();
    this.mChan4Raw = s.ReadUInt16();
    this.mChan5Raw = s.ReadUInt16();
    this.mChan6Raw = s.ReadUInt16();
    this.mChan7Raw = s.ReadUInt16();
    this.mChan8Raw = s.ReadUInt16();
    this.mTargetSystem = s.ReadByte();
    this.mTargetComponent = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "The RAW values of the RC channels sent to the MAV to override info received from the RC radio. A value of UINT16_MAX means no change to that channel. A value of 0 means control of that channel should be released back to the RC radio. The standard PPM modulation is as follows: 1000 microseconds: 0%, 2000 microseconds: 100%. Individual receivers/transmitters might violate this specification."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan1Raw",
      Description = "RC channel 1 value, in microseconds. A value of UINT16_MAX means to ignore this field.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan2Raw",
      Description = "RC channel 2 value, in microseconds. A value of UINT16_MAX means to ignore this field.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan3Raw",
      Description = "RC channel 3 value, in microseconds. A value of UINT16_MAX means to ignore this field.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan4Raw",
      Description = "RC channel 4 value, in microseconds. A value of UINT16_MAX means to ignore this field.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan5Raw",
      Description = "RC channel 5 value, in microseconds. A value of UINT16_MAX means to ignore this field.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan6Raw",
      Description = "RC channel 6 value, in microseconds. A value of UINT16_MAX means to ignore this field.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan7Raw",
      Description = "RC channel 7 value, in microseconds. A value of UINT16_MAX means to ignore this field.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan8Raw",
      Description = "RC channel 8 value, in microseconds. A value of UINT16_MAX means to ignore this field.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TargetSystem",
      Description = "System ID",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TargetComponent",
      Description = "Component ID",
      NumElements = 1
    });
  }
}
