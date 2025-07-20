// Decompiled with JetBrains decompiler
// Type: Wpfbootload.HeightConvert
// Assembly: Wpfbootload, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4FEF84E1-06E0-4569-8BB0-07C571E890DC
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\Wpfbootload.exe

using System;
using System.Globalization;
using System.Windows.Data;

#nullable disable
namespace Wpfbootload;

public class HeightConvert : IValueConverter
{
  public int AddValue { get; set; }

  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return (object) ((int) System.Convert.ToInt16(value) + this.AddValue);
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return (object) ((int) System.Convert.ToInt16(value) - this.AddValue);
  }
}
