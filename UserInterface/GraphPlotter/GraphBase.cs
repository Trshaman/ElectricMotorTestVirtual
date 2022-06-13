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
  #region Definition
  delegate void AxisValueChangedHandler(object sender, AxisNames axs, int curveno, float minval, float maxval);
  delegate void SetGraphCallback(Control ctrl, Rectangle rc, Pen pen, Point pt1, Point pt2);
  delegate void SetToolTipCallBack(Control ctrl, string txt, Point pnt, bool shw, ToolTip tltp);
  delegate void SaveGraphCallBack(string fileName);

  internal enum AxisNames
  {
    X, Y, none
  }

  #endregion

  /// <summary>
  /// To draw curve, only for 4 curve
  /// </summary>
  [ToolboxItem(false)]
  public partial class GraphBase : AnalogBase
  {
    #region External Functions
    [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
    internal static extern bool BitBlt(
         IntPtr hdcDest, // handle to destination DC 
         int nXDest, // x-coord of destination upper-left corner 
         int nYDest, // y-coord of destination upper-left corner 
         int nWidth, // width of destination rectangle 
         int nHeight, // height of destination rectangle 
         IntPtr hdcSrc, // handle to source DC 
         int nXSrc, // x-coordinate of source upper-left corner 
         int nYSrc, // y-coordinate of source upper-left corner 
         System.Int32 dwRop // raster operation code 
    );
    #endregion

    #region LocalVariable

    private bool _showGrid = true;
    private Color _gridColor = Color.Maroon;
    private Color _scaleColor = Color.Maroon;
    private int _bufferSize = 50000;
    private SizeF _generalRatio;
    private SizeF _fontRatioGraphHeader;
    private SizeF _fontRatioOthers;
    private SizeF _spaceRatio;
    private SizeF _axistextboxratio;
    private Color _graphAreaColor = Color.White;
    private int _tickCount = 3;
    //private const int Xaxis = 0;
    //private const int Yaxis = 1;
    //private const int AxisMax = 0;
    //private const int AxisMin = 1;


    private float _gridWidth = 1.0F;

    private float _scaleLineWidth = 1.0F;
    private BorderStyle _graphAreaBorderStyle = BorderStyle.None;

    private ToolTip _pointInfo = new ToolTip();
    private Color _graphHeaderColor = Color.Black;
    private Color _xaxisColor = Color.Black;
    private System.Drawing.Font _graphFont = DefaultFont;



    #endregion

    #region Internal Variable
    internal bool PauseGraph;
    internal Rectangle Drawrc;
    internal int Tickwidth = 5;
    internal int Scalespace = 5;
    internal NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
    private int _resamplingSize = 500;
    #endregion

    #region Properties

    [RefreshProperties(RefreshProperties.Repaint)]
    [Category("Appearance")]
    [Description("Automaticly Change the X Axis Range")]
    public bool AutoXaxisRange { get; set; }

    [RefreshProperties(RefreshProperties.Repaint)]
    [Category("Appearance")]
    [Description("Automaticly Change the Y Axis Range")]
    public bool AutoYaxisRange { get; set; }

    public Axis Xaxis { get; set; }

    [RefreshProperties(RefreshProperties.Repaint)]
    [Category("Appearance")]
    [Description("Change the graph area color")]
    public Color GraphAreaColor
    {
      get { return _graphAreaColor; }
      set
      {
        _graphAreaColor = value;
        this.Invalidate();
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    [Category("Appearance")]
    [Description("Change the scale area color")]
    public Color ScaleColor
    {
      get { return _scaleColor; }
      set
      {
        _scaleColor = value;
        this.Invalidate();
      }
    }

    [RefreshProperties(RefreshProperties.Repaint)]
    [Category("Appearance")]
    public Color GridColor
    {
      get { return _gridColor; }
      set
      {
        _gridColor = value;
        this.Invalidate();
      }
    }

    /// <summary>
    ///Font size changed automaticly if font set from properties size no change
    /// </summary>
    [Category("Appearance"), Description("Size has no effect")]
    public override Font HeaderFont
    {
      get
      {
        return base.HeaderFont;
      }
      set
      {
        //Font fnt = new Font(value.Name, base.HeaderFont.Size);
        //base.HeaderFont = fnt;
        base.HeaderFont = value ;
        Invalidate();
      }
    }

    /// <summary>
    ///Font size changed automaticly if font set from properties size no change
    /// </summary>
    [Category("Appearance"), Description("Size has no effect")]
    public Font GraphFont
    {
      get
      {
        return _graphFont;
      }
      set
      {
        Font fnt = new Font(value.Name, _graphFont.Size);
        _graphFont = fnt;
        Invalidate();
      }
    }

    [Category("Graph Options"), Description("Buffer Size for graph min 1000 max 1.000.000 ")]
    public virtual int BufferSize
    {
      get { return _bufferSize; }
      set
      {
        _bufferSize = Functions.MaxMinControl(value, 1000000, 1000);
      }
    }

    [Category("Graph Options"), Description("Resampling Size for graph min 100 max 2000 ")]
    public int ResamplingSize
    {
      get { return _resamplingSize; }
      set
      {
        _resamplingSize = Functions.MaxMinControl(value, 2000, 100);
      }
    }

    [Category("Appearance")]
    public bool ShowGrid
    {
      get { return _showGrid; }
      set
      {
        _showGrid = value;
        this.Invalidate();
      }
    }

    [Category("Appearance")]
    public BorderStyle GraphAreaBorderStyle
    {
      get { return _graphAreaBorderStyle; }
      set
      {
        _graphAreaBorderStyle = value;
        this.Invalidate();
      }
    }
    [Category("Appearance")]

    public float GridWidth
    {
      get { return _gridWidth; }
      set
      {
        _gridWidth = value;
        this.Invalidate();
      }
    }
    [Category("Appearance")]
    public float ScaleLineWidth
    {
      get { return _scaleLineWidth; }
      set
      {
        _scaleLineWidth = value;
        this.Invalidate();
      }
    }
    // [Category("Appearance")]
    public override Color BackColor
    {
      get
      {
        return base.BackColor;
      }
      set
      {
        base.BackColor = value;
        this.Invalidate();
      }
    }

    
    #endregion

    #region Hiding Property

    [Browsable(false)]
    public override string Unit
    {
      get { return base.Unit; }
      set { base.Unit = value; }
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

    /// <summary>
    /// Do not use
    /// </summary>
    [Browsable(false)]
    public override GlobalFunctions.BackFillTypes BackFillType
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

    /// <summary>
    /// Do not use
    /// </summary>
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

    /// <summary>
    /// Do not use
    /// </summary>
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

    /// <summary>
    /// Do not use
    /// </summary>
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

    /// <summary>
    /// Do not use
    /// </summary>
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

    /// <summary>
    /// Do not use
    /// </summary>
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

    /// <summary>
    /// Do not use
    /// </summary>
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

    /// <summary>
    /// Do not use
    /// </summary>
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

    /// <summary>
    /// Do not use
    /// </summary>
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

    /// <summary>
    /// Do not use
    /// </summary>
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

    /// <summary>
    /// Do not use
    /// </summary>
    [Browsable(false)]
    public override float Value
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

    /// <summary>
    /// Do not use
    /// </summary>
    [Browsable(false)]
    public override float HighValue
    {
      get
      {
        return base.HighValue;
      }
      set
      {
        base.HighValue = value;
      }
    }

    /// <summary>
    /// Do not use
    /// </summary>
    [Browsable(false)]
    public override float LowValue
    {
      get
      {
        return base.LowValue;
      }
      set
      {
        base.LowValue = value;
      }
    }

    /// <summary>
    /// Do not use
    /// </summary>
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

    [Browsable(false), Category("DoNotSave")]
    public override string ChannelName
    {
      get
      {
        return base.ChannelName;
      }
      set
      {
        base.ChannelName = value;
      }
    }


    #endregion

    #region Ctor

    public GraphBase()
    {

      this.UIType = UserInterfaceUsingTypes.RealTimeIndicator;
      Header = "Graph Header"; //Initial value for header.
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      //  this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      //this.SetStyle(ControlStyles.UserPaint, true);
      nfi.NumberDecimalSeparator = ".";
      nfi.NumberGroupSeparator = "";
      Xaxis = new Axis("Xaxis", "Unit", Color.Black, 10, 0, 0, 5);
      InitializeComponent();
      this.SizeChanged += GraphControl_SizeChanged;
      InitSize();
    }
    private void InitSize()
    {
      Drawrc.Height = 218;
      Drawrc.Width = 438;
      Drawrc.X = 63;
      Drawrc.Y = 45;
      _spaceRatio.Width = (float)Drawrc.Left / this.Width;
      _spaceRatio.Height = (float)Drawrc.Top / this.Height;
      _generalRatio.Height = (float)Drawrc.Height / this.Size.Height;
      _generalRatio.Width = (float)Drawrc.Width / this.Size.Width;
      _fontRatioGraphHeader.Height = HeaderFont.Size / this.Size.Height;
      _fontRatioGraphHeader.Width = HeaderFont.Size / this.Size.Width;
      _fontRatioOthers.Height = (float)6.75 / this.Size.Height;
      _fontRatioOthers.Width = (float)6.75 / this.Size.Width;
      _axistextboxratio.Width = (float)35 / this.Size.Width;
      _axistextboxratio.Height = (float)11 / this.Size.Height;
    }

    #endregion

    #region Event
    private void GraphControl_SizeChanged(object sender, EventArgs e)
    {
      if (this.Width == 0 || this.Height == 0)
        return;
      //base.HeaderFont = new Font(HeaderFont.Name, 2f * FontSize(this.Size, _fontRatioGraphHeader)); //Font size changed automaticly if font set from properties size no change
      _graphFont = new Font(GraphFont.Name, FontSize(this.Size, _fontRatioOthers));
      Drawrc.Width = Convert.ToInt32(this.Size.Width * (float)_generalRatio.Width) + 1;
      Drawrc.Height = Convert.ToInt32(this.Size.Height * (float)_generalRatio.Height) + 1;
      Drawrc.Y = Convert.ToInt32(this.Height * _spaceRatio.Height) + 1;
      Drawrc.X = Convert.ToInt32(this.Width * _spaceRatio.Width) + 1;
      this.Invalidate();
    }

    #endregion

    #region Subs
    private float FontSize(Size currentsize, SizeF fontoran)
    {
      return (currentsize.Width > currentsize.Height) ? 1.2f*currentsize.Width * fontoran.Width : 1.2f*currentsize.Height * fontoran.Height;
    }

    /// <summary>
    /// Copy graph to a file as bitmap
    /// </summary>
    /// <param name="fileName"></param>
    internal void SaveBitMapGraphArea(string fileName)
    {
      Graphics g1 = this.CreateGraphics();
      Image MyImage = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height, g1);
      Graphics g2 = Graphics.FromImage(MyImage);
      IntPtr dc1 = g1.GetHdc();
      IntPtr dc2 = g2.GetHdc();
      BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);
      g1.ReleaseHdc(dc1);
      g2.ReleaseHdc(dc2);
      MyImage.Save(fileName, ImageFormat.Jpeg);
      g1.Dispose();
      g2.Dispose();
    }

    internal void CopyGraphToClipboard()
    {
      Graphics g1 = this.CreateGraphics();
      Image MyImage = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height, g1);
      Graphics g2 = Graphics.FromImage(MyImage);
      IntPtr dc1 = g1.GetHdc();
      IntPtr dc2 = g2.GetHdc();
      BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);
      g1.ReleaseHdc(dc1);
      g2.ReleaseHdc(dc2);
      Clipboard.SetImage(MyImage);
      g1.Dispose();
      g2.Dispose();
    }


    public virtual void Clear()
    {
    }

    internal virtual void DrawAll(Graphics graphics)
    {

      if (HeaderVisible) DrawHeader(graphics, Header, HeaderFont, this.ClientRectangle, HeaderForeColor);
      if (ShowGrid) DrawGrid(graphics, Drawrc, GridColor, GridWidth, Xaxis.TickCount);
      DrawBorder(graphics, Drawrc);
    }


    private void DrawGrid(Graphics grph, Rectangle drawRectangle, Color clr, float linewidth, int grdcount)
    {
      if (grdcount > 1)
      {

        int xartis = Convert.ToInt32((float)(drawRectangle.Width) / (grdcount - 1));
        int yartis = Convert.ToInt32((float)(drawRectangle.Height) / (grdcount - 1));

        Pen pn = new Pen(clr, linewidth);
        // grph.DrawRectangle(pn, drawRectangle);
        pn.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
        for (int i = 1; i < grdcount - 1; i++)
        {
          grph.DrawLine(pn, new Point(drawRectangle.Left, drawRectangle.Top + i * yartis), new Point(drawRectangle.Right, drawRectangle.Top + i * yartis));  //Horizantal lines
          grph.DrawLine(pn, new Point(drawRectangle.Left + i * xartis, drawRectangle.Top), new Point(drawRectangle.Left + i * xartis, drawRectangle.Bottom)); //Vertical lines
        }
        pn.Dispose();
      }
    }

    internal void DrawHeader(Graphics graphics, string header, Font headerFont, Rectangle graphArea, Color stringColor)
    {
      SizeF headerSize = graphics.MeasureString(header, headerFont);

      using (SolidBrush brs = new SolidBrush(stringColor))
      {
        graphics.DrawString(header, headerFont, brs, ((graphArea.Width - headerSize.Width) / 2), 0);
      }
    }

    private void DrawBorder(Graphics grph, Rectangle drawRectangle)
    {
      if (ShowGrid && (GraphAreaBorderStyle != BorderStyle.Fixed3D) && GraphAreaBorderStyle != BorderStyle.None)
        grph.DrawRectangle(new Pen(GridColor, 1), drawRectangle);
      if (ShowGrid && (GraphAreaBorderStyle == BorderStyle.Fixed3D))
        ControlPaint.DrawBorder3D(grph, drawRectangle, Border3DStyle.Raised);
    }
    #endregion

    public override string ToString()
    {
      return Header;
    }
  }
}