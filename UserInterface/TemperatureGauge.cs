using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GlobalFunctions;

namespace UserInterface
{
  /// <summary>
  /// Class for the linear gauge control
  /// </summary>
  [ToolboxItem(true)]
  public partial class TemperatureGauge : AnalogBase
  {
    #region Enumerator
    public enum HeaderShownHidden
    {
      On, Off,
    }
    #endregion

    #region Properties variables
    private HeaderShownHidden headerLabel;
    private Color backgroundColor;
    private Color bodyColor;
    private Color tickColor;
    private Color levelColor;
    private bool viewGlass;
    private Color currentValueBackColor;
    private int scaleDivisionsLeft;
    private int scaleDivisionsRight;
    private int scaleSubDivisionsLeft;
    private int scaleSubDivisionsRight;
    private int precision;
    private float currValue;
    private float lowValue;
    private float highValue;
    private float lowAlarmValue;
    private float lowWarnValue;
    private float highAlarmValue;
    private float highWarnValue;
    private float x1, y1, x2, y2;
    private float cx, cy, w, h, tx, ty;
    #endregion

    #region Class variables
    protected PointF tickPositionStartLeft;
    protected PointF tickPositionEndLeft;
    protected PointF tickPositionStartRight;
    protected PointF tickPositionEndRight;
    protected float drawRatio;
    #endregion

    #region Costructors
    public TemperatureGauge()
    {
      // Initialization
      InitializeComponent();

      // Properties initialization
      this.WidthHeightRatio = 100f / 240f;
      this.headerLabel = HeaderShownHidden.On;
      this.backgroundColor = this.BackColor;
      this.bodyColor = Color.FromArgb(80, 138, 183);
      this.tickColor = Color.Black;
      this.levelColor = Color.FromArgb(177, 15, 15);
      this.currentValueBackColor = Color.Linen;
      this.LowAlarmColor = Color.DarkRed;
      this.LowWarnColor = Color.Yellow;
      this.HighAlarmColor = Color.DarkRed;
      this.HighWarnColor = Color.Yellow;
      this.viewGlass = true;
      this.scaleDivisionsLeft = 3;
      this.scaleSubDivisionsLeft = 3;
      this.scaleDivisionsRight = 3;
      this.scaleSubDivisionsRight = 3;
      this.highValue = 100;
      this.lowValue = 0;
      this.currValue = 0;
      this.precision = 1;
      this.highAlarmValue = this.highValue;
      this.highWarnValue = this.highValue;
      this.lowWarnValue = this.lowValue;
      this.lowAlarmValue = this.lowValue;

      // Set the styles for drawing
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.SetStyle(ControlStyles.ResizeRedraw, true);

      // Create the default renderer
      this.UIType = UserInterfaceUsingTypes.Indicator;
    }
    #endregion

    #region Properties
    [Browsable(false), Category("Appearance")]
    public override string Unit
    {
      get
      {
        return base.Unit;
      }
      set
      {
        base.Unit = value;
      }
    }

    [Browsable(false), Category("Appearance")]
    public override Font HeaderFont
    {
      get { return base.HeaderFont; }
    }

    [Browsable(false), Category("Appearance")]
    public override Color HeaderBackColor
    {
      get
      {
        return base.HeaderBackColor;
      }
      set
      {
        base.HeaderBackColor = value;
      }
    }

    [Category("Appearance"), Description("Show / Hide header")]
    public HeaderShownHidden HeaderLabel
    {
      get { return headerLabel; }
      set
      {
        headerLabel = value;
        Invalidate();
      }
    }

    [Browsable(false), Category("Appearance"), Description("Color of the gauge background")]
    public Color BackgroundColor
    {
      get { return backgroundColor; }
      set
      {
        backgroundColor = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Outer body color")]
    public Color BodyColor
    {
      get { return bodyColor; }
      set
      {
        bodyColor = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Color of the tick")]
    public Color TickColor
    {
      get { return tickColor; }
      set
      {
        tickColor = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Color of the level")]
    public Color LevelColor
    {
      get { return levelColor; }
      set
      {
        levelColor = value;
        Invalidate();
      }
    }

    [Browsable(false), Category("Appearance"), Description("Color of the current value background")]
    public Color CurrentValueBackColor
    {
      get { return currentValueBackColor; }
      set
      {
        currentValueBackColor = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Show / Hide the glass effect")]
    public bool ViewGlass
    {
      get { return viewGlass; }
      set
      {
        viewGlass = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Number of the left scale divisions (Celcius Side)")]
    public int ScaleDivisionsLeft
    {
      get { return scaleDivisionsLeft; }
      set
      {
        scaleDivisionsLeft = value;
        if (scaleDivisionsLeft < 2)
          scaleDivisionsLeft = 2;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Number of the left scale subdivisions (Celcius Side)")]
    public int ScaleSubDivisionsLeft
    {
      get { return scaleSubDivisionsLeft; }
      set
      {
        scaleSubDivisionsLeft = value;
        if (scaleSubDivisionsLeft < 0)
        {
          scaleSubDivisionsLeft = 0;
        }
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Number of the right scale divisions (Fahrenheit Side)")]
    public int ScaleDivisionsRight
    {
      get { return scaleDivisionsRight; }
      set
      {
        scaleDivisionsRight = value;
        if (scaleDivisionsRight < 2)
          scaleDivisionsRight = 2;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Number of the right scale subdivisions (Fahrenheit Side)")]
    public int ScaleSubDivisionsRight
    {
      get { return scaleSubDivisionsRight; }
      set
      {
        scaleSubDivisionsRight = value;
        if (scaleSubDivisionsRight < 0)
        {
          scaleSubDivisionsRight = 0;
        }
        Invalidate();
      }
    }

    [Browsable(false), Category("Behavior"), Description("Value of the data")]
    public override float Value
    {
      get
      {
        return base.Value;
      }
      set
      {
        float val = value;
        if (val > highValue)
          val = highValue;
        if (val < lowValue)
          val = lowValue;
        base.Value = (float)val;
        currValue = val;
        Invalidate();
      }
    }

    [Category("Behavior"), Description("Precision of the numeric value (0-6 digits)")]
    public int Precision
    {
      get { return precision; }
      set
      {
        precision = value;
        if (precision < 0 || precision > 6)
        {
          precision = 0;
        }
        Invalidate();
      }
    }

    [Category("Behavior"), Description("Minimum value of the data (in Celcius)")]
    public override float LowValue
    {
      get { return lowValue; }
      set
      {
        if (value < highValue)
        {
          lowValue = value;
          if (currValue < lowValue)
            currValue = lowValue;
          Invalidate();
        }
      }
    }

    [Category("Behavior"), Description("Maximum value of the data (in Celcius)")]
    public override float HighValue
    {
      get { return highValue; }
      set
      {
        if (value > lowValue)
        {
          highValue = value;
          if (currValue > highValue)
            currValue = highValue;
          Invalidate();
        }
      }
    }

    [Category("Behavior"), Description("Low alarm value")]
    public override float LowAlarmValue
    {
      get { return lowAlarmValue; }
      set
      {
        if (value >= lowValue && value <= highValue && value <= highWarnValue && value <= highAlarmValue)
        {
          lowAlarmValue = value;
          Invalidate();
        }
      }
    }

    [Category("Behavior"), Description("Low warning value (must be larger than the low alarm value)")]
    public override float LowWarnValue
    {
      get { return lowWarnValue; }
      set
      {
        if (value >= lowValue && value <= highValue && value <= highWarnValue && value <= highAlarmValue)
        {
          lowWarnValue = value;
          Invalidate();
        }
      }
    }

    [Category("Behavior"), Description("High alarm value")]
    public override float HighAlarmValue
    {
      get { return highAlarmValue; }
      set
      {
        if (value >= lowValue && value <= highValue && value >= lowWarnValue && value >= lowAlarmValue)
        {
          highAlarmValue = value;
          Invalidate();
        }
      }
    }

    [Category("Behavior"), Description("High warning value (must be smaller than the high alarm value)")]
    public override float HighWarnValue
    {
      get { return highWarnValue; }
      set
      {
        if (value >= lowValue && value <= highValue && value >= lowWarnValue && value >= lowAlarmValue)
        {
          highWarnValue = value;
          Invalidate();
        }
      }
    }

    [Category("Appearance"), Description("")]
    public new Color LowAlarmColor
    {
      get { return base.LowAlarmColor; }
      set { base.LowAlarmColor = value; }
    }

    [Category("Appearance"), Description("")]
    public new Color HighAlarmColor
    {
      get { return base.HighAlarmColor; }
      set { base.HighAlarmColor = value; }
    }

    [Category("Appearance"), Description("")]
    public new Color LowWarnColor
    {
      get { return base.LowWarnColor; }
      set { base.LowWarnColor = value; }
    }

    [Category("Appearance"), Description("")]
    public new Color HighWarnColor
    {
      get { return base.HighWarnColor; }
      set { base.HighWarnColor = value; }
    }

    [Browsable(false), Category("Appearance")]
    public override BackFillTypes BackFillType
    {
      get { return base.BackFillType; }
    }

    [Browsable(false), Category("Appearance")]
    public override Color BackGradientColor
    {
      get { return base.BackGradientColor; }
    }

    [Browsable(false), Category("Appearance")]
    public override LinearGradientMode BackGradientMode
    {
      get { return base.BackGradientMode; }
    }

    [Browsable(false), Category("Appearance")]
    public override Color BackColor
    {
      get { return base.BackColor; }
    }

    [Browsable(false), Category("Appearance")]
    public override Color ForeColor
    {
      get { return base.ForeColor; }
    }

    [Browsable(false), Category("Appearance")]
    public new BorderStyle BorderStyle
    {
      get { return base.BorderStyle; }
    }

    [Browsable(false), Category("Appearance")]
    public override HeaderPosition HeaderPosition
    {
      get { return base.HeaderPosition; }
    }

    [Browsable(false), Category("Appearance")]
    public override bool HeaderVisible
    {
      get { return base.HeaderVisible; }
    }
    #endregion

    #region Events delegates
    protected override void OnSizeChanged(EventArgs e)
    {
      base.OnSizeChanged(e);
      this.Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      Bitmap offScreenBmp = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
      using (System.Drawing.Graphics g = Graphics.FromImage(offScreenBmp))
      {
        g.SmoothingMode = SmoothingMode.HighQuality;
        // Draw the control
        DrawBackground(g);
        // Draw the image to the screen
        e.Graphics.DrawImageUnscaled(offScreenBmp, 0, 0);
      }
    }
    #endregion

    public RectangleF CalculateSize(RectangleF rc)
    {
      if (rc.Width == 0 || rc.Height == 0)
      {
        rc.Width = 100;
        rc.Height = 240;
      }

      rc.X = rc.X + 1;
      rc.Y = rc.Y + 1;
      rc.Width = (float)(ClientSize.Width);
      rc.Height = (float)(ClientSize.Height);

      return rc;
    }

    public RectangleF CalculateDimensions(RectangleF rc)
    {
      rc = CalculateSize(rc);
      if (rc.Width > rc.Height)
      {
        h = rc.Height;
        w = 100f / 240f * h;
        cx = (rc.Width - w) / 2;
        cy = 0;
      }
      else
      {
        if (rc.Width * 2.4f < rc.Height)
        {
          w = rc.Width;
          h = w * 2.4f;
          cx = 0;
          cy = (rc.Height - h) / 2 + 2;
        }
        else
        {
          h = rc.Height;
          w = h * 100f / 240f;
          cx = (rc.Width - w) / 2;
          cy = 0;
        }
      }
      rc.X = cx;
      rc.Y = cy;
      rc.Width = w;
      rc.Height = h;

      return rc;
    }

    private void DrawBackground(Graphics gr)
    {
      RectangleF rc = new RectangleF();
      rc = CalculateDimensions(rc);
      rc.Width = rc.Width - 2;
      rc.Height = rc.Height - 2;
      SolidBrush brBorder = new SolidBrush(Color.FromArgb(216, 216, 216));
      GraphicsPath path = RoundedRectangle.Create(rc.X, rc.Y, rc.Width, rc.Height, 20);
      gr.FillPath(brBorder, path);

      RectangleF rcInside = new RectangleF();
      rcInside.X = rc.X + rc.Width * 0.02f;
      rcInside.Y = rc.Y + rc.Width * 0.02f;
      rcInside.Width = rc.Width * 0.96f;
      rcInside.Height = rc.Height - rc.Width * 0.04f;
      SolidBrush brInside = new SolidBrush(Color.FromArgb(238, 238, 238));
      GraphicsPath pathInside = RoundedRectangle.Create(rcInside.X, rcInside.Y, rcInside.Width, rcInside.Height, 20);
      gr.FillPath(brInside, pathInside);

      Color bodyColor = this.BodyColor;
      float rCF = -30 / 175f + 1;
      float gCF = -49 / 117f + 1;
      float bCF = -31 / 72f + 1;
      float red = bodyColor.R * rCF;
      float green = bodyColor.G * gCF;
      float blue = bodyColor.B * bCF;
      Color darkerColor = Color.FromArgb(bodyColor.A, (int)red, (int)green, (int)blue);
      RectangleF rcOuterBody = new RectangleF();
      rcOuterBody.X = rcInside.X + rc.Width * 0.02f;
      rcOuterBody.Y = rcInside.Y + rc.Width * 0.02f;
      rcOuterBody.Width = rcInside.Width * 0.96f;
      rcOuterBody.Height = rcInside.Height - rc.Width * 0.04f;
      GraphicsPath pathOuterBody = RoundedRectangle.Create(rcOuterBody.X, rcOuterBody.Y, rcOuterBody.Width, rcOuterBody.Height, 17);
      LinearGradientBrush brOuterBody = new LinearGradientBrush(rcOuterBody, bodyColor, darkerColor, LinearGradientMode.Vertical);
      gr.FillPath(brOuterBody, pathOuterBody);

      RectangleF rcInnerBody = new RectangleF();
      rcInnerBody.X = rcOuterBody.X + rc.Width * 0.04f;
      rcInnerBody.Y = rcOuterBody.Y + rc.Width * 0.04f;
      rcInnerBody.Width = rcOuterBody.Width * 0.91f;
      rcInnerBody.Height = rcOuterBody.Height - rc.Width * 0.08f;
      GraphicsPath pathInnerBody = RoundedRectangle.Create(rcInnerBody.X, rcInnerBody.Y, rcInnerBody.Width, rcInnerBody.Height, 15);
      LinearGradientBrush brInnerBody = new LinearGradientBrush(rcInnerBody, darkerColor, bodyColor, LinearGradientMode.Vertical);
      gr.FillPath(brInnerBody, pathInnerBody);

      RectangleF rcInnerSurface = new RectangleF();
      rcInnerSurface.X = rcInnerBody.X + rc.Width * 0.04f;
      rcInnerSurface.Y = rcInnerBody.Y + rc.Width * 0.04f;
      rcInnerSurface.Width = rcInnerBody.Width * 0.91f;
      rcInnerSurface.Height = rcInnerBody.Height - rc.Width * 0.08f;
      GraphicsPath pathInnerSurface = RoundedRectangle.Create(rcInnerSurface.X, rcInnerSurface.Y, rcInnerSurface.Width, rcInnerSurface.Height, 10);
      SolidBrush brInnerSurface = new SolidBrush(Color.White);
      gr.FillPath(brInnerSurface, pathInnerSurface);

      RectangleF rcGlow = new RectangleF();
      rcGlow = rcInnerSurface;
      GraphicsPath pathGlow = RoundedRectangle.Create(rcGlow.X, rcGlow.Y, rcGlow.Width, rcGlow.Height, 10);
      LinearGradientBrush brGlow = new LinearGradientBrush(rcGlow, Color.FromArgb(87, 54, 54, 54), Color.FromArgb(128, 255, 255, 255), LinearGradientMode.Vertical);
      gr.FillPath(brGlow, pathGlow);
      DrawUpperGlow(gr, rcGlow);
      DrawDivisions(gr, rcGlow);
      DrawHeader(gr, rcGlow);
      DrawNumericValue(gr, rcGlow);
      DrawGlass(gr, rcGlow);
      DrawTube(gr, rcGlow);
      DrawValue(gr, rcGlow);
    }

    private void DrawUpperGlow(Graphics gr, RectangleF rc)
    {
      rc = CalculateDimensions(rc);
      rc.X = rc.X + rc.Width * 0.12f;
      rc.Y = rc.Y + rc.Width * 0.12f;
      if (rc.Width * 0.76317696f < 2)
        rc.Width = rc.Width * 0.76317696f;
      else
        rc.Width = rc.Width * 0.76317696f - 2;
      float radius = 10;
      float xw = rc.X + rc.Width;
      float r2 = radius * 2;
      float xwr2 = xw - r2;

      GraphicsPath p = new GraphicsPath();
      p.StartFigure();
      p.AddArc(rc.X, rc.Y, r2, r2, 180, 90);
      p.AddArc(xwr2, rc.Y, r2, r2, 270, 90);
      p.AddLine(xw, rc.Y + r2, xw, rc.Y + rc.Height * 0.2f);
      p.AddArc(rc.X, rc.Y + rc.Height * 0.2f, rc.Width, rc.Height * 0.1f, 0, 180);
      p.CloseFigure();
      Color clr1 = Color.FromArgb(200, 255, 255, 255);
      Color clr2 = Color.FromArgb(70, 50, 50, 50);
      LinearGradientBrush br1 = new LinearGradientBrush(rc, clr1, clr2, LinearGradientMode.Vertical);
      br1.SetSigmaBellShape(.3f, 0.6f);
      gr.FillPath(br1, p);
    }

    private void DrawTube(Graphics gr, RectangleF rc)
    {
      rc = CalculateDimensions(rc);

      Color tubeColor = Color.FromArgb(150,150,150);
      Pen penTube = new Pen(tubeColor, 2f);
      Pen penMercury = new Pen(levelColor);
      SolidBrush brIn = new SolidBrush(Color.FromArgb(255, 255, 255));
      SolidBrush brMercury = new SolidBrush(levelColor);
      rc.X = rc.X + (rc.Width / 2) - (rc.Width * 13 / 282);
      rc.Y = rc.Y + (rc.Height * 0.11f);
      rc.Width = (rc.Width * 13 / 141);
      rc.Height = (rc.Height * 9.4f / 368);
      GraphicsPath p = new GraphicsPath();
      p.StartFigure();
      p.AddArc(rc.X, rc.Y, rc.Width, rc.Height, 180, 180);
      x1 = rc.X + rc.Width;
      y1 = rc.Y + rc.Height / 2;
      x2 = rc.X + rc.Width;
      y2 = rc.Y + rc.Height / 2 + rc.Height * 368 / 13.6f;
      p.AddLine(x1, y1, x2, y2);
      p.AddArc(rc.X - rc.Width / 2, y2, rc.Width * 2, rc.Width * 2, -55, 290);
      p.AddLine(rc.X, y2, rc.X, rc.Y + rc.Height / 2);
      p.CloseFigure();

      if (currValue < HighWarnValue && currValue > LowWarnValue)
      {
        brIn = new SolidBrush(Color.FromArgb(240, 240, 240));
      }

      if (HighWarnValue <= currValue && currValue < HighAlarmValue)
      {
        brIn = new SolidBrush(this.HighWarnColor);
      }

      if (LowWarnValue >= currValue && currValue > LowAlarmValue)
      {
        brIn = new SolidBrush(this.LowWarnColor);
      }

      if (HighAlarmValue <= currValue)
      {
        brIn = new SolidBrush(this.HighAlarmColor);
      }

      if (LowAlarmValue >= currValue)
      {
        brIn = new SolidBrush(this.LowAlarmColor);
      }

      gr.DrawPath(penTube, p);
      gr.FillPath(brIn, p);
      GraphicsPath pIn = new GraphicsPath();
      pIn.StartFigure();
      pIn.AddArc(rc.X - rc.Width / 4f, y2 + rc.Width / 4f, rc.Width * 4.5f / 3, rc.Width * 4.5f / 3, -55, 290);
      pIn.AddLine(rc.X + rc.Width * 0.2f, y2 + rc.Width / 3f, rc.X + rc.Width * 0.2f, y2);
      pIn.AddLine(rc.X + rc.Width * 0.8f, y2, rc.X + rc.Width * 0.8f, y2);
      pIn.AddLine(rc.X + rc.Width * 0.8f, y2, rc.X + rc.Width * 0.8f, y2 + rc.Width / 3f);
      pIn.CloseFigure();
      gr.DrawPath(penMercury, pIn);
      gr.FillPath(brMercury, pIn);
    }

    private void DrawDivisions(Graphics gr, RectangleF rc)
    {
      rc = CalculateDimensions(rc);
      float drawRatio = (Math.Min(rc.Width, rc.Height)) / 75;
      if (drawRatio == 0.0)
        drawRatio = 1;
      rc.X = rc.X + (rc.Width / 2) - (rc.Width * 13 / 282);
      rc.Y = rc.Y + (rc.Height * 0.11f);
      rc.Width = (rc.Width * 13 / 141);
      rc.Height = (rc.Height * 9.4f / 368);

      x1 = rc.X + rc.Width;
      y1 = rc.Y + rc.Height / 2;
      x2 = rc.X + rc.Width;
      y2 = rc.Y + rc.Height / 2 + rc.Height * 368 / 13.6f;

      float rulerValueLeft = LowValue;
      float rulerValueRight = LowValue;
      Color tickColor = this.TickColor;

      #region Left Divisions
      PointF ptStart = new PointF(0, 0);
      PointF ptEnd = new PointF(0, 0);

      tickPositionStartLeft = new PointF(x1 - rc.Width * 2.5f, y2);
      tickPositionEndLeft = new PointF(x1 - rc.Width * 1.5f, y2);

      PointF tmpPnt = tickPositionStartLeft;
      for (int n = 0; n < ScaleDivisionsLeft; n++)
      {
        float difference = 0;
        difference = y2 - rc.Y - rc.Height;
        float division = difference / (ScaleDivisionsLeft - 1);

        ptStart.X = tickPositionStartLeft.X;
        ptStart.Y = tickPositionStartLeft.Y - n * division;
        ptEnd.X = tickPositionEndLeft.X;
        ptEnd.Y = tickPositionEndLeft.Y - n * division;

        Pen penTick = new Pen(tickColor, 1.5F * drawRatio);
        gr.DrawLine(penTick, ptStart, ptEnd);

        for (int j = 0; j <= ScaleSubDivisionsLeft; j++)
        {
          float subDifference = 0;
          subDifference = difference / (ScaleDivisionsLeft - 1);
          float subDivision = subDifference / (ScaleSubDivisionsLeft + 1);

          ptStart.X = tickPositionStartLeft.X + rc.Width * 0.25f;
          ptStart.Y = tickPositionStartLeft.Y - n * division - j * subDivision;
          ptEnd.X = tickPositionEndLeft.X;
          ptEnd.Y = tickPositionEndLeft.Y - n * division - j * subDivision;

          if (n == ScaleDivisionsLeft - 1)
            break;

          Pen pen2 = new Pen(tickColor, 0.75F * drawRatio);
          gr.DrawLine(pen2, ptStart, ptEnd);
        }

        float val = rulerValueLeft;
        String str = val.ToString("0.####");
        if (str.Length < 9)
        {
          Font font = new Font(this.Font.FontFamily, 4F * drawRatio);
          SolidBrush brTick = new SolidBrush(Color.Black);
          float tx = x1 - rc.Width * 3.5f;
          float ty = tmpPnt.Y - n * division - 3F * drawRatio;
          SizeF size = gr.MeasureString(str, font);
          gr.DrawString(str, font, brTick, tx - (float)(size.Width * 0.5), ty);
        }

        rulerValueLeft += (HighValue - LowValue) / (ScaleDivisionsLeft - 1);

        String strCelcius = "°C";
        Font fontCelcius = new Font(this.Font.FontFamily, 4F * drawRatio);
        SolidBrush brCelcius = new SolidBrush(Color.Black);
        float txCelcius = x1 - rc.Width * 2.5f;
        float tyCelcius = y2 + rc.Height;
        SizeF sizeCelcius = gr.MeasureString(strCelcius, fontCelcius);
        gr.DrawString(strCelcius, fontCelcius, brCelcius, txCelcius - (float)(sizeCelcius.Width * 0.5), tyCelcius);
      }
      #endregion

      #region Right Divisions
      PointF ptStart2 = new PointF(0, 0);
      PointF ptEnd2 = new PointF(0, 0);

      tickPositionStartRight = new PointF(x1 + rc.Width * 0.5f, y2);
      tickPositionEndRight = new PointF(x1 + rc.Width * 1.5f, y2);

      PointF tmpPnt2 = tickPositionStartRight;
      for (int n = 0; n < ScaleDivisionsRight; n++)
      {
        float difference2 = 0;
        difference2 = y2 - rc.Y - rc.Height;
        float division2 = difference2 / (ScaleDivisionsRight - 1);

        ptStart2.X = tickPositionStartRight.X;
        ptStart2.Y = tickPositionStartRight.Y - n * division2;
        ptEnd2.X = tickPositionEndRight.X;
        ptEnd2.Y = tickPositionEndRight.Y - n * division2;

        Pen penTick = new Pen(tickColor, 1.5F * drawRatio);
        gr.DrawLine(penTick, ptStart2, ptEnd2);

        for (int j = 0; j <= ScaleSubDivisionsRight; j++)
        {
          float subDifference2 = 0;
          subDifference2 = difference2 / (ScaleDivisionsRight - 1);
          float subDivision2 = subDifference2 / (ScaleSubDivisionsRight + 1);

          ptStart2.X = tickPositionStartRight.X;
          ptStart2.Y = tickPositionStartRight.Y - n * division2 - j * subDivision2;
          ptEnd2.X = tickPositionEndRight.X - rc.Width * 0.25f;
          ptEnd2.Y = tickPositionEndRight.Y - n * division2 - j * subDivision2;

          if (n == ScaleDivisionsRight - 1)
            break;

          Pen pen2 = new Pen(tickColor, 0.75F * drawRatio);
          gr.DrawLine(pen2, ptStart2, ptEnd2);
        }

        float val2 = rulerValueRight * 9 / 5 + 32;
        String str2 = val2.ToString("0.####");
        if (str2.Length < 9)
        {
          Font font = new Font(this.Font.FontFamily, 4F * drawRatio);
          SolidBrush brTick = new SolidBrush(Color.Black);
          float tx2 = x1 + rc.Width * 2.5f;
          float ty2 = tmpPnt2.Y - n * division2 - 3F * drawRatio;
          SizeF size2 = gr.MeasureString(str2, font);
          gr.DrawString(str2, font, brTick, tx2 - (float)(size2.Width * 0.5), ty2);
        }

        rulerValueRight += (HighValue - LowValue) / (ScaleDivisionsRight - 1);

        String strFahrenheit = "°F";
        Font fontFahrenheit = new Font(this.Font.FontFamily, 4F * drawRatio);
        SolidBrush brFahrenheit = new SolidBrush(Color.Black);
        float txFahrenheit = x1 + rc.Width * 1.5f;
        float tyFahrenheit = y2 + rc.Height;
        SizeF sizeFahrenheit = gr.MeasureString(strFahrenheit, fontFahrenheit);
        gr.DrawString(strFahrenheit, fontFahrenheit, brFahrenheit, txFahrenheit - (float)(sizeFahrenheit.Width * 0.5), tyFahrenheit);
      }
      #endregion
    }

    private void DrawValue(Graphics gr, RectangleF rc)
    {
      rc = CalculateDimensions(rc);
      rc.X = rc.X + (rc.Width / 2) - (rc.Width * 13 / 282);
      rc.Y = rc.Y + (rc.Height * 0.11f);
      rc.Width = (rc.Width * 13 / 141);
      rc.Height = (rc.Height * 9.4f / 368);

      float x1 = rc.X + rc.Width;
      float y1 = rc.Y + rc.Height / 2;
      float x2 = rc.X + rc.Width;
      float y2 = rc.Y + rc.Height / 2 + rc.Height * 368 / 13.6f;

      float minValue = this.LowValue;
      float maxValue = this.HighValue;
      float currValue = this.Value;

      PointF ptStart = new PointF(0, 0);
      PointF ptEnd = new PointF(0, 0);

      float drawRatio = (Math.Min(rc.Width, rc.Height)) / 75;
      if (drawRatio == 0.0)
        drawRatio = 1;


      float difference = 0;
      difference = y2 - rc.Y - rc.Height;

      float val = maxValue - minValue;
      val = (100 * (currValue - minValue)) / val;
      val = (maxValue - minValue) * val / 100;
      val = minValue + val;

      if (currValue > minValue)
      {
        tickPositionStartLeft = new PointF((rc.X + rc.Width * 0.2f), y2);
        tickPositionEndLeft = new PointF((rc.X + rc.Width * 0.8f), y2);

        GraphicsPath pthValue = new GraphicsPath();

        ptStart.X = tickPositionStartLeft.X;
        ptStart.Y = tickPositionStartLeft.Y - (val - minValue) * difference / (maxValue - minValue);
        ptEnd.X = tickPositionEndLeft.X;
        ptEnd.Y = tickPositionEndLeft.Y - (val - minValue) * difference / (maxValue - minValue);
        pthValue.AddLine(ptStart, ptEnd);

        ptStart = ptEnd;
        ptEnd.X = tickPositionEndLeft.X;
        ptEnd.Y = tickPositionEndLeft.Y;
        pthValue.AddLine(ptStart, ptEnd);

        ptStart = ptEnd;
        ptEnd.X = tickPositionStartLeft.X;
        ptEnd.Y = tickPositionStartLeft.Y;
        pthValue.AddLine(ptStart, ptEnd);

        pthValue.CloseFigure();

        SolidBrush brValue = new SolidBrush(this.LevelColor);
        Pen penValue = new Pen(this.LevelColor);

        gr.DrawPath(penValue, pthValue);
        gr.FillPath(brValue, pthValue);
      }
    }

    private void DrawHeader(Graphics gr, RectangleF rc)
    {
      if ((int)this.HeaderLabel == 0)
      {
        rc = CalculateDimensions(rc);
        Color headerFontColor = this.HeaderForeColor;

        float drawRatio = (Math.Min(rc.Width, rc.Height)) / 75;
        if (drawRatio == 0.0)
          drawRatio = 1;

        StringFormat stringFormat = new StringFormat();
        stringFormat.Alignment = StringAlignment.Center;
        stringFormat.LineAlignment = StringAlignment.Center;

        string strHeader = this.Header;
        Font font = new Font(this.Font.FontFamily, (float)(5F * drawRatio));
        SolidBrush brHeader = new SolidBrush(headerFontColor);
        float tx = (float)(0.5 * ClientSize.Width);
        float ty = (float)(rc.Y + rc.Height * 0.08f);
        SizeF size = gr.MeasureString(strHeader, font);
        gr.DrawString(strHeader, font, brHeader, tx, ty, stringFormat);
      }
    }

    private void DrawNumericValue(Graphics gr, RectangleF rc)
    {
      rc = CalculateDimensions(rc);
      Color currentValueColor = Color.Black;
      Color currentValueBackColor = this.CurrentValueBackColor;

      float drawRatio = (Math.Min(rc.Width, rc.Height)) / 75;
      if (drawRatio == 0.0)
        drawRatio = 1;

      StringFormat stringFormat = new StringFormat();
      stringFormat.Alignment = StringAlignment.Center;
      stringFormat.LineAlignment = StringAlignment.Center;

      int precision = this.Precision;
      double val = Value;
      String str = val.ToString("0.0");

      if (precision == 0 || precision > 6)
        str = val.ToString("0.");
      else if (precision == 1)
        str = val.ToString("0.0");
      else if (precision == 2)
        str = val.ToString("0.00");
      else if (precision == 3)
        str = val.ToString("0.000");
      else if (precision == 4)
        str = val.ToString("0.0000");
      else if (precision == 5)
        str = val.ToString("0.00000");
      else
        str = val.ToString("0.000000");

      Font font = new Font(this.Font.FontFamily, (float)(5F * drawRatio));
      SolidBrush brCurrentValue = new SolidBrush(currentValueColor);
      float tx = (float)(0.5 * ClientSize.Width);
      float ty = (float)(rc.Y + rc.Height * 0.92f);
      gr.DrawString(str, font, brCurrentValue, tx, ty, stringFormat);
    }

    private void DrawGlass(Graphics gr, RectangleF rc)
    {
      if (ViewGlass == true)
      {
        GraphicsPath path = RoundedRectangle.Create(rc.X, rc.Y, rc.Width, rc.Height, 10);
        Color clr1 = Color.FromArgb(100, 255, 255, 255);
        Color clr2 = Color.FromArgb(70, 100, 100, 100);
        LinearGradientBrush br1 = new LinearGradientBrush(rc, clr2, clr1, LinearGradientMode.Horizontal);
        br1.SetSigmaBellShape(.5f, 1f);
        gr.FillPath(br1, path);
      }
    }
  }
}
