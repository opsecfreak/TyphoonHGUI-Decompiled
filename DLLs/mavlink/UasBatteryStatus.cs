// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasBatteryStatus
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasBatteryStatus : UasMessage
{
  private int mCurrentConsumed;
  private int mEnergyConsumed;
  private ushort mVoltageCell1;
  private ushort mVoltageCell2;
  private ushort mVoltageCell3;
  private ushort mVoltageCell4;
  private ushort mVoltageCell5;
  private ushort mVoltageCell6;
  private short mCurrentBattery;
  private byte mAccuId;
  private sbyte mBatteryRemaining;

  public int CurrentConsumed
  {
    get => this.mCurrentConsumed;
    set
    {
      this.mCurrentConsumed = value;
      this.NotifyUpdated();
    }
  }

  public int EnergyConsumed
  {
    get => this.mEnergyConsumed;
    set
    {
      this.mEnergyConsumed = value;
      this.NotifyUpdated();
    }
  }

  public ushort VoltageCell1
  {
    get => this.mVoltageCell1;
    set
    {
      this.mVoltageCell1 = value;
      this.NotifyUpdated();
    }
  }

  public ushort VoltageCell2
  {
    get => this.mVoltageCell2;
    set
    {
      this.mVoltageCell2 = value;
      this.NotifyUpdated();
    }
  }

  public ushort VoltageCell3
  {
    get => this.mVoltageCell3;
    set
    {
      this.mVoltageCell3 = value;
      this.NotifyUpdated();
    }
  }

  public ushort VoltageCell4
  {
    get => this.mVoltageCell4;
    set
    {
      this.mVoltageCell4 = value;
      this.NotifyUpdated();
    }
  }

  public ushort VoltageCell5
  {
    get => this.mVoltageCell5;
    set
    {
      this.mVoltageCell5 = value;
      this.NotifyUpdated();
    }
  }

  public ushort VoltageCell6
  {
    get => this.mVoltageCell6;
    set
    {
      this.mVoltageCell6 = value;
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

  public byte AccuId
  {
    get => this.mAccuId;
    set
    {
      this.mAccuId = value;
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

  public UasBatteryStatus()
  {
    this.mMessageId = (byte) 147;
    this.CrcExtra = (byte) 177;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mCurrentConsumed);
    s.Write(this.mEnergyConsumed);
    s.Write(this.mVoltageCell1);
    s.Write(this.mVoltageCell2);
    s.Write(this.mVoltageCell3);
    s.Write(this.mVoltageCell4);
    s.Write(this.mVoltageCell5);
    s.Write(this.mVoltageCell6);
    s.Write(this.mCurrentBattery);
    s.Write(this.mAccuId);
    s.Write(this.mBatteryRemaining);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mCurrentConsumed = s.ReadInt32();
    this.mEnergyConsumed = s.ReadInt32();
    this.mVoltageCell1 = s.ReadUInt16();
    this.mVoltageCell2 = s.ReadUInt16();
    this.mVoltageCell3 = s.ReadUInt16();
    this.mVoltageCell4 = s.ReadUInt16();
    this.mVoltageCell5 = s.ReadUInt16();
    this.mVoltageCell6 = s.ReadUInt16();
    this.mCurrentBattery = s.ReadInt16();
    this.mAccuId = s.ReadByte();
    this.mBatteryRemaining = s.ReadSByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Transmitte battery informations for a accu pack."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "CurrentConsumed",
      Description = "Consumed charge, in milliampere hours (1 = 1 mAh), -1: autopilot does not provide mAh consumption estimate",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "EnergyConsumed",
      Description = "Consumed energy, in 100*Joules (intergrated U*I*dt)  (1 = 100 Joule), -1: autopilot does not provide energy consumption estimate",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "VoltageCell1",
      Description = "Battery voltage of cell 1, in millivolts (1 = 1 millivolt)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "VoltageCell2",
      Description = "Battery voltage of cell 2, in millivolts (1 = 1 millivolt), -1: no cell",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "VoltageCell3",
      Description = "Battery voltage of cell 3, in millivolts (1 = 1 millivolt), -1: no cell",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "VoltageCell4",
      Description = "Battery voltage of cell 4, in millivolts (1 = 1 millivolt), -1: no cell",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "VoltageCell5",
      Description = "Battery voltage of cell 5, in millivolts (1 = 1 millivolt), -1: no cell",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "VoltageCell6",
      Description = "Battery voltage of cell 6, in millivolts (1 = 1 millivolt), -1: no cell",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "CurrentBattery",
      Description = "Battery current, in 10*milliamperes (1 = 10 milliampere), -1: autopilot does not measure the current",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "AccuId",
      Description = "Accupack ID",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "BatteryRemaining",
      Description = "Remaining battery energy: (0%: 0, 100%: 100), -1: autopilot does not estimate the remaining battery",
      NumElements = 1
    });
  }
}
