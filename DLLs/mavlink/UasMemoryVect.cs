// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasMemoryVect
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasMemoryVect : UasMessage
{
  private ushort mAddress;
  private byte mVer;
  private byte mType;
  private sbyte[] mValue = new sbyte[32 /*0x20*/];

  public ushort Address
  {
    get => this.mAddress;
    set
    {
      this.mAddress = value;
      this.NotifyUpdated();
    }
  }

  public byte Ver
  {
    get => this.mVer;
    set
    {
      this.mVer = value;
      this.NotifyUpdated();
    }
  }

  public byte Type
  {
    get => this.mType;
    set
    {
      this.mType = value;
      this.NotifyUpdated();
    }
  }

  public sbyte[] Value
  {
    get => this.mValue;
    set
    {
      this.mValue = value;
      this.NotifyUpdated();
    }
  }

  public UasMemoryVect()
  {
    this.mMessageId = (byte) 249;
    this.CrcExtra = (byte) 204;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mAddress);
    s.Write(this.mVer);
    s.Write(this.mType);
    s.Write(this.mValue[0]);
    s.Write(this.mValue[1]);
    s.Write(this.mValue[2]);
    s.Write(this.mValue[3]);
    s.Write(this.mValue[4]);
    s.Write(this.mValue[5]);
    s.Write(this.mValue[6]);
    s.Write(this.mValue[7]);
    s.Write(this.mValue[8]);
    s.Write(this.mValue[9]);
    s.Write(this.mValue[10]);
    s.Write(this.mValue[11]);
    s.Write(this.mValue[12]);
    s.Write(this.mValue[13]);
    s.Write(this.mValue[14]);
    s.Write(this.mValue[15]);
    s.Write(this.mValue[16 /*0x10*/]);
    s.Write(this.mValue[17]);
    s.Write(this.mValue[18]);
    s.Write(this.mValue[19]);
    s.Write(this.mValue[20]);
    s.Write(this.mValue[21]);
    s.Write(this.mValue[22]);
    s.Write(this.mValue[23]);
    s.Write(this.mValue[24]);
    s.Write(this.mValue[25]);
    s.Write(this.mValue[26]);
    s.Write(this.mValue[27]);
    s.Write(this.mValue[28]);
    s.Write(this.mValue[29]);
    s.Write(this.mValue[30]);
    s.Write(this.mValue[31 /*0x1F*/]);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mAddress = s.ReadUInt16();
    this.mVer = s.ReadByte();
    this.mType = s.ReadByte();
    this.mValue[0] = s.ReadSByte();
    this.mValue[1] = s.ReadSByte();
    this.mValue[2] = s.ReadSByte();
    this.mValue[3] = s.ReadSByte();
    this.mValue[4] = s.ReadSByte();
    this.mValue[5] = s.ReadSByte();
    this.mValue[6] = s.ReadSByte();
    this.mValue[7] = s.ReadSByte();
    this.mValue[8] = s.ReadSByte();
    this.mValue[9] = s.ReadSByte();
    this.mValue[10] = s.ReadSByte();
    this.mValue[11] = s.ReadSByte();
    this.mValue[12] = s.ReadSByte();
    this.mValue[13] = s.ReadSByte();
    this.mValue[14] = s.ReadSByte();
    this.mValue[15] = s.ReadSByte();
    this.mValue[16 /*0x10*/] = s.ReadSByte();
    this.mValue[17] = s.ReadSByte();
    this.mValue[18] = s.ReadSByte();
    this.mValue[19] = s.ReadSByte();
    this.mValue[20] = s.ReadSByte();
    this.mValue[21] = s.ReadSByte();
    this.mValue[22] = s.ReadSByte();
    this.mValue[23] = s.ReadSByte();
    this.mValue[24] = s.ReadSByte();
    this.mValue[25] = s.ReadSByte();
    this.mValue[26] = s.ReadSByte();
    this.mValue[27] = s.ReadSByte();
    this.mValue[28] = s.ReadSByte();
    this.mValue[29] = s.ReadSByte();
    this.mValue[30] = s.ReadSByte();
    this.mValue[31 /*0x1F*/] = s.ReadSByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Send raw controller memory. The use of this message is discouraged for normal packets, but a quite efficient way for testing new messages and getting experimental debug output."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Address",
      Description = "Starting address of the debug variables",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Ver",
      Description = "Version code of the type variable. 0=unknown, type ignored and assumed int16_t. 1=as below",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Type",
      Description = "Type code of the memory variables. for ver = 1: 0=16 x int16_t, 1=16 x uint16_t, 2=16 x Q15, 3=16 x 1Q14",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Value",
      Description = "Memory contents at specified address",
      NumElements = 32 /*0x20*/
    });
  }
}
