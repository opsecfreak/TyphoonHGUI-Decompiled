// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasMissionRequestPartialList
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasMissionRequestPartialList : UasMessage
{
  private short mStartIndex;
  private short mEndIndex;
  private byte mTargetSystem;
  private byte mTargetComponent;

  public short StartIndex
  {
    get => this.mStartIndex;
    set
    {
      this.mStartIndex = value;
      this.NotifyUpdated();
    }
  }

  public short EndIndex
  {
    get => this.mEndIndex;
    set
    {
      this.mEndIndex = value;
      this.NotifyUpdated();
    }
  }

  public byte TargetSystem
  {
    get => this.mTargetSystem;
    set
    {
      this.mTargetSystem = value;
      this.NotifyUpdated();
    }
  }

  public byte TargetComponent
  {
    get => this.mTargetComponent;
    set
    {
      this.mTargetComponent = value;
      this.NotifyUpdated();
    }
  }

  public UasMissionRequestPartialList()
  {
    this.mMessageId = (byte) 37;
    this.CrcExtra = (byte) 212;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mStartIndex);
    s.Write(this.mEndIndex);
    s.Write(this.mTargetSystem);
    s.Write(this.mTargetComponent);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mStartIndex = s.ReadInt16();
    this.mEndIndex = s.ReadInt16();
    this.mTargetSystem = s.ReadByte();
    this.mTargetComponent = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Request a partial list of mission items from the system/component. http://qgroundcontrol.org/mavlink/waypoint_protocol. If start and end index are the same, just send one waypoint."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "StartIndex",
      Description = "Start index, 0 by default",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "EndIndex",
      Description = "End index, -1 by default (-1: send list to end). Else a valid index of the list",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TargetSystem",
      Description = "System ID",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TargetComponent",
      Description = "Component ID",
      NumElements = 1
    });
  }
}
