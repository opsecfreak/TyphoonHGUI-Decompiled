﻿// Decompiled with JetBrains decompiler
// Type: YuneecLinkNet.EscBLReboot
// Assembly: YuneecLINK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CFB54D17-6788-4CFB-B24E-B7975B945505
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\YuneecLINK.dll

using System.IO;

#nullable disable
namespace YuneecLinkNet;

public class EscBLReboot : UasMessage
{
  private byte mAck;

  public byte Ack
  {
    get => this.mAck;
    set
    {
      this.mAck = value;
      this.NotifyUpdated();
    }
  }

  public EscBLReboot() => this.mMessageId = (byte) 48 /*0x30*/;

  internal override void SerializeBody(BinaryWriter s) => s.Write(this.mAck);

  internal override void DeserializeBody(BinaryReader s)
  {
    int num = (int) s.ReadByte();
    this.mAck = s.ReadByte();
  }

  protected override void InitMetadata()
  {
  }
}
