// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasFenceFetchPoint
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasFenceFetchPoint : UasMessage
{
  private byte mTargetSystem;
  private byte mTargetComponent;
  private byte mIdx;

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

  public byte Idx
  {
    get => this.mIdx;
    set
    {
      this.mIdx = value;
      this.NotifyUpdated();
    }
  }

  public UasFenceFetchPoint()
  {
    this.mMessageId = (byte) 161;
    this.CrcExtra = (byte) 68;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTargetSystem);
    s.Write(this.mTargetComponent);
    s.Write(this.mIdx);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTargetSystem = s.ReadByte();
    this.mTargetComponent = s.ReadByte();
    this.mIdx = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Request a current fence point from MAV"
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
      Name = "Idx",
      Description = "point index (first point is 1, 0 is for return point)",
      NumElements = 1
    });
  }
}
