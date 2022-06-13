using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.GraphPlotter
{
  internal static class CommonFunction
  {
    delegate void SetPropControlCallBack(Control ctrl, int width, Font font, Color foreColor);
    internal static event AxisValueChangedHandler AxisChanged;
    internal static void AddAxisTextBox
      (RealTimeGraph owner, Control selectnextctrl, TextBox[] AxisExtremValtxtBox, float MinValue, float MaxValue, NumberFormatInfo nfi, int curveno, bool _doubleclicked, int precision, AxisNames axis)
    {

      for (int y = 0; y < 2; y++)
      {
        AxisExtremValtxtBox[y] = new TextBox();
        owner.Controls.Add(AxisExtremValtxtBox[y]);
        if (axis == AxisNames.Y) AxisExtremValtxtBox[y].Name = "txtYaxis" + y.ToString();
        else AxisExtremValtxtBox[y].Name = "txtXaxis" + y.ToString(); ;
        TextBox mtextbox = AxisExtremValtxtBox[y];
        mtextbox.BackColor = owner.BackColor;
        mtextbox.BorderStyle = BorderStyle.None;
        mtextbox.AcceptsReturn = true;
        if (axis == AxisNames.Y)
        {
          if (y == 1) mtextbox.Text = FormatNumber(MinValue, precision, nfi);
          else mtextbox.Text = FormatNumber(MaxValue, precision, nfi);
          if (curveno < 2)
            mtextbox.TextAlign = HorizontalAlignment.Right;
          else
            mtextbox.TextAlign = HorizontalAlignment.Left;
        }
        else
        {
          if (y == 0)
          {
            mtextbox.TextAlign = HorizontalAlignment.Left;
            mtextbox.Text = FormatNumber(MinValue, precision, nfi);
          }
          else
          {
            mtextbox.TextAlign = HorizontalAlignment.Right;
            mtextbox.Text = FormatNumber(MaxValue, precision, nfi);
          }
        }
        mtextbox.Click += (object sender, EventArgs e) =>
        {
          if (!_doubleclicked)
            selectnextctrl.Focus();
        };
        mtextbox.DoubleClick += (object sender, EventArgs e) =>
        {
          _doubleclicked = true;
          mtextbox.BackColor = Color.White;
          mtextbox.Focus();
          mtextbox.SelectAll();
        };
        mtextbox.LostFocus += (object sender, EventArgs e) =>
        {
          if (!_doubleclicked) return;
          mtextbox.Text = FormatNumber(mtextbox.Text, precision, nfi);
          mtextbox.BackColor = owner.BackColor;
          _doubleclicked = false;
          float maxval;
          float minval;
          AxisNames axs;

          switch (mtextbox.Name)
          {
            case "txtXaxis0":
              minval = float.Parse(mtextbox.Text, nfi);
              maxval = float.Parse(AxisExtremValtxtBox[1].Text, nfi);
              axs = AxisNames.X;
              break;
            case "txtXaxis1":
              minval = float.Parse(AxisExtremValtxtBox[0].Text, nfi);
              maxval = float.Parse(mtextbox.Text, nfi);
              axs = AxisNames.X;
              break;
            case "txtYaxis0":
              maxval = float.Parse(mtextbox.Text, nfi);
              minval = float.Parse(AxisExtremValtxtBox[1].Text, nfi);
              axs = AxisNames.Y;
              break;
            case "txtYaxis1":
              maxval = float.Parse(AxisExtremValtxtBox[0].Text, nfi);
              minval = float.Parse(mtextbox.Text, nfi);
              axs = AxisNames.Y;
              break;
            default:
              minval = MinValue;
              maxval = MaxValue;
              axs = AxisNames.none;
              break;

          }
          if (minval == maxval)
          {
            minval = MinValue;
            maxval = MaxValue;
            AxisExtremValtxtBox[0].Text = MaxValue.ToString(nfi);
            AxisExtremValtxtBox[1].Text = MinValue.ToString(nfi);
          }
          if (AxisChanged != null)
            AxisChanged(owner, axs, curveno, minval, maxval);

        };
        mtextbox.KeyDown += (object sender, KeyEventArgs e) =>
        {

          if (e.KeyCode == Keys.Return)
            selectnextctrl.Focus();

        };
        mtextbox.KeyPress += (object sender, KeyPressEventArgs e) =>
        {
          if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (e.KeyChar != '.') && (e.KeyChar != '\b') && (e.KeyChar != '-')) e.Handled = true;

        };
      }
    }
    internal static string FormatNumber(string str, int prec, NumberFormatInfo nfi)
    {
      nfi.NumberDecimalDigits = prec;

      return Math.Round(double.Parse(str, nfi), prec).ToString("N", nfi);

    }
    internal static string FormatNumber(float nmbr, int prec, NumberFormatInfo nfi)
    {
      nfi.NumberDecimalDigits = prec;
      return Math.Round(nmbr, prec).ToString("N", nfi);
    }
    internal static float FontSize(Size currentsize, SizeF fontoran)
    {
      return (currentsize.Width > currentsize.Height) ? currentsize.Width * fontoran.Width : currentsize.Height * fontoran.Height;
    }
    internal static void SetProp(Control ctrl, int width, Font font, Color foreColor)
    {
      if (ctrl.InvokeRequired)
      {
        SetPropControlCallBack d = new SetPropControlCallBack(SetProp);
        try
        {
          ctrl.Invoke(d, new object[] { ctrl, width, font, foreColor });
        }
        catch { };
      }
      else
      {
        ctrl.Width = width;
        ctrl.Font = font;
        ctrl.ForeColor = foreColor;
      }
    }
    internal static void ResizeDrawControls(UserControl owner, Rectangle drwrec, SizeF spaceoran, SizeF textboxoran,
      SizeF fontoranothers, int tickspace, int tickcount, float MaxValue, float MinValue,
      Color CurveColor, TextBox[] AxisExtremValtxtBox, int precision, NumberFormatInfo nfi, int curveno, AxisNames axis, string curvename)
    {
      string str = owner.Name;
      if (owner.Width == 0 || owner.Height == 0) return;
      #region init sub
      int xartis = Convert.ToInt32((float)drwrec.Width / (tickcount - 1));
      int yartis = Convert.ToInt32((float)drwrec.Height / (tickcount - 1));
      float valueinc = (MaxValue - MinValue) / (tickcount - 1);
      Graphics grph = owner.CreateGraphics();
      grph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
      System.Drawing.SolidBrush brs = new SolidBrush(CurveColor);
      #endregion
      #region Resizing
      if (axis == AxisNames.X)
      {
        System.Drawing.SolidBrush brsh = new SolidBrush(owner.BackColor);
        grph.FillRectangle(brsh, new Rectangle(AxisExtremValtxtBox[0].Left, AxisExtremValtxtBox[0].Top, owner.Width, owner.Bottom - drwrec.Bottom));
      }

      for (int y = 0; y < 2; y++)
      {
        TextBox txtbx = AxisExtremValtxtBox[y];
        //txtbx.Width = Convert.ToInt32((owner.Size.Width - drwrec.Width - 2 * tickspace) / 2);
        //txtbx.Font = new Font(txtbx.Font.Name, CommonFunction.FontSize(owner.Size, fontoranothers));
        //txtbx.ForeColor = CurveColor;

        for (int i = 1; i < tickcount - 1; i++)
        {
          Size temp = new Size();
          string mtxt;
          if (axis == AxisNames.Y) mtxt = FormatNumber((MaxValue - i * valueinc), precision, nfi);
          else mtxt = FormatNumber((MinValue + i * valueinc), precision, nfi);
          SizeF t1 = grph.MeasureString(mtxt, txtbx.Font);
          temp.Width = Convert.ToInt32(t1.Width);
          temp.Height = Convert.ToInt32(t1.Height);
          if (axis == AxisNames.Y)
          {
            switch (curveno)
            {
              case 0:
                grph.DrawString(mtxt, txtbx.Font, brs, drwrec.Left - tickspace - temp.Width, drwrec.Top + i * yartis - temp.Height);
                //if (i == 1) grph.DrawString(curvename, txtbx.Font, brs, drwrec.Left, drwrec.Top - 2 * temp.Height);
                break;
              case 1:
                grph.DrawString(mtxt, txtbx.Font, brs, drwrec.Left - tickspace - temp.Width, drwrec.Top + i * yartis);
                //if (i == 1) grph.DrawString(curvename, txtbx.Font, brs, drwrec.Left, drwrec.Top - temp.Height);
                break;
              case 2:
                grph.DrawString(mtxt, txtbx.Font, brs, drwrec.Right + tickspace, drwrec.Top + i * yartis - temp.Height);
                //if (i == 1) grph.DrawString(curvename, txtbx.Font, brs, (drwrec.Left+drwrec.Width) *0.8F , drwrec.Top - 2 * temp.Height);
                break;
              case 3:
                grph.DrawString(mtxt, txtbx.Font, brs, drwrec.Right + tickspace, drwrec.Top + i * yartis);
                //if (i == 1) grph.DrawString(curvename, txtbx.Font, brs, (drwrec.Left + drwrec.Width) * 0.8F, drwrec.Top - temp.Height);
                break;
            }
          }
          else
          {
            grph.DrawString(mtxt, txtbx.Font, brs, drwrec.Left + i * xartis - temp.Width / 2, drwrec.Bottom + tickspace);
            if (i == 1)
            {
              SizeF wd = grph.MeasureString(curvename, txtbx.Font);
              grph.DrawString(curvename, txtbx.Font, brs, (owner.Width - wd.Width) / 2, owner.Height - 1.5F * wd.Height);

            }
          }
        }

        //if (axis == AxisNames.Y)
        //{
        //  switch (curveno)
        //  {
        //    case 0:
        //      txtbx.Left = drwrec.Left - txtbx.Width - tickspace;
        //      txtbx.Top = drwrec.Top + y * drwrec.Height - txtbx.Height;
        //      break;
        //    case 1:
        //      txtbx.Left = drwrec.Left - txtbx.Width - tickspace;
        //      txtbx.Top = drwrec.Top + y * drwrec.Height;
        //      break;
        //    case 2:
        //      txtbx.Left = drwrec.Right + tickspace;
        //      txtbx.Top = drwrec.Top + y * drwrec.Height - txtbx.Height;
        //      break;
        //    case 3:
        //      txtbx.Left = drwrec.Right + tickspace;
        //      txtbx.Top = drwrec.Top + y * drwrec.Height;
        //      break;
        //  }
        //}
        //else
        //{
        //  if (y == 0) txtbx.Left = drwrec.Left ;
        //  else txtbx.Left = drwrec.Right - txtbx.Width;
        //  txtbx.Top = drwrec.Bottom + tickspace;

        //}

      }
      #endregion
      brs.Dispose();
      grph.Dispose();
    }
    //SAkın silme dikey yazı yazma alt programı !!!!!!!!
    //internal void DrawVerticalString()
    //{
    //  System.Drawing.Graphics formGraphics = this.CreateGraphics();
    //  string drawString = "Sample Text";
    //  System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 16);
    //  System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
    //  float x = 150.0F;
    //  float y = 50.0F;
    //  System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
    //  drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
    //  formGraphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
    //  drawFont.Dispose();
    //  drawBrush.Dispose();
    //  formGraphics.Dispose();
    //}
  }
}
