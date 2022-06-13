using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Configuration;
using System.Drawing.Imaging;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Threading.Tasks;
using Timer = System.Threading.Timer;
using GlobalFunctions;
using System.Threading;

namespace UserInterface.GraphPlotter
{

  /// <summary>
  /// To draw curve, only for 4 curve
  /// </summary>
  [ToolboxItem(true)]
  public partial class XYGraph : GraphBase
  {
    public enum XYGraphTypes
    {
      Curve,
      Bar
    }
    public static List<XYGraph> XYGraphList { get; private set; }

    static XYGraph()
    {
      XYGraphList = new List<XYGraph>();
    }

    #region LocalVariable
    private Timer _graphRefreshTimer;
    //private List<string> _channelName;
    private TextBox _setTextBox;
    private List<AxisValueEdit> _axesEditValues;
    private Curve _curve;
    //private string _xChannel;
    //private string _yChannel;
    private bool _isRefreshRequired;
    private List<Curve> _curves = new List<Curve>();
    #endregion

    #region Properties

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public List<Curve> Curves
    {
      get { return _curves; }
      set { _curves = value; }
    }

    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Curve Curve
    {
      get { return _curve; }
      set { _curve = value; }
    }

    public Color LimitAreaColor { get; set; }

    /// <summary>
    /// Describe to limit area for drawing.
    /// </summary>
    public List<PointF> LimitAreaPoints { get; set; }

    public bool ShowLimitArea { get; set; }

    public XYGraphTypes XyGraphType { get; set; }

    #endregion

    #region Ctor

    public XYGraph()
    {
      InitializeComponent();
      LimitAreaPoints = new List<PointF>();
      _axesEditValues = new List<AxisValueEdit>();
      _graphRefreshTimer = new Timer(graphRefreshTimerCallBack);
      Curve = new Curve("Name", 100, 0, 0, Color.Black, "Unit");
      _graphRefreshTimer.Change(0, 50);

      InitEvents();
      XYGraphList.Add(this);

    }

    private void InitEvents()
    {
      this.MouseClick += GraphControl_MouseClick;
      this.MouseDoubleClick += RealTimeGraph_MouseDoubleClick;
      this.MouseMove += RealTimeGraph_MouseMove;
      this.Disposed += GraphControl_Disposed;
      tstrpTxtBoxSetXDivision.KeyPress += tstrpTxtBoxSetXDivision_KeyPress;
      contextMenuStrip1.Opened += contextMenuStrip1_Opened;
      tstrpPause.CheckedChanged += tstrpPause_CheckedChanged;
      tstrpClear.Click += (object sender, EventArgs e) => { Clear(); };
      tstrpCopyImage.Click += (object sender, EventArgs e) => { CopyGraphToClipboard(); };
      tstrpAutoRangeXAxis.CheckStateChanged += (object sender, EventArgs e) => { AutoXaxisRange = tstrpAutoRangeXAxis.Checked; };
      tstrpAutoRangeYAxis.CheckStateChanged += (object sender, EventArgs e) => { AutoYaxisRange = tstrpAutoRangeYAxis.Checked; };
    }

    #endregion

    #region Event
    private void tstrpPause_CheckedChanged(object sender, EventArgs e)
    {
      PauseGraph = tstrpPause.Checked;
    }

    private void RealTimeGraph_MouseMove(object sender, MouseEventArgs e)
    {
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
              this.Invoke(new MethodInvoker(this.Refresh));
            else
              this.Refresh();
            _isRefreshRequired = false;
          }
        }
        catch { };
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      DrawAll(e.Graphics);
    }

    private void GraphControl_MouseClick(object sender, MouseEventArgs e)
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
        _setTextBox.Location = axEdit.LocationRectangle.Location;
        _setTextBox.Parent = this;
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
      tstrpAutoRangeXAxis.Checked = AutoXaxisRange;
      tstrpAutoRangeYAxis.Checked = AutoYaxisRange;
    }

    private void tstrpTxtBoxSetXDivision_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == '\r')
      {
        if (Functions.ToDouble(tstrpTxtBoxSetXDivision.Text) != 0)
          Xaxis.Division = float.Parse(tstrpTxtBoxSetXDivision.Text);
        Xaxis.ReplacedMax = Xaxis.ReplacedMin + Xaxis.Division * (Xaxis.TickCount - 1);
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
      float val = float.Parse(_setTextBox.Text, nfi);
      EditValueTypes typ = (EditValueTypes)_setTextBox.Tag;
      if (typ == EditValueTypes.Xmin)
      {
        if (val < Xaxis.ReplacedMax) // Xaxis.ReplacedMin must be small than Xaxis.ReplacedMax 
          Xaxis.ReplacedMin = val;
      }
      else if (typ == EditValueTypes.Xmax)
      {
        if (val > Xaxis.ReplacedMin) // Xaxis.ReplacedMax  must be bigger than Xaxis.ReplacedMin
          Xaxis.ReplacedMax = val;
      }
      else if (typ == EditValueTypes.Y1max)
      {
        if (val != Curve.MaxValueTemp)
          Curve.MaxValueTemp = val;
      }
      else if (typ == EditValueTypes.Y1min)
      {
        if (val != Curve.MinValueTemp)
          Curve.MinValueTemp = val;
      }
      this.Invalidate();
    }

    private void GraphControl_Disposed(object sender, EventArgs e)
    {
      XYGraphList.Remove(this);
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

      //if (Curves.Count > 0)
      //{
      //  foreach (Curve crv in Curves)
      //  {
      //    if (crv.ShowCurve)
      //    {
      //      if (XyGraphType == XYGraphTypes.Curve)
      //        DrawCurve(crv, graphics, Drawrc);
      //      else
      //        DrawBar(crv, graphics, Drawrc);
      //    }
      //  }
      //}
      //else
      //{
      //  if (Curve.LastIndex > 2)
      //  {
      //    if (AutoYaxisRange)
      //    {
      //      Curve.MaxValueTemp = pnts.Select(crv => crv.Y).Max();
      //      Curve.MinValueTemp = pnts.Select(crv => crv.Y).Min();
      //    }
      //    if (AutoXaxisRange)
      //    {
      //      Xaxis.ReplacedMax = pnts.ToList().Select(crv => crv.X).Max();
      //      Xaxis.ReplacedMin = pnts.Select(crv => crv.X).Min();
      //    }
      //  }
      //}

      if (Curve.Points.Length > 2)
      {
        List<PointF> pnts = Curve.Points.ToList();
        if (pnts.Count > 2)
        {
          if (AutoYaxisRange)
          {
            Curve.MaxValueTemp = pnts.Select(crv => crv.Y).Max();
            Curve.MinValueTemp = pnts.Select(crv => crv.Y).Min();
          }
          if (AutoXaxisRange)
          {
            Xaxis.ReplacedMax = pnts.ToList().Select(crv => crv.X).Max();
            Xaxis.ReplacedMin = pnts.Select(crv => crv.X).Min();
          }
        }
      }
      base.DrawAll(graphics);

      DrawScaleLines(Drawrc, ScaleColor, ScaleLineWidth, graphics, Xaxis.TickCount, Tickwidth, Scalespace, 1);
      _axesEditValues.Clear();
      DrawXAxisValues(graphics, Xaxis.AxisColor, Drawrc, GraphFont, Xaxis.TickCount, Xaxis.Precision, Tickwidth + Scalespace, Xaxis.Name + (Xaxis.Unit == "" ? "" : " (" + Xaxis.Unit + ")"));
      DrawYAxisValues(graphics, Curve, Drawrc, GraphFont, Xaxis.TickCount, Tickwidth + Scalespace);
      if (ShowLimitArea)
        DrawRegion(graphics, Curve, LimitAreaColor, Drawrc, LimitAreaPoints);
      DrawCurveValue(graphics, Curve, GraphFont, Drawrc, nfi);
      if (Curves.Count > 0)
      {
        foreach (Curve crv in Curves.ToList())
        {
          if (crv.ShowCurve)
          {
            if (XyGraphType == XYGraphTypes.Curve)
              DrawCurve(crv, graphics, Drawrc);
            else
              DrawBar(crv, graphics, Drawrc);
          }
        }
      }
      else
      {
        if (XyGraphType == XYGraphTypes.Curve)
          DrawCurve(Curve, graphics, Drawrc);
        else
          DrawBar(Curve, graphics, Drawrc);
      }

    }

    private void DrawRegion(Graphics graphics, Curve curve, Color limitAreaColor, Rectangle drawarea, List<PointF> regionPoint)
    {
      if (regionPoint.Count >= 3)
      {
        try
        {

          RectangleF recf = new RectangleF(Xaxis.ReplacedMin, curve.MaxValueTemp, Xaxis.ReplacedMax - Xaxis.ReplacedMin, -(curve.MaxValueTemp - curve.MinValueTemp));

          if (drawarea.Width != 0 && drawarea.Height != 0)
          {
            graphics.SetClip(drawarea, CombineMode.Intersect);
            PointF[] pnts = new PointF[] { new PointF(drawarea.Left, drawarea.Top), new PointF(drawarea.Right, drawarea.Top), new PointF(drawarea.Left, drawarea.Bottom - 0.5f) };
            graphics.Transform = new Matrix(recf, pnts);
            using (SolidBrush brsh = new SolidBrush(limitAreaColor))
            {
              graphics.FillPolygon(brsh, regionPoint.ToArray());
            }
          }
        }
        catch (Exception ex) { }
        finally
        {
          graphics.ResetTransform();
          graphics.ResetClip();
        }
      }
    }

    private float FontSize(Size currentsize, SizeF fontoran)
    {
      return (currentsize.Width > currentsize.Height) ? currentsize.Width * fontoran.Width : currentsize.Height * fontoran.Height;
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

    private void DrawCurveValue(Graphics graphics, Curve curve, Font font, Rectangle drwrec, NumberFormatInfo nfi)
    {

      string curveValue = curve.Name + ": " + CommonFunction.FormatNumber(curve.Value.Y, curve.Precision, nfi) + " " + curve.Unit; //To store writing curve value
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
        mtxt = CommonFunction.FormatNumber((Xaxis.ReplacedMin + i * valueinc), precision, nfi);
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
    /// <param name="curve"></param>
    /// <param name="drawRectangle"></param>
    /// <param name="font"></param>
    /// <param name="tickCount"></param>
    /// <param name="tickSpace"></param>
    private void DrawYAxisValues(Graphics graphics, Curve curve, Rectangle drawRectangle, Font font, int tickCount, int tickSpace)
    {
      string mtxt;
      SizeF stringSize;
      float valueinc = (curve.MaxValueTemp - curve.MinValueTemp) / (tickCount - 1);
      float yartis = (float)drawRectangle.Height / (tickCount - 1);
      using (SolidBrush brs = new SolidBrush(curve.CurveColor))
      {
        for (int i = 0; i < tickCount; i++)
        {
          RectangleF drawRec = RectangleF.Empty;
          mtxt = CommonFunction.FormatNumber((curve.MaxValueTemp - i * valueinc), curve.Precision, nfi);
          stringSize = graphics.MeasureString(mtxt, font);

          drawRec = new RectangleF(drawRectangle.Left - tickSpace - stringSize.Width, drawRectangle.Top + i * yartis - stringSize.Height, stringSize.Width, stringSize.Height);

          graphics.DrawString(mtxt, font, brs, drawRec);
          if (i == 0 || i == tickCount - 1)
            _axesEditValues.Add(new AxisValueEdit(Rectangle.Round(drawRec), mtxt, i == 0 ? EditValueTypes.Y1max + 2 * curve.CurveNo : EditValueTypes.Y1min + 2 * curve.CurveNo));
        }
        brs.Dispose();
      }
    }

    private void DrawCurve(Curve crv, Graphics graphics, Rectangle drawarea)
    {
      Pen pen = new Pen(crv.CurveColor);
      try
      {
        pen.Alignment = PenAlignment.Inset;
        if (crv.Points.Length > 1)
        {
          RectangleF recf = new RectangleF(Xaxis.ReplacedMin, Curve.MaxValueTemp, Xaxis.ReplacedMax - Xaxis.ReplacedMin, -(Curve.MaxValueTemp - Curve.MinValueTemp));
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
            //graphics.DrawCurve(pen, drawList, 0);
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

    private void DrawBar(Curve crv, Graphics graphics, Rectangle drawarea)
    {
      Pen pen = new Pen(crv.CurveColor);
      SolidBrush br = new SolidBrush(crv.CurveColor);
      try
      {
        pen.Alignment = PenAlignment.Inset;
        if (crv.Points.Length > 1)
        {
          PointF[] drawList = crv.Points.ToArray();
          if (drawList.Length > 1)
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
              //graphics.DrawCurve(pen, drawList, 0);
              RectangleF rec = new RectangleF();
              for (int i = 0; i < drawList.Length; i++)
              {
                //Point pt = new Point((int)drawList[i].X,(int)drawList[i].Y);
                rec.X = drawList[i].X - 5;
                rec.Y = 0;
                rec.Width = 10;
                rec.Height = drawList[i].Y;



                //graphics.DrawRectangle(pen, rec.X, rec.Y, rec.Width, rec.Height);
                graphics.FillRectangle(br, rec);
              }
            }

          }
        }
      }
      catch (Exception ex) { }
      finally
      {
        graphics.ResetTransform();
        graphics.ResetClip();
        pen.Dispose();
        br.Dispose();
      }
    }
    #endregion

    #region Public Subs

    public void AddPointRange(PointF[] points)
    {
      if (!PauseGraph && points.Length > 1)
      {
        Curve.AddRange(points);
        Curve.Value = points[points.Length - 1];
        _isRefreshRequired = true;
      }
    }

    /// <summary>
    /// Add point to Curve for only slow refresh rate other case use AddPointRange
    /// </summary>
    /// <param name="Xval"></param>
    /// <param name="Yval"></param>
    /// <param name="markpoint"></param>
    public void AddPoint(float Xval, float Yval, bool markpoint)
    {
      Monitor.Enter(this);
      try
      {
        if (Curve != null && !PauseGraph)
        {
          Curve.Value = new PointF(Xval, Yval);
          Curve.Points[Curve.CurrentIndex] = Curve.Value;
          if (markpoint)
            Curve.MarkPoints.Add(new PointF(Xval, Yval));
        }
      }
      finally { Monitor.Exit(this); }
    }

    public void AddPoint(string crvName, float Xval, float Yval, bool markpoint)
    {
      Monitor.Enter(this);
      try
      {
        Curve crv = Curves.Find(p => p.Name == crvName);
        if (Curve != null && !PauseGraph)
        {
          crv.Value = new PointF(Xval, Yval);
          crv.Points[crv.CurrentIndex] = crv.Value;
          if (markpoint)
            crv.MarkPoints.Add(new PointF(Xval, Yval));
        }
      }
      finally { Monitor.Exit(this); }
    }


    /// <summary>
    /// Clear all points of curve
    /// </summary>
    public override void Clear()
    {
      Curve.Clear();
      foreach (Curve crv in Curves)
        crv.Clear();
      //Xaxis.ReplacedMax = Xaxis.Max;
      //Xaxis.ReplacedMin = Xaxis.Min;
      this.Invalidate();
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

    #endregion

  }
}