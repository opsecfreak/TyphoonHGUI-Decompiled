// Decompiled with JetBrains decompiler
// Type: Wpfbootload.MyControl.MinimizeModule
// Assembly: Wpfbootload, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4FEF84E1-06E0-4569-8BB0-07C571E890DC
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\Wpfbootload.exe

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable disable
namespace Wpfbootload.MyControl;

public partial class MinimizeModule : UserControl, IComponentConnector
{
  internal Grid LayoutRoot;
  private bool _contentLoaded;

  public MinimizeModule() => this.InitializeComponent();

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/Wpfbootload;component/mycontrol/minimizemodule.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    if (connectionId == 1)
      this.LayoutRoot = (Grid) target;
    else
      this._contentLoaded = true;
  }
}
