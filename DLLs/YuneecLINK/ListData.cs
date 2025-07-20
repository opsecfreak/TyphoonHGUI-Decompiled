// Decompiled with JetBrains decompiler
// Type: YuneecLinkNet.ListData
// Assembly: YuneecLINK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CFB54D17-6788-4CFB-B24E-B7975B945505
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\YuneecLINK.dll

using System.ComponentModel;

#nullable disable
namespace YuneecLinkNet;

public class ListData : INotifyPropertyChanged
{
  private string mName;
  private string mValue;
  private int mColorIndex;

  public string Name
  {
    set
    {
      this.mName = value;
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (Name)));
    }
    get => this.mName;
  }

  public string Value
  {
    set
    {
      this.mValue = value;
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (Value)));
    }
    get => this.mValue;
  }

  public string Type { set; get; }

  public int ColorIndex
  {
    set
    {
      this.mColorIndex = value;
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (ColorIndex)));
    }
    get => this.mColorIndex;
  }

  public event PropertyChangedEventHandler PropertyChanged;
}
