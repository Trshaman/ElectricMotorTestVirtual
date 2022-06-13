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
  /// Class for the analog meter control
  /// </summary>
  [ToolboxItem(true)]
  public partial class AnalogGauge : AnalogBase
  {
    #region Enumerator
    public enum AnalogMeterStyle
    {
      Circular = 0,
    };

    public enum HeaderShownHidden
    {
      On, Off,
    }
    #endregion

    #region Properties variables
    private AnalogMeterStyle meterStyle;
    private HeaderShownHidden headerLabel;
    private Color bodyColor;
    private Color needleColor;
    private Color tickColor;
    private Color unitColor;
    private bool viewGlass;
    private int scaleDivisions;
    private int scaleSubDivisions;
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
    protected PointF needleCenter;
    protected RectangleF drawRect;
    protected RectangleF glossyRect;
    protected RectangleF needleCoverRect;
    protected float startAngle;
    protected float endAngle;
    protected float drawRatio;
    #endregion

    #region Costructors
    public AnalogGauge()
    {
      // Initialization
      InitializeComponent();

      // Properties initialization
      this.WidthHeightRatio = 1f;
      this.meterStyle = AnalogMeterStyle.Circular;
      this.headerLabel = HeaderShownHidden.On;
      this.bodyColor = Color.LightYellow;
      this.needleColor = Color.Red;
      this.tickColor = Color.DarkRed;
      this.unitColor = Color.Black;
      this.LowAlarmColor = Color.DarkRed;
      this.LowWarnColor = Color.Gold;
      this.HighAlarmColor = Color.DarkRed;
      this.HighWarnColor = Color.Gold;
      this.viewGlass = true;
      this.scaleDivisions = 11;
      this.scaleSubDivisions = 5;
      this.startAngle = 135;
      this.endAngle = 405;
      this.highValue = 100;
      this.lowValue = 0;
      this.currValue = 0;
      this.Precision = 1;
      this.highAlarmValue = this.highValue;
      this.highWarnValue = this.highValue;
      this.lowWarnValue = this.lowValue;
      this.lowAlarmValue = this.lowValue;
      this.UIType = UserInterfaceUsingTypes.Indicator;
      // Set the styles for drawing
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.BackColor = Color.Transparent;
    }
    #endregion

    #region Properties
    [Category("Appearance"), Description("Style of the control")]
    public AnalogMeterStyle Type
    {
      get { return meterStyle; }
      set
      {
        meterStyle = value;
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

    [Category("Appearance"), Description("Color of the body of the control")]
    public Color BodyColor
    {
      get { return bodyColor; }
      set
      {
        bodyColor = value;
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

    [Category("Appearance"), Description("Show or hide the glass effect")]
    public bool ViewGlass
    {
      get { return viewGlass; }
      set
      {
        viewGlass = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Color of the scale of the control")]
    public Color TickColor
    {
      get { return tickColor; }
      set
      {
        tickColor = value;
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

    [Category("Appearance"), Description("Number of the scale divisions")]
    public int ScaleDivisions
    {
      get { return scaleDivisions; }
      set
      {
        scaleDivisions = value;
        if (scaleDivisions < 2)
        {
          scaleDivisions = 2;
        }
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

       float  val = value;
        if (val > highValue)
          val = highValue;
        if (val < lowValue)
          val = lowValue;
        base.Value = val;
        currValue = val;
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

    [Category("Behavior"), Description("Low alert value")]
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

    [Category("Behavior"), Description("Low warning value (must be larger than the low alert value)")]
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

    [Category("Behavior"), Description("High alert value")]
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

    [Category("Behavior"), Description("High warning value (must be smaller than the high alert value)")]
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
    public override HeaderPosition HeaderPosition
    {
      get { return base.HeaderPosition; }
    }

    [Browsable(false), Category("Appearance")]
    public override bool HeaderVisible
    {
      get { return base.HeaderVisible; }
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

    [Browsable(false)]
    public override Color BackColor
    {
      get { return base.BackColor; }
    }

    [Browsable(false)]
    public override Color ForeColor
    {
      get { return base.ForeColor; }
    }

    [Browsable(false), Category("Appearance")]
    public new BorderStyle BorderStyle
    {
      get { return base.BorderStyle; }
    }
    #endregion

    #region Public methods
    public float GetDrawRatio()
    {
      return this.drawRatio;
    }

    public float GetStartAngle()
    {
      return this.startAngle;
    }

    public float GetEndAngle()
    {
      return this.endAngle;
    }

    public PointF GetNeedleCenter()
    {
      return this.needleCenter;
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
        DrawLowAlert(g);
        DrawLowWarning(g);
        DrawHighAlert(g);
        DrawHighWarning(g);
        DrawDivisions(g);
        DrawHeader(g);
        DrawNumericValue(g);
        DrawNeedle(g);
        DrawNeedleCover(g);
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
        rc.Width = 100;
        rc.Height = 100;
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
        cx = (rc.Width - rc.Height) / 2;
        cy = 0;
        w = rc.Height - 1;
        h = rc.Height - 1;
      }
      else
      {
        cx = 0;
        cy = (int)(rc.Height - rc.Width) / 2;
        w = rc.Width - 1;
        h = rc.Width - 1;
      }
      rc.X = cx;
      rc.Y = cy;
      rc.Width = w;
      rc.Height = h;

      return rc;
    }

    public RectangleF CalculateNeedleDimensions(RectangleF rc)
    {
      rc = CalculateSize(rc);
      if (rc.Width > rc.Height)
      {
        cx = rc.Width / 2;
        cy = rc.Height / 2;
        w = rc.Height - 1;
        h = rc.Height - 1;
      }
      else
      {
        cx = rc.Width / 2;
        cy = rc.Height / 2;
        w = rc.Width - 1;
        h = rc.Width - 1;
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
      SolidBrush br = new SolidBrush(this.Parent.BackColor);
      Pen pen = new Pen(this.Parent.BackColor);

      Rectangle rcTmp = new Rectangle((int)rc.X, (int)rc.Y, (int)rc.Width, (int)rc.Height);
      gr.DrawRectangle(pen, rcTmp);
      gr.FillRectangle(br, rcTmp);
    }

    private void DrawBody(Graphics gr)
    {
      RectangleF rc = new RectangleF();
      rc =  CalculateDimensions(rc);

      Color bodyColor = this.BodyColor;
      Color cDark = ColorManager.StepColor(bodyColor, 20);
      LinearGradientBrush br1 = new LinearGradientBrush(rc, bodyColor, cDark, 45);
      gr.FillEllipse(br1, rc);

      float drawRatio = this.GetDrawRatio();
      if (drawRatio <= 0)
      {
        drawRatio = (Math.Min(w, h)) / 200;
      }
      RectangleF _rc = rc;
      _rc.X += 3 * drawRatio;
      _rc.Y += 3 * drawRatio;
      _rc.Width -= 6 * drawRatio;
      _rc.Height -= 6 * drawRatio;

      LinearGradientBrush br2 = new LinearGradientBrush(_rc, cDark, bodyColor, 45);
      gr.FillEllipse(br2, _rc);
    }

    private void DrawLowAlert(Graphics gr)
    {
      RectangleF rc = new RectangleF();
      rc = CalculateDimensions(rc);

      float startAngle = this.GetStartAngle();
      float endAngle = this.GetEndAngle();
      float minValue = this.LowValue;
      float maxValue = this.HighValue;
      float lowAlertValue = this.LowAlarmValue;
      Color lowAlertColor = this.LowAlarmColor;
      float stAngle = 0;
      float sweepAngle = 0;

      float gap = rc.Width * 0.05F;
      float rangeOfIndicator = maxValue - minValue;
      float angleRange = endAngle - startAngle;

      stAngle = startAngle;
      if (lowAlertValue > maxValue) sweepAngle = angleRange;
      else if (lowAlertValue < minValue) sweepAngle = 0;
      else sweepAngle = (angleRange * (lowAlertValue - minValue)) / (rangeOfIndicator);

      SolidBrush br = new SolidBrush(lowAlertColor);
      Pen pen = new Pen(lowAlertColor, rc.Width / 25);

      RectangleF rcTmp = new RectangleF(rc.X + gap, rc.Y + gap, rc.Width - gap * 2, rc.Height - gap * 2);
      gr.DrawArc(pen, rcTmp, stAngle, sweepAngle);
    }

    private void DrawLowWarning(Graphics gr)
    {
      RectangleF rc = new RectangleF();
      rc = CalculateDimensions(rc);

      float startAngle = this.GetStartAngle();
      float endAngle = this.GetEndAngle();
      float minValue = this.LowValue;
      float maxValue = this.HighValue;
      float lowWarningValue = this.LowWarnValue;
      Color lowWarningColor = this.LowWarnColor;
      float lowAlertValue = this.LowAlarmValue;
      float stAngle = 0;
      float sweepAngle = 0;

      float gap = rc.Width * 0.05F;
      float rangeOfIndicator = maxValue - minValue;
      float angleRange = endAngle - startAngle;

      stAngle = startAngle;
      if (lowWarningValue <= minValue)
      {
        sweepAngle = 0;
      }

      else if (lowWarningValue >= maxValue)
      {
        if (lowAlertValue <= minValue)
        {
          sweepAngle = angleRange;
        }
        else
        {
          if (lowAlertValue <= maxValue)
          {
            stAngle = startAngle + angleRange * (lowAlertValue - minValue) / rangeOfIndicator;
            sweepAngle = endAngle - stAngle;
          }
          else
          {
            stAngle = endAngle;
            sweepAngle = 0;
          }
        }
      }

      else
      {
        if (lowAlertValue <= minValue)
        {
          sweepAngle = angleRange * (lowWarningValue - minValue) / rangeOfIndicator;
        }
        else
        {
          if (lowAlertValue <= maxValue && lowWarningValue >= lowAlertValue)
          {
            stAngle = startAngle + angleRange * (lowAlertValue - minValue) / rangeOfIndicator;
            sweepAngle = angleRange * (lowWarningValue - lowAlertValue) / rangeOfIndicator;
          }
          else
          {
            stAngle = endAngle;
            sweepAngle = 0;
          }
        }
      }

      SolidBrush br = new SolidBrush(lowWarningColor);
      Pen pen = new Pen(lowWarningColor, rc.Width / 25);

      RectangleF rcTmp = new RectangleF(rc.X + gap, rc.Y + gap, rc.Width - gap * 2, rc.Height - gap * 2);
      gr.DrawArc(pen, rcTmp, stAngle, sweepAngle);
    }

    private void DrawHighAlert(Graphics gr)
    {
      RectangleF rc = new RectangleF();
      rc = CalculateDimensions(rc);

      float startAngle = this.GetStartAngle();
      float endAngle = this.GetEndAngle();
      float minValue = this.LowValue;
      float maxValue = this.HighValue;
      float highAlertValue = this.HighAlarmValue;
      Color highAlertColor = this.HighAlarmColor;
      float stAngle;
      float sweepAngle;

      float gap = rc.Width * 0.05F;
      float rangeOfIndicator = maxValue - minValue;
      float angleRange = endAngle - startAngle;

      stAngle = endAngle;
      if (highAlertValue < minValue) sweepAngle = -angleRange;
      else if (highAlertValue > maxValue) sweepAngle = 0;
      else sweepAngle = -angleRange * (maxValue - highAlertValue) / (rangeOfIndicator);

      SolidBrush br = new SolidBrush(highAlertColor);
      Pen pen = new Pen(highAlertColor, rc.Width / 25);

      RectangleF rcTmp = new RectangleF(rc.X + gap, rc.Y + gap, rc.Width - gap * 2, rc.Height - gap * 2);
      gr.DrawArc(pen, rcTmp, stAngle, sweepAngle);
    }

    private void DrawHighWarning(Graphics gr)
    {
      RectangleF rc = new RectangleF();
      rc = CalculateDimensions(rc);

      float startAngle = this.GetStartAngle();
      float endAngle = this.GetEndAngle();
      float minValue = this.LowValue;
      float maxValue = this.HighValue;
      float highWarningValue = this.HighWarnValue;
      Color highWarningColor = this.HighWarnColor;
      float highAlertValue = this.HighAlarmValue;
      float stAngle = 0;
      float sweepAngle = 0;

      float gap = rc.Width * 0.05F;
      float rangeOfIndicator = maxValue - minValue;
      float angleRange = endAngle - startAngle;

      stAngle = endAngle;
      if (highWarningValue >= maxValue)
      {
        sweepAngle = 0;
      }

      else if (highWarningValue <= minValue)
      {
        if (highAlertValue >= maxValue)
        {
          sweepAngle = -angleRange;
        }
        else
        {
          if (highAlertValue >= minValue)
          {
            stAngle = endAngle - angleRange * (maxValue - highAlertValue) / rangeOfIndicator;
            sweepAngle = startAngle - stAngle;
          }
          else
          {
            stAngle = endAngle;
            sweepAngle = 0;
          }
        }
      }

      else
      {
        if (highAlertValue >= maxValue)
        {
          sweepAngle = -angleRange * (maxValue - highWarningValue) / rangeOfIndicator;
        }
        else
        {
          if (highAlertValue >= minValue && highWarningValue <= highAlertValue)
          {
            stAngle = endAngle - angleRange * (maxValue - highAlertValue) / rangeOfIndicator;
            sweepAngle = -angleRange * (highAlertValue - highWarningValue) / rangeOfIndicator;
          }
          else
          {
            stAngle = endAngle;
            sweepAngle = 0;
          }
        }
      }

      SolidBrush br = new SolidBrush(highWarningColor);
      Pen pen = new Pen(highWarningColor, rc.Width / 25);

      RectangleF rcTmp = new RectangleF(rc.X + gap, rc.Y + gap, rc.Width - gap * 2, rc.Height - gap * 2);
      gr.DrawArc(pen, rcTmp, stAngle, sweepAngle);
    }

    private void DrawDivisions(Graphics gr)
    {
      RectangleF rc = new RectangleF();
      rc = CalculateNeedleDimensions(rc);

      float startAngle = this.GetStartAngle();
      float endAngle = this.GetEndAngle();
      float scaleDivisions = this.ScaleDivisions;
      float scaleSubDivisions = this.ScaleSubDivisions;
      float drawRatio = this.GetDrawRatio();
      double minValue = this.LowValue;
      double maxValue = this.HighValue;
      double lowAlertValue = this.LowAlarmValue;
      Color scaleColor = this.TickColor;

      float incr = Functions.GetRadian((endAngle - startAngle) / ((scaleDivisions - 1) * (scaleSubDivisions + 1)));
      float currentAngle = Functions.GetRadian(startAngle);
      float radius = (float)(rc.Width / 2 - (rc.Width * 0.08));
      float rulerValue = (float)minValue;

      if (drawRatio <= 0)
      {
        drawRatio = (Math.Min(w, h)) / 200;
      }
      Pen pen = new Pen(scaleColor, (2 * drawRatio));
      SolidBrush br = new SolidBrush(scaleColor);

      PointF ptStart = new PointF(0, 0);
      PointF ptEnd = new PointF(0, 0);
      int n = 0;
      for (; n < scaleDivisions; n++)
      {
        //Draw Thick Line
        ptStart.X = (float)(rc.X + radius * Math.Cos(currentAngle));
        ptStart.Y = (float)(rc.Y + radius * Math.Sin(currentAngle));
        ptEnd.X = (float)(rc.X + (radius - rc.Width / 20) * Math.Cos(currentAngle));
        ptEnd.Y = (float)(rc.Y + (radius - rc.Width / 20) * Math.Sin(currentAngle));
        gr.DrawLine(pen, ptStart, ptEnd);

        //Draw Strings
        if (drawRatio <= 0)
        {
          drawRatio = (Math.Min(w, h)) / 200;
        }
        Font font = new Font(this.Font.FontFamily, (float)(6F * drawRatio));

        float tx = (float)(rc.X + (radius - (20 * drawRatio)) * Math.Cos(currentAngle));
        float ty = (float)(rc.Y + (radius - (20 * drawRatio)) * Math.Sin(currentAngle));
        float val = rulerValue;
        String str = val.ToString("0.#");

        SizeF size = gr.MeasureString(str, font);
        gr.DrawString(str, font, br, tx - (float)(size.Width * 0.5), ty - (float)(size.Height * 0.5));

        rulerValue += (float)((maxValue - minValue) / (scaleDivisions - 1));

        if (n == scaleDivisions - 1)
          break;

        if (scaleDivisions <= 0)
          currentAngle += incr;
        else
        {
          for (int j = 0; j <= scaleSubDivisions; j++)
          {
            currentAngle += incr;
            ptStart.X = (float)(rc.X + radius * Math.Cos(currentAngle));
            ptStart.Y = (float)(rc.Y + radius * Math.Sin(currentAngle));
            ptEnd.X = (float)(rc.X + (radius - rc.Width / 50) * Math.Cos(currentAngle));
            ptEnd.Y = (float)(rc.Y + (radius - rc.Width / 50) * Math.Sin(currentAngle));
            gr.DrawLine(pen, ptStart, ptEnd);
          }
        }
      }
    }

    private void DrawHeader(Graphics gr)
    {
      if ((int)this.HeaderLabel == 0)
      {
        RectangleF rc = new RectangleF();
        rc = CalculateSize(rc);

        if (rc.Width > rc.Height)
        {
          w = rc.Width * 0.5f;
          h = rc.Height * 0.3f;
        }
        else
        {
          w = rc.Width * 0.5f;
          h = (rc.Height - rc.Width) / 2 + rc.Width * 0.3f;
        }

        Color headerFontColor = this.HeaderForeColor;

        float drawRatio = (Math.Min(rc.Width, rc.Height)) / 150;
        if (drawRatio == 0.0)
          drawRatio = 1;

        StringFormat stringFormat = new StringFormat();
        stringFormat.Alignment = StringAlignment.Center;
        stringFormat.LineAlignment = StringAlignment.Center;

        string strHeader = this.Header;
        Font font = new Font(this.Font.FontFamily, (float)(5F * drawRatio));
        SolidBrush brHeader = new SolidBrush(headerFontColor);
        float tx = w;
        float ty = h;
        gr.DrawString(strHeader, font, brHeader, tx , ty, stringFormat);
      }
    }

    private void DrawUnit(Graphics gr)
    {
      if ((int)this.HeaderLabel == 0)
      {
        RectangleF rc = new RectangleF();
        rc = CalculateSize(rc);

        if (rc.Width > rc.Height)
        {
          w = rc.Width * 0.5f;
          h = rc.Height * 0.35f;
        }
        else
        {
          w = rc.Width * 0.5f;
          h = (rc.Height - rc.Width) / 2 + rc.Width * 0.35f;
        }
        Color unitFontColor = this.TickColor;

        float drawRatio = (Math.Min(rc.Width, rc.Height)) / 150;
        if (drawRatio == 0.0)
          drawRatio = 1;

        StringFormat stringFormat = new StringFormat();
        stringFormat.Alignment = StringAlignment.Center;
        stringFormat.LineAlignment = StringAlignment.Center;

        string strUnit = this.Unit;
        Font font = new Font(this.Font.FontFamily, (float)(5F * drawRatio), FontStyle.Bold);
        SolidBrush brUnit = new SolidBrush(unitFontColor);
        float tx = w;
        float ty = h;
        gr.DrawString(strUnit, font, brUnit, tx, ty, stringFormat);
      }
    }

    private void DrawNumericValue(Graphics gr)
    {
      RectangleF rc = new RectangleF();
      rc = CalculateSize(rc);
      float drawRatio = (Math.Min(rc.Width, rc.Height)) / 140;
      if (drawRatio == 0.0)
        drawRatio = 1;

      if (rc.Width > rc.Height)
      {
        cx = (rc.Width - rc.Height) / 2 + 0.24f * rc.Height;
        cy = 0.78f * rc.Height;
        w = 0.52f * rc.Height;
        h = 0.07f * rc.Height;
        tx = (rc.Width - rc.Height) / 2 + 0.5f * rc.Height;
        ty = 0.82f * rc.Height;
      }
      else
      {
        cx = 0.24f * rc.Width;
        cy = (rc.Height - rc.Width) / 2 + 0.78f * rc.Width;
        w = 0.52f * rc.Width;
        h = 0.07f * rc.Width;
        tx = rc.Width / 2;
        ty = (rc.Height - rc.Width) / 2 + 0.82f * rc.Width;
      }
      rc.X = cx;
      rc.Y = cy;
      rc.Width = w;
      rc.Height = h;
      double currValue = this.Value;
      Color currentValueColor = Color.Black;
      Color currentValueBackColor = Color.FromArgb(238, 238, 224);

      LinearGradientBrush brCurrValGround = new LinearGradientBrush(rc, currentValueBackColor, currentValueBackColor, 0f, true);
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
      SizeF size = gr.MeasureString(str, font);
      SolidBrush brCurrentValue = new SolidBrush(currentValueColor);
      gr.DrawString(str, font, brCurrentValue, tx, ty, stringFormat);
    }

    private void DrawNeedle(Graphics gr)
    {
      RectangleF rc = new RectangleF();
      rc = CalculateNeedleDimensions(rc);

      double minValue = this.LowValue;
      double maxValue = this.HighValue;
      double currValue = this.Value;
      float startAngle = this.GetStartAngle();
      float endAngle = this.GetEndAngle();

      float radius = (float)(rc.Width / 2 - (rc.Width * 0.13));
      float val = (float)(maxValue - minValue);

      val = (float)((100 * (currValue - minValue)) / val);
      val = ((endAngle - startAngle) * val) / 100;
      val += startAngle;

      float angle = Functions.GetRadian(val);

      PointF ptStart = new PointF(0, 0);
      PointF ptEnd = new PointF(0, 0);

      GraphicsPath pth1 = new GraphicsPath();

      ptStart.X = cx;
      ptStart.Y = cy;
      angle = Functions.GetRadian(val + 10);
      ptEnd.X = (float)(cx + (rc.Width * .09F) * Math.Cos(angle));
      ptEnd.Y = (float)(cy + (rc.Width * .09F) * Math.Sin(angle));
      pth1.AddLine(ptStart, ptEnd);

      ptStart = ptEnd;
      angle = Functions.GetRadian(val);
      ptEnd.X = (float)(cx + radius * Math.Cos(angle));
      ptEnd.Y = (float)(cy + radius * Math.Sin(angle));
      pth1.AddLine(ptStart, ptEnd);

      ptStart = ptEnd;
      angle = Functions.GetRadian(val - 10);
      ptEnd.X = (float)(cx + (rc.Width * .09F) * Math.Cos(angle));
      ptEnd.Y = (float)(cy + (rc.Width * .09F) * Math.Sin(angle));
      pth1.AddLine(ptStart, ptEnd);

      pth1.CloseFigure();

      SolidBrush br = new SolidBrush(this.NeedleColor);
      Pen pen = new Pen(this.NeedleColor);
      gr.DrawPath(pen, pth1);
      gr.FillPath(br, pth1);
    }

    private void DrawNeedleCover(Graphics gr)
    {
      RectangleF rc = new RectangleF();
      rc = CalculateNeedleDimensions(rc);

      Color clr = this.NeedleColor;
      RectangleF _rcTmp1 = new RectangleF(cx - rc.Width * 0.05f, cy - rc.Height * 0.05f, rc.Width * 0.1f, rc.Height * 0.1f);
      Color clr1 = Color.FromArgb(70, clr);
      SolidBrush brTransp = new SolidBrush(clr1);

      gr.FillEllipse(brTransp, _rcTmp1);
      Color clr2 = ColorManager.StepColor(clr, 75);
      RectangleF _rcTmp2 = new RectangleF(cx - rc.Width * 0.025f, cy - rc.Height * 0.025f, rc.Width * 0.05f, rc.Height * 0.05f);
      LinearGradientBrush br1 = new LinearGradientBrush(_rcTmp2, clr, clr2, 45);

      gr.FillEllipse(br1, _rcTmp2);
    }

    private void DrawGlass(Graphics gr)
    {
      if (this.ViewGlass == true)
      {
        RectangleF rc = new RectangleF();
        rc = CalculateDimensions(rc);

        drawRatio = (Math.Min(rc.Width, rc.Height)) / 200;
        if (drawRatio == 0.0)
          drawRatio = 1;

        glossyRect.X = rc.X + 20 * drawRatio;
        glossyRect.Y = rc.Y + 10 * drawRatio;
        glossyRect.Width = rc.Width - 40 * drawRatio;
        glossyRect.Height = rc.Height / 2 + 30 * drawRatio;

        Color clr1 = Color.FromArgb(40, 200, 200, 200);
        Color clr2 = Color.FromArgb(0, 200, 200, 200);
        LinearGradientBrush br1 = new LinearGradientBrush(glossyRect, clr1, clr2, 45);
        gr.FillEllipse(br1, glossyRect);
      }
    }
  }
}