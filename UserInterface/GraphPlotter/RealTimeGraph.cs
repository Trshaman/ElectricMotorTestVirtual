using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using Timer = System.Threading.Timer;
using GlobalFunctions;
using System.Threading;
using System.Text;

namespace UserInterface.GraphPlotter
{

  /// <summary>
  /// To draw curve, only for 4 curve
  /// </summary>
  [ToolboxItem(true)]
  public partial class RealTimeGraph : GraphBase
  {

    #region LocalVariable
    private Timer _graphRefreshTimer;
    private List<string> _channelName;
    private TextBox _setTextBox;
    private List<AxisValueEdit> _axesEditValues;
    private List<Curve> _curves = new List<Curve>();
    private Point _startLocation;
    #endregion

    #region Properties

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public List<Curve> Curves
    {
      get { return _curves; }
      set { _curves = value; }
    }


    public override int BufferSize
    {
      get
      {
        return base.BufferSize;
      }
      set
      {
        base.BufferSize = value;
        foreach (Curve crv in Curves)
          crv.BufferSize = base.BufferSize;
      }
    }

    [Category("Graph Options")]
    public int CurveCount
    {
      get { return Curves.Count; }
    }

    public bool ShowAxisAsSecond { get; set; }

    /// <summary>
    /// channels for draw curves
    /// </summary>
    [Category("AnalogBase"), Editor(typeof(CurveEditor), typeof(UITypeEditor))]
    public new List<string> ChannelName
    {
      get
      {
        CurveEditor.EditedGraph = this;
        CurveEditor.ChannelList = ChannelList;
        return _channelName;
      }
      set
      {
        if (_channelName != null)
        {
          foreach (string str in _channelName)
            OnChannelChanged(this, str, null);
        }
        if (value != null)
        {
          foreach (string str in value)
            OnChannelChanged(this, null, str);
        }
        _channelName = value;
      }
    }

    #endregion

    #region Ctor

    public RealTimeGraph()
    {
      InitializeComponent();
      Curves = new List<Curve>();
      _axesEditValues = new List<AxisValueEdit>();
      _graphRefreshTimer = new Timer(graphRefreshTimerCallBack);
      _graphRefreshTimer.Change(0, 50);
      InitEvents();
    }

    private void InitEvents()
    {
      MouseClick += RealTimeGraph_MouseClick;
      MouseDoubleClick += RealTimeGraph_MouseDoubleClick;
      MouseMove += RealTimeGraph_MouseMove;
      Disposed += RealTimeGraph_Disposed;
      MouseDown += (object sender, MouseEventArgs e) => { if (e.Button == MouseButtons.Left) _startLocation = e.Location; };

      tstrpTxtBoxSetXDivision.KeyPress += tstrpTxtBoxSetXDivision_KeyPress;
      contextMenuStrip1.Opened += contextMenuStrip1_Opened;
      tstrpPause.CheckedChanged += tstrpPause_CheckedChanged;
      tstrpCopyImage.Click += (object sender, EventArgs e) => { CopyGraphToClipboard(); };
      tstrbShowXAxisAsSecond.CheckedChanged += tstrbShowXAxisAsSecond_CheckedChanged;
    }



    #endregion

    #region Event
    private void tstrbShowXAxisAsSecond_CheckedChanged(object sender, EventArgs e)
    {
      ShowAxisAsSecond = tstrbShowXAxisAsSecond.Checked;
    }

    private void tstrpPause_CheckedChanged(object sender, EventArgs e)
    {
      PauseGraph = tstrpPause.Checked;
    }

    private void RealTimeGraph_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
        ControlPaint.DrawReversibleFrame(new Rectangle(_startLocation, new Size(e.X - _startLocation.X, e.Y - _startLocation.Y)), Color.Black, FrameStyle.Dashed);
      //SetToolTip(this, "", new Point(0, 0), false, _pointInfo);
      //foreach (Curve crv in Curves)
      //{
      //  if (crv.ScaledPlottedPoints.Count > 1)
      //  {

      //    Point pt = new Point(e.X, e.Y);
      //    try
      //    {
      //      List<PointF> tmplst = crv.ScaledPlottedPoints.ToList();
      //      tmplst.Add(pt);
      //      int indext = tmplst.OrderBy(p => p.X).ThenBy(p => p.Y).ToList().FindIndex(p => p == pt);
      //      if (indext != 0 && indext < tmplst.Count - 1)
      //      {
      //        PointF pt1 = tmplst[indext + 1];
      //        PointF pt2 = tmplst[indext - 1];
      //        float m = (pt2.Y - pt1.Y) / (pt2.X - pt1.X);
      //        float b = pt2.Y - m * pt2.X;
      //        int Ytmp = Convert.ToInt32(m * pt.X + b);
      //        if (pt.Y == Ytmp)
      //        {

      //          int index = crv.ScaledPlottedPoints.FindIndex(p => p == pt1);
      //          if (index != -1)
      //            SetToolTip(this, Xaxis.Name + ": " + crv.PlottedPoints[index].X.ToString("R", nfi) + "," + crv.Name + ": " + crv.PlottedPoints[index].Y.ToString("R", nfi), new Point(e.X + 10, e.Y - 20), true, _pointInfo);
      //          else
      //            SetToolTip(this, "", new Point(0, 0), false, _pointInfo);
      //        }
      //        else
      //          SetToolTip(this, "", new Point(0, 0), false, _pointInfo);
      //      }
      //    }
      //    catch { }
      //  }
      //}
    }

    private void graphRefreshTimerCallBack(object sender)
    {
      if (!DesignMode)
      {
        try
        {
          if (!this.IsDisposed)
          {
            if (this.InvokeRequired)
              this.Invoke(new MethodInvoker(this.Invalidate));
            //else
            //  this.Refresh();
          }
        }
        catch { };
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      DrawAll(e.Graphics);
    }

    private void RealTimeGraph_MouseClick(object sender, MouseEventArgs e)
    {
      if (_setTextBox != null) _setTextBox.Dispose();
      if (e.Button == MouseButtons.Right)
        contextMenuStrip1.Show(this, e.Location);
    }

    private void RealTimeGraph_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      AxisValueEdit axEdit = _axesEditValues.FindLast(ax => ax.LocationRectangle.Contains(e.Location));
      if (axEdit != null)
      {
        _setTextBox = new TextBox();
        _setTextBox.Size = new Size(2 * axEdit.LocationRectangle.Width, axEdit.LocationRectangle.Height);

        _setTextBox.Parent = this;
        switch (axEdit.EditValueType)
        {
          //case EditValueTypes.None:
          //  break;
          //case EditValueTypes.Xmin:

          //case EditValueTypes.Xmax:
          //  break;
          //case EditValueTypes.Y1min:
          //case EditValueTypes.Y1max:
          //case EditValueTypes.Y2min:
          //case EditValueTypes.Y2max:
          //  _setTextBox.Location = axEdit.LocationRectangle.Location;
          //  break;
          case EditValueTypes.Xmax:
          case EditValueTypes.Y3min:
          case EditValueTypes.Y3max:
          case EditValueTypes.Y4min:
          case EditValueTypes.Y4max:
            _setTextBox.Top = axEdit.LocationRectangle.Location.Y;
            _setTextBox.Left = axEdit.LocationRectangle.Location.X - axEdit.LocationRectangle.Width;
            break;
          default:
            _setTextBox.Location = axEdit.LocationRectangle.Location;
            break;
        }
        _setTextBox.TextAlign = HorizontalAlignment.Left;
        _setTextBox.KeyPress += _setTextBox_KeyPress;
        _setTextBox.Text = axEdit.EditedValue;
        _setTextBox.Tag = axEdit.EditValueType;
        _setTextBox.SelectAll();
        _setTextBox.Focus();
        _setTextBox.LostFocus += _setTextBox_LostFocus;
      }
    }

    private void contextMenuStrip1_Opened(object sender, EventArgs e)
    {
      tstrpTxtBoxSetXDivision.Text = Xaxis.Division.ToString("0.000");
      tstrbShowCurves.DropDownItems.Clear();
      tstrbShowXAxisAsSecond.Checked = ShowAxisAsSecond;
      foreach (Curve crv in Curves)
      {
        ToolStripMenuItem ts = new ToolStripMenuItem(crv.Name);
        ts.Click += (object snd1, EventArgs e1) => { Curves.FindLast(cr => cr.Name == ts.Text).ShowCurve = ts.Checked; };
        ts.CheckOnClick = true;
        ts.Checked = crv.ShowCurve;
        tstrbShowCurves.DropDownItems.Add(ts);
      }
    }

    private void tstrpTxtBoxSetXDivision_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == '\r')
      {
        if (Functions.ToDouble(tstrpTxtBoxSetXDivision.Text) != 0)
          Xaxis.Division = float.Parse(tstrpTxtBoxSetXDivision.Text);
        contextMenuStrip1.Close();
      }
      Functions.NumericFloatInput(ref e, '.');
    }

    private void _setTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == '\r') _setTextBox.Dispose();
      if (e.KeyChar == 27)
      {
        _setTextBox.Tag = EditValueTypes.None;
        _setTextBox.Dispose();
      }
      Functions.NumericFloatInput(ref e, '.');
    }

    private void _setTextBox_LostFocus(object sender, EventArgs e)
    {
      try
      {
        float val = float.Parse(_setTextBox.Text, nfi);
        EditValueTypes typ = (EditValueTypes)_setTextBox.Tag;
        if (typ == EditValueTypes.Xmin)
        {
          if (val < Xaxis.ReplacedMax) // _Xaxis.ReplacedMin must be small than _Xaxis.ReplacedMax 
            Xaxis.ReplacedMin = val;
        }
        else if (typ == EditValueTypes.Xmax)
        {
          if (val > Xaxis.ReplacedMin) // _Xaxis.ReplacedMax  must be bigger than _Xaxis.ReplacedMin
            Xaxis.ReplacedMax = val;
        }
        else if (typ == EditValueTypes.Y1max)
        {
          if (val != Curves[0].MinValueTemp)
            Curves[0].MaxValueTemp = val;
        }
        else if (typ == EditValueTypes.Y1min)
        {
          if (val != Curves[0].MaxValueTemp)
            Curves[0].MinValueTemp = val;
        }
        else if (typ == EditValueTypes.Y2max)
        {
          if (val != Curves[1].MinValueTemp)
            Curves[1].MaxValueTemp = val;
        }
        else if (typ == EditValueTypes.Y2min)
        {
          if (val != Curves[1].MaxValueTemp)
            Curves[1].MinValueTemp = val;
        }
        else if (typ == EditValueTypes.Y3max)
        {
          if (val != Curves[2].MinValueTemp)
            Curves[2].MaxValueTemp = val;
        }
        else if (typ == EditValueTypes.Y3min)
        {
          if (val != Curves[2].MaxValueTemp)
            Curves[2].MinValueTemp = val;
        }
        else if (typ == EditValueTypes.Y4max)
        {
          if (val != Curves[3].MinValueTemp)
            Curves[3].MaxValueTemp = val;
        }
        else if (typ == EditValueTypes.Y4min)
        {
          if (val != Curves[3].MaxValueTemp)
            Curves[3].MinValueTemp = val;
        }
      }
      catch { }
    }

    private void RealTimeGraph_Disposed(object sender, EventArgs e)
    {
      _graphRefreshTimer.Dispose();
    }

    private void SetToolTip(Control ctrl, string txt, Point pnt, bool shw, ToolTip tltp)
    {
      if (ctrl.InvokeRequired)
      {
        SetToolTipCallBack d = new SetToolTipCallBack(SetToolTip);
        try
        {
          this.Invoke(d, new object[] { ctrl, txt, pnt, shw, tltp });
        }
        catch { };
      }
      else
      {
        if (shw)
          tltp.Show(txt, ctrl, pnt);
        else
          tltp.Hide(ctrl);
      }
    }

    #endregion

    #region Subs
    internal override void DrawAll(Graphics graphics)
    {
      //Stopwatch tmr = new Stopwatch();
      //tmr.Start();
      base.DrawAll(graphics);
      
      DrawScaleLines(Drawrc, ScaleColor, ScaleLineWidth, graphics, Xaxis.TickCount, Tickwidth, Scalespace, Curves.Count);
      _axesEditValues.Clear();
      DrawXAxisValues(graphics, Xaxis.AxisColor, Drawrc, GraphFont, Xaxis.TickCount, Xaxis.Precision, Tickwidth + Scalespace, Xaxis.Name + (Xaxis.Unit == "" ? "" : " (" + Xaxis.Unit + ")"));
      DrawYAxisValues(graphics, Curves, Drawrc, GraphFont, Xaxis.TickCount, Tickwidth + Scalespace);
      foreach (Curve crv in Curves)
      {
        if (crv.ShowCurve)
        {
          DrawCurveValue(graphics, crv, GraphFont, Drawrc, nfi);
          DrawCurve(crv, graphics, Drawrc);
        }
      }
      //tmr.Stop();
      //base.DrawHeader(graphics, tmr.Elapsed.TotalMilliseconds.ToString() + " Points:" + Curves[0].Points.Length, HeaderFont, this.ClientRectangle, HeaderForeColor);
    }

    /// <summary>
    /// Draw Sacele lines
    /// </summary>
    /// <param name="rec"></param>
    /// <param name="clr"></param>
    /// <param name="linewidth"></param>
    /// <param name="grph"></param>
    /// <param name="grdcount"></param>
    /// <param name="tickwidth"></param>
    /// <param name="tickspace"></param>
    /// <param name="curvecount"></param>
    private void DrawScaleLines(Rectangle rec, Color clr, float linewidth, Graphics grph, int grdcount, int tickwidth, int tickspace, int curvecount)
    {
      Pen pn = new Pen(clr, linewidth);
      int startpt = tickwidth + tickspace;
      grph.DrawLine(pn, new Point(rec.Left - startpt, rec.Top), new Point(rec.Left - tickwidth, rec.Top));
      grph.DrawLine(pn, new Point(rec.Left - startpt, rec.Bottom), new Point(rec.Left - tickwidth, rec.Bottom));
      if (curvecount > 2)
      {
        grph.DrawLine(pn, new Point(rec.Right + tickwidth, rec.Top), new Point(rec.Right + startpt, rec.Top));
        grph.DrawLine(pn, new Point(rec.Right + tickwidth, rec.Bottom), new Point(rec.Right + startpt, rec.Bottom));
        grph.DrawLine(pn, new Point(rec.Right + tickwidth, rec.Top), new Point(rec.Right + tickwidth, rec.Bottom));
      }
      grph.DrawLine(pn, new Point(rec.Right, rec.Bottom + tickwidth), new Point(rec.Right, rec.Bottom + startpt));
      grph.DrawLine(pn, new Point(rec.Left - tickwidth, rec.Top), new Point(rec.Left - tickwidth, rec.Bottom));
      grph.DrawLine(pn, new Point(rec.Left, rec.Bottom + tickwidth), new Point(rec.Right, rec.Bottom + tickwidth));
      grph.DrawLine(pn, new Point(rec.Left, rec.Bottom + tickwidth), new Point(rec.Left, rec.Bottom + startpt));
      int xartis = Convert.ToInt32((float)rec.Width / (grdcount - 1));
      int yartis = Convert.ToInt32((float)rec.Height / (grdcount - 1));
      for (int i = 1; i < grdcount - 1; i++)
      {
        grph.DrawLine(pn, new Point(rec.Left - startpt, rec.Top + i * yartis), new Point(rec.Left - tickwidth, rec.Top + i * yartis));
        if (curvecount > 2)
          grph.DrawLine(pn, new Point(rec.Right + tickwidth, rec.Top + i * yartis), new Point(rec.Right + startpt, rec.Top + i * yartis));
        grph.DrawLine(pn, new Point(rec.Left + i * xartis, rec.Bottom + tickwidth), new Point(rec.Left + i * xartis, rec.Bottom + startpt));
      }
      pn.Dispose();
    }


    /// <summary>
    /// Draw Xaxis values with axisname and unit
    /// </summary>
    /// <param name="graphics"></param>
    /// <param name="color"></param>
    /// <param name="drawRectangle"></param>
    /// <param name="font"></param>
    /// <param name="tickCount"></param>
    /// <param name="precision"></param>
    /// <param name="tickSpace"></param>
    /// <param name="xAxisNameWithUnit"></param>
    private void DrawXAxisValues(Graphics graphics, Color color, Rectangle drawRectangle, Font font, int tickCount, int precision, int tickSpace, string xAxisNameWithUnit)
    {
      string mtxt;
      SizeF stringSize;
      float valueinc = (Xaxis.ReplacedMax - Xaxis.ReplacedMin) / (tickCount - 1);
      float xartis = (float)drawRectangle.Width / (tickCount - 1);
      SolidBrush brs = new SolidBrush(color);
      for (int i = 0; i < tickCount; i++)
      {
        if (ShowAxisAsSecond)
          mtxt = CommonFunction.FormatNumber((Xaxis.ReplacedMin + i * valueinc), precision, nfi);
        else
          mtxt = (new TimeSpan((long)(Xaxis.ReplacedMin + i * valueinc) * 10000000)).ToString();
        stringSize = graphics.MeasureString(mtxt, font);
        RectangleF drawRec = new RectangleF(drawRectangle.Left + i * xartis - stringSize.Width / 2, drawRectangle.Bottom + 2 * tickSpace, stringSize.Width, stringSize.Height);
        if (i == 0 || i == tickCount - 1)
          _axesEditValues.Add(new AxisValueEdit(Rectangle.Round(drawRec), mtxt, i == 0 ? EditValueTypes.Xmin : EditValueTypes.Xmax));
        graphics.DrawString(mtxt, font, brs, drawRec);
      }
      mtxt = CommonFunction.FormatNumber(valueinc, precision, nfi);
      StringBuilder stb = new StringBuilder();
      stb.Append(xAxisNameWithUnit); stb.Append("-Div:"); stb.Append(mtxt);
      stringSize = graphics.MeasureString(stb.ToString(), font);
      graphics.DrawString(stb.ToString(), font, brs, (this.Width - stringSize.Width) / 2, this.Height - 1.5F * stringSize.Height);
      brs.Dispose();
    }

    /// <summary>
    /// Draw Y Axis values
    /// </summary>
    /// <param name="graphics"></param>
    /// <param name="curves"></param>
    /// <param name="drawRectangle"></param>
    /// <param name="font"></param>
    /// <param name="tickCount"></param>
    /// <param name="tickSpace"></param>
    private void DrawYAxisValues(Graphics graphics, List<Curve> curves, Rectangle drawRectangle, Font font, int tickCount, int tickSpace)
    {

      foreach (Curve crv in curves)
      {
        string mtxt;
        SizeF stringSize;
        float valueinc = (crv.MaxValueTemp - crv.MinValueTemp) / (tickCount - 1);
        float yartis = (float)drawRectangle.Height / (tickCount - 1);
        using (SolidBrush brs = new SolidBrush(crv.CurveColor))
        {
          for (int i = 0; i < tickCount; i++)
          {
            RectangleF drawRec = RectangleF.Empty;
            mtxt = CommonFunction.FormatNumber((crv.MaxValueTemp - i * valueinc), crv.Precision, nfi);
            stringSize = graphics.MeasureString(mtxt, font);
            switch (crv.CurveNo)
            {
              case 0:
                drawRec = new RectangleF(drawRectangle.Left - tickSpace - stringSize.Width, drawRectangle.Top + i * yartis - stringSize.Height, stringSize.Width, stringSize.Height);
                break;
              case 1:
                drawRec = new RectangleF(drawRectangle.Left - tickSpace - stringSize.Width, drawRectangle.Top + i * yartis, stringSize.Width, stringSize.Height);
                break;
              case 2:
                drawRec = new RectangleF(drawRectangle.Right + tickSpace, drawRectangle.Top + i * yartis - stringSize.Height, stringSize.Width, stringSize.Height);
                break;
              case 3:
                drawRec = new RectangleF(drawRectangle.Right + tickSpace, drawRectangle.Top + i * yartis, stringSize.Width, stringSize.Height);
                break;
            }
            graphics.DrawString(mtxt, font, brs, drawRec);
            if (i == 0 || i == tickCount - 1)
              _axesEditValues.Add(new AxisValueEdit(Rectangle.Round(drawRec), mtxt, i == 0 ? EditValueTypes.Y1max + 2 * crv.CurveNo : EditValueTypes.Y1min + 2 * crv.CurveNo));
          }
          brs.Dispose();
        }
      }
    }

    /// <summary>
    /// Draw curve numeric value proper location
    /// </summary>
    /// <param name="graphics"></param>
    /// <param name="curve"></param>
    /// <param name="font"></param>
    /// <param name="drwrec"></param>
    /// <param name="nfi"></param>
    private void DrawCurveValue(Graphics graphics, Curve curve, Font font, Rectangle drwrec, NumberFormatInfo nfi)
    {
      StringBuilder stb = new StringBuilder();
      stb.Append(curve.Name); stb.Append(": "); stb.Append(CommonFunction.FormatNumber(curve.Value.Y, curve.Precision, nfi));
      stb.Append(" "); stb.Append(curve.Unit);
      string curveValue = stb.ToString();
      // string curveValue = "P: " + Curve.Points.Length + "-Xmin:" + _Xaxis.ReplacedMin;
      SizeF strSize = graphics.MeasureString(curveValue, font);
      RectangleF strRec = new RectangleF();

      strRec.Width = strSize.Width * 1.1f;
      strRec.Height = strSize.Height * 1.1f;
      switch (curve.CurveNo)
      {
        case 0:
          strRec.X = drwrec.Left;
          strRec.Y = drwrec.Top - 2 * strSize.Height;
          break;
        case 1:
          strRec.X = drwrec.Left;
          strRec.Y = drwrec.Top - strSize.Height;
          break;
        case 2:
          //strRec.X = (drwrec.Left + drwrec.Width) * 0.8F;
          strRec.X = drwrec.Right - strSize.Width;
          strRec.Y = drwrec.Top - 2 * strSize.Height;
          break;
        case 3:
          strRec.X = drwrec.Right - strSize.Width;
          strRec.Y = drwrec.Top - strSize.Height;
          break;
      }
      using (SolidBrush brs = new SolidBrush(curve.CurveColor))
        graphics.DrawString(curveValue, font, brs, strRec);

    }

    private void DrawCurve(Curve crv, Graphics graphics, Rectangle drawarea)
    {
      Pen pen = new Pen(crv.CurveColor);
      try
      {
        pen.Alignment = PenAlignment.Inset;
        if (crv.Points.Length > 1)
        {
          RectangleF recf = new RectangleF(Xaxis.ReplacedMin, crv.MaxValueTemp, Xaxis.ReplacedMax - Xaxis.ReplacedMin, -(crv.MaxValueTemp - crv.MinValueTemp));
          if (recf.Width != 0 && recf.Height != 0)
          {
            graphics.SetClip(drawarea, CombineMode.Intersect);
            PointF[] pnts = new PointF[] { new PointF(drawarea.Left, drawarea.Top), new PointF(drawarea.Right, drawarea.Top), new PointF(drawarea.Left, drawarea.Bottom - 0.5f) };
            graphics.Transform = new Matrix(recf, pnts);
            Matrix invMatrix = new Matrix(recf, pnts); //To proper width inverted matrix must be set to transform.
            invMatrix.Invert();
            pen.Transform = invMatrix;
            pen.Width = crv.Width;
            int lastIndex = 0, startIndex = 0;
            bool lastIndexFound = false, startIndexFound = false;
            for (int i = crv.LastIndex - 1; i >= 0; i--)
            {
              if (crv.Points[i].X < Xaxis.ReplacedMax && !lastIndexFound)
              {
                lastIndex = i;
                lastIndexFound = true;
              }
              if (crv.Points[i].X <= Xaxis.ReplacedMin && !startIndexFound && lastIndexFound)
              {
                startIndex = i;
                startIndexFound = true;
                break;
              }
            }
            PointF[] drawList = CommonFunction.LargestTriangleThreeBuckets(crv.Points, startIndex, lastIndex, ResamplingSize);
            if (drawList.Length > 1)
              graphics.DrawLines(pen, drawList);
           
          }
        }

      }
      catch (Exception ex) { }
      finally
      {
        graphics.ResetTransform();
        graphics.ResetClip();
        pen.Dispose();
      }
    }

    #endregion

    #region Public Subs



    public void AddPointRange(string curveName, PointF[] points)
    {
      Curve crv = Curves.Find(p => p.Name == curveName);
      if (crv != null && !PauseGraph)
      {
        crv.AddRange(points);
        crv.Value = points[points.Length - 1];
        if (Xaxis.ReplacedMax <= points[points.Length - 1].X)
        {
          Xaxis.ReplacedMax = points[points.Length - 1].X;// -  Xaxis.Division ;
          Xaxis.ReplacedMin = Xaxis.ReplacedMax - Xaxis.Division * (Xaxis.TickCount - 1);
        }
      }
    }

    /// <summary>
    /// Add point to Curve for only slow refresh rate other case use AddPointRange
    /// </summary>
    /// <param name="curveName"></param>
    /// <param name="Xval"></param>
    /// <param name="Yval"></param>
    /// <param name="markpoint"></param>
    public void AddPoint(string curveName, float Xval, float Yval, bool markpoint)
    {
      //Monitor.Enter(this);
      //try
      //{-
      Curve crv = Curves.Find(p => p.Name == curveName);
      if (crv != null && !PauseGraph)
      {
        crv.Value = new PointF(Xval, Yval);
        if (crv.LastIndex >= BufferSize)
        {
          PointF[] coppyArray = new PointF[BufferSize];
          Array.Copy(crv.Points, BufferSize / 5, coppyArray, 0, BufferSize - BufferSize / 5);
          crv.CurrentIndex = BufferSize - BufferSize / 5;
          crv.Points = coppyArray;
        }
        crv.Points[crv.CurrentIndex] = crv.Value;
        if (markpoint)
          crv.MarkPoints.Add(new PointF(Xval, Yval));
        if (Xaxis.ReplacedMax < Xval)
        {
          float temp = Xaxis.ReplacedMax - Xaxis.ReplacedMin;
          if (temp < Xval)
          {
            Xaxis.ReplacedMax += temp / (Xaxis.TickCount - 1);
            Xaxis.ReplacedMin += temp / (Xaxis.TickCount - 1);
          }
          else
          {
            Xaxis.ReplacedMax += Xval / (Xaxis.TickCount / 2);
            Xaxis.ReplacedMin = Xaxis.ReplacedMax - temp / (Xaxis.TickCount / 2);
          }

        }
      }
      //}
      //finally { Monitor.Exit(this); }
    }

    /// <summary>
    /// Return true if curve add successfully
    /// </summary>
    /// <param name="curvename"></param>
    /// <param name="maxval"></param>
    /// <param name="minval"></param>
    /// <param name="precision"></param>
    /// <param name="curvecolor"></param>
    /// <param name="unit"></param>
    /// <returns></returns>
    public bool AddCurve(string curvename, float maxval, float minval, int precision, Color curvecolor, string unit, int curveNo = -1)
    {
      if (Curves.Find(p => p.Name == curvename) == null)
      {
        Curve crv = new Curve(curvename, maxval, minval, precision, curvecolor, unit);
        Curves.Add(crv);
        crv.CurveChanged += (Curve curve) => { Invalidate(); };
        if (curveNo != -1 && curveNo <= 3 && curveNo >= 0)
        {
          crv.CurveNo = curveNo;
        }
        else
        {
          foreach (Curve cr in Curves)
            cr.CurveNo = Curves.IndexOf(cr);
        }
        return true;
      }
      else
        return false;
    }


    /// <summary>
    /// Delete Curve
    /// </summary>
    /// <param name="curvename"></param>
    public void RemoveCurve(string curvename, bool notRearrangeCurveNo = false)
    {
      Curve crv = Curves.Find(p => p.Name == curvename);
      if (crv != null)
        Curves.Remove(crv);
      if (!notRearrangeCurveNo)
      {
        foreach (Curve cr in Curves)
          cr.CurveNo = Curves.IndexOf(cr);
      }
    }

    /// <summary>
    /// Get Curve
    /// </summary>
    /// <param name="curvename"></param>
    /// <returns></returns>
    public Curve GetCurve(string curvename)
    {
      return Curves.Find(p => p.Name == curvename);
    }

    /// <summary>
    /// Clear all points of curves
    /// </summary>
    public override void Clear()
    {
      foreach (Curve crv in Curves)
        crv.Clear();
      Xaxis.ReplacedMax = Xaxis.Max;
      Xaxis.ReplacedMin = Xaxis.Min;
    }

    #endregion


  }
}