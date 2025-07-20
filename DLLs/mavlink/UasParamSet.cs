// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasParamSet
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasParamSet : UasMessage
{
  private float mParamValue;
  private byte mTargetSystem;
  private byte mTargetComponent;
  private char[] mParamId = new char[16 /*0x10*/];
  private MavParamType mParamType;

  public float ParamValue
  {
    get => this.mParamValue;
    set
    {
      this.mParamValue = value;
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

  public char[] ParamId
  {
    get => this.mParamId;
    set
    {
      this.mParamId = value;
      this.NotifyUpdated();
    }
  }

  public MavParamType ParamType
  {
    get => this.mParamType;
    set
    {
      this.mParamType = value;
      this.NotifyUpdated();
    }
  }

  public UasParamSet()
  {
    this.mMessageId = (byte) 23;
    this.CrcExtra = (byte) 168;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mParamValue);
    s.Write(this.mTargetSystem);
    s.Write(this.mTargetComponent);
    s.Write(this.mParamId[0]);
    s.Write(this.mParamId[1]);
    s.Write(this.mParamId[2]);
    s.Write(this.mParamId[3]);
    s.Write(this.mParamId[4]);
    s.Write(this.mParamId[5]);
    s.Write(this.mParamId[6]);
    s.Write(this.mParamId[7]);
    s.Write(this.mParamId[8]);
    s.Write(this.mParamId[9]);
    s.Write(this.mParamId[10]);
    s.Write(this.mParamId[11]);
    s.Write(this.mParamId[12]);
    s.Write(this.mParamId[13]);
    s.Write(this.mParamId[14]);
    s.Write(this.mParamId[15]);
    s.Write((byte) this.mParamType);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mParamValue = s.ReadSingle();
    this.mTargetSystem = s.ReadByte();
    this.mTargetComponent = s.ReadByte();
    this.mParamId[0] = s.ReadChar();
    this.mParamId[1] = s.ReadChar();
    this.mParamId[2] = s.ReadChar();
    this.mParamId[3] = s.ReadChar();
    this.mParamId[4] = s.ReadChar();
    this.mParamId[5] = s.ReadChar();
    this.mParamId[6] = s.ReadChar();
    this.mParamId[7] = s.ReadChar();
    this.mParamId[8] = s.ReadChar();
    this.mParamId[9] = s.ReadChar();
    this.mParamId[10] = s.ReadChar();
    this.mParamId[11] = s.ReadChar();
    this.mParamId[12] = s.ReadChar();
    this.mParamId[13] = s.ReadChar();
    this.mParamId[14] = s.ReadChar();
    this.mParamId[15] = s.ReadChar();
    this.mParamType = (MavParamType) s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Set a parameter value TEMPORARILY to RAM. It will be reset to default on system reboot. Send the ACTION MAV_ACTION_STORAGE_WRITE to PERMANENTLY write the RAM contents to EEPROM. IMPORTANT: The receiving component should acknowledge the new parameter value by sending a param_value message to all communication partners. This will also ensure that multiple GCS all have an up-to-date list of all parameters. If the sending GCS did not receive a PARAM_VALUE message within its timeout time, it should re-send the PARAM_SET message."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ParamValue",
      Description = "Onboard parameter value",
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
      Name = "ParamId",
      Description = "Onboard parameter id, terminated by NULL if the length is less than 16 human-readable chars and WITHOUT null termination (NULL) byte if the length is exactly 16 chars - applications have to provide 16+1 bytes storage if the ID is stored as string",
      NumElements = 16 /*0x10*/
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ParamType",
      Description = "Onboard parameter type: see the MAV_PARAM_TYPE enum for supported data types.",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("MavParamType")
    });
  }
}
