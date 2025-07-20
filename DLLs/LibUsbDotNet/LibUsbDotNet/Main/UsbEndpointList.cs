// Decompiled with JetBrains decompiler
// Type: LibUsbDotNet.Main.UsbEndpointList
// Assembly: LibUsbDotNet, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: 6A4CA9D6-D64A-4BFF-AAD0-F8E207CCD1F7
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\LibUsbDotNet.dll

using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace LibUsbDotNet.Main;

public class UsbEndpointList : IEnumerable<UsbEndpointBase>, IEnumerable
{
  private readonly List<UsbEndpointBase> mEpList = new List<UsbEndpointBase>();

  internal UsbEndpointList()
  {
  }

  public UsbEndpointBase this[int index] => this.mEpList[index];

  public int Count => this.mEpList.Count;

  public IEnumerator<UsbEndpointBase> GetEnumerator()
  {
    return (IEnumerator<UsbEndpointBase>) this.mEpList.GetEnumerator();
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.mEpList.GetEnumerator();

  public void Clear()
  {
    while (this.mEpList.Count > 0)
      this.Remove(this.mEpList[0]);
  }

  public bool Contains(UsbEndpointBase item) => this.mEpList.Contains(item);

  public int IndexOf(UsbEndpointBase item) => this.mEpList.IndexOf(item);

  public void Remove(UsbEndpointBase item) => item.Dispose();

  public void RemoveAt(int index) => this.Remove(this.mEpList[index]);

  internal UsbEndpointBase Add(UsbEndpointBase item)
  {
    foreach (UsbEndpointBase mEp in this.mEpList)
    {
      if ((int) mEp.EpNum == (int) item.EpNum)
        return mEp;
    }
    this.mEpList.Add(item);
    return item;
  }

  internal bool RemoveFromList(UsbEndpointBase item) => this.mEpList.Remove(item);
}
