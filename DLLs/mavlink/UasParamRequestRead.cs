// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasParamRequestRead
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasParamRequestRead : UasMessage
{
  private short mParamIndex;
  private byte mTargetSystem;
  private byte mTargetComponent;
  private char[] mParamId = new char[16 /*0x10*/];

  public short ParamIndex
  {
    get => this.mParamIndex;
    set
    {
      this.mParamIndex = value;
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

  public UasParamRequestRead()
  {
    this.mMessageId = (byte) 20;
    this.CrcExtra = (byte) 214;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mParamIndex);
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
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mParamIndex = s.ReadInt16();
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
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Request to read the onboard parameter with the param_id string id. Onboard parameters are stored as key[const char*] -> value[float]. This allows to send a parameter to any other component (such as the GCS) without the need of previous knowledge of possible parameter names. Thus the same GCS can store different parameters for different autopilots. See also http://qgroundcontrol.org/parameter_interface for a full documentation of QGroundControl and IMU code."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ParamIndex",
      Description = "Parameter index. Send -1 to use the param ID field as identifier (else the param id will be ignored)",
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
  }
}
