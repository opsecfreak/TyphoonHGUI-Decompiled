// Decompiled with JetBrains decompiler
// Type: YuneecLinkNet.UasSummary
// Assembly: YuneecLINK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CFB54D17-6788-4CFB-B24E-B7975B945505
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\YuneecLINK.dll

#nullable disable
namespace YuneecLinkNet;

public class UasSummary
{
  public static UasMessage CreateFromId(byte id)
  {
    switch (id)
    {
      case 16 /*0x10*/:
        return (UasMessage) new EscOK();
      case 17:
        return (UasMessage) new EscFAILED();
      case 33:
        return (UasMessage) new EscBLSync();
      case 35:
        return (UasMessage) new EscBLErase();
      case 39:
        return (UasMessage) new EscBLProgram();
      case 48 /*0x30*/:
        return (UasMessage) new EscBLReboot();
      default:
        return (UasMessage) null;
    }
  }
}
