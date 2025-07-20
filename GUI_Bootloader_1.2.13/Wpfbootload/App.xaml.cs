// Decompiled with JetBrains decompiler
// Type: Wpfbootload.App
// Assembly: Wpfbootload, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4FEF84E1-06E0-4569-8BB0-07C571E890DC
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\Wpfbootload.exe

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Threading;
using YCustomControlLibrary;

#nullable disable
namespace Wpfbootload;

public partial class App : Application
{
  private bool _contentLoaded;

  private void App_DispatcherUnhandledException(
    object sender,
    DispatcherUnhandledExceptionEventArgs e)
  {
    WriteLog.CreateLog(e.Exception);
    int num = (int) YMessageBox.Show($"Error encountered!Please contact support.{Environment.NewLine}{e.Exception.Message}{Environment.NewLine}Will be shut down.", "Error");
    e.Handled = true;
    this.Shutdown();
  }

  private void Application_Startup(object sender, StartupEventArgs e)
  {
    if (e.Args.Length == 0)
      return;
    if (e.Args[0].Contains("-Decrypt"))
    {
      DECRYPT.decrypt = true;
    }
    else
    {
      FILENAME.FileNameN = true;
      FILENAME.FileName = e.Args[0];
    }
  }

  private void License()
  {
    try
    {
      FileStream fileStream = new FileStream(".\\bootloader.lic", FileMode.Open, FileAccess.Read);
      Hardware hardware = new Hardware();
      string hardDiskId = hardware.GetHardDiskID();
      string cpuId = hardware.GetCpuID();
      RijndaelManaged rijndaelManaged = new RijndaelManaged();
      rijndaelManaged.Mode = CipherMode.ECB;
      rijndaelManaged.Padding = PaddingMode.PKCS7;
      rijndaelManaged.KeySize = 128 /*0x80*/;
      rijndaelManaged.BlockSize = 128 /*0x80*/;
      byte[] bytes1 = Encoding.UTF8.GetBytes(cpuId);
      byte[] destinationArray = new byte[16 /*0x10*/];
      int length1 = bytes1.Length;
      if (length1 > destinationArray.Length)
      {
        int length2 = destinationArray.Length;
        Array.Copy((Array) bytes1, (Array) destinationArray, length2);
      }
      else if (length1 < destinationArray.Length)
      {
        Array.Copy((Array) bytes1, (Array) destinationArray, length1);
        for (int index = length1; index < destinationArray.Length; ++index)
          destinationArray[index] = byte.MaxValue;
      }
      rijndaelManaged.Key = destinationArray;
      ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor();
      byte[] bytes2 = Encoding.UTF8.GetBytes(hardDiskId);
      byte[] inputBuffer = bytes2;
      int length3 = bytes2.Length;
      byte[] numArray = encryptor.TransformFinalBlock(inputBuffer, 0, length3);
      for (int index = 0; (long) index < fileStream.Length; ++index)
      {
        if ((int) numArray[index] != fileStream.ReadByte())
          throw new Exception("LIC FAILED");
      }
    }
    catch
    {
      int num = (int) YMessageBox.Show("This machine is not authorized!", "Error");
      this.Shutdown();
    }
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    this.Startup += new StartupEventHandler(this.Application_Startup);
    this.StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);
    Application.LoadComponent((object) this, new Uri("/Wpfbootload;component/app.xaml", UriKind.Relative));
  }

  [STAThread]
  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public static void Main()
  {
    App app = new App();
    app.InitializeComponent();
    app.Run();
  }
}
