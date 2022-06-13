using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Text;
using System.Data;
using GlobalFunctions;

namespace UserInterface
{
  /// <summary>
  /// Class for the seven segment digital display
  /// </summary>
  [ToolboxItem(true)]
  public partial class DigitalDisplay : AnalogBase
  {
    #region Enumerator
    public enum HeaderShownHidden { On, Off }
    #endregion

    #region Properties variables
    private HeaderShownHidden headerLabel;
    private Color backgroundColor;
    private Color digitColor;
    private Color unitColor;
    private float currValue;
    private float lowAlarmValue;
    private float lowWarnValue;
    private float highAlarmValue;
    private float highWarnValue;
    // private int precision;
    #endregion

    #region Class variables
    protected DigitalDisplayRenderer defaultRenderer;
    #endregion

    #region Constructors
    public DigitalDisplay()
    {
      InitializeComponent();
      this.headerLabel = HeaderShownHidden.On;
      this.backgroundColor = Color.DarkGray;
      this.unitColor = Color.Black;
      this.digitColor = Color.GreenYellow;
      this.LowAlarmColor = Color.DarkRed;
      this.LowWarnColor = Color.Gold;
      this.HighAlarmColor = Color.DarkRed;
      this.HighWarnColor = Color.Gold;
      this.currValue = 0;
      this.Precision = 1;
      this.highAlarmValue = 125;
      this.highWarnValue = 100;
      this.lowWarnValue = -100;
      this.lowAlarmValue = -125;
      this.UIType = UserInterfaceUsingTypes.Indicator;
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.BackColor = Color.Transparent;
    }
    #endregion

    #region Properties
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

    [Category("Appearance"), Description("")]
    public override string Unit
    {
      get { return base.Unit; }
      set { base.Unit = value; }
    }


    [Browsable(false)]
    public override float LowValue
    {
      get;
      set;
    }

    [Browsable(false)]
    public override float HighValue
    {
      get;
      set;
    }

    [Browsable(false), Category("DoNotSave"), Description("Value of the data")]
    public override float Value
    {
      get
      {
        return base.Value;
      }
      set
      {
        currValue = base.Value = value;
        Invalidate();
      }
    }

    [Category("Behavior"), Description("Low alert value")]
    public override float LowAlarmValue
    {
      get { return lowAlarmValue; }
      set
      {
        if (value <= highWarnValue && value <= highAlarmValue)
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
        if (value <= highWarnValue && value <= highAlarmValue)
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
        if (value >= lowWarnValue && value >= lowAlarmValue)
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
        if (value >= lowWarnValue && value >= lowAlarmValue)
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

    [Category("Appearance"), Description("Enable or disable alarm indicating")]
    public bool ShowAlarmIndicating { get; set; }

    [Category("Behavior"), Description("Background color")]
    public Color BackgroundColor
    {
      get { return backgroundColor; }
      set { backgroundColor = value; Invalidate(); }
    }

    [Category("Behavior"), Description("Color of the digits")]
    public Color DigitColor
    {
      get { return digitColor; }
      set { digitColor = value; Invalidate(); }
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
    #endregion

    #region Event delegates
    protected override void OnPaint(PaintEventArgs e)
    {
      e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
      DigitalDisplayRenderer renderer = new DigitalDisplayRenderer(e.Graphics);
      string digitText = Value.ToString("0.0");

      if (Precision == 0 || Precision > 6)
        digitText = Value.ToString("0.");
      else if (Precision == 1)
        digitText = Value.ToString("0.0");
      else if (Precision == 2)
        digitText = Value.ToString("0.00");
      else if (Precision == 3)
        digitText = Value.ToString("0.000");
      else if (Precision == 4)
        digitText = Value.ToString("0.0000");
      else if (Precision == 5)
        digitText = Value.ToString("0.00000");
      else
        digitText = Value.ToString("0.000000");

      if ((int)this.headerLabel == 0 && ClientSize.Width >= 150)
      {
        SizeF digitSizeF = renderer.GetStringSize(digitText, Font);
        float scaleFactor = Math.Min(ClientSize.Width / digitSizeF.Width, (ClientSize.Height - 20) / digitSizeF.Height);
        Font font = new Font(Font.FontFamily, scaleFactor * Font.SizeInPoints);
        digitSizeF = renderer.GetStringSize(digitText, font);

        using (SolidBrush brush = new SolidBrush(digitColor))
        {
          using (SolidBrush lightBrush = new SolidBrush(Color.FromArgb(25, digitColor)))
          {
            if (ClientSize.Height == (digitSizeF.Height + 20))
            {
              renderer.DrawDigits(digitText, font, brush, lightBrush, (ClientSize.Width - digitSizeF.Width) / 2, 20);
            }
            else
            {
              renderer.DrawDigits(digitText, font, brush, lightBrush, (ClientSize.Width - digitSizeF.Width) / 2, ((ClientSize.Height + 20 - digitSizeF.Height) / 2));
            }
          }
        }

        RectangleF rc = new RectangleF();
        rc.Width = (float)(ClientSize.Width) - (float)(ClientSize.Width * 1 / 6);
        rc.Height = 20;
        //LinearGradientBrush brBorder = new LinearGradientBrush(rc, Color.Gray, Color.Linen, 0f, true);
        LinearGradientBrush brBorder = new LinearGradientBrush(rc, HeaderBackColor, Color.Linen, 0f, true);
        brBorder.SetSigmaBellShape(.5f, .6f);
        //Pen penBorder = new Pen(Color.FromArgb(175, 175, 175));
        Pen penBorder = new Pen(HeaderBackColor);
        GraphicsPath path = RoundedRectangle.Create(0, 0, rc.Width, 20, 1);
        e.Graphics.FillPath(brBorder, path);
        e.Graphics.DrawPath(penBorder, path);

        StringFormat stringFormat = new StringFormat();
        stringFormat.Alignment = StringAlignment.Center;
        stringFormat.LineAlignment = StringAlignment.Center;

        string strHeader = this.Header;
        Font font1 = new Font(this.Font.FontFamily, 10);
        SolidBrush brHeader = new SolidBrush(this.HeaderForeColor);
        float tx = (float)((rc.Width) / 2);
        float ty = 10;
        e.Graphics.DrawString(strHeader, font1, brHeader, tx, ty, stringFormat);

        rc.Width = (float)(ClientSize.Width) - (float)(ClientSize.Width * 5 / 6);
        GraphicsPath path2 = RoundedRectangle.Create(ClientSize.Width * 5 / 6, 0, rc.Width, 20, 1);
        e.Graphics.FillPath(brBorder, path2);
        e.Graphics.DrawPath(penBorder, path2);

        string strUnit = this.Unit;
        SolidBrush brUnit = new SolidBrush(this.HeaderForeColor);
        float tx2 = (float)((rc.Width) / 2 + ClientSize.Width * 5 / 6);
        e.Graphics.DrawString(strUnit, font1, brUnit, tx2, ty, stringFormat);
      }

      else
      {
        SizeF digitSizeF = renderer.GetStringSize(digitText, Font);
        float scaleFactor = Math.Min(ClientSize.Width / digitSizeF.Width, ClientSize.Height / digitSizeF.Height);
        Font font = new Font(Font.FontFamily, scaleFactor * Font.SizeInPoints);
        digitSizeF = renderer.GetStringSize(digitText, font);
        using (SolidBrush brush = new SolidBrush(digitColor))
        {
          using (SolidBrush lightBrush = new SolidBrush(Color.FromArgb(25, digitColor)))
          {
            renderer.DrawDigits(digitText, font, brush, lightBrush, (ClientSize.Width - digitSizeF.Width) / 2, (ClientSize.Height - digitSizeF.Height) / 2);
          }
        }
      }
      if (ShowAlarmIndicating)
      {
        if (highWarnValue <= currValue && currValue < highAlarmValue)
          this.BackColor = this.HighWarnColor;
        else if (lowWarnValue >= currValue && currValue > lowAlarmValue)
          this.BackColor = this.LowWarnColor;
        else if (highAlarmValue <= currValue)
          this.BackColor = this.HighAlarmColor;
        else if (lowAlarmValue >= currValue)
          this.BackColor = this.LowAlarmColor;
        else
          this.BackColor = this.BackgroundColor;
      }
      else
        this.BackColor = this.BackgroundColor;
    }
    #endregion
  }

  /// <summary>
  /// Base class for the renderers of the digital display
  /// </summary>
  public class DigitalDisplayRenderer
  {
    Graphics _graphics;

    // Indicates what segments are illuminated for all 10 digits
    static byte[,] _segmentData = {{1, 1, 1, 0, 1, 1, 1},
               {0, 0, 1, 0, 0, 1, 0},  
               {1, 0, 1, 1, 1, 0, 1},  
               {1, 0, 1, 1, 0, 1, 1},  
               {0, 1, 1, 1, 0, 1, 0},  
               {1, 1, 0, 1, 0, 1, 1},  
               {1, 1, 0, 1, 1, 1, 1},  
               {1, 0, 1, 0, 0, 1, 0},  
               {1, 1, 1, 1, 1, 1, 1},  
               {1, 1, 1, 1, 0, 1, 1}};

    // Points that define each of the seven segments
    readonly Point[][] _segmentPoints = new Point[7][];

    public DigitalDisplayRenderer(Graphics graphics)
    {
      this._graphics = graphics;
      _segmentPoints[0] = new Point[] {new Point( 3,  2), new Point(39,  2), 
          new Point(31, 10), new Point(11, 10)};
      _segmentPoints[1] = new Point[] {new Point( 2,  3), new Point(10, 11), 
          new Point(10, 31), new Point( 2, 35)};
      _segmentPoints[2] = new Point[] {new Point(40,  3), new Point(40, 35), 
          new Point(32, 31), new Point(32, 11)};
      _segmentPoints[3] = new Point[] {new Point( 3, 36), new Point(11, 32), 
          new Point(31, 32), new Point(39, 36), new Point(31, 40), 
          new Point(11, 40)};
      _segmentPoints[4] = new Point[] {new Point( 2, 37), new Point(10, 41), 
          new Point(10, 61), new Point( 2, 69)};
      _segmentPoints[5] = new Point[] {new Point(40, 37), new Point(40, 69), 
          new Point(32, 61), new Point(32, 41)};
      _segmentPoints[6] = new Point[] {new Point(11, 62), new Point(31, 62), 
          new Point(39, 70), new Point( 3, 70)};
    }

    public SizeF GetStringSize(string text, Font font)
    {
      SizeF sizef = new SizeF(0, _graphics.DpiX * font.SizeInPoints / 72);

      for (int i = 0; i < text.Length; i++)
      {
        if (Char.IsDigit(text[i]) || text[i] == '-')
          sizef.Width += 42 * _graphics.DpiX * font.SizeInPoints / 72 / 72;
        else if (text[i] == ':' || text[i] == '.')
          sizef.Width += 12 * _graphics.DpiX * font.SizeInPoints / 72 / 72;
      }
      return sizef;
    }

    public void DrawDigits(string text, Font font, Brush brush,
        Brush brushLight, float x, float y)
    {
      for (int cnt = 0; cnt < text.Length; cnt++)
      {
        // For digits 0-9
        if (Char.IsDigit(text[cnt]))
          x = DrawDigit(text[cnt] - '0', font, brush, brushLight, x, y);
        // For colon :
        else if (text[cnt] == ':')
          x = DrawColon(font, brush, x, y);
        // For dot .
        else if (text[cnt] == '.')
          x = DrawDot(font, brush, x, y);
        // For minus sign -
        else if (text[cnt] == '-')
          x = DrawMinus(text[cnt], font, brush, brushLight, x, y);
      }
    }

    private float DrawDigit(int num, Font font, Brush brush, Brush brushLight,
        float x, float y)
    {
      for (int cnt = 0; cnt < _segmentPoints.Length; cnt++)
      {
        if (_segmentData[num, cnt] == 1)
        {
          FillPolygon(_segmentPoints[cnt], font, brush, x, y);
        }
        else
        {
          FillPolygon(_segmentPoints[cnt], font, brushLight, x, y);
        }
      }
      return x + 42 * _graphics.DpiX * font.SizeInPoints / 72 / 72;
    }

    private float DrawMinus(int num, Font font, Brush brush, Brush brushLight,
        float x, float y)
    {
      for (int cnt = 0; cnt < _segmentPoints.Length; cnt++)
      {
        if (cnt == 3)
        {
          FillPolygon(_segmentPoints[3], font, brush, x, y);
        }
        else
        {
          FillPolygon(_segmentPoints[cnt], font, brushLight, x, y);
        }
      }
      return x + 42 * _graphics.DpiX * font.SizeInPoints / 72 / 72;
    }

    private float DrawDot(Font font, Brush brush, float x, float y)
    {
      Point[][] dotPoints = new Point[1][];

      dotPoints[0] = new Point[] {new Point( 2, 66), new Point( 6, 62),
                                new Point(10, 66), new Point( 6, 70)};

      for (int cnt = 0; cnt < dotPoints.Length; cnt++)
      {
        FillPolygon(dotPoints[cnt], font, brush, x, y);
      }
      return x + 12 * _graphics.DpiX * font.SizeInPoints / 72 / 72;
    }

    private float DrawColon(Font font, Brush brush, float x, float y)
    {
      Point[][] colonPoints = new Point[2][];

      colonPoints[0] = new Point[] {new Point( 2, 21), new Point( 6, 17), 
          new Point(10, 21), new Point( 6, 25)};
      colonPoints[1] = new Point[] {new Point( 2, 51), new Point( 6, 47), 
          new Point(10, 51), new Point( 6, 55)};

      for (int cnt = 0; cnt < colonPoints.Length; cnt++)
      {
        FillPolygon(colonPoints[cnt], font, brush, x, y);
      }
      return x + 12 * _graphics.DpiX * font.SizeInPoints / 72 / 72;
    }

    private void FillPolygon(Point[] polygonPoints, Font font,
        Brush brush, float x, float y)
    {
      PointF[] polygonPointsF = new PointF[polygonPoints.Length];

      for (int cnt = 0; cnt < polygonPoints.Length; cnt++)
      {
        polygonPointsF[cnt].X = x + polygonPoints[cnt].X *
            _graphics.DpiX * font.SizeInPoints / 72 / 72;
        polygonPointsF[cnt].Y = y + polygonPoints[cnt].Y *
            _graphics.DpiY * font.SizeInPoints / 72 / 72;
      }
      _graphics.FillPolygon(brush, polygonPointsF);
    }
  }
}