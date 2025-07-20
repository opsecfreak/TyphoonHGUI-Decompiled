// Decompiled with JetBrains decompiler
// Type: WpfAppTyphoonH.Version
// Assembly: WpfAppTyphoonH, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 3524D12E-4BA5-4A95-813C-BA8CEFA4F2FA
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\WpfAppTyphoonH.exe

using System;
using System.ComponentModel;
using System.Xml;

#nullable disable
namespace WpfAppTyphoonH;

public class Version : INotifyPropertyChanged
{
  private string _aircraftversion = "";
  private string _guiversion = "v1.02";
  private string _versiondata = "";
  private string _versionstatus = "";
  private string _guistatus = "";
  private string _avformxml = "";
  private string _gvformxml = "";
  private string _aircrafturi;
  private string _guiuri;

  public string Aircraftversion
  {
    get => this._aircraftversion;
    set
    {
      this._aircraftversion = value;
      this.OnPropertyChanged(nameof (Aircraftversion));
      if (this._avformxml != "")
      {
        if (this.StrCompare(this._avformxml, this.Aircraftversion.Replace("v", "")) <= 0)
          return;
        this.Versionstatus = "New Version";
      }
      else
        this.Versionstatus = "";
    }
  }

  private int StrCompare(string str1, string str2)
  {
    int num = 0;
    string[] strArray1 = str1.Split('.');
    string[] strArray2 = str2.Split('.', ',');
    if (Convert.ToInt32(strArray1[0]) > Convert.ToInt32(strArray2[0]))
      num = 1;
    else if (Convert.ToInt32(strArray1[0]) == Convert.ToInt32(strArray2[0]))
    {
      if (Convert.ToInt32(strArray1[1]) > Convert.ToInt32(strArray2[1]))
        num = 1;
      else if (Convert.ToInt32(strArray1[1]) < Convert.ToInt32(strArray2[1]))
        num = -1;
    }
    else
      num = -1;
    return num;
  }

  public string Guiversion
  {
    get => this._guiversion;
    set
    {
      this._guiversion = value;
      this.OnPropertyChanged(nameof (Guiversion));
      if (this._gvformxml != "")
      {
        if (this.StrCompare(this._gvformxml, this.Guiversion.Replace("v", "")) <= 0)
          return;
        this.Guistatus = "New Version";
      }
      else
        this.Guistatus = "";
    }
  }

  public string Versiondata
  {
    get => this._versiondata;
    set
    {
      this._versiondata = value;
      this.OnPropertyChanged(nameof (Versiondata));
    }
  }

  public string Versionstatus
  {
    get => this._versionstatus;
    set
    {
      this._versionstatus = value;
      this.OnPropertyChanged(nameof (Versionstatus));
    }
  }

  public string Guistatus
  {
    get => this._guistatus;
    set
    {
      this._guistatus = value;
      this.OnPropertyChanged(nameof (Guistatus));
    }
  }

  public string Avformxml
  {
    get => this._avformxml;
    set
    {
      this._avformxml = value;
      if (this.Aircraftversion != "")
      {
        if (this.StrCompare(this._avformxml, this.Aircraftversion.Replace("v", "")) <= 0)
          return;
        this.Versionstatus = "New Version";
      }
      else
        this.Versionstatus = "";
    }
  }

  public string Gvformxml
  {
    get => this._gvformxml;
    set
    {
      this._gvformxml = value;
      if (this.Guiversion != "")
      {
        if (this.StrCompare(this._gvformxml, this.Guiversion.Replace("v", "")) <= 0)
          return;
        this.Guistatus = "New Version";
      }
      else
        this.Guistatus = "";
    }
  }

  public string Aircrafturi
  {
    get => this._aircrafturi;
    set
    {
      this._aircrafturi = value;
      this.OnPropertyChanged(nameof (Aircrafturi));
    }
  }

  public string Guiuri
  {
    get => this._guiuri;
    set
    {
      this._guiuri = value;
      this.OnPropertyChanged(nameof (Guiuri));
    }
  }

  private void OnPropertyChanged(string value)
  {
    PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
    if (propertyChanged == null)
      return;
    propertyChanged((object) this, new PropertyChangedEventArgs(value));
  }

  public void ReadVersionXML(string url)
  {
    XmlDocument xmlDocument = new XmlDocument();
    xmlDocument.Load(url);
    foreach (XmlElement childNode1 in xmlDocument.SelectSingleNode("root").ChildNodes)
    {
      if (childNode1.GetAttribute("name").ToString() == "a")
      {
        this._aircrafturi = "http://www.yuneec.com/support";
        foreach (XmlElement childNode2 in childNode1.ChildNodes)
        {
          if (childNode2.Name == "autopilot")
            this.Avformxml = childNode2.GetAttribute("version").ToString();
        }
      }
      else if (childNode1.GetAttribute("name").ToString() == "gui")
      {
        this._guiuri = childNode1.GetAttribute("ServerPath").ToString();
        foreach (XmlElement childNode3 in childNode1.ChildNodes)
        {
          if (childNode3.Name == "gui")
            this.Gvformxml = childNode3.GetAttribute("version").ToString();
        }
      }
    }
  }

  public event PropertyChangedEventHandler PropertyChanged;
}
