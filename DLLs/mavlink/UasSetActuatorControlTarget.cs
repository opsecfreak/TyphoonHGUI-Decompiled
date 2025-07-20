// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasSetActuatorControlTarget
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasSetActuatorControlTarget : UasMessage
{
  private ulong _timeUsec;
  private byte _groupMlx;
  private byte _targetSystem;
  private byte _targetComponent;
  private float[] _controls = new float[8];

  public ulong TimeUsec
  {
    get => this._timeUsec;
    set
    {
      this._timeUsec = value;
      this.NotifyUpdated();
    }
  }

  public byte GroupMlx
  {
    get => this._groupMlx;
    set
    {
      this._groupMlx = value;
      this.NotifyUpdated();
    }
  }

  public byte TargetSystem
  {
    get => this._targetSystem;
    set
    {
      this._targetSystem = value;
      this.NotifyUpdated();
    }
  }

  public byte TargetComponent
  {
    get => this._targetComponent;
    set
    {
      this._targetComponent = value;
      this.NotifyUpdated();
    }
  }

  public float[] Controls
  {
    get => this._controls;
    set
    {
      this._controls = value;
      this.NotifyUpdated();
    }
  }

  public UasSetActuatorControlTarget()
  {
    this.mMessageId = (byte) 139;
    this.CrcExtra = (byte) 168;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this._timeUsec);
    s.Write(this._groupMlx);
    s.Write(this._targetSystem);
    s.Write(this._targetComponent);
    for (int index = 0; index < 8; ++index)
      s.Write(this._controls[index]);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this._timeUsec = s.ReadUInt64();
    this._groupMlx = s.ReadByte();
    this._targetSystem = s.ReadByte();
    this._targetComponent = s.ReadByte();
    for (int index = 0; index < 8; ++index)
      this._controls[index] = s.ReadSingle();
  }

  protected override void InitMetadata()
  {
  }
}
