// Decompiled with JetBrains decompiler
// Type: YuneecLinkNet.YuneecLogFileTransport
// Assembly: YuneecLINK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CFB54D17-6788-4CFB-B24E-B7975B945505
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\YuneecLINK.dll

using System.IO;

#nullable disable
namespace YuneecLinkNet;

public class YuneecLogFileTransport : YuneecGenericTransport
{
  private string mLogFileName;

  public YuneecLogFileTransport(string logFileName) => this.mLogFileName = logFileName;

  public override void Initialize() => this.Parse();

  public override void Dispose()
  {
  }

  public override void SendMessage(UasMessage msg)
  {
  }

  private void Parse()
  {
    try
    {
      using (FileStream input = new FileStream(this.mLogFileName, FileMode.Open))
      {
        using (BinaryReader s = new BinaryReader((Stream) input))
        {
          while (true)
          {
            YuneecLinkPacket e;
            do
            {
              this.SyncStream(s);
              e = YuneecLinkPacket.Deserialize(s, (byte) 0);
            }
            while (!e.IsValid);
            this.HandlePacketReceived((object) this, e);
          }
        }
      }
    }
    catch (EndOfStreamException ex)
    {
    }
    this.HandleReceptionEnded((object) this);
  }

  private void SyncStream(BinaryReader s)
  {
    do
      ;
    while (s.ReadByte() != (byte) 254);
  }
}
