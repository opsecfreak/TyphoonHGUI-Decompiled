// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasNamedValueFloat
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasNamedValueFloat : UasMessage
{
  private uint mTimeBootMs;
  private float mValue;
  private char[] mName = new char[10];

  public uint TimeBootMs
  {
    get => this.mTimeBootMs;
    set
    {
      this.mTimeBootMs = value;
      this.NotifyUpdated();
    }
  }

  public float Value
  {
    get => this.mValue;
    set
    {
      this.mValue = value;
      this.NotifyUpdated();
    }
  }

  public char[] Name
  {
    get => this.mName;
    set
    {
      this.mName = value;
      this.NotifyUpdated();
    }
  }

  public UasNamedValueFloat()
  {
    this.mMessageId = (byte) 251;
    this.CrcExtra = (byte) 170;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeBootMs);
    s.Write(this.mValue);
    s.Write(this.mName[0]);
    s.Write(this.mName[1]);
    s.Write(this.mName[2]);
    s.Write(this.mName[3]);
    s.Write(this.mName[4]);
    s.Write(this.mName[5]);
    s.Write(this.mName[6]);
    s.Write(this.mName[7]);
    s.Write(this.mName[8]);
    s.Write(this.mName[9]);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeBootMs = s.ReadUInt32();
    this.mValue = s.ReadSingle();
    this.mName[0] = s.ReadChar();
    this.mName[1] = s.ReadChar();
    this.mName[2] = s.ReadChar();
    this.mName[3] = s.ReadChar();
    this.mName[4] = s.ReadChar();
    this.mName[5] = s.ReadChar();
    this.mName[6] = s.ReadChar();
    this.mName[7] = s.ReadChar();
    this.mName[8] = s.ReadChar();
    this.mName[9] = s.ReadChar();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Send a key-value pair as float. The use of this message is discouraged for normal packets, but a quite efficient way for testing new messages and getting experimental debug output."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeBootMs",
      Description = "Timestamp (milliseconds since system boot)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Value",
      Description = "Floating point value",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Name",
      Description = "Name of the debug variable",
      NumElements = 10
    });
  }
}
