// Decompiled with JetBrains decompiler
// Type: WpfAppTyphoonH.WriteLog
// Assembly: WpfAppTyphoonH, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 3524D12E-4BA5-4A95-813C-BA8CEFA4F2FA
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\WpfAppTyphoonH.exe

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

#nullable disable
namespace WpfAppTyphoonH;

public class WriteLog
{
  public static void CreateLog(Exception ex)
  {
    string path1 = Application.StartupPath + "\\log";
    if (!Directory.Exists(path1))
      Directory.CreateDirectory(path1);
    string path2 = $"{path1}\\{DateTime.Now.ToString("yyyy-MM-dd")}.log";
    WriteLog.WriteLogInfo(ex, path2);
  }

  private static void WriteLogInfo(Exception ex, string path)
  {
    using (StreamWriter streamWriter = new StreamWriter(path, true, Encoding.Default))
    {
      streamWriter.WriteLine($"*****************************************【{DateTime.Now.ToLongTimeString()}】*****************************************");
      if (ex != null)
      {
        streamWriter.WriteLine("【ErrorType】" + (object) ex.GetType());
        streamWriter.WriteLine("【TargetSite】" + (object) ex.TargetSite);
        streamWriter.WriteLine("【Message】" + ex.Message);
        streamWriter.WriteLine("【Source】" + ex.Source);
        streamWriter.WriteLine("【StackTrace】" + ex.StackTrace);
      }
      else
        streamWriter.WriteLine("Exception is NULL");
      streamWriter.WriteLine();
    }
  }
}
