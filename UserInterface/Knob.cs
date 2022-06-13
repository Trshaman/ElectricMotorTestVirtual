//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Drawing.Drawing2D;
//using System.Diagnostics;
//using GlobalFunctions;
//using System.Globalization;
//using System.Threading;

//namespace UserInterface
//{
//  [ToolboxItem(true)]
//  public partial class Knob : AnalogBase
//  {
//    #region Enumerator


//    public enum TurnActions
//    {
//      OnlyInside, Everywhere,
//    }
//    #endregion

//    #region Properties Variables

//    private bool _headerVisible;
//    private bool _scaleBandVisible;
//    private TurnActions _turnAction;
//    private float _angle = 180;
//    private float _currentStep;

//    private float _highValue;
//    private float _lowValue;

//    private float _highStepFrequency;

//    private Color _handleColor;
//    private Color _scaleBandColor;
//    private PointF _middlePoint;
//    private int counter;
//    private Color _onColor;
//    private Color _offColor;

//    private float _fontRatio;
//    private RectangleF _rcHeader;
//    private RectangleF _rcDraw;
//    private RectangleF _rcKnop;
//    private RectangleF _rcKnopTurn; //Turning part of knop;
//    private RectangleF _rcHandle;
//    private Color _highValueColor = Color.Red;
//    private Color _lowValueColor = Color.Yellow;
//    private Color _knopColor = Color.LightGray;
//    private bool _mouseDownPressed;
//    private bool _mouseInside;


//    private TextBox txtVal = new TextBox();
//    Stopwatch stopwatch = new Stopwatch();
//    private Bitmap _powerOnImage;
//    private Bitmap _powerOffImage;



//    #endregion

//    #region Ctor
//    public Knob()
//    {
//      InitializeComponent();
//      this.WidthHeightRatio = 0.8f;

//      this.HeaderBackColor = System.Drawing.Color.Gray;
//      this.HandleColor = System.Drawing.Color.Sienna;
//      this.ScaleBandColor = System.Drawing.Color.Gray;
//      this.ScaleBandVisible = true;
//      this.ForeColor = System.Drawing.Color.Black;
//      this.HeaderBackColor = System.Drawing.Color.Maroon;
//      this.HighValueColor = System.Drawing.Color.Red;
//      this.LowValueColor = System.Drawing.Color.Yellow;
//      this.HeaderVisible = true;
//      this.HighStepFrequency = 10;
//      this.HighValue = 100;
//      this.LowValue = 0;
//      //this.Precision = 1;
//      this.MaxStep = 1f;
//      this.MinStep = 0.1f;
//      this.KnopColor = System.Drawing.Color.Brown;
//      //this.Value = 0;
//      this.ControlEnable = false;
//      this.Controls.Add(txtVal);
//      this.txtVal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Keypress);
//      this.txtVal.TextAlign = HorizontalAlignment.Right;
//      this.UIType = UserInterfaceUsingTypes.Control;
//      // Set the styles for drawing
//      this.SetStyle(ControlStyles.DoubleBuffer, true);
//      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
//      this.SetStyle(ControlStyles.UserPaint, true);
//      this.SetStyle(ControlStyles.ResizeRedraw, true);
//      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

//      txtVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//      this.MouseUp += (object sender, MouseEventArgs e) => { _mouseDownPressed = false; };
//      this.MouseLeave += (object sender, EventArgs e) => { _mouseInside = false; };
//      this.MouseEnter += (object sender, EventArgs e) => { _mouseInside = true; };

//      _powerOnImage = UserInterface.Properties.Resources.powerOn;
//      _powerOffImage = UserInterface.Properties.Resources.powerOff;
//      pictureBox1.Image = _powerOffImage;
//      pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
//      pictureBox1.Click += pictureBox1_Click;
//      pictureBox1.BackColor = Color.Transparent;

//    }

//    #endregion

//    #region Properties
//    #region Property Hiding
//    [Browsable(false)]
//    public override BackFillTypes BackFillType
//    {
//      get
//      {
//        return base.BackFillType;
//      }
//      set
//      {
//        base.BackFillType = value;
//      }
//    }

//    [Browsable(false)]
//    public override Color BackGradientColor
//    {
//      get
//      {
//        return base.BackGradientColor;
//      }
//      set
//      {
//        base.BackGradientColor = value;
//      }
//    }

//    [Browsable(false)]
//    public override LinearGradientMode BackGradientMode
//    {
//      get
//      {
//        return base.BackGradientMode;
//      }
//      set
//      {
//        base.BackGradientMode = value;
//      }
//    }

//    [Browsable(false)]
//    public override Font HeaderFont
//    {
//      get { return base.HeaderFont; }
//      set
//      {
//        base.HeaderFont = new Font(value.FontFamily, base.HeaderFont.Size);
//      }
//    }

//    [Browsable(false)]
//    public override HeaderPosition HeaderPosition
//    {
//      get
//      {
//        return base.HeaderPosition;
//      }
//      set
//      {
//        base.HeaderPosition = value;
//      }
//    }

//    [Browsable(false)]
//    public override Color HighAlarmColor
//    {
//      get
//      {
//        return base.HighAlarmColor;
//      }
//      set
//      {
//        base.HighAlarmColor = value;
//      }
//    }

//    [Browsable(false)]
//    public override float HighAlarmValue
//    {
//      get
//      {
//        return base.HighAlarmValue;
//      }
//      set
//      {
//        base.HighAlarmValue = value;
//      }
//    }

//    [Browsable(false)]
//    public override Color HighWarnColor
//    {
//      get
//      {
//        return base.HighWarnColor;
//      }
//      set
//      {
//        base.HighWarnColor = value;
//      }
//    }

//    [Browsable(false)]
//    public override float HighWarnValue
//    {
//      get
//      {
//        return base.HighWarnValue;
//      }
//      set
//      {
//        base.HighWarnValue = value;
//      }
//    }

//    [Browsable(false)]
//    public override Color LowAlarmColor
//    {
//      get
//      {
//        return base.LowAlarmColor;
//      }
//      set
//      {
//        base.LowAlarmColor = value;
//      }
//    }

//    [Browsable(false)]
//    public override float LowAlarmValue
//    {
//      get
//      {
//        return base.LowAlarmValue;
//      }
//      set
//      {
//        base.LowAlarmValue = value;
//      }
//    }

//    [Browsable(false)]
//    public override Color LowWarnColor
//    {
//      get
//      {
//        return base.LowWarnColor;
//      }
//      set
//      {
//        base.LowWarnColor = value;
//      }
//    }

//    [Browsable(false)]
//    public override float LowWarnValue
//    {
//      get
//      {
//        return base.LowWarnValue;
//      }
//      set
//      {
//        base.LowWarnValue = value;
//      }
//    }
//    #endregion

//    //public override int Precision
//    //{
//    //  get
//    //  {
//    //    return base.Precision;
//    //  }
//    //  set
//    //  {
//    //    base.Precision = value;
//    //   // Value = Value;
//    //  }
//    //}

//    [Category("Appearance"), Description("Show / Hide scale band")]
//    public bool ScaleBandVisible
//    {
//      get { return _scaleBandVisible; }
//      set
//      {
//        _scaleBandVisible = value;
//        Invalidate();
//      }
//    }

//    [Category("Behavior"), Description("OnlyInside: Knob can be turned when mouse is inside the knob. Everywhere: Knob can be turned regardless the mouse position.")]
//    public TurnActions TurnAction
//    {
//      get { return _turnAction; }
//      set
//      {
//        _turnAction = value;
//        Invalidate();
//      }
//    }

//    [Browsable(false)]
//    public override float Value
//    {
//      get { return base.Value; }
//      set
//      {
//        base.Value = (float)Math.Round(Functions.MaxMinControl(value, _highValue, _lowValue), Precision);
//        if (!DesignMode)
//          CrossThreadHelper.SetControlOfText(FormatNumber(value, Precision, Thread.CurrentThread.CurrentCulture.NumberFormat), txtVal);
//      }
//    }

//    [Category("Behavior"), Description("Should be greater than or equal to the MinFrequency")]
//    public float HighStepFrequency
//    {
//      get { return _highStepFrequency; }
//      set
//      {
//        _highStepFrequency = value;
//        Invalidate();
//      }
//    }

//    [Category("Behavior"), Description("Turning speed if greater than HighStepFrequency value change step equal to maxStep")]
//    public float MaxStep { get; set; }

//    [Category("Behavior"), Description("Turning speed if smaller than HighStepFrequency value change step equal to minStep")]
//    public float MinStep { get; set; }

//    [Category("Behavior")]
//    public override float HighValue
//    {
//      get
//      {
//        return _highValue;
//      }
//      set
//      {
//        if (value > _lowValue)
//        {
//          _highValue = value;
//          if (Value > _highValue)
//            Value = _highValue;
//          Invalidate();
//        }
//      }
//    }

//    [Category("Behavior")]
//    public override float LowValue
//    {
//      get
//      {
//        return _lowValue;
//      }
//      set
//      {
//        if (value < _highValue)
//        {
//          _lowValue = value;
//          if (Value < _lowValue)
//            Value = _lowValue;
//          Invalidate();
//        }
//      }
//    }

//    [Category("Appearance"), Description("Knob handle color")]
//    public Color HandleColor
//    {
//      get { return _handleColor; }
//      set
//      {
//        _handleColor = value;
//        Invalidate();
//      }
//    }



//    [Category("Appearance"), Description("Color of the range band")]
//    public Color ScaleBandColor
//    {
//      get { return _scaleBandColor; }
//      set
//      {
//        _scaleBandColor = value;
//        Invalidate();
//      }
//    }

//    [Category("Appearance"), Description("Color of the high value band")]
//    public Color HighValueColor
//    {
//      get { return _highValueColor; }
//      set { _highValueColor = value; this.Invalidate(); }
//    }

//    public Color LowValueColor
//    {
//      get { return _lowValueColor; }
//      set { _lowValueColor = value; this.Invalidate(); }
//    }



//    public Color KnopColor
//    {
//      get { return _knopColor; }
//      set { _knopColor = value; Invalidate(); }
//    }

//    public override bool DesignModeActive
//    {
//      get
//      {
//        return base.DesignModeActive;
//      }
//      set
//      {
//        base.DesignModeActive = value;
//        txtVal.Enabled = !value;
//        pictureBox1.Enabled = !value;

//      }
//    }

//    public override bool ControlEnable
//    {
//      get
//      {
//        return base.ControlEnable;
//      }
//      set
//      {
//        base.ControlEnable = value;
//        pictureBox1.Image = ControlEnable ? _powerOnImage : _powerOffImage;
//        if (UserLevel == User.UserLevels.Operator)
//          txtVal.Enabled = false;
//      }
//    }

//    #endregion

//    #region Events Delegates
//    protected override void OnSizeChanged(EventArgs e)
//    {
//      if (this.Width == 0 || this.Height == 0)
//        return;
//      base.OnSizeChanged(e);
//      CalculateDimensions();
//      PlaceButtons();
//    }
//    protected override void OnPaint(PaintEventArgs e)
//    {
//      if (this.Width == 0 || this.Height == 0)
//        return;
//      e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

//      if (DesignMode)
//      {
//        CalculateDimensions();
//        PlaceButtons();
//      }
//      //// Draw the control

//      RectangleF rcKnop = _rcKnop;
//      DrawHeader(e.Graphics, _rcHeader, _fontRatio, HeaderForeColor);
//      DrawScaleBand(e.Graphics, ref rcKnop);
//      _rcKnopTurn = DrawKnob(e.Graphics, rcKnop, _rcHandle);

//    }


//    #endregion

//    #region Events

//    private void pictureBox1_Click(object sender, EventArgs e)
//    {
//      if ((SystemMode == SystemModes.Manual || SystemMode == SystemModes.Automatic) && UserLevel == User.UserLevels.Admin)
//        ControlEnable = !ControlEnable;
//      else
//        ControlEnable = false;
//    }

//    private void Knob_MouseDown(object sender, MouseEventArgs e)
//    {
//      if (e.Button == MouseButtons.Left)
//      {
//        this.label1.Focus();
//        _mouseDownPressed = _rcHandle.Contains(e.Location);
//      }
//    }

//    private void Knob_MouseMove(object sender, MouseEventArgs e)
//    {
//      if (_mouseDownPressed && !DesignModeActive)
//      {

//        if (TurnAction == TurnActions.Everywhere || (TurnAction == TurnActions.OnlyInside && _mouseInside))
//        {
//          float rotation, actualAngle;
//          actualAngle = (float)(Math.Atan2(e.Y - _middlePoint.Y, e.X - _middlePoint.X) / Math.PI * 180f) % 360f;
//          rotation = ((actualAngle - _angle) * 120) % 360;
//          _angle = actualAngle;

//          counter++;
//          if (counter > 2)
//          {
//            CalculateCurrentValue(rotation, Value);
//            //this.Value = rotation;
//            counter = 0;
//          }
//          _rcHandle = CalculateHandleRc(_rcKnop, _angle);
//          Invalidate();
//        }
//      }

//    }

//    private void Knob_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
//    {
//      if (_rcKnopTurn.Contains(e.Location))
//      {
//        _angle += (e.Delta / SystemInformation.MouseWheelScrollDelta) * 10;

//        _angle %= 360;
//        CalculateCurrentValue(e.Delta, Value);
//        _rcHandle = CalculateHandleRc(_rcKnop, _angle);
//      }
//      Invalidate();
//    }

//    private void txt_Keypress(object sender, KeyPressEventArgs e)
//    {
//      Functions.NumericFloatInput(ref e, '.', txtVal.Text, txtVal.SelectionStart);

//      if (e.KeyChar == (char)Keys.Return)
//      {
//        label1.Focus();
//        if (Functions.InRange((float)Functions.ToDouble(txtVal.Text), HighValue, LowValue))
//          this.Value = (float)Functions.ToDouble(txtVal.Text);//  Functions.MaxMinControl((float)Functions.ToDouble(txtVal.Text), HighValue, LowValue);
//        else
//          txtVal.Text = this.Value.ToString();
//      }
//    }
//    #endregion

//    #region Functions

//    private void CalculateDimensions()
//    {
//      _rcDraw = ClientRectangle;
//      if (BorderStyle == System.Windows.Forms.BorderStyle.Fixed3D)
//        _rcDraw.Inflate(-SystemInformation.Border3DSize.Width, -SystemInformation.Border3DSize.Height);
//      else if (BorderStyle == System.Windows.Forms.BorderStyle.FixedSingle)
//        _rcDraw.Inflate(-SystemInformation.BorderSize.Width, -SystemInformation.BorderSize.Height);
//      _fontRatio = (Math.Min(_rcDraw.Width, _rcDraw.Height)) / 75;
//      if (_fontRatio == 0.0)
//        _fontRatio = 1;
//      _rcHeader = _rcDraw;
//      _rcHeader.Height *= 0.1f;
//      _rcHeader.Width *= 0.990f;
//      _rcKnop = _rcDraw;
//      _rcKnop.Height = _rcDraw.Height - 2f * _rcHeader.Height;
//      _rcKnop.Width = _rcKnop.Height;
//      _rcKnop.X += (_rcDraw.Width - _rcKnop.Width) / 2;
//      _rcKnop.Y += _rcHeader.Height;
//      RectangleF rr = _rcKnop;
//      rr.Inflate(-rr.Width * 0.4f, -rr.Width * 0.4f);
//      pictureBox1.Size = rr.Size.ToSize();
//      pictureBox1.Location = new Point((int)rr.Location.X, (int)rr.Location.Y);
//      //pictureBox1.Width = pictureBox1.Height = (int)(_rcKnop.Width / 4f);
//      //pictureBox1.Left= 
//      _middlePoint = new PointF(_rcKnop.Left + _rcKnop.Width / 2f, _rcKnop.Top + _rcKnop.Height / 2f);
//      _rcHandle = CalculateHandleRc(_rcKnop, _angle);
//    }

//    private string FormatNumber(float nmbr, int prec, NumberFormatInfo nfi)
//    {
//      if (nfi != null)
//      {
//        string sep = nfi.NumberGroupSeparator;
//        int dig = nfi.NumberDecimalDigits;
//        nfi.NumberGroupSeparator = "";
//        nfi.NumberDecimalDigits = prec;
//        string val = Math.Round(nmbr, prec).ToString("N", nfi);
//        nfi.NumberGroupSeparator = sep;
//        nfi.NumberDecimalDigits = dig;
//        return val;
//      }
//      else
//        return Math.Round(nmbr, prec).ToString();
//    }

//    private void CalculateCurrentValue(float rotation, float currentValue)
//    {
//      float temp;
//      _currentStep = CalculateStep(1 / stopwatch.Elapsed.TotalSeconds, HighStepFrequency, MaxStep, MinStep);
//      stopwatch.Restart();
//      if (rotation < 0)
//        temp = currentValue - _currentStep;
//      else
//        temp = currentValue + _currentStep;
//      this.Value = (float)(Math.Round(Functions.MaxMinControl(temp, HighValue, LowValue), Precision));
//    }

//    private float CalculateStep(double actualfrequency, float highStepFrequency, float highStep, float lowStep)
//    {
//      if (actualfrequency > highStepFrequency)
//        return highStep;
//      else
//        return lowStep;
//    }

//    private void DrawHeader(Graphics gr, RectangleF headerRectangle, float fontRatio, Color headerFontColor)
//    {
//      const float unitRatio = 0.2f;

//      Font font = Functions.GetFontForControlHeight((int)headerRectangle.Height, Font);
//      SolidBrush brHeader = new SolidBrush(headerFontColor);
//      SizeF strSize = gr.MeasureString(Header, font);

//      float tx = headerRectangle.X + (headerRectangle.Width - unitRatio * headerRectangle.Width - strSize.Width) / 2;
//      float ty = headerRectangle.Y + (headerRectangle.Height - strSize.Height) / 2;

//      Pen penHeaderBorder = new Pen(Functions.CalculateGradientLight(HeaderBackColor, 400f));
//      gr.DrawRectangle(penHeaderBorder, headerRectangle.X, headerRectangle.Y, headerRectangle.Width, headerRectangle.Height);

//      LinearGradientBrush brGround = new LinearGradientBrush(headerRectangle, HeaderBackColor, Functions.CalculateGradientLight(HeaderBackColor, 400f), 0f, true);

//      brGround.SetSigmaBellShape(.5f, .6f);
//      gr.FillRectangle(brGround, headerRectangle);
//      gr.DrawString(Header, font, brHeader, tx, ty);


//      PointF lineStart = new PointF(headerRectangle.X + headerRectangle.Width * (1 - unitRatio), headerRectangle.Y);
//      PointF lineEnd = new PointF(lineStart.X, headerRectangle.Y + headerRectangle.Height);
//      strSize = gr.MeasureString(Unit, font);
//      tx = lineStart.X + (headerRectangle.Width * unitRatio - strSize.Width) / 2f;
//      ty = headerRectangle.Y + (headerRectangle.Height - strSize.Height) / 2f;
//      gr.DrawString(Unit, font, brHeader, tx, ty);
//      gr.DrawLine(penHeaderBorder, lineStart, lineEnd);


//      brHeader.Dispose();
//      penHeaderBorder.Dispose();
//      brGround.Dispose();
//    }

//    private RectangleF DrawKnob(Graphics gr, RectangleF rcKnop, RectangleF rcHandle)
//    {
//      rcKnop.Inflate(-rcKnop.Width * 0.02f, -rcKnop.Width * 0.02f);
//      Brush brBackCircle = new LinearGradientBrush(rcKnop, KnopColor, Functions.CalculateGradientDark(KnopColor, 200f), LinearGradientMode.ForwardDiagonal);
//      Pen penBackCircle = new Pen(brBackCircle);
//      gr.DrawEllipse(penBackCircle, rcKnop);
//      gr.FillEllipse(brBackCircle, rcKnop);
//      brBackCircle.Dispose();
//      penBackCircle.Dispose();

//      rcKnop.Inflate(-0.1f * rcKnop.Width, -0.1f * rcKnop.Width);

//      GraphicsPath pth = new GraphicsPath();
//      pth.AddEllipse(rcKnop);
//      PathGradientBrush brs = new PathGradientBrush(pth);
//      brs.CenterColor = Functions.CalculateGradientDark(KnopColor, 200f);
//      brs.SurroundColors = new Color[] { KnopColor };
//      Pen penKnobCircle = new Pen(KnopColor); //Functions.CalculateGradientDark(KnopColor, 500f));
//      gr.DrawEllipse(penKnobCircle, rcKnop);
//      gr.FillEllipse(brs, rcKnop);
//      penKnobCircle.Dispose();

//      Brush brHandleCircle = new LinearGradientBrush(rcKnop, _handleColor, Functions.CalculateGradientDark(_handleColor, 150f), _angle);
//      Pen penHandleCircle = new Pen(Functions.CalculateGradientDark(_handleColor, 200f));
//      gr.DrawEllipse(penHandleCircle, rcHandle);
//      gr.FillEllipse(brHandleCircle, rcHandle);
//      brHandleCircle.Dispose();
//      penBackCircle.Dispose();
//      pth.Dispose();
//      brs.Dispose();
//      return rcKnop;
//    }

//    private RectangleF CalculateHandleRc(RectangleF rcKnop, float angle)
//    {
//      float r = 0.5f * rcKnop.Height / 2f;
//      float xm = rcKnop.Left + rcKnop.Height / 2f;
//      float ym = rcKnop.Top + rcKnop.Height / 2f;
//      rcKnop.Inflate(-0.44f * rcKnop.Width, -0.44f * rcKnop.Width);
//      float rHandle = rcKnop.Width / 2f;
//      rcKnop.X = r * (float)Math.Cos(angle * Math.PI / 180f) + xm - rHandle;
//      rcKnop.Y = r * (float)Math.Sin(angle * Math.PI / 180f) + ym - rHandle;
//      return rcKnop;
//    }

//    private void DrawScaleBand(Graphics gr, ref RectangleF rcKnop)
//    {
//      if (ScaleBandVisible)
//      {
//        float startAngle = 180;
//        float endAngle = 540;
//        float sweepAngle;
//        float rangeOfScaleBand = _highValue - _lowValue;
//        float angleRange = endAngle - startAngle;
//        startAngle = (float)(Math.Round((decimal)((Value - _lowValue) * angleRange / rangeOfScaleBand + startAngle)));
//        sweepAngle = 540 - startAngle;
//        rcKnop.Inflate(-rcKnop.Width * 0.06f, -rcKnop.Width * 0.06f);
//        float gap = rcKnop.Width / 50f;

//        PointF[] pts = new PointF[6];
//        float cx = rcKnop.X + rcKnop.Width / 2;
//        float cy = rcKnop.Y + rcKnop.Height / 2;
//        float r = rcKnop.Width / 1.4f;
//        double theta = Math.PI;
//        double dtheta = 4 * Math.PI / 10;
//        for (int i = 0; i < pts.Length; i++)
//        {
//          pts[i].X = (float)(cx + r * Math.Cos(theta));
//          pts[i].Y = (float)(cy + r * Math.Sin(theta));
//          theta += dtheta;
//        }

//        using (PathGradientBrush path_brush = new PathGradientBrush(pts))
//        {
//          // Define the center and surround colors.
//          path_brush.CenterPoint = new PointF(cx, cy);
//          path_brush.CenterColor = Color.White;
//          path_brush.SurroundColors = Functions.InterpolateColors(LowValueColor, HighValueColor, 6);
//          Pen pen = new Pen(path_brush, rcKnop.Width * 0.06f);
//          gr.DrawArc(pen, rcKnop, 180f, 360f);
//        }

//        Pen penCover = new Pen(ScaleBandColor, rcKnop.Width * 0.06f);

//        gr.DrawArc(penCover, rcKnop, startAngle, sweepAngle);

//        rcKnop.Inflate(-gap, -gap);
//      }
//    }

//    private void PlaceButtons()
//    {
//      if (_rcDraw.Width > 10 && _rcDraw.Height > 20)
//      {
//        RectangleF rcButtons = new RectangleF();
//        rcButtons.X = _rcKnop.Width * 0.05f;
//        rcButtons.Y = _rcDraw.Y + _rcKnop.Bottom;
//        rcButtons.Width = _rcKnop.Width * 0.9f;
//        rcButtons.Height = (_rcDraw.Height - rcButtons.Y);
//        this.txtVal.Width = (int)(rcButtons.Width);

//        this.txtVal.Font = Functions.GetFontForControlHeight((int)rcButtons.Height, this.Font);

//        this.txtVal.Location = new Point((int)rcButtons.X, (int)(rcButtons.Y));
//      }
//    }
//    #endregion
//  }
//}

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
using System.Diagnostics;
using GlobalFunctions;
using System.Globalization;
using System.Threading;

namespace UserInterface
{
  [ToolboxItem(true)]
  public partial class Knob : AnalogBase
  {
    #region Enumerator


    public enum TurnActions
    {
      OnlyInside, Everywhere,
    }
    #endregion

    #region Properties Variables

    private bool _headerVisible;
    private bool _scaleBandVisible;
    private TurnActions _turnAction;
    private float _angle = 180;
    private float _currentStep;

    private float _highValue;
    private float _lowValue;

    private float _highStepFrequency;

    private Color _handleColor;
    private Color _scaleBandColor;
    private PointF _middlePoint;
    private int counter;
    private Color _onColor;
    private Color _offColor;

    private float _fontRatio;
    private RectangleF _rcHeader;
    private RectangleF _rcDraw;
    private RectangleF _rcKnop;
    private RectangleF _rcKnopTurn; //Turning part of knop;
    private RectangleF _rcHandle;
    private Color _highValueColor = Color.Red;
    private Color _lowValueColor = Color.Yellow;
    private Color _knopColor = Color.LightGray;
    private bool _mouseDownPressed;
    private bool _mouseInside;


    private TextBox txtVal = new TextBox();
    Stopwatch stopwatch = new Stopwatch();
    private Bitmap _powerOnImage;
    private Bitmap _powerOffImage;



    #endregion

    #region Ctor
    public Knob()
    {
      InitializeComponent();
      this.WidthHeightRatio = 0.8f;

      this.HeaderBackColor = System.Drawing.Color.Gray;
      this.HandleColor = System.Drawing.Color.Sienna;
      this.ScaleBandColor = System.Drawing.Color.Gray;
      this.ScaleBandVisible = true;
      this.ForeColor = System.Drawing.Color.Black;
      this.HeaderBackColor = System.Drawing.Color.Maroon;
      this.HighValueColor = System.Drawing.Color.Red;
      this.LowValueColor = System.Drawing.Color.Yellow;
      this.HeaderVisible = true;
      this.HighStepFrequency = 10;
      this.HighValue = 100;
      this.LowValue = 0;
      //this.Precision = 1;
      this.MaxStep = 1f;
      this.MinStep = 0.1f;
      this.KnopColor = System.Drawing.Color.Brown;
      //this.Value = 0;
      this.ControlEnable = false;
      this.Controls.Add(txtVal);
      this.txtVal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Keypress);
      this.txtVal.TextAlign = HorizontalAlignment.Right;
      this.UIType = UserInterfaceUsingTypes.Control;
      // Set the styles for drawing
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

      txtVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.MouseUp += (object sender, MouseEventArgs e) => { _mouseDownPressed = false; };
      this.MouseLeave += (object sender, EventArgs e) => { _mouseInside = false; };
      this.MouseEnter += (object sender, EventArgs e) => { _mouseInside = true; };

      _powerOnImage = UserInterface.Properties.Resources.powerOn;
      _powerOffImage = UserInterface.Properties.Resources.powerOff;
      pictureBox1.Image = _powerOffImage;
      pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      pictureBox1.Click += pictureBox1_Click;
      pictureBox1.BackColor = Color.Transparent;

    }

    #endregion

    #region Properties
    #region Property Hiding
    [Browsable(false)]
    public override BackFillTypes BackFillType
    {
      get
      {
        return base.BackFillType;
      }
      set
      {
        base.BackFillType = value;
      }
    }

    [Browsable(false)]
    public override Color BackGradientColor
    {
      get
      {
        return base.BackGradientColor;
      }
      set
      {
        base.BackGradientColor = value;
      }
    }

    [Browsable(false)]
    public override LinearGradientMode BackGradientMode
    {
      get
      {
        return base.BackGradientMode;
      }
      set
      {
        base.BackGradientMode = value;
      }
    }

    [Browsable(false)]
    public override Font HeaderFont
    {
      get { return base.HeaderFont; }
      set
      {
        base.HeaderFont = new Font(value.FontFamily, base.HeaderFont.Size);
      }
    }

    [Browsable(false)]
    public override HeaderPosition HeaderPosition
    {
      get
      {
        return base.HeaderPosition;
      }
      set
      {
        base.HeaderPosition = value;
      }
    }

    [Browsable(false)]
    public override Color HighAlarmColor
    {
      get
      {
        return base.HighAlarmColor;
      }
      set
      {
        base.HighAlarmColor = value;
      }
    }

    [Browsable(false)]
    public override float HighAlarmValue
    {
      get
      {
        return base.HighAlarmValue;
      }
      set
      {
        base.HighAlarmValue = value;
      }
    }

    [Browsable(false)]
    public override Color HighWarnColor
    {
      get
      {
        return base.HighWarnColor;
      }
      set
      {
        base.HighWarnColor = value;
      }
    }

    [Browsable(false)]
    public override float HighWarnValue
    {
      get
      {
        return base.HighWarnValue;
      }
      set
      {
        base.HighWarnValue = value;
      }
    }

    [Browsable(false)]
    public override Color LowAlarmColor
    {
      get
      {
        return base.LowAlarmColor;
      }
      set
      {
        base.LowAlarmColor = value;
      }
    }

    [Browsable(false)]
    public override float LowAlarmValue
    {
      get
      {
        return base.LowAlarmValue;
      }
      set
      {
        base.LowAlarmValue = value;
      }
    }

    [Browsable(false)]
    public override Color LowWarnColor
    {
      get
      {
        return base.LowWarnColor;
      }
      set
      {
        base.LowWarnColor = value;
      }
    }

    [Browsable(false)]
    public override float LowWarnValue
    {
      get
      {
        return base.LowWarnValue;
      }
      set
      {
        base.LowWarnValue = value;
      }
    }
    #endregion

    //public override int Precision
    //{
    //  get
    //  {
    //    return base.Precision;
    //  }
    //  set
    //  {
    //    base.Precision = value;
    //   // Value = Value;
    //  }
    //}

    [Category("Appearance"), Description("Show / Hide scale band")]
    public bool ScaleBandVisible
    {
      get { return _scaleBandVisible; }
      set
      {
        _scaleBandVisible = value;
        Invalidate();
      }
    }

    [Category("Behavior"), Description("OnlyInside: Knob can be turned when mouse is inside the knob. Everywhere: Knob can be turned regardless the mouse position.")]
    public TurnActions TurnAction
    {
      get { return _turnAction; }
      set
      {
        _turnAction = value;
        Invalidate();
      }
    }

    [Browsable(false)]
    public override float Value
    {
      get { return base.Value; }
      set
      {
        base.Value = (float)Math.Round(Functions.MaxMinControl(value, _highValue, _lowValue), Precision);
        if (!DesignMode)
          CrossThreadHelper.SetControlOfText(FormatNumber(value, Precision, Thread.CurrentThread.CurrentCulture.NumberFormat), txtVal);
      }
    }

    [Category("Behavior"), Description("Should be greater than or equal to the MinFrequency")]
    public float HighStepFrequency
    {
      get { return _highStepFrequency; }
      set
      {
        _highStepFrequency = value;
        Invalidate();
      }
    }

    [Category("Behavior"), Description("Turning speed if greater than HighStepFrequency value change step equal to maxStep")]
    public float MaxStep { get; set; }

    [Category("Behavior"), Description("Turning speed if smaller than HighStepFrequency value change step equal to minStep")]
    public float MinStep { get; set; }

    [Category("Behavior")]
    public override float HighValue
    {
      get
      {
        return _highValue;
      }
      set
      {
        if (value > _lowValue)
        {
          _highValue = value;
          if (Value > _highValue)
            Value = _highValue;
          Invalidate();
        }
      }
    }

    [Category("Behavior")]
    public override float LowValue
    {
      get
      {
        return _lowValue;
      }
      set
      {
        if (value < _highValue)
        {
          _lowValue = value;
          if (Value < _lowValue)
            Value = _lowValue;
          Invalidate();
        }
      }
    }

    [Category("Appearance"), Description("Knob handle color")]
    public Color HandleColor
    {
      get { return _handleColor; }
      set
      {
        _handleColor = value;
        Invalidate();
      }
    }



    [Category("Appearance"), Description("Color of the range band")]
    public Color ScaleBandColor
    {
      get { return _scaleBandColor; }
      set
      {
        _scaleBandColor = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Color of the high value band")]
    public Color HighValueColor
    {
      get { return _highValueColor; }
      set { _highValueColor = value; this.Invalidate(); }
    }

    public Color LowValueColor
    {
      get { return _lowValueColor; }
      set { _lowValueColor = value; this.Invalidate(); }
    }



    public Color KnopColor
    {
      get { return _knopColor; }
      set { _knopColor = value; Invalidate(); }
    }

    public override bool DesignModeActive
    {
      get
      {
        return base.DesignModeActive;
      }
      set
      {
        base.DesignModeActive = value;
        txtVal.Enabled = !value;
        pictureBox1.Enabled = !value;

      }
    }

    public override bool ControlEnable
    {
      get
      {
        return base.ControlEnable;
      }
      set
      {
        base.ControlEnable = value;
        //if (ActualUserLevel == User.UserLevels.Admin)
        pictureBox1.Image = ControlEnable ? _powerOnImage : _powerOffImage;
        //else
        //  pictureBox1.Image = _powerOffImage;
      }
    }

    #endregion

    #region Events Delegates
    protected override void OnSizeChanged(EventArgs e)
    {
      if (this.Width == 0 || this.Height == 0)
        return;
      base.OnSizeChanged(e);
      CalculateDimensions();
      PlaceButtons();
    }
    protected override void OnPaint(PaintEventArgs e)
    {
      if (this.Width == 0 || this.Height == 0)
        return;
      e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

      if (DesignMode)
      {
        CalculateDimensions();
        PlaceButtons();
      }
      //// Draw the control

      RectangleF rcKnop = _rcKnop;
      DrawHeader(e.Graphics, _rcHeader, _fontRatio, HeaderForeColor);
      DrawScaleBand(e.Graphics, ref rcKnop);
      _rcKnopTurn = DrawKnob(e.Graphics, rcKnop, _rcHandle);

    }


    #endregion

    #region Events

    private void pictureBox1_Click(object sender, EventArgs e)
    {
      if ((SystemMode == SystemModes.Manual || SystemMode == SystemModes.Automatic) && CanUserAccess)
        ControlEnable = !ControlEnable;
      else
        ControlEnable = false;
    }

    private void Knob_MouseDown(object sender, MouseEventArgs e)
    {
      this.label1.Focus();
      _mouseDownPressed = _rcHandle.Contains(e.Location);
    }

    private void Knob_MouseMove(object sender, MouseEventArgs e)
    {
      if (_mouseDownPressed && !DesignModeActive)
      {
        if (TurnAction == TurnActions.Everywhere || (TurnAction == TurnActions.OnlyInside && _mouseInside))
        {
          float rotation, actualAngle;
          actualAngle = (float)(Math.Atan2(e.Y - _middlePoint.Y, e.X - _middlePoint.X) / Math.PI * 180f) % 360f;
          rotation = ((actualAngle - _angle) * 120) % 360;
          _angle = actualAngle;

          counter++;
          if (counter > 2)
          {
            CalculateCurrentValue(rotation, Value);
            //this.Value = rotation;
            counter = 0;
          }
          _rcHandle = CalculateHandleRc(_rcKnop, _angle);
          Invalidate();
        }
      }

    }

    private void Knob_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
    {
      if (!DesignModeActive)
      {
        if (_rcKnopTurn.Contains(e.Location))
        {
          _angle += (e.Delta / SystemInformation.MouseWheelScrollDelta) * 10;

          _angle %= 360;
          CalculateCurrentValue(e.Delta, Value);
          _rcHandle = CalculateHandleRc(_rcKnop, _angle);
        }
      }
      Invalidate();
    }

    private void txt_Keypress(object sender, KeyPressEventArgs e)
    {
      Functions.NumericFloatInput(ref e, '.', txtVal.Text, txtVal.SelectionStart);

      if (e.KeyChar == (char)Keys.Return)
      {
        label1.Focus();
        if (Functions.InRange((float)Functions.ToDouble(txtVal.Text), HighValue, LowValue))
          this.Value = (float)Functions.ToDouble(txtVal.Text);//  Functions.MaxMinControl((float)Functions.ToDouble(txtVal.Text), HighValue, LowValue);
        else
          txtVal.Text = this.Value.ToString();
      }
    }
    #endregion

    #region Functions

    private void CalculateDimensions()
    {
      _rcDraw = ClientRectangle;
      if (BorderStyle == System.Windows.Forms.BorderStyle.Fixed3D)
        _rcDraw.Inflate(-SystemInformation.Border3DSize.Width, -SystemInformation.Border3DSize.Height);
      else if (BorderStyle == System.Windows.Forms.BorderStyle.FixedSingle)
        _rcDraw.Inflate(-SystemInformation.BorderSize.Width, -SystemInformation.BorderSize.Height);
      _fontRatio = (Math.Min(_rcDraw.Width, _rcDraw.Height)) / 75;
      if (_fontRatio == 0.0)
        _fontRatio = 1;
      _rcHeader = _rcDraw;
      _rcHeader.Height *= 0.1f;
      _rcHeader.Width *= 0.990f;
      _rcKnop = _rcDraw;
      _rcKnop.Height = _rcDraw.Height - 2f * _rcHeader.Height;
      _rcKnop.Width = _rcKnop.Height;
      _rcKnop.X += (_rcDraw.Width - _rcKnop.Width) / 2;
      _rcKnop.Y += _rcHeader.Height;
      RectangleF rr = _rcKnop;
      rr.Inflate(-rr.Width * 0.4f, -rr.Width * 0.4f);
      pictureBox1.Size = rr.Size.ToSize();
      pictureBox1.Location = new Point((int)rr.Location.X, (int)rr.Location.Y);
      //pictureBox1.Width = pictureBox1.Height = (int)(_rcKnop.Width / 4f);
      //pictureBox1.Left= 
      _middlePoint = new PointF(_rcKnop.Left + _rcKnop.Width / 2f, _rcKnop.Top + _rcKnop.Height / 2f);
      _rcHandle = CalculateHandleRc(_rcKnop, _angle);
    }

    private string FormatNumber(float nmbr, int prec, NumberFormatInfo nfi)
    {
      if (nfi != null)
      {
        string sep = nfi.NumberGroupSeparator;
        int dig = nfi.NumberDecimalDigits;
        nfi.NumberGroupSeparator = "";
        nfi.NumberDecimalDigits = prec;
        string val = Math.Round(nmbr, prec).ToString("N", nfi);
        nfi.NumberGroupSeparator = sep;
        nfi.NumberDecimalDigits = dig;
        return val;
      }
      else
        return Math.Round(nmbr, prec).ToString();
    }

    private void CalculateCurrentValue(float rotation, float currentValue)
    {
      float temp;
      _currentStep = CalculateStep(1 / stopwatch.Elapsed.TotalSeconds, HighStepFrequency, MaxStep, MinStep);
      stopwatch.Restart();
      if (rotation < 0)
        temp = currentValue - _currentStep;
      else
        temp = currentValue + _currentStep;
      this.Value = (float)(Math.Round(Functions.MaxMinControl(temp, HighValue, LowValue), Precision));
    }

    private float CalculateStep(double actualfrequency, float highStepFrequency, float highStep, float lowStep)
    {
      if (actualfrequency > highStepFrequency)
        return highStep;
      else
        return lowStep;
    }

    private void DrawHeader(Graphics gr, RectangleF headerRectangle, float fontRatio, Color headerFontColor)
    {
      const float unitRatio = 0.2f;

      Font font = Functions.GetFontForControlHeight((int)headerRectangle.Height, Font);
      SolidBrush brHeader = new SolidBrush(headerFontColor);
      SizeF strSize = gr.MeasureString(Header, font);

      float tx = headerRectangle.X + (headerRectangle.Width - unitRatio * headerRectangle.Width - strSize.Width) / 2;
      float ty = headerRectangle.Y + (headerRectangle.Height - strSize.Height) / 2;

      Pen penHeaderBorder = new Pen(Functions.CalculateGradientLight(HeaderBackColor, 400f));
      gr.DrawRectangle(penHeaderBorder, headerRectangle.X, headerRectangle.Y, headerRectangle.Width, headerRectangle.Height);

      LinearGradientBrush brGround = new LinearGradientBrush(headerRectangle, HeaderBackColor, Functions.CalculateGradientLight(HeaderBackColor, 400f), 0f, true);

      brGround.SetSigmaBellShape(.5f, .6f);
      gr.FillRectangle(brGround, headerRectangle);
      gr.DrawString(Header, font, brHeader, tx, ty);


      PointF lineStart = new PointF(headerRectangle.X + headerRectangle.Width * (1 - unitRatio), headerRectangle.Y);
      PointF lineEnd = new PointF(lineStart.X, headerRectangle.Y + headerRectangle.Height);
      strSize = gr.MeasureString(Unit, font);
      tx = lineStart.X + (headerRectangle.Width * unitRatio - strSize.Width) / 2f;
      ty = headerRectangle.Y + (headerRectangle.Height - strSize.Height) / 2f;
      gr.DrawString(Unit, font, brHeader, tx, ty);
      gr.DrawLine(penHeaderBorder, lineStart, lineEnd);


      brHeader.Dispose();
      penHeaderBorder.Dispose();
      brGround.Dispose();
    }

    private RectangleF DrawKnob(Graphics gr, RectangleF rcKnop, RectangleF rcHandle)
    {
      rcKnop.Inflate(-rcKnop.Width * 0.02f, -rcKnop.Width * 0.02f);
      Brush brBackCircle = new LinearGradientBrush(rcKnop, KnopColor, Functions.CalculateGradientDark(KnopColor, 200f), LinearGradientMode.ForwardDiagonal);
      Pen penBackCircle = new Pen(brBackCircle);
      gr.DrawEllipse(penBackCircle, rcKnop);
      gr.FillEllipse(brBackCircle, rcKnop);
      brBackCircle.Dispose();
      penBackCircle.Dispose();

      rcKnop.Inflate(-0.1f * rcKnop.Width, -0.1f * rcKnop.Width);

      GraphicsPath pth = new GraphicsPath();
      pth.AddEllipse(rcKnop);
      PathGradientBrush brs = new PathGradientBrush(pth);
      brs.CenterColor = Functions.CalculateGradientDark(KnopColor, 200f);
      brs.SurroundColors = new Color[] { KnopColor };
      Pen penKnobCircle = new Pen(KnopColor); //Functions.CalculateGradientDark(KnopColor, 500f));
      gr.DrawEllipse(penKnobCircle, rcKnop);
      gr.FillEllipse(brs, rcKnop);
      penKnobCircle.Dispose();

      Brush brHandleCircle = new LinearGradientBrush(rcKnop, _handleColor, Functions.CalculateGradientDark(_handleColor, 150f), _angle);
      Pen penHandleCircle = new Pen(Functions.CalculateGradientDark(_handleColor, 200f));
      gr.DrawEllipse(penHandleCircle, rcHandle);
      gr.FillEllipse(brHandleCircle, rcHandle);
      brHandleCircle.Dispose();
      penBackCircle.Dispose();
      pth.Dispose();
      brs.Dispose();
      return rcKnop;
    }

    private RectangleF CalculateHandleRc(RectangleF rcKnop, float angle)
    {
      float r = 0.5f * rcKnop.Height / 2f;
      float xm = rcKnop.Left + rcKnop.Height / 2f;
      float ym = rcKnop.Top + rcKnop.Height / 2f;
      rcKnop.Inflate(-0.44f * rcKnop.Width, -0.44f * rcKnop.Width);
      float rHandle = rcKnop.Width / 2f;
      rcKnop.X = r * (float)Math.Cos(angle * Math.PI / 180f) + xm - rHandle;
      rcKnop.Y = r * (float)Math.Sin(angle * Math.PI / 180f) + ym - rHandle;
      return rcKnop;
    }

    private void DrawScaleBand(Graphics gr, ref RectangleF rcKnop)
    {
      if (ScaleBandVisible)
      {
        float startAngle = 180;
        float endAngle = 540;
        float sweepAngle;
        float rangeOfScaleBand = _highValue - _lowValue;
        float angleRange = endAngle - startAngle;
        startAngle = (float)(Math.Round((decimal)((Value - _lowValue) * angleRange / rangeOfScaleBand + startAngle)));
        sweepAngle = 540 - startAngle;
        rcKnop.Inflate(-rcKnop.Width * 0.06f, -rcKnop.Width * 0.06f);
        float gap = rcKnop.Width / 50f;

        PointF[] pts = new PointF[6];
        float cx = rcKnop.X + rcKnop.Width / 2;
        float cy = rcKnop.Y + rcKnop.Height / 2;
        float r = rcKnop.Width / 1.4f;
        double theta = Math.PI;
        double dtheta = 4 * Math.PI / 10;
        for (int i = 0; i < pts.Length; i++)
        {
          pts[i].X = (float)(cx + r * Math.Cos(theta));
          pts[i].Y = (float)(cy + r * Math.Sin(theta));
          theta += dtheta;
        }

        using (PathGradientBrush path_brush = new PathGradientBrush(pts))
        {
          // Define the center and surround colors.
          path_brush.CenterPoint = new PointF(cx, cy);
          path_brush.CenterColor = Color.White;
          path_brush.SurroundColors = Functions.InterpolateColors(LowValueColor, HighValueColor, 6);
          Pen pen = new Pen(path_brush, rcKnop.Width * 0.06f);
          gr.DrawArc(pen, rcKnop, 180f, 360f);
        }

        Pen penCover = new Pen(ScaleBandColor, rcKnop.Width * 0.06f);

        gr.DrawArc(penCover, rcKnop, startAngle, sweepAngle);

        rcKnop.Inflate(-gap, -gap);
      }
    }

    private void PlaceButtons()
    {
      if (_rcDraw.Width > 10 && _rcDraw.Height > 20)
      {
        RectangleF rcButtons = new RectangleF();
        rcButtons.X = _rcKnop.Width * 0.05f;
        rcButtons.Y = _rcDraw.Y + _rcKnop.Bottom;
        rcButtons.Width = _rcKnop.Width * 0.9f;
        rcButtons.Height = (_rcDraw.Height - rcButtons.Y);
        this.txtVal.Width = (int)(rcButtons.Width);

        this.txtVal.Font = Functions.GetFontForControlHeight((int)rcButtons.Height, this.Font);

        this.txtVal.Location = new Point((int)rcButtons.X, (int)(rcButtons.Y));
      }
    }
    #endregion
  }
}