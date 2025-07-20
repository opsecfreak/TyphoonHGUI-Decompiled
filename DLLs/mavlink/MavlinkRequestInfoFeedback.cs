// Decompiled with JetBrains decompiler
// Type: MavLinkNet.MavlinkRequestInfoFeedback
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class MavlinkRequestInfoFeedback : UasMessage
{
  private ushort mSoftwareVersion;
  private ushort mHardwareVersion;
  private ushort mSoftwareYear;
  private char[] mProductName = new char[16 /*0x10*/];
  private MavResquestInfoSoftwareType mSoftwareType;
  private byte mSoftwareMonth;
  private byte mSoftwareDay;

  public ushort SoftwareVersion
  {
    get => this.mSoftwareVersion;
    set
    {
      this.mSoftwareVersion = value;
      this.NotifyUpdated();
    }
  }

  public ushort HardwareVersion
  {
    get => this.mHardwareVersion;
    set
    {
      this.mHardwareVersion = value;
      this.NotifyUpdated();
    }
  }

  public ushort SoftwareYear
  {
    get => this.mSoftwareYear;
    set
    {
      this.mSoftwareYear = value;
      this.NotifyUpdated();
    }
  }

  public char[] ProductName
  {
    get => this.mProductName;
    set
    {
      this.mProductName = value;
      this.NotifyUpdated();
    }
  }

  public MavResquestInfoSoftwareType SoftwareType
  {
    get => this.mSoftwareType;
    set
    {
      this.mSoftwareType = value;
      this.NotifyUpdated();
    }
  }

  public byte SoftwareMonth
  {
    get => this.mSoftwareMonth;
    set
    {
      this.mSoftwareMonth = value;
      this.NotifyUpdated();
    }
  }

  public byte SoftwareDay
  {
    get => this.mSoftwareDay;
    set
    {
      this.mSoftwareDay = value;
      this.NotifyUpdated();
    }
  }

  public MavlinkRequestInfoFeedback()
  {
    this.mMessageId = (byte) 52;
    this.CrcExtra = (byte) 218;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mSoftwareVersion);
    s.Write(this.mHardwareVersion);
    s.Write(this.mSoftwareYear);
    for (int index = 0; index < 16 /*0x10*/; ++index)
      s.Write(this.mProductName[index]);
    s.Write((byte) this.mSoftwareType);
    s.Write(this.mSoftwareMonth);
    s.Write(this.mSoftwareDay);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mSoftwareVersion = s.ReadUInt16();
    this.mHardwareVersion = s.ReadUInt16();
    this.mSoftwareYear = s.ReadUInt16();
    this.mProductName = s.ReadChars(16 /*0x10*/);
    this.mSoftwareType = (MavResquestInfoSoftwareType) s.ReadByte();
    this.mSoftwareMonth = s.ReadByte();
    this.mSoftwareDay = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "MavlinkRequestInfoFeedback;Pack a request_info_feedback message."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "SoftwareVersion",
      Description = "SoftwareVersion",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "HardwareVersion",
      Description = "HardwareVersion",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "SoftwareYear",
      Description = "SoftwareYear",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "ProductName",
      Description = "ProductName",
      NumElements = 16 /*0x10*/
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "SoftwareType",
      Description = "SoftwareType",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "SoftwareMonth",
      Description = "SoftwareMonth",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "SoftwareDay",
      Description = "SoftwareDay",
      NumElements = 1
    });
  }
}
