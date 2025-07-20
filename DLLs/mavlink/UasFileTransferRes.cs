// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasFileTransferRes
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasFileTransferRes : UasMessage
{
  private ulong mTransferUid;
  private byte mResult;

  public ulong TransferUid
  {
    get => this.mTransferUid;
    set
    {
      this.mTransferUid = value;
      this.NotifyUpdated();
    }
  }

  public byte Result
  {
    get => this.mResult;
    set
    {
      this.mResult = value;
      this.NotifyUpdated();
    }
  }

  public UasFileTransferRes()
  {
    this.mMessageId = (byte) 112 /*0x70*/;
    this.CrcExtra = (byte) 124;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTransferUid);
    s.Write(this.mResult);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTransferUid = s.ReadUInt64();
    this.mResult = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "File transfer result"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TransferUid",
      Description = "Unique transfer ID",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Result",
      Description = "0: OK, 1: not permitted, 2: bad path / file name, 3: no space left on device",
      NumElements = 1
    });
  }
}
