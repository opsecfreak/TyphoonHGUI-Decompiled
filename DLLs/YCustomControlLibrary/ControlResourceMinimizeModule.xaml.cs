// Decompiled with JetBrains decompiler
// Type: YCustomControlLibrary.ControlResource.MinimizeModule
// Assembly: YCustomControlLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4940B50A-5996-4EDB-9939-34777C39EC01
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\YCustomControlLibrary.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable disable
namespace YCustomControlLibrary.ControlResource;

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
    Application.LoadComponent((object) this, new Uri("/YCustomControlLibrary;component/controlresource/minimizemodule.xaml", UriKind.Relative));
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
