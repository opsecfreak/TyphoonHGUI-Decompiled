// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasFileTransferDirList
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.IO;

#nullable disable
namespace MavLinkNet;

public class UasFileTransferDirList : UasMessage
{
  private ulong mTransferUid;
  private char[] mDirPath = new char[240 /*0xF0*/];
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

  public char[] DirPath
  {
    get => this.mDirPath;
    set
    {
      this.mDirPath = value;
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

  public UasFileTransferDirList()
  {
    this.mMessageId = (byte) 111;
    this.CrcExtra = (byte) 93;
  }

  internal override void SerializeBody(BinaryWriter s)
  {
    s.Write(this.mTransferUid);
    s.Write(this.mDirPath[0]);
    s.Write(this.mDirPath[1]);
    s.Write(this.mDirPath[2]);
    s.Write(this.mDirPath[3]);
    s.Write(this.mDirPath[4]);
    s.Write(this.mDirPath[5]);
    s.Write(this.mDirPath[6]);
    s.Write(this.mDirPath[7]);
    s.Write(this.mDirPath[8]);
    s.Write(this.mDirPath[9]);
    s.Write(this.mDirPath[10]);
    s.Write(this.mDirPath[11]);
    s.Write(this.mDirPath[12]);
    s.Write(this.mDirPath[13]);
    s.Write(this.mDirPath[14]);
    s.Write(this.mDirPath[15]);
    s.Write(this.mDirPath[16 /*0x10*/]);
    s.Write(this.mDirPath[17]);
    s.Write(this.mDirPath[18]);
    s.Write(this.mDirPath[19]);
    s.Write(this.mDirPath[20]);
    s.Write(this.mDirPath[21]);
    s.Write(this.mDirPath[22]);
    s.Write(this.mDirPath[23]);
    s.Write(this.mDirPath[24]);
    s.Write(this.mDirPath[25]);
    s.Write(this.mDirPath[26]);
    s.Write(this.mDirPath[27]);
    s.Write(this.mDirPath[28]);
    s.Write(this.mDirPath[29]);
    s.Write(this.mDirPath[30]);
    s.Write(this.mDirPath[31 /*0x1F*/]);
    s.Write(this.mDirPath[32 /*0x20*/]);
    s.Write(this.mDirPath[33]);
    s.Write(this.mDirPath[34]);
    s.Write(this.mDirPath[35]);
    s.Write(this.mDirPath[36]);
    s.Write(this.mDirPath[37]);
    s.Write(this.mDirPath[38]);
    s.Write(this.mDirPath[39]);
    s.Write(this.mDirPath[40]);
    s.Write(this.mDirPath[41]);
    s.Write(this.mDirPath[42]);
    s.Write(this.mDirPath[43]);
    s.Write(this.mDirPath[44]);
    s.Write(this.mDirPath[45]);
    s.Write(this.mDirPath[46]);
    s.Write(this.mDirPath[47]);
    s.Write(this.mDirPath[48 /*0x30*/]);
    s.Write(this.mDirPath[49]);
    s.Write(this.mDirPath[50]);
    s.Write(this.mDirPath[51]);
    s.Write(this.mDirPath[52]);
    s.Write(this.mDirPath[53]);
    s.Write(this.mDirPath[54]);
    s.Write(this.mDirPath[55]);
    s.Write(this.mDirPath[56]);
    s.Write(this.mDirPath[57]);
    s.Write(this.mDirPath[58]);
    s.Write(this.mDirPath[59]);
    s.Write(this.mDirPath[60]);
    s.Write(this.mDirPath[61]);
    s.Write(this.mDirPath[62]);
    s.Write(this.mDirPath[63 /*0x3F*/]);
    s.Write(this.mDirPath[64 /*0x40*/]);
    s.Write(this.mDirPath[65]);
    s.Write(this.mDirPath[66]);
    s.Write(this.mDirPath[67]);
    s.Write(this.mDirPath[68]);
    s.Write(this.mDirPath[69]);
    s.Write(this.mDirPath[70]);
    s.Write(this.mDirPath[71]);
    s.Write(this.mDirPath[72]);
    s.Write(this.mDirPath[73]);
    s.Write(this.mDirPath[74]);
    s.Write(this.mDirPath[75]);
    s.Write(this.mDirPath[76]);
    s.Write(this.mDirPath[77]);
    s.Write(this.mDirPath[78]);
    s.Write(this.mDirPath[79]);
    s.Write(this.mDirPath[80 /*0x50*/]);
    s.Write(this.mDirPath[81]);
    s.Write(this.mDirPath[82]);
    s.Write(this.mDirPath[83]);
    s.Write(this.mDirPath[84]);
    s.Write(this.mDirPath[85]);
    s.Write(this.mDirPath[86]);
    s.Write(this.mDirPath[87]);
    s.Write(this.mDirPath[88]);
    s.Write(this.mDirPath[89]);
    s.Write(this.mDirPath[90]);
    s.Write(this.mDirPath[91]);
    s.Write(this.mDirPath[92]);
    s.Write(this.mDirPath[93]);
    s.Write(this.mDirPath[94]);
    s.Write(this.mDirPath[95]);
    s.Write(this.mDirPath[96 /*0x60*/]);
    s.Write(this.mDirPath[97]);
    s.Write(this.mDirPath[98]);
    s.Write(this.mDirPath[99]);
    s.Write(this.mDirPath[100]);
    s.Write(this.mDirPath[101]);
    s.Write(this.mDirPath[102]);
    s.Write(this.mDirPath[103]);
    s.Write(this.mDirPath[104]);
    s.Write(this.mDirPath[105]);
    s.Write(this.mDirPath[106]);
    s.Write(this.mDirPath[107]);
    s.Write(this.mDirPath[108]);
    s.Write(this.mDirPath[109]);
    s.Write(this.mDirPath[110]);
    s.Write(this.mDirPath[111]);
    s.Write(this.mDirPath[112 /*0x70*/]);
    s.Write(this.mDirPath[113]);
    s.Write(this.mDirPath[114]);
    s.Write(this.mDirPath[115]);
    s.Write(this.mDirPath[116]);
    s.Write(this.mDirPath[117]);
    s.Write(this.mDirPath[118]);
    s.Write(this.mDirPath[119]);
    s.Write(this.mDirPath[120]);
    s.Write(this.mDirPath[121]);
    s.Write(this.mDirPath[122]);
    s.Write(this.mDirPath[123]);
    s.Write(this.mDirPath[124]);
    s.Write(this.mDirPath[125]);
    s.Write(this.mDirPath[126]);
    s.Write(this.mDirPath[(int) sbyte.MaxValue]);
    s.Write(this.mDirPath[128 /*0x80*/]);
    s.Write(this.mDirPath[129]);
    s.Write(this.mDirPath[130]);
    s.Write(this.mDirPath[131]);
    s.Write(this.mDirPath[132]);
    s.Write(this.mDirPath[133]);
    s.Write(this.mDirPath[134]);
    s.Write(this.mDirPath[135]);
    s.Write(this.mDirPath[136]);
    s.Write(this.mDirPath[137]);
    s.Write(this.mDirPath[138]);
    s.Write(this.mDirPath[139]);
    s.Write(this.mDirPath[140]);
    s.Write(this.mDirPath[141]);
    s.Write(this.mDirPath[142]);
    s.Write(this.mDirPath[143]);
    s.Write(this.mDirPath[144 /*0x90*/]);
    s.Write(this.mDirPath[145]);
    s.Write(this.mDirPath[146]);
    s.Write(this.mDirPath[147]);
    s.Write(this.mDirPath[148]);
    s.Write(this.mDirPath[149]);
    s.Write(this.mDirPath[150]);
    s.Write(this.mDirPath[151]);
    s.Write(this.mDirPath[152]);
    s.Write(this.mDirPath[153]);
    s.Write(this.mDirPath[154]);
    s.Write(this.mDirPath[155]);
    s.Write(this.mDirPath[156]);
    s.Write(this.mDirPath[157]);
    s.Write(this.mDirPath[158]);
    s.Write(this.mDirPath[159]);
    s.Write(this.mDirPath[160 /*0xA0*/]);
    s.Write(this.mDirPath[161]);
    s.Write(this.mDirPath[162]);
    s.Write(this.mDirPath[163]);
    s.Write(this.mDirPath[164]);
    s.Write(this.mDirPath[165]);
    s.Write(this.mDirPath[166]);
    s.Write(this.mDirPath[167]);
    s.Write(this.mDirPath[168]);
    s.Write(this.mDirPath[169]);
    s.Write(this.mDirPath[170]);
    s.Write(this.mDirPath[171]);
    s.Write(this.mDirPath[172]);
    s.Write(this.mDirPath[173]);
    s.Write(this.mDirPath[174]);
    s.Write(this.mDirPath[175]);
    s.Write(this.mDirPath[176 /*0xB0*/]);
    s.Write(this.mDirPath[177]);
    s.Write(this.mDirPath[178]);
    s.Write(this.mDirPath[179]);
    s.Write(this.mDirPath[180]);
    s.Write(this.mDirPath[181]);
    s.Write(this.mDirPath[182]);
    s.Write(this.mDirPath[183]);
    s.Write(this.mDirPath[184]);
    s.Write(this.mDirPath[185]);
    s.Write(this.mDirPath[186]);
    s.Write(this.mDirPath[187]);
    s.Write(this.mDirPath[188]);
    s.Write(this.mDirPath[189]);
    s.Write(this.mDirPath[190]);
    s.Write(this.mDirPath[191]);
    s.Write(this.mDirPath[192 /*0xC0*/]);
    s.Write(this.mDirPath[193]);
    s.Write(this.mDirPath[194]);
    s.Write(this.mDirPath[195]);
    s.Write(this.mDirPath[196]);
    s.Write(this.mDirPath[197]);
    s.Write(this.mDirPath[198]);
    s.Write(this.mDirPath[199]);
    s.Write(this.mDirPath[200]);
    s.Write(this.mDirPath[201]);
    s.Write(this.mDirPath[202]);
    s.Write(this.mDirPath[203]);
    s.Write(this.mDirPath[204]);
    s.Write(this.mDirPath[205]);
    s.Write(this.mDirPath[206]);
    s.Write(this.mDirPath[207]);
    s.Write(this.mDirPath[208 /*0xD0*/]);
    s.Write(this.mDirPath[209]);
    s.Write(this.mDirPath[210]);
    s.Write(this.mDirPath[211]);
    s.Write(this.mDirPath[212]);
    s.Write(this.mDirPath[213]);
    s.Write(this.mDirPath[214]);
    s.Write(this.mDirPath[215]);
    s.Write(this.mDirPath[216]);
    s.Write(this.mDirPath[217]);
    s.Write(this.mDirPath[218]);
    s.Write(this.mDirPath[219]);
    s.Write(this.mDirPath[220]);
    s.Write(this.mDirPath[221]);
    s.Write(this.mDirPath[222]);
    s.Write(this.mDirPath[223]);
    s.Write(this.mDirPath[224 /*0xE0*/]);
    s.Write(this.mDirPath[225]);
    s.Write(this.mDirPath[226]);
    s.Write(this.mDirPath[227]);
    s.Write(this.mDirPath[228]);
    s.Write(this.mDirPath[229]);
    s.Write(this.mDirPath[230]);
    s.Write(this.mDirPath[231]);
    s.Write(this.mDirPath[232]);
    s.Write(this.mDirPath[233]);
    s.Write(this.mDirPath[234]);
    s.Write(this.mDirPath[235]);
    s.Write(this.mDirPath[236]);
    s.Write(this.mDirPath[237]);
    s.Write(this.mDirPath[238]);
    s.Write(this.mDirPath[239]);
    s.Write(this.mFlags);
  }

  internal override void DeserializeBody(BinaryReader s)
  {
    this.mTransferUid = s.ReadUInt64();
    this.mDirPath[0] = s.ReadChar();
    this.mDirPath[1] = s.ReadChar();
    this.mDirPath[2] = s.ReadChar();
    this.mDirPath[3] = s.ReadChar();
    this.mDirPath[4] = s.ReadChar();
    this.mDirPath[5] = s.ReadChar();
    this.mDirPath[6] = s.ReadChar();
    this.mDirPath[7] = s.ReadChar();
    this.mDirPath[8] = s.ReadChar();
    this.mDirPath[9] = s.ReadChar();
    this.mDirPath[10] = s.ReadChar();
    this.mDirPath[11] = s.ReadChar();
    this.mDirPath[12] = s.ReadChar();
    this.mDirPath[13] = s.ReadChar();
    this.mDirPath[14] = s.ReadChar();
    this.mDirPath[15] = s.ReadChar();
    this.mDirPath[16 /*0x10*/] = s.ReadChar();
    this.mDirPath[17] = s.ReadChar();
    this.mDirPath[18] = s.ReadChar();
    this.mDirPath[19] = s.ReadChar();
    this.mDirPath[20] = s.ReadChar();
    this.mDirPath[21] = s.ReadChar();
    this.mDirPath[22] = s.ReadChar();
    this.mDirPath[23] = s.ReadChar();
    this.mDirPath[24] = s.ReadChar();
    this.mDirPath[25] = s.ReadChar();
    this.mDirPath[26] = s.ReadChar();
    this.mDirPath[27] = s.ReadChar();
    this.mDirPath[28] = s.ReadChar();
    this.mDirPath[29] = s.ReadChar();
    this.mDirPath[30] = s.ReadChar();
    this.mDirPath[31 /*0x1F*/] = s.ReadChar();
    this.mDirPath[32 /*0x20*/] = s.ReadChar();
    this.mDirPath[33] = s.ReadChar();
    this.mDirPath[34] = s.ReadChar();
    this.mDirPath[35] = s.ReadChar();
    this.mDirPath[36] = s.ReadChar();
    this.mDirPath[37] = s.ReadChar();
    this.mDirPath[38] = s.ReadChar();
    this.mDirPath[39] = s.ReadChar();
    this.mDirPath[40] = s.ReadChar();
    this.mDirPath[41] = s.ReadChar();
    this.mDirPath[42] = s.ReadChar();
    this.mDirPath[43] = s.ReadChar();
    this.mDirPath[44] = s.ReadChar();
    this.mDirPath[45] = s.ReadChar();
    this.mDirPath[46] = s.ReadChar();
    this.mDirPath[47] = s.ReadChar();
    this.mDirPath[48 /*0x30*/] = s.ReadChar();
    this.mDirPath[49] = s.ReadChar();
    this.mDirPath[50] = s.ReadChar();
    this.mDirPath[51] = s.ReadChar();
    this.mDirPath[52] = s.ReadChar();
    this.mDirPath[53] = s.ReadChar();
    this.mDirPath[54] = s.ReadChar();
    this.mDirPath[55] = s.ReadChar();
    this.mDirPath[56] = s.ReadChar();
    this.mDirPath[57] = s.ReadChar();
    this.mDirPath[58] = s.ReadChar();
    this.mDirPath[59] = s.ReadChar();
    this.mDirPath[60] = s.ReadChar();
    this.mDirPath[61] = s.ReadChar();
    this.mDirPath[62] = s.ReadChar();
    this.mDirPath[63 /*0x3F*/] = s.ReadChar();
    this.mDirPath[64 /*0x40*/] = s.ReadChar();
    this.mDirPath[65] = s.ReadChar();
    this.mDirPath[66] = s.ReadChar();
    this.mDirPath[67] = s.ReadChar();
    this.mDirPath[68] = s.ReadChar();
    this.mDirPath[69] = s.ReadChar();
    this.mDirPath[70] = s.ReadChar();
    this.mDirPath[71] = s.ReadChar();
    this.mDirPath[72] = s.ReadChar();
    this.mDirPath[73] = s.ReadChar();
    this.mDirPath[74] = s.ReadChar();
    this.mDirPath[75] = s.ReadChar();
    this.mDirPath[76] = s.ReadChar();
    this.mDirPath[77] = s.ReadChar();
    this.mDirPath[78] = s.ReadChar();
    this.mDirPath[79] = s.ReadChar();
    this.mDirPath[80 /*0x50*/] = s.ReadChar();
    this.mDirPath[81] = s.ReadChar();
    this.mDirPath[82] = s.ReadChar();
    this.mDirPath[83] = s.ReadChar();
    this.mDirPath[84] = s.ReadChar();
    this.mDirPath[85] = s.ReadChar();
    this.mDirPath[86] = s.ReadChar();
    this.mDirPath[87] = s.ReadChar();
    this.mDirPath[88] = s.ReadChar();
    this.mDirPath[89] = s.ReadChar();
    this.mDirPath[90] = s.ReadChar();
    this.mDirPath[91] = s.ReadChar();
    this.mDirPath[92] = s.ReadChar();
    this.mDirPath[93] = s.ReadChar();
    this.mDirPath[94] = s.ReadChar();
    this.mDirPath[95] = s.ReadChar();
    this.mDirPath[96 /*0x60*/] = s.ReadChar();
    this.mDirPath[97] = s.ReadChar();
    this.mDirPath[98] = s.ReadChar();
    this.mDirPath[99] = s.ReadChar();
    this.mDirPath[100] = s.ReadChar();
    this.mDirPath[101] = s.ReadChar();
    this.mDirPath[102] = s.ReadChar();
    this.mDirPath[103] = s.ReadChar();
    this.mDirPath[104] = s.ReadChar();
    this.mDirPath[105] = s.ReadChar();
    this.mDirPath[106] = s.ReadChar();
    this.mDirPath[107] = s.ReadChar();
    this.mDirPath[108] = s.ReadChar();
    this.mDirPath[109] = s.ReadChar();
    this.mDirPath[110] = s.ReadChar();
    this.mDirPath[111] = s.ReadChar();
    this.mDirPath[112 /*0x70*/] = s.ReadChar();
    this.mDirPath[113] = s.ReadChar();
    this.mDirPath[114] = s.ReadChar();
    this.mDirPath[115] = s.ReadChar();
    this.mDirPath[116] = s.ReadChar();
    this.mDirPath[117] = s.ReadChar();
    this.mDirPath[118] = s.ReadChar();
    this.mDirPath[119] = s.ReadChar();
    this.mDirPath[120] = s.ReadChar();
    this.mDirPath[121] = s.ReadChar();
    this.mDirPath[122] = s.ReadChar();
    this.mDirPath[123] = s.ReadChar();
    this.mDirPath[124] = s.ReadChar();
    this.mDirPath[125] = s.ReadChar();
    this.mDirPath[126] = s.ReadChar();
    this.mDirPath[(int) sbyte.MaxValue] = s.ReadChar();
    this.mDirPath[128 /*0x80*/] = s.ReadChar();
    this.mDirPath[129] = s.ReadChar();
    this.mDirPath[130] = s.ReadChar();
    this.mDirPath[131] = s.ReadChar();
    this.mDirPath[132] = s.ReadChar();
    this.mDirPath[133] = s.ReadChar();
    this.mDirPath[134] = s.ReadChar();
    this.mDirPath[135] = s.ReadChar();
    this.mDirPath[136] = s.ReadChar();
    this.mDirPath[137] = s.ReadChar();
    this.mDirPath[138] = s.ReadChar();
    this.mDirPath[139] = s.ReadChar();
    this.mDirPath[140] = s.ReadChar();
    this.mDirPath[141] = s.ReadChar();
    this.mDirPath[142] = s.ReadChar();
    this.mDirPath[143] = s.ReadChar();
    this.mDirPath[144 /*0x90*/] = s.ReadChar();
    this.mDirPath[145] = s.ReadChar();
    this.mDirPath[146] = s.ReadChar();
    this.mDirPath[147] = s.ReadChar();
    this.mDirPath[148] = s.ReadChar();
    this.mDirPath[149] = s.ReadChar();
    this.mDirPath[150] = s.ReadChar();
    this.mDirPath[151] = s.ReadChar();
    this.mDirPath[152] = s.ReadChar();
    this.mDirPath[153] = s.ReadChar();
    this.mDirPath[154] = s.ReadChar();
    this.mDirPath[155] = s.ReadChar();
    this.mDirPath[156] = s.ReadChar();
    this.mDirPath[157] = s.ReadChar();
    this.mDirPath[158] = s.ReadChar();
    this.mDirPath[159] = s.ReadChar();
    this.mDirPath[160 /*0xA0*/] = s.ReadChar();
    this.mDirPath[161] = s.ReadChar();
    this.mDirPath[162] = s.ReadChar();
    this.mDirPath[163] = s.ReadChar();
    this.mDirPath[164] = s.ReadChar();
    this.mDirPath[165] = s.ReadChar();
    this.mDirPath[166] = s.ReadChar();
    this.mDirPath[167] = s.ReadChar();
    this.mDirPath[168] = s.ReadChar();
    this.mDirPath[169] = s.ReadChar();
    this.mDirPath[170] = s.ReadChar();
    this.mDirPath[171] = s.ReadChar();
    this.mDirPath[172] = s.ReadChar();
    this.mDirPath[173] = s.ReadChar();
    this.mDirPath[174] = s.ReadChar();
    this.mDirPath[175] = s.ReadChar();
    this.mDirPath[176 /*0xB0*/] = s.ReadChar();
    this.mDirPath[177] = s.ReadChar();
    this.mDirPath[178] = s.ReadChar();
    this.mDirPath[179] = s.ReadChar();
    this.mDirPath[180] = s.ReadChar();
    this.mDirPath[181] = s.ReadChar();
    this.mDirPath[182] = s.ReadChar();
    this.mDirPath[183] = s.ReadChar();
    this.mDirPath[184] = s.ReadChar();
    this.mDirPath[185] = s.ReadChar();
    this.mDirPath[186] = s.ReadChar();
    this.mDirPath[187] = s.ReadChar();
    this.mDirPath[188] = s.ReadChar();
    this.mDirPath[189] = s.ReadChar();
    this.mDirPath[190] = s.ReadChar();
    this.mDirPath[191] = s.ReadChar();
    this.mDirPath[192 /*0xC0*/] = s.ReadChar();
    this.mDirPath[193] = s.ReadChar();
    this.mDirPath[194] = s.ReadChar();
    this.mDirPath[195] = s.ReadChar();
    this.mDirPath[196] = s.ReadChar();
    this.mDirPath[197] = s.ReadChar();
    this.mDirPath[198] = s.ReadChar();
    this.mDirPath[199] = s.ReadChar();
    this.mDirPath[200] = s.ReadChar();
    this.mDirPath[201] = s.ReadChar();
    this.mDirPath[202] = s.ReadChar();
    this.mDirPath[203] = s.ReadChar();
    this.mDirPath[204] = s.ReadChar();
    this.mDirPath[205] = s.ReadChar();
    this.mDirPath[206] = s.ReadChar();
    this.mDirPath[207] = s.ReadChar();
    this.mDirPath[208 /*0xD0*/] = s.ReadChar();
    this.mDirPath[209] = s.ReadChar();
    this.mDirPath[210] = s.ReadChar();
    this.mDirPath[211] = s.ReadChar();
    this.mDirPath[212] = s.ReadChar();
    this.mDirPath[213] = s.ReadChar();
    this.mDirPath[214] = s.ReadChar();
    this.mDirPath[215] = s.ReadChar();
    this.mDirPath[216] = s.ReadChar();
    this.mDirPath[217] = s.ReadChar();
    this.mDirPath[218] = s.ReadChar();
    this.mDirPath[219] = s.ReadChar();
    this.mDirPath[220] = s.ReadChar();
    this.mDirPath[221] = s.ReadChar();
    this.mDirPath[222] = s.ReadChar();
    this.mDirPath[223] = s.ReadChar();
    this.mDirPath[224 /*0xE0*/] = s.ReadChar();
    this.mDirPath[225] = s.ReadChar();
    this.mDirPath[226] = s.ReadChar();
    this.mDirPath[227] = s.ReadChar();
    this.mDirPath[228] = s.ReadChar();
    this.mDirPath[229] = s.ReadChar();
    this.mDirPath[230] = s.ReadChar();
    this.mDirPath[231] = s.ReadChar();
    this.mDirPath[232] = s.ReadChar();
    this.mDirPath[233] = s.ReadChar();
    this.mDirPath[234] = s.ReadChar();
    this.mDirPath[235] = s.ReadChar();
    this.mDirPath[236] = s.ReadChar();
    this.mDirPath[237] = s.ReadChar();
    this.mDirPath[238] = s.ReadChar();
    this.mDirPath[239] = s.ReadChar();
    this.mFlags = s.ReadByte();
  }

  protected override void InitMetadata()
  {
    this.mMetadata = new UasMessageMetadata()
    {
      Description = "Get directory listing"
    };
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "TransferUid",
      Description = "Unique transfer ID",
      NumElements = 1
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "DirPath",
      Description = "Directory path to list",
      NumElements = 240 /*0xF0*/
    });
    this.mMetadata.Fields.Add(new UasFieldMetadata()
    {
      Name = "Flags",
      Description = "RESERVED",
      NumElements = 1
    });
  }
}
