// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasSysStatus
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasSysStatus : UasMessage
{
  private MavSysStatusSensor mOnboardControlSensorsPresent;
  private MavSysStatusSensor mOnboardControlSensorsEnabled;
  private MavSysStatusSensor mOnboardControlSensorsHealth;
  private ushort mLoad;
  private ushort mVoltageBattery;
  private short mCurrentBattery;
  private ushort mDropRateComm;
  private ushort mErrorsComm;
  private ushort mErrorsCount1;
  private ushort mErrorsCount2;
  private ushort mErrorsCount3;
  private ushort mErrorsCount4;
  private sbyte mBatteryRemaining;

  public MavSysStatusSensor OnboardControlSensorsPresent
  {
    get => this.mOnboardControlSensorsPresent;
    set
    {
      this.mOnboardControlSensorsPresent = value;
      this.NotifyUpdated();
    }
  }

  public MavSysStatusSensor OnboardControlSensorsEnabled
  {
    get => this.mOnboardControlSensorsEnabled;
    set
    {
      this.mOnboardControlSensorsEnabled = value;
      this.NotifyUpdated();
    }
  }

  public MavSysStatusSensor OnboardControlSensorsHealth
  {
    get => this.mOnboardControlSensorsHealth;
    set
    {
      this.mOnboardControlSensorsHealth = value;
      this.NotifyUpdated();
    }
  }

  public ushort Load
  {
    get => this.mLoad;
    set
    {
      this.mLoad = value;
      this.NotifyUpdated();
    }
  }

  public ushort VoltageBattery
  {
    get => this.mVoltageBattery;
    set
    {
      this.mVoltageBattery = value;
      this.NotifyUpdated();
    }
  }

  public short CurrentBattery
  {
    get => this.mCurrentBattery;
    set
    {
      this.mCurrentBattery = value;
      this.NotifyUpdated();
    }
  }

  public ushort DropRateComm
  {
    get => this.mDropRateComm;
    set
    {
      this.mDropRateComm = value;
      this.NotifyUpdated();
    }
  }

  public ushort ErrorsComm
  {
    get => this.mErrorsComm;
    set
    {
      this.mErrorsComm = value;
      this.NotifyUpdated();
    }
  }

  public ushort ErrorsCount1
  {
    get => this.mErrorsCount1;
    set
    {
      this.mErrorsCount1 = value;
      this.NotifyUpdated();
    }
  }

  public ushort ErrorsCount2
  {
    get => this.mErrorsCount2;
    set
    {
      this.mErrorsCount2 = value;
      this.NotifyUpdated();
    }
  }

  public ushort ErrorsCount3
  {
    get => this.mErrorsCount3;
    set
    {
      this.mErrorsCount3 = value;
      this.NotifyUpdated();
    }
  }

  public ushort ErrorsCount4
  {
    get => this.mErrorsCount4;
    set
    {
      this.mErrorsCount4 = value;
      this.NotifyUpdated();
    }
  }

  public sbyte BatteryRemaining
  {
    get => this.mBatteryRemaining;
    set
    {
      this.mBatteryRemaining = value;
      this.NotifyUpdated();
    }
  }

  public UasSysStatus()
  {
    this.mMessageId = (byte) 1;
    this.CrcExtra = (byte) 124;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write((uint) this.mOnboardControlSensorsPresent);
    s.Write((uint) this.mOnboardControlSensorsEnabled);
    s.Write((uint) this.mOnboardControlSensorsHealth);
    s.Write(this.mLoad);
    s.Write(this.mVoltageBattery);
    s.Write(this.mCurrentBattery);
    s.Write(this.mDropRateComm);
    s.Write(this.mErrorsComm);
    s.Write(this.mErrorsCount1);
    s.Write(this.mErrorsCount2);
    s.Write(this.mErrorsCount3);
    s.Write(this.mErrorsCount4);
    s.Write(this.mBatteryRemaining);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mOnboardControlSensorsPresent = (MavSysStatusSensor) s.ReadUInt32();
    this.mOnboardControlSensorsEnabled = (MavSysStatusSensor) s.ReadUInt32();
    this.mOnboardControlSensorsHealth = (MavSysStatusSensor) s.ReadUInt32();
    this.mLoad = s.ReadUInt16();
    this.mVoltageBattery = s.ReadUInt16();
    this.mCurrentBattery = s.ReadInt16();
    this.mDropRateComm = s.ReadUInt16();
    this.mErrorsComm = s.ReadUInt16();
    this.mErrorsCount1 = s.ReadUInt16();
    this.mErrorsCount2 = s.ReadUInt16();
    this.mErrorsCount3 = s.ReadUInt16();
    this.mErrorsCount4 = s.ReadUInt16();
    this.mBatteryRemaining = s.ReadSByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "SysStatus;The general system state. If the system is following the MAVLink standard, the system state is mainly defined by three orthogonal states/modes: The system mode, which is either LOCKED (motors shut down and locked), MANUAL (system under RC control), GUIDED (system with autonomous position control, position setpoint controlled manually) or AUTO (system guided by path/waypoint planner). The NAV_MODE defined the current flight state: LIFTOFF (often an open-loop maneuver), LANDING, WAYPOINTS or VECTOR. This represents the internal navigation state machine. The system status shows wether the system is currently active or not and if an emergency occured. During the CRITICAL and EMERGENCY states the MAV is still considered to be active, but should start emergency procedures autonomously. After a failure occured it should first move from active to critical to allow manual intervention and then move to emergency after a certain timeout."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "OnboardControlSensorsPresent",
      Value = this.mOnboardControlSensorsPresent.ToString(),
      Description = "Bitmask showing which onboard controllers and sensors are present. Value of 0: not present. Value of 1: present. Indices defined by ENUM MAV_SYS_STATUS_SENSOR",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("MavSysStatusSensor")
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "OnboardControlSensorsEnabled",
      Value = this.OnboardControlSensorsEnabled.ToString(),
      Description = "Bitmask showing which onboard controllers and sensors are enabled:  Value of 0: not enabled. Value of 1: enabled. Indices defined by ENUM MAV_SYS_STATUS_SENSOR",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("MavSysStatusSensor")
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "OnboardControlSensorsHealth",
      Value = this.OnboardControlSensorsHealth.ToString(),
      Description = "Bitmask showing which onboard controllers and sensors are operational or have an error:  Value of 0: not enabled. Value of 1: enabled. Indices defined by ENUM MAV_SYS_STATUS_SENSOR",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("MavSysStatusSensor")
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Load",
      Value = this.Load.ToString(),
      Description = "Maximum usage in percent of the mainloop time, (0%: 0, 100%: 1000) should be always below 1000",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "VoltageBattery",
      Value = this.VoltageBattery.ToString(),
      Description = "Battery voltage, in millivolts (1 = 1 millivolt)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "CurrentBattery",
      Value = this.CurrentBattery.ToString(),
      Description = "Battery current, in 10*milliamperes (1 = 10 milliampere), -1: autopilot does not measure the current",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "DropRateComm",
      Value = this.DropRateComm.ToString(),
      Description = "Communication drops in percent, (0%: 0, 100%: 10'000), (UART, I2C, SPI, CAN), dropped packets on all links (packets that were corrupted on reception on the MAV)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ErrorsComm",
      Value = this.ErrorsComm.ToString(),
      Description = "Communication errors (UART, I2C, SPI, CAN), dropped packets on all links (packets that were corrupted on reception on the MAV)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ErrorsCount1",
      Value = this.ErrorsCount1.ToString(),
      Description = "Autopilot-specific errors",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ErrorsCount2",
      Value = this.ErrorsCount2.ToString(),
      Description = "Autopilot-specific errors",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ErrorsCount3",
      Value = this.ErrorsCount3.ToString(),
      Description = "Autopilot-specific errors",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ErrorsCount4",
      Value = this.ErrorsCount4.ToString(),
      Description = "Autopilot-specific errors",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "BatteryRemaining",
      Value = this.BatteryRemaining.ToString(),
      Description = "Remaining battery energy: (0%: 0, 100%: 100), -1: autopilot estimate the remaining battery",
      NumElements = 1
    });
  }
}
