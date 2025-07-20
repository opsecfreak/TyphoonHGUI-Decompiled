// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasChangeOperatorControl
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasChangeOperatorControl : UasMessage
{
  private byte mTargetSystem;
  private byte mControlRequest;
  private byte mVersion;
  private char[] mPasskey = new char[25];

  public byte TargetSystem
  {
    get => this.mTargetSystem;
    set
    {
      this.mTargetSystem = value;
      this.NotifyUpdated();
    }
  }

  public byte ControlRequest
  {
    get => this.mControlRequest;
    set
    {
      this.mControlRequest = value;
      this.NotifyUpdated();
    }
  }

  public byte Version
  {
    get => this.mVersion;
    set
    {
      this.mVersion = value;
      this.NotifyUpdated();
    }
  }

  public char[] Passkey
  {
    get => this.mPasskey;
    set
    {
      this.mPasskey = value;
      this.NotifyUpdated();
    }
  }

  public UasChangeOperatorControl()
  {
    this.mMessageId = (byte) 5;
    this.CrcExtra = (byte) 217;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTargetSystem);
    s.Write(this.mControlRequest);
    s.Write(this.mVersion);
    s.Write(this.mPasskey[0]);
    s.Write(this.mPasskey[1]);
    s.Write(this.mPasskey[2]);
    s.Write(this.mPasskey[3]);
    s.Write(this.mPasskey[4]);
    s.Write(this.mPasskey[5]);
    s.Write(this.mPasskey[6]);
    s.Write(this.mPasskey[7]);
    s.Write(this.mPasskey[8]);
    s.Write(this.mPasskey[9]);
    s.Write(this.mPasskey[10]);
    s.Write(this.mPasskey[11]);
    s.Write(this.mPasskey[12]);
    s.Write(this.mPasskey[13]);
    s.Write(this.mPasskey[14]);
    s.Write(this.mPasskey[15]);
    s.Write(this.mPasskey[16 /*0x10*/]);
    s.Write(this.mPasskey[17]);
    s.Write(this.mPasskey[18]);
    s.Write(this.mPasskey[19]);
    s.Write(this.mPasskey[20]);
    s.Write(this.mPasskey[21]);
    s.Write(this.mPasskey[22]);
    s.Write(this.mPasskey[23]);
    s.Write(this.mPasskey[24]);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTargetSystem = s.ReadByte();
    this.mControlRequest = s.ReadByte();
    this.mVersion = s.ReadByte();
    this.mPasskey[0] = s.ReadChar();
    this.mPasskey[1] = s.ReadChar();
    this.mPasskey[2] = s.ReadChar();
    this.mPasskey[3] = s.ReadChar();
    this.mPasskey[4] = s.ReadChar();
    this.mPasskey[5] = s.ReadChar();
    this.mPasskey[6] = s.ReadChar();
    this.mPasskey[7] = s.ReadChar();
    this.mPasskey[8] = s.ReadChar();
    this.mPasskey[9] = s.ReadChar();
    this.mPasskey[10] = s.ReadChar();
    this.mPasskey[11] = s.ReadChar();
    this.mPasskey[12] = s.ReadChar();
    this.mPasskey[13] = s.ReadChar();
    this.mPasskey[14] = s.ReadChar();
    this.mPasskey[15] = s.ReadChar();
    this.mPasskey[16 /*0x10*/] = s.ReadChar();
    this.mPasskey[17] = s.ReadChar();
    this.mPasskey[18] = s.ReadChar();
    this.mPasskey[19] = s.ReadChar();
    this.mPasskey[20] = s.ReadChar();
    this.mPasskey[21] = s.ReadChar();
    this.mPasskey[22] = s.ReadChar();
    this.mPasskey[23] = s.ReadChar();
    this.mPasskey[24] = s.ReadChar();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Request to control this MAV"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TargetSystem",
      Description = "System the GCS requests control for",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ControlRequest",
      Description = "0: request control of this MAV, 1: Release control of this MAV",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Version",
      Description = "0: key as plaintext, 1-255: future, different hashing/encryption variants. The GCS should in general use the safest mode possible initially and then gradually move down the encryption level if it gets a NACK message indicating an encryption mismatch.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Passkey",
      Description = "Password / Key, depending on version plaintext or encrypted. 25 or less characters, NULL terminated. The characters may involve A-Z, a-z, 0-9, and '!?,.-'",
      NumElements = 25
    });
  }
}
