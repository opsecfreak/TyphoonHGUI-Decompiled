// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasSetMode
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasSetMode : UasMessage
{
  private uint mCustomMode;
  private byte mTargetSystem;
  private byte mBaseMode;

  public uint CustomMode
  {
    get => this.mCustomMode;
    set
    {
      this.mCustomMode = value;
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

  public byte BaseMode
  {
    get => this.mBaseMode;
    set
    {
      this.mBaseMode = value;
      this.NotifyUpdated();
    }
  }

  public UasSetMode()
  {
    this.mMessageId = (byte) 11;
    this.CrcExtra = (byte) 89;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mCustomMode);
    s.Write(this.mTargetSystem);
    s.Write(this.mBaseMode);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mCustomMode = s.ReadUInt32();
    this.mTargetSystem = s.ReadByte();
    this.mBaseMode = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Set the system mode, as defined by enum MAV_MODE. There is no target component id as the mode is by definition for the overall aircraft, not only for one component."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "CustomMode",
      Description = "The new autopilot-specific mode. This field can be ignored by an autopilot.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TargetSystem",
      Description = "The system setting the mode",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "BaseMode",
      Description = "The new base mode",
      NumElements = 1
    });
  }
}
