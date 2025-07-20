// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavLinkGenericTransport
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System;

#nullable disable
namespace MavLinkNet;

public abstract class MavLinkGenericTransport : IDisposable
{
  public byte MavlinkSystemId = 200;
  public byte MavlinkComponentId = 1;
  public bool mIsActive = true;
  public MavLinkState UavState = new MavLinkState();

  public event PacketReceivedDelegate OnPacketReceived;

  public event EventHandler OnReceptionEnded;

  public abstract void Initialize();

  public abstract void Dispose();

  public abstract void SendMessage(UasMessage msg);

  public abstract void BeginHeartBeatLoop();

  protected void HandlePacketReceived(object sender, MavLinkPacket e)
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
