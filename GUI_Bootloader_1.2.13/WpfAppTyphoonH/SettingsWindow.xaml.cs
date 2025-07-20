// Decompiled with JetBrains decompiler
// Type: WpfAppTyphoonH.SettingsWindow
// Assembly: WpfAppTyphoonH, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 3524D12E-4BA5-4A95-813C-BA8CEFA4F2FA
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\WpfAppTyphoonH.exe

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using YCustomControlLibrary;

#nullable disable
namespace WpfAppTyphoonH;

public partial class SettingsWindow : Window, IComponentConnector
{
  private MainWindow mainwindow;
  public const int WM_DEVICECHANGE = 537;
  public const int DBT_DEVICEARRIVAL = 32768 /*0x8000*/;
  public const int DBT_DEVICEREMOVECOMPLETE = 32772;
  internal TabControl tabcontrol;
  internal CheckBox checkboxauto;
  internal Label labelusbvid;
  internal Label labelusbpid;
  internal TextBox textboxvid;
  internal TextBox textboxpid;
  internal Button buttontesting;
  internal Label labelserialport;
  internal Label labelserialbaud;
  internal ComboBox comboboxport;
  internal TextBox textboxbaud;
  internal Button buttonapply;
  internal Button buttoncancel;
  internal Button buttonok;
  private bool _contentLoaded;

  public SettingsWindow(MainWindow MW)
  {
    this.InitializeComponent();
    this.labelserialport.Content = (object) ("Port:       " + MW.serialportname);
    this.labelserialbaud.Content = (object) ("Baud:     " + MW.serialportbaud.ToString());
    this.labelusbvid.Content = (object) ("VID:       0x" + $"{MW.usbVID:X4}");
    this.labelusbpid.Content = (object) ("PID:       0x" + $"{MW.usbPID:X4}");
    this.textboxvid.Text = "0x" + $"{MW.usbVID:X4}";
    this.textboxpid.Text = "0x" + $"{MW.usbPID:X4}";
    this.textboxbaud.Text = MW.serialportbaud.ToString();
    this.checkboxauto.IsChecked = new bool?(MW.enableauto);
    this.mainwindow = MW;
    this.IsPortOpen();
  }

  private void buttoncancel_Click(object sender, RoutedEventArgs e) => this.Close();

  private void buttonok_Click(object sender, RoutedEventArgs e)
  {
    switch (this.tabcontrol.SelectedIndex)
    {
      case 0:
        if (!(this.textboxvid.Text == ""))
        {
          if (!(this.textboxvid.Text == ""))
          {
            try
            {
              string str1 = this.textboxvid.Text;
              if (str1.StartsWith("0x"))
                str1 = str1.Remove(0, 2);
              this.mainwindow.usbVID = Convert.ToInt32(str1, 16 /*0x10*/);
              string str2 = this.textboxpid.Text;
              if (str2.StartsWith("0x"))
                str2 = str2.Remove(0, 2);
              this.mainwindow.usbPID = Convert.ToInt32(str2, 16 /*0x10*/);
              bool? isChecked = this.checkboxauto.IsChecked;
              bool flag = true;
              this.mainwindow.enableauto = (isChecked.GetValueOrDefault() == flag ? (isChecked.HasValue ? 1 : 0) : 0) != 0;
              break;
            }
            catch (Exception ex)
            {
              int num = (int) YMessageBox.Show(ex.Message, "Error");
              break;
            }
          }
        }
        int num1 = (int) YMessageBox.Show("Value can't be empty!", "Note");
        return;
      case 1:
        if (!(this.comboboxport.Text == ""))
        {
          if (!(this.textboxbaud.Text == ""))
          {
            try
            {
              this.mainwindow.serialportname = this.comboboxport.Text;
              this.mainwindow.serialportbaud = Convert.ToInt32(this.textboxbaud.Text);
              break;
            }
            catch (Exception ex)
            {
              int num2 = (int) YMessageBox.Show(ex.Message, "Error");
              break;
            }
          }
        }
        int num3 = (int) YMessageBox.Show("Value can't be empty", "Note");
        return;
    }
    this.mainwindow.WriteConfigFile();
    this.Close();
  }

  private void IsPortOpen()
  {
    string[] portNames = SerialPort.GetPortNames();
    this.comboboxport.Items.Clear();
    foreach (object newItem in portNames)
      this.comboboxport.Items.Add(newItem);
  }

  protected override void OnSourceInitialized(EventArgs e)
  {
    base.OnSourceInitialized(e);
    this.win_SourceInitialized((object) this, e);
  }

  private void win_SourceInitialized(object sender, EventArgs e)
  {
    if (!(PresentationSource.FromVisual((Visual) this) is HwndSource hwndSource))
      return;
    hwndSource.AddHook(new HwndSourceHook(this.WndProc));
  }

  protected virtual IntPtr WndProc(
    IntPtr hwnd,
    int msg,
    IntPtr wParam,
    IntPtr lParam,
    ref bool handled)
  {
    if (msg == 537)
      this.IsPortOpen();
    return IntPtr.Zero;
  }

  private void comboboxport_SelectionChanged(object sender, SelectionChangedEventArgs e)
  {
    if (this.comboboxport.SelectedIndex == -1)
      this.buttontesting.IsEnabled = false;
    else
      this.buttontesting.IsEnabled = true;
  }

  private void buttontesting_Click(object sender, RoutedEventArgs e)
  {
    SerialPort serialPort = new SerialPort(this.comboboxport.Text, 9600);
    try
    {
      serialPort.Open();
      serialPort.Write(this.comboboxport.Text);
      serialPort.Close();
      int num = (int) YMessageBox.Show("SUCCESS!", "Note");
    }
    catch
    {
      int num = (int) YMessageBox.Show("FAILED!", "Note");
    }
  }

  private void buttonapply_Click(object sender, RoutedEventArgs e)
  {
    switch (this.tabcontrol.SelectedIndex)
    {
      case 0:
        if (!(this.textboxvid.Text == ""))
        {
          if (!(this.textboxvid.Text == ""))
          {
            try
            {
              string str1 = this.textboxvid.Text;
              if (str1.StartsWith("0x"))
                str1 = str1.Remove(0, 2);
              this.mainwindow.usbVID = Convert.ToInt32(str1, 16 /*0x10*/);
              string str2 = this.textboxpid.Text;
              if (str2.StartsWith("0x"))
                str2 = str2.Remove(0, 2);
              this.mainwindow.usbPID = Convert.ToInt32(str2, 16 /*0x10*/);
              bool? isChecked = this.checkboxauto.IsChecked;
              bool flag = true;
              this.mainwindow.enableauto = (isChecked.GetValueOrDefault() == flag ? (isChecked.HasValue ? 1 : 0) : 0) != 0;
            }
            catch (Exception ex)
            {
              int num = (int) YMessageBox.Show(ex.Message, "Error");
            }
            this.labelusbvid.Content = (object) ("VID:       0x" + $"{this.mainwindow.usbVID:X4}");
            this.labelusbpid.Content = (object) ("PID:       0x" + $"{this.mainwindow.usbPID:X4}");
            break;
          }
        }
        int num1 = (int) YMessageBox.Show("Value can't be empty!", "Note");
        return;
      case 1:
        if (!(this.comboboxport.Text == ""))
        {
          if (!(this.textboxbaud.Text == ""))
          {
            try
            {
              this.mainwindow.serialportname = this.comboboxport.Text;
              this.mainwindow.serialportbaud = Convert.ToInt32(this.textboxbaud.Text);
            }
            catch (Exception ex)
            {
              int num2 = (int) YMessageBox.Show(ex.Message, "Error");
            }
            this.labelserialport.Content = (object) ("Port:       " + this.mainwindow.serialportname);
            this.labelserialbaud.Content = (object) ("Baud:     " + this.mainwindow.serialportbaud.ToString());
            break;
          }
        }
        int num3 = (int) YMessageBox.Show("Value can't be empty!", "Note");
        return;
    }
    this.mainwindow.WriteConfigFile();
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/WpfAppTyphoonH;component/settingswindow.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        this.tabcontrol = (TabControl) target;
        break;
      case 2:
        this.checkboxauto = (CheckBox) target;
        break;
      case 3:
        this.labelusbvid = (Label) target;
        break;
      case 4:
        this.labelusbpid = (Label) target;
        break;
      case 5:
        this.textboxvid = (TextBox) target;
        break;
      case 6:
        this.textboxpid = (TextBox) target;
        break;
      case 7:
        this.buttontesting = (Button) target;
        this.buttontesting.Click += new RoutedEventHandler(this.buttontesting_Click);
        break;
      case 8:
        this.labelserialport = (Label) target;
        break;
      case 9:
        this.labelserialbaud = (Label) target;
        break;
      case 10:
        this.comboboxport = (ComboBox) target;
        this.comboboxport.SelectionChanged += new SelectionChangedEventHandler(this.comboboxport_SelectionChanged);
        break;
      case 11:
        this.textboxbaud = (TextBox) target;
        break;
      case 12:
        this.buttonapply = (Button) target;
        this.buttonapply.Click += new RoutedEventHandler(this.buttonapply_Click);
        break;
      case 13:
        this.buttoncancel = (Button) target;
        this.buttoncancel.Click += new RoutedEventHandler(this.buttoncancel_Click);
        break;
      case 14:
        this.buttonok = (Button) target;
        this.buttonok.Click += new RoutedEventHandler(this.buttonok_Click);
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
