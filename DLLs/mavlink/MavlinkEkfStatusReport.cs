// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavlinkEkfStatusReport
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class MavlinkEkfStatusReport : UasMessage
{
  private float _velocity;
  private float _pos_horiz;
  private float _pos_vert;
  private float _compass;
  private float _terrain_alt;
  private ushort _flags;

  public float Velocity
  {
    get => this._velocity;
    set => this._velocity = value;
  }

  public float Pos_horiz
  {
    get => this._pos_horiz;
    set => this._pos_horiz = value;
  }

  public float Pos_vert
  {
    get => this._pos_vert;
    set => this._pos_vert = value;
  }

  public float Compass
  {
    get => this._compass;
    set => this._compass = value;
  }

  public float Terrain_alt
  {
    get => this._terrain_alt;
    set => this._terrain_alt = value;
  }

  public ushort Flags
  {
    get => this._flags;
    set => this._flags = value;
  }

  public MavlinkEkfStatusReport()
  {
    this.mMessageId = (byte) 193;
    this.CrcExtra = (byte) 71;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
  }

  internal override void DeserializeBody(BinaryReader s)
  {
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "MavlinkEkfStatusReport;MavlinkEkfStatusReport"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Velocity",
      Description = "Velocity variance",
      Value = this._velocity.ToString(),
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Pos_horiz",
      Description = "Horizontal Position variance",
      Value = this._pos_horiz.ToString(),
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Pos_vert",
      Description = "Vertical Position variance",
      Value = this._pos_vert.ToString(),
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Compass",
      Description = "Compass variance",
      Value = this._compass.ToString(),
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Terrain_alt",
      Description = "Terrain Altitude variance",
      Value = this._terrain_alt.ToString(),
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Flags",
      Description = "Flags",
      Value = this._flags.ToString(),
      NumElements = 1
    });
  }
}
