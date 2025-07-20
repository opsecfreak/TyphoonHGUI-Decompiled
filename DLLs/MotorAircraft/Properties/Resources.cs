// Decompiled with JetBrains decompiler
// Type: MotorAircraft.Properties.Resources
// Assembly: MotorAircraft, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3EAE6236-0753-4F74-8C56-74002B013BFA
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\MotorAircraft.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

#nullable disable
namespace MotorAircraft.Properties;

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
      if (MotorAircraft.Properties.Resources.resourceMan == null)
        MotorAircraft.Properties.Resources.resourceMan = new ResourceManager("MotorAircraft.Properties.Resources", typeof (MotorAircraft.Properties.Resources).Assembly);
      return MotorAircraft.Properties.Resources.resourceMan;
    }
  }

  [EditorBrowsable(EditorBrowsableState.Advanced)]
  internal static CultureInfo Culture
  {
    get => MotorAircraft.Properties.Resources.resourceCulture;
    set => MotorAircraft.Properties.Resources.resourceCulture = value;
  }

  internal static Bitmap FST
  {
    get => (Bitmap) MotorAircraft.Properties.Resources.ResourceManager.GetObject(nameof (FST), MotorAircraft.Properties.Resources.resourceCulture);
  }
}
