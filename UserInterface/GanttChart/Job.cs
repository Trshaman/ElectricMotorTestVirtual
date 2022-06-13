using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.GanttChart
{
  public class Job
  {

    public string Name { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime FinishDate { get; set; }

    public TimeSpan Duration
    {
      get
      {
        return FinishDate - StartDate;
      }
    }
    
  }
}
