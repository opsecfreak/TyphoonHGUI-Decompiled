// Decompiled with JetBrains decompiler
// Type: Wpfbootload.BootClass.EscUpDataFirmware
// Assembly: Wpfbootload, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4FEF84E1-06E0-4569-8BB0-07C571E890DC
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\Wpfbootload.exe

using MavLinkNet;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using YCustomControlLibrary;
using YuneecLinkNet;

#nullable disable
namespace Wpfbootload.BootClass;

internal class EscUpDataFirmware(FData file) : CommonUpDataFirmware(file)
{
  private bool _flagMain = true;
  private bool _flagSec = true;
  private bool _restart;
  private long _countEsc;
  private int _crcCountEsc;
  private long _sendtimeEsc;
  private int _crctimeEsc;
  private int _outimecount;
  private readonly int[] _number = new int[6]
  {
    0,
    1,
    2,
    3,
    4,
    5
  };
  private int _numberT;
  private readonly List<int> _wcfnumber = new List<int>();
  private readonly AutoResetEvent _mSendSignalMain = new AutoResetEvent(false);
  private MavLinkSerialPortTransport _serialportMavlink;
  private YuneecSerialPortTransport _serialportYuneeclink;
  private Timer _timerout;

  protected override void ThreadUpDataFirmware()
  {
    this.IsAction = true;
    this.Maximum = this.File.FS / 32L /*0x20*/ * 6L;
    this.IsGetSoftware = false;
    this.IsReboot = false;
    this._countEsc = this.File.FS % 32L /*0x20*/ != 0L ? this.File.FS / 32L /*0x20*/ + 1L : this.File.FS / 32L /*0x20*/;
    this._crcCountEsc = this.File.FS % 128L /*0x80*/ != 0L ? (int) this.File.FS / 128 /*0x80*/ + 1 : (int) this.File.FS / 128 /*0x80*/;
    this._wcfnumber.Clear();
    try
    {
      for (byte index = 4; index < (byte) 10; ++index)
      {
        this._flagMain = true;
        this._flagSec = true;
        this._restart = false;
        this._mSendSignalMain.Reset();
        this._serialportMavlink = new MavLinkSerialPortTransport()
        {
          SerialPortName = this.Port,
          BaudRate = 115200
        };
        this._serialportMavlink.Initialize();
        this._serialportMavlink.OnPacketReceived += new MavLinkNet.PacketReceivedDelegate(this.Mavlink_OnPacketReceived);
        this._numberT = (int) index - 4;
        while (this._flagMain)
        {
          this._serialportMavlink.SendMessage((MavLinkNet.UasMessage) new UasCommandLong()
          {
            TargetSystem = (byte) 1,
            TargetComponent = (byte) 1,
            Command = MavCmd.PreflightRebootShutdown,
            Confirmation = (byte) 0,
            Param1 = (float) index,
            Param2 = 0.0f,
            Param3 = 0.0f,
            Param4 = 0.0f
          });
          Thread.Sleep(1000);
        }
        this._mSendSignalMain.WaitOne();
        if (this._wcfnumber.Count > 0 && this._wcfnumber[this._wcfnumber.Count - 1] == this._numberT && this._wcfnumber.FindAll((Predicate<int>) (p => p == this._numberT)).Count < 2)
        {
          this.Log = $"{this.Log}{(object) this._numberT}: Try again............{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r";
          --index;
        }
        Thread.Sleep(500);
        if (this._restart)
          break;
      }
      if (!this._restart)
      {
        this._serialportMavlink = new MavLinkSerialPortTransport()
        {
          SerialPortName = this.Port,
          BaudRate = 115200
        };
        this._serialportMavlink.Initialize();
        this._serialportMavlink.OnPacketReceived += new MavLinkNet.PacketReceivedDelegate(this.Mavlink_OnPacketReceived);
        this._numberT = 6;
        while (this._flagMain)
        {
          this._serialportMavlink.SendMessage((MavLinkNet.UasMessage) new UasCommandLong()
          {
            TargetSystem = (byte) 1,
            TargetComponent = (byte) 1,
            Command = MavCmd.PreflightRebootShutdown,
            Confirmation = (byte) 0,
            Param1 = 9f,
            Param2 = 0.0f,
            Param3 = 0.0f,
            Param4 = 0.0f
          });
          Thread.Sleep(1000);
        }
      }
      if (this._wcfnumber.Count > 0)
      {
        this._wcfnumber.ForEach((Action<int>) (p => this.Log = $"{this.Log}{(object) p},"));
        this.Log += "CRC FAILED.";
      }
      else if (this.Maximum == this.Barvalue)
      {
        int num = (int) YMessageBox.Show("Flash suceessful!", "Note");
      }
      try
      {
        this._serialportMavlink.OnPacketReceived -= new MavLinkNet.PacketReceivedDelegate(this.Mavlink_OnPacketReceived);
        this._serialportMavlink.Dispose();
        this._serialportYuneeclink.OnPacketReceived -= new YuneecLinkNet.PacketReceivedDelegate(this.serialportYuneeclink_OnPacketReceived);
        this._serialportYuneeclink.Dispose();
      }
      catch
      {
        this._serialportYuneeclink.OnPacketReceived -= new YuneecLinkNet.PacketReceivedDelegate(this.serialportYuneeclink_OnPacketReceived);
        this._serialportYuneeclink.Dispose();
      }
    }
    catch (Exception ex)
    {
      this.Log = $"{this.Log}{ex.Message}\r\n";
    }
    finally
    {
      this.IsAction = false;
      this.IsGetSoftware = true;
      this.IsdownLoad = true;
      this.IsReboot = true;
      this.DownLoad = "Update";
    }
  }

  private void Mavlink_OnPacketReceived(object sender, MavLinkPacket packet)
  {
    if (packet.MessageId != (byte) 77)
      return;
    this._flagMain = false;
    if (this._numberT == 6)
      return;
    if (packet.Message is UasCommandAck message && message.Result == MavResult.Accepted)
    {
      this._serialportMavlink.OnPacketReceived -= new MavLinkNet.PacketReceivedDelegate(this.Mavlink_OnPacketReceived);
      this._serialportMavlink.Dispose();
      this._serialportYuneeclink = new YuneecSerialPortTransport()
      {
        SerialPortName = this.Port,
        BaudRate = 115200
      };
      this._serialportYuneeclink.Initialize();
      this._serialportYuneeclink.OnPacketReceived += new YuneecLinkNet.PacketReceivedDelegate(this.serialportYuneeclink_OnPacketReceived);
      this.Log = $"{this.Log}{(object) this._numberT}: Waiting ack............{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r";
      this._sendtimeEsc = 0L;
      this._crctimeEsc = 0;
      while (this._flagSec)
      {
        this._serialportYuneeclink.SendMessage((YuneecLinkNet.UasMessage) new EscBLSync()
        {
          Ack = (byte) this._number[this._numberT]
        });
        Thread.Sleep(1000);
      }
    }
    else
      this.Log += "\r\n";
  }

  private void serialportYuneeclink_OnPacketReceived(object sender, YuneecLinkPacket packet)
  {
    if (packet.MessageId == (byte) 16 /*0x10*/)
    {
      if (this._flagSec)
      {
        this.Log = $"{this.Log}{(object) this._numberT}: Erase..........{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r";
        this._flagSec = false;
        this._sendtimeEsc = 0L;
        this._crctimeEsc = 0;
        this._serialportYuneeclink.SendMessage((YuneecLinkNet.UasMessage) new EscBLErase()
        {
          Ack = (byte) this._number[this._numberT]
        });
      }
      else
      {
        DateTime now;
        if (this._sendtimeEsc == 0L)
        {
          object[] objArray = new object[5]
          {
            (object) this.Log,
            (object) this._numberT,
            (object) ": Program..........",
            null,
            null
          };
          now = DateTime.Now;
          objArray[3] = (object) now.ToString("yyyy-MM-dd HH:mm:ss");
          objArray[4] = (object) "\r";
          this.Log = string.Concat(objArray);
        }
        if (this._sendtimeEsc <= this._countEsc - 1L)
        {
          this.Barvalue = (long) this._numberT * this._countEsc + this._sendtimeEsc > this.Maximum ? this.Maximum : (long) this._numberT * this._countEsc + this._sendtimeEsc;
          EscBLProgram msg = new EscBLProgram()
          {
            ID = (byte) this._number[this._numberT]
          };
          if (this._sendtimeEsc == this._countEsc - 1L)
          {
            if (this.File.FS % 32L /*0x20*/ == 0L)
            {
              Array.Copy((Array) this.File.Getfd, 32 /*0x20*/ * (int) this._sendtimeEsc, (Array) msg.Program, 0, 32 /*0x20*/);
            }
            else
            {
              Array.Copy((Array) this.File.Getfd, (long) (32 /*0x20*/ * (int) this._sendtimeEsc), (Array) msg.Program, 0L, this.File.FS % 32L /*0x20*/);
              for (long index = this.File.FS % 32L /*0x20*/; index < 32L /*0x20*/; ++index)
                msg.Program[index] = byte.MaxValue;
            }
          }
          else
            Array.Copy((Array) this.File.Getfd, 32 /*0x20*/ * (int) this._sendtimeEsc, (Array) msg.Program, 0, 32 /*0x20*/);
          this._serialportYuneeclink.SendMessage((YuneecLinkNet.UasMessage) msg);
          ++this._sendtimeEsc;
        }
        else if (this._crctimeEsc == this._crcCountEsc + 1)
        {
          this._timerout.Dispose();
          object[] objArray = new object[5]
          {
            (object) this.Log,
            (object) this._numberT,
            (object) ": Successfully.................",
            null,
            null
          };
          now = DateTime.Now;
          objArray[3] = (object) now.ToString("yyyy-MM-dd HH:mm:ss");
          objArray[4] = (object) "\r";
          this.Log = string.Concat(objArray);
          this._serialportYuneeclink.OnPacketReceived -= new YuneecLinkNet.PacketReceivedDelegate(this.serialportYuneeclink_OnPacketReceived);
          this._serialportYuneeclink.Dispose();
          this._mSendSignalMain.Set();
        }
        else if (this._crctimeEsc == this._crcCountEsc)
        {
          int index = this._wcfnumber.FindIndex((Predicate<int>) (p => p == this._numberT));
          if (index != -1)
            this._wcfnumber.RemoveAt(index);
          this._serialportYuneeclink.SendMessage((YuneecLinkNet.UasMessage) new EscBLReboot()
          {
            Ack = (byte) this._number[this._numberT]
          });
          ++this._crctimeEsc;
          this._outimecount = 0;
          this._timerout = new Timer(new TimerCallback(this.TimeroutCall), (object) null, 100, 100);
        }
        else
        {
          byte[] numArray = new byte[128 /*0x80*/];
          if (this._crctimeEsc == this._crcCountEsc - 1)
          {
            if (this.File.FS % 128L /*0x80*/ == 0L)
            {
              Array.Copy((Array) this.File.Getfd, 128 /*0x80*/ * this._crctimeEsc, (Array) numArray, 0, 128 /*0x80*/);
            }
            else
            {
              Array.Copy((Array) this.File.Getfd, (long) (128 /*0x80*/ * this._crctimeEsc), (Array) numArray, 0L, this.File.FS % 128L /*0x80*/);
              for (long index = this.File.FS % 128L /*0x80*/; index < 128L /*0x80*/; ++index)
                numArray[index] = byte.MaxValue;
            }
          }
          else
            Array.Copy((Array) this.File.Getfd, 128 /*0x80*/ * this._crctimeEsc, (Array) numArray, 0, 128 /*0x80*/);
          EscBLCRC msg = new EscBLCRC()
          {
            ID = (byte) this._number[this._numberT],
            CRC = YuneecLinkPacket.PCRC8(numArray)
          };
          msg.Adress[0] = (byte) (128 /*0x80*/ * this._crctimeEsc);
          msg.Adress[1] = (byte) (128 /*0x80*/ * this._crctimeEsc >> 8);
          this._serialportYuneeclink.SendMessage((YuneecLinkNet.UasMessage) msg);
          ++this._crctimeEsc;
        }
      }
    }
    else if (this._crctimeEsc > 0)
    {
      this.Log = $"{this.Log}{(object) this._numberT}: CRC FAILED.................{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r";
      this._wcfnumber.Add(this._numberT);
      this._serialportYuneeclink.OnPacketReceived -= new YuneecLinkNet.PacketReceivedDelegate(this.serialportYuneeclink_OnPacketReceived);
      this._serialportYuneeclink.Dispose();
      this._mSendSignalMain.Set();
    }
    else
      this.Log = $"{this.Log}{(object) this._numberT}: PROGRAM FAILED.................{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r";
  }

  private void TimeroutCall(object obj)
  {
    if (this._outimecount > 2)
    {
      this._timerout.Dispose();
      this.Log = $"{this.Log}{(object) this._numberT}: REBOOT FAILED.................{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r";
      if (this.DownLoad == "Reset")
      {
        this._flagMain = false;
        this._flagSec = false;
        this._restart = true;
        this._mSendSignalMain.Set();
        this.DownLoad = "Update";
        this.IsdownLoad = false;
      }
    }
    this._serialportYuneeclink.SendMessage((YuneecLinkNet.UasMessage) new EscBLReboot()
    {
      Ack = (byte) this._number[this._numberT]
    });
    ++this._outimecount;
  }

  protected override void DownLoad_Click(object sender, RoutedEventArgs e)
  {
    if (this.DownLoad == "Reset")
    {
      this._flagMain = false;
      this._flagSec = false;
      this._restart = true;
      this._mSendSignalMain.Set();
      this.DownLoad = "Update";
      this.IsdownLoad = false;
    }
    else
    {
      if (this.IsAction)
        return;
      this.Barvalue = 0L;
      this.DownLoad = "Reset";
      base.DownLoad_Click(sender, e);
    }
  }
}
