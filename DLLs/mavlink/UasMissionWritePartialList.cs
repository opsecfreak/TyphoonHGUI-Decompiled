// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasMissionWritePartialList
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasMissionWritePartialList : UasMessage
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

  public UasMissionWritePartialList()
  {
    this.mMessageId = (byte) 38;
    this.CrcExtra = (byte) 9;
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
      Description = "This message is sent to the MAV to write a partial list. If start index == end index, only one item will be transmitted / updated. If the start index is NOT 0 and above the current list size, this request should be REJECTED!"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "StartIndex",
      Description = "Start index, 0 by default and smaller / equal to the largest index of the current onboard list.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "EndIndex",
      Description = "End index, equal or greater than start index.",
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
