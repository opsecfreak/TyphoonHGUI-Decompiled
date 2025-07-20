// Decompiled with JetBrains decompiler
// Type: Wpfbootload.MainWindow
// Assembly: Wpfbootload, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4FEF84E1-06E0-4569-8BB0-07C571E890DC
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\Wpfbootload.exe

using LibUsbDotNet.DeviceNotify;
using MavLinkNet;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Management;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using Wpfbootload.BootClass;
using YCustomControlLibrary;

#nullable disable
namespace Wpfbootload;

public partial class MainWindow : Window, IComponentConnector
{
  private OpenFileDialog openfile;
  private readonly AutoResetEvent _mSendSignalMain = new AutoResetEvent(false);
  private readonly WindowsDeviceNotifier DeviceNotifier = new WindowsDeviceNotifier();
  private System.Threading.Timer _timerout;
  private int _outimecount;
  private int _numberT;
  private MavLinkSerialPortTransport _serialportMavlink;
  public string _serialportname;
  private Thread _t;
  private CommonUpDataFirmware _upDataFirmware;
  private FData _myFile;
  private bool _isa;
  private Regex r = new Regex("COM\\d+");
  internal MainWindow window;
  internal Border borderFrame;
  internal Grid containerFrame;
  internal Grid homeHeader;
  internal TextBlock lblTitle;
  internal Thumb headerThumb;
  internal StackPanel homeHeaderActionButtons;
  internal System.Windows.Controls.Button btnActionMinimize;
  internal System.Windows.Controls.Button btnActionClose;
  internal System.Windows.Controls.TextBox textboxfilename;
  internal System.Windows.Controls.ComboBox combox;
  internal System.Windows.Controls.Button buttonopenfile;
  internal System.Windows.Controls.ProgressBar progressbar;
  internal System.Windows.Controls.TextBox textboxlog;
  internal Expander expander;
  internal System.Windows.Controls.Button ButtonReboot;
  internal System.Windows.Controls.Button ButtonSoftwareVersion;
  internal System.Windows.Controls.Button buttondownload;
  private bool _contentLoaded;

  private void MyInitialize()
  {
    if (FILENAME.FileNameN)
    {
      string fileName = FILENAME.FileName;
      this.textboxfilename.Text = fileName;
      this.LoadFile(fileName);
    }
    this.openfile = new OpenFileDialog();
    this.openfile.Filter = "程序文件(*.yuneec)|*.yuneec|程序文件(*.bin)|*.bin|所有文件(*.*)|*.*";
  }

  public MainWindow()
  {
    this.InitializeComponent();
    this.MyInitialize();
    this.DeviceNotifier.OnDeviceNotify += new EventHandler<DeviceNotifyEventArgs>(this.DeviceNotifier_OnDeviceNotify);
    this.IsPortOpen();
    this.DataContext = (object) new CommonUpDataFirmware(new FData());
  }

  private void DeviceNotifier_OnDeviceNotify(object sender, DeviceNotifyEventArgs e)
  {
    if (this._isa)
      return;
    if (e.EventType == EventType.DeviceArrival)
    {
      this._isa = true;
      Task.Factory.StartNew<string>((Func<string>) (() => this.MulGetHardwareInfo(MainWindow.HardwareEnum.Win32_PnPEntity, "DeviceID")));
    }
    else
    {
      if (e.EventType != EventType.DeviceRemoveComplete)
        return;
      this._isa = true;
      Task.Factory.StartNew((Action) (() => this.Usbmove(MainWindow.HardwareEnum.Win32_PnPEntity, "DeviceID")));
    }
  }

  private void textboxlog_TextChanged(object sender, TextChangedEventArgs e)
  {
    this.textboxlog.ScrollToEnd();
  }

  private void window_Closing(object sender, CancelEventArgs e)
  {
  }

  private void buttonopenfile_Click(object sender, RoutedEventArgs e)
  {
    if (this.openfile.ShowDialog() != System.Windows.Forms.DialogResult.OK)
      return;
    this.LoadFile(this.openfile.FileName);
  }

  private void LoadFile(string f)
  {
    this._myFile = new FData(f);
    if (this._myFile.Error)
    {
      int num = (int) YMessageBox.Show("Error loading the file!", "Note");
    }
    else
    {
      this.textboxfilename.Text = f;
      if (this._myFile.TargetSystem.ToLower().Contains("fc"))
        this._upDataFirmware = (CommonUpDataFirmware) new FcUpDataFirmware(this._myFile);
      else if (this._myFile.TargetSystem.ToLower().Contains("h920"))
        this._upDataFirmware = (CommonUpDataFirmware) new FcUpDataFirmware(this._myFile);
      else if (this._myFile.TargetSystem.ToLower().Contains("esc"))
        this._upDataFirmware = (CommonUpDataFirmware) new EscUpDataFirmware(this._myFile);
      else if (this._myFile.TargetSystem.ToLower().Contains("bat"))
        this._upDataFirmware = (CommonUpDataFirmware) new FocUpdataFirmware(this._myFile, (byte) 3);
      else if (this._myFile.TargetSystem.ToLower().Contains("foc"))
        this._upDataFirmware = (CommonUpDataFirmware) new FocUpdataFirmware(this._myFile, (byte) 2);
      else if (this._myFile.TargetSystem.ToLower().Contains("bldc"))
        this._upDataFirmware = (CommonUpDataFirmware) new FocUpdataFirmware(this._myFile, (byte) 1);
      else if (this._myFile.TargetSystem.ToLower().Contains("wizard"))
        this._upDataFirmware = (CommonUpDataFirmware) new WizardUpDataFirmware(this._myFile);
      else if (this._myFile.TargetSystem.ToLower().Contains("cgo3"))
        this._upDataFirmware = (CommonUpDataFirmware) new Cgo3UpDataFirmware(this._myFile);
      else if (this._myFile.TargetSystem.ToLower().Contains("bat"))
        this._upDataFirmware = (CommonUpDataFirmware) new BatEscUpdataFirmware(this._myFile);
      this.DataContext = (object) this._upDataFirmware;
    }
  }

  private void window_Drop(object sender, System.Windows.DragEventArgs e)
  {
    this.LoadFile(((Array) e.Data.GetData(System.Windows.DataFormats.FileDrop)).GetValue(0).ToString());
  }

  private void window_Loaded(object sender, RoutedEventArgs e)
  {
    string[] strArray = Environment.CommandLine.Split('"');
    if (strArray.Length <= 3)
      return;
    this.LoadFile(strArray[3]);
  }

  private void IsPortOpen()
  {
    string[] portNames = SerialPort.GetPortNames();
    this.combox.Items.Clear();
    foreach (object newItem in portNames)
      this.combox.Items.Add(newItem);
  }

  public void Usbmove(MainWindow.HardwareEnum hardType, string propKey)
  {
    try
    {
      using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from " + (object) hardType))
      {
        foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
        {
          if (managementBaseObject.Properties[propKey].Value != null && managementBaseObject.Properties[propKey].Value.ToString().Contains("VID_0483&PID_5740"))
            return;
        }
        if (this._serialportMavlink != null)
        {
          try
          {
            this._serialportMavlink.Dispose();
          }
          catch
          {
          }
        }
        this.Dispatcher.BeginInvoke((Delegate) new Action(this.IsPortOpen));
        managementObjectSearcher.Dispose();
      }
    }
    catch
    {
      this._isa = false;
    }
    finally
    {
      this._isa = false;
    }
  }

  public string MulGetHardwareInfo(MainWindow.HardwareEnum hardType, string propKey)
  {
    string hardwareInfo = (string) null;
    CommonUpDataFirmware upDataFirmware = this._upDataFirmware;
    if ((upDataFirmware != null ? (upDataFirmware.IsAction ? 1 : 0) : 0) != 0)
      return hardwareInfo;
    try
    {
      using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from " + (object) hardType))
      {
        foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
        {
          if (managementBaseObject.Properties[propKey].Value != null && managementBaseObject.Properties[propKey].Value.ToString().Contains("VID_0483&PID_5740"))
          {
            Match match = this.r.Match(managementBaseObject.Properties["Name"].Value.ToString());
            if (match.Success)
            {
              hardwareInfo = match.Value;
              this._serialportname = match.Value;
              this.Dispatcher.Invoke((Delegate) (() =>
              {
                this.combox.Items.Clear();
                this.combox.Items.Add((object) this._serialportname);
                this.combox.SelectedIndex = this.combox.Items.Count - 1;
                this.progressbar.Value = 0.0;
              }));
              if (this._upDataFirmware != null)
              {
                this._upDataFirmware.Port = hardwareInfo;
                this._upDataFirmware.Start();
                break;
              }
              int num = (int) YMessageBox.Show("Please Load File!", "Note");
              break;
            }
          }
        }
        managementObjectSearcher.Dispose();
      }
      return hardwareInfo;
    }
    catch
    {
      this._isa = false;
      return hardwareInfo;
    }
    finally
    {
      this._isa = false;
    }
  }

  private void ButtonSoftwareVersion_Click(object sender, RoutedEventArgs e)
  {
    this._serialportname = this.combox.Text;
    if (this._serialportname != "")
    {
      this.buttondownload.IsEnabled = false;
      this.ButtonSoftwareVersion.IsEnabled = false;
      this.progressbar.Maximum = 15.0;
      System.Windows.Controls.TextBox textboxlog = this.textboxlog;
      textboxlog.Text = $"{textboxlog.Text}\r\n***************************{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}***************************\r\n";
      this._t = new Thread(new ThreadStart(this.GetAllSoftwareVersions))
      {
        IsBackground = true
      };
      this._t.Start();
    }
    else
    {
      int num = (int) YMessageBox.Show("Port is NULL!", "Note");
    }
  }

  private void GetAllSoftwareVersions()
  {
    this._serialportMavlink = new MavLinkSerialPortTransport()
    {
      SerialPortName = this._serialportname,
      BaudRate = 115200
    };
    this._serialportMavlink.Initialize();
    this._serialportMavlink.OnPacketReceived += new PacketReceivedDelegate(this.Mavlink_OnPacketReceived);
    for (this._numberT = 1; this._numberT < 6; ++this._numberT)
    {
      switch (this._numberT)
      {
        case 1:
          this.Dispatcher.Invoke((Delegate) (() =>
          {
            this.progressbar.Value = 0.0;
            this.textboxlog.Text += "========Autopilot========\r\n";
          }));
          break;
        case 2:
          this.Dispatcher.Invoke((Delegate) (() =>
          {
            this.progressbar.Value = 3.0;
            this.textboxlog.Text += "=========Gimbal=========\r\n";
          }));
          break;
        case 3:
          this.Dispatcher.Invoke((Delegate) (() =>
          {
            this.progressbar.Value = 6.0;
            this.textboxlog.Text += "=========Camera=========\r\n";
          }));
          break;
        case 4:
          this.Dispatcher.Invoke((Delegate) (() =>
          {
            this.progressbar.Value = 9.0;
            this.textboxlog.Text += "=========Remote=========\r\n";
          }));
          break;
        case 5:
          this.Dispatcher.Invoke((Delegate) (() =>
          {
            this.progressbar.Value = 12.0;
            this.textboxlog.Text += "=========Optflow=========\r\n";
          }));
          break;
      }
      this._serialportMavlink.SendMessage((UasMessage) new MavlinkRequestInfoCmd()
      {
        TargetSystem = (MavRequestInfoSystemId) this._numberT,
        TargetComponent = (byte) 0,
        Type = MavRequestInfoType.Product
      });
      this.Dispatcher.Invoke((Delegate) (() => ++this.progressbar.Value));
      this._outimecount = 0;
      System.Threading.Timer timer = new System.Threading.Timer(new TimerCallback(this.SoftwareTimeroutCall), (object) null, 1000, 1000);
      this._mSendSignalMain.WaitOne();
      timer.Dispose();
    }
    this._serialportMavlink.Dispose();
    this._serialportMavlink.OnPacketReceived -= new PacketReceivedDelegate(this.Mavlink_OnPacketReceived);
    this.Dispatcher.Invoke((Delegate) (() =>
    {
      this.progressbar.Value = this.progressbar.Maximum;
      this.ButtonSoftwareVersion.IsEnabled = true;
    }));
  }

  private void SoftwareTimeroutCall(object obj)
  {
    ++this._outimecount;
    if (this._outimecount < 2)
    {
      this._serialportMavlink.SendMessage((UasMessage) new MavlinkRequestInfoCmd()
      {
        TargetSystem = (MavRequestInfoSystemId) this._numberT,
        TargetComponent = (byte) 0,
        Type = MavRequestInfoType.Product
      });
      this.Dispatcher.Invoke((Delegate) (() => ++this.progressbar.Value));
    }
    else
    {
      this.Dispatcher.Invoke((Delegate) (() =>
      {
        System.Windows.Controls.TextBox textboxlog = this.textboxlog;
        textboxlog.Text = $"{textboxlog.Text}Get {((MavRequestInfoSystemId) this._numberT).ToString()} Fialed\r";
      }));
      this._mSendSignalMain.Set();
    }
  }

  private void ButtonReboot_Click(object sender, RoutedEventArgs e)
  {
    this._serialportname = this.combox.Text;
    if (this._serialportname != "")
    {
      this._serialportMavlink = new MavLinkSerialPortTransport()
      {
        SerialPortName = this._serialportname,
        BaudRate = 115200
      };
      this._serialportMavlink.Initialize();
      this._serialportMavlink.SendMessage((UasMessage) new UasCommandLong()
      {
        TargetSystem = (byte) 1,
        TargetComponent = (byte) 1,
        Command = MavCmd.PreflightRebootShutdown,
        Confirmation = (byte) 0,
        Param1 = 3f,
        Param2 = 0.0f,
        Param3 = 0.0f,
        Param4 = 0.0f
      });
    }
    else
    {
      int num = (int) YMessageBox.Show("Port is NULL!", "Note");
    }
  }

  private void Mavlink_OnPacketReceived(object sender, MavLinkPacket packet)
  {
    if (packet.MessageId != (byte) 52)
      return;
    MavlinkRequestInfoFeedback message = packet.Message as MavlinkRequestInfoFeedback;
    string str = new string(message.ProductName).Replace(char.MinValue, ' ');
    string softwarestring = "";
    if (str != "                ")
    {
      softwarestring = $"System:{new string(message.ProductName).Replace(char.MinValue, ' ')}\r\n";
      softwarestring = $"{softwarestring}Version:HV{((float) message.HardwareVersion * 0.01f).ToString("f2")},SV{((float) message.SoftwareVersion * 0.01f).ToString("f2")}\r\n";
      softwarestring = $"{softwarestring}Data:{(object) message.SoftwareYear}-{(object) message.SoftwareMonth}-{(object) message.SoftwareDay}";
    }
    else
      softwarestring = "System: NULL";
    this.Dispatcher.Invoke((Delegate) (() =>
    {
      System.Windows.Controls.TextBox textboxlog = this.textboxlog;
      textboxlog.Text = $"{textboxlog.Text}{softwarestring}\r\n";
    }));
    this._mSendSignalMain.Set();
  }

  private void buttondownload_Click(object sender, RoutedEventArgs e)
  {
    this._upDataFirmware?.Start();
  }

  private void headerThumb_DragDelta(object sender, DragDeltaEventArgs e)
  {
    this.Left += e.HorizontalChange;
    this.Top += e.VerticalChange;
  }

  private void headerThumb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
  {
    if (this.WindowState == WindowState.Normal)
    {
      this.WindowState = WindowState.Maximized;
    }
    else
    {
      if (this.WindowState != WindowState.Maximized)
        return;
      this.WindowState = WindowState.Normal;
    }
  }

  private void btnActionMinimize_Click(object sender, RoutedEventArgs e)
  {
    this.WindowState = WindowState.Minimized;
  }

  private void btnActionClose_Click(object sender, RoutedEventArgs e)
  {
    if (System.Windows.Application.Current.Windows.Count > 1)
    {
      GC.Collect();
      this.DeviceNotifier.OnDeviceNotify -= new EventHandler<DeviceNotifyEventArgs>(this.DeviceNotifier_OnDeviceNotify);
      this.Close();
      GC.Collect();
    }
    else
      System.Windows.Application.Current.Shutdown();
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    System.Windows.Application.LoadComponent((object) this, new Uri("/Wpfbootload;component/mainwindow.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  internal Delegate _CreateDelegate(System.Type delegateType, string handler)
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
        this.window = (MainWindow) target;
        this.window.Closing += new CancelEventHandler(this.window_Closing);
        this.window.Drop += new System.Windows.DragEventHandler(this.window_Drop);
        this.window.Loaded += new RoutedEventHandler(this.window_Loaded);
        break;
      case 2:
        this.borderFrame = (Border) target;
        break;
      case 3:
        this.containerFrame = (Grid) target;
        break;
      case 4:
        this.homeHeader = (Grid) target;
        break;
      case 5:
        this.lblTitle = (TextBlock) target;
        break;
      case 6:
        this.headerThumb = (Thumb) target;
        this.headerThumb.DragDelta += new DragDeltaEventHandler(this.headerThumb_DragDelta);
        this.headerThumb.MouseDoubleClick += new MouseButtonEventHandler(this.headerThumb_MouseDoubleClick);
        break;
      case 7:
        this.homeHeaderActionButtons = (StackPanel) target;
        break;
      case 8:
        this.btnActionMinimize = (System.Windows.Controls.Button) target;
        this.btnActionMinimize.Click += new RoutedEventHandler(this.btnActionMinimize_Click);
        break;
      case 9:
        this.btnActionClose = (System.Windows.Controls.Button) target;
        this.btnActionClose.Click += new RoutedEventHandler(this.btnActionClose_Click);
        break;
      case 10:
        this.textboxfilename = (System.Windows.Controls.TextBox) target;
        break;
      case 11:
        this.combox = (System.Windows.Controls.ComboBox) target;
        break;
      case 12:
        this.buttonopenfile = (System.Windows.Controls.Button) target;
        this.buttonopenfile.Click += new RoutedEventHandler(this.buttonopenfile_Click);
        break;
      case 13:
        this.progressbar = (System.Windows.Controls.ProgressBar) target;
        break;
      case 14:
        this.textboxlog = (System.Windows.Controls.TextBox) target;
        this.textboxlog.TextChanged += new TextChangedEventHandler(this.textboxlog_TextChanged);
        break;
      case 15:
        this.expander = (Expander) target;
        break;
      case 16 /*0x10*/:
        this.ButtonReboot = (System.Windows.Controls.Button) target;
        this.ButtonReboot.Click += new RoutedEventHandler(this.ButtonReboot_Click);
        break;
      case 17:
        this.ButtonSoftwareVersion = (System.Windows.Controls.Button) target;
        this.ButtonSoftwareVersion.Click += new RoutedEventHandler(this.ButtonSoftwareVersion_Click);
        break;
      case 18:
        this.buttondownload = (System.Windows.Controls.Button) target;
        this.buttondownload.Click += new RoutedEventHandler(this.buttondownload_Click);
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }

  public enum HardwareEnum
  {
    Win32_Processor,
    Win32_PhysicalMemory,
    Win32_Keyboard,
    Win32_PointingDevice,
    Win32_FloppyDrive,
    Win32_DiskDrive,
    Win32_CDROMDrive,
    Win32_BaseBoard,
    Win32_BIOS,
    Win32_ParallelPort,
    Win32_SerialPort,
    Win32_SerialPortConfiguration,
    Win32_SoundDevice,
    Win32_SystemSlot,
    Win32_USBController,
    Win32_NetworkAdapter,
    Win32_NetworkAdapterConfiguration,
    Win32_Printer,
    Win32_PrinterConfiguration,
    Win32_PrintJob,
    Win32_TCPIPPrinterPort,
    Win32_POTSModem,
    Win32_POTSModemToSerialPort,
    Win32_DesktopMonitor,
    Win32_DisplayConfiguration,
    Win32_DisplayControllerConfiguration,
    Win32_VideoController,
    Win32_VideoSettings,
    Win32_TimeZone,
    Win32_SystemDriver,
    Win32_DiskPartition,
    Win32_LogicalDisk,
    Win32_LogicalDiskToPartition,
    Win32_LogicalMemoryConfiguration,
    Win32_PageFile,
    Win32_PageFileSetting,
    Win32_BootConfiguration,
    Win32_ComputerSystem,
    Win32_OperatingSystem,
    Win32_StartupCommand,
    Win32_Service,
    Win32_Group,
    Win32_GroupUser,
    Win32_UserAccount,
    Win32_Process,
    Win32_Thread,
    Win32_Share,
    Win32_NetworkClient,
    Win32_NetworkProtocol,
    Win32_PnPEntity,
  }
}
