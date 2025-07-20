// Decompiled with JetBrains decompiler
// Type: Wpfbootload.BootClass.BatEscUpdataFirmware
// Assembly: Wpfbootload, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4FEF84E1-06E0-4569-8BB0-07C571E890DC
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\Wpfbootload.exe

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;

#nullable disable
namespace Wpfbootload.BootClass;

internal class BatEscUpdataFirmware(FData file) : CommonUpDataFirmware(file)
{
  private IntPtr QM_DLL;
  private BatEscUpdataFirmware.TYPE_Init_can Init_can;
  private BatEscUpdataFirmware.TYPE_Quit_can Quit_can;
  private BatEscUpdataFirmware.TYPE_Can_send Can_send;
  private BatEscUpdataFirmware.TYPE_Can_receive Can_receive;
  private int _number;
  private UpdateBlock UpDataPro = UpdateBlock.Sync;
  private UpdateBlock CurrenctPro;
  private long _sendtimeEsc;
  private readonly AutoResetEvent _mSendSignalMain = new AutoResetEvent(false);
  private long _countEsc;
  private byte[] Ids = new byte[7]
  {
    (byte) 1,
    (byte) 2,
    (byte) 3,
    (byte) 4,
    (byte) 5,
    (byte) 6,
    (byte) 0
  };
  private byte defualt_id;
  private byte pc_id = 31 /*0x1F*/;
  private byte All = 16 /*0x10*/;
  private byte Buz = 19;
  private byte Boot_Sync = 32 /*0x20*/;
  private byte Boot_Erase = 33;
  private byte Boot_Program = 34;
  private byte Boot_Crc = 35;
  private byte Boot_Reboot = 36;

  [DllImport("kernel32.dll")]
  private static extern IntPtr LoadLibrary(string lpFileName);

  [DllImport("kernel32.dll")]
  private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

  private event ReceiveDelegate receiveHandle;

  private void LoadDll()
  {
    this.QM_DLL = BatEscUpdataFirmware.LoadLibrary("QM_USB.dll");
    if (this.QM_DLL != IntPtr.Zero)
    {
      IntPtr procAddress1 = BatEscUpdataFirmware.GetProcAddress(this.QM_DLL, "Init_can");
      IntPtr procAddress2 = BatEscUpdataFirmware.GetProcAddress(this.QM_DLL, "Quit_can");
      IntPtr procAddress3 = BatEscUpdataFirmware.GetProcAddress(this.QM_DLL, "Can_send");
      IntPtr procAddress4 = BatEscUpdataFirmware.GetProcAddress(this.QM_DLL, "Can_receive");
      this.Init_can = (BatEscUpdataFirmware.TYPE_Init_can) Marshal.GetDelegateForFunctionPointer(procAddress1, typeof (BatEscUpdataFirmware.TYPE_Init_can));
      this.Quit_can = (BatEscUpdataFirmware.TYPE_Quit_can) Marshal.GetDelegateForFunctionPointer(procAddress2, typeof (BatEscUpdataFirmware.TYPE_Quit_can));
      this.Can_send = (BatEscUpdataFirmware.TYPE_Can_send) Marshal.GetDelegateForFunctionPointer(procAddress3, typeof (BatEscUpdataFirmware.TYPE_Can_send));
      this.Can_receive = (BatEscUpdataFirmware.TYPE_Can_receive) Marshal.GetDelegateForFunctionPointer(procAddress4, typeof (BatEscUpdataFirmware.TYPE_Can_receive));
      Console.WriteLine("加载DLL成功");
    }
    else
      Console.WriteLine("加载DLL失败");
  }

  protected override void ThreadUpDataFirmware()
  {
    this._countEsc = this.File.FS % 8L != 0L ? this.File.FS / 8L + 1L : this.File.FS / 8L;
    this.Maximum = this._countEsc + 3L;
    this.LoadDll();
    switch (this.ConnectTarget())
    {
      case 0:
        Console.WriteLine("连接设备成功");
        new Thread(new ThreadStart(this.ReceiveThread))
        {
          IsBackground = true
        }.Start();
        break;
      case 1:
        Console.WriteLine("设备已连接");
        break;
      case 2:
        Console.WriteLine("无应答(端口有效无应答)");
        return;
      case 3:
        Console.WriteLine("无可用的串口(3-30)");
        return;
    }
    this.receiveHandle += new ReceiveDelegate(this.Program_receiveHandle);
    List<byte> byteList = new List<byte>();
    byteList.Add((byte) 1);
    byteList.Add((byte) 2);
    byteList.Add((byte) 3);
    byteList.Add((byte) 4);
    byteList.Add((byte) 5);
    byteList.Add((byte) 6);
    int index = 0;
    this.DownLoad = "Reset";
    while (byteList.Count != 0 && this.DownLoad == "Reset")
    {
      if (index > byteList.Count - 1)
        index = 0;
      this._number = (int) byteList[index];
      this.UpDataPro = UpdateBlock.Sync;
      this.CurrenctPro = UpdateBlock.None;
      this._sendtimeEsc = 0L;
      this._mSendSignalMain.Reset();
      this.UpDataPro = UpdateBlock.Sync;
      Console.WriteLine("Waiting ack...");
      this.Log = $"{this.Log}{(object) this._number}: Waiting ack...{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r";
      this.IsdownLoad = true;
      int num1;
      for (num1 = 0; this.UpDataPro == UpdateBlock.Sync && num1 < 10; ++num1)
      {
        byte[] IDbuff = new byte[4];
        byte[] Databuff = new byte[8];
        int num2 = (int) this.UpDataPro << 5 | this._number;
        IDbuff[0] = (byte) (num2 >> 8 & (int) byte.MaxValue);
        IDbuff[1] = (byte) (num2 & (int) byte.MaxValue);
        if (this.Can_send(IDbuff, Databuff, (byte) 0, (byte) 0) != 0)
        {
          Console.WriteLine(this.UpDataPro.ToString() + " 发送失败!");
          return;
        }
        Thread.Sleep(500);
      }
      if (num1 < 10)
      {
        this._mSendSignalMain.WaitOne();
        if (this.CurrenctPro == UpdateBlock.None)
          byteList.RemoveAt(index);
        else
          ++index;
      }
      else
        ++index;
    }
    this.receiveHandle -= new ReceiveDelegate(this.Program_receiveHandle);
    this.DownLoad = "Update";
    this.IsdownLoad = true;
  }

  private void ReceiveThread()
  {
    byte[] IDbuff = new byte[4];
    byte[] numArray = new byte[8];
    byte[] FreamType = new byte[1];
    byte[] Bytes = new byte[1];
label_1:
    int num1;
    do
    {
      num1 = this.Can_receive(IDbuff, numArray, FreamType, Bytes);
      if (num1 == 1)
      {
        Console.Write($"\r\n接收:{IDbuff[0].ToString("X2")} {IDbuff[1].ToString("X2")} {numArray[0].ToString("X2")} {numArray[1].ToString("X2")} {numArray[2].ToString("X2")} {numArray[3].ToString("X2")} {numArray[4].ToString("X2")} {numArray[5].ToString("X2")} {numArray[6].ToString("X2")} {numArray[7].ToString("X2")}\r\n>");
        int num2 = (int) IDbuff[0] << 8 | (int) IDbuff[1];
        int num3 = num2 & 31 /*0x1F*/;
        int cmd = num2 >> 5 & 47;
        if (num3 == (int) this.pc_id)
        {
          ReceiveDelegate receiveHandle = this.receiveHandle;
          if (receiveHandle != null)
            receiveHandle((UpdateBlock) cmd, numArray);
        }
      }
    }
    while (num1 == 1);
    goto label_1;
  }

  private void Program_receiveHandle(UpdateBlock cmd, byte[] data)
  {
    if (data[1] != (byte) 0 || data[0] != (byte) 0)
    {
      Console.WriteLine(this.CurrenctPro.ToString() + " 失败!");
      this._mSendSignalMain.Set();
    }
    else
    {
      if (cmd == UpdateBlock.Sync)
        this.UpDataPro = UpdateBlock.Erase;
      this.IsdownLoad = false;
      byte[] IDbuff = new byte[4];
      byte[] numArray = new byte[8];
      switch (this.UpDataPro)
      {
        case UpdateBlock.None:
          this.CurrenctPro = UpdateBlock.None;
          Console.WriteLine("Flash Successful!");
          this.Log = $"{this.Log}{(object) this._number}: Flash successfully...{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r";
          this._mSendSignalMain.Set();
          this.Barvalue = 0L;
          break;
        case UpdateBlock.Erase:
          this.CurrenctPro = UpdateBlock.Erase;
          Console.WriteLine("Erase...");
          object[] objArray1 = new object[5]
          {
            (object) this.Log,
            (object) this._number,
            (object) ": Erase...",
            null,
            null
          };
          DateTime now = DateTime.Now;
          objArray1[3] = (object) now.ToString("yyyy-MM-dd HH:mm:ss");
          objArray1[4] = (object) "\r";
          this.Log = string.Concat(objArray1);
          this.Barvalue = 1L;
          int num1 = (int) this.UpDataPro << 5 | this._number;
          IDbuff[0] = (byte) (num1 >> 8 & (int) byte.MaxValue);
          IDbuff[1] = (byte) (num1 & (int) byte.MaxValue);
          if (this.Can_send(IDbuff, numArray, (byte) 0, (byte) 0) != 0)
          {
            object[] objArray2 = new object[7]
            {
              (object) this.Log,
              (object) this._number,
              (object) ": ",
              (object) this.UpDataPro,
              (object) " 发送失败!",
              null,
              null
            };
            now = DateTime.Now;
            objArray2[5] = (object) now.ToString("yyyy-MM-dd HH:mm:ss");
            objArray2[6] = (object) "\r";
            this.Log = string.Concat(objArray2);
            Console.WriteLine(this.UpDataPro.ToString() + " 发送失败!");
            break;
          }
          Console.WriteLine($"{(object) this.UpDataPro} Version:{(object) ((float) ((int) data[3] << 8 | (int) data[2]) / 100f)}");
          this.UpDataPro = UpdateBlock.Program;
          break;
        case UpdateBlock.Program:
          this.CurrenctPro = UpdateBlock.Program;
          Console.WriteLine("Program...");
          this.Log = $"{this.Log}{(object) this._number}: Program...{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r";
          int num2 = (int) this.UpDataPro << 5 | this._number;
          IDbuff[0] = (byte) (num2 >> 8 & (int) byte.MaxValue);
          IDbuff[1] = (byte) (num2 & (int) byte.MaxValue);
          for (int index1 = 0; index1 < 2048 /*0x0800*/; ++index1)
          {
            if (this._sendtimeEsc == this._countEsc - 1L)
            {
              if (this.File.FS % 8L == 0L)
              {
                Array.Copy((Array) this.File.Getfd, 8 * (int) this._sendtimeEsc, (Array) numArray, 0, 8);
              }
              else
              {
                Array.Copy((Array) this.File.Getfd, (long) (8 * (int) this._sendtimeEsc), (Array) numArray, 0L, this.File.FS % 8L);
                for (long index2 = this.File.FS % 8L; index2 < 8L; ++index2)
                  numArray[index2] = byte.MaxValue;
              }
              this.UpDataPro = UpdateBlock.CRC;
            }
            else if (this._sendtimeEsc >= this._countEsc)
            {
              for (int index3 = 0; index3 < 8; ++index3)
                numArray[index3] = byte.MaxValue;
            }
            else
              Array.Copy((Array) this.File.Getfd, 8 * (int) this._sendtimeEsc, (Array) numArray, 0, 8);
            if (this.Can_send(IDbuff, numArray, (byte) 0, (byte) 8) != 0)
            {
              Console.WriteLine(this.UpDataPro.ToString() + " 发送失败!");
              break;
            }
            ++this._sendtimeEsc;
            this.Barvalue = this._sendtimeEsc;
          }
          break;
        case UpdateBlock.CRC:
          this.CurrenctPro = UpdateBlock.CRC;
          Console.WriteLine("CRC...");
          this.Log = $"{this.Log}{(object) this._number}: CRC...{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r";
          this.Barvalue = this.Maximum - 1L;
          int num3 = (int) this.UpDataPro << 5 | this._number;
          IDbuff[0] = (byte) (num3 >> 8 & (int) byte.MaxValue);
          IDbuff[1] = (byte) (num3 & (int) byte.MaxValue);
          numArray[0] = (byte) (this.File.Crc32 & (uint) byte.MaxValue);
          numArray[1] = (byte) (this.File.Crc32 >> 8 & (uint) byte.MaxValue);
          numArray[2] = (byte) (this.File.Crc32 >> 16 /*0x10*/ & (uint) byte.MaxValue);
          numArray[3] = (byte) (this.File.Crc32 >> 24 & (uint) byte.MaxValue);
          if (this.Can_send(IDbuff, numArray, (byte) 0, (byte) 4) != 0)
          {
            Console.WriteLine(this.UpDataPro.ToString() + " 发送失败!");
            break;
          }
          this.UpDataPro = UpdateBlock.Reboot;
          break;
        case UpdateBlock.Reboot:
          this.CurrenctPro = UpdateBlock.Reboot;
          Console.WriteLine("Reboot...");
          this.Log = $"{this.Log}{(object) this._number}: Reboot...{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r";
          this.Barvalue = this.Maximum;
          int num4 = (int) this.UpDataPro << 5 | this._number;
          IDbuff[0] = (byte) (num4 >> 8 & (int) byte.MaxValue);
          IDbuff[1] = (byte) (num4 & (int) byte.MaxValue);
          if (this.Can_send(IDbuff, numArray, (byte) 0, (byte) 0) != 0)
          {
            Console.WriteLine(this.UpDataPro.ToString() + " 发送失败!");
            break;
          }
          this.UpDataPro = UpdateBlock.None;
          Console.WriteLine("Flash Successful!");
          break;
      }
    }
  }

  private int ConnectTarget(byte port = 0)
  {
    byte[] RXF = new byte[4];
    byte[] RXM = new byte[4];
    RXF[0] = (byte) 0;
    RXF[1] = (byte) 0;
    RXF[2] = (byte) 0;
    RXF[3] = (byte) 0;
    RXM[0] = (byte) 0;
    RXM[1] = (byte) 0;
    RXM[2] = (byte) 0;
    RXM[3] = (byte) 0;
    return this.Init_can(port, (byte) 1, (ushort) 1000, (byte) 2, (byte) 0, RXF, RXM);
  }

  protected override void DownLoad_Click(object sender, RoutedEventArgs e)
  {
    if (this.DownLoad == "Reset")
    {
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

  private delegate int TYPE_Init_can(
    byte com_NUM,
    byte Model,
    ushort CanBaudRate,
    byte SET_ID_TYPE,
    byte FILTER_MODE,
    byte[] RXF,
    byte[] RXM);

  private delegate int TYPE_Quit_can();

  private delegate int TYPE_Can_send(byte[] IDbuff, byte[] Databuff, byte FreamType, byte Bytes);

  private delegate int TYPE_Can_receive(
    byte[] IDbuff,
    byte[] Databuff,
    byte[] FreamType,
    byte[] Bytes);
}
