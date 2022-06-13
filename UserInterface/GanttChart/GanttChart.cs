using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace UserInterface.GanttChart
{
  public partial class GanttChart : UserControl
  {

    #region LocalVariable
    private List<Performer> _performerList;
    private DateTime _startDate;
    private DateTime _finishDate;
    private float _zoom = 1;
    private float _verticalBetweenSpace = 50;
    private float _horizantalBetweenSpace = 50;
    private float _verticalStartSpace = 20;
    private float _horizantalStartSpace = 20;
    private bool _controlKeyDown = false;
    #endregion

    #region Properties
    public int BarsHeight { get; set; } = 20;
    #endregion

    #region CTOR
    public GanttChart()
    {
      SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
      _performerList = new List<Performer>();
      InitializeComponent();
      InitEvents();

    }
    #endregion

    #region Events
    private void InitEvents()
    {
      Resize += (object sender, EventArgs e) => { Invalidate(); };
      Paint += GanttChart_Paint;
      MouseWheel += (object sender, MouseEventArgs e) => { MouseWheels(e.Delta); };
      KeyDown += (object sender, KeyEventArgs e) => { _controlKeyDown = e.Control; };
      KeyUp += (object sender, KeyEventArgs e) => { _controlKeyDown = false; };
      horzScrollBar.ValueChanged += (object sender, EventArgs e) => { Invalidate(); };
      verScrollBar.ValueChanged += (object sender, EventArgs e) => { Invalidate(); };

    }

    private void GanttChart_Paint(object sender, PaintEventArgs e)
    {
      
      CalculateMaxMinDates(_performerList, ref _startDate, ref _finishDate);
      float datelabelRecHeight = CalculateDateHeight(e.Graphics, Font, DateTime.Now.ToString("dd.MM.yyyy hh:mm")) + 2 * _verticalStartSpace;
      float performerNameMaxWidth = CalculatePerformerNameMaxWidth(e.Graphics, Font, _performerList) + 2 * _horizantalStartSpace;
      PointF DatesLabelsStartPoint = new PointF(performerNameMaxWidth - horzScrollBar.Value, _verticalStartSpace);
      PointF PerformerNamesStartPoint = new PointF(_horizantalStartSpace, datelabelRecHeight - verScrollBar.Value);
      PointF BarsStartPoint = new PointF(performerNameMaxWidth - horzScrollBar.Value, datelabelRecHeight - verScrollBar.Value);
      string mtxt = _startDate.ToString("dd.MM.yyyy");
      SizeF stringSize = e.Graphics.MeasureString(mtxt, Font);
      CalculateScrollsMaxMin(stringSize);

      RectangleF recClipPerformerNames = new RectangleF(_horizantalStartSpace, datelabelRecHeight, performerNameMaxWidth, Height);
      RectangleF recClipDatesLabels = new RectangleF(performerNameMaxWidth - stringSize.Width / 2, _verticalStartSpace, Width, Height);
      RectangleF recClipBar = new RectangleF(performerNameMaxWidth, datelabelRecHeight, (float)(_finishDate - _startDate).TotalHours, Height);

      RectangleF recClipLine = new RectangleF(performerNameMaxWidth, datelabelRecHeight, (float)(_finishDate - _startDate).TotalHours + 1, Height);
      e.Graphics.Clip = new Region(recClipPerformerNames);
      DrawPerformerNames(e.Graphics, _performerList.Select(pr => pr.Name).ToList(), PerformerNamesStartPoint, _horizantalBetweenSpace);

      DrawDatesLabels(e.Graphics, _startDate, _finishDate, "dd.MM.yyyy", DatesLabelsStartPoint, recClipDatesLabels, recClipLine, Height, ForeColor);



      e.Graphics.Clip = new Region(recClipBar);
      DrawJobsBar(e.Graphics, _performerList, _startDate, _verticalBetweenSpace, BarsStartPoint, BarsHeight);


    }

    private void Performer_JobListChanged(Performer performer)
    {
      CalculateMaxMinDates(_performerList, ref _startDate, ref _finishDate);
      Invalidate();
    }

    #endregion

    #region Private Functions

    private void CalculateScrollsMaxMin(SizeF stringSize)
    {
      //horzScrollBar.Minimum = verScrollBar.Minimum = 0;
      int verScrollMax = (_performerList.Count + 3) * 50 - Height;
      int horScroolMax = (int)(_finishDate - _startDate).TotalHours - Width + 3 * (int)stringSize.Width;
      if (verScrollMax < 0)
        verScrollMax = 0;
      if (horScroolMax < 0)
        horScroolMax = 0;
      verScrollBar.Maximum = verScrollMax;
      horzScrollBar.Maximum = horScroolMax;
    }

    private void MouseWheels(int wheelDelta)
    {
      int delta = Math.Abs(wheelDelta);
      if (!_controlKeyDown)
      {
        if (wheelDelta > 0)
        {
          if ((verScrollBar.Value - delta) > verScrollBar.Minimum)
            verScrollBar.Value -= delta;
          else
            verScrollBar.Value = verScrollBar.Minimum;
        }
        else
        {
          if ((verScrollBar.Value + delta) <= verScrollBar.Maximum)
            verScrollBar.Value += delta;
          else
            verScrollBar.Value = verScrollBar.Maximum;
        }
      }
      Invalidate();
    }

    private float CalculatePerformerNameMaxWidth(Graphics graphics, Font font, List<Performer> performerList)
    {
      float maxWidth = 0;
      foreach (Performer performer in performerList)
      {
        if (maxWidth < graphics.MeasureString(performer.Name, font).Width)
          maxWidth = graphics.MeasureString(performer.Name, font).Width;
      }
      return maxWidth;
    }

    private float CalculateDateHeight(Graphics graphics, Font font, string exampleString)
    {
      return graphics.MeasureString(exampleString, font).Height;
    }

    private void DrawJobsBar(Graphics graphics, List<Performer> performers, DateTime startDate, float verticalSpace, PointF startPoint, int barsHeight)
    {
      float yloc = 0;
      int i = 0;

      SolidBrush brs = new SolidBrush(Color.AliceBlue);
      foreach (Performer perf in performers)
      {
        yloc = i * verticalSpace;
        foreach (Job jb in perf.JobList())
        {
          brs.Color = perf.BarColor;
          RectangleF recf = new RectangleF((float)(jb.StartDate - startDate).TotalHours, yloc, (float)(jb.Duration).TotalHours, barsHeight);
          recf.Offset(startPoint);
          graphics.FillRectangle(brs, recf);
        }
        i++;
      }
      brs.Dispose();
    }

    private void DrawDatesLabels(Graphics graphics, DateTime startDate, DateTime endDate, string dateTimeFormat, PointF startPoint, RectangleF LabelRecF, RectangleF lineRecF, int maxDrawAreaHeight, Color color)
    {
      string mtxt = startDate.ToString(dateTimeFormat);
      SizeF stringSize = graphics.MeasureString(mtxt, Font);
      double timeSpan = (endDate - startDate).TotalHours;
      int dateLabelCount = (int)(timeSpan / (stringSize.Width + 10));
      if (dateLabelCount < 2)
        dateLabelCount = 2;
      SolidBrush brs = new SolidBrush(color);
      Pen pen = new Pen(brs);
      float xloc = 0;

      if (timeSpan > 0)
      {
        for (int i = 0; i < dateLabelCount; i++)
        {

          mtxt = (startDate + TimeSpan.FromHours(i * timeSpan / (dateLabelCount - 1))).ToString(dateTimeFormat);
          stringSize = graphics.MeasureString(mtxt, Font);
          xloc = startPoint.X - stringSize.Width / 2 + i * (float)timeSpan / (dateLabelCount - 1);
          graphics.Clip = new Region(LabelRecF);
          graphics.DrawString(mtxt, Font, brs, xloc, startPoint.Y);
          graphics.Clip = new Region(lineRecF);
          graphics.DrawLine(pen, xloc + stringSize.Width / 2, startPoint.Y + stringSize.Height, xloc + stringSize.Width / 2, maxDrawAreaHeight);
        }
      }
      brs.Dispose();
      pen.Dispose();
    }

    private void DrawPerformerNames(Graphics graphics, List<string> names, PointF startPoint, float betweenSpace)
    {
      if (names != null)
      {
        SolidBrush brs = new SolidBrush(ForeColor);
        float yloc = 0;
        for (int i = 0; i < names.Count; i++)
        {
          yloc = i * betweenSpace + startPoint.Y;
          graphics.DrawString(names[i], Font, brs, startPoint.X, yloc);
        }
        brs.Dispose();
      }
    }

    private bool CalculateMaxMinDates(List<Performer> performers, ref DateTime minDate, ref DateTime maxDate)
    {
      maxDate = DateTime.MinValue;
      minDate = DateTime.MaxValue;
      foreach (Performer perf in performers)
      {
        foreach (Job job in perf.JobList())
        {
          if (job.StartDate < _startDate)
            minDate = job.StartDate;
          if (job.FinishDate > _finishDate)
            maxDate = job.FinishDate;
        }
      }
      return !(maxDate == DateTime.MinValue && minDate == DateTime.MaxValue);
    }

    #endregion

    #region Public Functions
    public void AddPerformers(List<Performer> performerList)
    {
      foreach (Performer performer in performerList)
      {
        _performerList.Add(performer);
        performer.JobListChanged += Performer_JobListChanged;
      }
      Invalidate();
    }

    public void AddPerformer(Performer performer)
    {
      _performerList.Add(performer);
      performer.JobListChanged += Performer_JobListChanged;
      Invalidate();
    }

    public void RemovePerformer(Performer performer)
    {
      _performerList.Remove(performer);
      performer.JobListChanged -= Performer_JobListChanged;
      Invalidate();
    }

    public void ClearPerformers()
    {
      foreach (Performer perf in _performerList)
        perf.JobListChanged -= Performer_JobListChanged;
      _performerList.Clear();
      Invalidate();
    }
    #endregion

  }
}