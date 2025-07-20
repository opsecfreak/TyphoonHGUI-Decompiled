// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasChangeOperatorControlAck
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasChangeOperatorControlAck : UasMessage
{
  private byte mGcsSystemId;
  private byte mControlRequest;
  private byte mAck;

  public byte GcsSystemId
  {
    get => this.mGcsSystemId;
    set
    {
      this.mGcsSystemId = value;
      this.NotifyUpdated();
    }
  }

  public byte ControlRequest
  {
    get => this.mControlRequest;
    set
    {
      this.mControlRequest = value;
      this.NotifyUpdated();
    }
  }

  public byte Ack
  {
    get => this.mAck;
    set
    {
      this.mAck = value;
      this.NotifyUpdated();
    }
  }

  public UasChangeOperatorControlAck()
  {
    this.mMessageId = (byte) 6;
    this.CrcExtra = (byte) 104;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mGcsSystemId);
    s.Write(this.mControlRequest);
    s.Write(this.mAck);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mGcsSystemId = s.ReadByte();
    this.mControlRequest = s.ReadByte();
    this.mAck = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Accept / deny control of this MAV"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "GcsSystemId",
      Description = "ID of the GCS this message ",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ControlRequest",
      Description = "0: request control of this MAV, 1: Release control of this MAV",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Ack",
      Description = "0: ACK, 1: NACK: Wrong passkey, 2: NACK: Unsupported passkey encryption method, 3: NACK: Already under control",
      NumElements = 1
    });
  }
}
