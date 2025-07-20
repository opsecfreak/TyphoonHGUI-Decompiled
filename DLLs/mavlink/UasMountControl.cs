// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasMountControl
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasMountControl : UasMessage
{
  private int mInputA;
  private int mInputB;
  private int mInputC;
  private byte mTargetSystem;
  private byte mTargetComponent;
  private byte mSavePosition;

  public int InputA
  {
    get => this.mInputA;
    set
    {
      this.mInputA = value;
      this.NotifyUpdated();
    }
  }

  public int InputB
  {
    get => this.mInputB;
    set
    {
      this.mInputB = value;
      this.NotifyUpdated();
    }
  }

  public int InputC
  {
    get => this.mInputC;
    set
    {
      this.mInputC = value;
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

  public byte SavePosition
  {
    get => this.mSavePosition;
    set
    {
      this.mSavePosition = value;
      this.NotifyUpdated();
    }
  }

  public UasMountControl()
  {
    this.mMessageId = (byte) 157;
    this.CrcExtra = (byte) 21;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mInputA);
    s.Write(this.mInputB);
    s.Write(this.mInputC);
    s.Write(this.mTargetSystem);
    s.Write(this.mTargetComponent);
    s.Write(this.mSavePosition);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mInputA = s.ReadInt32();
    this.mInputB = s.ReadInt32();
    this.mInputC = s.ReadInt32();
    this.mTargetSystem = s.ReadByte();
    this.mTargetComponent = s.ReadByte();
    this.mSavePosition = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Message to control a camera mount, directional antenna, etc."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "InputA",
      Description = "pitch(deg*100) or lat, depending on mount mode",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "InputB",
      Description = "roll(deg*100) or lon depending on mount mode",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "InputC",
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
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "SavePosition",
      Description = "if '1' it will save current trimmed position on EEPROM (just valid for NEUTRAL and LANDING)",
      NumElements = 1
    });
  }
}
