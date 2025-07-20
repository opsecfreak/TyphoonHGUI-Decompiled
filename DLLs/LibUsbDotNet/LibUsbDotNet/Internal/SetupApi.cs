// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Internal.SetupApi
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using LibUsbDotNet.Main;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace LibUsbDotNet.Internal;

internal class SetupApi
{
  private const string STRUCT_END_MARK = "STRUCT_END_MARK";
  public static readonly Guid GUID_DEVINTERFACE_USB_DEVICE = new Guid("f18a0e88-c30c-11d0-8815-00a0c906bed8");

  public static bool Is64Bit => IntPtr.Size == 8;

  [DllImport("setupapi.dll", CharSet = CharSet.Auto)]
  public static extern SetupApi.CR CM_Get_Device_ID(
    IntPtr dnDevInst,
    IntPtr Buffer,
    int BufferLen,
    int ulFlags);

  [DllImport("setupapi.dll")]
  public static extern SetupApi.CR CM_Get_Parent(
    out IntPtr pdnDevInst,
    IntPtr dnDevInst,
    int ulFlags);

  [DllImport("setupapi.dll", CharSet = CharSet.Auto)]
  public static extern bool SetupDiDestroyDeviceInfoList(IntPtr hDevInfo);

  [DllImport("setupapi.dll", SetLastError = true)]
  public static extern bool SetupDiEnumDeviceInfo(
    IntPtr DeviceInfoSet,
    int MemberIndex,
    ref SetupApi.SP_DEVINFO_DATA DeviceInfoData);

  [DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
  public static extern bool SetupDiEnumDeviceInterfaces(
    IntPtr hDevInfo,
    ref SetupApi.SP_DEVINFO_DATA devInfo,
    ref Guid interfaceClassGuid,
    int memberIndex,
    ref SetupApi.SP_DEVICE_INTERFACE_DATA deviceInterfaceData);

  [DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
  public static extern bool SetupDiEnumDeviceInterfaces(
    IntPtr hDevInfo,
    [MarshalAs(UnmanagedType.AsAny)] object devInfo,
    ref Guid interfaceClassGuid,
    int memberIndex,
    ref SetupApi.SP_DEVICE_INTERFACE_DATA deviceInterfaceData);

  [DllImport("setupapi.dll", EntryPoint = "SetupDiGetClassDevsA", CharSet = CharSet.Ansi)]
  public static extern IntPtr SetupDiGetClassDevs(
    ref Guid ClassGuid,
    [MarshalAs(UnmanagedType.LPTStr)] string Enumerator,
    IntPtr hwndParent,
    SetupApi.DICFG Flags);

  [DllImport("setupapi.dll", EntryPoint = "SetupDiGetClassDevsA", CharSet = CharSet.Ansi)]
  public static extern IntPtr SetupDiGetClassDevs(
    ref Guid ClassGuid,
    int Enumerator,
    IntPtr hwndParent,
    SetupApi.DICFG Flags);

  [DllImport("setupapi.dll", EntryPoint = "SetupDiGetClassDevsA", CharSet = CharSet.Ansi)]
  public static extern IntPtr SetupDiGetClassDevs(
    int ClassGuid,
    string Enumerator,
    IntPtr hwndParent,
    SetupApi.DICFG Flags);

  [DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
  public static extern bool SetupDiGetCustomDeviceProperty(
    IntPtr DeviceInfoSet,
    ref SetupApi.SP_DEVINFO_DATA DeviceInfoData,
    string CustomPropertyName,
    SetupApi.DICUSTOMDEVPROP Flags,
    out RegistryValueKind PropertyRegDataType,
    byte[] PropertyBuffer,
    int PropertyBufferSize,
    out int RequiredSize);

  [DllImport("setupapi.dll", EntryPoint = "SetupDiGetDeviceInstanceIdA", CharSet = CharSet.Ansi, SetLastError = true)]
  public static extern bool SetupDiGetDeviceInstanceId(
    IntPtr DeviceInfoSet,
    ref SetupApi.SP_DEVINFO_DATA DeviceInfoData,
    StringBuilder DeviceInstanceId,
    int DeviceInstanceIdSize,
    out int RequiredSize);

  [DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
  public static extern bool SetupDiGetDeviceInterfaceDetail(
    IntPtr hDevInfo,
    ref SetupApi.SP_DEVICE_INTERFACE_DATA deviceInterfaceData,
    SetupApi.DEVICE_INTERFACE_DETAIL_HANDLE deviceInterfaceDetailData,
    int deviceInterfaceDetailDataSize,
    out int requiredSize,
    [MarshalAs(UnmanagedType.AsAny)] object deviceInfoData);

  [DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
  public static extern bool SetupDiGetDeviceInterfaceDetail(
    IntPtr hDevInfo,
    ref SetupApi.SP_DEVICE_INTERFACE_DATA deviceInterfaceData,
    SetupApi.DEVICE_INTERFACE_DETAIL_HANDLE deviceInterfaceDetailData,
    int deviceInterfaceDetailDataSize,
    out int requiredSize,
    ref SetupApi.SP_DEVINFO_DATA deviceInfoData);

  [DllImport("setupapi.dll", CharSet = CharSet.Auto)]
  public static extern bool SetupDiGetDeviceInterfacePropertyKeys(
    IntPtr DeviceInfoSet,
    ref SetupApi.SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
    byte[] propKeyBuffer,
    int propKeyBufferElements,
    out int RequiredPropertyKeyCount,
    int Flags);

  [DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
  public static extern bool SetupDiGetDeviceRegistryProperty(
    IntPtr DeviceInfoSet,
    ref SetupApi.SP_DEVINFO_DATA DeviceInfoData,
    SPDRP Property,
    out RegistryValueKind PropertyRegDataType,
    byte[] PropertyBuffer,
    int PropertyBufferSize,
    out int RequiredSize);

  [DllImport("setupapi.dll", CharSet = CharSet.Auto)]
  public static extern SetupApi.CR CM_Get_Device_ID(
    uint dnDevInst,
    StringBuilder Buffer,
    int BufferLen,
    int ulFlags);

  [DllImport("Setupapi", CharSet = CharSet.Auto, SetLastError = true)]
  public static extern IntPtr SetupDiOpenDevRegKey(
    IntPtr hDeviceInfoSet,
    ref SetupApi.SP_DEVINFO_DATA deviceInfoData,
    int scope,
    int hwProfile,
    SetupApi.DevKeyType keyType,
    RegistryKeyPermissionCheck samDesired);

  [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  public static extern int RegEnumValue(
    IntPtr hKey,
    int index,
    StringBuilder lpValueName,
    ref int lpcValueName,
    IntPtr lpReserved,
    out RegistryValueKind lpType,
    byte[] data,
    ref int dataLength);

  [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  public static extern int RegEnumValue(
    IntPtr hKey,
    int index,
    StringBuilder lpValueName,
    ref int lpcValueName,
    IntPtr lpReserved,
    out RegistryValueKind lpType,
    StringBuilder data,
    ref int dataLength);

  [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  public static extern int RegCloseKey(IntPtr hKey);

  public static bool EnumClassDevs(
    string enumerator,
    SetupApi.DICFG flags,
    SetupApi.ClassEnumeratorDelegate classEnumeratorCallback,
    object classEnumeratorCallbackParam1)
  {
    SetupApi.SP_DEVINFO_DATA empty = SetupApi.SP_DEVINFO_DATA.Empty;
    int num = 0;
    IntPtr classDevs = SetupApi.SetupDiGetClassDevs(0, enumerator, IntPtr.Zero, flags);
    if (classDevs == IntPtr.Zero || classDevs.ToInt64() == -1L)
      return false;
    bool flag = false;
    for (; SetupApi.SetupDiEnumDeviceInfo(classDevs, num, ref empty); ++num)
    {
      if (classEnumeratorCallback(classDevs, num, ref empty, classEnumeratorCallbackParam1))
      {
        flag = true;
        break;
      }
    }
    SetupApi.SetupDiDestroyDeviceInfoList(classDevs);
    return flag;
  }

  public static void getSPDRPProperties(
    IntPtr deviceInfoSet,
    ref SetupApi.SP_DEVINFO_DATA deviceInfoData,
    Dictionary<string, object> deviceProperties)
  {
    byte[] numArray = new byte[1024 /*0x0400*/];
    foreach (KeyValuePair<string, int> keyValuePair in Helper.GetEnumData(typeof (SPDRP)))
    {
      object obj = (object) string.Empty;
      int RequiredSize;
      if (SetupApi.SetupDiGetDeviceRegistryProperty(deviceInfoSet, ref deviceInfoData, (SPDRP) keyValuePair.Value, out RegistryValueKind _, numArray, numArray.Length, out RequiredSize))
      {
        switch (keyValuePair.Value)
        {
          case 0:
          case 7:
          case 8:
          case 9:
          case 11:
          case 12:
          case 13:
          case 14:
          case 22:
            obj = (object) UsbRegistry.GetAsString(numArray, RequiredSize);
            break;
          case 1:
          case 2:
          case 35:
            obj = (object) UsbRegistry.GetAsStringArray(numArray, RequiredSize);
            break;
          case 16 /*0x10*/:
          case 20:
          case 21:
          case 28:
          case 31 /*0x1F*/:
          case 34:
            obj = (object) UsbRegistry.GetAsStringInt32(numArray, RequiredSize);
            break;
          case 19:
            obj = (object) UsbRegistry.GetAsGuid(numArray, RequiredSize);
            break;
        }
      }
      else
        obj = (object) string.Empty;
      deviceProperties.Add(keyValuePair.Key, obj);
    }
  }

  public static bool SetupDiGetDeviceInterfaceDetailLength(
    IntPtr hDevInfo,
    ref SetupApi.SP_DEVICE_INTERFACE_DATA deviceInterfaceData,
    out int requiredLength)
  {
    SetupApi.DEVICE_INTERFACE_DETAIL_HANDLE deviceInterfaceDetailData = new SetupApi.DEVICE_INTERFACE_DETAIL_HANDLE();
    return SetupApi.SetupDiGetDeviceInterfaceDetail(hDevInfo, ref deviceInterfaceData, deviceInterfaceDetailData, 0, out requiredLength, (object) null);
  }

  public static bool SetupDiGetDeviceRegistryProperty(
    out byte[] regBytes,
    IntPtr DeviceInfoSet,
    ref SetupApi.SP_DEVINFO_DATA DeviceInfoData,
    SPDRP Property)
  {
    regBytes = (byte[]) null;
    byte[] numArray = new byte[1024 /*0x0400*/];
    int RequiredSize;
    if (!SetupApi.SetupDiGetDeviceRegistryProperty(DeviceInfoSet, ref DeviceInfoData, Property, out RegistryValueKind _, numArray, numArray.Length, out RequiredSize))
    {
      UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (SetupDiGetDeviceRegistryProperty), (object) typeof (SetupApi));
      return false;
    }
    regBytes = new byte[RequiredSize];
    Array.Copy((Array) numArray, (Array) regBytes, regBytes.Length);
    return true;
  }

  public static bool SetupDiGetDeviceRegistryProperty(
    out string regSZ,
    IntPtr DeviceInfoSet,
    ref SetupApi.SP_DEVINFO_DATA DeviceInfoData,
    SPDRP Property)
  {
    regSZ = (string) null;
    byte[] regBytes;
    if (!SetupApi.SetupDiGetDeviceRegistryProperty(out regBytes, DeviceInfoSet, ref DeviceInfoData, Property))
      return false;
    regSZ = Encoding.Unicode.GetString(regBytes).TrimEnd(new char[1]);
    return true;
  }

  public static bool SetupDiGetDeviceRegistryProperty(
    out string[] regMultiSZ,
    IntPtr DeviceInfoSet,
    ref SetupApi.SP_DEVINFO_DATA DeviceInfoData,
    SPDRP Property)
  {
    regMultiSZ = (string[]) null;
    string regSZ;
    if (!SetupApi.SetupDiGetDeviceRegistryProperty(out regSZ, DeviceInfoSet, ref DeviceInfoData, Property))
      return false;
    regMultiSZ = regSZ.Split(new char[1], StringSplitOptions.RemoveEmptyEntries);
    return true;
  }

  private static bool cbHasDeviceInterfaceGUID(
    IntPtr DeviceInfoSet,
    int deviceIndex,
    ref SetupApi.SP_DEVINFO_DATA DeviceInfoData,
    object devInterfaceGuid)
  {
    byte[] numArray = new byte[256 /*0x0100*/];
    int RequiredSize;
    return SetupApi.SetupDiGetCustomDeviceProperty(DeviceInfoSet, ref DeviceInfoData, "DeviceInterfaceGuids", SetupApi.DICUSTOMDEVPROP.NONE, out RegistryValueKind _, numArray, numArray.Length, out RequiredSize) && (Guid) devInterfaceGuid == new Guid(Encoding.Unicode.GetString(numArray, 0, RequiredSize).Split(new char[1], StringSplitOptions.RemoveEmptyEntries)[0]);
  }

  public delegate bool ClassEnumeratorDelegate(
    IntPtr DeviceInfoSet,
    int deviceIndex,
    ref SetupApi.SP_DEVINFO_DATA DeviceInfoData,
    object classEnumeratorCallbackParam1);

  public enum CR
  {
    SUCCESS = 0,
    DEFAULT = 1,
    OUT_OF_MEMORY = 2,
    INVALID_POINTER = 3,
    INVALID_FLAG = 4,
    INVALID_DEVINST = 5,
    INVALID_DEVNODE = 5,
    INVALID_RES_DES = 6,
    INVALID_LOG_CONF = 7,
    INVALID_ARBITRATOR = 8,
    INVALID_NODELIST = 9,
    DEVINST_HAS_REQS = 10, // 0x0000000A
    DEVNODE_HAS_REQS = 10, // 0x0000000A
    INVALID_RESOURCEID = 11, // 0x0000000B
    DLVXD_NOT_FOUND = 12, // 0x0000000C
    NO_SUCH_DEVINST = 13, // 0x0000000D
    NO_SUCH_DEVNODE = 13, // 0x0000000D
    NO_MORE_LOG_CONF = 14, // 0x0000000E
    NO_MORE_RES_DES = 15, // 0x0000000F
    ALREADY_SUCH_DEVINST = 16, // 0x00000010
    ALREADY_SUCH_DEVNODE = 16, // 0x00000010
    INVALID_RANGE_LIST = 17, // 0x00000011
    INVALID_RANGE = 18, // 0x00000012
    FAILURE = 19, // 0x00000013
    NO_SUCH_LOGICAL_DEV = 20, // 0x00000014
    CREATE_BLOCKED = 21, // 0x00000015
    NOT_SYSTEM_VM = 22, // 0x00000016
    REMOVE_VETOED = 23, // 0x00000017
    APM_VETOED = 24, // 0x00000018
    INVALID_LOAD_TYPE = 25, // 0x00000019
    BUFFER_SMALL = 26, // 0x0000001A
    NO_ARBITRATOR = 27, // 0x0000001B
    NO_REGISTRY_HANDLE = 28, // 0x0000001C
    REGISTRY_ERROR = 29, // 0x0000001D
    INVALID_DEVICE_ID = 30, // 0x0000001E
    INVALID_DATA = 31, // 0x0000001F
    INVALID_API = 32, // 0x00000020
    DEVLOADER_NOT_READY = 33, // 0x00000021
    NEED_RESTART = 34, // 0x00000022
    NO_MORE_HW_PROFILES = 35, // 0x00000023
    DEVICE_NOT_THERE = 36, // 0x00000024
    NO_SUCH_VALUE = 37, // 0x00000025
    WRONG_TYPE = 38, // 0x00000026
    INVALID_PRIORITY = 39, // 0x00000027
    NOT_DISABLEABLE = 40, // 0x00000028
    FREE_RESOURCES = 41, // 0x00000029
    QUERY_VETOED = 42, // 0x0000002A
    CANT_SHARE_IRQ = 43, // 0x0000002B
    NO_DEPENDENT = 44, // 0x0000002C
    SAME_RESOURCES = 45, // 0x0000002D
    NO_SUCH_REGISTRY_KEY = 46, // 0x0000002E
    INVALID_MACHINENAME = 47, // 0x0000002F
    REMOTE_COMM_FAILURE = 48, // 0x00000030
    MACHINE_UNAVAILABLE = 49, // 0x00000031
    NO_CM_SERVICES = 50, // 0x00000032
    ACCESS_DENIED = 51, // 0x00000033
    CALL_NOT_IMPLEMENTED = 52, // 0x00000034
    INVALID_PROPERTY = 53, // 0x00000035
    DEVICE_INTERFACE_ACTIVE = 54, // 0x00000036
    NO_SUCH_DEVICE_INTERFACE = 55, // 0x00000037
    INVALID_REFERENCE_STRING = 56, // 0x00000038
    INVALID_CONFLICT_LIST = 57, // 0x00000039
    INVALID_INDEX = 58, // 0x0000003A
    INVALID_STRUCTURE_SIZE = 59, // 0x0000003B
    NUM_CR_RESULTS = 60, // 0x0000003C
  }

  public enum DeviceInterfaceDataFlags : uint
  {
    Active = 1,
    Default = 2,
    Removed = 4,
  }

  [Flags]
  public enum DICFG
  {
    DEFAULT = 1,
    PRESENT = 2,
    ALLCLASSES = 4,
    PROFILE = 8,
    DEVICEINTERFACE = 16, // 0x00000010
  }

  public enum DICUSTOMDEVPROP
  {
    NONE,
    MERGE_MULTISZ,
  }

  [Flags]
  public enum DevKeyType
  {
    DEV = 1,
    DRV = 2,
    BOTH = 4,
  }

  public struct DEVICE_INTERFACE_DETAIL_HANDLE
  {
    private IntPtr mPtr;

    internal DEVICE_INTERFACE_DETAIL_HANDLE(IntPtr ptrInit) => this.mPtr = ptrInit;
  }

  public class DeviceInterfaceDetailHelper
  {
    public static readonly int SIZE = SetupApi.Is64Bit ? 8 : 6;
    private IntPtr mpDevicePath;
    private IntPtr mpStructure;

    public DeviceInterfaceDetailHelper(int maximumLength)
    {
      this.mpStructure = Marshal.AllocHGlobal(maximumLength);
      this.mpDevicePath = new IntPtr(this.mpStructure.ToInt64() + (long) Marshal.SizeOf(typeof (int)));
    }

    public SetupApi.DEVICE_INTERFACE_DETAIL_HANDLE Handle
    {
      get
      {
        Marshal.WriteInt32(this.mpStructure, SetupApi.DeviceInterfaceDetailHelper.SIZE);
        return new SetupApi.DEVICE_INTERFACE_DETAIL_HANDLE(this.mpStructure);
      }
    }

    public string DevicePath => Marshal.PtrToStringAuto(this.mpDevicePath);

    public void Free()
    {
      if (this.mpStructure != IntPtr.Zero)
        Marshal.FreeHGlobal(this.mpStructure);
      this.mpDevicePath = IntPtr.Zero;
      this.mpStructure = IntPtr.Zero;
    }

    ~DeviceInterfaceDetailHelper() => this.Free();
  }

  private class MaxStructSizes
  {
    public const int SP_DEVINFO_DATA = 40;
  }

  public struct SP_DEVICE_INTERFACE_DATA
  {
    public static readonly SetupApi.SP_DEVICE_INTERFACE_DATA Empty = new SetupApi.SP_DEVICE_INTERFACE_DATA(Marshal.SizeOf(typeof (SetupApi.SP_DEVICE_INTERFACE_DATA)));
    public uint cbSize;
    public Guid interfaceClassGuid;
    public uint flags;
    private UIntPtr reserved;

    private SP_DEVICE_INTERFACE_DATA(int size)
    {
      this.cbSize = (uint) size;
      this.reserved = UIntPtr.Zero;
      this.flags = 0U;
      this.interfaceClassGuid = Guid.Empty;
    }
  }

  public struct SP_DEVINFO_DATA
  {
    public static readonly SetupApi.SP_DEVINFO_DATA Empty = new SetupApi.SP_DEVINFO_DATA(Marshal.SizeOf(typeof (SetupApi.SP_DEVINFO_DATA)));
    public uint cbSize;
    public Guid ClassGuid;
    public uint DevInst;
    public IntPtr Reserved;

    private SP_DEVINFO_DATA(int size)
    {
      this.cbSize = (uint) size;
      this.ClassGuid = Guid.Empty;
      this.DevInst = 0U;
      this.Reserved = IntPtr.Zero;
    }
  }
}
