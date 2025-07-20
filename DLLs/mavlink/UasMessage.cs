// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasMessage
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasMessage
{
  protected byte mMessageId;
  protected UasMessageMetadata mMetadata;

  public byte CrcExtra { get; protected set; }

  public byte MessageId => this.mMessageId;

  public UasMessageMetadata GetMetadata()
  {
    if (this.mMetadata == null)
      this.InitMetadata();
    return this.mMetadata;
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
}
