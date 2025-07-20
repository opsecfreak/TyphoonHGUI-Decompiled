// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasMountConfigure
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasMountConfigure : UasMessage
{
  private byte mTargetSystem;
  private byte mTargetComponent;
  private MavMountMode mMountMode;
  private byte mStabRoll;
  private byte mStabPitch;
  private byte mStabYaw;

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

  public MavMountMode MountMode
  {
    get => this.mMountMode;
    set
    {
      this.mMountMode = value;
      this.NotifyUpdated();
    }
  }

  public byte StabRoll
  {
    get => this.mStabRoll;
    set
    {
      this.mStabRoll = value;
      this.NotifyUpdated();
    }
  }

  public byte StabPitch
  {
    get => this.mStabPitch;
    set
    {
      this.mStabPitch = value;
      this.NotifyUpdated();
    }
  }

  public byte StabYaw
  {
    get => this.mStabYaw;
    set
    {
      this.mStabYaw = value;
      this.NotifyUpdated();
    }
  }

  public UasMountConfigure()
  {
    this.mMessageId = (byte) 156;
    this.CrcExtra = (byte) 19;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTargetSystem);
    s.Write(this.mTargetComponent);
    s.Write((byte) this.mMountMode);
    s.Write(this.mStabRoll);
    s.Write(this.mStabPitch);
    s.Write(this.mStabYaw);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTargetSystem = s.ReadByte();
    this.mTargetComponent = s.ReadByte();
    this.mMountMode = (MavMountMode) s.ReadByte();
    this.mStabRoll = s.ReadByte();
    this.mStabPitch = s.ReadByte();
    this.mStabYaw = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Message to configure a camera mount, directional antenna, etc."
    };
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
      Name = "MountMode",
      Description = "mount operating mode (see MAV_MOUNT_MODE enum)",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("MavMountMode")
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "StabRoll",
      Description = "(1 = yes, 0 = no)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "StabPitch",
      Description = "(1 = yes, 0 = no)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "StabYaw",
      Description = "(1 = yes, 0 = no)",
      NumElements = 1
    });
  }
}
