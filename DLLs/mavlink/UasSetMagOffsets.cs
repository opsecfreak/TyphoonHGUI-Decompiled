// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasSetMagOffsets
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasSetMagOffsets : UasMessage
{
  private short mMagOfsX;
  private short mMagOfsY;
  private short mMagOfsZ;
  private byte mTargetSystem;
  private byte mTargetComponent;

  public short MagOfsX
  {
    get => this.mMagOfsX;
    set
    {
      this.mMagOfsX = value;
      this.NotifyUpdated();
    }
  }

  public short MagOfsY
  {
    get => this.mMagOfsY;
    set
    {
      this.mMagOfsY = value;
      this.NotifyUpdated();
    }
  }

  public short MagOfsZ
  {
    get => this.mMagOfsZ;
    set
    {
      this.mMagOfsZ = value;
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

  public UasSetMagOffsets()
  {
    this.mMessageId = (byte) 151;
    this.CrcExtra = (byte) 219;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mMagOfsX);
    s.Write(this.mMagOfsY);
    s.Write(this.mMagOfsZ);
    s.Write(this.mTargetSystem);
    s.Write(this.mTargetComponent);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mMagOfsX = s.ReadInt16();
    this.mMagOfsY = s.ReadInt16();
    this.mMagOfsZ = s.ReadInt16();
    this.mTargetSystem = s.ReadByte();
    this.mTargetComponent = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "set the magnetometer offsets"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "MagOfsX",
      Description = "magnetometer X offset",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "MagOfsY",
      Description = "magnetometer Y offset",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "MagOfsZ",
      Description = "magnetometer Z offset",
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
  }
}
