// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasHilControls
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasHilControls : UasMessage
{
  private ulong mTimeUsec;
  private float mRollAilerons;
  private float mPitchElevator;
  private float mYawRudder;
  private float mThrottle;
  private float mAux1;
  private float mAux2;
  private float mAux3;
  private float mAux4;
  private MavMode mMode;
  private byte mNavMode;

  public ulong TimeUsec
  {
    get => this.mTimeUsec;
    set
    {
      this.mTimeUsec = value;
      this.NotifyUpdated();
    }
  }

  public float RollAilerons
  {
    get => this.mRollAilerons;
    set
    {
      this.mRollAilerons = value;
      this.NotifyUpdated();
    }
  }

  public float PitchElevator
  {
    get => this.mPitchElevator;
    set
    {
      this.mPitchElevator = value;
      this.NotifyUpdated();
    }
  }

  public float YawRudder
  {
    get => this.mYawRudder;
    set
    {
      this.mYawRudder = value;
      this.NotifyUpdated();
    }
  }

  public float Throttle
  {
    get => this.mThrottle;
    set
    {
      this.mThrottle = value;
      this.NotifyUpdated();
    }
  }

  public float Aux1
  {
    get => this.mAux1;
    set
    {
      this.mAux1 = value;
      this.NotifyUpdated();
    }
  }

  public float Aux2
  {
    get => this.mAux2;
    set
    {
      this.mAux2 = value;
      this.NotifyUpdated();
    }
  }

  public float Aux3
  {
    get => this.mAux3;
    set
    {
      this.mAux3 = value;
      this.NotifyUpdated();
    }
  }

  public float Aux4
  {
    get => this.mAux4;
    set
    {
      this.mAux4 = value;
      this.NotifyUpdated();
    }
  }

  public MavMode Mode
  {
    get => this.mMode;
    set
    {
      this.mMode = value;
      this.NotifyUpdated();
    }
  }

  public byte NavMode
  {
    get => this.mNavMode;
    set
    {
      this.mNavMode = value;
      this.NotifyUpdated();
    }
  }

  public UasHilControls()
  {
    this.mMessageId = (byte) 91;
    this.CrcExtra = (byte) 63 /*0x3F*/;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeUsec);
    s.Write(this.mRollAilerons);
    s.Write(this.mPitchElevator);
    s.Write(this.mYawRudder);
    s.Write(this.mThrottle);
    s.Write(this.mAux1);
    s.Write(this.mAux2);
    s.Write(this.mAux3);
    s.Write(this.mAux4);
    s.Write((byte) this.mMode);
    s.Write(this.mNavMode);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeUsec = s.ReadUInt64();
    this.mRollAilerons = s.ReadSingle();
    this.mPitchElevator = s.ReadSingle();
    this.mYawRudder = s.ReadSingle();
    this.mThrottle = s.ReadSingle();
    this.mAux1 = s.ReadSingle();
    this.mAux2 = s.ReadSingle();
    this.mAux3 = s.ReadSingle();
    this.mAux4 = s.ReadSingle();
    this.mMode = (MavMode) s.ReadByte();
    this.mNavMode = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Sent from autopilot to simulation. Hardware in the loop control outputs"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeUsec",
      Description = "Timestamp (microseconds since UNIX epoch or microseconds since system boot)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "RollAilerons",
      Description = "Control output -1 .. 1",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "PitchElevator",
      Description = "Control output -1 .. 1",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "YawRudder",
      Description = "Control output -1 .. 1",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Throttle",
      Description = "Throttle 0 .. 1",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Aux1",
      Description = "Aux 1, -1 .. 1",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Aux2",
      Description = "Aux 2, -1 .. 1",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Aux3",
      Description = "Aux 3, -1 .. 1",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Aux4",
      Description = "Aux 4, -1 .. 1",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Mode",
      Description = "System mode (MAV_MODE)",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("MavMode")
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "NavMode",
      Description = "Navigation mode (MAV_NAV_MODE)",
      NumElements = 1
    });
  }
}
