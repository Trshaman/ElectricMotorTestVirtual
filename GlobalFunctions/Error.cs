using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace GlobalFunctions
{
  public struct ErrorCodes
  {
    public const int NoError = 0;
    public const int SqlServerNotInstalled = 9;
    public const int SQLDataSourceNotFound = 11;
    public const int SqlServerNotWork = 12;
    public const int SqlServerConnectionFault = 13;
    public const int FaultyDatabase = 14; //for all database(system,log,record)
    public const int FolderNotFound = 16;
    public const int DeviceNotConnected = 20;

  }

  /// <summary>
  /// Bu sınıf hataların özelliklerini tutar.
  /// </summary>
  public enum ErrorActions
  { 
    DoNothing,Stop,EmergencyStop,User
  }
  public class Error
  {
    public int ID{ get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ErrorActions ErrorAction { get; set; }
    public string Language { get; set; }
    public Error(int Id, string name, string description, string language,ErrorActions errAction)
    {
      ID = Id;
      Name = name;
      Description = description;
      Language = language;
      ErrorAction = errAction;
    }
  }
}
