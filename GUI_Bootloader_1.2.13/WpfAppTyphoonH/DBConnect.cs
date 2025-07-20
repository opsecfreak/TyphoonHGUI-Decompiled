// Decompiled with JetBrains decompiler
// Type: WpfAppTyphoonH.DBConnect
// Assembly: WpfAppTyphoonH, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: 3524D12E-4BA5-4A95-813C-BA8CEFA4F2FA
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\WpfAppTyphoonH.exe

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Windows;

#nullable disable
namespace WpfAppTyphoonH;

public class DBConnect
{
  private MySqlConnection connection;

  public void Initialize(string SqlConnectionString)
  {
    this.connection = new MySqlConnection(SqlConnectionString);
  }

  public bool OpenConnection()
  {
    try
    {
      ((DbConnection) this.connection).Open();
      return true;
    }
    catch (MySqlException ex)
    {
      switch (ex.Number)
      {
        case 0:
          int num1 = (int) MessageBox.Show("Cannot connect to server.  Contact administrator");
          break;
        case 1045:
          int num2 = (int) MessageBox.Show("Invalid username/password, please try again");
          break;
      }
      return false;
    }
  }

  public bool CloseConnection()
  {
    try
    {
      ((DbConnection) this.connection).Close();
      return true;
    }
    catch (MySqlException ex)
    {
      int num = (int) MessageBox.Show(((Exception) ex).Message);
      return false;
    }
  }

  public DataTable GetSchema(string str, string[] restri)
  {
    return ((DbConnection) this.connection).GetSchema(str, restri);
  }

  public DataTable GetSchema(string str) => ((DbConnection) this.connection).GetSchema(str);

  public void Insert(string q)
  {
    string str = q;
    if (!this.OpenConnection())
      return;
    ((DbCommand) new MySqlCommand(str, this.connection)).ExecuteNonQuery();
    this.CloseConnection();
  }

  public void Update(string q)
  {
    string str = q;
    if (!this.OpenConnection())
      return;
    MySqlCommand mySqlCommand = new MySqlCommand();
    ((DbCommand) mySqlCommand).CommandText = str;
    mySqlCommand.Connection = this.connection;
    ((DbCommand) mySqlCommand).ExecuteNonQuery();
    this.CloseConnection();
  }

  public void Delete()
  {
    string str = "DELETE FROM tableinfo WHERE name='John Smith'";
    if (!this.OpenConnection())
      return;
    ((DbCommand) new MySqlCommand(str, this.connection)).ExecuteNonQuery();
    this.CloseConnection();
  }

  public List<string>[] SelectCount()
  {
    string str = "SELECT * FROM tableinfo";
    List<string>[] stringListArray = new List<string>[3]
    {
      new List<string>(),
      new List<string>(),
      new List<string>()
    };
    if (!this.OpenConnection())
      return stringListArray;
    MySqlDataReader mySqlDataReader = new MySqlCommand(str, this.connection).ExecuteReader();
    while (((DbDataReader) mySqlDataReader).Read())
    {
      stringListArray[0].Add(string.Concat(((DbDataReader) mySqlDataReader)["id"]));
      stringListArray[1].Add(string.Concat(((DbDataReader) mySqlDataReader)["name"]));
      stringListArray[2].Add(string.Concat(((DbDataReader) mySqlDataReader)["age"]));
    }
    ((DbDataReader) mySqlDataReader).Close();
    this.CloseConnection();
    return stringListArray;
  }

  public int Count(string q)
  {
    string str = q;
    int num1 = -1;
    if (!this.OpenConnection())
      return num1;
    int num2 = int.Parse(string.Concat(((DbCommand) new MySqlCommand(str, this.connection)).ExecuteScalar()));
    this.CloseConnection();
    return num2;
  }

  public void ExecuteSQLFile(string fileName)
  {
    MySqlCommand mySqlCommand = new MySqlCommand(File.ReadAllText(fileName, Encoding.UTF8));
    mySqlCommand.Connection = this.connection;
    if (!this.OpenConnection())
      return;
    ((DbCommand) mySqlCommand).ExecuteNonQuery();
    this.CloseConnection();
  }
}
