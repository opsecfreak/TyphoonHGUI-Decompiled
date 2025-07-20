// Decompiled with JetBrains decompiler
// Type: YuneecLinkNet.EscBLProgram
// Assembly: YuneecLINK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CFB54D17-6788-4CFB-B24E-B7975B945505
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\YuneecLINK.dll

using System.IO;

#nullable disable
namespace YuneecLinkNet;

public class EscBLProgram : UasMessage
{
  private byte mID;
  private byte[] mProgram = new byte[32 /*0x20*/];

  public byte ID
  {
    get => this.mID;
    set
    {
      this.mID = value;
      this.NotifyUpdated();
    }
  }

  public byte[] Program
  {
    get => this.mProgram;
    set
    {
      this.mProgram = value;
      this.NotifyUpdated();
    }
  }

  public EscBLProgram() => this.mMessageId = (byte) 39;

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mID);
    s.Write(this.mProgram);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
  }

  protected override void InitMetadata()
  {
  }
}
