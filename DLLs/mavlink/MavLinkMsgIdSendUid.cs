// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavLinkMsgIdSendUid
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class MavLinkMsgIdSendUid : UasMessage
{
  private uint[] mUID = new uint[3];

  public uint[] UID
  {
    set
    {
      this.mUID = value;
      this.NotifyUpdated();
    }
    get => this.mUID;
  }

  public MavLinkMsgIdSendUid()
  {
    this.mMessageId = (byte) 56;
    this.CrcExtra = (byte) 7;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    for (int index = 0; index < 3; ++index)
      s.Write(this.mUID[index]);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    for (int index = 0; index < 3; ++index)
      this.mUID[index] = s.ReadUInt32();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "MavLinkMsgIdSendUid;Get UID."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "UID[0]",
      Description = "UID0",
      Value = this.mUID[0].ToString(),
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "UID[1]",
      Description = "UID1",
      Value = this.mUID[1].ToString(),
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "UID[2]",
      Description = "UID2",
      Value = this.mUID[2].ToString(),
      NumElements = 1
    });
  }
}
