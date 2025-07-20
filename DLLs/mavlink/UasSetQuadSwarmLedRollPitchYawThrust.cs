// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasSetQuadSwarmLedRollPitchYawThrust
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasSetQuadSwarmLedRollPitchYawThrust : UasMessage
{
  private short[] mRoll = new short[4];
  private short[] mPitch = new short[4];
  private short[] mYaw = new short[4];
  private ushort[] mThrust = new ushort[4];
  private byte mGroup;
  private byte mMode;
  private byte[] mLedRed = new byte[4];
  private byte[] mLedBlue = new byte[4];
  private byte[] mLedGreen = new byte[4];

  public short[] Roll
  {
    get => this.mRoll;
    set
    {
      this.mRoll = value;
      this.NotifyUpdated();
    }
  }

  public short[] Pitch
  {
    get => this.mPitch;
    set
    {
      this.mPitch = value;
      this.NotifyUpdated();
    }
  }

  public short[] Yaw
  {
    get => this.mYaw;
    set
    {
      this.mYaw = value;
      this.NotifyUpdated();
    }
  }

  public ushort[] Thrust
  {
    get => this.mThrust;
    set
    {
      this.mThrust = value;
      this.NotifyUpdated();
    }
  }

  public byte Group
  {
    get => this.mGroup;
    set
    {
      this.mGroup = value;
      this.NotifyUpdated();
    }
  }

  public byte Mode
  {
    get => this.mMode;
    set
    {
      this.mMode = value;
      this.NotifyUpdated();
    }
  }

  public byte[] LedRed
  {
    get => this.mLedRed;
    set
    {
      this.mLedRed = value;
      this.NotifyUpdated();
    }
  }

  public byte[] LedBlue
  {
    get => this.mLedBlue;
    set
    {
      this.mLedBlue = value;
      this.NotifyUpdated();
    }
  }

  public byte[] LedGreen
  {
    get => this.mLedGreen;
    set
    {
      this.mLedGreen = value;
      this.NotifyUpdated();
    }
  }

  public UasSetQuadSwarmLedRollPitchYawThrust()
  {
    this.mMessageId = (byte) 63 /*0x3F*/;
    this.CrcExtra = (byte) 130;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mRoll[0]);
    s.Write(this.mRoll[1]);
    s.Write(this.mRoll[2]);
    s.Write(this.mRoll[3]);
    s.Write(this.mPitch[0]);
    s.Write(this.mPitch[1]);
    s.Write(this.mPitch[2]);
    s.Write(this.mPitch[3]);
    s.Write(this.mYaw[0]);
    s.Write(this.mYaw[1]);
    s.Write(this.mYaw[2]);
    s.Write(this.mYaw[3]);
    s.Write(this.mThrust[0]);
    s.Write(this.mThrust[1]);
    s.Write(this.mThrust[2]);
    s.Write(this.mThrust[3]);
    s.Write(this.mGroup);
    s.Write(this.mMode);
    s.Write(this.mLedRed[0]);
    s.Write(this.mLedRed[1]);
    s.Write(this.mLedRed[2]);
    s.Write(this.mLedRed[3]);
    s.Write(this.mLedBlue[0]);
    s.Write(this.mLedBlue[1]);
    s.Write(this.mLedBlue[2]);
    s.Write(this.mLedBlue[3]);
    s.Write(this.mLedGreen[0]);
    s.Write(this.mLedGreen[1]);
    s.Write(this.mLedGreen[2]);
    s.Write(this.mLedGreen[3]);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mRoll[0] = s.ReadInt16();
    this.mRoll[1] = s.ReadInt16();
    this.mRoll[2] = s.ReadInt16();
    this.mRoll[3] = s.ReadInt16();
    this.mPitch[0] = s.ReadInt16();
    this.mPitch[1] = s.ReadInt16();
    this.mPitch[2] = s.ReadInt16();
    this.mPitch[3] = s.ReadInt16();
    this.mYaw[0] = s.ReadInt16();
    this.mYaw[1] = s.ReadInt16();
    this.mYaw[2] = s.ReadInt16();
    this.mYaw[3] = s.ReadInt16();
    this.mThrust[0] = s.ReadUInt16();
    this.mThrust[1] = s.ReadUInt16();
    this.mThrust[2] = s.ReadUInt16();
    this.mThrust[3] = s.ReadUInt16();
    this.mGroup = s.ReadByte();
    this.mMode = s.ReadByte();
    this.mLedRed[0] = s.ReadByte();
    this.mLedRed[1] = s.ReadByte();
    this.mLedRed[2] = s.ReadByte();
    this.mLedRed[3] = s.ReadByte();
    this.mLedBlue[0] = s.ReadByte();
    this.mLedBlue[1] = s.ReadByte();
    this.mLedBlue[2] = s.ReadByte();
    this.mLedBlue[3] = s.ReadByte();
    this.mLedGreen[0] = s.ReadByte();
    this.mLedGreen[1] = s.ReadByte();
    this.mLedGreen[2] = s.ReadByte();
    this.mLedGreen[3] = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Setpoint for up to four quadrotors in a group / wing"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Roll",
      Description = "Desired roll angle in radians +-PI (+-INT16_MAX)",
      NumElements = 4
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Pitch",
      Description = "Desired pitch angle in radians +-PI (+-INT16_MAX)",
      NumElements = 4
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Yaw",
      Description = "Desired yaw angle in radians, scaled to int16 +-PI (+-INT16_MAX)",
      NumElements = 4
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Thrust",
      Description = "Collective thrust, scaled to uint16 (0..UINT16_MAX)",
      NumElements = 4
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Group",
      Description = "ID of the quadrotor group (0 - 255, up to 256 groups supported)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Mode",
      Description = "ID of the flight mode (0 - 255, up to 256 modes supported)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "LedRed",
      Description = "RGB red channel (0-255)",
      NumElements = 4
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "LedBlue",
      Description = "RGB green channel (0-255)",
      NumElements = 4
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "LedGreen",
      Description = "RGB blue channel (0-255)",
      NumElements = 4
    });
  }
}
