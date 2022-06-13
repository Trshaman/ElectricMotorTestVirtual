using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.GanttChart
{
  public class Performer
  {
    public delegate void JobListChangedHandler(Performer performer);

    public event JobListChangedHandler JobListChanged;

    private List<Job> _jobList;

    public string Name { get; set; }

    public Color BarColor { get; set; } = Color.Red;

    public Performer()
    {
      _jobList = new List<Job>();
    }

    public void AddJob(Job job)
    {
      _jobList.Add(job);
      JobListChanged?.Invoke(this);
    }

    public void RemoveJob(Job job)
    {
      _jobList.Remove(job);
      JobListChanged?.Invoke(this);
    }

    public void ClearJobs()
    {
      _jobList.Clear();
      JobListChanged?.Invoke(this);
    }

    internal List<Job> JobList()
    {
      return _jobList;
    }
  }
}
