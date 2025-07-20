// Decompiled with JetBrains decompiler
// Type: MotorAircraft.FireEventArgs
// Assembly: MotorAircraft, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3EAE6236-0753-4F74-8C56-74002B013BFA
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\MotorAircraft.dll

using System;

#nullable disable
namespace MotorAircraft;

public class FireEventArgs : EventArgs
{
  public int firenumber;

  public FireEventArgs(int n) => this.firenumber = n;
}
