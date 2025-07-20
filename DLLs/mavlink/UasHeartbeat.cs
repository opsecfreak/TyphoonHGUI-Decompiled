// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasHeartbeat
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasHeartbeat : UasMessage
{
  private uint mCustomMode;
  private MavType mType;
  private MavAutopilot mAutopilot;
  private MavModeFlag mBaseMode;
  private MavState mSystemStatus;
  private byte mMavlinkVersion;

  public uint CustomMode
  {
    get => this.mCustomMode;
    set
    {
      this.mCustomMode = value;
      this.NotifyUpdated();
    }
  }

  public MavType Type
  {
    get => this.mType;
    set
    {
      this.mType = value;
      this.NotifyUpdated();
    }
  }

  public MavAutopilot Autopilot
  {
    get => this.mAutopilot;
    set
    {
      this.mAutopilot = value;
      this.NotifyUpdated();
    }
  }

  public MavModeFlag BaseMode
  {
    get => this.mBaseMode;
    set
    {
      this.mBaseMode = value;
      this.NotifyUpdated();
    }
  }

  public MavState SystemStatus
  {
    get => this.mSystemStatus;
    set
    {
      this.mSystemStatus = value;
      this.NotifyUpdated();
    }
  }

  public byte MavlinkVersion
  {
    get => this.mMavlinkVersion;
    set
    {
      this.mMavlinkVersion = value;
      this.NotifyUpdated();
    }
  }

  public UasHeartbeat()
  {
    this.mMessageId = (byte) 0;
    this.CrcExtra = (byte) 50;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mCustomMode);
    s.Write((byte) this.mType);
    s.Write((byte) this.mAutopilot);
    s.Write((byte) this.mBaseMode);
    s.Write((byte) this.mSystemStatus);
    s.Write(this.mMavlinkVersion);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mCustomMode = s.ReadUInt32();
    this.mType = (MavType) s.ReadByte();
    this.mAutopilot = (MavAutopilot) s.ReadByte();
    this.mBaseMode = (MavModeFlag) s.ReadByte();
    this.mSystemStatus = (MavState) s.ReadByte();
    this.mMavlinkVersion = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Heartbeat;The heartbeat message shows that a system is present and responding. The type of the MAV and Autopilot hardware allow the receiving system to treat further messages from this system appropriate (e.g. by laying out the user interface based on the autopilot)."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "CustomMode",
      Value = this.CustomMode.ToString(),
      Description = "A bitfield for use for autopilot-specific flags.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Type",
      Value = this.Type.ToString(),
      Description = "Type of the MAV (quadrotor, helicopter, etc., up to 15 types, defined in MAV_TYPE ENUM)",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("MavType")
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Autopilot",
      Value = this.Autopilot.ToString(),
      Description = "Autopilot type / class. defined in MAV_AUTOPILOT ENUM",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("MavAutopilot")
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "BaseMode",
      Value = this.BaseMode.ToString(),
      Description = "System mode bitfield, see MAV_MODE_FLAGS ENUM in mavlink/include/mavlink_types.h",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("MavModeFlag")
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "SystemStatus",
      Value = this.SystemStatus.ToString(),
      Description = "System status flag, see MAV_STATE ENUM",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("MavState")
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "MavlinkVersion",
      Value = this.MavlinkVersion.ToString(),
      Description = "MAVLink version, not writable by user, gets added by protocol because of magic data type: uint8_t_mavlink_version",
      NumElements = 1
    });
  }
}
