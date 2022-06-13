using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalFunctions
{
  public enum LogTypes
  {
    System, Alarm
  }
  public class Log
  {
    /// <summary>
    /// Log date and time
    /// </summary>
    public DateTime LogDateTime { get; set; }
    /// <summary>
    /// Log Description
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Log Icon
    /// </summary>
    public Icon LogIcon { get; set; }
    /// <summary>
    /// Log or error code
    /// </summary>
    public int Code { get; set; }
    /// <summary>
    /// Type of log 
    /// </summary>

    public int TestId { get; set; }

    public int StepId { get; set; }

    public LogTypes Type { get; set; }

    public Log(DateTime dateTime, LogTypes type, int code, int testId, int stepId, string description, Icon logIcon)
    {
      Type = type;
      LogDateTime = dateTime;
      Description = description;
      Code = code;
      TestId = testId;
      StepId = stepId;
      LogIcon = logIcon;
    }

    public Log(LogTypes type, int code, string description)
    {
      Type = type;
      Description = description;
      Code = code;
    }
  }
}
