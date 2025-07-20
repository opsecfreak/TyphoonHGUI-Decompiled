// Decompiled with JetBrains decompiler
// Type: Wpfbootload.BootClass.CommonUpDataFirmware
// Assembly: Wpfbootload, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4FEF84E1-06E0-4569-8BB0-07C571E890DC
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\Wpfbootload.exe

using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

#nullable disable
namespace Wpfbootload.BootClass;

internal class CommonUpDataFirmware : INotifyPropertyChanged
{
  private string _port;
  private long _maximum = 100;
  private long _barvalue;
  private string _log;
  private bool _isReboot;
  private bool _isGetSoftware;
  private bool _isdownLoad;
  private string _downLoad = "Update";
  protected readonly FData File;
  public bool IsAction;

  public long Maximum
  {
    get => this._maximum;
    set
    {
      this._maximum = value;
      this.OnPropertyChanged(nameof (Maximum));
    }
  }

  public long Barvalue
  {
    get => this._barvalue;
    set
    {
      this._barvalue = value;
      this.OnPropertyChanged(nameof (Barvalue));
    }
  }

  public string Port
  {
    get => this._port;
    set
    {
      this._port = value;
      this.OnPropertyChanged(nameof (Port));
    }
  }

  public string Log
  {
    get => this._log;
    set
    {
      this._log = value;
      this.OnPropertyChanged(nameof (Log));
    }
  }

  public bool IsReboot
  {
    get => this._isReboot;
    set
    {
      this._isReboot = value;
      this.OnPropertyChanged(nameof (IsReboot));
    }
  }

  public bool IsGetSoftware
  {
    get => this._isGetSoftware;
    set
    {
      this._isGetSoftware = value;
      this.OnPropertyChanged(nameof (IsGetSoftware));
    }
  }

  public bool IsdownLoad
  {
    get => this._isdownLoad;
    set
    {
      this._isdownLoad = value;
      this.OnPropertyChanged(nameof (IsdownLoad));
    }
  }

  public string DownLoad
  {
    get => this._downLoad;
    set
    {
      this._downLoad = value;
      this.OnPropertyChanged(nameof (DownLoad));
    }
  }

  public void Start() => this.DownLoad_Click((object) this, new RoutedEventArgs());

  private void OnPropertyChanged(string value)
  {
    PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
    if (propertyChanged == null)
      return;
    propertyChanged((object) this, new PropertyChangedEventArgs(value));
  }

  protected virtual void ThreadUpDataFirmware()
  {
  }

  protected virtual void DownLoad_Click(object sender, RoutedEventArgs e)
  {
    Task.Factory.StartNew(new Action(this.ThreadUpDataFirmware));
  }

  protected virtual void Reboot_Click(object sender, RoutedEventArgs e)
  {
  }

  protected virtual void GetSoftware_Click(object sender, RoutedEventArgs e)
  {
  }

  public event PropertyChangedEventHandler PropertyChanged;

  public CommonUpDataFirmware(FData file)
  {
    this.File = file;
    this.Log = $"{this.Log}{"File Information:\nType:" + this.File.TargetSystem + "\nVersion:" + this.File.SoftwareVersion + "\nDate:" + this.File.Date}\n";
    this.Barvalue = 0L;
    this.IsdownLoad = true;
  }
}
