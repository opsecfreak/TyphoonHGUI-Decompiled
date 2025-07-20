// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasFileTransferStart
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasFileTransferStart : UasMessage
{
  private ulong mTransferUid;
  private uint mFileSize;
  private char[] mDestPath = new char[240 /*0xF0*/];
  private byte mDirection;
  private byte mFlags;

  public ulong TransferUid
  {
    get => this.mTransferUid;
    set
    {
      this.mTransferUid = value;
      this.NotifyUpdated();
    }
  }

  public uint FileSize
  {
    get => this.mFileSize;
    set
    {
      this.mFileSize = value;
      this.NotifyUpdated();
    }
  }

  public char[] DestPath
  {
    get => this.mDestPath;
    set
    {
      this.mDestPath = value;
      this.NotifyUpdated();
    }
  }

  public byte Direction
  {
    get => this.mDirection;
    set
    {
      this.mDirection = value;
      this.NotifyUpdated();
    }
  }

  public byte Flags
  {
    get => this.mFlags;
    set
    {
      this.mFlags = value;
      this.NotifyUpdated();
    }
  }

  public UasFileTransferStart()
  {
    this.mMessageId = (byte) 110;
    this.CrcExtra = (byte) 235;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTransferUid);
    s.Write(this.mFileSize);
    s.Write(this.mDestPath[0]);
    s.Write(this.mDestPath[1]);
    s.Write(this.mDestPath[2]);
    s.Write(this.mDestPath[3]);
    s.Write(this.mDestPath[4]);
    s.Write(this.mDestPath[5]);
    s.Write(this.mDestPath[6]);
    s.Write(this.mDestPath[7]);
    s.Write(this.mDestPath[8]);
    s.Write(this.mDestPath[9]);
    s.Write(this.mDestPath[10]);
    s.Write(this.mDestPath[11]);
    s.Write(this.mDestPath[12]);
    s.Write(this.mDestPath[13]);
    s.Write(this.mDestPath[14]);
    s.Write(this.mDestPath[15]);
    s.Write(this.mDestPath[16 /*0x10*/]);
    s.Write(this.mDestPath[17]);
    s.Write(this.mDestPath[18]);
    s.Write(this.mDestPath[19]);
    s.Write(this.mDestPath[20]);
    s.Write(this.mDestPath[21]);
    s.Write(this.mDestPath[22]);
    s.Write(this.mDestPath[23]);
    s.Write(this.mDestPath[24]);
    s.Write(this.mDestPath[25]);
    s.Write(this.mDestPath[26]);
    s.Write(this.mDestPath[27]);
    s.Write(this.mDestPath[28]);
    s.Write(this.mDestPath[29]);
    s.Write(this.mDestPath[30]);
    s.Write(this.mDestPath[31 /*0x1F*/]);
    s.Write(this.mDestPath[32 /*0x20*/]);
    s.Write(this.mDestPath[33]);
    s.Write(this.mDestPath[34]);
    s.Write(this.mDestPath[35]);
    s.Write(this.mDestPath[36]);
    s.Write(this.mDestPath[37]);
    s.Write(this.mDestPath[38]);
    s.Write(this.mDestPath[39]);
    s.Write(this.mDestPath[40]);
    s.Write(this.mDestPath[41]);
    s.Write(this.mDestPath[42]);
    s.Write(this.mDestPath[43]);
    s.Write(this.mDestPath[44]);
    s.Write(this.mDestPath[45]);
    s.Write(this.mDestPath[46]);
    s.Write(this.mDestPath[47]);
    s.Write(this.mDestPath[48 /*0x30*/]);
    s.Write(this.mDestPath[49]);
    s.Write(this.mDestPath[50]);
    s.Write(this.mDestPath[51]);
    s.Write(this.mDestPath[52]);
    s.Write(this.mDestPath[53]);
    s.Write(this.mDestPath[54]);
    s.Write(this.mDestPath[55]);
    s.Write(this.mDestPath[56]);
    s.Write(this.mDestPath[57]);
    s.Write(this.mDestPath[58]);
    s.Write(this.mDestPath[59]);
    s.Write(this.mDestPath[60]);
    s.Write(this.mDestPath[61]);
    s.Write(this.mDestPath[62]);
    s.Write(this.mDestPath[63 /*0x3F*/]);
    s.Write(this.mDestPath[64 /*0x40*/]);
    s.Write(this.mDestPath[65]);
    s.Write(this.mDestPath[66]);
    s.Write(this.mDestPath[67]);
    s.Write(this.mDestPath[68]);
    s.Write(this.mDestPath[69]);
    s.Write(this.mDestPath[70]);
    s.Write(this.mDestPath[71]);
    s.Write(this.mDestPath[72]);
    s.Write(this.mDestPath[73]);
    s.Write(this.mDestPath[74]);
    s.Write(this.mDestPath[75]);
    s.Write(this.mDestPath[76]);
    s.Write(this.mDestPath[77]);
    s.Write(this.mDestPath[78]);
    s.Write(this.mDestPath[79]);
    s.Write(this.mDestPath[80 /*0x50*/]);
    s.Write(this.mDestPath[81]);
    s.Write(this.mDestPath[82]);
    s.Write(this.mDestPath[83]);
    s.Write(this.mDestPath[84]);
    s.Write(this.mDestPath[85]);
    s.Write(this.mDestPath[86]);
    s.Write(this.mDestPath[87]);
    s.Write(this.mDestPath[88]);
    s.Write(this.mDestPath[89]);
    s.Write(this.mDestPath[90]);
    s.Write(this.mDestPath[91]);
    s.Write(this.mDestPath[92]);
    s.Write(this.mDestPath[93]);
    s.Write(this.mDestPath[94]);
    s.Write(this.mDestPath[95]);
    s.Write(this.mDestPath[96 /*0x60*/]);
    s.Write(this.mDestPath[97]);
    s.Write(this.mDestPath[98]);
    s.Write(this.mDestPath[99]);
    s.Write(this.mDestPath[100]);
    s.Write(this.mDestPath[101]);
    s.Write(this.mDestPath[102]);
    s.Write(this.mDestPath[103]);
    s.Write(this.mDestPath[104]);
    s.Write(this.mDestPath[105]);
    s.Write(this.mDestPath[106]);
    s.Write(this.mDestPath[107]);
    s.Write(this.mDestPath[108]);
    s.Write(this.mDestPath[109]);
    s.Write(this.mDestPath[110]);
    s.Write(this.mDestPath[111]);
    s.Write(this.mDestPath[112 /*0x70*/]);
    s.Write(this.mDestPath[113]);
    s.Write(this.mDestPath[114]);
    s.Write(this.mDestPath[115]);
    s.Write(this.mDestPath[116]);
    s.Write(this.mDestPath[117]);
    s.Write(this.mDestPath[118]);
    s.Write(this.mDestPath[119]);
    s.Write(this.mDestPath[120]);
    s.Write(this.mDestPath[121]);
    s.Write(this.mDestPath[122]);
    s.Write(this.mDestPath[123]);
    s.Write(this.mDestPath[124]);
    s.Write(this.mDestPath[125]);
    s.Write(this.mDestPath[126]);
    s.Write(this.mDestPath[(int) sbyte.MaxValue]);
    s.Write(this.mDestPath[128 /*0x80*/]);
    s.Write(this.mDestPath[129]);
    s.Write(this.mDestPath[130]);
    s.Write(this.mDestPath[131]);
    s.Write(this.mDestPath[132]);
    s.Write(this.mDestPath[133]);
    s.Write(this.mDestPath[134]);
    s.Write(this.mDestPath[135]);
    s.Write(this.mDestPath[136]);
    s.Write(this.mDestPath[137]);
    s.Write(this.mDestPath[138]);
    s.Write(this.mDestPath[139]);
    s.Write(this.mDestPath[140]);
    s.Write(this.mDestPath[141]);
    s.Write(this.mDestPath[142]);
    s.Write(this.mDestPath[143]);
    s.Write(this.mDestPath[144 /*0x90*/]);
    s.Write(this.mDestPath[145]);
    s.Write(this.mDestPath[146]);
    s.Write(this.mDestPath[147]);
    s.Write(this.mDestPath[148]);
    s.Write(this.mDestPath[149]);
    s.Write(this.mDestPath[150]);
    s.Write(this.mDestPath[151]);
    s.Write(this.mDestPath[152]);
    s.Write(this.mDestPath[153]);
    s.Write(this.mDestPath[154]);
    s.Write(this.mDestPath[155]);
    s.Write(this.mDestPath[156]);
    s.Write(this.mDestPath[157]);
    s.Write(this.mDestPath[158]);
    s.Write(this.mDestPath[159]);
    s.Write(this.mDestPath[160 /*0xA0*/]);
    s.Write(this.mDestPath[161]);
    s.Write(this.mDestPath[162]);
    s.Write(this.mDestPath[163]);
    s.Write(this.mDestPath[164]);
    s.Write(this.mDestPath[165]);
    s.Write(this.mDestPath[166]);
    s.Write(this.mDestPath[167]);
    s.Write(this.mDestPath[168]);
    s.Write(this.mDestPath[169]);
    s.Write(this.mDestPath[170]);
    s.Write(this.mDestPath[171]);
    s.Write(this.mDestPath[172]);
    s.Write(this.mDestPath[173]);
    s.Write(this.mDestPath[174]);
    s.Write(this.mDestPath[175]);
    s.Write(this.mDestPath[176 /*0xB0*/]);
    s.Write(this.mDestPath[177]);
    s.Write(this.mDestPath[178]);
    s.Write(this.mDestPath[179]);
    s.Write(this.mDestPath[180]);
    s.Write(this.mDestPath[181]);
    s.Write(this.mDestPath[182]);
    s.Write(this.mDestPath[183]);
    s.Write(this.mDestPath[184]);
    s.Write(this.mDestPath[185]);
    s.Write(this.mDestPath[186]);
    s.Write(this.mDestPath[187]);
    s.Write(this.mDestPath[188]);
    s.Write(this.mDestPath[189]);
    s.Write(this.mDestPath[190]);
    s.Write(this.mDestPath[191]);
    s.Write(this.mDestPath[192 /*0xC0*/]);
    s.Write(this.mDestPath[193]);
    s.Write(this.mDestPath[194]);
    s.Write(this.mDestPath[195]);
    s.Write(this.mDestPath[196]);
    s.Write(this.mDestPath[197]);
    s.Write(this.mDestPath[198]);
    s.Write(this.mDestPath[199]);
    s.Write(this.mDestPath[200]);
    s.Write(this.mDestPath[201]);
    s.Write(this.mDestPath[202]);
    s.Write(this.mDestPath[203]);
    s.Write(this.mDestPath[204]);
    s.Write(this.mDestPath[205]);
    s.Write(this.mDestPath[206]);
    s.Write(this.mDestPath[207]);
    s.Write(this.mDestPath[208 /*0xD0*/]);
    s.Write(this.mDestPath[209]);
    s.Write(this.mDestPath[210]);
    s.Write(this.mDestPath[211]);
    s.Write(this.mDestPath[212]);
    s.Write(this.mDestPath[213]);
    s.Write(this.mDestPath[214]);
    s.Write(this.mDestPath[215]);
    s.Write(this.mDestPath[216]);
    s.Write(this.mDestPath[217]);
    s.Write(this.mDestPath[218]);
    s.Write(this.mDestPath[219]);
    s.Write(this.mDestPath[220]);
    s.Write(this.mDestPath[221]);
    s.Write(this.mDestPath[222]);
    s.Write(this.mDestPath[223]);
    s.Write(this.mDestPath[224 /*0xE0*/]);
    s.Write(this.mDestPath[225]);
    s.Write(this.mDestPath[226]);
    s.Write(this.mDestPath[227]);
    s.Write(this.mDestPath[228]);
    s.Write(this.mDestPath[229]);
    s.Write(this.mDestPath[230]);
    s.Write(this.mDestPath[231]);
    s.Write(this.mDestPath[232]);
    s.Write(this.mDestPath[233]);
    s.Write(this.mDestPath[234]);
    s.Write(this.mDestPath[235]);
    s.Write(this.mDestPath[236]);
    s.Write(this.mDestPath[237]);
    s.Write(this.mDestPath[238]);
    s.Write(this.mDestPath[239]);
    s.Write(this.mDirection);
    s.Write(this.mFlags);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTransferUid = s.ReadUInt64();
    this.mFileSize = s.ReadUInt32();
    this.mDestPath[0] = s.ReadChar();
    this.mDestPath[1] = s.ReadChar();
    this.mDestPath[2] = s.ReadChar();
    this.mDestPath[3] = s.ReadChar();
    this.mDestPath[4] = s.ReadChar();
    this.mDestPath[5] = s.ReadChar();
    this.mDestPath[6] = s.ReadChar();
    this.mDestPath[7] = s.ReadChar();
    this.mDestPath[8] = s.ReadChar();
    this.mDestPath[9] = s.ReadChar();
    this.mDestPath[10] = s.ReadChar();
    this.mDestPath[11] = s.ReadChar();
    this.mDestPath[12] = s.ReadChar();
    this.mDestPath[13] = s.ReadChar();
    this.mDestPath[14] = s.ReadChar();
    this.mDestPath[15] = s.ReadChar();
    this.mDestPath[16 /*0x10*/] = s.ReadChar();
    this.mDestPath[17] = s.ReadChar();
    this.mDestPath[18] = s.ReadChar();
    this.mDestPath[19] = s.ReadChar();
    this.mDestPath[20] = s.ReadChar();
    this.mDestPath[21] = s.ReadChar();
    this.mDestPath[22] = s.ReadChar();
    this.mDestPath[23] = s.ReadChar();
    this.mDestPath[24] = s.ReadChar();
    this.mDestPath[25] = s.ReadChar();
    this.mDestPath[26] = s.ReadChar();
    this.mDestPath[27] = s.ReadChar();
    this.mDestPath[28] = s.ReadChar();
    this.mDestPath[29] = s.ReadChar();
    this.mDestPath[30] = s.ReadChar();
    this.mDestPath[31 /*0x1F*/] = s.ReadChar();
    this.mDestPath[32 /*0x20*/] = s.ReadChar();
    this.mDestPath[33] = s.ReadChar();
    this.mDestPath[34] = s.ReadChar();
    this.mDestPath[35] = s.ReadChar();
    this.mDestPath[36] = s.ReadChar();
    this.mDestPath[37] = s.ReadChar();
    this.mDestPath[38] = s.ReadChar();
    this.mDestPath[39] = s.ReadChar();
    this.mDestPath[40] = s.ReadChar();
    this.mDestPath[41] = s.ReadChar();
    this.mDestPath[42] = s.ReadChar();
    this.mDestPath[43] = s.ReadChar();
    this.mDestPath[44] = s.ReadChar();
    this.mDestPath[45] = s.ReadChar();
    this.mDestPath[46] = s.ReadChar();
    this.mDestPath[47] = s.ReadChar();
    this.mDestPath[48 /*0x30*/] = s.ReadChar();
    this.mDestPath[49] = s.ReadChar();
    this.mDestPath[50] = s.ReadChar();
    this.mDestPath[51] = s.ReadChar();
    this.mDestPath[52] = s.ReadChar();
    this.mDestPath[53] = s.ReadChar();
    this.mDestPath[54] = s.ReadChar();
    this.mDestPath[55] = s.ReadChar();
    this.mDestPath[56] = s.ReadChar();
    this.mDestPath[57] = s.ReadChar();
    this.mDestPath[58] = s.ReadChar();
    this.mDestPath[59] = s.ReadChar();
    this.mDestPath[60] = s.ReadChar();
    this.mDestPath[61] = s.ReadChar();
    this.mDestPath[62] = s.ReadChar();
    this.mDestPath[63 /*0x3F*/] = s.ReadChar();
    this.mDestPath[64 /*0x40*/] = s.ReadChar();
    this.mDestPath[65] = s.ReadChar();
    this.mDestPath[66] = s.ReadChar();
    this.mDestPath[67] = s.ReadChar();
    this.mDestPath[68] = s.ReadChar();
    this.mDestPath[69] = s.ReadChar();
    this.mDestPath[70] = s.ReadChar();
    this.mDestPath[71] = s.ReadChar();
    this.mDestPath[72] = s.ReadChar();
    this.mDestPath[73] = s.ReadChar();
    this.mDestPath[74] = s.ReadChar();
    this.mDestPath[75] = s.ReadChar();
    this.mDestPath[76] = s.ReadChar();
    this.mDestPath[77] = s.ReadChar();
    this.mDestPath[78] = s.ReadChar();
    this.mDestPath[79] = s.ReadChar();
    this.mDestPath[80 /*0x50*/] = s.ReadChar();
    this.mDestPath[81] = s.ReadChar();
    this.mDestPath[82] = s.ReadChar();
    this.mDestPath[83] = s.ReadChar();
    this.mDestPath[84] = s.ReadChar();
    this.mDestPath[85] = s.ReadChar();
    this.mDestPath[86] = s.ReadChar();
    this.mDestPath[87] = s.ReadChar();
    this.mDestPath[88] = s.ReadChar();
    this.mDestPath[89] = s.ReadChar();
    this.mDestPath[90] = s.ReadChar();
    this.mDestPath[91] = s.ReadChar();
    this.mDestPath[92] = s.ReadChar();
    this.mDestPath[93] = s.ReadChar();
    this.mDestPath[94] = s.ReadChar();
    this.mDestPath[95] = s.ReadChar();
    this.mDestPath[96 /*0x60*/] = s.ReadChar();
    this.mDestPath[97] = s.ReadChar();
    this.mDestPath[98] = s.ReadChar();
    this.mDestPath[99] = s.ReadChar();
    this.mDestPath[100] = s.ReadChar();
    this.mDestPath[101] = s.ReadChar();
    this.mDestPath[102] = s.ReadChar();
    this.mDestPath[103] = s.ReadChar();
    this.mDestPath[104] = s.ReadChar();
    this.mDestPath[105] = s.ReadChar();
    this.mDestPath[106] = s.ReadChar();
    this.mDestPath[107] = s.ReadChar();
    this.mDestPath[108] = s.ReadChar();
    this.mDestPath[109] = s.ReadChar();
    this.mDestPath[110] = s.ReadChar();
    this.mDestPath[111] = s.ReadChar();
    this.mDestPath[112 /*0x70*/] = s.ReadChar();
    this.mDestPath[113] = s.ReadChar();
    this.mDestPath[114] = s.ReadChar();
    this.mDestPath[115] = s.ReadChar();
    this.mDestPath[116] = s.ReadChar();
    this.mDestPath[117] = s.ReadChar();
    this.mDestPath[118] = s.ReadChar();
    this.mDestPath[119] = s.ReadChar();
    this.mDestPath[120] = s.ReadChar();
    this.mDestPath[121] = s.ReadChar();
    this.mDestPath[122] = s.ReadChar();
    this.mDestPath[123] = s.ReadChar();
    this.mDestPath[124] = s.ReadChar();
    this.mDestPath[125] = s.ReadChar();
    this.mDestPath[126] = s.ReadChar();
    this.mDestPath[(int) sbyte.MaxValue] = s.ReadChar();
    this.mDestPath[128 /*0x80*/] = s.ReadChar();
    this.mDestPath[129] = s.ReadChar();
    this.mDestPath[130] = s.ReadChar();
    this.mDestPath[131] = s.ReadChar();
    this.mDestPath[132] = s.ReadChar();
    this.mDestPath[133] = s.ReadChar();
    this.mDestPath[134] = s.ReadChar();
    this.mDestPath[135] = s.ReadChar();
    this.mDestPath[136] = s.ReadChar();
    this.mDestPath[137] = s.ReadChar();
    this.mDestPath[138] = s.ReadChar();
    this.mDestPath[139] = s.ReadChar();
    this.mDestPath[140] = s.ReadChar();
    this.mDestPath[141] = s.ReadChar();
    this.mDestPath[142] = s.ReadChar();
    this.mDestPath[143] = s.ReadChar();
    this.mDestPath[144 /*0x90*/] = s.ReadChar();
    this.mDestPath[145] = s.ReadChar();
    this.mDestPath[146] = s.ReadChar();
    this.mDestPath[147] = s.ReadChar();
    this.mDestPath[148] = s.ReadChar();
    this.mDestPath[149] = s.ReadChar();
    this.mDestPath[150] = s.ReadChar();
    this.mDestPath[151] = s.ReadChar();
    this.mDestPath[152] = s.ReadChar();
    this.mDestPath[153] = s.ReadChar();
    this.mDestPath[154] = s.ReadChar();
    this.mDestPath[155] = s.ReadChar();
    this.mDestPath[156] = s.ReadChar();
    this.mDestPath[157] = s.ReadChar();
    this.mDestPath[158] = s.ReadChar();
    this.mDestPath[159] = s.ReadChar();
    this.mDestPath[160 /*0xA0*/] = s.ReadChar();
    this.mDestPath[161] = s.ReadChar();
    this.mDestPath[162] = s.ReadChar();
    this.mDestPath[163] = s.ReadChar();
    this.mDestPath[164] = s.ReadChar();
    this.mDestPath[165] = s.ReadChar();
    this.mDestPath[166] = s.ReadChar();
    this.mDestPath[167] = s.ReadChar();
    this.mDestPath[168] = s.ReadChar();
    this.mDestPath[169] = s.ReadChar();
    this.mDestPath[170] = s.ReadChar();
    this.mDestPath[171] = s.ReadChar();
    this.mDestPath[172] = s.ReadChar();
    this.mDestPath[173] = s.ReadChar();
    this.mDestPath[174] = s.ReadChar();
    this.mDestPath[175] = s.ReadChar();
    this.mDestPath[176 /*0xB0*/] = s.ReadChar();
    this.mDestPath[177] = s.ReadChar();
    this.mDestPath[178] = s.ReadChar();
    this.mDestPath[179] = s.ReadChar();
    this.mDestPath[180] = s.ReadChar();
    this.mDestPath[181] = s.ReadChar();
    this.mDestPath[182] = s.ReadChar();
    this.mDestPath[183] = s.ReadChar();
    this.mDestPath[184] = s.ReadChar();
    this.mDestPath[185] = s.ReadChar();
    this.mDestPath[186] = s.ReadChar();
    this.mDestPath[187] = s.ReadChar();
    this.mDestPath[188] = s.ReadChar();
    this.mDestPath[189] = s.ReadChar();
    this.mDestPath[190] = s.ReadChar();
    this.mDestPath[191] = s.ReadChar();
    this.mDestPath[192 /*0xC0*/] = s.ReadChar();
    this.mDestPath[193] = s.ReadChar();
    this.mDestPath[194] = s.ReadChar();
    this.mDestPath[195] = s.ReadChar();
    this.mDestPath[196] = s.ReadChar();
    this.mDestPath[197] = s.ReadChar();
    this.mDestPath[198] = s.ReadChar();
    this.mDestPath[199] = s.ReadChar();
    this.mDestPath[200] = s.ReadChar();
    this.mDestPath[201] = s.ReadChar();
    this.mDestPath[202] = s.ReadChar();
    this.mDestPath[203] = s.ReadChar();
    this.mDestPath[204] = s.ReadChar();
    this.mDestPath[205] = s.ReadChar();
    this.mDestPath[206] = s.ReadChar();
    this.mDestPath[207] = s.ReadChar();
    this.mDestPath[208 /*0xD0*/] = s.ReadChar();
    this.mDestPath[209] = s.ReadChar();
    this.mDestPath[210] = s.ReadChar();
    this.mDestPath[211] = s.ReadChar();
    this.mDestPath[212] = s.ReadChar();
    this.mDestPath[213] = s.ReadChar();
    this.mDestPath[214] = s.ReadChar();
    this.mDestPath[215] = s.ReadChar();
    this.mDestPath[216] = s.ReadChar();
    this.mDestPath[217] = s.ReadChar();
    this.mDestPath[218] = s.ReadChar();
    this.mDestPath[219] = s.ReadChar();
    this.mDestPath[220] = s.ReadChar();
    this.mDestPath[221] = s.ReadChar();
    this.mDestPath[222] = s.ReadChar();
    this.mDestPath[223] = s.ReadChar();
    this.mDestPath[224 /*0xE0*/] = s.ReadChar();
    this.mDestPath[225] = s.ReadChar();
    this.mDestPath[226] = s.ReadChar();
    this.mDestPath[227] = s.ReadChar();
    this.mDestPath[228] = s.ReadChar();
    this.mDestPath[229] = s.ReadChar();
    this.mDestPath[230] = s.ReadChar();
    this.mDestPath[231] = s.ReadChar();
    this.mDestPath[232] = s.ReadChar();
    this.mDestPath[233] = s.ReadChar();
    this.mDestPath[234] = s.ReadChar();
    this.mDestPath[235] = s.ReadChar();
    this.mDestPath[236] = s.ReadChar();
    this.mDestPath[237] = s.ReadChar();
    this.mDestPath[238] = s.ReadChar();
    this.mDestPath[239] = s.ReadChar();
    this.mDirection = s.ReadByte();
    this.mFlags = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Begin file transfer"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TransferUid",
      Description = "Unique transfer ID",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "FileSize",
      Description = "File size in bytes",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "DestPath",
      Description = "Destination path",
      NumElements = 240 /*0xF0*/
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Direction",
      Description = "Transfer direction: 0: from requester, 1: to requester",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Flags",
      Description = "RESERVED",
      NumElements = 1
    });
  }
}
