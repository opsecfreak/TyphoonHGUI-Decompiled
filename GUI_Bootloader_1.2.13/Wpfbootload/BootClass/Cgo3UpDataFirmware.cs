// Decompiled with JetBrains decompiler
// Type: Wpfbootload.BootClass.Cgo3UpDataFirmware
// Assembly: Wpfbootload, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4FEF84E1-06E0-4569-8BB0-07C571E890DC
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\Wpfbootload.exe

using System;
using System.IO.Ports;
using System.Windows;
using YCustomControlLibrary;

#nullable disable
namespace Wpfbootload.BootClass;

internal class Cgo3UpDataFirmware(FData file) : CommonUpDataFirmware(file)
{
  protected override void ThreadUpDataFirmware()
  {
    this.IsAction = true;
    this.IsdownLoad = false;
    this.Maximum = (long) (((int) this.File.FS / 2048 /*0x0800*/ + 1) * 4);
    this.Barvalue = 0L;
    this.Log = $"{this.Log}Waiting ack............{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r";
    byte[] buffer1 = new byte[1]{ (byte) 113 };
    try
    {
      SerialPort serialPort = new SerialPort()
      {
        PortName = this.Port,
        BaudRate = 921600 /*0x0E1000*/,
        WriteBufferSize = 4096 /*0x1000*/,
        ReadTimeout = 100
      };
      serialPort.Open();
      int num1 = 0;
      do
      {
        serialPort.Write(buffer1, 0, 1);
        try
        {
          if (serialPort.ReadByte() == 136)
            break;
        }
        catch (TimeoutException ex)
        {
          ++num1;
        }
      }
      while (num1 < 200);
      if (num1 < 200)
      {
        serialPort.ReadTimeout = 1000;
        string log1 = this.Log;
        DateTime now = DateTime.Now;
        string str1 = now.ToString("yyyy-MM-dd HH:mm:ss");
        this.Log = $"{log1}Successfully,waiting for 500ms to send data....{str1}\r";
        byte[] buffer2 = new byte[6];
        for (long index = 0; index < this.File.FS / 2048L /*0x0800*/ + 1L; ++index)
        {
          int num2 = index != this.File.FS / 2048L /*0x0800*/ ? 2048 /*0x0800*/ : (int) this.File.FS % 2048 /*0x0800*/;
          buffer2[0] = (byte) 114;
          buffer2[1] = (byte) 115;
          buffer2[2] = (byte) (num2 & (int) byte.MaxValue);
          buffer2[3] = (byte) (num2 >> 8 & (int) byte.MaxValue);
          buffer2[4] = (byte) (num2 >> 16 /*0x10*/ & (int) byte.MaxValue);
          buffer2[5] = (byte) (num2 >> 24 & (int) byte.MaxValue);
          serialPort.Write(buffer2, 0, 6);
          ++this.Barvalue;
          serialPort.Write(this.File.Getfd, (int) index * 2048 /*0x0800*/, num2);
          ++this.Barvalue;
          buffer2[0] = this.CRC8(this.File.Getfd, (int) index * 2048 /*0x0800*/, num2);
          buffer2[1] = (byte) 116;
          buffer2[2] = (byte) 117;
          ++this.Barvalue;
          if (index == this.File.FS / 2048L /*0x0800*/)
          {
            buffer2[1] = (byte) 118;
            buffer2[2] = (byte) 119;
          }
          serialPort.Write(buffer2, 0, 3);
          try
          {
            switch (serialPort.ReadByte())
            {
              case 16 /*0x10*/:
                string log2 = this.Log;
                now = DateTime.Now;
                string str2 = now.ToString("yyyy-MM-dd HH:mm:ss");
                this.Log = $"{log2}CRC calibration failed...............{str2}\r";
                goto label_23;
              case 17:
                string log3 = this.Log;
                now = DateTime.Now;
                string str3 = now.ToString("yyyy-MM-dd HH:mm:ss");
                this.Log = $"{log3}Flash successfully.............{str3}\r";
                goto label_23;
              case 153:
                object[] objArray = new object[6]
                {
                  (object) this.Log,
                  (object) "Block ",
                  (object) index,
                  (object) " complted.............",
                  null,
                  null
                };
                now = DateTime.Now;
                objArray[4] = (object) now.ToString("yyyy-MM-dd HH:mm:ss");
                objArray[5] = (object) "\r";
                this.Log = string.Concat(objArray);
                break;
            }
          }
          catch (TimeoutException ex)
          {
            goto label_23;
          }
          ++this.Barvalue;
        }
        try
        {
          switch (serialPort.ReadByte())
          {
            case 16 /*0x10*/:
              string log4 = this.Log;
              now = DateTime.Now;
              string str4 = now.ToString("yyyy-MM-dd HH:mm:ss");
              this.Log = $"{log4}CRC calibration failed...............{str4}\r";
              break;
            case 17:
              int num3 = (int) YMessageBox.Show("Flash successfully!", "Note");
              break;
          }
        }
        catch (TimeoutException ex)
        {
          serialPort.Close();
        }
      }
      else
        this.Log = $"{this.Log}Time out....{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r";
label_23:
      serialPort.Close();
    }
    catch (Exception ex)
    {
      this.Log = $"{this.Log}{ex.Message}............{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r";
    }
    finally
    {
      this.Barvalue = 0L;
      this.IsAction = false;
      this.IsdownLoad = true;
    }
  }

  private byte CRC8(byte[] buffer, int startlength, int length)
  {
    byte num = 0;
    for (int index1 = 0; index1 < length; ++index1)
    {
      num ^= buffer[startlength + index1];
      for (int index2 = 0; index2 < 8; ++index2)
      {
        if (((int) num & 1) != 0)
          num = (byte) ((uint) (byte) ((uint) num >> 1) ^ 140U);
        else
          num >>= 1;
      }
    }
    return num;
  }

  protected override void DownLoad_Click(object sender, RoutedEventArgs e)
  {
    if (this.IsAction)
      return;
    this.Barvalue = 0L;
    base.DownLoad_Click(sender, e);
  }
}
