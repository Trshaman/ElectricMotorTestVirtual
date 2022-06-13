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
  public partial class Header : UIBase
  {
    private bool _radientBackGround;
    private bool _autoFontSize;
    private System.Drawing.Font _regHeaderFont;


    public Header()
    {
      InitializeComponent();
      this.WidthHeightRatio = 4f;
    }

    [Browsable(false), Category("Appearance")]
    public override Font Font
    {
      get
      {
        return base.Font;
      }
      set
      {
        base.Font = value;
      }
    }

    [Browsable(false), Category("Appearance")]
    public override Color ForeColor
    {
      get { return base.ForeColor; }
    }

    [Browsable(false), Category("Appearance")]
    public override Color HeaderBackColor
    {
      get { return base.HeaderBackColor; }
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
    public override string ChannelName
    {
      get { return base.ChannelName; }
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


    [Category("Appearance")]
    public bool GradientBackGround
    {
      get { return _radientBackGround; }

      set
      {
        _radientBackGround = value;
        Invalidate();
      }
    }

    /// <summary>
    ///Font size changed automaticly if font set from properties size no change
    /// </summary>
    [Category("Appearance"), Description("Header font ")]
    public override Font HeaderFont
    {
      get
      {
        return base.HeaderFont;
      }
      set
      {
        _regHeaderFont = value;
        if (AutoFontSize)
          base.HeaderFont = new Font(value.Name, base.HeaderFont.Size, value.Style);
        else
          base.HeaderFont = value;
        Invalidate();
      }
    }

    protected override void OnSizeChanged(EventArgs e)
    {
      base.OnSizeChanged(e);
      this.Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      // Create an offscreen graphics object for double buffering
      Bitmap offScreenBmp = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
      using (System.Drawing.Graphics g = Graphics.FromImage(offScreenBmp))
      {
        g.SmoothingMode = SmoothingMode.HighQuality;
        // Draw the control
        DrawLabel(g);
        // Draw the image to the screen
        e.Graphics.DrawImageUnscaled(offScreenBmp, 0, 0);
      }
    }

    private void DrawLabel(Graphics g)
    {
      RectangleF rc = new RectangleF();
      LinearGradientBrush brBorder;
      GraphicsPath path;
      StringFormat stringFormat = new StringFormat();
      string strHeader = this.Header;
      Font font1;
      SolidBrush brHeader;
      float tx, ty, fontSize;
      SizeF headerSize;


      rc.Width = (float)(ClientSize.Width);
      rc.Height = (float)(ClientSize.Height);
      if (GradientBackGround)
      {
        brBorder = new LinearGradientBrush(rc, BackColor, Functions.CalculateGradientLight(BackColor, 200f), 0f, true);
        brBorder.SetSigmaBellShape(.5f, .6f);
        path = RoundedRectangle.Create(0, 0, rc.Width, rc.Height, 1);
        g.FillPath(brBorder, path);
      }
      else
      {
        brBorder = new LinearGradientBrush(rc, BackColor, BackColor, 0f, true);
        path = RoundedRectangle.Create(0, 0, rc.Width, rc.Height, 1);
        g.FillPath(brBorder, path);
      }
      stringFormat.Alignment = StringAlignment.Center;
      stringFormat.LineAlignment = StringAlignment.Center;
      if (AutoFontSize)
      {
        fontSize = rc.Height / 2.5f;
        font1 = new Font(HeaderFont.Name, fontSize, HeaderFont.Style);
      }
      else
        font1 = HeaderFont;
      headerSize = g.MeasureString(strHeader, font1);

      brHeader = new SolidBrush(this.HeaderForeColor);
      tx = (float)((rc.Width) / 2);
      ty = (float)((rc.Height) / 2);
      g.DrawString(strHeader, font1, brHeader, tx, ty, stringFormat);
    }

    public bool AutoFontSize
    {
      get { return _autoFontSize; }
      set
      {
        _autoFontSize = value;
        if (!_autoFontSize)
          HeaderFont = _regHeaderFont;
        this.Invalidate();
      }
    }


  }
}
