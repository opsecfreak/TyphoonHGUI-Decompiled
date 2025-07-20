// Decompiled with JetBrains decompiler
// Type: battery.Battery
// Assembly: battery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2465C829-9D4F-4727-8648-0133DA15A102
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\battery.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Shapes;

#nullable disable
namespace battery;

public partial class Battery : UserControl, IComponentConnector
{
  private float remain = 100f;
  internal Rectangle BatteryRemain;
  private bool _contentLoaded;

  public float Remain
  {
    set
    {
      this.remain = value;
      this.MakeRemain();
    }
    get => this.remain;
  }

  public Battery() => this.InitializeComponent();

  private void MakeRemain()
  {
    this.BatteryRemain.Width = 177.0 / 217.0 * this.Width / 100.0 * (double) this.remain;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/battery;component/battery.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    if (connectionId == 1)
      this.BatteryRemain = (Rectangle) target;
    else
      this._contentLoaded = true;
  }
}
