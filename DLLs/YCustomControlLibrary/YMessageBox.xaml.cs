// Decompiled with JetBrains decompiler
// Type: YCustomControlLibrary.YMessageBox
// Assembly: YCustomControlLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4940B50A-5996-4EDB-9939-34777C39EC01
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\YCustomControlLibrary.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Threading;

#nullable disable
namespace YCustomControlLibrary;

public partial class YMessageBox : Window, IComponentConnector
{
  private static YMessageResultButton _reslut;
  internal YMessageBox main;
  internal TextBlock lblTitle;
  internal Thumb headerThumb;
  internal TextBlock lbcontent;
  internal Button ButtonNo;
  internal Button ButtonYes;
  private bool _contentLoaded;

  public YMessageBox()
  {
    this.InitializeComponent();
    this.ButtonYes.Focus();
  }

  private void headerThumb_DragDelta(object sender, DragDeltaEventArgs e)
  {
    this.Left += e.HorizontalChange;
    this.Top += e.VerticalChange;
  }

  private void ButtonYes_Click(object sender, RoutedEventArgs e)
  {
    YMessageBox._reslut = YMessageResultButton.Yes;
    this.DialogResult = new bool?(true);
    this.Close();
  }

  private void ButtonNO_Click(object sender, RoutedEventArgs e)
  {
    YMessageBox._reslut = YMessageResultButton.No;
    this.DialogResult = new bool?(false);
    this.Close();
  }

  public static YMessageResultButton Show(string content, string title, YMessageBoxButton button = YMessageBoxButton.Yes)
  {
    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Delegate) (() =>
    {
      YMessageBox ymessageBox = new YMessageBox();
      switch (button)
      {
        case YMessageBoxButton.Yes:
          ymessageBox.ButtonNo.Visibility = Visibility.Collapsed;
          break;
      }
      ymessageBox.lblTitle.Text = title;
      ymessageBox.lbcontent.Text = content;
      ymessageBox.ShowDialog();
    }));
    return YMessageBox._reslut;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/YCustomControlLibrary;component/ymessagebox.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        this.main = (YMessageBox) target;
        break;
      case 2:
        this.lblTitle = (TextBlock) target;
        break;
      case 3:
        this.headerThumb = (Thumb) target;
        this.headerThumb.DragDelta += new DragDeltaEventHandler(this.headerThumb_DragDelta);
        break;
      case 4:
        this.lbcontent = (TextBlock) target;
        break;
      case 5:
        this.ButtonNo = (Button) target;
        this.ButtonNo.Click += new RoutedEventHandler(this.ButtonNO_Click);
        break;
      case 6:
        this.ButtonYes = (Button) target;
        this.ButtonYes.Click += new RoutedEventHandler(this.ButtonYes_Click);
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
