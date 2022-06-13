using System;
using System.Drawing;
using System.Globalization;
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

    internal static PointF[] LargestTriangleThreeBuckets(PointF[] data, int threshold)
    {
      int data_length = data.Length;
      if (threshold >= data_length || threshold == 0)
        return data; // Nothing to do
      PointF[] sampled = new PointF[threshold];
      int sampled_index = 0;
      // Bucket size. Leave room for start and end data points
      int bucketCount = (data_length - 2) / (threshold - 2);
      PointF max_area_point = new PointF();
      int a = 0;  // Initially a is the first point in the triangle
      int next_a = 0;
      float max_area, area;
      sampled[sampled_index++] = data[a]; // Always add the first point
      for (int i = 0; i < threshold - 2; i++)
      {
        // Calculate point average for next bucket (containing c)
        float avg_x = 0, avg_y = 0;
        int avg_range_start = (i + 1) * bucketCount + 1;
        int avg_range_end = (i + 2) * bucketCount + 1;
        avg_range_end = avg_range_end < data_length ? avg_range_end : data_length;
        int avg_range_length = avg_range_end - avg_range_start;

        for (; avg_range_start < avg_range_end; avg_range_start++)
        {
          avg_x += data[avg_range_start].X * 1; // * 1 enforces Number (value may be Date)
          avg_y += data[avg_range_start].Y * 1;
        }
        avg_x /= avg_range_length;
        avg_y /= avg_range_length;

        // Get the range for this bucket
        int range_offs = (i + 0) * bucketCount + 1;
        int range_to = (i + 1) * bucketCount + 1;

        // Point a
        PointF point_a = new PointF(data[a].X * 1, data[a].Y * 1); // enforce Number (value may be Date)
        max_area = area = -1;

        for (; range_offs < range_to; range_offs++)
        {
          // Calculate triangle area over three buckets
          area = Math.Abs((point_a.X - avg_x) * (data[range_offs].Y - point_a.Y - (point_a.X - data[range_offs].X) * (avg_y - point_a.Y))) * 0.5f;
          //area = CommonFunction.TriangleArea(point_a, data[range_offs], new PointF(avg_x,avg_y));
          if (area > max_area)
          {
            max_area = area;
            max_area_point = data[range_offs];
            next_a = range_offs; // Next a is this b
          }
        }

        sampled[sampled_index++] = max_area_point; // Pick this point from the bucket
        a = next_a; // This a is the next a (chosen b)
      }
      sampled[sampled_index++] = data[data_length - 1]; // Always add last
      return sampled;
    }

    internal static PointF[] LargestTriangleThreeBuckets(PointF[] input, int startIndex, int lastIndex, int threshold)
    {
      PointF[] sampled = new PointF[threshold];
      int input_length = lastIndex - startIndex;
      if (threshold >= input_length || threshold == 0)
      {
        sampled = new PointF[input_length];
        for (int i = startIndex; i < lastIndex; i++)
          sampled[i - startIndex] = input[i];
        return sampled; // Nothing to do
      }
      int sampled_index = 0;
      int extra = 0;
      if (input_length % threshold != 0)
        extra = threshold - input_length % threshold;
      // Bucket size. Leave room for start and end data points
      int bucketCount = (input_length + extra - 2) / (threshold - 2);
      PointF max_area_point = new PointF();
      int a = startIndex;  // Initially a is the first point in the triangle
      int next_a = startIndex;
      float max_area, area;
      sampled[sampled_index++] = input[a]; // Always add the first point
      for (int i = 0; i < threshold - 2; i++)
      {
        // Calculate point average for next bucket (containing c)
        float avg_x = 0, avg_y = 0;
        int avg_range_start = (i + 1) * bucketCount + 1 + startIndex;
        int avg_range_end = (i + 2) * bucketCount + 1 + startIndex;
        //avg_range_end = avg_range_end < (input_length + extra + startIndex) ? avg_range_end : input_length + extra + startIndex;
        int avg_range_length = avg_range_end - avg_range_start;

        for (; avg_range_start < avg_range_end; avg_range_start++)
        {
          int index = avg_range_start > (input_length - 1 + startIndex) ? input_length - 1 + startIndex : avg_range_start;
          avg_x += input[index].X * 1; // * 1 enforces Number (value may be Date)
          avg_y += input[index].Y * 1;
        }
        avg_x /= avg_range_length;
        avg_y /= avg_range_length;

        // Get the range for this bucket
        int range_offs = (i + 0) * bucketCount + 1 + startIndex;
        int range_to = (i + 1) * bucketCount + 1 + startIndex;

        // Point a
        PointF point_a = new PointF(input[a].X * 1, input[a].Y * 1); // enforce Number (value may be Date)
        max_area = area = -1;

        for (; range_offs < range_to; range_offs++)
        {
          // Calculate triangle area over three buckets
          int index = range_offs > (input_length - 1 + startIndex) ? input_length - 1 + startIndex : range_offs;
          area = Math.Abs((point_a.X - avg_x) * (input[index].Y - point_a.Y - (point_a.X - input[index].X) * (avg_y - point_a.Y))) * 0.5f;
          if (area > max_area)
          {
            max_area = area;
            max_area_point = input[index];
            next_a = index; // Next a is this b
          }
        }

        sampled[sampled_index++] = max_area_point; // Pick this point from the bucket
        a = next_a; // This a is the next a (chosen b)
      }
      sampled[sampled_index++] = input[input_length - 1 + startIndex]; // Always add last
      return sampled;
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

    /// <summary>
    /// Akın's function
    /// </summary>
    /// <param name="input"></param>
    /// <param name="startIndex"></param>
    /// <param name="lastIndex"></param>
    /// <param name="threshold"></param>
    /// <returns></returns>
    internal static PointF[] LargestTriangleThreeBucket(PointF[] input, int startIndex, int lastIndex, int threshold)
    {
      PointF[] sampled = new PointF[threshold];
      int input_length = lastIndex - startIndex;
      if (threshold >= input_length || threshold == 0)
      {
        sampled = new PointF[input_length];
        for (int i = startIndex; i < lastIndex; i++)
          sampled[i - startIndex] = input[i];
        return sampled; // Nothing to do
      }
      int extra = 0;
      if (input_length % threshold != 0)
        extra = threshold - input_length % threshold;
    
      sampled[0] = input[startIndex];
      sampled[threshold - 1] = input[lastIndex];
      int sol = (input_length + extra - 2) / (threshold - 2);      // number of points in one bucket. First and last bucket is fixed with first and last value
      
      int take = 0, ind = 0;
      PointF[] buff;
      PointF temp = new PointF();
      float area, max = 0, sum = 0;

      for (int i = 0; i < threshold - 2; i++)
      {

        take = sol;
        buff = new PointF[take]; //initilazing bucket size
        for (int a = 0; a < take; a++)
          buff[a] = input[i * take + a + 1 + startIndex]; //creating bucket
        if (i != threshold - 3)
        {
          temp.X = input[(i + 1) * take + take / 2 - 1 + startIndex].X;    //finding time average, just take middle point...
          for (int b = 0; b < take; b++)
            sum = input[(i + 1) * take + b + 1 + startIndex].Y + sum;  //finding average in next bucket
          temp.Y = sum / take;
        }
        else
          temp = sampled[threshold - 1]; // if it is reached final bucket cancel averaging
        ind = 0;
        for (int k = 0; k < buff.Length; k++)              // finding maximum area
        {
          area = TriangleArea(sampled[0], buff[k], temp);
          if (area > max)
          {
            max = area;
            ind = k;
          }
        }
        sampled[i + 1] = buff[ind];
      }
      return sampled;
    }

    private static float TriangleArea(PointF point1, PointF point2, PointF point3)
    {
      return 1 / 2f * Math.Abs(point1.X * point2.Y + point2.X * point3.Y + point3.X * point1.Y - point2.X * point1.Y - point3.X * point2.Y - point1.X * point3.Y);
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
