// Decompiled with JetBrains decompiler
// Type: YuneecLinkNet.YuneecGenericTransport
// Assembly: YuneecLINK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CFB54D17-6788-4CFB-B24E-B7975B945505
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\YuneecLINK.dll

using System;

#nullable disable
namespace YuneecLinkNet;

public abstract class YuneecGenericTransport : IDisposable
{
  public byte MavlinkSystemId = 200;
  public byte MavlinkComponentId = 1;

  public event PacketReceivedDelegate OnPacketReceived;

  public event EventHandler OnReceptionEnded;

  public abstract void Initialize();

  public abstract void Dispose();

  public abstract void SendMessage(UasMessage msg);

  protected void HandlePacketReceived(object sender, YuneecLinkPacket e)
  {
    if (this.OnPacketReceived == null)
      return;
    this.OnPacketReceived(sender, e);
  }

  protected void HandleReceptionEnded(object sender)
  {
    if (this.OnReceptionEnded == null)
      return;
    this.OnReceptionEnded(sender, EventArgs.Empty);
  }
}
