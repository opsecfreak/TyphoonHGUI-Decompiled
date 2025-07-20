// Decompiled with JetBrains decompiler
// Type: YCustomControlLibrary.LoginWindow
// Assembly: YCustomControlLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4940B50A-5996-4EDB-9939-34777C39EC01
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\YCustomControlLibrary.dll

using MySql.Data.MySqlClient;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;

#nullable disable
namespace YCustomControlLibrary;

public partial class LoginWindow : Window, IComponentConnector
{
  private string mySqlConnectionString = "Server=rm-uf69k1efi3nt2pi52o.mysql.rds.aliyuncs.com;Database=account;Uid=yuneec;Pwd=yuneec;";
  private bool _isConnecting;
  private int trycount;
  private Storyboard sbd;
  private Storyboard baiyun;
  internal RotateTransform igSmallLeaf;
  internal RotateTransform igBigLeaf;
  internal Image imgCloud;
  internal TranslateTransform igCloud;
  internal Button btnActionClose;
  internal Button btnActionMinimize;
  internal TextBlock txtwrong;
  internal TextBox txtid;
  internal PasswordBox txtPass;
  internal Button ButtonLogin;
  internal Button ButtonCancel;
  private bool _contentLoaded;

  public event LoginSuccessDelegate LoginSuccessHanlde;

  public LoginWindow()
  {
    this.InitializeComponent();
    this.sbd = this.Resources[(object) "leafLeave"] as Storyboard;
    this.baiyun = this.Resources[(object) "cloudMove"] as Storyboard;
    this.txtid.Text = "jy.wang";
    this.txtPass.Password = "000";
  }

  private void Window_MouseDown(object sender, MouseButtonEventArgs e)
  {
    if (e.LeftButton != MouseButtonState.Pressed)
      return;
    this.DragMove();
  }

  private void Window_Loaded(object sender, RoutedEventArgs e)
  {
  }

  private void btnAction_Click(object sender, RoutedEventArgs e)
  {
    if ((sender as Button).ToolTip.ToString() == "Close")
      this.Close();
    else
      this.WindowState = WindowState.Minimized;
  }

  private void ButtonLogin_Click(object sender, RoutedEventArgs e)
  {
    if (this._isConnecting)
      return;
    this.txtwrong.Visibility = Visibility.Collapsed;
    this.trycount = 0;
    this.sbd.Begin();
    this.baiyun.Begin();
    Task.Factory.StartNew(new Action(this.ThreadConnecting));
  }

  private void ThreadConnecting()
  {
    this._isConnecting = true;
    MySqlConnection mySqlConnection = new MySqlConnection(this.mySqlConnectionString);
    try
    {
      ((DbConnection) mySqlConnection).Open();
      MySqlCommand cmd = mySqlConnection.CreateCommand();
      ((DbCommand) cmd).CommandText = "SELECT Count(*) FROM sa WHERE id = @myid AND pw = @mypw";
      this.Dispatcher.Invoke((Delegate) (() =>
      {
        cmd.Parameters.AddWithValue("@myid", (object) this.txtid.Text);
        cmd.Parameters.AddWithValue("@mypw", (object) this.txtPass.Password);
      }));
      MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
      while (((DbDataReader) mySqlDataReader).Read())
      {
        this._isConnecting = false;
        if (((DbDataReader) mySqlDataReader).GetInt32(0) > 0)
          this.Dispatcher.Invoke((Delegate) (() =>
          {
            this.LoginSuccessHanlde?.BeginInvoke((object) this, this.txtid.Text, new AsyncCallback(this.LoginSuccessEnd), (object) this);
            this.Close();
          }));
        else
          this.Dispatcher.Invoke((Delegate) (() =>
          {
            this.sbd.Pause();
            this.baiyun.Pause();
            this.txtwrong.Visibility = Visibility.Visible;
          }));
      }
    }
    catch
    {
      ++this.trycount;
      if (this.trycount < 5)
      {
        Task.Factory.StartNew(new Action(this.ThreadConnecting));
      }
      else
      {
        this._isConnecting = false;
        this.sbd.Pause();
        this.baiyun.Pause();
        int num = (int) YMessageBox.Show("Network error!", "Error");
      }
    }
    finally
    {
      ((DbConnection) mySqlConnection).Close();
    }
  }

  private void LoginSuccessEnd(IAsyncResult ar)
  {
  }

  private void txtid_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (this.txtid.Text != "" && this.txtPass.Password != "")
      this.ButtonLogin.IsEnabled = true;
    else
      this.ButtonLogin.IsEnabled = false;
  }

  private void txtPass_PasswordChanged(object sender, RoutedEventArgs e)
  {
    if (this.txtid.Text != "" && this.txtPass.Password != "")
      this.ButtonLogin.IsEnabled = true;
    else
      this.ButtonLogin.IsEnabled = false;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/YCustomControlLibrary;component/loginwindow.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  internal Delegate _CreateDelegate(Type delegateType, string handler)
  {
    return Delegate.CreateDelegate(delegateType, (object) this, handler);
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        ((UIElement) target).MouseDown += new MouseButtonEventHandler(this.Window_MouseDown);
        ((FrameworkElement) target).Loaded += new RoutedEventHandler(this.Window_Loaded);
        break;
      case 2:
        this.igSmallLeaf = (RotateTransform) target;
        break;
      case 3:
        this.igBigLeaf = (RotateTransform) target;
        break;
      case 4:
        this.imgCloud = (Image) target;
        break;
      case 5:
        this.igCloud = (TranslateTransform) target;
        break;
      case 6:
        this.btnActionClose = (Button) target;
        this.btnActionClose.Click += new RoutedEventHandler(this.btnAction_Click);
        break;
      case 7:
        this.btnActionMinimize = (Button) target;
        this.btnActionMinimize.Click += new RoutedEventHandler(this.btnAction_Click);
        break;
      case 8:
        this.txtwrong = (TextBlock) target;
        break;
      case 9:
        this.txtid = (TextBox) target;
        this.txtid.TextChanged += new TextChangedEventHandler(this.txtid_TextChanged);
        break;
      case 10:
        this.txtPass = (PasswordBox) target;
        this.txtPass.PasswordChanged += new RoutedEventHandler(this.txtPass_PasswordChanged);
        break;
      case 11:
        this.ButtonLogin = (Button) target;
        this.ButtonLogin.Click += new RoutedEventHandler(this.ButtonLogin_Click);
        break;
      case 12:
        this.ButtonCancel = (Button) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
