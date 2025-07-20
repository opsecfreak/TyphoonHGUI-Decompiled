// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.DeviceNotify.Linux.LinuxDeviceNotifier
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Descriptors;
using LibUsbDotNet.LudnMonoLibUsb;
using MonoLibUsb.Profile;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Timers;

#nullable disable
namespace LibUsbDotNet.DeviceNotify.Linux;

public class LinuxDeviceNotifier : IDeviceNotifier
{
  private readonly LinuxDevItemList mLinuxDevItemList = new LinuxDevItemList();
  private readonly LinuxDeviceNotifierMode mMode;
  public static int PollingInterval = 750;
  private Timer mDeviceListPollTimer;
  private object PollTimerLock = new object();
  private static Regex _RegParseDeviceInterface;
  private static string DeviceIntefaceMatchExpression = "usbdev(?<BusNumber>[0-9]+)\\.(?<DeviceAddress>[0-9]+)$";
  private readonly string mDevDir;
  private FileSystemWatcher mUsbFS;

  public LinuxDeviceNotifier(string devDir)
  {
    this.mDevDir = devDir;
    try
    {
      this.StartDevDirectoryMonitor();
      if (this.mLinuxDevItemList.Count == 0)
        throw new NotSupportedException("LinuxDeviceNotifier:Dev directory monitor not supported.");
      this.mMode = LinuxDeviceNotifierMode.MonitorDevDirectory;
      return;
    }
    catch
    {
      this.StopDevDirectoryMonitor();
    }
    this.mMode = LinuxDeviceNotifierMode.PollDeviceList;
    this.StartDeviceListPolling();
  }

  public LinuxDeviceNotifier()
    : this("/dev")
  {
  }

  public LinuxDeviceNotifierMode Mode => this.mMode;

  public bool Enabled
  {
    get
    {
      switch (this.mMode)
      {
        case LinuxDeviceNotifierMode.PollDeviceList:
          return this.mDeviceListPollTimer != null;
        case LinuxDeviceNotifierMode.MonitorDevDirectory:
          return this.mUsbFS != null;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }
    set
    {
      if (value)
        this.Start();
      else
        this.Stop();
    }
  }

  public event EventHandler<DeviceNotifyEventArgs> OnDeviceNotify;

  private void Stop()
  {
    switch (this.mMode)
    {
      case LinuxDeviceNotifierMode.PollDeviceList:
        this.StopDeviceListPolling();
        break;
      case LinuxDeviceNotifierMode.MonitorDevDirectory:
        this.StopDevDirectoryMonitor();
        break;
      default:
        throw new ArgumentOutOfRangeException();
    }
  }

  private void Start()
  {
    switch (this.mMode)
    {
      case LinuxDeviceNotifierMode.PollDeviceList:
        this.StartDeviceListPolling();
        break;
      case LinuxDeviceNotifierMode.MonitorDevDirectory:
        this.StartDevDirectoryMonitor();
        break;
      default:
        throw new ArgumentOutOfRangeException();
    }
  }

  private void StartDeviceListPolling()
  {
    lock (this.PollTimerLock)
    {
      if (this.mDeviceListPollTimer != null)
        return;
      MonoUsbDevice.RefreshProfileList();
      MonoUsbDevice.ProfileList.AddRemoveEvent += new EventHandler<AddRemoveEventArgs>(this.OnAddRemoveEvent);
      this.mDeviceListPollTimer = new Timer((double) LinuxDeviceNotifier.PollingInterval);
      this.mDeviceListPollTimer.Elapsed += new ElapsedEventHandler(this.PollTimer_Elapsed);
      this.mDeviceListPollTimer.Start();
    }
  }

  private void PollTimer_Elapsed(object sender, ElapsedEventArgs e)
  {
    lock (this.PollTimerLock)
    {
      this.mDeviceListPollTimer.Stop();
      MonoUsbDevice.RefreshProfileList();
      this.mDeviceListPollTimer.Start();
    }
  }

  private void StopDeviceListPolling()
  {
    lock (this.PollTimerLock)
    {
      if (this.mDeviceListPollTimer == null)
        return;
      this.mDeviceListPollTimer.Stop();
      this.mDeviceListPollTimer.Elapsed -= new ElapsedEventHandler(this.PollTimer_Elapsed);
      this.mDeviceListPollTimer.Dispose();
      MonoUsbDevice.ProfileList.AddRemoveEvent -= new EventHandler<AddRemoveEventArgs>(this.OnAddRemoveEvent);
      this.mDeviceListPollTimer = (Timer) null;
    }
  }

  private void OnAddRemoveEvent(object sender, AddRemoveEventArgs e)
  {
    EventHandler<DeviceNotifyEventArgs> onDeviceNotify = this.OnDeviceNotify;
    if (onDeviceNotify == null)
      return;
    LinuxDevItem linuxDevItem = new LinuxDevItem($"usbdev{e.MonoUSBProfile.BusNumber}.{e.MonoUSBProfile.DeviceAddress}", e.MonoUSBProfile.BusNumber, e.MonoUSBProfile.DeviceAddress, e.MonoUSBProfile.DeviceDescriptor);
    onDeviceNotify((object) this, (DeviceNotifyEventArgs) new LinuxDeviceNotifyEventArgs(linuxDevItem, DeviceType.DeviceInterface, e.EventType == AddRemoveType.Added ? EventType.DeviceArrival : EventType.DeviceRemoveComplete));
  }

  private static Regex RegParseDeviceInterface
  {
    get
    {
      if (LinuxDeviceNotifier._RegParseDeviceInterface == null)
        LinuxDeviceNotifier._RegParseDeviceInterface = new Regex(LinuxDeviceNotifier.DeviceIntefaceMatchExpression, RegexOptions.ExplicitCapture | RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.CultureInvariant);
      return LinuxDeviceNotifier._RegParseDeviceInterface;
    }
  }

  private static bool IsDeviceEnterface(string name, out byte busNumber, out byte deviceAddress)
  {
    busNumber = (byte) 0;
    deviceAddress = (byte) 0;
    Match match = LinuxDeviceNotifier.RegParseDeviceInterface.Match(name);
    if (!match.Success)
      return false;
    try
    {
      busNumber = byte.Parse(match.Groups["BusNumber"].Value);
      deviceAddress = byte.Parse(match.Groups["DeviceAddress"].Value);
      return true;
    }
    catch
    {
      return false;
    }
  }

  private static bool ReadFileDescriptor(string fullPath, out byte[] deviceDescriptorBytes)
  {
    try
    {
      FileStream fileStream = File.Open(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
      deviceDescriptorBytes = new byte[UsbDeviceDescriptor.Size];
      int num = fileStream.Read(deviceDescriptorBytes, 0, UsbDeviceDescriptor.Size);
      fileStream.Close();
      int size = UsbDeviceDescriptor.Size;
      return num == size;
    }
    catch
    {
      deviceDescriptorBytes = (byte[]) null;
      return false;
    }
  }

  private void StartDevDirectoryMonitor()
  {
    if (this.mUsbFS != null)
      return;
    this.BuildDevList();
    this.mUsbFS = new FileSystemWatcher(this.mDevDir);
    this.mUsbFS.IncludeSubdirectories = false;
    this.mUsbFS.Created += new FileSystemEventHandler(this.FileAdded);
    this.mUsbFS.Deleted += new FileSystemEventHandler(this.FileRemoved);
    this.mUsbFS.EnableRaisingEvents = true;
  }

  private void BuildDevList()
  {
    this.mLinuxDevItemList.Clear();
    foreach (string file in Directory.GetFiles(this.mDevDir, "usbdev*", SearchOption.TopDirectoryOnly))
    {
      string fileName = Path.GetFileName(file);
      byte busNumber;
      byte deviceAddress;
      byte[] deviceDescriptorBytes;
      if (LinuxDeviceNotifier.IsDeviceEnterface(fileName, out busNumber, out deviceAddress) && LinuxDeviceNotifier.ReadFileDescriptor(file, out deviceDescriptorBytes))
        this.mLinuxDevItemList.Add(new LinuxDevItem(fileName, busNumber, deviceAddress, deviceDescriptorBytes));
    }
  }

  private void FileRemoved(object sender, FileSystemEventArgs e)
  {
    if (!LinuxDeviceNotifier.IsDeviceEnterface(e.Name, out byte _, out byte _))
      return;
    LinuxDevItem byName;
    if ((byName = this.mLinuxDevItemList.FindByName(e.Name)) == (LinuxDevItem) null)
      throw new Exception("FileRemoved:Invalid LinuxDevItem");
    this.mLinuxDevItemList.Remove(byName);
    EventHandler<DeviceNotifyEventArgs> onDeviceNotify = this.OnDeviceNotify;
    if (onDeviceNotify == null)
      return;
    onDeviceNotify((object) this, (DeviceNotifyEventArgs) new LinuxDeviceNotifyEventArgs(byName, DeviceType.DeviceInterface, EventType.DeviceRemoveComplete));
  }

  private void FileAdded(object sender, FileSystemEventArgs e)
  {
    byte busNumber;
    byte deviceAddress;
    byte[] deviceDescriptorBytes;
    if (!LinuxDeviceNotifier.IsDeviceEnterface(e.Name, out busNumber, out deviceAddress) || !LinuxDeviceNotifier.ReadFileDescriptor(e.FullPath, out deviceDescriptorBytes))
      return;
    LinuxDevItem linuxDevItem = new LinuxDevItem(e.Name, busNumber, deviceAddress, deviceDescriptorBytes);
    if (this.mLinuxDevItemList.FindByName(e.Name) != (LinuxDevItem) null)
      throw new Exception("FileAdded:Invalid LinuxDevItem");
    this.mLinuxDevItemList.Add(linuxDevItem);
    EventHandler<DeviceNotifyEventArgs> onDeviceNotify = this.OnDeviceNotify;
    if (onDeviceNotify == null)
      return;
    onDeviceNotify((object) this, (DeviceNotifyEventArgs) new LinuxDeviceNotifyEventArgs(linuxDevItem, DeviceType.DeviceInterface, EventType.DeviceArrival));
  }

  private void StopDevDirectoryMonitor()
  {
    if (this.mUsbFS == null)
      return;
    this.mUsbFS.EnableRaisingEvents = false;
    this.mUsbFS.Created -= new FileSystemEventHandler(this.FileAdded);
    this.mUsbFS.Deleted -= new FileSystemEventHandler(this.FileRemoved);
    this.mUsbFS.Dispose();
    this.mUsbFS = (FileSystemWatcher) null;
  }
}
