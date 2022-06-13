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
  public partial class LinearGauge : AnalogBase
  {
    #region Enumerator
    public enum LinearGaugeStyle
    {
      Vertical,
    };

    public enum NeedleStyle
    {
      Line, LeftTriangle, LeftWedge, RightTriangle, RightWedge,
    };

    public enum RangeBandShownHidden
    {
      On, Off,
    }

    public enum HeaderShownHidden
    {
      On, Off,
    }

    #endregion

    #region Properties variables
    private LinearGaugeStyle gaugeStyle;
    private NeedleStyle needleType;
    private RangeBandShownHidden rangeBand;
    private HeaderShownHidden headerLabel;
    private Color backgroundColor;
    private Color bodyColor1;
    private Color bodyColor2;
    private Color needleColor;
    private Color tickColor;
    private Color levelColor;
    private Color rangeBandColor;
    private Color unitColor;
    private Color currentValueBackColor;
    private bool viewGlass;
    private int scaleDivisions;
    private int scaleSubDivisions;
    private int precision;
    private float currValue;
    private float lowValue;
    private float highValue;
    private float lowAlarmValue;
    private float lowWarnValue;
    private float highAlarmValue;
    private float highWarnValue;
    private float cx, cy, w, h, tx, ty;
    #endregion

    #region Class variables
    protected PointF tickPositionStart;
    protected PointF tickPositionEnd;
    protected RectangleF drawRect;
    protected RectangleF glossyRect;
    protected float drawRatio;
    #endregion

    #region Costructors
    public LinearGauge()
    {
      // Initialization
      InitializeComponent();

      // Properties initialization
      this.WidthHeightRatio = 110f /242f;
      this.gaugeStyle = LinearGaugeStyle.Vertical;
      this.needleType = NeedleStyle.RightTriangle;
      this.rangeBand = RangeBandShownHidden.On;
      this.headerLabel = HeaderShownHidden.On;
      this.backgroundColor = this.BackColor;
      this.bodyColor1 = Color.FromArgb(4, 80, 142);
      this.bodyColor2 = Color.FromArgb(45, 10, 9);
      this.needleColor = Color.Red;
      this.tickColor = Color.FromArgb(182, 182, 182);
      this.levelColor = Color.Chartreuse;
      this.rangeBandColor = Color.Chartreuse;
      this.unitColor = Color.Black;
      this.currentValueBackColor = Color.Linen;
      this.LowAlarmColor = Color.DarkRed;
      this.LowWarnColor = Color.Yellow;
      this.HighAlarmColor = Color.DarkRed;
      this.HighWarnColor = Color.Yellow;
      this.viewGlass = true;
      this.scaleDivisions = 3;
      this.scaleSubDivisions = 3;
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

    [Category("Appearance"), Description("Style of the linear gauge")]
    public LinearGaugeStyle Type
    {
      get { return gaugeStyle; }
      set
      {
        gaugeStyle = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Type of the needle")]
    public NeedleStyle NeedleType
    {
      get { return needleType; }
      set
      {
        needleType = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Show / Hide range band")]
    public RangeBandShownHidden RangeBand
    {
      get { return rangeBand; }
      set
      {
        rangeBand = value;
        Invalidate();
      }
    }

    [Browsable(false), Category("Appearance")]
    public override Font HeaderFont
    {
      get { return base.HeaderFont; }
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

    [Category("Appearance"), Description("Color of the gauge background")]
    public Color BackgroundColor
    {
      get { return backgroundColor; }
      set
      {
        backgroundColor = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Lower body color")]
    public Color BodyColor1
    {
      get { return bodyColor1; }
      set
      {
        bodyColor1 = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Upper body color")]
    public Color BodyColor2
    {
      get { return bodyColor2; }
      set
      {
        bodyColor2 = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Color of the needle")]
    public Color NeedleColor
    {
      get { return needleColor; }
      set
      {
        needleColor = value;
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

    [Category("Appearance"), Description("Color of the range band")]
    public Color RangeBandColor
    {
      get { return rangeBandColor; }
      set
      {
        rangeBandColor = value;
        Invalidate();
      }
    }

    [Browsable(false), Category("Appearance"), Description("Color of the unit")]
    public Color UnitColor
    {
      get { return unitColor; }
      set
      {
        unitColor = value;
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

    [Category("Appearance"), Description("Number of the scale divisions")]
    public int ScaleDivisions
    {
      get { return scaleDivisions; }
      set
      {
        scaleDivisions = value;
        if (scaleDivisions < 2)
          scaleDivisions = 2;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Number of the scale subdivisions")]
    public int ScaleSubDivisions
    {
      get { return scaleSubDivisions; }
      set
      {
        scaleSubDivisions = value;
        if (scaleSubDivisions < 0)
        {
          scaleSubDivisions = 0;
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
        base.Value = val;
        currValue = val;
        
      }
    }

    [Category("Behavior"), Description("Precision of the value (0-6 digits)")]
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

    [Category("Behavior"), Description("Minimum value of the data")]
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

    [Category("Behavior"), Description("Maximum value of the data")]
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

    [Category("Appearance"), Description("")]
    public override string Unit
    {
      get { return base.Unit; }
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

    #region Public methods
    public float GetDrawRatio()
    {
      return this.drawRatio;
    }

    public PointF GetTickPositionStart()
    {
      return this.tickPositionStart;
    }

    public PointF GetTickPositionEnd()
    {
      return this.tickPositionEnd;
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
        DrawBody(g);
        DrawUnit(g);
        DrawHeader(g);
        DrawNumericValue(g);
        DrawValue(g);
        DrawDivisions(g);
        DrawRangeBand(g);
        DrawAlertWarning(g);
        DrawNeedle(g);
        DrawGlass(g);
        // Draw the image to the screen
        e.Graphics.DrawImageUnscaled(offScreenBmp, 0, 0);
      }
    }
    #endregion

    public RectangleF CalculateSize(RectangleF rc)
    {
      if (rc.Width == 0 || rc.Height == 0)
      {
        rc.Width = 110;
        rc.Height = 242;
      }

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
        w = 110f / 242f * h;
        cx = (rc.Width - w) / 2;
        cy = 0;
      }
      else
      {
        if (rc.Width * 2.2f < rc.Height)
        {
          w = rc.Width;
          h = w * 2.2f;
          cx = 0;
          cy = (rc.Height - h) / 2 + 2;
        }
        else
        {
          h = rc.Height;
          w = h * 110f / 242f;
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

    protected void LowAlertWarningDrawing(Graphics gr, RectangleF rc, double alertValue, Color alertColor)
    {
      double minValue = this.LowValue;
      double maxValue = this.HighValue;

      PointF ptStart = new PointF(0, 0);
      PointF ptEnd = new PointF(0, 0);

      float drawRatio = (Math.Min(rc.Width, rc.Height)) / 75;
      if (drawRatio == 0.0)
        drawRatio = 1;
      float difference = 0;
      if ((int)this.HeaderLabel == 0)
      {
        difference = rc.Height - 33F * drawRatio;
      }
      else
      {
        difference = rc.Height - 23F * drawRatio;
      }

      tickPositionStart = new PointF((rc.X + rc.Width * 0.4f), (rc.Y + rc.Height * 0.9f));
      tickPositionEnd = new PointF((rc.X + rc.Width * 0.5f), (rc.Y + rc.Height * 0.9f));

      GraphicsPath pthAlertWarning = new GraphicsPath();

      if (alertValue > minValue)
      {
        ptStart.X = tickPositionStart.X;
        ptStart.Y = tickPositionStart.Y - (float)(alertValue - minValue) * difference / (float)(maxValue - minValue);
        ptEnd.X = tickPositionEnd.X;
        ptEnd.Y = tickPositionEnd.Y - (float)(alertValue - minValue) * difference / (float)(maxValue - minValue);
        pthAlertWarning.AddLine(ptStart, ptEnd);

        ptStart = ptEnd;
        ptEnd.X = tickPositionStart.X + rc.Width * 0.1f;
        ptEnd.Y = tickPositionStart.Y;
        pthAlertWarning.AddLine(ptStart, ptEnd);

        ptStart = ptEnd;
        ptEnd.X = tickPositionStart.X;
        ptEnd.Y = tickPositionStart.Y;
        pthAlertWarning.AddLine(ptStart, ptEnd);
      }

      pthAlertWarning.CloseFigure();
      SolidBrush brAlertWarning = new SolidBrush(alertColor);
      Pen penAlertWarning = new Pen(alertColor);
      gr.DrawPath(penAlertWarning, pthAlertWarning);
      gr.FillPath(brAlertWarning, pthAlertWarning);
    }

    protected void HighAlertWarningDrawing(Graphics gr, RectangleF rc, double alertValue, Color alertColor)
    {
      double minValue = this.LowValue;
      double maxValue = this.HighValue;

      PointF ptStart = new PointF(0, 0);
      PointF ptEnd = new PointF(0, 0);

      float drawRatio = (Math.Min(rc.Width, rc.Height)) / 75;
      if (drawRatio == 0.0)
        drawRatio = 1;
      float difference = 0;
      if ((int)this.HeaderLabel == 0)
      {
        difference = rc.Height - 33F * drawRatio;
      }
      else
      {
        difference = rc.Height - 23F * drawRatio;
      }

      tickPositionStart = new PointF((rc.X + rc.Width * 0.4f), (rc.Y + rc.Height * 0.9f));
      tickPositionEnd = new PointF((rc.X + rc.Width * 0.5f), (rc.Y + rc.Height * 0.9f));

      GraphicsPath pthAlertWarning = new GraphicsPath();

      if (alertValue < maxValue)
      {
        ptStart.X = tickPositionStart.X;
        ptStart.Y = tickPositionStart.Y - (float)(alertValue - minValue) * difference / (float)(maxValue - minValue);
        ptEnd.X = tickPositionEnd.X;
        ptEnd.Y = tickPositionEnd.Y - (float)(alertValue - minValue) * difference / (float)(maxValue - minValue);
        pthAlertWarning.AddLine(ptStart, ptEnd);

        ptStart = ptEnd;
        ptEnd.X = tickPositionStart.X + rc.Width * 0.1f;
        ptEnd.Y = tickPositionStart.Y - difference;
        pthAlertWarning.AddLine(ptStart, ptEnd);

        ptStart = ptEnd;
        ptEnd.X = tickPositionStart.X;
        ptEnd.Y = tickPositionStart.Y - difference;
        pthAlertWarning.AddLine(ptStart, ptEnd);
      }

      pthAlertWarning.CloseFigure();
      SolidBrush brAlertWarning = new SolidBrush(alertColor);
      Pen penAlertWarning = new Pen(alertColor);
      gr.DrawPath(penAlertWarning, pthAlertWarning);
      gr.FillPath(brAlertWarning, pthAlertWarning);
    }

    private void DrawBackground(Graphics gr)
    {
      RectangleF rc = new RectangleF();
      rc = CalculateSize(rc);
      SolidBrush br = new SolidBrush(this.Parent.BackColor);
      Pen pen = new Pen(this.Parent.BackColor);

      Rectangle rcTmp = new Rectangle((int)rc.X, (int)rc.Y, (int)rc.Width, (int)rc.Height);
      gr.DrawRectangle(pen, rcTmp);
      gr.FillRectangle(br, rcTmp);
    }

    private void DrawBody(Graphics gr)
    {
      RectangleF rc = new RectangleF();
      rc = CalculateDimensions(rc);

      Color backColor = this.BackgroundColor;
      SolidBrush brBack = new SolidBrush(backColor);
      gr.FillRectangle(brBack, rc);

      float widthToHeightDrawRatio = rc.Width / rc.Height;

      Color bodyColor1 = this.BodyColor1;
      Color bodyColor2 = this.BodyColor2;
      LinearGradientBrush brBody = new LinearGradientBrush(rc, bodyColor2, bodyColor1, LinearGradientMode.Vertical);
      gr.FillRectangle(brBody, rc);
    }

    private void DrawUnit(Graphics gr)
    {
      RectangleF rc = new RectangleF();
      rc = CalculateDimensions(rc);
      Color unitFontColor = this.TickColor;

      float drawRatio = (Math.Min(w, h)) / 75;
      if (drawRatio == 0.0)
        drawRatio = 1;

      gr.ScaleTransform(-1.0f, -1.0f);
      StringFormat stringFormat = new StringFormat(StringFormatFlags.DirectionVertical);
      stringFormat.Alignment = StringAlignment.Center;
      stringFormat.LineAlignment = StringAlignment.Center;
      string strUnit = this.Unit;
      Font font = new Font(this.Font.FontFamily, (float)(5F * drawRatio), FontStyle.Bold);
      SolidBrush brUnit = new SolidBrush(unitFontColor);
      if (ClientSize.Width > ClientSize.Height)
      {
        tx = (float)(-0.96 * rc.Width - (ClientSize.Width - rc.Width) / 2);
        ty = (float)(-0.50 * rc.Height);
        if ((int)this.HeaderLabel == 1)
        {
          ty = (float)(-0.475 * rc.Height);
        }
      }
      else
      {
        tx = (float)(-0.96 * rc.Width - (ClientSize.Width - rc.Width) / 2);
        ty = (float)(-0.50 * rc.Height - (ClientSize.Height - rc.Height) / 2);
        if ((int)this.HeaderLabel == 1)
        {
          ty = (float)(-0.475 * rc.Height - (ClientSize.Height - rc.Height) / 2);
        }
      }

      SizeF size = gr.MeasureString(strUnit, font);
      gr.DrawString(strUnit, font, brUnit, tx, ty, stringFormat);
      gr.ResetTransform();
    }

    private void DrawHeader(Graphics gr)
    {
      if ((int)this.HeaderLabel == 0)
      {
        RectangleF rc = new RectangleF();
        rc = CalculateDimensions(rc);
        Color headerFontColor = this.HeaderForeColor;

        float drawRatio = (Math.Min(rc.Width, rc.Height)) / 75;
        if (drawRatio == 0.0)
          drawRatio = 1;
        float widthToHeightDrawRatio = rc.Width / rc.Height;

        rc.X = rc.X + rc.Width * 0.01f;
        rc.Y = rc.Y + rc.Width * 0.01f;
        rc.Width = rc.Width * 0.98f;
        rc.Height = rc.Height * 0.07f;

        LinearGradientBrush brHeaderGround = new LinearGradientBrush(rc, Color.Gray, Color.Linen, 0f, true);
        brHeaderGround.SetSigmaBellShape(.5f, .6f);
        gr.FillRectangle(brHeaderGround, rc);

        StringFormat stringFormat = new StringFormat();
        stringFormat.Alignment = StringAlignment.Center;
        stringFormat.LineAlignment = StringAlignment.Center;

        string strHeader = this.Header;
        Font font = new Font(this.Font.FontFamily, (float)(5F * drawRatio));
        SolidBrush brHeader = new SolidBrush(headerFontColor);
        float tx = (float)(0.5 * ClientSize.Width);
        float ty = (float)(rc.Y + rc.Height / 2);
        SizeF size = gr.MeasureString(strHeader, font);
        gr.DrawString(strHeader, font, brHeader, tx, ty, stringFormat);

        Pen headerHousing = new Pen(Color.Black);
        gr.DrawRectangle(headerHousing, rc.X, rc.Y, rc.Width, rc.Height);
      }
    }

    private void DrawNumericValue(Graphics gr)
    {
      RectangleF rc = new RectangleF();
      rc = CalculateDimensions(rc);
      double currValue = this.Value;
      Color currentValueColor = Color.Black;
      Color currentValueBackColor = this.CurrentValueBackColor;

      float drawRatio = (Math.Min(rc.Width, rc.Height)) / 75;

      if (drawRatio == 0.0)
        drawRatio = 1;
      float widthToHeightDrawRatio = rc.Width / rc.Height;

      rc.X = rc.X + rc.Width * 0.01f;
      rc.Y = rc.Y + rc.Height * 0.92f;
      rc.Width = rc.Width * 0.98f; ;
      rc.Height = rc.Height * 0.07f;

      LinearGradientBrush brCurrValGround = new LinearGradientBrush(rc, Color.Gray, currentValueBackColor, 0f, true);
      brCurrValGround.SetSigmaBellShape(.5f, .6f);
      gr.FillRectangle(brCurrValGround, rc);

      Pen headerHousing = new Pen(Color.Black);
      gr.DrawRectangle(headerHousing, rc.X, rc.Y, rc.Width, rc.Height);

      StringFormat stringFormat = new StringFormat();
      stringFormat.Alignment = StringAlignment.Center;
      stringFormat.LineAlignment = StringAlignment.Center;

      int precision = this.Precision;
      double val = currValue;
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

      Font font = new Font(this.Font.FontFamily, (float)(6F * drawRatio));
      SolidBrush brCurrentValue = new SolidBrush(currentValueColor);
      float tx = (float)(0.5 * ClientSize.Width);
      float ty = (float)(rc.Y + rc.Height / 2f);
      gr.DrawString(str, font, brCurrentValue, tx, ty, stringFormat);
    }

    private void DrawValue(Graphics gr)
    {
      RectangleF rc = new RectangleF();
      rc = CalculateDimensions(rc);
      double minValue = this.LowValue;
      double maxValue = this.HighValue;
      double currValue = this.Value;
      double highAlertValue = this.HighAlarmValue;
      double highWarningValue = this.HighWarnValue;
      double lowAlertValue = this.LowAlarmValue;
      double lowWarningValue = this.LowWarnValue;

      PointF ptStart = new PointF(0, 0);
      PointF ptEnd = new PointF(0, 0);

      float drawRatio = (Math.Min(rc.Width, rc.Height)) / 75;
      if (drawRatio == 0.0)
        drawRatio = 1;
      float widthToHeightDrawRatio = rc.Width / rc.Height;
      float difference = 0;
      if ((int)this.HeaderLabel == 0)
      {
        difference = rc.Height - 33F * drawRatio;
      }
      else
      {
        difference = rc.Height - 23F * drawRatio;
      }

      float val = (float)(maxValue - minValue);
      val = (float)((100 * (currValue - minValue)) / val);
      val = ((float)(maxValue - minValue) * val) / 100;
      val = (float)minValue + val;

      if (currValue > (float)minValue)
      {
        tickPositionStart = new PointF((rc.X + rc.Width * 0.6f), (rc.Y + rc.Height * 0.9f));
        tickPositionEnd = new PointF((rc.X + rc.Width * 0.9f), (rc.Y + rc.Height * 0.9f));

        GraphicsPath pthValue = new GraphicsPath();

        ptStart.X = tickPositionStart.X;
        ptStart.Y = tickPositionStart.Y - (val - (float)minValue) * difference / (float)(maxValue - minValue);
        ptEnd.X = tickPositionEnd.X;
        ptEnd.Y = tickPositionEnd.Y - (val - (float)minValue) * difference / (float)(maxValue - minValue);
        pthValue.AddLine(ptStart, ptEnd);

        ptStart = ptEnd;
        ptEnd.X = tickPositionEnd.X;
        ptEnd.Y = tickPositionEnd.Y;
        pthValue.AddLine(ptStart, ptEnd);

        ptStart = ptEnd;
        ptEnd.X = tickPositionStart.X;
        ptEnd.Y = tickPositionStart.Y;
        pthValue.AddLine(ptStart, ptEnd);

        pthValue.CloseFigure();

        SolidBrush brValue = new SolidBrush(this.LevelColor);
        Pen penValue = new Pen(this.LevelColor);

        if (currValue < highWarningValue && currValue > lowWarningValue)
        {
          brValue = new SolidBrush(this.LevelColor);
          penValue = new Pen(this.LevelColor);
        }

        if (highWarningValue <= currValue && currValue < highAlertValue)
        {
          brValue = new SolidBrush(this.HighWarnColor);
          penValue = new Pen(this.HighWarnColor);
        }

        if (lowWarningValue >= currValue && currValue > lowAlertValue)
        {
          brValue = new SolidBrush(this.LowWarnColor);
          penValue = new Pen(this.LowWarnColor);
        }

        if (highAlertValue <= currValue)
        {
          brValue = new SolidBrush(this.HighAlarmColor);
          penValue = new Pen(this.HighAlarmColor);
        }

        if (lowAlertValue >= currValue)
        {
          brValue = new SolidBrush(this.LowAlarmColor);
          penValue = new Pen(this.LowAlarmColor);
        }
        gr.DrawPath(penValue, pthValue);
        gr.FillPath(brValue, pthValue);
      }
    }

    private void DrawDivisions(Graphics gr)
    {
      RectangleF rc = new RectangleF();
      rc = CalculateDimensions(rc);
      float scaleDivisions = this.ScaleDivisions;
      float scaleSubDivisions = this.ScaleSubDivisions;
      float minValue = this.LowValue;
      float maxValue = this.HighValue;
      float rulerValue = minValue;
      Color tickColor = this.TickColor;

      PointF ptStart = new PointF(0, 0);
      PointF ptEnd = new PointF(0, 0);

      float drawRatio = (Math.Min(rc.Width, rc.Height)) / 75;
      if (drawRatio == 0.0)
        drawRatio = 1;

      float widthToHeightDrawRatio = rc.Width / rc.Height;

      tickPositionStart = new PointF((rc.X + rc.Width * 0.4f), (rc.Y + rc.Height * 0.9f));
      tickPositionEnd = new PointF((rc.X + rc.Width * 0.9f), (rc.Y + rc.Height * 0.9f));

      PointF tmpPnt = tickPositionStart;
      for (int n = 0; n < scaleDivisions; n++)
      {
        float difference = 0;
        if ((int)this.HeaderLabel == 0)
        {
          difference = rc.Height - 33F * drawRatio;
        }
        else
        {
          difference = rc.Height - 23F * drawRatio;
        }
        float division = difference / (scaleDivisions - 1);

        ptStart.X = tickPositionStart.X;
        ptStart.Y = tickPositionStart.Y - n * division;
        ptEnd.X = tickPositionEnd.X;
        ptEnd.Y = tickPositionEnd.Y - n * division;

        Pen penTick = new Pen(tickColor, 1.5F * drawRatio);
        gr.DrawLine(penTick, ptStart, ptEnd);

        for (int j = 0; j <= scaleSubDivisions; j++)
        {
          float subDifference = 0;
          if ((int)this.HeaderLabel == 0)
          {
            subDifference = (rc.Height - 33F * drawRatio) / (scaleDivisions - 1);
          }
          else
          {
            subDifference = (rc.Height - 23F * drawRatio) / (scaleDivisions - 1);
          }
          float subDivision = subDifference / (scaleSubDivisions + 1);

          ptStart.X = tickPositionStart.X + 0.2f * w;
          ptStart.Y = tickPositionStart.Y - n * division - j * subDivision;
          ptEnd.X = tickPositionEnd.X;
          ptEnd.Y = tickPositionEnd.Y - n * division - j * subDivision;

          if (n == scaleDivisions - 1)
            break;

          Pen pen2 = new Pen(tickColor, 0.75F * drawRatio);
          gr.DrawLine(pen2, ptStart, ptEnd);
        }

        float val = rulerValue;
        String str = val.ToString("0.####");
        if (str.Length < 9)
        {
          Font font = new Font(this.Font.FontFamily, (float)(4F * drawRatio));
          SolidBrush brTick = new SolidBrush(tickColor);
          float tx = (float)(rc.X + rc.Width * 0.2f);
          float ty = (float)(tmpPnt.Y - n * division - 3F * drawRatio);
          SizeF size = gr.MeasureString(str, font);
          gr.DrawString(str, font, brTick, tx - (float)(size.Width * 0.5), ty);
        }

        rulerValue += (float)((maxValue - minValue) / (scaleDivisions - 1));
      }
    }

    private void DrawRangeBand(Graphics gr)
    {
      if ((int)this.RangeBand == 0)
      {
        RectangleF rc = new RectangleF();
        rc = CalculateDimensions(rc);
        double minValue = this.LowValue;
        double maxValue = this.HighValue;

        PointF ptStart = new PointF(0, 0);
        PointF ptEnd = new PointF(0, 0);

        float drawRatio = (Math.Min(rc.Width, rc.Height)) / 75;
        if (drawRatio == 0.0)
          drawRatio = 1;
        float difference = 0;
        if ((int)this.HeaderLabel == 0)
        {
          difference = rc.Height - 33F * drawRatio;
        }
        else
        {
          difference = rc.Height - 23F * drawRatio;
        }

        tickPositionStart = new PointF((rc.X + rc.Width * 0.4f), (rc.Y + rc.Height * 0.9f));
        tickPositionEnd = new PointF((rc.X + rc.Width * 0.5f), (rc.Y + rc.Height * 0.9f));

        GraphicsPath pthRangeBand = new GraphicsPath();

        ptStart.X = tickPositionStart.X;
        ptStart.Y = tickPositionStart.Y - (float)(maxValue - minValue) * difference / (float)(maxValue - minValue);
        ptEnd.X = tickPositionEnd.X;
        ptEnd.Y = tickPositionEnd.Y - (float)(maxValue - minValue) * difference / (float)(maxValue - minValue);
        pthRangeBand.AddLine(ptStart, ptEnd);

        ptStart = ptEnd;
        ptEnd.X = tickPositionStart.X + rc.Width * 0.1f;
        ptEnd.Y = tickPositionStart.Y;
        pthRangeBand.AddLine(ptStart, ptEnd);

        ptStart = ptEnd;
        ptEnd.X = tickPositionStart.X;
        ptEnd.Y = tickPositionStart.Y;
        pthRangeBand.AddLine(ptStart, ptEnd);

        pthRangeBand.CloseFigure();

        SolidBrush brLowAlert = new SolidBrush(this.RangeBandColor);
        Pen penLowAlert = new Pen(this.RangeBandColor);
        gr.DrawPath(penLowAlert, pthRangeBand);
        gr.FillPath(brLowAlert, pthRangeBand);
      }
    }

    private void DrawAlertWarning(Graphics gr)
    {
      RectangleF rc = new RectangleF();
      rc = CalculateDimensions(rc);
      double highAlertValue = this.HighAlarmValue;
      double highWarningValue = this.HighWarnValue;
      double lowAlertValue = this.LowAlarmValue;
      double lowWarningValue = this.LowWarnValue;
      Color highAlertColor = this.HighAlarmColor;
      Color highWarningColor = this.HighWarnColor;
      Color lowAlertColor = this.LowAlarmColor;
      Color lowWarningColor = this.LowWarnColor;

      HighAlertWarningDrawing(gr, rc, highWarningValue, highWarningColor);
      HighAlertWarningDrawing(gr, rc, highAlertValue, highAlertColor);
      LowAlertWarningDrawing(gr, rc, lowWarningValue, lowWarningColor);
      LowAlertWarningDrawing(gr, rc, lowAlertValue, lowAlertColor);
    }

    private void DrawNeedle(Graphics gr)
    {
      RectangleF rc = new RectangleF();
      rc = CalculateDimensions(rc);
      double minValue = this.LowValue;
      double maxValue = this.HighValue;
      double currValue = this.Value;
      Color needleColor = this.NeedleColor;

      PointF ptStart = new PointF(0, 0);
      PointF ptEnd = new PointF(0, 0);

      float drawRatio = (Math.Min(rc.Width, rc.Height)) / 75;
      if (drawRatio == 0.0)
        drawRatio = 1;
      float difference = 0;
      if ((int)this.HeaderLabel == 0)
      {
        difference = rc.Height - 33F * drawRatio;
      }
      else
      {
        difference = rc.Height - 23F * drawRatio;
      }

      float val = (float)(maxValue - minValue);
      val = (float)(100 * (currValue - minValue) / val);
      val = (float)(maxValue - minValue) * val / 100;
      val = (float)(minValue) + val;

      tickPositionStart = new PointF((rc.X + rc.Width * 0.4f), (rc.Y + rc.Height * 0.9f));
      tickPositionEnd = new PointF((rc.X + rc.Width * 0.9f), (rc.Y + rc.Height * 0.9f));

      Pen penNeedle = new Pen(needleColor, 1.5F * drawRatio);
      ptStart.X = tickPositionStart.X;
      ptStart.Y = tickPositionStart.Y - (val - (float)minValue) * difference / (float)(maxValue - minValue);
      ptEnd.X = tickPositionEnd.X;
      ptEnd.Y = tickPositionEnd.Y - (val - (float)minValue) * difference / (float)(maxValue - minValue);
      gr.DrawLine(penNeedle, ptStart, ptEnd);

      GraphicsPath pthNeedle = new GraphicsPath();
      Pen penNeedle1 = new Pen(needleColor, 0.5F * drawRatio);
      SolidBrush brNeedle = new SolidBrush(this.NeedleColor);

      if ((int)this.NeedleType == 0)
      {
        ptStart.X = ptStart.X - 4F * drawRatio;
        gr.DrawLine(penNeedle, ptStart, ptEnd);
      }
      else if ((int)this.NeedleType == 1)
      {
        ptStart.Y = ptStart.Y - 2F * drawRatio;
        ptEnd.X = ptStart.X - 4F * drawRatio;
        pthNeedle.AddLine(ptStart, ptEnd);

        ptStart = ptEnd;
        ptEnd.X = ptStart.X + 4F * drawRatio;
        ptEnd.Y = ptStart.Y + 2F * drawRatio;
      }
      else if ((int)this.NeedleType == 2)
      {
        ptStart.Y = ptStart.Y - 2F * drawRatio;
        ptEnd.X = ptStart.X - 4F * drawRatio;
        pthNeedle.AddLine(ptStart, ptEnd);

        ptStart = ptEnd;
        ptEnd.X = ptStart.X + 4F * drawRatio;
        ptEnd.Y = ptStart.Y + 2F * drawRatio;
        pthNeedle.AddLine(ptStart, ptEnd);

        ptStart = ptEnd;
        ptEnd.X = ptStart.X - 2F * drawRatio;
        ptEnd.Y = ptStart.Y - 2F * drawRatio;
      }
      else if ((int)this.NeedleType == 3)
      {
        ptEnd.X = ptStart.X - 4F * drawRatio;
        ptEnd.Y = ptStart.Y - 2F * drawRatio;
        pthNeedle.AddLine(ptStart, ptEnd);

        ptStart = ptEnd;
        ptEnd.Y = ptStart.Y + 4F * drawRatio;
      }
      else if ((int)this.NeedleType == 4)
      {
        ptEnd.X = ptStart.X - 4F * drawRatio;
        ptEnd.Y = ptStart.Y - 2F * drawRatio;
        pthNeedle.AddLine(ptStart, ptEnd);

        ptStart = ptEnd;
        ptEnd.X = ptStart.X + 2F * drawRatio;
        ptEnd.Y = ptStart.Y + 2F * drawRatio;
        pthNeedle.AddLine(ptStart, ptEnd);

        ptStart = ptEnd;
        ptEnd.X = ptStart.X - 2F * drawRatio;
        ptEnd.Y = ptStart.Y + 2F * drawRatio;
      }
      pthNeedle.AddLine(ptStart, ptEnd);
      pthNeedle.CloseFigure();
      gr.DrawPath(penNeedle1, pthNeedle);
      gr.FillPath(brNeedle, pthNeedle);
    }

    private void DrawGlass(Graphics gr)
    {
      if (this.ViewGlass == true)
      {
        RectangleF rc = new RectangleF();
        rc = CalculateDimensions(rc);
        Color clr1 = Color.FromArgb(0, 150, 150, 150);
        Color clr2 = Color.FromArgb(70, 222, 222, 222);
        LinearGradientBrush br1 = new LinearGradientBrush(rc, clr1, clr2, LinearGradientMode.Horizontal);
        br1.SetSigmaBellShape(.5f, 0.7f);
        gr.FillRectangle(br1, rc);
      }
    }
  }
}
