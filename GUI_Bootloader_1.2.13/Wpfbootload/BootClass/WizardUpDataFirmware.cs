// Decompiled with JetBrains decompiler
// Type: Wpfbootload.BootClass.WizardUpDataFirmware
// Assembly: Wpfbootload, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4FEF84E1-06E0-4569-8BB0-07C571E890DC
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\Wpfbootload.exe

using System;
using System.IO.Ports;
using System.Windows;
using YCustomControlLibrary;

#nullable disable
namespace Wpfbootload.BootClass;

internal class WizardUpDataFirmware(FData file) : CommonUpDataFirmware(file)
{
  protected override void DownLoad_Click(object sender, RoutedEventArgs e)
  {
    if (this.IsAction)
      return;
    this.Barvalue = 0L;
    base.DownLoad_Click(sender, e);
  }

  protected override void ThreadUpDataFirmware()
  {
    this.IsAction = true;
    this.IsdownLoad = false;
    this.Maximum = (this.File.FS / 2048L /*0x0800*/ + 1L) * 4L;
    this.Barvalue = 0L;
    this.Log = $"{this.Log}Waiting ack............{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r";
    byte[] buffer1 = new byte[2]{ (byte) 114, (byte) 114 };
    try
    {
      SerialPort serialPort = new SerialPort()
      {
        PortName = this.Port,
        BaudRate = 115200,
        WriteBufferSize = 4096 /*0x1000*/,
        ReadTimeout = 100
      };
      serialPort.Open();
      int num1 = 0;
      do
      {
        serialPort.Write(buffer1, 0, 2);
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
      while (num1 < 50);
      if (num1 < 50)
      {
        serialPort.ReadTimeout = 1000;
        this.Log = $"{this.Log}Successfully,waiting for 500ms to send data....{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r";
        byte[] buffer2 = new byte[4];
        for (long index = 0; index < this.File.FS / 2048L /*0x0800*/ + 1L; ++index)
        {
          int num2 = index != this.File.FS / 2048L /*0x0800*/ ? 2048 /*0x0800*/ : (int) this.File.FS % 2048 /*0x0800*/;
          buffer2[0] = (byte) 114;
          buffer2[1] = (byte) 115;
          buffer2[2] = (byte) (num2 / 64 /*0x40*/);
          buffer2[3] = (byte) (num2 % 64 /*0x40*/);
          serialPort.Write(buffer2, 0, 4);
          ++this.Barvalue;
          serialPort.Write(this.File.Getfd, (int) index * 2048 /*0x0800*/, num2);
          ++this.Barvalue;
          buffer2[0] = this.Crc8(this.File.Getfd, (int) index * 2048 /*0x0800*/, num2);
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
                int num3 = (int) YMessageBox.Show("CRC calibration failed!", "Note");
                goto label_22;
              case 17:
                int num4 = (int) YMessageBox.Show("Flash Successfully!", "Note");
                goto label_22;
            }
          }
          catch (TimeoutException ex)
          {
            goto label_22;
          }
          ++this.Barvalue;
        }
        try
        {
          switch (serialPort.ReadByte())
          {
            case 16 /*0x10*/:
              int num5 = (int) YMessageBox.Show("CRC calibration failed!", "Note");
              break;
            case 17:
              int num6 = (int) YMessageBox.Show("Flash Successfully!", "Note");
              break;
          }
        }
        catch (TimeoutException ex)
        {
          serialPort.Close();
        }
      }
      else
      {
        int num7 = (int) YMessageBox.Show("Time out!", "Note");
      }
label_22:
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

  public byte Crc8(byte[] buffer, int startlength, int length)
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
}
