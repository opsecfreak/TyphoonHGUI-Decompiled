// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasLimitsStatus
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasLimitsStatus : UasMessage
{
  private uint mLastTrigger;
  private uint mLastAction;
  private uint mLastRecovery;
  private uint mLastClear;
  private ushort mBreachCount;
  private LimitsState mLimitsState;
  private LimitModule mModsEnabled;
  private LimitModule mModsRequired;
  private LimitModule mModsTriggered;

  public uint LastTrigger
  {
    get => this.mLastTrigger;
    set
    {
      this.mLastTrigger = value;
      this.NotifyUpdated();
    }
  }

  public uint LastAction
  {
    get => this.mLastAction;
    set
    {
      this.mLastAction = value;
      this.NotifyUpdated();
    }
  }

  public uint LastRecovery
  {
    get => this.mLastRecovery;
    set
    {
      this.mLastRecovery = value;
      this.NotifyUpdated();
    }
  }

  public uint LastClear
  {
    get => this.mLastClear;
    set
    {
      this.mLastClear = value;
      this.NotifyUpdated();
    }
  }

  public ushort BreachCount
  {
    get => this.mBreachCount;
    set
    {
      this.mBreachCount = value;
      this.NotifyUpdated();
    }
  }

  public LimitsState LimitsState
  {
    get => this.mLimitsState;
    set
    {
      this.mLimitsState = value;
      this.NotifyUpdated();
    }
  }

  public LimitModule ModsEnabled
  {
    get => this.mModsEnabled;
    set
    {
      this.mModsEnabled = value;
      this.NotifyUpdated();
    }
  }

  public LimitModule ModsRequired
  {
    get => this.mModsRequired;
    set
    {
      this.mModsRequired = value;
      this.NotifyUpdated();
    }
  }

  public LimitModule ModsTriggered
  {
    get => this.mModsTriggered;
    set
    {
      this.mModsTriggered = value;
      this.NotifyUpdated();
    }
  }

  public UasLimitsStatus()
  {
    this.mMessageId = (byte) 167;
    this.CrcExtra = (byte) 144 /*0x90*/;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mLastTrigger);
    s.Write(this.mLastAction);
    s.Write(this.mLastRecovery);
    s.Write(this.mLastClear);
    s.Write(this.mBreachCount);
    s.Write((byte) this.mLimitsState);
    s.Write((byte) this.mModsEnabled);
    s.Write((byte) this.mModsRequired);
    s.Write((byte) this.mModsTriggered);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mLastTrigger = s.ReadUInt32();
    this.mLastAction = s.ReadUInt32();
    this.mLastRecovery = s.ReadUInt32();
    this.mLastClear = s.ReadUInt32();
    this.mBreachCount = s.ReadUInt16();
    this.mLimitsState = (LimitsState) s.ReadByte();
    this.mModsEnabled = (LimitModule) s.ReadByte();
    this.mModsRequired = (LimitModule) s.ReadByte();
    this.mModsTriggered = (LimitModule) s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Status of AP_Limits. Sent in extended  \t    status stream when AP_Limits is enabled"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "LastTrigger",
      Description = "time of last breach in milliseconds since boot",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "LastAction",
      Description = "time of last recovery action in milliseconds since boot",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "LastRecovery",
      Description = "time of last successful recovery in milliseconds since boot",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "LastClear",
      Description = "time of last all-clear in milliseconds since boot",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "BreachCount",
      Description = "number of fence breaches",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "LimitsState",
      Description = "state of AP_Limits, (see enum LimitState, LIMITS_STATE)",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("LimitsState")
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ModsEnabled",
      Description = "AP_Limit_Module bitfield of enabled modules, (see enum moduleid or LIMIT_MODULE)",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("LimitModule")
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ModsRequired",
      Description = "AP_Limit_Module bitfield of required modules, (see enum moduleid or LIMIT_MODULE)",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("LimitModule")
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ModsTriggered",
      Description = "AP_Limit_Module bitfield of triggered modules, (see enum moduleid or LIMIT_MODULE)",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("LimitModule")
    });
  }
}
