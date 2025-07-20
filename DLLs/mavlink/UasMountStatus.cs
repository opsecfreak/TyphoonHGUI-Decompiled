// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasMountStatus
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasMountStatus : UasMessage
{
  private int mPointingA;
  private int mPointingB;
  private int mPointingC;
  private byte mTargetSystem;
  private byte mTargetComponent;

  public int PointingA
  {
    get => this.mPointingA;
    set
    {
      this.mPointingA = value;
      this.NotifyUpdated();
    }
  }

  public int PointingB
  {
    get => this.mPointingB;
    set
    {
      this.mPointingB = value;
      this.NotifyUpdated();
    }
  }

  public int PointingC
  {
    get => this.mPointingC;
    set
    {
      this.mPointingC = value;
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

  public UasMountStatus()
  {
    this.mMessageId = (byte) 158;
    this.CrcExtra = (byte) 134;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mPointingA);
    s.Write(this.mPointingB);
    s.Write(this.mPointingC);
    s.Write(this.mTargetSystem);
    s.Write(this.mTargetComponent);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mPointingA = s.ReadInt32();
    this.mPointingB = s.ReadInt32();
    this.mPointingC = s.ReadInt32();
    this.mTargetSystem = s.ReadByte();
    this.mTargetComponent = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Message with some status from APM to GCS about camera or antenna mount"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "PointingA",
      Description = "pitch(deg*100) or lat, depending on mount mode",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "PointingB",
      Description = "roll(deg*100) or lon depending on mount mode",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "PointingC",
      Description = "yaw(deg*100) or alt (in cm) depending on mount mode",
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
