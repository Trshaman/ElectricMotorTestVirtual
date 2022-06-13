using GlobalFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UserInterface
{
  [ToolboxItem(true)]
  public partial class LedDisplay : DigitalBase
  {
    #region Enumerator
    public enum LedDisplayStyle
    {
      Sphere,
      Rectangle
    }

    public enum ReflectionState
    {
      On, Off
    }

    public enum BlinkState
    {
      On, Off
    }

    #endregion

    #region Properties variables
    private LedDisplayStyle _ledDisplayStyle;
    private ReflectionState _reflectionState;
    private BlinkState _blinkState;
    private int _diameter;
    private int _blinkPeriod;
    private Color _onColor;
    private Color _offColor;
    private Color _reflectionColor = Color.FromArgb(180, 255, 255, 255);
    private Color[] _surroundColor = new Color[] { Color.FromArgb(0, 255, 255, 255) };
    private Timer _timer = new Timer();
    #endregion

    #region Constructor
    public LedDisplay()
    {
      InitializeComponent();
      // Properties initialization
      WidthHeightRatio = 0f;
      _ledDisplayStyle = LedDisplayStyle.Sphere;
      _reflectionState = ReflectionState.On;
      _blinkState = BlinkState.Off;
      _onColor = Color.GreenYellow;
      _offColor = Color.Red;
      _blinkPeriod = 1000;
      _timer.Interval = _blinkPeriod;
      _timer.Tick += new EventHandler(timer_Tick);

      // Set the styles for drawing
      SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
      UIType = UserInterfaceUsingTypes.Indicator;
    }
    #endregion

    #region Properties
    [Browsable(true), Category("DoNotSave")]
    public override bool Value
    {
      get
      {
        return base.Value;
      }
      set
      {
        base.Value = value;
      }
    }

    [Category("Behavior"), Description("Blink period (in milliseconds)")]
    public int BlinkPeriod
    {
      get { return _blinkPeriod; }
      set
      {
        _blinkPeriod = value;
        if (_blinkPeriod < 400)
          _blinkPeriod = 400;
        Invalidate();
      }
    }

    [Category("Behavior"), Description("Activates or deactivates blink")]
    public BlinkState Blink
    {
      get { return _blinkState; }
      set
      {
        _blinkState = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Style of the led display")]
    public LedDisplayStyle LedStyle
    {
      get { return _ledDisplayStyle; }
      set
      {
        _ledDisplayStyle = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Activates or deactivates reflection")]
    public ReflectionState Reflection
    {
      get { return _reflectionState; }
      set
      {
        _reflectionState = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("The color of the LED when it is \"OFF\"")]
    public Color OffColor
    {
      get { return _offColor; }
      set
      {
        _offColor = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("The color of the LED when it is \"ON\"")]
    public Color OnColor
    {
      get { return _onColor; }
      set
      {
        _onColor = value;
        Invalidate();
      }
    }

    [Browsable(false), Category("Appearance")]
    public override Font HeaderFont
    {
      get { return base.HeaderFont; }
    }

    [Browsable(false), Category("Appearance")]
    public override HeaderPosition HeaderPosition
    {
      get { return base.HeaderPosition; }
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

    #region Events
    protected override void OnSizeChanged(EventArgs e)
    {
      base.OnSizeChanged(e);
      Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      //drawControl(e.Graphics, Value);
      // Create an offscreen graphics object for double buffering
      Bitmap offScreenBmp = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
      using (System.Drawing.Graphics g = Graphics.FromImage(offScreenBmp))
      {
        g.SmoothingMode = SmoothingMode.HighQuality;
        // Draw the control
        drawControl(g, Value);
        // Draw the image to the screen
        e.Graphics.DrawImageUnscaled(offScreenBmp, 0, 0);
      }
    }

    private void timer_Tick(object sender, EventArgs e)
    {
      //_timer.Interval = _milliseconds;
      //if (lightColor == _onColor)
      //  lightColor = _offColor;
      //else
      //  lightColor = _onColor;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Renders the control to an image
    /// </summary>
    private void drawControl(Graphics g, bool value)
    {
      RectangleF rc = new RectangleF();
      LinearGradientBrush brBorder;
      Pen penBorder;
      GraphicsPath path2;
      StringFormat stringFormat = new StringFormat();
      string strHeader;
      Font font1;
      SolidBrush brHeader;
      float tx, ty;
      int width, height;
      Rectangle rectangle = new Rectangle();
      Color centerColor = _onColor;
      Color surroundColor = _onColor;

      if (value == true && _blinkState == BlinkState.Off)
      {
        surroundColor = _onColor;
        centerColor = ControlPaint.Light(_onColor, 1f);
        blinking_Off(_blinkState);
      }
      else if (value == true && _blinkState == BlinkState.On)
        blinking_On(_blinkState);
      else
      {
        surroundColor = _offColor;
        centerColor = ControlPaint.Light(_offColor, 0.3f);
      }



      if (HeaderVisible)
      {
        rc.Width = (float)(ClientSize.Width);
        rc.Height = 20;
       // brBorder = new LinearGradientBrush(rc, Color.Gray, Color.Linen, 0f, true);
        brBorder = new LinearGradientBrush(rc, HeaderBackColor, Color.Linen, 0f, true);
        brBorder.SetSigmaBellShape(.5f, .6f);
        //penBorder = new Pen(Color.FromArgb(175, 175, 175));
        penBorder = new Pen(HeaderBackColor);
        path2 = RoundedRectangle.Create(0, 0, rc.Width, 20, 1);
        g.FillPath(brBorder, path2);
        g.DrawPath(penBorder, path2);

        stringFormat.Alignment = StringAlignment.Center;
        stringFormat.LineAlignment = StringAlignment.Center;

        strHeader = Header;
        font1 = new Font(Font.FontFamily, 10);
        brHeader = new SolidBrush(HeaderForeColor);
        tx = (float)((rc.Width) / 2);
        ty = 10;
        g.DrawString(strHeader, font1, brHeader, tx, ty, stringFormat);

        // Calculate the dimensions of the bulb
        width = Width - (Padding.Left + Padding.Right);
        height = Height - (Padding.Top + Padding.Bottom) - 25;
        // Diameter is the lesser of width and height
        _diameter = Math.Min(width, height);
        // Subtract 1 pixel so ellipse doesn't get cut off
        _diameter = Math.Max(_diameter - 1, 1);

        // Draw the background ellipse
        rectangle = new Rectangle((width - _diameter) / 2, Padding.Top + 25, _diameter, _diameter);
      }

      else
      {
        // Calculate the dimensions of the bulb
        width = Width -(Padding.Left + Padding.Right);
        height = Height - (Padding.Top + Padding.Bottom);
        // Diameter is the lesser of width and height
        _diameter = Math.Min(width, height);
        // Subtract 1 pixel so ellipse doesn't get cut off
        _diameter = Math.Max(_diameter - 1, 1);

        // Draw the background ellipse
        rectangle = new Rectangle(Padding.Left, Padding.Top, _diameter, _diameter);
      }

      var path = new GraphicsPath();
      if (_ledDisplayStyle == LedDisplayStyle.Sphere)
      {
         g.FillEllipse(new SolidBrush(surroundColor), rectangle);
        // Draw the glow gradient
        path.AddEllipse(rectangle);
        var pathBrush = new PathGradientBrush(path);
        pathBrush.CenterColor = centerColor;// ControlPaint.Light(lightColor, 5f);
        //pathBrush.SurroundColors = new Color[] { Color.FromArgb(0, lightColor) };
        pathBrush.SurroundColors = new Color[] { surroundColor };
        g.FillEllipse(pathBrush, rectangle);

        if (_reflectionState == ReflectionState.On)
        {
          // Draw the white reflection gradient
          var offset = Convert.ToInt32(_diameter * .15F);
          var diameter1 = Convert.ToInt32(rectangle.Width * 0.8F);
          var whiteRect = new Rectangle(rectangle.X - offset, rectangle.Y - offset, diameter1, diameter1);
          var path1 = new GraphicsPath();
          path1.AddEllipse(whiteRect);
          var pathBrush1 = new PathGradientBrush(path);
          pathBrush1.CenterColor = _reflectionColor;
          pathBrush1.SurroundColors = _surroundColor;
          g.FillEllipse(pathBrush1, whiteRect);
        }
      }

      else
      {
        if (HeaderVisible)
          rectangle = new Rectangle(Padding.Left, Padding.Top + 25, width, _diameter);
        //g.FillRectangle(new SolidBrush(darkColor), rectangle);
        // Draw the glow gradient
        path.AddRectangle(rectangle);
        var pathBrush = new PathGradientBrush(path);
        pathBrush.CenterColor = centerColor;
        pathBrush.SurroundColors = new Color[] { surroundColor };
        g.FillRectangle(pathBrush, rectangle);

        if (_reflectionState == ReflectionState.On)
        {
          var point1 = new Point();
          var point2 = new Point();
          var point3 = new Point();

          if (!HeaderVisible)
          {
            // Draw the white reflection gradient
            point1 = new Point(rectangle.X, rectangle.Y);
            point2 = new Point(rectangle.X, rectangle.Width);
            point3 = new Point(rectangle.Height, rectangle.X);
          }
          else
          {
            point1 = new Point(rectangle.X, rectangle.Y);
            point2 = new Point(rectangle.X, rectangle.Height + 25);
            //point3 = new Point(rectangle.Width + 25, rectangle.X);
            //if (ClientSize.Width >= ClientSize.Height)
            point3 = new Point(rectangle.Width, rectangle.X + 25);
            //else
            //  point3 = new Point(rectangle.Width, rectangle.X + 26);
          }
          var path1 = new GraphicsPath();
          path1.AddLine(point1, point2);
          path1.AddLine(point2, point3);
          var pathBrush1 = new PathGradientBrush(path);
          pathBrush1.CenterColor = _reflectionColor;
          pathBrush1.SurroundColors = _surroundColor;
          g.FillPath(pathBrush1, path1);
        }
      }
    }

    private void blinking_On(BlinkState blinkState)
    {
      _timer.Start();
    }

    private void blinking_Off(BlinkState blinkState)
    {
      _timer.Stop();
    }
    #endregion
  }
}
