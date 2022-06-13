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
using GlobalFunctions;

namespace UserInterface
{
  [ToolboxItem(true)]
  public partial class HeaderWithUnit : UIBase
  {
    private string _unit = "Unit";
    public HeaderWithUnit()
    {
      InitializeComponent();
      UIType = UserInterfaceUsingTypes.Decorative;
      this.WidthHeightRatio = 4f;
    }

    [Browsable(false), Category("Appearance")]
    public override Color BackColor
    {
      get { return base.BackColor; }
    }

    [Browsable(false), Category("Appearance")]
    public new BorderStyle BorderStyle
    {
      get { return base.BorderStyle; }
    }

    [Browsable(false), Category("Appearance")]
    public override Color ForeColor
    {
      get { return base.ForeColor; }
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

    /// <summary>
    ///Font size changed automaticly if font set from properties size no change
    /// </summary>
    [Category("Appearance"), Description("Header font (size has no effect)")]
    public override Font HeaderFont
    {
      get
      {
        return base.HeaderFont;
      }
      set
      {
        Font fnt = new Font(value.Name, base.HeaderFont.Size);
        base.HeaderFont = fnt;
        Invalidate();
      }
    }

    [Browsable(true), Category("Appearance")]
    public string Unit
    {
      get { return _unit; }
      set { _unit = value; this.Invalidate(); }
    }

    protected override void OnSizeChanged(EventArgs e)
    {
      base.OnSizeChanged(e);
      this.Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      //DrawLabel(e);
      RectangleF rc = new RectangleF();
      rc.Width = (float)(ClientSize.Width) - (float)(ClientSize.Width * 1 / 6);
      rc.Height = (float)(ClientSize.Height);// -(float)(ClientSize.Height * 1 / 6);
      DrawHeader(e.Graphics, ClientRectangle,  ForeColor);
    }


    private void DrawHeader(Graphics gr, RectangleF headerRectangle,  Color headerFontColor)
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

    private void DrawLabel(PaintEventArgs e)
    {
     
      RectangleF rc = new RectangleF();
      rc.Width = (float)(ClientSize.Width) - (float)(ClientSize.Width * 1 / 6);
      rc.Height = (float)(ClientSize.Height);// -(float)(ClientSize.Height * 1 / 6);
      LinearGradientBrush brBorder = new LinearGradientBrush(rc, Color.Gray, Color.Linen, 0f, true);
      brBorder.SetSigmaBellShape(.5f, .6f);
      Pen penBorder = new Pen(Color.FromArgb(175, 175, 175));
      GraphicsPath path = RoundedRectangle.Create(0, 0, rc.Width, rc.Height, 1);
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
      GraphicsPath path2 = RoundedRectangle.Create(ClientSize.Width * 5 / 6, 0, rc.Width, rc.Height, 1);
      e.Graphics.FillPath(brBorder, path2);
      e.Graphics.DrawPath(penBorder, path2);

      string strUnit = this.Unit;
      SolidBrush brUnit = new SolidBrush(this.HeaderForeColor);
      float tx2 = (float)((rc.Width) / 2 + ClientSize.Width * 5 / 6);
      e.Graphics.DrawString(strUnit, font1, brUnit, tx2, ty, stringFormat);

    //  if (ClientSize.Height <= 50)
     //    this.Height = 20;

    }
  }
}
