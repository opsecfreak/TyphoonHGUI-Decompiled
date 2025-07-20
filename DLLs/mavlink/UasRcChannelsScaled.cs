// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasRcChannelsScaled
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasRcChannelsScaled : UasMessage
{
  private uint mTimeBootMs;
  private short mChan1Scaled;
  private short mChan2Scaled;
  private short mChan3Scaled;
  private short mChan4Scaled;
  private short mChan5Scaled;
  private short mChan6Scaled;
  private short mChan7Scaled;
  private short mChan8Scaled;
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

  public short Chan1Scaled
  {
    get => this.mChan1Scaled;
    set
    {
      this.mChan1Scaled = value;
      this.NotifyUpdated();
    }
  }

  public short Chan2Scaled
  {
    get => this.mChan2Scaled;
    set
    {
      this.mChan2Scaled = value;
      this.NotifyUpdated();
    }
  }

  public short Chan3Scaled
  {
    get => this.mChan3Scaled;
    set
    {
      this.mChan3Scaled = value;
      this.NotifyUpdated();
    }
  }

  public short Chan4Scaled
  {
    get => this.mChan4Scaled;
    set
    {
      this.mChan4Scaled = value;
      this.NotifyUpdated();
    }
  }

  public short Chan5Scaled
  {
    get => this.mChan5Scaled;
    set
    {
      this.mChan5Scaled = value;
      this.NotifyUpdated();
    }
  }

  public short Chan6Scaled
  {
    get => this.mChan6Scaled;
    set
    {
      this.mChan6Scaled = value;
      this.NotifyUpdated();
    }
  }

  public short Chan7Scaled
  {
    get => this.mChan7Scaled;
    set
    {
      this.mChan7Scaled = value;
      this.NotifyUpdated();
    }
  }

  public short Chan8Scaled
  {
    get => this.mChan8Scaled;
    set
    {
      this.mChan8Scaled = value;
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

  public UasRcChannelsScaled()
  {
    this.mMessageId = (byte) 34;
    this.CrcExtra = (byte) 237;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeBootMs);
    s.Write(this.mChan1Scaled);
    s.Write(this.mChan2Scaled);
    s.Write(this.mChan3Scaled);
    s.Write(this.mChan4Scaled);
    s.Write(this.mChan5Scaled);
    s.Write(this.mChan6Scaled);
    s.Write(this.mChan7Scaled);
    s.Write(this.mChan8Scaled);
    s.Write(this.mPort);
    s.Write(this.mRssi);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeBootMs = s.ReadUInt32();
    this.mChan1Scaled = s.ReadInt16();
    this.mChan2Scaled = s.ReadInt16();
    this.mChan3Scaled = s.ReadInt16();
    this.mChan4Scaled = s.ReadInt16();
    this.mChan5Scaled = s.ReadInt16();
    this.mChan6Scaled = s.ReadInt16();
    this.mChan7Scaled = s.ReadInt16();
    this.mChan8Scaled = s.ReadInt16();
    this.mPort = s.ReadByte();
    this.mRssi = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "The scaled values of the RC channels received. (-100%) -10000, (0%) 0, (100%) 10000. Channels that are inactive should be set to UINT16_MAX."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeBootMs",
      Description = "Timestamp (milliseconds since system boot)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan1Scaled",
      Description = "RC channel 1 value scaled, (-100%) -10000, (0%) 0, (100%) 10000, (invalid) INT16_MAX.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan2Scaled",
      Description = "RC channel 2 value scaled, (-100%) -10000, (0%) 0, (100%) 10000, (invalid) INT16_MAX.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan3Scaled",
      Description = "RC channel 3 value scaled, (-100%) -10000, (0%) 0, (100%) 10000, (invalid) INT16_MAX.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan4Scaled",
      Description = "RC channel 4 value scaled, (-100%) -10000, (0%) 0, (100%) 10000, (invalid) INT16_MAX.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan5Scaled",
      Description = "RC channel 5 value scaled, (-100%) -10000, (0%) 0, (100%) 10000, (invalid) INT16_MAX.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan6Scaled",
      Description = "RC channel 6 value scaled, (-100%) -10000, (0%) 0, (100%) 10000, (invalid) INT16_MAX.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan7Scaled",
      Description = "RC channel 7 value scaled, (-100%) -10000, (0%) 0, (100%) 10000, (invalid) INT16_MAX.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Chan8Scaled",
      Description = "RC channel 8 value scaled, (-100%) -10000, (0%) 0, (100%) 10000, (invalid) INT16_MAX.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Port",
      Description = "Servo output port (set of 8 outputs = 1 port). Most MAVs will just use one, but this allows for more than 8 servos.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Rssi",
      Description = "Receive signal strength indicator, 0: 0%, 100: 100%, 255: invalid/unknown.",
      NumElements = 1
    });
  }
}
