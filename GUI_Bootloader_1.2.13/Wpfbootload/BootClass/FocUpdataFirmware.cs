// Decompiled with JetBrains decompiler
// Type: Wpfbootload.BootClass.FocUpdataFirmware
// Assembly: Wpfbootload, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4FEF84E1-06E0-4569-8BB0-07C571E890DC
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\Wpfbootload.exe

using EscProtocol;
using MavLinkNet;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using YCustomControlLibrary;

#nullable disable
namespace Wpfbootload.BootClass;

internal class FocUpdataFirmware : CommonUpDataFirmware
{
  private bool _flagMain = true;
  private bool _flagSec = true;
  private bool _restart;
  private long _countEsc;
  private int _crcCountEsc;
  private ushort _sendtimeEsc;
  private ushort _crctimeEsc;
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
  private static EscUpDataPro UpDataPro = EscUpDataPro.Erase;
  private static EscUpDataPro WaitDataPro = EscUpDataPro.None;
  private byte _hardwareid;
  private string[] nums = new string[10]
  {
    "0",
    "1",
    "2",
    "3",
    "4",
    "5",
    "6",
    "7",
    "8",
    "9"
  };

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
        FocUpdataFirmware.UpDataPro = EscUpDataPro.Erase;
        this._mSendSignalMain.Reset();
        this._serialportMavlink = new MavLinkSerialPortTransport()
        {
          SerialPortName = this.Port,
          BaudRate = 115200
        };
        this._serialportMavlink.Initialize();
        this._serialportMavlink.OnPacketReceived += new PacketReceivedDelegate(this.Mavlink_OnPacketReceived);
        this._numberT = (int) index - 4;
        while (this._flagMain)
        {
          this._serialportMavlink.SendMessage((UasMessage) new UasCommandLong()
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
        this._serialportMavlink.OnPacketReceived += new PacketReceivedDelegate(this.Mavlink_OnPacketReceived);
        this._numberT = 6;
        while (this._flagMain)
        {
          this._serialportMavlink.SendMessage((UasMessage) new UasCommandLong()
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
      else if (this.Maximum <= this.Barvalue)
      {
        int num = (int) YMessageBox.Show("Flash suceessful!", "Note");
      }
      try
      {
        this._serialportMavlink.OnPacketReceived -= new PacketReceivedDelegate(this.Mavlink_OnPacketReceived);
        this._serialportMavlink.Dispose();
        // ISSUE: method pointer
        ((YuneecGenericTransport) this._serialportYuneeclink).OnPacketReceived -= new PacketReceivedDelegate((object) this, __methodptr(serialportYuneeclink_OnPacketReceived));
        ((YuneecGenericTransport) this._serialportYuneeclink).Dispose();
      }
      catch
      {
        // ISSUE: method pointer
        ((YuneecGenericTransport) this._serialportYuneeclink).OnPacketReceived -= new PacketReceivedDelegate((object) this, __methodptr(serialportYuneeclink_OnPacketReceived));
        ((YuneecGenericTransport) this._serialportYuneeclink).Dispose();
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
      this._serialportMavlink.OnPacketReceived -= new PacketReceivedDelegate(this.Mavlink_OnPacketReceived);
      this._serialportMavlink.Dispose();
      this._serialportYuneeclink = new YuneecSerialPortTransport()
      {
        SerialPortName = this.Port,
        BaudRate = 115200
      };
      ((YuneecGenericTransport) this._serialportYuneeclink).Initialize();
      // ISSUE: method pointer
      ((YuneecGenericTransport) this._serialportYuneeclink).OnPacketReceived += new PacketReceivedDelegate((object) this, __methodptr(serialportYuneeclink_OnPacketReceived));
      this.Log = $"{this.Log}{(object) this._numberT}: Waiting ack............{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r";
      this._sendtimeEsc = (ushort) 0;
      this._crctimeEsc = (ushort) 0;
      while (this._flagSec)
      {
        ((YuneecGenericTransport) this._serialportYuneeclink).SendMessage((UasMessage) new EscBLSync()
        {
          Ack = (byte) this._number[this._numberT],
          TargetSystemId = this._hardwareid
        });
        Thread.Sleep(1000);
      }
    }
    else
      this.Log += "\r\n";
  }

  private void serialportYuneeclink_OnPacketReceived(object sender, YuneecLinkPacket packet)
  {
    this._outimecount = 0;
    this._timerout?.Dispose();
    switch (packet.MessageId)
    {
      case 16 /*0x10*/:
        COMMAND_BYTES command = (packet.Message as EscOK).Command;
        switch (FocUpdataFirmware.UpDataPro)
        {
          case EscUpDataPro.None:
            FocUpdataFirmware.WaitDataPro = EscUpDataPro.None;
            // ISSUE: method pointer
            ((YuneecGenericTransport) this._serialportYuneeclink).OnPacketReceived -= new PacketReceivedDelegate((object) this, __methodptr(serialportYuneeclink_OnPacketReceived));
            ((YuneecGenericTransport) this._serialportYuneeclink).Dispose();
            this._mSendSignalMain.Set();
            return;
          case EscUpDataPro.Erase:
            FocUpdataFirmware.WaitDataPro = EscUpDataPro.Erase;
            if (command != 33)
              return;
            this._flagSec = false;
            this.Log = $"{this.Log}{(object) this._numberT}: Erase..........{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r";
            ((YuneecGenericTransport) this._serialportYuneeclink).SendMessage((UasMessage) new EscBLErase()
            {
              Ack = (byte) this._number[this._numberT]
            });
            FocUpdataFirmware.UpDataPro = EscUpDataPro.Program;
            this.Log = $"{this.Log}{(object) this._numberT}: Program..........{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r";
            this._timerout = new Timer(new TimerCallback(this.TimeroutCall), (object) null, 10000, 10000);
            return;
          case EscUpDataPro.Program:
            FocUpdataFirmware.WaitDataPro = EscUpDataPro.Program;
            if (command != 39 && command != 35)
              return;
            ++this.Barvalue;
            ushort num = (ushort) ((int) (packet.Message as EscOK).Extra + 1 & (int) ushort.MaxValue);
            this._sendtimeEsc = num;
            EscBLProgram escBlProgram = new EscBLProgram()
            {
              ID = (byte) this._number[this._numberT],
              Seq = num
            };
            if ((long) num == this._countEsc - 1L)
            {
              if (this.File.FS % 32L /*0x20*/ == 0L)
              {
                Array.Copy((Array) this.File.Getfd, 32 /*0x20*/ * (int) num, (Array) escBlProgram.Program, 0, 32 /*0x20*/);
              }
              else
              {
                Array.Copy((Array) this.File.Getfd, (long) (32 /*0x20*/ * (int) num), (Array) escBlProgram.Program, 0L, this.File.FS % 32L /*0x20*/);
                for (long index = this.File.FS % 32L /*0x20*/; index < 32L /*0x20*/; ++index)
                  escBlProgram.Program[index] = byte.MaxValue;
              }
              FocUpdataFirmware.UpDataPro = EscUpDataPro.Crc;
            }
            else
              Array.Copy((Array) this.File.Getfd, 32 /*0x20*/ * (int) num, (Array) escBlProgram.Program, 0, 32 /*0x20*/);
            ((YuneecGenericTransport) this._serialportYuneeclink).SendMessage((UasMessage) escBlProgram);
            this._timerout = new Timer(new TimerCallback(this.TimeroutCall), (object) null, 1000, 500);
            return;
          case EscUpDataPro.Crc:
            FocUpdataFirmware.WaitDataPro = EscUpDataPro.Crc;
            if (command != 41 && command != 39)
              return;
            EscOK message1 = packet.Message as EscOK;
            ushort sourceIndex = 0;
            if (command == 41)
              sourceIndex = (ushort) ((uint) message1.Extra + 128U /*0x80*/);
            this._crctimeEsc = sourceIndex;
            byte[] destinationArray = new byte[128 /*0x80*/];
            if (this.File.FS - (long) sourceIndex <= 128L /*0x80*/)
            {
              if (this.File.FS % 128L /*0x80*/ == 0L)
              {
                Array.Copy((Array) this.File.Getfd, (int) sourceIndex, (Array) destinationArray, 0, 128 /*0x80*/);
              }
              else
              {
                Array.Copy((Array) this.File.Getfd, (long) sourceIndex, (Array) destinationArray, 0L, this.File.FS % 128L /*0x80*/);
                for (long index = this.File.FS % 128L /*0x80*/; index < 128L /*0x80*/; ++index)
                  destinationArray[index] = byte.MaxValue;
              }
              FocUpdataFirmware.UpDataPro = EscUpDataPro.Reboot;
            }
            else
              Array.Copy((Array) this.File.Getfd, (int) sourceIndex, (Array) destinationArray, 0, 128 /*0x80*/);
            ((YuneecGenericTransport) this._serialportYuneeclink).SendMessage((UasMessage) new EscBLCRC()
            {
              ID = (byte) this._number[this._numberT],
              CRC = YuneecLinkPacket.PCRC8(destinationArray),
              Adress = sourceIndex
            });
            this._timerout = new Timer(new TimerCallback(this.TimeroutCall), (object) null, 1000, 500);
            return;
          case EscUpDataPro.Reboot:
            FocUpdataFirmware.WaitDataPro = EscUpDataPro.Reboot;
            this.Log = $"{this.Log}{(object) this._numberT}: Successfully..........{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r";
            ((YuneecGenericTransport) this._serialportYuneeclink).SendMessage((UasMessage) new EscBLReboot()
            {
              Ack = (byte) this._number[this._numberT],
              Version = Convert.ToUInt16(this.File.SoftwareVersion.Replace("v", "").Replace(".", "").Replace("V", ""))
            });
            FocUpdataFirmware.UpDataPro = EscUpDataPro.None;
            return;
          case EscUpDataPro.GetSV:
            this._flagSec = false;
            ((YuneecGenericTransport) this._serialportYuneeclink).SendMessage((UasMessage) new EscBLGetSoftwareVersion()
            {
              Ack = (byte) this._number[this._numberT]
            });
            return;
          case EscUpDataPro.GetHV:
            this._flagSec = false;
            ((YuneecGenericTransport) this._serialportYuneeclink).SendMessage((UasMessage) new EscBLGetHardwareVersion()
            {
              Ack = (byte) this._number[this._numberT]
            });
            return;
          default:
            return;
        }
      case 65:
        EscBLGetSoftwareVersionBack message2 = packet.Message as EscBLGetSoftwareVersionBack;
        ((YuneecGenericTransport) this._serialportYuneeclink).SendMessage((UasMessage) new EscBLReboot()
        {
          Ack = (byte) this._number[this._numberT],
          Version = message2.Version
        });
        FocUpdataFirmware.UpDataPro = EscUpDataPro.None;
        break;
      case 81:
        UasMessage message3 = packet.Message;
        ((YuneecGenericTransport) this._serialportYuneeclink).SendMessage((UasMessage) new EscBLGetSoftwareVersion()
        {
          Ack = (byte) this._number[this._numberT]
        });
        break;
      default:
        this.Log = $"{this.Log}{(object) FocUpdataFirmware.UpDataPro} FAILED...{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r";
        this._mSendSignalMain.Set();
        break;
    }
  }

  private void TimeroutCall(object obj)
  {
    if (this._outimecount > 10)
    {
      this._timerout?.Dispose();
      this.Log = $"{this.Log}{(object) FocUpdataFirmware.WaitDataPro} FAILED.................{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r";
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
    switch (FocUpdataFirmware.WaitDataPro)
    {
      case EscUpDataPro.Erase:
        ((YuneecGenericTransport) this._serialportYuneeclink).SendMessage((UasMessage) new EscBLErase()
        {
          Ack = (byte) this._number[this._numberT]
        });
        break;
      case EscUpDataPro.Program:
        EscBLProgram escBlProgram = new EscBLProgram()
        {
          ID = (byte) this._number[this._numberT],
          Seq = this._sendtimeEsc
        };
        if ((long) this._sendtimeEsc == this._countEsc - 1L)
        {
          if (this.File.FS % 32L /*0x20*/ == 0L)
          {
            Array.Copy((Array) this.File.Getfd, 32 /*0x20*/ * (int) this._sendtimeEsc, (Array) escBlProgram.Program, 0, 32 /*0x20*/);
          }
          else
          {
            Array.Copy((Array) this.File.Getfd, (long) (32 /*0x20*/ * (int) this._sendtimeEsc), (Array) escBlProgram.Program, 0L, this.File.FS % 32L /*0x20*/);
            for (long index = this.File.FS % 32L /*0x20*/; index < 32L /*0x20*/; ++index)
              escBlProgram.Program[index] = byte.MaxValue;
          }
          FocUpdataFirmware.UpDataPro = EscUpDataPro.Crc;
        }
        else
          Array.Copy((Array) this.File.Getfd, 32 /*0x20*/ * (int) this._sendtimeEsc, (Array) escBlProgram.Program, 0, 32 /*0x20*/);
        ((YuneecGenericTransport) this._serialportYuneeclink).SendMessage((UasMessage) escBlProgram);
        break;
      case EscUpDataPro.Crc:
        byte[] destinationArray = new byte[128 /*0x80*/];
        if (this.File.FS - (long) this._crctimeEsc <= 128L /*0x80*/)
        {
          if (this.File.FS % 128L /*0x80*/ == 0L)
          {
            Array.Copy((Array) this.File.Getfd, (int) this._crctimeEsc, (Array) destinationArray, 0, 128 /*0x80*/);
          }
          else
          {
            Array.Copy((Array) this.File.Getfd, (long) this._crctimeEsc, (Array) destinationArray, 0L, this.File.FS % 128L /*0x80*/);
            for (long index = this.File.FS % 128L /*0x80*/; index < 128L /*0x80*/; ++index)
              destinationArray[index] = byte.MaxValue;
          }
          FocUpdataFirmware.UpDataPro = EscUpDataPro.Reboot;
        }
        else
          Array.Copy((Array) this.File.Getfd, (int) this._crctimeEsc, (Array) destinationArray, 0, 128 /*0x80*/);
        ((YuneecGenericTransport) this._serialportYuneeclink).SendMessage((UasMessage) new EscBLCRC()
        {
          ID = (byte) this._number[this._numberT],
          CRC = YuneecLinkPacket.PCRC8(destinationArray),
          Adress = this._crctimeEsc
        });
        break;
      default:
        Timer timerout = this._timerout;
        if (timerout != null)
        {
          timerout.Dispose();
          break;
        }
        break;
    }
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

  public FocUpdataFirmware(FData file, byte hardwareid)
    : base(file)
  {
    this._hardwareid = hardwareid;
  }
}
