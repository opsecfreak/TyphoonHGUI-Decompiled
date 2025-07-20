// Decompiled with JetBrains decompiler
// Type: Wpfbootload.WriteLog
// Assembly: Wpfbootload, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4FEF84E1-06E0-4569-8BB0-07C571E890DC
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\Wpfbootload.exe

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

#nullable disable
namespace Wpfbootload;

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
