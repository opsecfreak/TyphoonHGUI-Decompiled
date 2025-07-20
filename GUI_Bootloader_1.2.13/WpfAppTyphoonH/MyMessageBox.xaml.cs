// Decompiled with JetBrains decompiler
// Type: WpfAppTyphoonH.MyMessageBox
// Assembly: WpfAppTyphoonH, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 3524D12E-4BA5-4A95-813C-BA8CEFA4F2FA
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\WpfAppTyphoonH.exe

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media.Animation;

#nullable disable
namespace WpfAppTyphoonH;

public partial class MyMessageBox : Window, IComponentConnector
{
  internal MyMessageBox main;
  internal Storyboard sbOpShow;
  internal Thumb headerThumb;
  internal TextBlock lblTitle;
  internal TextBlock lblMsg;
  internal CheckBox Checkbox;
  internal Button Byes;
  private bool _contentLoaded;

  public MyMessageBox() => this.InitializeComponent();

  private void Button_Click(object sender, RoutedEventArgs e)
  {
    this.DialogResult = new bool?(false);
    this.Close();
  }

  private void Byes_Click(object sender, RoutedEventArgs e)
  {
    this.DialogResult = new bool?(true);
    this.Close();
  }

  private void Checkbox_Checked(object sender, RoutedEventArgs e) => this.Byes.IsEnabled = true;

  private void Checkbox_Unchecked(object sender, RoutedEventArgs e) => this.Byes.IsEnabled = false;

  private void headerThumb_DragDelta(object sender, DragDeltaEventArgs e)
  {
    this.Left += e.HorizontalChange;
    this.Top += e.VerticalChange;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/WpfAppTyphoonH;component/mymessagebox.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        this.main = (MyMessageBox) target;
        break;
      case 2:
        this.sbOpShow = (Storyboard) target;
        break;
      case 3:
        this.headerThumb = (Thumb) target;
        this.headerThumb.DragDelta += new DragDeltaEventHandler(this.headerThumb_DragDelta);
        break;
      case 4:
        this.lblTitle = (TextBlock) target;
        break;
      case 5:
        this.lblMsg = (TextBlock) target;
        break;
      case 6:
        this.Checkbox = (CheckBox) target;
        this.Checkbox.Checked += new RoutedEventHandler(this.Checkbox_Checked);
        this.Checkbox.Unchecked += new RoutedEventHandler(this.Checkbox_Unchecked);
        break;
      case 7:
        this.Byes = (Button) target;
        this.Byes.Click += new RoutedEventHandler(this.Byes_Click);
        break;
      case 8:
        ((ButtonBase) target).Click += new RoutedEventHandler(this.Button_Click);
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
