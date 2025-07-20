// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavlinkRequestInfoCmd
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class MavlinkRequestInfoCmd : UasMessage
{
  private MavRequestInfoSystemId mTargetSystem;
  private byte mTargetComponent;
  private MavRequestInfoType mType;

  public MavRequestInfoSystemId TargetSystem
  {
    set
    {
      this.mTargetSystem = value;
      this.NotifyUpdated();
    }
    get => this.mTargetSystem;
  }

  public byte TargetComponent
  {
    set
    {
      this.mTargetComponent = value;
      this.NotifyUpdated();
    }
    get => this.mTargetComponent;
  }

  public MavRequestInfoType Type
  {
    set
    {
      this.mType = value;
      this.NotifyUpdated();
    }
    get => this.mType;
  }

  public MavlinkRequestInfoCmd()
  {
    this.mMessageId = (byte) 51;
    this.CrcExtra = (byte) 132;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write((byte) this.mTargetSystem);
    s.Write(this.mTargetComponent);
    s.Write((byte) this.mType);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTargetSystem = (MavRequestInfoSystemId) s.ReadByte();
    this.mTargetComponent = s.ReadByte();
    this.mType = (MavRequestInfoType) s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "MavlinkRequestInfoCmd;Pack a request_info_cmd message"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TargetSystem",
      Description = "TargetSystem",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TargetComponent",
      Description = "TargetComponent",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Type",
      Description = "Type",
      NumElements = 1
    });
  }
}
