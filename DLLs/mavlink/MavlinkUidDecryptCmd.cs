// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavlinkUidDecryptCmd
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class MavlinkUidDecryptCmd : UasMessage
{
  private MavParamUidDecryptCmd mCmd;
  private byte[] mKey = new byte[16 /*0x10*/];

  public MavParamUidDecryptCmd Cmd
  {
    get => this.mCmd;
    set => this.mCmd = value;
  }

  public byte[] Key
  {
    get => this.mKey;
    set => this.mKey = value;
  }

  public MavlinkUidDecryptCmd()
  {
    this.mMessageId = (byte) 57;
    this.CrcExtra = (byte) 239;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write((ushort) this.mCmd);
    s.Write(this.mKey);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mCmd = (MavParamUidDecryptCmd) s.ReadUInt16();
    this.mKey = s.ReadBytes(16 /*0x10*/);
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "MavlinkUidDecryptCmd;None."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Cmd",
      Description = "CMD",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Key",
      Description = "KEY",
      NumElements = 1
    });
  }
}
