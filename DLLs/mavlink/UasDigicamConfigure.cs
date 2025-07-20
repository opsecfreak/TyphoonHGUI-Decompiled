// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasDigicamConfigure
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasDigicamConfigure : UasMessage
{
  private float mExtraValue;
  private ushort mShutterSpeed;
  private byte mTargetSystem;
  private byte mTargetComponent;
  private byte mMode;
  private byte mAperture;
  private byte mIso;
  private byte mExposureType;
  private byte mCommandId;
  private byte mEngineCutOff;
  private byte mExtraParam;

  public float ExtraValue
  {
    get => this.mExtraValue;
    set
    {
      this.mExtraValue = value;
      this.NotifyUpdated();
    }
  }

  public ushort ShutterSpeed
  {
    get => this.mShutterSpeed;
    set
    {
      this.mShutterSpeed = value;
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

  public byte Mode
  {
    get => this.mMode;
    set
    {
      this.mMode = value;
      this.NotifyUpdated();
    }
  }

  public byte Aperture
  {
    get => this.mAperture;
    set
    {
      this.mAperture = value;
      this.NotifyUpdated();
    }
  }

  public byte Iso
  {
    get => this.mIso;
    set
    {
      this.mIso = value;
      this.NotifyUpdated();
    }
  }

  public byte ExposureType
  {
    get => this.mExposureType;
    set
    {
      this.mExposureType = value;
      this.NotifyUpdated();
    }
  }

  public byte CommandId
  {
    get => this.mCommandId;
    set
    {
      this.mCommandId = value;
      this.NotifyUpdated();
    }
  }

  public byte EngineCutOff
  {
    get => this.mEngineCutOff;
    set
    {
      this.mEngineCutOff = value;
      this.NotifyUpdated();
    }
  }

  public byte ExtraParam
  {
    get => this.mExtraParam;
    set
    {
      this.mExtraParam = value;
      this.NotifyUpdated();
    }
  }

  public UasDigicamConfigure()
  {
    this.mMessageId = (byte) 154;
    this.CrcExtra = (byte) 84;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mExtraValue);
    s.Write(this.mShutterSpeed);
    s.Write(this.mTargetSystem);
    s.Write(this.mTargetComponent);
    s.Write(this.mMode);
    s.Write(this.mAperture);
    s.Write(this.mIso);
    s.Write(this.mExposureType);
    s.Write(this.mCommandId);
    s.Write(this.mEngineCutOff);
    s.Write(this.mExtraParam);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mExtraValue = s.ReadSingle();
    this.mShutterSpeed = s.ReadUInt16();
    this.mTargetSystem = s.ReadByte();
    this.mTargetComponent = s.ReadByte();
    this.mMode = s.ReadByte();
    this.mAperture = s.ReadByte();
    this.mIso = s.ReadByte();
    this.mExposureType = s.ReadByte();
    this.mCommandId = s.ReadByte();
    this.mEngineCutOff = s.ReadByte();
    this.mExtraParam = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Configure on-board Camera Control System."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ExtraValue",
      Description = "Correspondent value to given extra_param",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ShutterSpeed",
      Description = "Divisor number //e.g. 1000 means 1/1000 (0 means ignore)",
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
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Mode",
      Description = "Mode enumeration from 1 to N //P, TV, AV, M, Etc (0 means ignore)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Aperture",
      Description = "F stop number x 10 //e.g. 28 means 2.8 (0 means ignore)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Iso",
      Description = "ISO enumeration from 1 to N //e.g. 80, 100, 200, Etc (0 means ignore)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ExposureType",
      Description = "Exposure type enumeration from 1 to N (0 means ignore)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "CommandId",
      Description = "Command Identity (incremental loop: 0 to 255)//A command sent multiple times will be executed or pooled just once",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "EngineCutOff",
      Description = "Main engine cut-off time before camera trigger in seconds/10 (0 means no cut-off)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ExtraParam",
      Description = "Extra parameters enumeration (0 means ignore)",
      NumElements = 1
    });
  }
}
