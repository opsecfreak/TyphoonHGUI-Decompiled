﻿// Decompiled with JetBrains decompiler
// Type: MavLinkNet.UasEnumMetadata
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.Collections.Generic;

#nullable disable
namespace MavLinkNet;

public class UasEnumMetadata
{
  public string Name;
  public string Description;
  public List<UasEnumEntryMetadata> Entries = new List<UasEnumEntryMetadata>();
}
