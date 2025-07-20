// Decompiled with JetBrains decompiler
// Type: battery.Properties.Resources
// Assembly: battery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2465C829-9D4F-4727-8648-0133DA15A102
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\battery.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

#nullable disable
namespace battery.Properties;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Resources
{
  private static ResourceManager resourceMan;
  private static CultureInfo resourceCulture;

  internal Resources()
  {
  }

  [EditorBrowsable(EditorBrowsableState.Advanced)]
  internal static ResourceManager ResourceManager
  {
    get
    {
      if (battery.Properties.Resources.resourceMan == null)
        battery.Properties.Resources.resourceMan = new ResourceManager("battery.Properties.Resources", typeof (battery.Properties.Resources).Assembly);
      return battery.Properties.Resources.resourceMan;
    }
  }

  [EditorBrowsable(EditorBrowsableState.Advanced)]
  internal static CultureInfo Culture
  {
    get => battery.Properties.Resources.resourceCulture;
    set => battery.Properties.Resources.resourceCulture = value;
  }

  internal static Bitmap battery_P
  {
    get
    {
      return (Bitmap) battery.Properties.Resources.ResourceManager.GetObject(nameof (battery_P), battery.Properties.Resources.resourceCulture);
    }
  }
}
