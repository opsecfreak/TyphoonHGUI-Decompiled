// Decompiled with JetBrains decompiler
// Type: YuneecLinkNet.EscBLCRC
// Assembly: YuneecLINK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CFB54D17-6788-4CFB-B24E-B7975B945505
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\YuneecLINK.dll

using System.IO;

#nullable disable
namespace YuneecLinkNet;

public class EscBLCRC : UasMessage
{
  private byte mID;
  private byte[] mAdress = new byte[2];
  private byte mCRC;

  public byte ID
  {
    get => this.mID;
    set
    {
      this.mID = value;
      this.NotifyUpdated();
    }
  }

  public byte[] Adress
  {
    get => this.mAdress;
    set
    {
      this.mAdress = value;
      this.NotifyUpdated();
    }
  }

  public byte CRC
  {
    get => this.mCRC;
    set
    {
      this.mCRC = value;
      this.NotifyUpdated();
    }
  }

  public EscBLCRC() => this.mMessageId = (byte) 41;

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mID);
    s.Write(this.mAdress);
    s.Write(this.mCRC);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
  }

  protected override void InitMetadata()
  {
  }
}
