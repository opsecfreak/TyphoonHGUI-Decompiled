// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.WinUsb.WinUsbRegistry
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Internal;
using LibUsbDotNet.Internal.UsbRegex;
using LibUsbDotNet.Main;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

#nullable disable
namespace LibUsbDotNet.WinUsb;

public class WinUsbRegistry : UsbRegistry
{
  private bool mIsDeviceIDParsed;
  private string mDeviceID;
  private byte mInterfaceID;
  private ushort mVid;
  private ushort mPid;

  public static bool GetDevicePathList(Guid deviceInterfaceGuid, out List<string> devicePathList)
  {
    devicePathList = new List<string>();
    int memberIndex = 0;
    SetupApi.SP_DEVICE_INTERFACE_DATA empty = SetupApi.SP_DEVICE_INTERFACE_DATA.Empty;
    IntPtr classDevs = SetupApi.SetupDiGetClassDevs(ref deviceInterfaceGuid, (string) null, IntPtr.Zero, SetupApi.DICFG.PRESENT | SetupApi.DICFG.DEVICEINTERFACE);
    if (classDevs != IntPtr.Zero)
    {
      for (; SetupApi.SetupDiEnumDeviceInterfaces(classDevs, (object) null, ref deviceInterfaceGuid, memberIndex, ref empty); ++memberIndex)
      {
        int requiredSize = 1024 /*0x0400*/;
        SetupApi.DeviceInterfaceDetailHelper interfaceDetailHelper = new SetupApi.DeviceInterfaceDetailHelper(requiredSize);
        if (SetupApi.SetupDiGetDeviceInterfaceDetail(classDevs, ref empty, interfaceDetailHelper.Handle, requiredSize, out requiredSize, (object) null))
          devicePathList.Add(interfaceDetailHelper.DevicePath);
      }
    }
    if (memberIndex == 0)
      UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (GetDevicePathList), (object) typeof (SetupApi));
    if (classDevs != IntPtr.Zero)
      SetupApi.SetupDiDestroyDeviceInfoList(classDevs);
    return memberIndex > 0;
  }

  public static bool GetWinUsbRegistryList(
    Guid deviceInterfaceGuid,
    out List<WinUsbRegistry> deviceRegistryList)
  {
    deviceRegistryList = new List<WinUsbRegistry>();
    int memberIndex = 0;
    SetupApi.SP_DEVICE_INTERFACE_DATA empty1 = SetupApi.SP_DEVICE_INTERFACE_DATA.Empty;
    SetupApi.SP_DEVINFO_DATA empty2 = SetupApi.SP_DEVINFO_DATA.Empty;
    IntPtr classDevs = SetupApi.SetupDiGetClassDevs(ref deviceInterfaceGuid, (string) null, IntPtr.Zero, SetupApi.DICFG.PRESENT | SetupApi.DICFG.DEVICEINTERFACE);
    if (classDevs != IntPtr.Zero)
    {
      for (; SetupApi.SetupDiEnumDeviceInterfaces(classDevs, (object) null, ref deviceInterfaceGuid, memberIndex, ref empty1); ++memberIndex)
      {
        int requiredSize = 1024 /*0x0400*/;
        SetupApi.DeviceInterfaceDetailHelper interfaceDetailHelper = new SetupApi.DeviceInterfaceDetailHelper(requiredSize);
        if (SetupApi.SetupDiGetDeviceInterfaceDetail(classDevs, ref empty1, interfaceDetailHelper.Handle, requiredSize, out requiredSize, ref empty2))
        {
          WinUsbRegistry winUsbRegistry = new WinUsbRegistry();
          SetupApi.getSPDRPProperties(classDevs, ref empty2, winUsbRegistry.mDeviceProperties);
          winUsbRegistry.mDeviceProperties.Add("SymbolicName", (object) interfaceDetailHelper.DevicePath);
          winUsbRegistry.mDeviceInterfaceGuids = new Guid[1]
          {
            deviceInterfaceGuid
          };
          StringBuilder Buffer = new StringBuilder(1024 /*0x0400*/);
          if (SetupApi.CM_Get_Device_ID(empty2.DevInst, Buffer, Buffer.Capacity, 0) == SetupApi.CR.SUCCESS)
            winUsbRegistry.mDeviceProperties["DeviceID"] = (object) Buffer.ToString();
          deviceRegistryList.Add(winUsbRegistry);
        }
      }
    }
    if (memberIndex == 0)
      UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), "GetDevicePathList", (object) typeof (SetupApi));
    if (classDevs != IntPtr.Zero)
      SetupApi.SetupDiDestroyDeviceInfoList(classDevs);
    return memberIndex > 0;
  }

  internal WinUsbRegistry()
  {
  }

  public static List<WinUsbRegistry> DeviceList
  {
    get
    {
      List<WinUsbRegistry> classEnumeratorCallbackParam1 = new List<WinUsbRegistry>();
      SetupApi.EnumClassDevs((string) null, SetupApi.DICFG.PRESENT | SetupApi.DICFG.ALLCLASSES, new SetupApi.ClassEnumeratorDelegate(WinUsbRegistry.WinUsbRegistryCallBack), (object) classEnumeratorCallbackParam1);
      return classEnumeratorCallbackParam1;
    }
  }

  public override Guid[] DeviceInterfaceGuids => this.mDeviceInterfaceGuids;

  public override bool IsAlive
  {
    get
    {
      if (string.IsNullOrEmpty(this.SymbolicName))
        throw new UsbException((object) this, "A symbolic name is required for this property.");
      foreach (WinUsbRegistry device in WinUsbRegistry.DeviceList)
      {
        if (!string.IsNullOrEmpty(device.SymbolicName) && device.SymbolicName == this.SymbolicName)
          return true;
      }
      return false;
    }
  }

  public override UsbDevice Device
  {
    get
    {
      WinUsbDevice usbDevice;
      this.Open(out usbDevice);
      return (UsbDevice) usbDevice;
    }
  }

  private void parseDeviceID()
  {
    if (this.mIsDeviceIDParsed)
      return;
    this.mIsDeviceIDParsed = true;
    foreach (Match match in RegHardwareID.GlobalInstance.Matches(this.DeviceID))
    {
      foreach (NamedGroup namedGroup in RegHardwareID.NAMED_GROUPS)
      {
        Group group = match.Groups[namedGroup.GroupNumber];
        ushort result1;
        if (group.Success)
        {
          switch (namedGroup.GroupNumber)
          {
            case 1:
              if (ushort.TryParse(group.Value, NumberStyles.HexNumber, (IFormatProvider) null, out result1))
              {
                this.mVid = result1;
                continue;
              }
              continue;
            case 2:
              if (ushort.TryParse(group.Value, NumberStyles.HexNumber, (IFormatProvider) null, out result1))
              {
                this.mPid = result1;
                continue;
              }
              continue;
            case 3:
              continue;
            case 4:
              byte result2;
              if (byte.TryParse(group.Value, NumberStyles.HexNumber, (IFormatProvider) null, out result2))
              {
                this.mInterfaceID = result2;
                continue;
              }
              continue;
            default:
              throw new ArgumentOutOfRangeException();
          }
        }
      }
    }
  }

  public string DeviceID
  {
    get
    {
      if (this.mDeviceID == null)
      {
        object obj;
        this.mDeviceID = !this.mDeviceProperties.TryGetValue(nameof (DeviceID), out obj) ? string.Empty : obj.ToString();
      }
      return this.mDeviceID;
    }
  }

  public override int Vid
  {
    get
    {
      this.parseDeviceID();
      return (int) this.mVid;
    }
  }

  public override int Pid
  {
    get
    {
      this.parseDeviceID();
      return (int) this.mPid;
    }
  }

  public byte InterfaceID
  {
    get
    {
      this.parseDeviceID();
      return this.mInterfaceID;
    }
  }

  public override bool Open(out UsbDevice usbDevice)
  {
    usbDevice = (UsbDevice) null;
    WinUsbDevice usbDevice1;
    int num = this.Open(out usbDevice1) ? 1 : 0;
    if (num == 0)
      return num != 0;
    usbDevice = (UsbDevice) usbDevice1;
    return num != 0;
  }

  public bool Open(out WinUsbDevice usbDevice)
  {
    usbDevice = (WinUsbDevice) null;
    if (string.IsNullOrEmpty(this.SymbolicName) || !WinUsbDevice.Open(this.SymbolicName, out usbDevice))
      return false;
    usbDevice.mUsbRegistry = (UsbRegistry) this;
    return true;
  }

  private static bool WinUsbRegistryCallBack(
    IntPtr deviceInfoSet,
    int deviceIndex,
    ref SetupApi.SP_DEVINFO_DATA deviceInfoData,
    object classEnumeratorCallbackParam1)
  {
    List<WinUsbRegistry> winUsbRegistryList = (List<WinUsbRegistry>) classEnumeratorCallbackParam1;
    byte[] numArray = new byte[256 /*0x0100*/];
    int RequiredSize;
    if (SetupApi.SetupDiGetCustomDeviceProperty(deviceInfoSet, ref deviceInfoData, "DeviceInterfaceGuids", SetupApi.DICUSTOMDEVPROP.NONE, out RegistryValueKind _, numArray, numArray.Length, out RequiredSize))
    {
      foreach (string asString in UsbRegistry.GetAsStringArray(numArray, RequiredSize))
      {
        Guid deviceInterfaceGuid = new Guid(asString);
        List<WinUsbRegistry> deviceRegistryList;
        if (WinUsbRegistry.GetWinUsbRegistryList(deviceInterfaceGuid, out deviceRegistryList))
        {
          foreach (WinUsbRegistry winUsbRegistry1 in deviceRegistryList)
          {
            WinUsbRegistry winUsbRegistry2 = (WinUsbRegistry) null;
            foreach (WinUsbRegistry winUsbRegistry3 in winUsbRegistryList)
            {
              if (winUsbRegistry3.SymbolicName == winUsbRegistry1.SymbolicName)
              {
                winUsbRegistry2 = winUsbRegistry3;
                break;
              }
            }
            if (winUsbRegistry2 == null)
            {
              winUsbRegistryList.Add(winUsbRegistry1);
            }
            else
            {
              List<Guid> guidList = new List<Guid>((IEnumerable<Guid>) winUsbRegistry2.mDeviceInterfaceGuids);
              if (!guidList.Contains(deviceInterfaceGuid))
              {
                guidList.Add(deviceInterfaceGuid);
                winUsbRegistry2.mDeviceInterfaceGuids = guidList.ToArray();
              }
            }
          }
        }
      }
    }
    return false;
  }
}
