// Decompiled with JetBrains decompiler
// Type: YuneecLinkNet.EscFAILED
// Assembly: YuneecLINK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CFB54D17-6788-4CFB-B24E-B7975B945505
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\YuneecLINK.dll

using System.IO;

#nullable disable
namespace YuneecLinkNet;

public class EscFAILED : UasMessage
{
  private byte mID;

  public byte ID
  {
    get => this.mID;
    set
    {
      this.mID = value;
      this.NotifyUpdated();
    }
  }

  public EscFAILED() => this.mMessageId = (byte) 17;

  internal override void SerializeBody(BinaryWriter s) => s.Write(this.mID);

  internal override void DeserializeBody(BinaryReader s)
  {
    int num = (int) s.ReadByte();
    this.mID = s.ReadByte();
  }

  protected override void InitMetadata()
  {
  }
}
