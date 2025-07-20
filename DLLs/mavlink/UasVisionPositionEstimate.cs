// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasVisionPositionEstimate
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasVisionPositionEstimate : UasMessage
{
  private ulong mUsec;
  private float mX;
  private float mY;
  private float mZ;
  private float mRoll;
  private float mPitch;
  private float mYaw;

  public ulong Usec
  {
    get => this.mUsec;
    set
    {
      this.mUsec = value;
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

  public UasVisionPositionEstimate()
  {
    this.mMessageId = (byte) 102;
    this.CrcExtra = (byte) 158;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mUsec);
    s.Write(this.mX);
    s.Write(this.mY);
    s.Write(this.mZ);
    s.Write(this.mRoll);
    s.Write(this.mPitch);
    s.Write(this.mYaw);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mUsec = s.ReadUInt64();
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
      Description = ""
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Usec",
      Description = "Timestamp (microseconds, synced to UNIX time or since system boot)",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "X",
      Description = "Global X position",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Y",
      Description = "Global Y position",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Z",
      Description = "Global Z position",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Roll",
      Description = "Roll angle in rad",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Pitch",
      Description = "Pitch angle in rad",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Yaw",
      Description = "Yaw angle in rad",
      NumElements = 1
    });
  }
}
