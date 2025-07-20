// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasMissionItem
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasMissionItem : UasMessage
{
  private float mParam1;
  private float mParam2;
  private float mParam3;
  private float mParam4;
  private float mX;
  private float mY;
  private float mZ;
  private ushort mSeq;
  private MavCmd mCommand;
  private byte mTargetSystem;
  private byte mTargetComponent;
  private MavFrame mFrame;
  private byte mCurrent;
  private byte mAutocontinue;

  public float Param1
  {
    get => this.mParam1;
    set
    {
      this.mParam1 = value;
      this.NotifyUpdated();
    }
  }

  public float Param2
  {
    get => this.mParam2;
    set
    {
      this.mParam2 = value;
      this.NotifyUpdated();
    }
  }

  public float Param3
  {
    get => this.mParam3;
    set
    {
      this.mParam3 = value;
      this.NotifyUpdated();
    }
  }

  public float Param4
  {
    get => this.mParam4;
    set
    {
      this.mParam4 = value;
      this.NotifyUpdated();
    }
  }

  public float X
  {
    get => this.mX;
    set
    {
      this.mX = value;
      this.NotifyUpdated();
    }
  }

  public float Y
  {
    get => this.mY;
    set
    {
      this.mY = value;
      this.NotifyUpdated();
    }
  }

  public float Z
  {
    get => this.mZ;
    set
    {
      this.mZ = value;
      this.NotifyUpdated();
    }
  }

  public ushort Seq
  {
    get => this.mSeq;
    set
    {
      this.mSeq = value;
      this.NotifyUpdated();
    }
  }

  public MavCmd Command
  {
    get => this.mCommand;
    set
    {
      this.mCommand = value;
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

  public MavFrame Frame
  {
    get => this.mFrame;
    set
    {
      this.mFrame = value;
      this.NotifyUpdated();
    }
  }

  public byte Current
  {
    get => this.mCurrent;
    set
    {
      this.mCurrent = value;
      this.NotifyUpdated();
    }
  }

  public byte Autocontinue
  {
    get => this.mAutocontinue;
    set
    {
      this.mAutocontinue = value;
      this.NotifyUpdated();
    }
  }

  public UasMissionItem()
  {
    this.mMessageId = (byte) 39;
    this.CrcExtra = (byte) 254;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mParam1);
    s.Write(this.mParam2);
    s.Write(this.mParam3);
    s.Write(this.mParam4);
    s.Write(this.mX);
    s.Write(this.mY);
    s.Write(this.mZ);
    s.Write(this.mSeq);
    s.Write((ushort) this.mCommand);
    s.Write(this.mTargetSystem);
    s.Write(this.mTargetComponent);
    s.Write((byte) this.mFrame);
    s.Write(this.mCurrent);
    s.Write(this.mAutocontinue);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mParam1 = s.ReadSingle();
    this.mParam2 = s.ReadSingle();
    this.mParam3 = s.ReadSingle();
    this.mParam4 = s.ReadSingle();
    this.mX = s.ReadSingle();
    this.mY = s.ReadSingle();
    this.mZ = s.ReadSingle();
    this.mSeq = s.ReadUInt16();
    this.mCommand = (MavCmd) s.ReadUInt16();
    this.mTargetSystem = s.ReadByte();
    this.mTargetComponent = s.ReadByte();
    this.mFrame = (MavFrame) s.ReadByte();
    this.mCurrent = s.ReadByte();
    this.mAutocontinue = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Message encoding a mission item. This message is emitted to announce                  the presence of a mission item and to set a mission item on the system. The mission item can be either in x, y, z meters (type: LOCAL) or x:lat, y:lon, z:altitude. Local frame is Z-down, right handed (NED), global frame is Z-up, right handed (ENU). See also http://qgroundcontrol.org/mavlink/waypoint_protocol."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Param1",
      Description = "PARAM1 / For NAV command MISSIONs: Radius in which the MISSION is accepted as reached, in meters",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Param2",
      Description = "PARAM2 / For NAV command MISSIONs: Time that the MAV should stay inside the PARAM1 radius before advancing, in milliseconds",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Param3",
      Description = "PARAM3 / For LOITER command MISSIONs: Orbit to circle around the MISSION, in meters. If positive the orbit direction should be clockwise, if negative the orbit direction should be counter-clockwise.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Param4",
      Description = "PARAM4 / For NAV and LOITER command MISSIONs: Yaw orientation in degrees, [0..360] 0 = NORTH",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "X",
      Description = "PARAM5 / local: x position, global: latitude",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Y",
      Description = "PARAM6 / y position: global: longitude",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Z",
      Description = "PARAM7 / z position: global: altitude",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Seq",
      Description = "Sequence",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Command",
      Description = "The scheduled action for the MISSION. see MAV_CMD in common.xml MAVLink specs",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("MavCmd")
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
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Frame",
      Description = "The coordinate system of the MISSION. see MAV_FRAME in mavlink_types.h",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("MavFrame")
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Current",
      Description = "false:0, true:1",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Autocontinue",
      Description = "autocontinue to next wp",
      NumElements = 1
    });
  }
}
