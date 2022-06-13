using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GlobalFunctions;
using System.Drawing.Drawing2D;

namespace UserInterface
{
  [ToolboxItem(true)]
  public partial class ToggleSwitch : DigitalBase
  {
    #region Enumerator
    //public enum ToggleSwitchStyle
    //{
    //    Horizontal,
    //    Vertical
    //}

    //public enum OnOffState
    //{
    //  On, Off
    //}

    public enum ShadowState
    {
      On, Off
    }
    #endregion

    #region Properties variables
    //private ToggleSwitchStyle switchStyle;
    // private OnOffState _onOffSwitch;
    private ShadowState shadowState;
    private Color onBackgroundColor;
    private Color offBackgroundColor;
    private Color onTextColor;
    private Color offTextColor;
    Font fontOn, fontOff;
    string onLabel, offLabel;
    #endregion

    #region Class variables
    protected RectangleF drawRect;
    #endregion

    #region Costructors
    public ToggleSwitch()
    {
      // Initialization
      InitializeComponent();
      // Properties initialization
      //this.switchStyle = ToggleSwitchStyle.Horizontal;
      this.WidthHeightRatio = 2f;
      this.Value = false;
      this.shadowState = ShadowState.Off;
      this.onBackgroundColor = Color.OliveDrab;
      this.offBackgroundColor = Color.Firebrick;
      this.onTextColor = Color.White;
      this.offTextColor = Color.Black;
      this.onLabel = "ON";
      this.offLabel = "OFF";
      // Set the styles for drawing
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.UIType = UserInterfaceUsingTypes.Control;
    }
    #endregion

    #region Properties
    [Browsable(false), Category("Appearance")]
    public override Font HeaderFont
    {
      get { return base.HeaderFont; }
    }

    [Browsable(false), Category("Appearance")]
    public override HeaderPosition HeaderPosition
    {
      get
      {
        return base.HeaderPosition;
      }
    }

    [Browsable(false), Category("Appearance")]
    public ShadowState Shadow
    {
      get { return shadowState; }
      set
      {
        shadowState = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Label of the \"ON\" position")]
    public string OnLabel
    {
      get { return onLabel; }
      set
      {
        onLabel = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Label of the \"OFF\" position")]
    public string OffLabel
    {
      get { return offLabel; }
      set
      {
        offLabel = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Background Color of \"ON\"")]
    public Color OnBackgroundColor
    {
      get { return onBackgroundColor; }
      set
      {
        onBackgroundColor = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Background Color of \"OFF\"")]
    public Color OffBackgroundColor
    {
      get { return offBackgroundColor; }
      set
      {
        offBackgroundColor = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Text Color of \"ON\"")]
    public Color OnTextColor
    {
      get { return onTextColor; }
      set
      {
        onTextColor = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Text Color of \"OFF\"")]
    public Color OffTextColor
    {
      get { return offTextColor; }
      set
      {
        offTextColor = value;
        Invalidate();
      }
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

    //[Category("DoNotSave")]
    //public override bool Value
    //{
    //  get { return base.Value; }
    //  set { base.Value = value; }
    //}
    #endregion

    #region Events delegates
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
        DrawBackground(g);
        DrawBody(g);
        // Draw the image to the screen
        e.Graphics.DrawImageUnscaled(offScreenBmp, 0, 0);
      }
    }
    #endregion

    private void DrawBackground(Graphics Gr)
    {
      RectangleF rc = new RectangleF(0, 0, 100f, 50f);

      if (rc.Width <= 0 || rc.Height <= 0)
      {
        rc.Width = 100;
        rc.Height = 50;
      }

      rc.Width = (float)(Width);
      rc.Height = (float)(Height);
      Pen penBackground = new Pen(this.Parent.BackColor);
      SolidBrush brBackground = new SolidBrush(this.Parent.BackColor);
      Rectangle rcTmp = new Rectangle(0, 0, (int)rc.Width, (int)rc.Height);
      Gr.DrawRectangle(penBackground, rcTmp);
      Gr.FillRectangle(brBackground, rcTmp);
      penBackground.Dispose();
      brBackground.Dispose();
      LinearGradientBrush brBorder = new LinearGradientBrush(rc, HeaderBackColor, Color.Linen, LinearGradientMode.Vertical);
      Pen penBorder = new Pen(Color.FromArgb(175, 175, 175));

      GraphicsPath path = RoundedRectangle.Create(0, 0, rc.Width - 1, rc.Height - 1, 2);
      GraphicsPath path2 = RoundedRectangle.Create(1, 1, rc.Width - 3, rc.Height - 3, 2);
      Gr.DrawPath(penBorder, path);
      Gr.FillPath(brBorder, path2);
      brBorder.Dispose();
      path.Dispose();
      path2.Dispose();

      if (!Value)
      {
        SolidBrush brOnBg = new SolidBrush(this.OffBackgroundColor);
        Pen penBorder2 = new Pen(Color.Black);
        GraphicsPath path3 = RoundedRectangle.Create(2, 2, rc.Width - 5, rc.Height - 5, 2);
        Gr.FillPath(brOnBg, path3);
        penBorder2.Dispose();
        brOnBg.Dispose();
        path3.Dispose();
      }

      if (Value)
      {
        SolidBrush brOnBg = new SolidBrush(this.OnBackgroundColor);
        Pen penBorder2 = new Pen(Color.Black);
        GraphicsPath path3 = RoundedRectangle.Create(2, 2, rc.Width - 5, rc.Height - 5, 2);
        Gr.FillPath(brOnBg, path3);
        penBorder2.Dispose();
        brOnBg.Dispose();
        path3.Dispose();
      }
    }

    private void DrawBody(Graphics Gr)
    {
      RectangleF rc = new RectangleF();

      if (rc.Width <= 0 || rc.Height <= 0)
      {
        rc.Width = 100;
        rc.Height = 50;
      }

      rc.Width = (float)(ClientSize.Width);
      rc.Height = (float)(ClientSize.Height);

      if (rc.Width >= 100 && this.HeaderVisible)
      {
        LinearGradientBrush brBorder = new LinearGradientBrush(rc, HeaderBackColor, Color.Linen, 0f, true);
        brBorder.SetSigmaBellShape(.5f, .6f);
        Pen penBorder = new Pen(HeaderBackColor);
        GraphicsPath path = RoundedRectangle.Create(1, 1, rc.Width - 4, 20, 2);
        Gr.FillPath(brBorder, path);
        Gr.DrawPath(penBorder, path);
        penBorder.Dispose();
        path.Dispose();
        brBorder.Dispose();
        StringFormat stringFormat = new StringFormat();
        stringFormat.Alignment = StringAlignment.Center;
        stringFormat.LineAlignment = StringAlignment.Center;

        string strHeader = this.Header;
        Font font = new Font(this.Font.FontFamily, 10);
        SolidBrush brHeader = new SolidBrush(this.HeaderForeColor);
        float tx = rc.Width / 2;
        float ty = 12;
        SizeF size = Gr.MeasureString(strHeader, font);
        Gr.DrawString(strHeader, font, brHeader, tx, ty, stringFormat);
        brHeader.Dispose();
        if (Value)
        {
          fontOn = new Font(this.Font.FontFamily, rc.Width * 0.1f);
          SolidBrush brOn = new SolidBrush(this.OnTextColor);

          float tx2 = (rc.Width) - (rc.Width) / 4;
          float ty2 = ((rc.Height + 23) / 2);
          Gr.DrawString(this.onLabel, fontOn, brOn, tx2, ty2, stringFormat);
          brOn.Dispose();
          rc.X = rc.X + 3;
          rc.Y = rc.Y + 23;
          rc.Width = rc.Width / 2 - 3;
          rc.Height = rc.Height - 27;
          if (rc.Width == 0 || rc.Height == 0)
          {
            rc.Width = 1;
            rc.Height = 1;
          }

          GraphicsPath path1 = RoundedRectangle.Create(rc.X, rc.Y, rc.Width, rc.Height, 2);
          Pen penSwitchBorder = new Pen(Color.White, 2);
          Color bodyColor1 = Color.FromArgb(175, 175, 175);
          if (this.Shadow == ToggleSwitch.ShadowState.On)
          {
            bodyColor1 = Color.FromArgb(30, 30, 30);
            penSwitchBorder = new Pen(Color.Wheat, 2);
          }

          LinearGradientBrush brBody = new LinearGradientBrush(rc, bodyColor1, bodyColor1, LinearGradientMode.Vertical);
          Gr.FillPath(brBody, path1);
          Gr.DrawPath(penSwitchBorder, path1);
          path1.Dispose();
          brBody.Dispose();
          penSwitchBorder.Dispose();
        }

        if (!Value)
        {
          fontOff = new Font(this.Font.FontFamily, rc.Width * 0.1f);
          SolidBrush brOff = new SolidBrush(this.OffTextColor);
          float tx2 = (rc.Width) / 4;
          float ty2 = (rc.Height + 23) / 2;
          Gr.DrawString(this.offLabel, fontOff, brOff, tx2, ty2, stringFormat);
          brOff.Dispose();
          rc.X = rc.Width / 2;
          rc.Y = rc.Y + 23;
          rc.Width = rc.Width / 2 - 3;
          rc.Height = rc.Height - 27;
          if (rc.Width == 0 || rc.Height == 0)
          {
            rc.Width = 1;
            rc.Height = 1;
          }

          GraphicsPath path1 = RoundedRectangle.Create(rc.X, rc.Y, rc.Width, rc.Height, 2);
          Pen penSwitchBorder = new Pen(Color.White, 2);
          Color bodyColor1 = Color.FromArgb(175, 175, 175);
          if (this.Shadow == ToggleSwitch.ShadowState.On)
          {
            bodyColor1 = Color.FromArgb(30, 30, 30);
            penSwitchBorder = new Pen(Color.Wheat, 2);
          }
          LinearGradientBrush brBody = new LinearGradientBrush(rc, bodyColor1, bodyColor1, LinearGradientMode.Vertical);
          Gr.FillPath(brBody, path1);
          Gr.DrawPath(penSwitchBorder, path1);
          path1.Dispose();
          brBody.Dispose();
          penSwitchBorder.Dispose();
        }
      }
      else
      {
        StringFormat stringFormat = new StringFormat();
        stringFormat.Alignment = StringAlignment.Center;
        stringFormat.LineAlignment = StringAlignment.Center;

        if (Value)
        {
          fontOn = new Font(this.Font.FontFamily, rc.Width * 0.08f);
          SolidBrush brOn = new SolidBrush(this.OnTextColor);
          float tx2 = rc.Width * 3 / 4;
          float ty2 = rc.Height / 2;
          Gr.DrawString(this.onLabel, fontOn, brOn, tx2, ty2, stringFormat);

          rc.X = rc.X + 3;
          rc.Y = rc.Y + 3;
          rc.Width = rc.Width / 2 - 3;
          rc.Height = rc.Height - 7;
          if (rc.Width == 0 || rc.Height == 0)
          {
            rc.Width = 1;
            rc.Height = 1;
          }

          GraphicsPath path1 = RoundedRectangle.Create(rc.X, rc.Y, rc.Width, rc.Height, 2);
          Pen penSwitchBorder = new Pen(Color.White, 2);
          Color bodyColor1 = Color.FromArgb(175, 175, 175);
          if (this.Shadow == ToggleSwitch.ShadowState.On)
          {
            bodyColor1 = Color.FromArgb(30, 30, 30);
            penSwitchBorder = new Pen(Color.Wheat, 2);
          }
          LinearGradientBrush brBody = new LinearGradientBrush(rc, bodyColor1, bodyColor1, LinearGradientMode.Vertical);
          Gr.FillPath(brBody, path1);
          Gr.DrawPath(penSwitchBorder, path1);
          brOn.Dispose();
          brBody.Dispose();
          path1.Dispose();
          penSwitchBorder.Dispose();
        }
        else
        {
          fontOff = new Font(this.Font.FontFamily, rc.Width * 0.08f);
          SolidBrush brOff = new SolidBrush(this.OffTextColor);
          float tx2 = rc.Width / 4;
          float ty2 = rc.Height / 2;
          Gr.DrawString(this.offLabel, fontOff, brOff, tx2, ty2, stringFormat);

          rc.X = rc.Width / 2;
          rc.Y = rc.Y + 3;
          rc.Width = rc.Width / 2 - 3;
          rc.Height = rc.Height - 7;
          if (rc.Width == 0 || rc.Height == 0)
          {
            rc.Width = 1;
            rc.Height = 1;
          }

          GraphicsPath path1 = RoundedRectangle.Create(rc.X, rc.Y, rc.Width, rc.Height, 2);
          Pen penSwitchBorder = new Pen(Color.White, 2);
          Color bodyColor1 = Color.FromArgb(175, 175, 175);
          if (this.Shadow == ToggleSwitch.ShadowState.On)
          {
            bodyColor1 = Color.FromArgb(30, 30, 30);
            penSwitchBorder = new Pen(Color.Wheat, 2);
          }
          LinearGradientBrush brBody = new LinearGradientBrush(rc, bodyColor1, bodyColor1, LinearGradientMode.Vertical);
          Gr.FillPath(brBody, path1);
          Gr.DrawPath(penSwitchBorder, path1);
          brOff.Dispose();
          brBody.Dispose();
          path1.Dispose();
          penSwitchBorder.Dispose();
        }
      }
    }

    #region Mouse events
    private void ToggleSwitch_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left && !DesignModeActive && (SystemMode == SystemModes.Automatic || SystemMode == SystemModes.Manual) && CanUserAccess)
      {
        ValueChangeEventEnabled = true;
        Value = !base.Value;
        this.shadowState = ShadowState.Off;
        Invalidate();
      }
    }

    private void ToggleSwitch_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left && (SystemMode == SystemModes.Automatic || SystemMode == SystemModes.Manual) && !DesignModeActive && CanUserAccess)
      {
        this.shadowState = ShadowState.On;
        Invalidate();
      }
    }
    #endregion
  }


}
