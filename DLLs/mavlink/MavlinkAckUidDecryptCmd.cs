// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavlinkAckUidDecryptCmd
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class MavlinkAckUidDecryptCmd : UasMessage
{
  private bool mAll;
  private bool mCmd;
  private bool mKey;

  public bool All
  {
    get => this.mAll;
    set => this.mAll = value;
  }

  public bool Key
  {
    get => this.mKey;
    set => this.mKey = value;
  }

  public bool MCmd
  {
    get => this.mCmd;
    set => this.mCmd = value;
  }

  public MavlinkAckUidDecryptCmd()
  {
    this.mMessageId = (byte) 58;
    this.CrcExtra = (byte) 238;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mAll);
    s.Write(this.mCmd);
    s.Write(this.mKey);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mAll = s.ReadBoolean();
    this.mCmd = s.ReadBoolean();
    this.mKey = s.ReadBoolean();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "MavlinkAckUidDecryptCmd;Ack for MavlinkUidDecryptCmd."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "All",
      Description = "All is OK?",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Cmd",
      Description = "Cmd is OK?",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Key",
      Description = "Key is OK?",
      NumElements = 1
    });
  }
}
