// Decompiled with JetBrains decompiler
// Type: Wpfbootload.BootClass.FcUpDataFirmware
// Assembly: Wpfbootload, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4FEF84E1-06E0-4569-8BB0-07C571E890DC
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\Wpfbootload.exe

using System;
using System.IO.Ports;
using System.Threading;
using System.Windows;
using YCustomControlLibrary;

#nullable disable
namespace Wpfbootload.BootClass;

internal class FcUpDataFirmware : CommonUpDataFirmware
{
  public FcUpDataFirmware(FData file)
    : base(file)
  {
    this.IsReboot = true;
  }

  protected override void ThreadUpDataFirmware()
  {
    if (this.File.IsEncrypt)
      this.AsySendData_TyhoonH_N_S();
    else
      this.AsySendData_TyhoonH();
  }

  protected override void DownLoad_Click(object sender, RoutedEventArgs e)
  {
    if (this.IsAction)
      return;
    this.Barvalue = 0L;
    base.DownLoad_Click(sender, e);
  }

  private void AsySendData_TyhoonH()
  {
    this.IsAction = true;
    this.Maximum = this.File.FS / 48L /*0x30*/ + 1L;
    this.IsdownLoad = false;
    byte[] buffer1 = new byte[256 /*0x0100*/];
    byte[] buffer2 = new byte[2]{ (byte) 227, (byte) 186 };
    byte[] numArray1 = new byte[63 /*0x3F*/];
    byte[] buffer3 = new byte[2]{ (byte) 232, (byte) 186 };
    byte[] buffer4 = new byte[2]{ (byte) 229, (byte) 186 };
    int[] numArray2 = new int[2];
    numArray1[0] = (byte) 228;
    numArray1[1] = (byte) 60;
    numArray1[62] = (byte) 186;
    try
    {
      SerialPort serialPort = new SerialPort()
      {
        PortName = this.Port,
        BaudRate = 115200,
        WriteBufferSize = 4096 /*0x1000*/,
        ReadTimeout = 10000
      };
      Thread.Sleep(1000);
      serialPort.Open();
      serialPort.Write(buffer2, 0, 2);
      numArray2[0] = serialPort.ReadByte();
      numArray2[1] = serialPort.ReadByte();
      if (numArray2[0] != 171 || numArray2[1] != 240 /*0xF0*/)
      {
        serialPort.Close();
        throw new Exception("erase FAILED\r\n");
      }
      serialPort.DiscardInBuffer();
      ++this.Barvalue;
      for (int index1 = 0; index1 < this.File.Getfd.Length / 60 + 1; ++index1)
      {
        for (int index2 = 2; index2 < 62; ++index2)
          numArray1[index2] = byte.MaxValue;
        if (index1 == this.File.Getfd.Length / 60)
          Array.Copy((Array) this.File.Getfd, 60 * index1, (Array) numArray1, 2, this.File.Getfd.Length % 60);
        else
          Array.Copy((Array) this.File.Getfd, 60 * index1, (Array) numArray1, 2, 60);
        serialPort.Write(numArray1, 0, 63 /*0x3F*/);
        if (serialPort.ReadByte() != 171 || serialPort.ReadByte() != 240 /*0xF0*/)
        {
          serialPort.Close();
          throw new Exception("Program FAILED!");
        }
        ++this.Barvalue;
      }
      serialPort.DiscardInBuffer();
      serialPort.Write(buffer4, 0, 2);
      Thread.Sleep(500);
      serialPort.Read(buffer1, 0, 6);
      uint uint32 = BitConverter.ToUInt32(buffer1, 0);
      if (buffer1[4] != (byte) 171 || buffer1[5] != (byte) 240 /*0xF0*/ || (int) uint32 != (int) this.File.Crc32)
      {
        serialPort.Close();
        throw new Exception("CRC FAILED!");
      }
      serialPort.Write(buffer3, 0, 2);
      serialPort.Close();
      this.Barvalue = this.Maximum;
      int num = (int) YMessageBox.Show("Flash successfully!", "Note");
      this.Barvalue = 0L;
    }
    catch (Exception ex)
    {
      this.Log = $"{this.Log}{ex.Message}\r\n";
    }
    finally
    {
      this.IsAction = false;
      this.IsdownLoad = true;
      this.DownLoad = "Update";
    }
  }

  private void AsySendData_TyhoonH_N_S()
  {
    this.Maximum = this.File.FS / 48L /*0x30*/ + 1L;
    this.IsdownLoad = false;
    this.IsAction = true;
    byte[] buffer1 = new byte[256 /*0x0100*/];
    byte[] buffer2 = new byte[2]{ (byte) 227, (byte) 186 };
    byte[] numArray1 = new byte[51];
    byte[] buffer3 = new byte[2]{ (byte) 232, (byte) 186 };
    byte[] buffer4 = new byte[2]{ (byte) 229, (byte) 186 };
    int[] numArray2 = new int[2];
    numArray1[0] = (byte) 234;
    numArray1[1] = (byte) 48 /*0x30*/;
    numArray1[50] = (byte) 186;
    try
    {
      SerialPort serialPort = new SerialPort()
      {
        PortName = this.Port,
        BaudRate = 115200,
        WriteBufferSize = 4096 /*0x1000*/,
        ReadTimeout = 10000
      };
      serialPort.Open();
      serialPort.Write(buffer2, 0, 2);
      numArray2[0] = serialPort.ReadByte();
      numArray2[1] = serialPort.ReadByte();
      if (numArray2[0] != 171 || numArray2[1] != 240 /*0xF0*/)
      {
        serialPort.Close();
        throw new Exception("erase FAILED\r\n");
      }
      serialPort.DiscardInBuffer();
      ++this.Barvalue;
      for (int index = 0; index < this.File.Getfd.Length / 48 /*0x30*/; ++index)
      {
        Array.Copy((Array) this.File.Getfd, 48 /*0x30*/ * index, (Array) numArray1, 2, 48 /*0x30*/);
        serialPort.Write(numArray1, 0, 51);
        if (serialPort.ReadByte() != 171 || serialPort.ReadByte() != 240 /*0xF0*/)
        {
          serialPort.Close();
          throw new Exception("Program FAILED!");
        }
        ++this.Barvalue;
      }
      serialPort.DiscardInBuffer();
      serialPort.Write(buffer4, 0, 2);
      Thread.Sleep(500);
      serialPort.Read(buffer1, 0, 6);
      uint uint32 = BitConverter.ToUInt32(buffer1, 0);
      if (buffer1[4] != (byte) 171 || buffer1[5] != (byte) 240 /*0xF0*/ || (int) uint32 != (int) this.File.Crc32)
      {
        serialPort.Close();
        throw new Exception("CRC FAILED!");
      }
      serialPort.Write(buffer3, 0, 2);
      serialPort.Close();
      this.Barvalue = this.Maximum;
      int num = (int) YMessageBox.Show("Flash successfully!", "Note");
      this.Barvalue = 0L;
    }
    catch (Exception ex)
    {
      this.Log = $"{this.Log}{ex.Message}\r\n";
    }
    finally
    {
      this.IsAction = false;
      this.IsdownLoad = true;
      this.DownLoad = "Update";
    }
  }
}
