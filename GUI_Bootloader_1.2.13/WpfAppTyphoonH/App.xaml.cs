// Decompiled with JetBrains decompiler
// Type: WpfAppTyphoonH.App
// Assembly: WpfAppTyphoonH, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 3524D12E-4BA5-4A95-813C-BA8CEFA4F2FA
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\WpfAppTyphoonH.exe

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;
using YCustomControlLibrary;

#nullable disable
namespace WpfAppTyphoonH;

public partial class App : Application
{
  private bool _contentLoaded;

  public App()
  {
    this.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(this.App_DispatcherUnhandledException);
  }

  private void App_DispatcherUnhandledException(
    object sender,
    DispatcherUnhandledExceptionEventArgs e)
  {
    WriteLog.CreateLog(e.Exception);
    int num = (int) YMessageBox.Show($"Error encountered!Please contact support.{Environment.NewLine}{e.Exception.Message}{Environment.NewLine}Will be shut down.", "Error");
    e.Handled = true;
    this.Shutdown();
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    this.StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);
    Application.LoadComponent((object) this, new Uri("/WpfAppTyphoonH;component/app.xaml", UriKind.Relative));
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
