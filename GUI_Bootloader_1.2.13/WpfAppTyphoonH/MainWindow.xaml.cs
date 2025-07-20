// Decompiled with JetBrains decompiler
// Type: WpfAppTyphoonH.MainWindow
// Assembly: WpfAppTyphoonH, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 3524D12E-4BA5-4A95-813C-BA8CEFA4F2FA
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\WpfAppTyphoonH.exe

using battery;
using GetWebPage;
using LibUsbDotNet.DeviceNotify;
using MavLinkNet;
using MotorAircraft;
using MySql.Data.MySqlClient;
using Sparrow.Chart;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using WpfJudgement;
using WpfLed;
using YCustomControlLibrary;

#nullable disable
namespace WpfAppTyphoonH;

public partial class MainWindow : Window, INotifyPropertyChanged, IComponentConnector
{
  private OpenFileDialog openfile;
  private string Newfilename;
  private string downloadnewfile;
  private static readonly WindowsDeviceNotifier DeviceNotifier = new WindowsDeviceNotifier();
  private MavLinkUSBTransport usbMavLink;
  private MavLinkSerialPortTransport serialportMavlink;
  private System.Threading.Timer timerefreshstatus;
  private System.Threading.Timer checkinternet;
  private System.Threading.Timer sendcommandlong;
  private WebPage yuneecweb;
  private int motornumber;
  public string serialportname;
  public int serialportbaud;
  public int usbVID;
  public int usbPID;
  public bool enableauto;
  private MainWindow.ConnectWays connectway;
  private MainWindow.GetInformation GetBlock;
  private MySqlConnection _mysqlconnection;
  private string mySqlConnectionString;
  private List<DoublePoint> points;
  private List<DoublePoint> pointsused;
  private int refreshcount;
  private bool requestanswer;
  public bool haveanewfile;
  private static bool firing = false;
  private string DirPath;
  private readonly Dictionary<string, byte[]> _licFile;
  private string _myuid;
  private readonly MainWindow.FData _filedata;
  private string filename;
  private bool _downloading;
  private Version ver;
  private WpfAppTyphoonH.Account account;
  private DBConnect dbconnect;
  private Regex r;
  public const int WM_DEVICECHANGE = 537;
  public const int DBT_DEVICEARRIVAL = 32768 /*0x8000*/;
  public const int DBT_DEVICEREMOVECOMPLETE = 32772;
  private bool isa;
  private bool _interneting;
  internal Border borderFrame;
  internal Grid containerFrame;
  internal Grid homeHeader;
  internal TextBlock lblTitle;
  internal Thumb headerThumb;
  internal StackPanel homeHeaderActionButtons;
  internal System.Windows.Controls.Button btnActionMinimize;
  internal System.Windows.Controls.Button btnActionRestore;
  internal System.Windows.Controls.Button btnActionMaxamize;
  internal System.Windows.Controls.Button btnActionClose;
  internal System.Windows.Controls.MenuItem menuitemconnect;
  internal System.Windows.Controls.MenuItem menuitemsettings;
  internal System.Windows.Controls.MenuItem menuitemclose;
  internal System.Windows.Controls.MenuItem menuitem12;
  internal System.Windows.Controls.MenuItem menuitem14;
  internal System.Windows.Controls.MenuItem menuitem16;
  internal System.Windows.Controls.MenuItem menuitem18;
  internal System.Windows.Controls.MenuItem menuitemusb;
  internal System.Windows.Controls.MenuItem menuitemserialport;
  internal System.Windows.Controls.MenuItem menuitemUpdate;
  internal System.Windows.Controls.MenuItem menuitemLicense;
  internal System.Windows.Controls.TabControl tabSteps;
  internal TabItem FirstHome;
  internal System.Windows.Controls.GroupBox groupbox1;
  internal WControlJudgement judgementO;
  internal WControlJudgement judgementP;
  internal WControlJudgement judgementC;
  internal WControlJudgement judgementG;
  internal WControlJudgement judgementS;
  internal WControlJudgement judgementR;
  internal WControlJudgement judgementOF;
  internal WControlJudgement judgementRS;
  internal System.Windows.Controls.Label labelO;
  internal System.Windows.Controls.Label labelP;
  internal System.Windows.Controls.Label labelC;
  internal System.Windows.Controls.Label labelG;
  internal System.Windows.Controls.Label labelS;
  internal System.Windows.Controls.Label labelR;
  internal System.Windows.Controls.Label labelOF;
  internal System.Windows.Controls.Label labelRS;
  internal System.Windows.Controls.GroupBox groupbox15;
  internal System.Windows.Controls.CheckBox checkenbletesting;
  internal System.Windows.Controls.Button buttonallturn;
  internal Motor AircraftESC;
  internal System.Windows.Controls.GroupBox groupbox2;
  internal System.Windows.Controls.TextBox textboxvoltage;
  internal System.Windows.Controls.Label labelvoltage;
  internal Battery Battery;
  internal System.Windows.Controls.Label labelvoltagev;
  internal System.Windows.Controls.GroupBox groupbox3;
  internal System.Windows.Controls.TextBox textboxaccx;
  internal System.Windows.Controls.TextBox textboxaccy;
  internal System.Windows.Controls.TextBox textboxaccz;
  internal System.Windows.Controls.TextBox textboxaccm;
  internal System.Windows.Controls.GroupBox groupbox4;
  internal System.Windows.Controls.TextBox textboxgyrx;
  internal System.Windows.Controls.TextBox textboxgyry;
  internal System.Windows.Controls.TextBox textboxgyrz;
  internal System.Windows.Controls.GroupBox groupbox5;
  internal System.Windows.Controls.TextBox textboxroll;
  internal System.Windows.Controls.TextBox textboxpitch;
  internal System.Windows.Controls.TextBox textboxyaw;
  internal System.Windows.Controls.GroupBox groupbox6;
  internal System.Windows.Controls.TextBox textboxcomx;
  internal System.Windows.Controls.TextBox textboxcomy;
  internal System.Windows.Controls.TextBox textboxcomz;
  internal System.Windows.Controls.GroupBox groupbox7;
  internal System.Windows.Controls.TextBox textboxpre;
  internal System.Windows.Controls.TextBox textboxpretem;
  internal System.Windows.Controls.TextBox textboxprehe;
  internal System.Windows.Controls.GroupBox groupbox8;
  internal System.Windows.Controls.GroupBox groupbox14;
  internal System.Windows.Controls.Label Geofencecurrentvalue;
  internal TAlex.WPF.Controls.NumericUpDown Geofencenewvalue;
  internal System.Windows.Controls.Button Updategeofence;
  internal System.Windows.Controls.Label Heightlimitcurrentvalue;
  internal TAlex.WPF.Controls.NumericUpDown Heightlimitnewvalue;
  internal System.Windows.Controls.Button Updateheightlimit;
  internal System.Windows.Controls.Button ButtonNoFlyEnable;
  internal System.Windows.Controls.Button ButtonFlyEnable;
  internal System.Windows.Controls.Button ButtonClearPar;
  internal TextBlock AveSnr;
  internal SparrowChart Chart;
  internal ColumnSeries columnseries;
  internal ColumnSeries columnseriesgreen;
  internal System.Windows.Controls.GroupBox groupbox9;
  internal System.Windows.Controls.TextBox textboxlat;
  internal System.Windows.Controls.TextBox textboxlon;
  internal System.Windows.Controls.TextBox textboxalt;
  internal System.Windows.Controls.TextBox textboxeph;
  internal System.Windows.Controls.GroupBox groupbox10;
  internal System.Windows.Controls.TextBox textboxvx;
  internal System.Windows.Controls.TextBox textboxvy;
  internal System.Windows.Controls.TextBox textboxvz;
  internal TabItem StartHome;
  internal TextBlock TextBlockSpecification;
  internal System.Windows.Controls.GroupBox groupbox11;
  internal TextBlock GuiUp;
  internal System.Windows.Controls.GroupBox groupbox12;
  internal TextBlock AircraftUp;
  internal System.Windows.Controls.GroupBox groupbox13;
  internal System.Windows.Controls.Label labeluid;
  internal System.Windows.Controls.Button buttonfirmwareupdate;
  internal System.Windows.Controls.Primitives.StatusBar statusbar;
  internal wpfledcontrol MYLED;
  internal System.Windows.Controls.Label statuslabel;
  internal System.Windows.Controls.ProgressBar progressbar;
  internal Grid homeResizing;
  internal Thumb ResizeDrop;
  internal Thumb ResizeRight;
  internal Thumb ResizeBottom;
  internal TextBlock Account;
  private bool _contentLoaded;

  public void DownloadFile(string URL, string filename)
  {
    float percent = 0.0f;
    try
    {
      HttpWebResponse response = (HttpWebResponse) WebRequest.Create(URL).GetResponse();
      long totalBytes = response.ContentLength;
      this.Dispatcher.Invoke((Delegate) (() => this.progressbar.Maximum = (double) (int) totalBytes));
      Stream responseStream = response.GetResponseStream();
      Stream stream = (Stream) new FileStream(filename, FileMode.Create);
      long num = 0;
      byte[] buffer = new byte[1024 /*0x0400*/];
      int count = responseStream.Read(buffer, 0, buffer.Length);
      while (count > 0)
      {
        num = (long) count + num;
        System.Windows.Forms.Application.DoEvents();
        stream.Write(buffer, 0, count);
        long downloadedByte = num;
        this.Dispatcher.Invoke((Delegate) (() => this.progressbar.Value = (double) (int) downloadedByte));
        count = responseStream.Read(buffer, 0, buffer.Length);
        percent = (float) ((double) num / (double) totalBytes * 100.0);
        this.Dispatcher.Invoke((Delegate) (() => this.statuslabel.Content = (object) $"The current downloadnewfile progress:{percent.ToString("f2")}%"));
        System.Windows.Forms.Application.DoEvents();
      }
      stream.Close();
      responseStream.Close();
      this.Dispatcher.Invoke((Delegate) (() => this.progressbar.Visibility = Visibility.Hidden));
    }
    catch (Exception ex)
    {
      WriteLog.CreateLog(ex);
      throw;
    }
  }

  private string AESDecryptbyte(string text)
  {
    string s = "2015-10-10#YUNEEC#2017-10-10#000";
    RijndaelManaged rijndaelManaged = new RijndaelManaged();
    rijndaelManaged.Mode = CipherMode.ECB;
    rijndaelManaged.Padding = PaddingMode.Zeros;
    rijndaelManaged.Key = Encoding.UTF8.GetBytes(s);
    ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor();
    byte[] numArray = Convert.FromBase64String(text);
    byte[] inputBuffer = numArray;
    int length = numArray.Length;
    return Encoding.UTF8.GetString(decryptor.TransformFinalBlock(inputBuffer, 0, length));
  }

  public bool isConnInternet()
  {
    Ping ping = new Ping();
    try
    {
      return ping.Send("www.baidu.com").Status == IPStatus.Success;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  private void AddPoints(List<DoublePoint> sourcepoints, List<DoublePoint> sourcepointsgreen)
  {
    this.columnseries.Points.Clear();
    this.columnseriesgreen.Points.Clear();
    sourcepoints.ForEach((Action<DoublePoint>) (p => this.columnseries.Points.Add((ChartPoint) p)));
    sourcepointsgreen.ForEach((Action<DoublePoint>) (p => this.columnseriesgreen.Points.Add((ChartPoint) p)));
    List<DoublePoint> doublePointList = sourcepointsgreen;
    doublePointList.Sort((Comparison<DoublePoint>) ((x, y) => -x.Value.CompareTo(y.Value)));
    if (doublePointList.Count < 5)
      this.AveSnr.Text = "0";
    else
      this.AveSnr.Text = ((doublePointList[0].Value + doublePointList[1].Value + doublePointList[2].Value + doublePointList[3].Value + doublePointList[4].Value) / 5.0).ToString();
  }

  private byte JudgeMent_Byte(UasSysStatus MavSysStatus, MavSysStatusSensor MavSys)
  {
    byte num1 = 0;
    if ((MavSysStatus.OnboardControlSensorsPresent & MavSys) != MavSys)
      return (byte) ((uint) num1 | 0U);
    byte num2 = (byte) ((uint) num1 | 4U);
    if ((MavSysStatus.OnboardControlSensorsEnabled & MavSys) != MavSys)
      return (byte) ((uint) num2 | 0U);
    byte num3 = (byte) ((uint) num2 | 2U);
    return (MavSysStatus.OnboardControlSensorsHealth & MavSys) == MavSys ? (byte) ((uint) num3 | 1U) : (byte) ((uint) num3 | 0U);
  }

  private void YUNEEC_CLOSE(MainWindow.ConnectWays way)
  {
    try
    {
      this.statuslabel.Content = (object) "";
      this.MYLED.Status = false;
      this.requestanswer = true;
      this.checkenbletesting.IsChecked = new bool?(false);
      this.checkenbletesting.IsEnabled = false;
      this.menuitemconnect.Header = (object) "Connect";
      this.judgementO.Judgementindex = 2;
      this.judgementP.Judgementindex = 2;
      this.judgementC.Judgementindex = 2;
      this.judgementG.Judgementindex = 2;
      this.judgementS.Judgementindex = 2;
      this.judgementR.Judgementindex = 2;
      this.judgementOF.Judgementindex = 2;
      this.judgementRS.Judgementindex = 2;
      this.labelR.Content = (object) "";
      this.labelOF.Content = (object) "";
      this.labelRS.Content = (object) "";
      this.labelO.Content = (object) "";
      this.labelP.Content = (object) "";
      this.labelC.Content = (object) "";
      this.labelG.Content = (object) "";
      this.labelS.Content = (object) "";
      this.Myuid = string.Empty;
      switch (way)
      {
        case MainWindow.ConnectWays.YUNEEC_USB_CONNECT_ONE:
          this.usbMavLink.OnPacketReceived -= new PacketReceivedDelegate(this.Mavlink_OnPacketReceived);
          this.timerefreshstatus.Dispose();
          this.usbMavLink.Dispose();
          break;
        case MainWindow.ConnectWays.YUNEEC_SERIALPORT_CONNECT_TWO:
          this.serialportMavlink.OnPacketReceived -= new PacketReceivedDelegate(this.Mavlink_OnPacketReceived);
          this.timerefreshstatus.Dispose();
          this.serialportMavlink.Dispose();
          break;
      }
    }
    catch
    {
      this.statuslabel.Content = (object) "";
      this.MYLED.Status = false;
      this.requestanswer = true;
      this.checkenbletesting.IsChecked = new bool?(false);
      this.checkenbletesting.IsEnabled = false;
      this.menuitemconnect.Header = (object) "Connect";
      this.labelO.Content = (object) "";
      this.labelP.Content = (object) "";
      this.labelC.Content = (object) "";
      this.labelG.Content = (object) "";
      this.labelS.Content = (object) "";
      this.labelR.Content = (object) "";
      this.labelOF.Content = (object) "";
      this.labelRS.Content = (object) "";
    }
  }

  private void ReadConfigFile()
  {
    AppSettingsSection section = (AppSettingsSection) ConfigurationManager.OpenExeConfiguration("WpfAppTyphoonH.exe").GetSection("appSettings");
    this.usbVID = Convert.ToInt32(section.Settings["USBVID"].Value.Remove(0, 2), 16 /*0x10*/);
    this.usbPID = Convert.ToInt32(section.Settings["USBPID"].Value.Remove(0, 2), 16 /*0x10*/);
    this.serialportname = section.Settings["SERIALPORTNAME"].Value;
    this.serialportbaud = Convert.ToInt32(section.Settings["SERIALPORTBAUD"].Value);
    this.enableauto = section.Settings["EABLEAUTO"].Value == "TRUE";
    switch (Convert.ToInt16(section.Settings["CONNECTWAY"].Value))
    {
      case 0:
        this.connectway = MainWindow.ConnectWays.YUNEEC_NULL;
        this.menuitemusb.IsChecked = false;
        this.menuitemserialport.IsChecked = false;
        break;
      case 1:
        this.connectway = MainWindow.ConnectWays.YUNEEC_USB_CONNECT_ONE;
        this.menuitemusb.IsChecked = true;
        this.menuitemserialport.IsChecked = false;
        break;
      case 2:
        this.connectway = MainWindow.ConnectWays.YUNEEC_SERIALPORT_CONNECT_TWO;
        this.menuitemusb.IsChecked = false;
        this.menuitemserialport.IsChecked = true;
        break;
    }
    switch (Convert.ToInt16(section.Settings["FONTSIZE"].Value))
    {
      case 12:
        this.menuitem14.IsChecked = false;
        this.menuitem16.IsChecked = false;
        this.menuitem18.IsChecked = false;
        this.menuitem12.IsChecked = true;
        this.FontSize = 12.0;
        break;
      case 14:
        this.menuitem14.IsChecked = true;
        this.menuitem16.IsChecked = false;
        this.menuitem18.IsChecked = false;
        this.menuitem12.IsChecked = false;
        this.FontSize = 14.0;
        break;
      case 16 /*0x10*/:
        this.menuitem14.IsChecked = false;
        this.menuitem16.IsChecked = true;
        this.menuitem18.IsChecked = false;
        this.menuitem12.IsChecked = false;
        this.FontSize = 16.0;
        break;
      case 18:
        this.menuitem14.IsChecked = false;
        this.menuitem16.IsChecked = false;
        this.menuitem18.IsChecked = true;
        this.menuitem12.IsChecked = false;
        this.FontSize = 18.0;
        break;
    }
  }

  public void WriteConfigFile()
  {
    System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration("WpfAppTyphoonH.exe");
    AppSettingsSection section = (AppSettingsSection) configuration.GetSection("appSettings");
    section.Settings["USBVID"].Value = "0x" + $"{this.usbVID:X4}";
    section.Settings["USBPID"].Value = "0x" + $"{this.usbPID:X4}";
    section.Settings["SERIALPORTNAME"].Value = this.serialportname;
    section.Settings["SERIALPORTBAUD"].Value = this.serialportbaud.ToString();
    section.Settings["EABLEAUTO"].Value = !this.enableauto ? "FALSE" : "TRUE";
    configuration.Save();
  }

  public void WriteConfigFile_ConnectWay()
  {
    System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration("WpfAppTyphoonH.exe");
    AppSettingsSection section = (AppSettingsSection) configuration.GetSection("appSettings");
    switch (this.connectway)
    {
      case MainWindow.ConnectWays.YUNEEC_NULL:
        section.Settings["CONNECTWAY"].Value = "0";
        break;
      case MainWindow.ConnectWays.YUNEEC_USB_CONNECT_ONE:
        section.Settings["CONNECTWAY"].Value = "1";
        break;
      case MainWindow.ConnectWays.YUNEEC_SERIALPORT_CONNECT_TWO:
        section.Settings["CONNECTWAY"].Value = "2";
        break;
    }
    configuration.Save();
  }

  public void WriteConfigFile_FontSize()
  {
    System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration("WpfAppTyphoonH.exe");
    AppSettingsSection section = (AppSettingsSection) configuration.GetSection("appSettings");
    switch (this.FontSize)
    {
      case 12.0:
        section.Settings["FONTSIZE"].Value = "12";
        break;
      case 14.0:
        section.Settings["FONTSIZE"].Value = "14";
        break;
      case 16.0:
        section.Settings["FONTSIZE"].Value = "16";
        break;
      case 18.0:
        section.Settings["FONTSIZE"].Value = "18";
        break;
    }
    configuration.Save();
  }

  public string NewFilename
  {
    set
    {
      this.Newfilename = value;
      this.haveanewfile = true;
    }
    get => this.Newfilename;
  }

  public event PropertyChangedEventHandler PropertyChanged;

  private bool DownLoading
  {
    set
    {
      this._downloading = value;
      this.Dispatcher.Invoke(this._downloading ? (Delegate) (() => this.buttonfirmwareupdate.IsEnabled = false) : (Delegate) (() => this.buttonfirmwareupdate.IsEnabled = true));
    }
    get => this._downloading;
  }

  public string Myuid
  {
    get => this._myuid;
    set
    {
      this._myuid = value;
      this.OnPropertyChanged(nameof (Myuid));
      if (this._licFile.Keys.Contains<string>(this._myuid))
        this.Dispatcher.Invoke((Delegate) (() =>
        {
          this.ButtonNoFlyEnable.Visibility = Visibility.Visible;
          this.ButtonFlyEnable.Visibility = Visibility.Visible;
          this.ButtonClearPar.Visibility = Visibility.Visible;
        }));
      else
        this.Dispatcher.Invoke((Delegate) (() =>
        {
          this.ButtonNoFlyEnable.Visibility = Visibility.Collapsed;
          this.ButtonFlyEnable.Visibility = Visibility.Collapsed;
          this.ButtonClearPar.Visibility = Visibility.Collapsed;
        }));
    }
  }

  private void OnPropertyChanged(string value)
  {
    PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
    if (propertyChanged == null)
      return;
    propertyChanged((object) this, new PropertyChangedEventArgs(value));
  }

  public MainWindow()
  {
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.Filter = "Lic文件(*.pfx)|*.pfx|所有文件(*.*)|*.*";
    openFileDialog.RestoreDirectory = true;
    this.openfile = openFileDialog;
    this.serialportname = "COM1";
    this.serialportbaud = 115200;
    this.usbVID = 1155;
    this.usbPID = 22336;
    this.enableauto = true;
    this.mySqlConnectionString = "Server=rm-uf69k1efi3nt2pi52o.mysql.rds.aliyuncs.com;Database=account;Uid=yuneec;Pwd=yuneec;";
    this.points = new List<DoublePoint>();
    this.pointsused = new List<DoublePoint>();
    this.requestanswer = true;
    this.DirPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TyphoonHGUI\\License";
    this._licFile = new Dictionary<string, byte[]>();
    this._filedata = new MainWindow.FData();
    this.ver = new Version();
    this.account = new WpfAppTyphoonH.Account();
    this.dbconnect = new DBConnect();
    this.r = new Regex("COM\\d+");
    // ISSUE: explicit constructor call
    base.\u002Ector();
    this.InitializeComponent();
    this.GetKeys();
    this.ReadConfigFile();
    this.checkinternet = new System.Threading.Timer(new TimerCallback(this.checktheinternet), (object) null, 0, 10000);
    this.checkenbletesting.IsEnabled = false;
    switch (this.connectway)
    {
      case MainWindow.ConnectWays.YUNEEC_USB_CONNECT_ONE:
        this.statuslabel.Content = (object) "The connection method is USB. Device: TyphoonH.";
        break;
      case MainWindow.ConnectWays.YUNEEC_SERIALPORT_CONNECT_TWO:
        this.statuslabel.Content = (object) $"The connection method is serialport. Port: {this.serialportname} Baud: {this.serialportbaud.ToString()}";
        break;
    }
    MainWindow.DeviceNotifier.OnDeviceNotify += new EventHandler<DeviceNotifyEventArgs>(this.DeviceNotifier_OnDeviceNotify);
    Task.Factory.StartNew<string[]>((Func<string[]>) (() => this.MulGetHardwareInfo(MainWindow.HardwareEnum.Win32_PnPEntity, "DeviceID")));
    this.labeluid.DataContext = (object) this;
    Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
    this.StartHome.DataContext = (object) this.ver;
    this.Account.DataContext = (object) this.account;
  }

  private void DeviceNotifier_OnDeviceNotify(object sender, DeviceNotifyEventArgs e)
  {
    if (this.DownLoading || this.isa)
      return;
    if (e.EventType == EventType.DeviceArrival)
    {
      this.isa = true;
      Task.Factory.StartNew<string[]>((Func<string[]>) (() => this.MulGetHardwareInfo(MainWindow.HardwareEnum.Win32_PnPEntity, "DeviceID")));
    }
    else
    {
      if (e.EventType != EventType.DeviceRemoveComplete)
        return;
      this.isa = true;
      Task.Factory.StartNew((Action) (() => this.Usbmove(MainWindow.HardwareEnum.Win32_PnPEntity, "DeviceID")));
    }
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
        this.Dispatcher.Invoke((Delegate) (() => this.menuitemconnect_Click((object) this, new RoutedEventArgs())));
        managementObjectSearcher.Dispose();
      }
    }
    catch
    {
      this.isa = false;
    }
    finally
    {
      this.isa = false;
    }
  }

  public string[] MulGetHardwareInfo(MainWindow.HardwareEnum hardType, string propKey)
  {
    List<string> stringList = new List<string>();
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
              this.serialportname = match.Value;
              this.Dispatcher.Invoke((Delegate) (() => this.menuitemconnect_Click((object) this, new RoutedEventArgs())));
              break;
            }
          }
        }
        managementObjectSearcher.Dispose();
      }
      return stringList.ToArray();
    }
    catch
    {
      return (string[]) null;
    }
    finally
    {
      this.isa = false;
    }
  }

  private void GetUid()
  {
    MavlinkRequestInfoCmd msg = new MavlinkRequestInfoCmd()
    {
      TargetSystem = MavRequestInfoSystemId.Uid,
      TargetComponent = 0,
      Type = MavRequestInfoType.Product
    };
    switch (this.connectway)
    {
      case MainWindow.ConnectWays.YUNEEC_USB_CONNECT_ONE:
        this.usbMavLink.SendMessage((UasMessage) msg);
        break;
      case MainWindow.ConnectWays.YUNEEC_SERIALPORT_CONNECT_TWO:
        this.serialportMavlink.SendMessage((UasMessage) msg);
        break;
    }
  }

  private void OpenGpsDbTest()
  {
    MavlinkRequestInfoCmd msg = new MavlinkRequestInfoCmd()
    {
      TargetSystem = MavRequestInfoSystemId.GpsDbTest,
      TargetComponent = 0,
      Type = MavRequestInfoType.Product
    };
    switch (this.connectway)
    {
      case MainWindow.ConnectWays.YUNEEC_USB_CONNECT_ONE:
        this.usbMavLink.SendMessage((UasMessage) msg);
        break;
      case MainWindow.ConnectWays.YUNEEC_SERIALPORT_CONNECT_TWO:
        this.serialportMavlink.SendMessage((UasMessage) msg);
        break;
    }
  }

  private void GetKeys()
  {
    if (!Directory.Exists(this.DirPath))
      return;
    foreach (string fileSystemEntry in Directory.GetFileSystemEntries(this.DirPath))
    {
      FileStream fileStream = new FileStream(fileSystemEntry, FileMode.Open, FileAccess.Read, FileShare.Read);
      if (fileStream.Length != 16L /*0x10*/)
      {
        int num = (int) YMessageBox.Show(fileSystemEntry + " Wrong!", "Note");
        fileStream.Dispose();
        System.IO.File.Delete(fileSystemEntry);
      }
      else
      {
        byte[] numArray = new byte[16 /*0x10*/];
        for (int index = 0; index < 16 /*0x10*/; ++index)
          numArray[index] = (byte) fileStream.ReadByte();
        this._licFile.Add(fileSystemEntry.Split('\\')[fileSystemEntry.Split('\\').Length - 1].Split('.')[0], numArray);
      }
    }
  }

  private void SendPARAM_REQUEST_LIST()
  {
    UasParamRequestList msg = new UasParamRequestList()
    {
      TargetSystem = 1,
      TargetComponent = 0
    };
    switch (this.connectway)
    {
      case MainWindow.ConnectWays.YUNEEC_USB_CONNECT_ONE:
        this.usbMavLink.SendMessage((UasMessage) msg);
        break;
      case MainWindow.ConnectWays.YUNEEC_SERIALPORT_CONNECT_TWO:
        this.serialportMavlink.SendMessage((UasMessage) msg);
        break;
    }
  }

  private void Mavlink_OnPacketReceived(object sender, MavLinkPacket packet)
  {
    byte messageId = packet.MessageId;
    if (messageId <= (byte) 74)
    {
      if (messageId <= (byte) 42)
      {
        switch (messageId)
        {
          case 0:
            if (this.requestanswer)
              this.SendPARAM_REQUEST_LIST();
            switch (this.GetBlock)
            {
              case MainWindow.GetInformation.Uid:
                this.GetUid();
                this.GetBlock = MainWindow.GetInformation.Software;
                break;
              case MainWindow.GetInformation.Software:
                this.GetSoftware();
                this.GetBlock = MainWindow.GetInformation.GpsDb;
                break;
              case MainWindow.GetInformation.GpsDb:
                this.OpenGpsDbTest();
                this.GetBlock = MainWindow.GetInformation.Uid;
                break;
              default:
                this.GetBlock = MainWindow.GetInformation.Uid;
                break;
            }
            this.Dispatcher.Invoke((Delegate) (() =>
            {
              this.MYLED.Status = !this.MYLED.Status;
              this.checkenbletesting.IsEnabled = true;
            }));
            break;
          case 1:
            if (this.JudgeMent_Byte((UasSysStatus) packet.Message, MavSysStatusSensor._3dGyro) == (byte) 7)
              this.Dispatcher.Invoke((Delegate) (() =>
              {
                this.judgementO.Judgementindex = 1;
                this.labelO.Content = (object) "";
              }));
            else
              this.Dispatcher.Invoke((Delegate) (() =>
              {
                this.judgementO.Judgementindex = 0;
                this.labelO.Content = (object) "FAILED";
              }));
            if (this.JudgeMent_Byte((UasSysStatus) packet.Message, MavSysStatusSensor.AbsolutePressure) == (byte) 7)
              this.Dispatcher.Invoke((Delegate) (() =>
              {
                this.judgementP.Judgementindex = 1;
                this.labelP.Content = (object) "";
              }));
            else
              this.Dispatcher.Invoke((Delegate) (() =>
              {
                this.judgementP.Judgementindex = 0;
                this.labelP.Content = (object) "FAILED";
              }));
            if (this.JudgeMent_Byte((UasSysStatus) packet.Message, MavSysStatusSensor._3dMag) == (byte) 7)
              this.Dispatcher.Invoke((Delegate) (() =>
              {
                this.judgementC.Judgementindex = 1;
                this.labelC.Content = (object) "";
              }));
            else
              this.Dispatcher.Invoke((Delegate) (() =>
              {
                this.judgementC.Judgementindex = 0;
                this.labelC.Content = (object) "FAILED";
              }));
            if (this.JudgeMent_Byte((UasSysStatus) packet.Message, MavSysStatusSensor.Gps) == (byte) 7)
              this.Dispatcher.Invoke((Delegate) (() =>
              {
                this.judgementG.Judgementindex = 1;
                this.labelG.Content = (object) "";
              }));
            else
              this.Dispatcher.Invoke((Delegate) (() =>
              {
                this.judgementG.Judgementindex = 0;
                this.labelG.Content = (object) "FAILED";
              }));
            if (this.JudgeMent_Byte((UasSysStatus) packet.Message, MavSysStatusSensor.MotorOutputs) == (byte) 7)
              this.Dispatcher.Invoke((Delegate) (() =>
              {
                this.judgementS.Judgementindex = 1;
                this.labelS.Content = (object) "";
              }));
            else
              this.Dispatcher.Invoke((Delegate) (() =>
              {
                this.judgementS.Judgementindex = 0;
                this.labelS.Content = (object) "FAILED";
              }));
            if (this.JudgeMent_Byte((UasSysStatus) packet.Message, MavSysStatusSensor.Sonar) == (byte) 7)
              this.Dispatcher.Invoke((Delegate) (() =>
              {
                this.judgementR.Judgementindex = 1;
                this.labelR.Content = (object) "";
              }));
            else
              this.Dispatcher.Invoke((Delegate) (() =>
              {
                this.judgementR.Judgementindex = 0;
                this.labelR.Content = (object) "FAILED";
              }));
            if (this.JudgeMent_Byte((UasSysStatus) packet.Message, MavSysStatusSensor.RealSense) == (byte) 7)
              this.Dispatcher.Invoke((Delegate) (() =>
              {
                this.judgementRS.Judgementindex = 1;
                this.labelRS.Content = (object) "";
                this.judgementOF.Judgementindex = 1;
                this.labelOF.Content = (object) "";
              }));
            else
              this.Dispatcher.Invoke((Delegate) (() =>
              {
                this.judgementRS.Judgementindex = 0;
                this.labelRS.Content = (object) "Not Installed";
                this.judgementOF.Judgementindex = 0;
                this.labelOF.Content = (object) "Not Installed";
              }));
            this.Dispatcher.Invoke((Delegate) (() =>
            {
              float num1 = (float) ((UasSysStatus) packet.Message).VoltageBattery / 1000f;
              float num2 = (double) num1 < 13.199999809265137 ? 0.0f : (float) (100.0 * ((double) num1 - 13.199999809265137) / 3.5999999046325684);
              this.textboxvoltage.Text = num1.ToString("f1");
              this.labelvoltage.Content = (object) (num2.ToString("f1") + "%");
              this.Battery.Remain = num2;
              if ((double) num2 < 30.0)
                this.labelvoltagev.Visibility = Visibility.Visible;
              else
                this.labelvoltagev.Visibility = Visibility.Hidden;
            }));
            break;
          case 2:
            break;
          default:
            switch ((int) messageId - 22)
            {
              case 0:
                this.requestanswer = false;
                string str1 = new string(((UasParamValue) packet.Message).ParamId);
                if (str1.Contains("FENCE_RADIUS"))
                {
                  this.Dispatcher.BeginInvoke((Delegate) (() => this.Geofencecurrentvalue.Content = (object) ((UasParamValue) packet.Message).ParamValue));
                  return;
                }
                if (str1.Contains("FENCE_ALT_MAX"))
                {
                  this.Dispatcher.BeginInvoke((Delegate) (() => this.Heightlimitcurrentvalue.Content = (object) ((UasParamValue) packet.Message).ParamValue));
                  return;
                }
                if (str1.Contains("NOFLY_ENABLED"))
                {
                  int num = (int) YMessageBox.Show("Successfully!", "Note");
                  return;
                }
                if (!str1.Contains("EKF_CLEAR_PARA") || (double) ((UasParamValue) packet.Message).ParamValue != 1.0)
                  return;
                int num3 = (int) YMessageBox.Show("Clear parameters successfully!Please restart manually.", "Note");
                return;
              case 1:
                return;
              case 2:
                this.Dispatcher.Invoke((Delegate) (() =>
                {
                  this.textboxlat.Text = ((UasGpsRawInt) packet.Message).Lat.ToString();
                  this.textboxlon.Text = ((UasGpsRawInt) packet.Message).Lon.ToString();
                  this.textboxalt.Text = ((UasGpsRawInt) packet.Message).Alt.ToString();
                  this.textboxeph.Text = ((double) ((UasGpsRawInt) packet.Message).Eph / 100.0).ToString();
                }));
                return;
              case 3:
                this.points.Clear();
                this.pointsused.Clear();
                for (int index = 0; index < 20; ++index)
                {
                  DoublePoint doublePoint = new DoublePoint();
                  doublePoint.Data = (double) (index + 1);
                  doublePoint.Value = (double) ((UasGpsStatus) packet.Message).SatelliteSnr[index];
                  if (((UasGpsStatus) packet.Message).SatelliteUsed[index] == (byte) 0)
                    this.points.Add(doublePoint);
                  else
                    this.pointsused.Add(doublePoint);
                }
                return;
              case 4:
                return;
              case 5:
                this.Dispatcher.Invoke((Delegate) (() =>
                {
                  short xacc = ((UasRawImu) packet.Message).Xacc;
                  short yacc = ((UasRawImu) packet.Message).Yacc;
                  short zacc = ((UasRawImu) packet.Message).Zacc;
                  this.textboxaccx.Text = xacc.ToString();
                  this.textboxaccy.Text = yacc.ToString();
                  this.textboxaccz.Text = zacc.ToString();
                  this.textboxgyrx.Text = ((UasRawImu) packet.Message).Xgyro.ToString();
                  this.textboxgyry.Text = ((UasRawImu) packet.Message).Ygyro.ToString();
                  this.textboxgyrz.Text = ((UasRawImu) packet.Message).Zgyro.ToString();
                  this.textboxcomx.Text = ((UasRawImu) packet.Message).Xmag.ToString();
                  this.textboxcomy.Text = ((UasRawImu) packet.Message).Ymag.ToString();
                  this.textboxcomz.Text = ((UasRawImu) packet.Message).Zmag.ToString();
                  this.textboxaccm.Text = Math.Sqrt((double) ((int) xacc * (int) xacc + (int) yacc * (int) yacc + (int) zacc * (int) zacc)).ToString("f2");
                }));
                return;
              case 6:
                return;
              case 7:
                this.Dispatcher.Invoke((Delegate) (() =>
                {
                  this.textboxpre.Text = ((UasScaledPressure) packet.Message).PressAbs.ToString("f2");
                  this.textboxpretem.Text = ((double) ((UasScaledPressure) packet.Message).Temperature / 100.0).ToString("f2");
                  this.textboxprehe.Text = ((UasScaledPressure) packet.Message).PressDiff.ToString("f2");
                }));
                return;
              case 8:
                this.Dispatcher.Invoke((Delegate) (() =>
                {
                  this.textboxroll.Text = ((double) ((UasAttitude) packet.Message).Roll * 180.0 / Math.PI).ToString("f1");
                  this.textboxpitch.Text = ((double) ((UasAttitude) packet.Message).Pitch * 180.0 / Math.PI).ToString("f1");
                  this.textboxyaw.Text = ((double) ((UasAttitude) packet.Message).Yaw * 180.0 / Math.PI).ToString("f1");
                }));
                return;
              case 9:
                return;
              case 10:
                return;
              case 11:
                return;
              case 12:
                return;
              case 13:
                return;
              case 14:
                return;
              default:
                return;
            }
        }
      }
      else if (messageId <= (byte) 56)
      {
        if (messageId != (byte) 52)
        {
          if (messageId != (byte) 56)
            return;
          MavLinkMsgIdSendUid packetuid = packet.Message as MavLinkMsgIdSendUid;
          this.Dispatcher.Invoke((Delegate) (() => this.Myuid = $"{packetuid.UID[0].ToString("X8")}-{packetuid.UID[1].ToString("X8")}-{packetuid.UID[2].ToString("X8")}"));
        }
        else
        {
          MavlinkRequestInfoFeedback message = packet.Message as MavlinkRequestInfoFeedback;
          if (!(new string(message.ProductName).Replace(char.MinValue, ' ') != "                "))
            return;
          string str2 = " v" + ((float) message.SoftwareVersion * 0.01f).ToString("f2");
          string str3 = $" {(object) message.SoftwareYear}-{(object) message.SoftwareMonth}-{(object) message.SoftwareDay}";
          this.ver.Aircraftversion = str2;
          this.ver.Versiondata = str3;
        }
      }
      else if (messageId == (byte) 62)
        ;
    }
    else if (messageId <= (byte) 152)
    {
      if (messageId == (byte) 77 || messageId == (byte) 150)
        ;
    }
    else if (messageId <= (byte) 173)
    {
      switch ((int) messageId - 162)
      {
      }
    }
    else if (messageId == (byte) 174)
      ;
  }

  private void GetSoftware()
  {
    MavlinkRequestInfoCmd msg = new MavlinkRequestInfoCmd()
    {
      TargetSystem = MavRequestInfoSystemId.Autopilot,
      TargetComponent = 0,
      Type = MavRequestInfoType.Product
    };
    switch (this.connectway)
    {
      case MainWindow.ConnectWays.YUNEEC_USB_CONNECT_ONE:
        this.usbMavLink.SendMessage((UasMessage) msg);
        break;
      case MainWindow.ConnectWays.YUNEEC_SERIALPORT_CONNECT_TWO:
        this.serialportMavlink.SendMessage((UasMessage) msg);
        break;
    }
  }

  private void checktheinternet(object obj)
  {
    if (this._interneting || !this.isConnInternet())
      return;
    this._interneting = true;
    try
    {
      this.ver.ReadVersionXML("http://www.yuneec.com/download/firmware/Typhoon.H.firmware.xml");
    }
    catch (Exception ex)
    {
      WriteLog.CreateLog(ex);
    }
    finally
    {
      this._interneting = false;
    }
  }

  private void timerefreshstatusf(object obj)
  {
    ++this.refreshcount;
    this.Dispatcher.Invoke((Delegate) (() =>
    {
      if (this.refreshcount > 9)
      {
        this.AddPoints(this.points, this.pointsused);
        this.refreshcount = 0;
      }
      switch (this.connectway)
      {
        case MainWindow.ConnectWays.YUNEEC_USB_CONNECT_ONE:
          if (this.judgementO.Judgementindex == 2)
            this.judgementO.Judgementindex = 2;
          if (this.judgementP.Judgementindex == 2)
            this.judgementP.Judgementindex = 2;
          if (this.judgementC.Judgementindex == 2)
            this.judgementC.Judgementindex = 2;
          if (this.judgementG.Judgementindex == 2)
            this.judgementG.Judgementindex = 2;
          if (this.judgementS.Judgementindex == 2)
            this.judgementS.Judgementindex = 2;
          if (this.judgementR.Judgementindex == 2)
            this.judgementR.Judgementindex = 2;
          if (this.judgementOF.Judgementindex == 2)
            this.judgementOF.Judgementindex = 2;
          if (this.judgementRS.Judgementindex == 2)
            this.judgementRS.Judgementindex = 2;
          this.statuslabel.Content = (object) this.usbMavLink.usbstate;
          if (!this.usbMavLink.usbstate.Contains("Remove the USB device is the target device."))
            break;
          this.Dispatcher.Invoke((Delegate) (() =>
          {
            this.MYLED.Status = false;
            this.requestanswer = true;
            this.checkenbletesting.IsChecked = new bool?(false);
            this.checkenbletesting.IsEnabled = false;
            this.judgementO.Judgementindex = 2;
            this.judgementP.Judgementindex = 2;
            this.judgementC.Judgementindex = 2;
            this.judgementG.Judgementindex = 2;
            this.judgementS.Judgementindex = 2;
            this.judgementR.Judgementindex = 2;
            this.judgementOF.Judgementindex = 2;
            this.judgementRS.Judgementindex = 2;
            this.labelR.Content = (object) "";
            this.labelOF.Content = (object) "";
            this.labelRS.Content = (object) "";
            this.labelO.Content = (object) "";
            this.labelP.Content = (object) "";
            this.labelC.Content = (object) "";
            this.labelG.Content = (object) "";
            this.labelS.Content = (object) "";
          }));
          break;
        case MainWindow.ConnectWays.YUNEEC_SERIALPORT_CONNECT_TWO:
          if (this.judgementO.Judgementindex == 2)
            this.judgementO.Judgementindex = 2;
          if (this.judgementP.Judgementindex == 2)
            this.judgementP.Judgementindex = 2;
          if (this.judgementC.Judgementindex == 2)
            this.judgementC.Judgementindex = 2;
          if (this.judgementG.Judgementindex == 2)
            this.judgementG.Judgementindex = 2;
          if (this.judgementS.Judgementindex == 2)
            this.judgementS.Judgementindex = 2;
          if (this.judgementR.Judgementindex == 2)
            this.judgementR.Judgementindex = 2;
          if (this.judgementOF.Judgementindex == 2)
            this.judgementOF.Judgementindex = 2;
          if (this.judgementRS.Judgementindex != 2)
            break;
          this.judgementRS.Judgementindex = 2;
          break;
      }
    }));
  }

  private void menuitem12_Click(object sender, RoutedEventArgs e)
  {
    this.FontSize = 12.0;
    this.menuitem14.IsChecked = false;
    this.menuitem16.IsChecked = false;
    this.menuitem18.IsChecked = false;
    this.menuitem12.IsChecked = true;
    this.WriteConfigFile_FontSize();
  }

  private void menuitem14_Click(object sender, RoutedEventArgs e)
  {
    this.FontSize = 14.0;
    this.menuitem14.IsChecked = true;
    this.menuitem16.IsChecked = false;
    this.menuitem18.IsChecked = false;
    this.menuitem12.IsChecked = false;
    this.WriteConfigFile_FontSize();
  }

  private void menuitem16_Click(object sender, RoutedEventArgs e)
  {
    this.FontSize = 16.0;
    this.menuitem14.IsChecked = false;
    this.menuitem16.IsChecked = true;
    this.menuitem18.IsChecked = false;
    this.menuitem12.IsChecked = false;
    this.WriteConfigFile_FontSize();
  }

  private void menuitem18_Click(object sender, RoutedEventArgs e)
  {
    this.FontSize = 18.0;
    this.menuitem14.IsChecked = false;
    this.menuitem16.IsChecked = false;
    this.menuitem18.IsChecked = true;
    this.menuitem12.IsChecked = false;
    this.WriteConfigFile_FontSize();
  }

  private void menuitemusb_Click(object sender, RoutedEventArgs e)
  {
    this.YUNEEC_CLOSE(this.connectway);
    this.connectway = MainWindow.ConnectWays.YUNEEC_USB_CONNECT_ONE;
    this.statuslabel.Content = (object) "The connection method is USB. Device: TyphoonH.";
    this.menuitemusb.IsChecked = true;
    this.menuitemserialport.IsChecked = false;
    this.WriteConfigFile_ConnectWay();
  }

  private void menuitemserialport_Click(object sender, RoutedEventArgs e)
  {
    this.YUNEEC_CLOSE(this.connectway);
    this.connectway = MainWindow.ConnectWays.YUNEEC_SERIALPORT_CONNECT_TWO;
    this.statuslabel.Content = (object) ("The connection method is serialport. Port: " + this.serialportname);
    this.menuitemusb.IsChecked = false;
    this.menuitemserialport.IsChecked = true;
    this.WriteConfigFile_ConnectWay();
  }

  private void menuitemclose_Click(object sender, RoutedEventArgs e)
  {
    try
    {
      this.Close();
    }
    catch
    {
    }
  }

  private void menuitemsettings_Click(object sender, RoutedEventArgs e)
  {
    new SettingsWindow(this).ShowDialog();
  }

  private void menuitemconnect_Click(object sender, RoutedEventArgs e)
  {
    if ((string) this.menuitemconnect.Header == "Disconnect")
    {
      this.YUNEEC_CLOSE(this.connectway);
      this.StartHome.IsSelected = true;
      this.TextBlockSpecification.Visibility = Visibility.Visible;
    }
    else
    {
      if (this.DownLoading)
        return;
      try
      {
        switch (this.connectway)
        {
          case MainWindow.ConnectWays.YUNEEC_USB_CONNECT_ONE:
            this.usbMavLink = new MavLinkUSBTransport();
            this.usbMavLink.myVID = this.usbVID;
            this.usbMavLink.myPID = this.usbPID;
            this.usbMavLink.EnbaleAuto = this.enableauto;
            this.usbMavLink.Initialize();
            this.usbMavLink.BeginHeartBeatLoop();
            this.statuslabel.Content = (object) "USB is opened.";
            this.usbMavLink.OnPacketReceived += new PacketReceivedDelegate(this.Mavlink_OnPacketReceived);
            this.MYLED.Status = true;
            this.menuitemconnect.Header = (object) "Disconnect";
            break;
          case MainWindow.ConnectWays.YUNEEC_SERIALPORT_CONNECT_TWO:
            this.serialportMavlink = new MavLinkSerialPortTransport();
            this.serialportMavlink.SerialPortName = this.serialportname;
            this.serialportMavlink.BaudRate = this.serialportbaud;
            this.serialportMavlink.Initialize();
            this.serialportMavlink.BeginHeartBeatLoop();
            this.serialportMavlink.OnPacketReceived += new PacketReceivedDelegate(this.Mavlink_OnPacketReceived);
            this.statuslabel.Content = (object) "SerialPort is opened.";
            this.MYLED.Status = true;
            this.menuitemconnect.Header = (object) "Disconnect";
            break;
        }
        this.timerefreshstatus = new System.Threading.Timer(new TimerCallback(this.timerefreshstatusf), (object) null, 1000, 100);
        if (this.StartHome.IsSelected)
          this.FirstHome.IsSelected = true;
        this.TextBlockSpecification.Visibility = Visibility.Collapsed;
      }
      catch (Exception ex)
      {
        WriteLog.CreateLog(ex);
        int num = (int) YMessageBox.Show(ex.Message, "Error");
      }
    }
  }

  private void buttonfirmwareupdate_Click(object sender, RoutedEventArgs e)
  {
  }

  private void Window_Closing(object sender, CancelEventArgs e)
  {
    this.YUNEEC_CLOSE(this.connectway);
  }

  private void Label_MouseDown(object sender, MouseButtonEventArgs e)
  {
    if (System.IO.File.Exists(this.NewFilename))
    {
      int num1 = (int) YMessageBox.Show("File exists!", "Note");
    }
    else
    {
      this.progressbar.Visibility = Visibility.Visible;
      if (this.isConnInternet())
      {
        Task.Factory.StartNew((Action) (() => this.DownloadFile(this.downloadnewfile, this.NewFilename)));
      }
      else
      {
        int num2 = (int) YMessageBox.Show("Network is not connected!", "Note");
      }
    }
  }

  private void checkenbletesting_Checked(object sender, RoutedEventArgs e)
  {
    bool? nullable = new MyMessageBox().ShowDialog();
    bool flag = true;
    if ((nullable.GetValueOrDefault() == flag ? (nullable.HasValue ? 1 : 0) : 0) != 0)
    {
      this.AircraftESC.IsEnabled = true;
      this.AircraftESC.yEnable = true;
      this.buttonallturn.IsEnabled = true;
      this.AircraftESC.Fire += new EventHandler<FireEventArgs>(this.AircraftESC_Fire);
      this.AircraftESC.NoFire += new EventHandler<FireEventArgs>(this.AircraftESC_NoFire);
    }
    else
      this.checkenbletesting.IsChecked = new bool?(false);
  }

  private void checkenbletesting_Unchecked(object sender, RoutedEventArgs e)
  {
    this.AircraftESC.IsEnabled = false;
    this.AircraftESC.yEnable = false;
    this.buttonallturn.IsEnabled = false;
    this.AircraftESC.Fire -= new EventHandler<FireEventArgs>(this.AircraftESC_Fire);
    this.AircraftESC.NoFire -= new EventHandler<FireEventArgs>(this.AircraftESC_NoFire);
    this.sendcommandlong?.Dispose();
  }

  private void Sendcommandmotor(object obj)
  {
    for (int index = 0; index < 500; ++index)
    {
      UasCommandLong msg = new UasCommandLong();
      msg.TargetSystem = (byte) 1;
      msg.TargetComponent = (byte) 1;
      msg.Command = MavCmd.DoTestMotor;
      msg.Confirmation = (byte) 1;
      msg.Param1 = (float) byte.MaxValue;
      this.Dispatcher.Invoke((Delegate) (() => this.AircraftESC.FIRE = byte.MaxValue));
      msg.Param2 = 0.0f;
      msg.Param3 = 29f;
      msg.Param4 = 100f;
      switch (this.connectway)
      {
        case MainWindow.ConnectWays.YUNEEC_USB_CONNECT_ONE:
          this.usbMavLink.SendMessage((UasMessage) msg);
          break;
        case MainWindow.ConnectWays.YUNEEC_SERIALPORT_CONNECT_TWO:
          this.serialportMavlink.SendMessage((UasMessage) msg);
          break;
      }
      Thread.Sleep(10);
    }
    this.Dispatcher.Invoke((Delegate) (() =>
    {
      this.AircraftESC.IsEnabled = true;
      this.buttonallturn.IsEnabled = true;
      this.AircraftESC.FIRE = (byte) 0;
    }));
  }

  private void AircraftESC_Fire(object sender, FireEventArgs e)
  {
    Task.Factory.StartNew((Action) (() => this.firefuction(e.firenumber)));
  }

  private void AircraftESC_NoFire(object sender, FireEventArgs e) => MainWindow.firing = false;

  private void firefuction(int n)
  {
    MainWindow.firing = true;
    while (MainWindow.firing)
    {
      UasCommandLong msg = new UasCommandLong()
      {
        TargetSystem = 1,
        TargetComponent = 1,
        Command = MavCmd.DoTestMotor,
        Confirmation = 1
      };
      switch (n)
      {
        case 1:
          msg.Param1 = 2f;
          break;
        case 2:
          msg.Param1 = 1f;
          break;
        case 3:
          msg.Param1 = 6f;
          break;
        case 4:
          msg.Param1 = 5f;
          break;
        case 5:
          msg.Param1 = 4f;
          break;
        case 6:
          msg.Param1 = 3f;
          break;
      }
      msg.Param2 = 0.0f;
      msg.Param3 = 29f;
      msg.Param4 = 100f;
      switch (this.connectway)
      {
        case MainWindow.ConnectWays.YUNEEC_USB_CONNECT_ONE:
          this.usbMavLink.SendMessage((UasMessage) msg);
          break;
        case MainWindow.ConnectWays.YUNEEC_SERIALPORT_CONNECT_TWO:
          this.serialportMavlink.SendMessage((UasMessage) msg);
          break;
      }
      Thread.Sleep(10);
    }
  }

  private void buttonallturn_Click(object sender, RoutedEventArgs e)
  {
    this.motornumber = 0;
    this.AircraftESC.IsEnabled = false;
    this.buttonallturn.IsEnabled = false;
    this.sendcommandlong = new System.Threading.Timer(new TimerCallback(this.Sendcommandmotor), (object) null, 200, 0);
  }

  private void ButtonNoFlyEnable_Click(object sender, RoutedEventArgs e)
  {
    if (!this._licFile.Keys.Contains<string>(this._myuid) || YMessageBox.Show("Do you want to Disable No Fly Zone?", "Note", YMessageBoxButton.YesNo) != YMessageResultButton.Yes || !((string) this.menuitemconnect.Header == "Disconnect"))
      return;
    MavlinkUidDecryptCmd msg = new MavlinkUidDecryptCmd()
    {
      Cmd = MavParamUidDecryptCmd.MavParamUidDecryptCmdDisNoFlyZone,
      Key = this._licFile[this._myuid]
    };
    switch (this.connectway)
    {
      case MainWindow.ConnectWays.YUNEEC_USB_CONNECT_ONE:
        this.usbMavLink.SendMessage((UasMessage) msg);
        break;
      case MainWindow.ConnectWays.YUNEEC_SERIALPORT_CONNECT_TWO:
        this.serialportMavlink.SendMessage((UasMessage) msg);
        break;
    }
  }

  private void ButtonClearPar_Click(object sender, RoutedEventArgs e)
  {
    if (YMessageBox.Show("Do you want to clear all parameters?", "Note", YMessageBoxButton.YesNo) != YMessageResultButton.Yes || !((string) this.menuitemconnect.Header == "Disconnect"))
      return;
    MavlinkUidDecryptCmd msg = new MavlinkUidDecryptCmd()
    {
      Cmd = MavParamUidDecryptCmd.MavParamUidDecryptCmdClear,
      Key = this._licFile[this._myuid]
    };
    switch (this.connectway)
    {
      case MainWindow.ConnectWays.YUNEEC_USB_CONNECT_ONE:
        this.usbMavLink.SendMessage((UasMessage) msg);
        break;
      case MainWindow.ConnectWays.YUNEEC_SERIALPORT_CONNECT_TWO:
        this.serialportMavlink.SendMessage((UasMessage) msg);
        break;
    }
  }

  private void menuitemLicense_Click(object sender, RoutedEventArgs e)
  {
    if (this.openfile.ShowDialog() != System.Windows.Forms.DialogResult.OK)
      return;
    bool flag = false;
    string fileName = this.openfile.FileName;
    string key = fileName.Split('\\')[fileName.Split('\\').Length - 1].Split('.')[0];
    string path = $"{this.DirPath}\\{key}.pfx";
    if (!Directory.Exists(this.DirPath))
      Directory.CreateDirectory(this.DirPath);
    using (FileStream fileStream1 = new FileStream(path, FileMode.Create))
    {
      FileStream fileStream2 = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
      if (fileStream2.Length != 16L /*0x10*/)
      {
        flag = true;
        int num = (int) YMessageBox.Show(fileName + " Wrong!", "Note");
      }
      else
      {
        byte[] buffer = new byte[16 /*0x10*/];
        for (int index = 0; index < 16 /*0x10*/; ++index)
          buffer[index] = (byte) fileStream2.ReadByte();
        if (this._licFile.Keys.Contains<string>(key))
          this._licFile.Remove(key);
        this._licFile.Add(key, buffer);
        fileStream1.Write(buffer, 0, 16 /*0x10*/);
      }
    }
    if (flag && System.IO.File.Exists(path))
      System.IO.File.Delete(path);
    if (this._myuid != null && this._licFile.Keys.Contains<string>(this._myuid))
    {
      this.ButtonNoFlyEnable.Visibility = Visibility.Visible;
      this.ButtonFlyEnable.Visibility = Visibility.Visible;
      this.ButtonClearPar.Visibility = Visibility.Visible;
    }
    else
    {
      this.ButtonNoFlyEnable.Visibility = Visibility.Collapsed;
      this.ButtonFlyEnable.Visibility = Visibility.Collapsed;
      this.ButtonClearPar.Visibility = Visibility.Collapsed;
    }
  }

  private void Window_Loaded(object sender, RoutedEventArgs e)
  {
    WpfAppTyphoonH.MyClass.NativeMethods.SetWindowNoBorder(new WindowInteropHelper((Window) this).Handle);
    this.StartHome.IsSelected = true;
    this.TextBlockSpecification.Visibility = Visibility.Visible;
  }

  private void Window_StateChanged(object sender, EventArgs e)
  {
  }

  private void Updategeofence_Click(object sender, RoutedEventArgs e)
  {
    if (YMessageBox.Show("Do you want to modify the Geo-fence?", "Note", YMessageBoxButton.YesNo) != YMessageResultButton.Yes || !((string) this.menuitemconnect.Header == "Disconnect"))
      return;
    string str = "FENCE_RADIUS";
    char[] destinationArray = new char[16 /*0x10*/];
    Array.Copy((Array) str.ToCharArray(), (Array) destinationArray, str.Length);
    UasParamSet msg = new UasParamSet();
    msg.TargetSystem = (byte) 1;
    msg.TargetComponent = (byte) 1;
    msg.ParamValue = (float) this.Geofencenewvalue.Value;
    msg.ParamType = MavParamType.Float;
    msg.ParamId = destinationArray;
    switch (this.connectway)
    {
      case MainWindow.ConnectWays.YUNEEC_USB_CONNECT_ONE:
        this.usbMavLink.SendMessage((UasMessage) msg);
        break;
      case MainWindow.ConnectWays.YUNEEC_SERIALPORT_CONNECT_TWO:
        this.serialportMavlink.SendMessage((UasMessage) msg);
        break;
    }
  }

  private void Updateheightlimit_Click(object sender, RoutedEventArgs e)
  {
    if (YMessageBox.Show("Do you want to modify the Height-limit?\t\nAfter the first-level battery low voltage warning,\t\nthe maximum flight height will be limited to the half of the Current Value of the Height limit.", "Note", YMessageBoxButton.YesNo) != YMessageResultButton.Yes || !((string) this.menuitemconnect.Header == "Disconnect"))
      return;
    string str = "FENCE_ALT_MAX";
    char[] destinationArray = new char[16 /*0x10*/];
    Array.Copy((Array) str.ToCharArray(), (Array) destinationArray, str.Length);
    UasParamSet msg = new UasParamSet();
    msg.TargetSystem = (byte) 1;
    msg.TargetComponent = (byte) 1;
    msg.ParamValue = (float) this.Heightlimitnewvalue.Value;
    msg.ParamType = MavParamType.Float;
    msg.ParamId = destinationArray;
    switch (this.connectway)
    {
      case MainWindow.ConnectWays.YUNEEC_USB_CONNECT_ONE:
        this.usbMavLink.SendMessage((UasMessage) msg);
        break;
      case MainWindow.ConnectWays.YUNEEC_SERIALPORT_CONNECT_TWO:
        this.serialportMavlink.SendMessage((UasMessage) msg);
        break;
    }
  }

  private void ResizeDrop_DragDelta(object sender, DragDeltaEventArgs e)
  {
    double num1 = this.Height + e.VerticalChange;
    double num2 = this.Width + e.HorizontalChange;
    if (num2 > this.MinWidth)
      this.Width = num2;
    if (num1 <= this.MinHeight)
      return;
    this.Height = num1;
  }

  private void ResizeRight_DragDelta(object sender, DragDeltaEventArgs e)
  {
    double num = this.Width + e.HorizontalChange;
    if (num <= this.MinWidth)
      return;
    this.Width = num;
  }

  private void ResizeBottom_DragDelta(object sender, DragDeltaEventArgs e)
  {
    double num = this.Height + e.VerticalChange;
    if (num <= this.MinHeight)
      return;
    this.Height = num;
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

  private void btnActionRestore_Click(object sender, RoutedEventArgs e)
  {
    this.btnActionRestore.Visibility = Visibility.Collapsed;
    this.btnActionMaxamize.Visibility = Visibility.Visible;
    this.WindowState = WindowState.Normal;
  }

  private void labeluid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
  {
    try
    {
      System.Windows.Clipboard.SetDataObject((object) (string) this.labeluid.Content, true);
    }
    catch
    {
      return;
    }
    int num = (int) YMessageBox.Show("Copy success.", "Note");
  }

  private void ButtonFlyEnable_Click(object sender, RoutedEventArgs e)
  {
    if (!this._licFile.Keys.Contains<string>(this._myuid) || YMessageBox.Show("Do you want to Enable No Fly Zone?", "Note", YMessageBoxButton.YesNo) != YMessageResultButton.Yes || !((string) this.menuitemconnect.Header == "Disconnect"))
      return;
    MavlinkUidDecryptCmd msg = new MavlinkUidDecryptCmd()
    {
      Cmd = MavParamUidDecryptCmd.MavParamUidDecryptCmdEnNoFlyZone,
      Key = this._licFile[this._myuid]
    };
    switch (this.connectway)
    {
      case MainWindow.ConnectWays.YUNEEC_USB_CONNECT_ONE:
        this.usbMavLink.SendMessage((UasMessage) msg);
        break;
      case MainWindow.ConnectWays.YUNEEC_SERIALPORT_CONNECT_TWO:
        this.serialportMavlink.SendMessage((UasMessage) msg);
        break;
    }
  }

  private void menuitemUpdate_Click(object sender, RoutedEventArgs e)
  {
    this.YUNEEC_CLOSE(this.connectway);
    this.DownLoading = true;
    new Wpfbootload.MainWindow().ShowDialog();
    this.DownLoading = false;
  }

  private void Hyperlink_Click(object sender, RoutedEventArgs e)
  {
    Process.Start("explorer.exe", AppDomain.CurrentDomain.BaseDirectory + "driver");
  }

  private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
  {
    LoginWindow loginWindow = new LoginWindow();
    loginWindow.LoginSuccessHanlde += new LoginSuccessDelegate(this.Win_LoginSuccessHanlde);
    loginWindow.Show();
  }

  private void Win_LoginSuccessHanlde(object sender, string name)
  {
    string q = $"SELECT Count(*) FROM aircrafts WHERE uid = '{this.Myuid}'";
    this.account.AccountName = name;
    this.dbconnect.Initialize(this.mySqlConnectionString);
    if (this.dbconnect.Count(q) > 0)
      this.dbconnect.Update($"UPDATE aircrafts SET data = '{this.ver.Aircraftversion}' WHERE uid = '{this.Myuid}'");
    else
      this.dbconnect.Insert($"INSERT INTO aircrafts (`uid`, `data`) VALUES ('{this.Myuid}', '{this.ver.Aircraftversion}')");
  }

  private void GuiUp_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
  {
    Process.Start(new ProcessStartInfo(this.ver.Guiuri));
    e.Handled = true;
  }

  private void AircraftUp_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
  {
    Process.Start(new ProcessStartInfo(this.ver.Aircrafturi));
    e.Handled = true;
  }

  private void btnActionMaxamize_Click(object sender, RoutedEventArgs e)
  {
    this.btnActionRestore.Visibility = Visibility.Visible;
    this.btnActionMaxamize.Visibility = Visibility.Collapsed;
    this.WindowState = WindowState.Maximized;
  }

  private void btnActionClose_Click(object sender, RoutedEventArgs e)
  {
    System.Windows.Application.Current.Shutdown();
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    System.Windows.Application.LoadComponent((object) this, new Uri("/WpfAppTyphoonH;component/mainwindow.xaml", UriKind.Relative));
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
        ((Window) target).Closing += new CancelEventHandler(this.Window_Closing);
        ((FrameworkElement) target).Loaded += new RoutedEventHandler(this.Window_Loaded);
        ((Window) target).StateChanged += new EventHandler(this.Window_StateChanged);
        break;
      case 2:
        ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.menuitemconnect_Click);
        break;
      case 3:
        ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.menuitemclose_Click);
        break;
      case 4:
        ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.menuitemsettings_Click);
        break;
      case 5:
        this.borderFrame = (Border) target;
        break;
      case 6:
        this.containerFrame = (Grid) target;
        break;
      case 7:
        this.homeHeader = (Grid) target;
        break;
      case 8:
        this.lblTitle = (TextBlock) target;
        break;
      case 9:
        this.headerThumb = (Thumb) target;
        this.headerThumb.DragDelta += new DragDeltaEventHandler(this.headerThumb_DragDelta);
        this.headerThumb.MouseDoubleClick += new MouseButtonEventHandler(this.headerThumb_MouseDoubleClick);
        break;
      case 10:
        this.homeHeaderActionButtons = (StackPanel) target;
        break;
      case 11:
        this.btnActionMinimize = (System.Windows.Controls.Button) target;
        this.btnActionMinimize.Click += new RoutedEventHandler(this.btnActionMinimize_Click);
        break;
      case 12:
        this.btnActionRestore = (System.Windows.Controls.Button) target;
        this.btnActionRestore.Click += new RoutedEventHandler(this.btnActionRestore_Click);
        break;
      case 13:
        this.btnActionMaxamize = (System.Windows.Controls.Button) target;
        this.btnActionMaxamize.Click += new RoutedEventHandler(this.btnActionMaxamize_Click);
        break;
      case 14:
        this.btnActionClose = (System.Windows.Controls.Button) target;
        this.btnActionClose.Click += new RoutedEventHandler(this.btnActionClose_Click);
        break;
      case 15:
        this.menuitemconnect = (System.Windows.Controls.MenuItem) target;
        this.menuitemconnect.Click += new RoutedEventHandler(this.menuitemconnect_Click);
        break;
      case 16 /*0x10*/:
        this.menuitemsettings = (System.Windows.Controls.MenuItem) target;
        this.menuitemsettings.Click += new RoutedEventHandler(this.menuitemsettings_Click);
        break;
      case 17:
        this.menuitemclose = (System.Windows.Controls.MenuItem) target;
        this.menuitemclose.Click += new RoutedEventHandler(this.menuitemclose_Click);
        break;
      case 18:
        this.menuitem12 = (System.Windows.Controls.MenuItem) target;
        this.menuitem12.Click += new RoutedEventHandler(this.menuitem12_Click);
        break;
      case 19:
        this.menuitem14 = (System.Windows.Controls.MenuItem) target;
        this.menuitem14.Click += new RoutedEventHandler(this.menuitem14_Click);
        break;
      case 20:
        this.menuitem16 = (System.Windows.Controls.MenuItem) target;
        this.menuitem16.Click += new RoutedEventHandler(this.menuitem16_Click);
        break;
      case 21:
        this.menuitem18 = (System.Windows.Controls.MenuItem) target;
        this.menuitem18.Click += new RoutedEventHandler(this.menuitem18_Click);
        break;
      case 22:
        this.menuitemusb = (System.Windows.Controls.MenuItem) target;
        this.menuitemusb.Click += new RoutedEventHandler(this.menuitemusb_Click);
        break;
      case 23:
        this.menuitemserialport = (System.Windows.Controls.MenuItem) target;
        this.menuitemserialport.Click += new RoutedEventHandler(this.menuitemserialport_Click);
        break;
      case 24:
        this.menuitemUpdate = (System.Windows.Controls.MenuItem) target;
        this.menuitemUpdate.Click += new RoutedEventHandler(this.menuitemUpdate_Click);
        break;
      case 25:
        this.menuitemLicense = (System.Windows.Controls.MenuItem) target;
        this.menuitemLicense.Click += new RoutedEventHandler(this.menuitemLicense_Click);
        break;
      case 26:
        this.tabSteps = (System.Windows.Controls.TabControl) target;
        break;
      case 27:
        this.FirstHome = (TabItem) target;
        break;
      case 28:
        this.groupbox1 = (System.Windows.Controls.GroupBox) target;
        break;
      case 29:
        this.judgementO = (WControlJudgement) target;
        break;
      case 30:
        this.judgementP = (WControlJudgement) target;
        break;
      case 31 /*0x1F*/:
        this.judgementC = (WControlJudgement) target;
        break;
      case 32 /*0x20*/:
        this.judgementG = (WControlJudgement) target;
        break;
      case 33:
        this.judgementS = (WControlJudgement) target;
        break;
      case 34:
        this.judgementR = (WControlJudgement) target;
        break;
      case 35:
        this.judgementOF = (WControlJudgement) target;
        break;
      case 36:
        this.judgementRS = (WControlJudgement) target;
        break;
      case 37:
        this.labelO = (System.Windows.Controls.Label) target;
        break;
      case 38:
        this.labelP = (System.Windows.Controls.Label) target;
        break;
      case 39:
        this.labelC = (System.Windows.Controls.Label) target;
        break;
      case 40:
        this.labelG = (System.Windows.Controls.Label) target;
        break;
      case 41:
        this.labelS = (System.Windows.Controls.Label) target;
        break;
      case 42:
        this.labelR = (System.Windows.Controls.Label) target;
        break;
      case 43:
        this.labelOF = (System.Windows.Controls.Label) target;
        break;
      case 44:
        this.labelRS = (System.Windows.Controls.Label) target;
        break;
      case 45:
        this.groupbox15 = (System.Windows.Controls.GroupBox) target;
        break;
      case 46:
        this.checkenbletesting = (System.Windows.Controls.CheckBox) target;
        this.checkenbletesting.Checked += new RoutedEventHandler(this.checkenbletesting_Checked);
        this.checkenbletesting.Unchecked += new RoutedEventHandler(this.checkenbletesting_Unchecked);
        break;
      case 47:
        this.buttonallturn = (System.Windows.Controls.Button) target;
        this.buttonallturn.Click += new RoutedEventHandler(this.buttonallturn_Click);
        break;
      case 48 /*0x30*/:
        this.AircraftESC = (Motor) target;
        break;
      case 49:
        this.groupbox2 = (System.Windows.Controls.GroupBox) target;
        break;
      case 50:
        this.textboxvoltage = (System.Windows.Controls.TextBox) target;
        break;
      case 51:
        this.labelvoltage = (System.Windows.Controls.Label) target;
        break;
      case 52:
        this.Battery = (Battery) target;
        break;
      case 53:
        this.labelvoltagev = (System.Windows.Controls.Label) target;
        break;
      case 54:
        this.groupbox3 = (System.Windows.Controls.GroupBox) target;
        break;
      case 55:
        this.textboxaccx = (System.Windows.Controls.TextBox) target;
        break;
      case 56:
        this.textboxaccy = (System.Windows.Controls.TextBox) target;
        break;
      case 57:
        this.textboxaccz = (System.Windows.Controls.TextBox) target;
        break;
      case 58:
        this.textboxaccm = (System.Windows.Controls.TextBox) target;
        break;
      case 59:
        this.groupbox4 = (System.Windows.Controls.GroupBox) target;
        break;
      case 60:
        this.textboxgyrx = (System.Windows.Controls.TextBox) target;
        break;
      case 61:
        this.textboxgyry = (System.Windows.Controls.TextBox) target;
        break;
      case 62:
        this.textboxgyrz = (System.Windows.Controls.TextBox) target;
        break;
      case 63 /*0x3F*/:
        this.groupbox5 = (System.Windows.Controls.GroupBox) target;
        break;
      case 64 /*0x40*/:
        this.textboxroll = (System.Windows.Controls.TextBox) target;
        break;
      case 65:
        this.textboxpitch = (System.Windows.Controls.TextBox) target;
        break;
      case 66:
        this.textboxyaw = (System.Windows.Controls.TextBox) target;
        break;
      case 67:
        this.groupbox6 = (System.Windows.Controls.GroupBox) target;
        break;
      case 68:
        this.textboxcomx = (System.Windows.Controls.TextBox) target;
        break;
      case 69:
        this.textboxcomy = (System.Windows.Controls.TextBox) target;
        break;
      case 70:
        this.textboxcomz = (System.Windows.Controls.TextBox) target;
        break;
      case 71:
        this.groupbox7 = (System.Windows.Controls.GroupBox) target;
        break;
      case 72:
        this.textboxpre = (System.Windows.Controls.TextBox) target;
        break;
      case 73:
        this.textboxpretem = (System.Windows.Controls.TextBox) target;
        break;
      case 74:
        this.textboxprehe = (System.Windows.Controls.TextBox) target;
        break;
      case 75:
        this.groupbox8 = (System.Windows.Controls.GroupBox) target;
        break;
      case 76:
        this.groupbox14 = (System.Windows.Controls.GroupBox) target;
        break;
      case 77:
        this.Geofencecurrentvalue = (System.Windows.Controls.Label) target;
        break;
      case 78:
        this.Geofencenewvalue = (TAlex.WPF.Controls.NumericUpDown) target;
        break;
      case 79:
        this.Updategeofence = (System.Windows.Controls.Button) target;
        this.Updategeofence.Click += new RoutedEventHandler(this.Updategeofence_Click);
        break;
      case 80 /*0x50*/:
        this.Heightlimitcurrentvalue = (System.Windows.Controls.Label) target;
        break;
      case 81:
        this.Heightlimitnewvalue = (TAlex.WPF.Controls.NumericUpDown) target;
        break;
      case 82:
        this.Updateheightlimit = (System.Windows.Controls.Button) target;
        this.Updateheightlimit.Click += new RoutedEventHandler(this.Updateheightlimit_Click);
        break;
      case 83:
        this.ButtonNoFlyEnable = (System.Windows.Controls.Button) target;
        this.ButtonNoFlyEnable.Click += new RoutedEventHandler(this.ButtonNoFlyEnable_Click);
        break;
      case 84:
        this.ButtonFlyEnable = (System.Windows.Controls.Button) target;
        this.ButtonFlyEnable.Click += new RoutedEventHandler(this.ButtonFlyEnable_Click);
        break;
      case 85:
        this.ButtonClearPar = (System.Windows.Controls.Button) target;
        this.ButtonClearPar.Click += new RoutedEventHandler(this.ButtonClearPar_Click);
        break;
      case 86:
        this.AveSnr = (TextBlock) target;
        break;
      case 87:
        this.Chart = (SparrowChart) target;
        break;
      case 88:
        this.columnseries = (ColumnSeries) target;
        break;
      case 89:
        this.columnseriesgreen = (ColumnSeries) target;
        break;
      case 90:
        this.groupbox9 = (System.Windows.Controls.GroupBox) target;
        break;
      case 91:
        this.textboxlat = (System.Windows.Controls.TextBox) target;
        break;
      case 92:
        this.textboxlon = (System.Windows.Controls.TextBox) target;
        break;
      case 93:
        this.textboxalt = (System.Windows.Controls.TextBox) target;
        break;
      case 94:
        this.textboxeph = (System.Windows.Controls.TextBox) target;
        break;
      case 95:
        this.groupbox10 = (System.Windows.Controls.GroupBox) target;
        break;
      case 96 /*0x60*/:
        this.textboxvx = (System.Windows.Controls.TextBox) target;
        break;
      case 97:
        this.textboxvy = (System.Windows.Controls.TextBox) target;
        break;
      case 98:
        this.textboxvz = (System.Windows.Controls.TextBox) target;
        break;
      case 99:
        this.StartHome = (TabItem) target;
        break;
      case 100:
        this.TextBlockSpecification = (TextBlock) target;
        break;
      case 101:
        ((Hyperlink) target).Click += new RoutedEventHandler(this.Hyperlink_Click);
        break;
      case 102:
        this.groupbox11 = (System.Windows.Controls.GroupBox) target;
        break;
      case 103:
        this.GuiUp = (TextBlock) target;
        this.GuiUp.MouseLeftButtonUp += new MouseButtonEventHandler(this.GuiUp_MouseLeftButtonUp);
        break;
      case 104:
        this.groupbox12 = (System.Windows.Controls.GroupBox) target;
        break;
      case 105:
        this.AircraftUp = (TextBlock) target;
        this.AircraftUp.MouseLeftButtonUp += new MouseButtonEventHandler(this.AircraftUp_MouseLeftButtonUp);
        break;
      case 106:
        this.groupbox13 = (System.Windows.Controls.GroupBox) target;
        break;
      case 107:
        this.labeluid = (System.Windows.Controls.Label) target;
        this.labeluid.MouseLeftButtonDown += new MouseButtonEventHandler(this.labeluid_MouseLeftButtonDown);
        break;
      case 108:
        this.buttonfirmwareupdate = (System.Windows.Controls.Button) target;
        this.buttonfirmwareupdate.Click += new RoutedEventHandler(this.buttonfirmwareupdate_Click);
        break;
      case 109:
        this.statusbar = (System.Windows.Controls.Primitives.StatusBar) target;
        break;
      case 110:
        this.MYLED = (wpfledcontrol) target;
        break;
      case 111:
        this.statuslabel = (System.Windows.Controls.Label) target;
        break;
      case 112 /*0x70*/:
        this.progressbar = (System.Windows.Controls.ProgressBar) target;
        break;
      case 113:
        this.homeResizing = (Grid) target;
        break;
      case 114:
        this.ResizeDrop = (Thumb) target;
        this.ResizeDrop.DragDelta += new DragDeltaEventHandler(this.ResizeDrop_DragDelta);
        break;
      case 115:
        this.ResizeRight = (Thumb) target;
        this.ResizeRight.DragDelta += new DragDeltaEventHandler(this.ResizeRight_DragDelta);
        break;
      case 116:
        this.ResizeBottom = (Thumb) target;
        this.ResizeBottom.DragDelta += new DragDeltaEventHandler(this.ResizeBottom_DragDelta);
        break;
      case 117:
        this.Account = (TextBlock) target;
        this.Account.MouseLeftButtonUp += new MouseButtonEventHandler(this.TextBlock_MouseLeftButtonUp);
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }

  public class FData
  {
    private FileStream file;
    private long filesize;

    public FileStream FD
    {
      get => this.file;
      set => this.file = value;
    }

    public long FS
    {
      get => this.filesize;
      set => this.filesize = value;
    }
  }

  private enum ConnectWays
  {
    YUNEEC_NULL,
    YUNEEC_USB_CONNECT_ONE,
    YUNEEC_SERIALPORT_CONNECT_TWO,
  }

  private enum GetInformation
  {
    Uid,
    Software,
    GpsDb,
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
