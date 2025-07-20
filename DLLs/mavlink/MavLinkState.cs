// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavLinkState
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.Collections.Generic;

#nullable disable
namespace MavLinkNet;

public class MavLinkState
{
  private Dictionary<string, UasMessage> mState = new Dictionary<string, UasMessage>();
  private List<UasMessage> mHeartBeatMessages = new List<UasMessage>();

  public MavLinkState()
  {
    this.mState.Add("Heartbeat", (UasMessage) new UasHeartbeat()
    {
      Type = MavType.Quadrotor,
      Autopilot = MavAutopilot.Ardupilotmega,
      BaseMode = MavModeFlag.AutoEnabled,
      CustomMode = 0U,
      SystemStatus = MavState.Active,
      MavlinkVersion = (byte) 3
    });
    this.mState.Add("SysStatus", (UasMessage) new UasSysStatus()
    {
      Load = (ushort) 500,
      VoltageBattery = (ushort) 11000,
      CurrentBattery = (short) -1,
      BatteryRemaining = (sbyte) -1
    });
    this.mState.Add("LocalPositionNed", (UasMessage) new UasLocalPositionNed());
    this.mState.Add("Attitude", (UasMessage) new UasAttitude());
  }

  public UasMessage Get(string mavlinkObjectName) => this.mState[mavlinkObjectName];

  public List<UasMessage> GetHeartBeatObjects()
  {
    if (this.mHeartBeatMessages.Count == 0)
    {
      this.mHeartBeatMessages.Add(this.Get("Heartbeat"));
      this.mHeartBeatMessages.Add(this.Get("SysStatus"));
      this.mHeartBeatMessages.Add(this.Get("LocalPositionNed"));
      this.mHeartBeatMessages.Add(this.Get("Attitude"));
    }
    return this.mHeartBeatMessages;
  }
}
