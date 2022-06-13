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
using System.Drawing.Text;

namespace UserInterface
{
  [ToolboxItem(true)]
  public partial class SteeringWheel : AnalogBase
  {
    #region Variables
    private string yaz;
    private float katsay;
    private StringFormat sf;
    private float currValue;
    private string birim;
    private Bitmap swbit;
    private Font ytipi;
    private SizeF textSize;
    private Matrix mxr;
    private Point ilk;
    private float mouseSpeed;
    private TextBox txtValu = new TextBox();
    private PointF ptrr;
    private RectangleF rc = new RectangleF();
    private Font font1;
    private SolidBrush brHeader;
    private float tx, ty, fontSize;
    private SizeF headerSize;
    private LinearGradientBrush brBorder;
    private Pen penBorder;
    private GraphicsPath path;
    private string strHeader;
    #endregion

    #region Ctor
    public SteeringWheel()
    {
      InitializeComponent();
      this.Refresh();
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.UIType = UserInterfaceUsingTypes.Control;
      this.Controls.Add(txtValu);
      this.txtValu.Multiline = true;
      this.txtValu.TextChanged += new System.EventHandler(this.txt_TextChanged);
      this.txtValu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Keypres);
      sf = new StringFormat();
      sf.LineAlignment = StringAlignment.Center;
      sf.Alignment = StringAlignment.Center;
      katsay = (float)1 / 16;
      HeaderForeColor = Color.Black;
      swbit = new Bitmap(UserInterface.Properties.Resources.Lenkrad);
      ytipi = this.HeaderFont = new Font("Arial", (float)this.Height * katsay, FontStyle.Bold);
      mouseSpeed = 4;
      HeaderBackColor = this.BackColor;
    }


    #endregion

    #region Properties
    [Category("DoNotSave")]
    public override float Value
    {
      get { return base.Value; }
      set
      {
        float val = value;
        base.Value = val;
        currValue = val;
        Invalidate();
      }
    }


    public float MouseSpeed
    {
      get { return mouseSpeed; }
      set
      {
        mouseSpeed = value;
        Invalidate();
      }
    }


    [Category("Appearance")]
    public override string Unit
    {
      get { return birim; }
      set
      {
        birim = value;
        Invalidate();
      }
    }


    [Browsable(false)]
    public override HeaderPosition HeaderPosition
    {
      get { return base.HeaderPosition; }
    }

    [Category("Appearance")]
    public override Font HeaderFont
    {
      get { return ytipi; }
      set
      {
        ytipi = value;
        Invalidate();
      }

    }

    [Browsable(false)]
    public override string Header
    {
      get { return base.Header; }
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
    public override Color HighAlarmColor
    {
      get { return base.HighAlarmColor; }
    }

    [Browsable(false), Category("Appearance")]
    public override Color HighWarnColor
    {
      get { return base.HighWarnColor; }
    }

    [Browsable(false), Category("Appearance")]
    public override Color LowAlarmColor
    {
      get { return base.LowAlarmColor; }
    }

    [Browsable(false), Category("Appearance")]
    public override Color LowWarnColor
    {
      get { return base.LowWarnColor; }
    }

    [Browsable(false), Category("Appearance")]
    public override GlobalFunctions.BackFillTypes BackFillType
    {
      get { return base.BackFillType; }
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

    #region Functions
    protected override void OnPaint(PaintEventArgs e)
    {
      e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
      e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
      e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
      e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
      Draw(e.Graphics);
      e.Dispose();
    }

    private void Wheel_Resize()
    {
      this.WidthHeightRatio = 1f;
    }

    public void Draw(Graphics graf)
    {
      //if (HeaderVisible)
      //{


      strHeader = this.Header + " [" + Unit + "]";
      penBorder = new Pen(Color.FromArgb(175, 175, 175));
      headerSize = graf.MeasureString(strHeader, HeaderFont);
      rc.Height = (headerSize.Height);
      rc.Width = this.Width;
      fontSize = rc.Height / 1.5f;
      brBorder = new LinearGradientBrush(rc, Color.Gray, Color.Linen, 0f, true);
      brBorder.SetSigmaBellShape(.5f, .6f);
      path = RoundedRectangle.Create(0, 0, rc.Width, rc.Height, 1);
      graf.FillPath(brBorder, path);
      graf.DrawPath(penBorder, path);
      textSize = headerSize;
      font1 = new Font(HeaderFont.Name, fontSize);
      brHeader = new SolidBrush(this.HeaderForeColor);
      tx = (float)((rc.Width) / 2);
      ty = (float)((rc.Height) / 2);
      graf.DrawString(strHeader, font1, brHeader, tx, ty, sf);


      this.txtValu.Width = (int)(this.Width);
      this.txtValu.Height = (int)(headerSize.Height * 1.3f);
      RectangleF drawRect = new RectangleF(((txtValu.Height + rc.Height) / 2), rc.Height, this.Height - txtValu.Height - rc.Height, this.Height - txtValu.Height - rc.Height);
      this.txtValu.Location = new Point(0, (int)(drawRect.Height + rc.Height));
      this.txtValu.Font = base.HeaderFont;
      this.txtValu.Text = Convert.ToString(currValue);
      //}
      //else
      //{ }
      ptrr = new PointF(this.Width / 2, rc.Height + ((drawRect.Height) / 2));

      mxr = new Matrix();
      mxr.RotateAt(currValue, ptrr, MatrixOrder.Append);
      graf.Transform = mxr;
      graf.DrawImage(swbit, drawRect);

    }

    #endregion

    #region Events

    private void txt_Keypres(object sender, KeyPressEventArgs e)
    {
      if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (e.KeyChar != '\b') && (e.KeyChar != '.') && (e.KeyChar != '-')) e.Handled = true;

      if (e.KeyChar == (char)Keys.Return)
      {
        if (this.txtValu.Text != "")
        {
          this.Value = (float)Convert.ToDouble(txtValu.Text);
          this.label1.Focus();
        }
      }
    }

    private void txt_TextChanged(object sender, EventArgs e)
    {

    }

    private void SteeringWheel_MouseMove(object sender, MouseEventArgs e)
    {

      if ((e.Button == MouseButtons.Left) && !DesignModeActive)
      {
        ////////////// Birinci Bölge Hareket /////////////////////////////////
        if ((e.X >= ptrr.X) && (ptrr.Y >= e.Y) && (e.X < ilk.X) && (e.Y < ilk.Y))
        {
          currValue = currValue - mouseSpeed;
          this.Value = currValue;
          this.txtValu.Text = Convert.ToString(currValue);
        }
        else if ((e.X >= ptrr.X) && (ptrr.Y >= e.Y) && (e.X > ilk.X) && (e.Y > ilk.Y))
        {
          currValue = currValue + mouseSpeed;
          this.Value = currValue;
          this.txtValu.Text = Convert.ToString(currValue);
        }
        //////////////////////////////////////////////////////////////////////
        ////////////// İkinci Bölge Hareket //////////////////////////////////
        else if ((e.X >= ptrr.X) && (ptrr.Y <= e.Y) && (e.X < ilk.X) && (e.Y > ilk.Y))
        {
          currValue = currValue + mouseSpeed;
          this.Value = currValue;
          this.txtValu.Text = Convert.ToString(currValue);
        }
        else if ((e.X >= ptrr.X) && (ptrr.Y <= e.Y) && (e.X > ilk.X) && (e.Y < ilk.Y))
        {
          currValue = currValue - mouseSpeed;
          this.Value = currValue;
          this.txtValu.Text = Convert.ToString(currValue);
        }
        //////////////////////////////////////////////////////////////////////
        ////////////// Üçüncü Bölge Hareket //////////////////////////////////
        else if ((e.X <= ptrr.X) && (ptrr.Y <= e.Y) && (e.X < ilk.X) && (e.Y < ilk.Y))
        {
          currValue = currValue + mouseSpeed;
          this.Value = currValue;
          this.txtValu.Text = Convert.ToString(currValue);
        }
        else if ((e.X <= ptrr.X) && (ptrr.Y <= e.Y) && (e.X > ilk.X) && (e.Y > ilk.Y))
        {
          currValue = currValue - mouseSpeed;
          this.Value = currValue;
          this.txtValu.Text = Convert.ToString(currValue);
        }
        ///////////////////////////////////////////////////////////////////////
        ////////////// Dördüncü Bölge Hareket /////////////////////////////////
        else if ((e.X <= ptrr.X) && (ptrr.Y >= e.Y) && (e.X > ilk.X) && (e.Y < ilk.Y))
        {
          currValue = currValue + mouseSpeed;
          this.Value = currValue;
          this.txtValu.Text = Convert.ToString(currValue);
        }
        else if ((e.X <= ptrr.X) && (ptrr.Y >= e.Y) && (e.X < ilk.X) && (e.Y > ilk.Y))
        {
          currValue = currValue - mouseSpeed;
          this.Value = currValue;
          this.txtValu.Text = Convert.ToString(currValue);      
        }
        ///////////////////////////////////////////////////////////////////////
        //Invalidate();
      }

      ilk = e.Location;
    }

    private void SteeringWheel_MouseDown(object sender, MouseEventArgs e)
    {
      ilk = e.Location;
      this.label1.Focus();
      Invalidate();
    }

    private void SteeringWheel_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
    {
      if (!DesignModeActive)
      {
        if (e.Delta > 0)
        {
          currValue = currValue + 1;
          this.Value = currValue;
          //Invalidate();
        }
        else if (e.Delta < 0)
        {
          currValue = currValue - 1;
          this.Value = currValue;
          //Invalidate();
        }

      }
    }

    protected override void OnSizeChanged(EventArgs e)
    {
      base.OnSizeChanged(e);
      Wheel_Resize();
    }


    #endregion

  }
}
