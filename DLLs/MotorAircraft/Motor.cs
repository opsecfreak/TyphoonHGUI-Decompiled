// Decompiled with JetBrains decompiler
// Type: MotorAircraft.Motor
// Assembly: MotorAircraft, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3EAE6236-0753-4F74-8C56-74002B013BFA
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\MotorAircraft.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

#nullable disable
namespace MotorAircraft;

public class Motor : UserControl, IComponentConnector
{
  private byte fire;
  private bool enable;
  private Brush red = (Brush) new SolidColorBrush(Color.FromArgb((byte) 70, (byte) 211, (byte) 9, (byte) 9));
  private Brush none = (Brush) new SolidColorBrush(Color.FromArgb((byte) 0, (byte) 0, (byte) 0, (byte) 0));
  private Brush green = (Brush) new SolidColorBrush(Color.FromArgb((byte) 70, (byte) 96 /*0x60*/, byte.MaxValue, (byte) 22));
  internal Ellipse motor1;
  internal Ellipse motor2;
  internal Ellipse motor3;
  internal Ellipse motor4;
  internal Ellipse motor6;
  internal Ellipse motor5;
  private bool _contentLoaded;

  public event EventHandler<FireEventArgs> Fire;

  public event EventHandler<FireEventArgs> NoFire;

  public void OnFire(FireEventArgs e)
  {
    if (this.Fire == null)
      return;
    this.Fire((object) this, e);
  }

  public void OffFire(FireEventArgs e)
  {
    if (this.NoFire == null)
      return;
    this.NoFire((object) this, e);
  }

  public byte FIRE
  {
    set
    {
      this.fire = value;
      this.makestatus();
    }
    get => this.fire;
  }

  public bool yEnable
  {
    set
    {
      this.enable = value;
      this.makenble();
    }
    get => this.enable;
  }

  public Motor()
  {
    this.InitializeComponent();
    this.motor1.Fill = this.none;
    this.motor1.IsEnabled = false;
    this.motor2.Fill = this.none;
    this.motor2.IsEnabled = false;
    this.motor3.Fill = this.none;
    this.motor3.IsEnabled = false;
    this.motor4.Fill = this.none;
    this.motor4.IsEnabled = false;
    this.motor5.Fill = this.none;
    this.motor5.IsEnabled = false;
    this.motor6.Fill = this.none;
    this.motor6.IsEnabled = false;
  }

  private void makestatus()
  {
    byte fire = this.fire;
    if (fire <= (byte) 8)
    {
      switch ((int) fire - 1)
      {
        case 0:
          this.motor1.Fill = this.green;
          this.motor2.Fill = this.red;
          this.motor3.Fill = this.red;
          this.motor4.Fill = this.red;
          this.motor5.Fill = this.red;
          this.motor6.Fill = this.red;
          return;
        case 1:
          this.motor1.Fill = this.red;
          this.motor2.Fill = this.green;
          this.motor3.Fill = this.red;
          this.motor4.Fill = this.red;
          this.motor5.Fill = this.red;
          this.motor6.Fill = this.red;
          return;
        case 2:
          break;
        case 3:
          this.motor1.Fill = this.red;
          this.motor2.Fill = this.red;
          this.motor3.Fill = this.green;
          this.motor4.Fill = this.red;
          this.motor5.Fill = this.red;
          this.motor6.Fill = this.red;
          return;
        default:
          if (fire == (byte) 8)
          {
            this.motor1.Fill = this.red;
            this.motor2.Fill = this.red;
            this.motor3.Fill = this.red;
            this.motor4.Fill = this.green;
            this.motor5.Fill = this.red;
            this.motor6.Fill = this.red;
            return;
          }
          break;
      }
    }
    else if (fire != (byte) 16 /*0x10*/)
    {
      if (fire != (byte) 32 /*0x20*/)
      {
        if (fire == byte.MaxValue)
        {
          this.motor1.Fill = this.green;
          this.motor2.Fill = this.green;
          this.motor3.Fill = this.green;
          this.motor4.Fill = this.green;
          this.motor5.Fill = this.green;
          this.motor6.Fill = this.green;
          return;
        }
      }
      else
      {
        this.motor1.Fill = this.red;
        this.motor2.Fill = this.red;
        this.motor3.Fill = this.red;
        this.motor4.Fill = this.red;
        this.motor5.Fill = this.red;
        this.motor6.Fill = this.green;
        return;
      }
    }
    else
    {
      this.motor1.Fill = this.red;
      this.motor2.Fill = this.red;
      this.motor3.Fill = this.red;
      this.motor4.Fill = this.red;
      this.motor5.Fill = this.green;
      this.motor6.Fill = this.red;
      return;
    }
    this.motor1.Fill = this.red;
    this.motor2.Fill = this.red;
    this.motor3.Fill = this.red;
    this.motor4.Fill = this.red;
    this.motor5.Fill = this.red;
    this.motor6.Fill = this.red;
  }

  private void makenble()
  {
    if (this.enable)
    {
      this.motor1.Fill = this.red;
      this.motor1.IsEnabled = true;
      this.motor2.Fill = this.red;
      this.motor2.IsEnabled = true;
      this.motor3.Fill = this.red;
      this.motor3.IsEnabled = true;
      this.motor4.Fill = this.red;
      this.motor4.IsEnabled = true;
      this.motor5.Fill = this.red;
      this.motor5.IsEnabled = true;
      this.motor6.Fill = this.red;
      this.motor6.IsEnabled = true;
    }
    else
    {
      this.motor1.Fill = this.none;
      this.motor1.IsEnabled = false;
      this.motor2.Fill = this.none;
      this.motor2.IsEnabled = false;
      this.motor3.Fill = this.none;
      this.motor3.IsEnabled = false;
      this.motor4.Fill = this.none;
      this.motor4.IsEnabled = false;
      this.motor5.Fill = this.none;
      this.motor5.IsEnabled = false;
      this.motor6.Fill = this.none;
      this.motor6.IsEnabled = false;
    }
  }

  private void motor1_MouseDown(object sender, MouseButtonEventArgs e)
  {
    this.motor1.Fill = this.green;
    this.fire |= (byte) 1;
    this.OnFire(new FireEventArgs(1));
  }

  private void motor1_MouseLeave(object sender, MouseEventArgs e)
  {
    this.motor1.Fill = this.red;
    this.fire &= (byte) 254;
    this.OffFire(new FireEventArgs(1));
  }

  private void motor2_MouseDown(object sender, MouseButtonEventArgs e)
  {
    this.motor2.Fill = this.green;
    this.fire |= (byte) 2;
    this.OnFire(new FireEventArgs(2));
  }

  private void motor2_MouseLeave(object sender, MouseEventArgs e)
  {
    this.motor2.Fill = this.red;
    this.fire &= (byte) 253;
    this.OffFire(new FireEventArgs(2));
  }

  private void motor3_MouseDown(object sender, MouseButtonEventArgs e)
  {
    this.motor3.Fill = this.green;
    this.fire |= (byte) 4;
    this.OnFire(new FireEventArgs(3));
  }

  private void motor3_MouseLeave(object sender, MouseEventArgs e)
  {
    this.motor3.Fill = this.red;
    this.fire &= (byte) 251;
    this.OffFire(new FireEventArgs(3));
  }

  private void motor4_MouseDown(object sender, MouseButtonEventArgs e)
  {
    this.motor4.Fill = this.green;
    this.fire |= (byte) 8;
    this.OnFire(new FireEventArgs(4));
  }

  private void motor4_MouseLeave(object sender, MouseEventArgs e)
  {
    this.motor4.Fill = this.red;
    this.fire &= (byte) 247;
    this.OffFire(new FireEventArgs(4));
  }

  private void motor6_MouseDown(object sender, MouseButtonEventArgs e)
  {
    this.motor6.Fill = this.green;
    this.fire |= (byte) 16 /*0x10*/;
    this.OnFire(new FireEventArgs(6));
  }

  private void motor6_MouseLeave(object sender, MouseEventArgs e)
  {
    this.motor6.Fill = this.red;
    this.fire &= (byte) 239;
    this.OffFire(new FireEventArgs(6));
  }

  private void motor5_MouseDown(object sender, MouseButtonEventArgs e)
  {
    this.motor5.Fill = this.green;
    this.fire |= (byte) 32 /*0x20*/;
    this.OnFire(new FireEventArgs(5));
  }

  private void motor5_MouseLeave(object sender, MouseEventArgs e)
  {
    this.motor5.Fill = this.red;
    this.fire &= (byte) 223;
    this.OffFire(new FireEventArgs(5));
  }

  private void motor1_MouseUp(object sender, MouseButtonEventArgs e)
  {
    this.motor1.Fill = this.red;
    this.fire &= (byte) 254;
    this.OffFire(new FireEventArgs(1));
  }

  private void motor2_MouseUp(object sender, MouseButtonEventArgs e)
  {
    this.motor2.Fill = this.red;
    this.fire &= (byte) 253;
    this.OffFire(new FireEventArgs(2));
  }

  private void motor3_MouseUp(object sender, MouseButtonEventArgs e)
  {
    this.motor3.Fill = this.red;
    this.fire &= (byte) 251;
    this.OffFire(new FireEventArgs(3));
  }

  private void motor4_MouseUp(object sender, MouseButtonEventArgs e)
  {
    this.motor4.Fill = this.red;
    this.fire &= (byte) 247;
    this.OffFire(new FireEventArgs(4));
  }

  private void motor6_MouseUp(object sender, MouseButtonEventArgs e)
  {
    this.motor6.Fill = this.red;
    this.fire &= (byte) 239;
    this.OffFire(new FireEventArgs(6));
  }

  private void motor5_MouseUp(object sender, MouseButtonEventArgs e)
  {
    this.motor5.Fill = this.red;
    this.fire &= (byte) 223;
    this.OffFire(new FireEventArgs(5));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/MotorAircraft;component/aircraftmotor.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        this.motor1 = (Ellipse) target;
        this.motor1.MouseDown += new MouseButtonEventHandler(this.motor1_MouseDown);
        this.motor1.MouseLeave += new MouseEventHandler(this.motor1_MouseLeave);
        this.motor1.MouseUp += new MouseButtonEventHandler(this.motor1_MouseUp);
        break;
      case 2:
        this.motor2 = (Ellipse) target;
        this.motor2.MouseDown += new MouseButtonEventHandler(this.motor2_MouseDown);
        this.motor2.MouseLeave += new MouseEventHandler(this.motor2_MouseLeave);
        this.motor2.MouseUp += new MouseButtonEventHandler(this.motor2_MouseUp);
        break;
      case 3:
        this.motor3 = (Ellipse) target;
        this.motor3.MouseDown += new MouseButtonEventHandler(this.motor3_MouseDown);
        this.motor3.MouseLeave += new MouseEventHandler(this.motor3_MouseLeave);
        this.motor3.MouseUp += new MouseButtonEventHandler(this.motor3_MouseUp);
        break;
      case 4:
        this.motor4 = (Ellipse) target;
        this.motor4.MouseDown += new MouseButtonEventHandler(this.motor4_MouseDown);
        this.motor4.MouseLeave += new MouseEventHandler(this.motor4_MouseLeave);
        this.motor4.MouseUp += new MouseButtonEventHandler(this.motor4_MouseUp);
        break;
      case 5:
        this.motor6 = (Ellipse) target;
        this.motor6.MouseDown += new MouseButtonEventHandler(this.motor6_MouseDown);
        this.motor6.MouseLeave += new MouseEventHandler(this.motor6_MouseLeave);
        this.motor6.MouseUp += new MouseButtonEventHandler(this.motor6_MouseUp);
        break;
      case 6:
        this.motor5 = (Ellipse) target;
        this.motor5.MouseDown += new MouseButtonEventHandler(this.motor5_MouseDown);
        this.motor5.MouseLeave += new MouseEventHandler(this.motor5_MouseLeave);
        this.motor5.MouseUp += new MouseButtonEventHandler(this.motor5_MouseUp);
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
