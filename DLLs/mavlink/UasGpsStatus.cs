// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasGpsStatus
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasGpsStatus : UasMessage
{
  private byte mSatellitesVisible;
  private byte[] mSatellitePrn = new byte[20];
  private byte[] mSatelliteUsed = new byte[20];
  private byte[] mSatelliteElevation = new byte[20];
  private byte[] mSatelliteAzimuth = new byte[20];
  private byte[] mSatelliteSnr = new byte[20];

  public byte SatellitesVisible
  {
    get => this.mSatellitesVisible;
    set
    {
      this.mSatellitesVisible = value;
      this.NotifyUpdated();
    }
  }

  public byte[] SatellitePrn
  {
    get => this.mSatellitePrn;
    set
    {
      this.mSatellitePrn = value;
      this.NotifyUpdated();
    }
  }

  public byte[] SatelliteUsed
  {
    get => this.mSatelliteUsed;
    set
    {
      this.mSatelliteUsed = value;
      this.NotifyUpdated();
    }
  }

  public byte[] SatelliteElevation
  {
    get => this.mSatelliteElevation;
    set
    {
      this.mSatelliteElevation = value;
      this.NotifyUpdated();
    }
  }

  public byte[] SatelliteAzimuth
  {
    get => this.mSatelliteAzimuth;
    set
    {
      this.mSatelliteAzimuth = value;
      this.NotifyUpdated();
    }
  }

  public byte[] SatelliteSnr
  {
    get => this.mSatelliteSnr;
    set
    {
      this.mSatelliteSnr = value;
      this.NotifyUpdated();
    }
  }

  public UasGpsStatus()
  {
    this.mMessageId = (byte) 25;
    this.CrcExtra = (byte) 23;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mSatellitesVisible);
    s.Write(this.mSatellitePrn[0]);
    s.Write(this.mSatellitePrn[1]);
    s.Write(this.mSatellitePrn[2]);
    s.Write(this.mSatellitePrn[3]);
    s.Write(this.mSatellitePrn[4]);
    s.Write(this.mSatellitePrn[5]);
    s.Write(this.mSatellitePrn[6]);
    s.Write(this.mSatellitePrn[7]);
    s.Write(this.mSatellitePrn[8]);
    s.Write(this.mSatellitePrn[9]);
    s.Write(this.mSatellitePrn[10]);
    s.Write(this.mSatellitePrn[11]);
    s.Write(this.mSatellitePrn[12]);
    s.Write(this.mSatellitePrn[13]);
    s.Write(this.mSatellitePrn[14]);
    s.Write(this.mSatellitePrn[15]);
    s.Write(this.mSatellitePrn[16 /*0x10*/]);
    s.Write(this.mSatellitePrn[17]);
    s.Write(this.mSatellitePrn[18]);
    s.Write(this.mSatellitePrn[19]);
    s.Write(this.mSatelliteUsed[0]);
    s.Write(this.mSatelliteUsed[1]);
    s.Write(this.mSatelliteUsed[2]);
    s.Write(this.mSatelliteUsed[3]);
    s.Write(this.mSatelliteUsed[4]);
    s.Write(this.mSatelliteUsed[5]);
    s.Write(this.mSatelliteUsed[6]);
    s.Write(this.mSatelliteUsed[7]);
    s.Write(this.mSatelliteUsed[8]);
    s.Write(this.mSatelliteUsed[9]);
    s.Write(this.mSatelliteUsed[10]);
    s.Write(this.mSatelliteUsed[11]);
    s.Write(this.mSatelliteUsed[12]);
    s.Write(this.mSatelliteUsed[13]);
    s.Write(this.mSatelliteUsed[14]);
    s.Write(this.mSatelliteUsed[15]);
    s.Write(this.mSatelliteUsed[16 /*0x10*/]);
    s.Write(this.mSatelliteUsed[17]);
    s.Write(this.mSatelliteUsed[18]);
    s.Write(this.mSatelliteUsed[19]);
    s.Write(this.mSatelliteElevation[0]);
    s.Write(this.mSatelliteElevation[1]);
    s.Write(this.mSatelliteElevation[2]);
    s.Write(this.mSatelliteElevation[3]);
    s.Write(this.mSatelliteElevation[4]);
    s.Write(this.mSatelliteElevation[5]);
    s.Write(this.mSatelliteElevation[6]);
    s.Write(this.mSatelliteElevation[7]);
    s.Write(this.mSatelliteElevation[8]);
    s.Write(this.mSatelliteElevation[9]);
    s.Write(this.mSatelliteElevation[10]);
    s.Write(this.mSatelliteElevation[11]);
    s.Write(this.mSatelliteElevation[12]);
    s.Write(this.mSatelliteElevation[13]);
    s.Write(this.mSatelliteElevation[14]);
    s.Write(this.mSatelliteElevation[15]);
    s.Write(this.mSatelliteElevation[16 /*0x10*/]);
    s.Write(this.mSatelliteElevation[17]);
    s.Write(this.mSatelliteElevation[18]);
    s.Write(this.mSatelliteElevation[19]);
    s.Write(this.mSatelliteAzimuth[0]);
    s.Write(this.mSatelliteAzimuth[1]);
    s.Write(this.mSatelliteAzimuth[2]);
    s.Write(this.mSatelliteAzimuth[3]);
    s.Write(this.mSatelliteAzimuth[4]);
    s.Write(this.mSatelliteAzimuth[5]);
    s.Write(this.mSatelliteAzimuth[6]);
    s.Write(this.mSatelliteAzimuth[7]);
    s.Write(this.mSatelliteAzimuth[8]);
    s.Write(this.mSatelliteAzimuth[9]);
    s.Write(this.mSatelliteAzimuth[10]);
    s.Write(this.mSatelliteAzimuth[11]);
    s.Write(this.mSatelliteAzimuth[12]);
    s.Write(this.mSatelliteAzimuth[13]);
    s.Write(this.mSatelliteAzimuth[14]);
    s.Write(this.mSatelliteAzimuth[15]);
    s.Write(this.mSatelliteAzimuth[16 /*0x10*/]);
    s.Write(this.mSatelliteAzimuth[17]);
    s.Write(this.mSatelliteAzimuth[18]);
    s.Write(this.mSatelliteAzimuth[19]);
    s.Write(this.mSatelliteSnr[0]);
    s.Write(this.mSatelliteSnr[1]);
    s.Write(this.mSatelliteSnr[2]);
    s.Write(this.mSatelliteSnr[3]);
    s.Write(this.mSatelliteSnr[4]);
    s.Write(this.mSatelliteSnr[5]);
    s.Write(this.mSatelliteSnr[6]);
    s.Write(this.mSatelliteSnr[7]);
    s.Write(this.mSatelliteSnr[8]);
    s.Write(this.mSatelliteSnr[9]);
    s.Write(this.mSatelliteSnr[10]);
    s.Write(this.mSatelliteSnr[11]);
    s.Write(this.mSatelliteSnr[12]);
    s.Write(this.mSatelliteSnr[13]);
    s.Write(this.mSatelliteSnr[14]);
    s.Write(this.mSatelliteSnr[15]);
    s.Write(this.mSatelliteSnr[16 /*0x10*/]);
    s.Write(this.mSatelliteSnr[17]);
    s.Write(this.mSatelliteSnr[18]);
    s.Write(this.mSatelliteSnr[19]);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mSatellitesVisible = s.ReadByte();
    this.mSatellitePrn[0] = s.ReadByte();
    this.mSatellitePrn[1] = s.ReadByte();
    this.mSatellitePrn[2] = s.ReadByte();
    this.mSatellitePrn[3] = s.ReadByte();
    this.mSatellitePrn[4] = s.ReadByte();
    this.mSatellitePrn[5] = s.ReadByte();
    this.mSatellitePrn[6] = s.ReadByte();
    this.mSatellitePrn[7] = s.ReadByte();
    this.mSatellitePrn[8] = s.ReadByte();
    this.mSatellitePrn[9] = s.ReadByte();
    this.mSatellitePrn[10] = s.ReadByte();
    this.mSatellitePrn[11] = s.ReadByte();
    this.mSatellitePrn[12] = s.ReadByte();
    this.mSatellitePrn[13] = s.ReadByte();
    this.mSatellitePrn[14] = s.ReadByte();
    this.mSatellitePrn[15] = s.ReadByte();
    this.mSatellitePrn[16 /*0x10*/] = s.ReadByte();
    this.mSatellitePrn[17] = s.ReadByte();
    this.mSatellitePrn[18] = s.ReadByte();
    this.mSatellitePrn[19] = s.ReadByte();
    this.mSatelliteUsed[0] = s.ReadByte();
    this.mSatelliteUsed[1] = s.ReadByte();
    this.mSatelliteUsed[2] = s.ReadByte();
    this.mSatelliteUsed[3] = s.ReadByte();
    this.mSatelliteUsed[4] = s.ReadByte();
    this.mSatelliteUsed[5] = s.ReadByte();
    this.mSatelliteUsed[6] = s.ReadByte();
    this.mSatelliteUsed[7] = s.ReadByte();
    this.mSatelliteUsed[8] = s.ReadByte();
    this.mSatelliteUsed[9] = s.ReadByte();
    this.mSatelliteUsed[10] = s.ReadByte();
    this.mSatelliteUsed[11] = s.ReadByte();
    this.mSatelliteUsed[12] = s.ReadByte();
    this.mSatelliteUsed[13] = s.ReadByte();
    this.mSatelliteUsed[14] = s.ReadByte();
    this.mSatelliteUsed[15] = s.ReadByte();
    this.mSatelliteUsed[16 /*0x10*/] = s.ReadByte();
    this.mSatelliteUsed[17] = s.ReadByte();
    this.mSatelliteUsed[18] = s.ReadByte();
    this.mSatelliteUsed[19] = s.ReadByte();
    this.mSatelliteElevation[0] = s.ReadByte();
    this.mSatelliteElevation[1] = s.ReadByte();
    this.mSatelliteElevation[2] = s.ReadByte();
    this.mSatelliteElevation[3] = s.ReadByte();
    this.mSatelliteElevation[4] = s.ReadByte();
    this.mSatelliteElevation[5] = s.ReadByte();
    this.mSatelliteElevation[6] = s.ReadByte();
    this.mSatelliteElevation[7] = s.ReadByte();
    this.mSatelliteElevation[8] = s.ReadByte();
    this.mSatelliteElevation[9] = s.ReadByte();
    this.mSatelliteElevation[10] = s.ReadByte();
    this.mSatelliteElevation[11] = s.ReadByte();
    this.mSatelliteElevation[12] = s.ReadByte();
    this.mSatelliteElevation[13] = s.ReadByte();
    this.mSatelliteElevation[14] = s.ReadByte();
    this.mSatelliteElevation[15] = s.ReadByte();
    this.mSatelliteElevation[16 /*0x10*/] = s.ReadByte();
    this.mSatelliteElevation[17] = s.ReadByte();
    this.mSatelliteElevation[18] = s.ReadByte();
    this.mSatelliteElevation[19] = s.ReadByte();
    this.mSatelliteAzimuth[0] = s.ReadByte();
    this.mSatelliteAzimuth[1] = s.ReadByte();
    this.mSatelliteAzimuth[2] = s.ReadByte();
    this.mSatelliteAzimuth[3] = s.ReadByte();
    this.mSatelliteAzimuth[4] = s.ReadByte();
    this.mSatelliteAzimuth[5] = s.ReadByte();
    this.mSatelliteAzimuth[6] = s.ReadByte();
    this.mSatelliteAzimuth[7] = s.ReadByte();
    this.mSatelliteAzimuth[8] = s.ReadByte();
    this.mSatelliteAzimuth[9] = s.ReadByte();
    this.mSatelliteAzimuth[10] = s.ReadByte();
    this.mSatelliteAzimuth[11] = s.ReadByte();
    this.mSatelliteAzimuth[12] = s.ReadByte();
    this.mSatelliteAzimuth[13] = s.ReadByte();
    this.mSatelliteAzimuth[14] = s.ReadByte();
    this.mSatelliteAzimuth[15] = s.ReadByte();
    this.mSatelliteAzimuth[16 /*0x10*/] = s.ReadByte();
    this.mSatelliteAzimuth[17] = s.ReadByte();
    this.mSatelliteAzimuth[18] = s.ReadByte();
    this.mSatelliteAzimuth[19] = s.ReadByte();
    this.mSatelliteSnr[0] = s.ReadByte();
    this.mSatelliteSnr[1] = s.ReadByte();
    this.mSatelliteSnr[2] = s.ReadByte();
    this.mSatelliteSnr[3] = s.ReadByte();
    this.mSatelliteSnr[4] = s.ReadByte();
    this.mSatelliteSnr[5] = s.ReadByte();
    this.mSatelliteSnr[6] = s.ReadByte();
    this.mSatelliteSnr[7] = s.ReadByte();
    this.mSatelliteSnr[8] = s.ReadByte();
    this.mSatelliteSnr[9] = s.ReadByte();
    this.mSatelliteSnr[10] = s.ReadByte();
    this.mSatelliteSnr[11] = s.ReadByte();
    this.mSatelliteSnr[12] = s.ReadByte();
    this.mSatelliteSnr[13] = s.ReadByte();
    this.mSatelliteSnr[14] = s.ReadByte();
    this.mSatelliteSnr[15] = s.ReadByte();
    this.mSatelliteSnr[16 /*0x10*/] = s.ReadByte();
    this.mSatelliteSnr[17] = s.ReadByte();
    this.mSatelliteSnr[18] = s.ReadByte();
    this.mSatelliteSnr[19] = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "UasGpsStatus;The positioning status, as reported by GPS. This message is intended to display status information about each satellite visible to the receiver. See message GLOBAL_POSITION for the global position estimate. This message can contain information for up to 20 satellites."
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "SatellitesVisible",
      Description = "Number of satellites visible",
      Value = this.mSatellitesVisible.ToString(),
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "SatellitePrn",
      Description = "Global satellite ID",
      Value = this.SatellitePrn.ToString(),
      NumElements = 20
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "SatelliteUsed",
      Description = "0: Satellite not used, 1: used for localization",
      Value = this.SatelliteUsed.ToString(),
      NumElements = 20
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "SatelliteElevation",
      Description = "Elevation (0: right on top of receiver, 90: on the horizon) of satellite",
      Value = this.SatelliteElevation.ToString(),
      NumElements = 20
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "SatelliteAzimuth",
      Description = "Direction of satellite, 0: 0 deg, 255: 360 deg.",
      Value = this.SatelliteAzimuth.ToString(),
      NumElements = 20
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "SatelliteSnr",
      Description = "Signal to noise ratio of satellite",
      Value = this.SatelliteSnr.ToString(),
      NumElements = 20
    });
  }
}
