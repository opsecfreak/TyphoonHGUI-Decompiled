// Decompiled with JetBrains decompiler
// Type: MonoLibUsb.Profile.AddRemoveEventArgs
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System;

#nullable disable
namespace MonoLibUsb.Profile;

public class AddRemoveEventArgs : EventArgs
{
  private readonly AddRemoveType mAddRemoveType;
  private readonly MonoUsbProfile mMonoUSBProfile;

  internal AddRemoveEventArgs(MonoUsbProfile monoUSBProfile, AddRemoveType addRemoveType)
  {
    this.mMonoUSBProfile = monoUSBProfile;
    this.mAddRemoveType = addRemoveType;
  }

  public MonoUsbProfile MonoUSBProfile => this.mMonoUSBProfile;

  public AddRemoveType EventType => this.mAddRemoveType;
}
