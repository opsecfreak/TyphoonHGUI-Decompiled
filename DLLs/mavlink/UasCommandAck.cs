// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasCommandAck
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasCommandAck : UasMessage
{
  private MavCmd mCommand;
  private MavResult mResult;

  public MavCmd Command
  {
    get => this.mCommand;
    set
    {
      this.mCommand = value;
      this.NotifyUpdated();
    }
  }

  public MavResult Result
  {
    get => this.mResult;
    set
    {
      this.mResult = value;
      this.NotifyUpdated();
    }
  }

  public UasCommandAck()
  {
    this.mMessageId = (byte) 77;
    this.CrcExtra = (byte) 143;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write((ushort) this.mCommand);
    s.Write((byte) this.mResult);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mCommand = (MavCmd) s.ReadUInt16();
    this.mResult = (MavResult) s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Report status of a command. Includes feedback wether the command was executed."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Command",
      Description = "Command ID, as defined by MAV_CMD enum.",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("MavCmd")
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Result",
      Description = "See MAV_RESULT enum",
      NumElements = 1,
      EnumMetadata = UasSummary.GetEnumMetadata("MavResult")
    });
  }
}
