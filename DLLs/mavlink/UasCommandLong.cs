// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasCommandLong
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasCommandLong : UasMessage
{
  private float mParam1;
  private float mParam2;
  private float mParam3;
  private float mParam4;
  private float mParam5;
  private float mParam6;
  private float mParam7;
  private MavCmd mCommand;
  private byte mTargetSystem;
  private byte mTargetComponent;
  private byte mConfirmation;

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

  public float Param5
  {
    get => this.mParam5;
    set
    {
      this.mParam5 = value;
      this.NotifyUpdated();
    }
  }

  public float Param6
  {
    get => this.mParam6;
    set
    {
      this.mParam6 = value;
      this.NotifyUpdated();
    }
  }

  public float Param7
  {
    get => this.mParam7;
    set
    {
      this.mParam7 = value;
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

  public byte Confirmation
  {
    get => this.mConfirmation;
    set
    {
      this.mConfirmation = value;
      this.NotifyUpdated();
    }
  }

  public UasCommandLong()
  {
    this.mMessageId = (byte) 76;
    this.CrcExtra = (byte) 152;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mParam1);
    s.Write(this.mParam2);
    s.Write(this.mParam3);
    s.Write(this.mParam4);
    s.Write(this.mParam5);
    s.Write(this.mParam6);
    s.Write(this.mParam7);
    s.Write((ushort) this.mCommand);
    s.Write(this.mTargetSystem);
    s.Write(this.mTargetComponent);
    s.Write(this.mConfirmation);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mParam1 = s.ReadSingle();
    this.mParam2 = s.ReadSingle();
    this.mParam3 = s.ReadSingle();
    this.mParam4 = s.ReadSingle();
    this.mParam5 = s.ReadSingle();
    this.mParam6 = s.ReadSingle();
    this.mParam7 = s.ReadSingle();
    this.mCommand = (MavCmd) s.ReadUInt16();
    this.mTargetSystem = s.ReadByte();
    this.mTargetComponent = s.ReadByte();
    this.mConfirmation = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Send a command with up to seven parameters to the MAV"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Param1",
      Description = "Parameter 1, as defined by MAV_CMD enum.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Param2",
      Description = "Parameter 2, as defined by MAV_CMD enum.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Param3",
      Description = "Parameter 3, as defined by MAV_CMD enum.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Param4",
      Description = "Parameter 4, as defined by MAV_CMD enum.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Param5",
      Description = "Parameter 5, as defined by MAV_CMD enum.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Param6",
      Description = "Parameter 6, as defined by MAV_CMD enum.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Param7",
      Description = "Parameter 7, as defined by MAV_CMD enum.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Command",
      Description = "Command ID, as defined by MAV_CMD enum.",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("MavCmd")
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TargetSystem",
      Description = "System which should execute the command",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TargetComponent",
      Description = "Component which should execute the command, 0 for all components",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Confirmation",
      Description = "0: First transmission of this command. 1-255: Confirmation transmissions (e.g. for kill command)",
      NumElements = 1
    });
  }
}
