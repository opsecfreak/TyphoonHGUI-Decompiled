// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasServoOutputRaw
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasServoOutputRaw : UasMessage
{
  private uint mTimeUsec;
  private ushort mServo1Raw;
  private ushort mServo2Raw;
  private ushort mServo3Raw;
  private ushort mServo4Raw;
  private ushort mServo5Raw;
  private ushort mServo6Raw;
  private ushort mServo7Raw;
  private ushort mServo8Raw;
  private byte mPort;

  public uint TimeUsec
  {
    get => this.mTimeUsec;
    set
    {
      this.mTimeUsec = value;
      this.NotifyUpdated();
    }
  }

  public ushort Servo1Raw
  {
    get => this.mServo1Raw;
    set
    {
      this.mServo1Raw = value;
      this.NotifyUpdated();
    }
  }

  public ushort Servo2Raw
  {
    get => this.mServo2Raw;
    set
    {
      this.mServo2Raw = value;
      this.NotifyUpdated();
    }
  }

  public ushort Servo3Raw
  {
    get => this.mServo3Raw;
    set
    {
      this.mServo3Raw = value;
      this.NotifyUpdated();
    }
  }

  public ushort Servo4Raw
  {
    get => this.mServo4Raw;
    set
    {
      this.mServo4Raw = value;
      this.NotifyUpdated();
    }
  }

  public ushort Servo5Raw
  {
    get => this.mServo5Raw;
    set
    {
      this.mServo5Raw = value;
      this.NotifyUpdated();
    }
  }

  public ushort Servo6Raw
  {
    get => this.mServo6Raw;
    set
    {
      this.mServo6Raw = value;
      this.NotifyUpdated();
    }
  }

  public ushort Servo7Raw
  {
    get => this.mServo7Raw;
    set
    {
      this.mServo7Raw = value;
      this.NotifyUpdated();
    }
  }

  public ushort Servo8Raw
  {
    get => this.mServo8Raw;
    set
    {
      this.mServo8Raw = value;
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

  public UasServoOutputRaw()
  {
    this.mMessageId = (byte) 36;
    this.CrcExtra = (byte) 222;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeUsec);
    s.Write(this.mServo1Raw);
    s.Write(this.mServo2Raw);
    s.Write(this.mServo3Raw);
    s.Write(this.mServo4Raw);
    s.Write(this.mServo5Raw);
    s.Write(this.mServo6Raw);
    s.Write(this.mServo7Raw);
    s.Write(this.mServo8Raw);
    s.Write(this.mPort);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeUsec = s.ReadUInt32();
    this.mServo1Raw = s.ReadUInt16();
    this.mServo2Raw = s.ReadUInt16();
    this.mServo3Raw = s.ReadUInt16();
    this.mServo4Raw = s.ReadUInt16();
    this.mServo5Raw = s.ReadUInt16();
    this.mServo6Raw = s.ReadUInt16();
    this.mServo7Raw = s.ReadUInt16();
    this.mServo8Raw = s.ReadUInt16();
    this.mPort = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "ServoOutputRaw;The RAW values of the servo outputs (for RC input from the remote, use the RC_CHANNELS messages). The standard PPM modulation is as follows: 1000 microseconds: 0%, 2000 microseconds: 100%."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeUsec",
      Value = this.TimeUsec.ToString(),
      Description = "Timestamp (microseconds since system boot)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Servo1Raw",
      Value = this.Servo1Raw.ToString(),
      Description = "Servo output 1 value, in microseconds",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Servo2Raw",
      Value = this.Servo2Raw.ToString(),
      Description = "Servo output 2 value, in microseconds",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Servo3Raw",
      Value = this.Servo3Raw.ToString(),
      Description = "Servo output 3 value, in microseconds",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Servo4Raw",
      Value = this.Servo4Raw.ToString(),
      Description = "Servo output 4 value, in microseconds",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Servo5Raw",
      Value = this.Servo5Raw.ToString(),
      Description = "Servo output 5 value, in microseconds",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Servo6Raw",
      Value = this.Servo6Raw.ToString(),
      Description = "Servo output 6 value, in microseconds",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Servo7Raw",
      Value = this.Servo7Raw.ToString(),
      Description = "Servo output 7 value, in microseconds",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Servo8Raw",
      Value = this.Servo8Raw.ToString(),
      Description = "Servo output 8 value, in microseconds",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Port",
      Value = this.Port.ToString(),
      Description = "Servo output port (set of 8 outputs = 1 port). Most MAVs will just use one, but this allows to encode more than 8 servos.",
      NumElements = 1
    });
  }
}
