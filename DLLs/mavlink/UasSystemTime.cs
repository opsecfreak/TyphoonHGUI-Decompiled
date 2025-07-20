// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasSystemTime
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasSystemTime : UasMessage
{
  private ulong mTimeUnixUsec;
  private uint mTimeBootMs;

  public ulong TimeUnixUsec
  {
    get => this.mTimeUnixUsec;
    set
    {
      this.mTimeUnixUsec = value;
      this.NotifyUpdated();
    }
  }

  public uint TimeBootMs
  {
    get => this.mTimeBootMs;
    set
    {
      this.mTimeBootMs = value;
      this.NotifyUpdated();
    }
  }

  public UasSystemTime()
  {
    this.mMessageId = (byte) 2;
    this.CrcExtra = (byte) 137;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTimeUnixUsec);
    s.Write(this.mTimeBootMs);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTimeUnixUsec = s.ReadUInt64();
    this.mTimeBootMs = s.ReadUInt32();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "SystemTime;The system time is the time of the master clock, typically the computer clock of the main onboard computer."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeUnixUsec",
      Value = this.TimeUnixUsec.ToString(),
      Description = "Timestamp of the master clock in microseconds since UNIX epoch.",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TimeBootMs",
      Value = this.TimeBootMs.ToString(),
      Description = "Timestamp of the component clock since boot time in milliseconds.",
      NumElements = 1
    });
  }
}
