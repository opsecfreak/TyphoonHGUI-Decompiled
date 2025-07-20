// Decompiled with JetBrains decompiler
// Type: YuneecLinkNet.UasMessage
// Assembly: YuneecLINK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CFB54D17-6788-4CFB-B24E-B7975B945505
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\YuneecLINK.dll

using System.ComponentModel;
using System.IO;

#nullable disable
namespace YuneecLinkNet;

public class UasMessage : INotifyPropertyChanged
{
  protected byte mMessageId;
  protected UasMessageMetadata mMetadata;

  public byte MessageId => this.mMessageId;

  public UasMessageMetadata GetMetadata()
  {
    if (this.mMetadata == null)
      this.InitMetadata();
    return this.mMetadata;
  }

  protected void NotifyUpdated(string value)
  {
    if (this.PropertyChanged == null)
      return;
    this.PropertyChanged((object) this, new PropertyChangedEventArgs(value));
  }

  protected void NotifyUpdated()
  {
  }

  internal virtual void SerializeBody(BinaryWriter s)
  {
  }

  internal virtual void DeserializeBody(BinaryReader stream)
  {
  }

  protected virtual void InitMetadata()
  {
  }

  public event PropertyChangedEventHandler PropertyChanged;
}
