// Decompiled with JetBrains decompiler
// Type: Wpfbootload.FData
// Assembly: Wpfbootload, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4FEF84E1-06E0-4569-8BB0-07C571E890DC
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\Wpfbootload.exe

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

#nullable disable
namespace Wpfbootload;

public class FData
{
  private string _targetSystem;
  private string _softwareVersion;
  private string _date;
  private uint _crc32;
  private long _filesize;
  private FileStream _file;
  private byte[] _getfd;
  private bool _isEncrypt;
  private bool _error;

  public FileStream FD
  {
    get => this._file;
    set => this._file = value;
  }

  public long FS
  {
    get => this._filesize;
    set => this._filesize = value;
  }

  public string TargetSystem => this._targetSystem;

  public string SoftwareVersion => this._softwareVersion;

  public string Date => this._date;

  public uint Crc32 => this._crc32;

  public byte[] Getfd => this._getfd;

  public bool IsEncrypt => this._isEncrypt;

  public bool Error => this._error;

  public FData()
  {
  }

  public FData(string filename)
  {
    switch (filename.Split('.')[filename.Split('.').Length - 1])
    {
      case "yuneec":
        this._isEncrypt = true;
        FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
        StreamReader streamReader = new StreamReader((Stream) fileStream, Encoding.Default);
        string text = streamReader.ReadLine();
        streamReader.Dispose();
        streamReader.Close();
        fileStream.Close();
        this._file = File.OpenRead(filename);
        if (text != null)
        {
          this._filesize = this._file.Length - (long) text.Length - 2L;
          this._getfd = new byte[this._filesize];
          this._file.Read(new byte[text.Length + 2], 0, text.Length + 2);
          for (int index = 0; (long) index < this._filesize; ++index)
            this._getfd[index] = (byte) this._file.ReadByte();
          string str;
          try
          {
            str = this.AESDecryptbyte(text);
          }
          catch
          {
            break;
          }
          string[] strArray = str.Split(';');
          if (strArray.Length >= 4)
          {
            this._targetSystem = strArray[0];
            this._softwareVersion = strArray[1];
            this._date = strArray[2];
            this._crc32 = Convert.ToUInt32(strArray[3]);
            if (strArray[0].ToLower().Contains("esc"))
            {
              RijndaelManaged rijndaelManaged = new RijndaelManaged();
              rijndaelManaged.Mode = CipherMode.ECB;
              rijndaelManaged.Padding = PaddingMode.None;
              rijndaelManaged.KeySize = 256 /*0x0100*/;
              rijndaelManaged.BlockSize = 128 /*0x80*/;
              rijndaelManaged.Key = DECRYPT.key_file;
              this._getfd = rijndaelManaged.CreateDecryptor().TransformFinalBlock(this._getfd, 0, this._getfd.Length);
            }
            else if (!strArray[0].ToLower().Contains("wizard") && !strArray[0].ToLower().Contains("cgo"))
            {
              if (strArray[0].ToLower().Contains("foc"))
              {
                RijndaelManaged rijndaelManaged = new RijndaelManaged();
                rijndaelManaged.Mode = CipherMode.ECB;
                rijndaelManaged.Padding = PaddingMode.None;
                rijndaelManaged.KeySize = 256 /*0x0100*/;
                rijndaelManaged.BlockSize = 128 /*0x80*/;
                rijndaelManaged.Key = DECRYPT.key_file;
                this._getfd = rijndaelManaged.CreateDecryptor().TransformFinalBlock(this._getfd, 0, this._getfd.Length);
              }
              else if (strArray[0].ToLower().Contains("bldc"))
              {
                RijndaelManaged rijndaelManaged = new RijndaelManaged();
                rijndaelManaged.Mode = CipherMode.ECB;
                rijndaelManaged.Padding = PaddingMode.None;
                rijndaelManaged.KeySize = 256 /*0x0100*/;
                rijndaelManaged.BlockSize = 128 /*0x80*/;
                rijndaelManaged.Key = DECRYPT.key_file;
                this._getfd = rijndaelManaged.CreateDecryptor().TransformFinalBlock(this._getfd, 0, this._getfd.Length);
              }
              else if (strArray[0].ToLower().Contains("bat"))
              {
                RijndaelManaged rijndaelManaged = new RijndaelManaged();
                rijndaelManaged.Mode = CipherMode.ECB;
                rijndaelManaged.Padding = PaddingMode.None;
                rijndaelManaged.KeySize = 256 /*0x0100*/;
                rijndaelManaged.BlockSize = 128 /*0x80*/;
                rijndaelManaged.Key = DECRYPT.key_file;
                this._getfd = rijndaelManaged.CreateDecryptor().TransformFinalBlock(this._getfd, 0, this._getfd.Length);
                this._isEncrypt = false;
              }
              else if (DECRYPT.decrypt)
              {
                RijndaelManaged rijndaelManaged = new RijndaelManaged();
                rijndaelManaged.Mode = CipherMode.ECB;
                rijndaelManaged.Padding = PaddingMode.None;
                rijndaelManaged.KeySize = 256 /*0x0100*/;
                rijndaelManaged.BlockSize = 128 /*0x80*/;
                rijndaelManaged.Key = DECRYPT.key_file;
                this._getfd = rijndaelManaged.CreateDecryptor().TransformFinalBlock(this._getfd, 0, this._getfd.Length);
                this._isEncrypt = false;
              }
            }
          }
          else
            break;
        }
        this._file.Close();
        return;
      case "bin":
        string str1 = filename.Split('\\')[filename.Split('\\').Length - 1];
        this._targetSystem = !str1.ToLower().Contains("esc") ? (!str1.ToLower().Contains("cgo") ? "FC" : "CGO") : "ESC";
        this._isEncrypt = false;
        this._file = File.OpenRead(filename);
        this._filesize = this._file.Length;
        this._getfd = new byte[this._filesize];
        for (int index = 0; (long) index < this._filesize; ++index)
          this._getfd[index] = (byte) this._file.ReadByte();
        this._file.Close();
        new Thread((ThreadStart) (() =>
        {
          byte[] numArray = new byte[4];
          uint state = 0;
          for (int sourceIndex = 0; sourceIndex < this._getfd.Length; sourceIndex += 4)
          {
            Array.Copy((Array) this._getfd, sourceIndex, (Array) numArray, 0, 4);
            state = this.crc32(numArray, 4, state);
          }
          for (long length = (long) this._getfd.Length; length < 983040L /*0x0F0000*/; length += 4L)
            state = this.crc32(new byte[4]
            {
              byte.MaxValue,
              byte.MaxValue,
              byte.MaxValue,
              byte.MaxValue
            }, 4, state);
          this._crc32 = state;
        })).Start();
        return;
    }
    this._error = true;
  }

  private string AESDecryptbyte(string text)
  {
    string s = "2015-10-10#YUNEEC#2017-10-10#000";
    RijndaelManaged rijndaelManaged = new RijndaelManaged();
    rijndaelManaged.Mode = CipherMode.ECB;
    rijndaelManaged.Padding = PaddingMode.Zeros;
    rijndaelManaged.Key = Encoding.UTF8.GetBytes(s);
    ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor();
    byte[] numArray = Convert.FromBase64String(text);
    byte[] inputBuffer = numArray;
    int length = numArray.Length;
    return Encoding.UTF8.GetString(decryptor.TransformFinalBlock(inputBuffer, 0, length));
  }

  private uint crc32(byte[] src, int len, uint state)
  {
    uint[] numArray = new uint[256 /*0x0100*/];
    if (numArray[1] == 0U)
    {
      for (uint index1 = 0; index1 < 256U /*0x0100*/; ++index1)
      {
        uint num = index1;
        for (int index2 = 0; index2 < 8; ++index2)
        {
          if (((int) num & 1) == 1)
            num = 3988292384U ^ num >> 1;
          else
            num >>= 1;
        }
        numArray[(int) index1] = num;
      }
    }
    for (int index = 0; index < len; ++index)
      state = numArray[((int) state ^ (int) src[index]) & (int) byte.MaxValue] ^ state >> 8;
    return state;
  }
}
