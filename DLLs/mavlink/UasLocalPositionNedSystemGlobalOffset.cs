// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasLocalPositionNedSystemGlobalOffset
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasLocalPositionNedSystemGlobalOffset : UasMessage
{
  private uint mTimeBootMs;
  private float mX;
  private float mY;
  private float mZ;
  private float mRoll;
  private float mPitch;
  private float mYaw;

  public uint TimeBootMs
  {
    get => this.mTimeBootMs;
    set
    {
      this.mTimeBootMs = value;
      this.NotifyUpdated();
    }
  }

  public float X
  {
    get => this.mX;
    set
    {
      this.mX = value;
      this.NotifyUpdated();
    }
  }

  public float Y
  {
    get => this.mY;
    set
    {
      this.mY = value;
      this.NotifyUpdated();
    }
  }

  public float Z
  {
    get => this.mZ;
    set
    {
      this.mZ = value;
      this.NotifyUpdated();
    }
  }

  public float Roll
  {
    get => this.mRoll;
    set
    {
      this.mRoll = value;
      this.NotifyUpdated();
    }
  }

  public float Pitch
  {
    get => this.mPitch;
    set
    {
      this.mPitch = value;
      this.NotifyUpdated();
    }
  }

  public float Yaw
  {
    get => this.mYaw;
    set
    {
      this.mYaw = value;
      this.NotifyUpdated();
    }
  }

  public UasLocalPositionNedSystemGlobalOffset()
  {
    this.mMessageId = (byte) 89;
    this.CrcExtra = (byte) 231;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeBootMs);
    s.Write(this.mX);
    s.Write(this.mY);
    s.Write(this.mZ);
    s.Write(this.mRoll);
    s.Write(this.mPitch);
    s.Write(this.mYaw);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeBootMs = s.ReadUInt32();
    this.mX = s.ReadSingle();
    this.mY = s.ReadSingle();
    this.mZ = s.ReadSingle();
    this.mRoll = s.ReadSingle();
    this.mPitch = s.ReadSingle();
    this.mYaw = s.ReadSingle();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "The offset in X, Y, Z and yaw between the LOCAL_POSITION_NED messages of MAV X and the global coordinate frame in NED coordinates. Coordinate frame is right-handed, Z-axis down (aeronautical frame, NED / north-east-down convention)"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeBootMs",
      Description = "Timestamp (milliseconds since system boot)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "X",
      Description = "X Position",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Y",
      Description = "Y Position",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Z",
      Description = "Z Position",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Roll",
      Description = "Roll",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Pitch",
      Description = "Pitch",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Yaw",
      Description = "Yaw",
      NumElements = 1
    });
  }
}
