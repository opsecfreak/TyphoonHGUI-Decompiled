// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasDigicamControl
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasDigicamControl : UasMessage
{
  private float mExtraValue;
  private byte mTargetSystem;
  private byte mTargetComponent;
  private byte mSession;
  private byte mZoomPos;
  private sbyte mZoomStep;
  private byte mFocusLock;
  private byte mShot;
  private byte mCommandId;
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

  public byte Session
  {
    get => this.mSession;
    set
    {
      this.mSession = value;
      this.NotifyUpdated();
    }
  }

  public byte ZoomPos
  {
    get => this.mZoomPos;
    set
    {
      this.mZoomPos = value;
      this.NotifyUpdated();
    }
  }

  public sbyte ZoomStep
  {
    get => this.mZoomStep;
    set
    {
      this.mZoomStep = value;
      this.NotifyUpdated();
    }
  }

  public byte FocusLock
  {
    get => this.mFocusLock;
    set
    {
      this.mFocusLock = value;
      this.NotifyUpdated();
    }
  }

  public byte Shot
  {
    get => this.mShot;
    set
    {
      this.mShot = value;
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

  public byte ExtraParam
  {
    get => this.mExtraParam;
    set
    {
      this.mExtraParam = value;
      this.NotifyUpdated();
    }
  }

  public UasDigicamControl()
  {
    this.mMessageId = (byte) 155;
    this.CrcExtra = (byte) 22;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mExtraValue);
    s.Write(this.mTargetSystem);
    s.Write(this.mTargetComponent);
    s.Write(this.mSession);
    s.Write(this.mZoomPos);
    s.Write(this.mZoomStep);
    s.Write(this.mFocusLock);
    s.Write(this.mShot);
    s.Write(this.mCommandId);
    s.Write(this.mExtraParam);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mExtraValue = s.ReadSingle();
    this.mTargetSystem = s.ReadByte();
    this.mTargetComponent = s.ReadByte();
    this.mSession = s.ReadByte();
    this.mZoomPos = s.ReadByte();
    this.mZoomStep = s.ReadSByte();
    this.mFocusLock = s.ReadByte();
    this.mShot = s.ReadByte();
    this.mCommandId = s.ReadByte();
    this.mExtraParam = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Control on-board Camera Control System to take shots."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ExtraValue",
      Description = "Correspondent value to given extra_param",
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
      Name = "Session",
      Description = "0: stop, 1: start or keep it up //Session control e.g. show/hide lens",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ZoomPos",
      Description = "1 to N //Zoom's absolute position (0 means ignore)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ZoomStep",
      Description = "-100 to 100 //Zooming step value to offset zoom from the current position",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "FocusLock",
      Description = "0: unlock focus or keep unlocked, 1: lock focus or keep locked, 3: re-lock focus",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Shot",
      Description = "0: ignore, 1: shot or start filming",
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
      Name = "ExtraParam",
      Description = "Extra parameters enumeration (0 means ignore)",
      NumElements = 1
    });
  }
}
