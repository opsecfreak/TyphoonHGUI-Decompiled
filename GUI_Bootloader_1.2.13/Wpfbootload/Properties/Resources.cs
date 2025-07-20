// Decompiled with JetBrains decompiler
// Type: Wpfbootload.Properties.Resources
// Assembly: Wpfbootload, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4FEF84E1-06E0-4569-8BB0-07C571E890DC
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\Wpfbootload.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

#nullable disable
namespace Wpfbootload.Properties;

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
      if (Wpfbootload.Properties.Resources.resourceMan == null)
        Wpfbootload.Properties.Resources.resourceMan = new ResourceManager("Wpfbootload.Properties.Resources", typeof (Wpfbootload.Properties.Resources).Assembly);
      return Wpfbootload.Properties.Resources.resourceMan;
    }
  }

  [EditorBrowsable(EditorBrowsableState.Advanced)]
  internal static CultureInfo Culture
  {
    get => Wpfbootload.Properties.Resources.resourceCulture;
    set => Wpfbootload.Properties.Resources.resourceCulture = value;
  }

  internal static Bitmap Cgo
  {
    get => (Bitmap) Wpfbootload.Properties.Resources.ResourceManager.GetObject(nameof (Cgo), Wpfbootload.Properties.Resources.resourceCulture);
  }

  internal static Icon Cgo1
  {
    get => (Icon) Wpfbootload.Properties.Resources.ResourceManager.GetObject(nameof (Cgo1), Wpfbootload.Properties.Resources.resourceCulture);
  }

  internal static Icon Main
  {
    get => (Icon) Wpfbootload.Properties.Resources.ResourceManager.GetObject(nameof (Main), Wpfbootload.Properties.Resources.resourceCulture);
  }

  internal static Bitmap MainICO
  {
    get
    {
      return (Bitmap) Wpfbootload.Properties.Resources.ResourceManager.GetObject(nameof (MainICO), Wpfbootload.Properties.Resources.resourceCulture);
    }
  }
}
