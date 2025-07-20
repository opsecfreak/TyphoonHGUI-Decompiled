// Decompiled with JetBrains decompiler
// Type: WpfAppTyphoonH.Account
// Assembly: WpfAppTyphoonH, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 3524D12E-4BA5-4A95-813C-BA8CEFA4F2FA
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\WpfAppTyphoonH.exe

using System.ComponentModel;

#nullable disable
namespace WpfAppTyphoonH;

public class Account : INotifyPropertyChanged
{
  private string _myColor = "#FF747474";
  private string _accountName = "Login";

  public event PropertyChangedEventHandler PropertyChanged;

  private void OnPropertyChanged(string value)
  {
    PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
    if (propertyChanged == null)
      return;
    propertyChanged((object) this, new PropertyChangedEventArgs(value));
  }

  public string MyColor
  {
    get => this._myColor;
    set
    {
      this._myColor = value;
      this.OnPropertyChanged(nameof (MyColor));
    }
  }

  public string AccountName
  {
    get => this._accountName;
    set
    {
      this._accountName = value;
      this.MyColor = !(this._accountName == "Login") ? "Black" : "#FF747474";
      this.OnPropertyChanged(nameof (AccountName));
    }
  }
}
