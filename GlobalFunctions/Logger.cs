using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalFunctions
{

  /// <summary>
  /// To use record log database or text file.
  /// </summary>
  public static class Logger
  {

    private static SqlConnection _connection;
    private static SqlCommand _command;
    private static string _connectionString;
    private static StreamWriter _textWriter;
    private static string _logFileName;
    /// <summary>
    /// When set the property immadiatly connection open.
    /// </summary>
    public static string ConnectionString
    {
      get { return _connectionString; }
      set
      {
        _connectionString = value;
        _connection.Close();
        _connection.ConnectionString = value;
        _connection.Open();
        _command.Connection = _connection;
      }
    }
    /// <summary>
    /// Set with Path
    /// </summary>
    public static string LogFileName
    {
      get { return _logFileName; }
      set
      {
        _textWriter = File.AppendText(value);
        FileInfo finfo = new FileInfo(value);
        if (finfo.Length == 0)
          _textWriter.WriteLine("Date\tTime\tCode\tDescription");

        _logFileName = value;
      }
    }

    static Logger()
    {
      _connection = new SqlConnection();
      _command = new SqlCommand();
      _command.Connection = _connection;

      //_textWriter = new StreamWriter();
    }

    public static void Dispose()
    {

      _command.Dispose();
      if (_textWriter != null)
        _textWriter.Dispose();
      _connection.Close();
      _connection.Dispose();

    }


    public static List<string> GetSystemLog(int testId, int stepId)
    {
      List<string> retList = new List<string>();
      _command.Parameters.Clear();
      _command.CommandTimeout = 1;
      _command.CommandText = @"SELECT * FROM SystemLog WHERE TestId = " + testId + " And StepId=" + stepId + " ORDER BY Date, Time";
      SqlDataReader rd = _command.ExecuteReader();
      while (rd.Read())
      {
        string str = DateTime.Parse(rd["Date"].ToString()).ToString("dd.MM.yyyy");
        string str1 = DateTime.Parse(rd["Time"].ToString()).ToString("hh.mm.ss");
        retList.Add(str + " " + str1 + " " + rd["Decription"].ToString());
      }
      rd.Close();
      return retList;
    }



    //TODO: Burada hata oluşuyor. Muhtemelen _command açılmadan yazılmaya çalışıldığı için çöz.




    public static Exception WriteLogToDatabase(Log log)
    {
      return WriteLogToDatabase(log.Type, log.Code, log.TestId, log.StepId, log.Description);
    }

    public static Exception WriteLogToDatabase(LogTypes type, int code, int testId, int stepId, string description)
    {
      try
      {
        _command.Parameters.Clear();
        _command.CommandTimeout = 1;
        if (type == LogTypes.Alarm)
          _command.CommandText = @"INSERT INTO AlarmLog (Date,Time,Type,Code,TestId,StepId,Decription) values (@Date,@Time,@Type,@Code,@TestId,@StepId,@Decription)";
        else if (type == LogTypes.System)
          _command.CommandText = @"INSERT INTO SystemLog (Date,Time,Type,Code,TestId,StepId,Decription) values (@Date,@Time,@Type,@Code,@TestId,@StepId,@Decription)";
        _command.Parameters.AddWithValue("@Date", DateTime.Now);
        _command.Parameters.AddWithValue("@Time", DateTime.Now.TimeOfDay);
        _command.Parameters.AddWithValue("@Type", type);
        _command.Parameters.AddWithValue("@Code", code);
        _command.Parameters.AddWithValue("@TestId", testId);
        _command.Parameters.AddWithValue("@StepId", stepId);
        _command.Parameters.AddWithValue("@Decription", description);
        _command.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        return ex;
      }
      return null;
    }
    /// <summary>
    /// Before use must be set LogFileName. For write some log to text file.
    ///  If description empty log is not writing
    /// </summary>
    /// <param name="code">Error or log code</param>
    /// <param name="description">Error or  log description. If string has new line character ("\r\n") it will be removed. If description empty log is not writing</param>
    /// <returns></returns>
    public static Exception WriteLogToTextFile(int code, string description)
    {
      try
      {
        if (description != string.Empty && description != null)
          _textWriter.WriteLine(DateTime.Now.ToShortDateString().ToString() + "\t" + DateTime.Now.TimeOfDay.ToString() + "\t" + code.ToString() + "\t" + description.Replace("\r\n", ""));
      }
      catch (Exception ex)
      {
        return ex;
      }
      return null;
    }
  }
}
