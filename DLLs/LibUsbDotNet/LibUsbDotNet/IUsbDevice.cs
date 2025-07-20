// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.IUsbDevice
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

#nullable disable
namespace LibUsbDotNet;

public interface IUsbDevice : IUsbInterface
{
  bool SetConfiguration(byte config);

  bool GetConfiguration(out byte config);

  bool SetAltInterface(int alternateID);

  bool GetAltInterfaceSetting(byte interfaceID, out byte selectedAltInterfaceID);

  bool ClaimInterface(int interfaceID);

  bool ReleaseInterface(int interfaceID);

  bool ResetDevice();
}
