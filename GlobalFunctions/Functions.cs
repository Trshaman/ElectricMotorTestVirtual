using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.XPath;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.ComponentModel;
using System.Reflection;
using System.Drawing.Drawing2D;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;
using Microsoft.Win32;
using System.ServiceProcess;
using System.Collections;
using System.Threading.Tasks;

namespace GlobalFunctions
{
  public enum BackFillTypes
  {
    None, Solid, Gradient
  }

  /// <summary>
  /// Windows Message list
  /// </summary>
  public enum WM_Messages
  {
    WM_ACTIVATE = 0x0006,
    WM_ACTIVATEAPP = 0x001C,
    WM_AFXFIRST = 0x0360,
    WM_AFXLAST = 0x037F,
    WM_APP = 0x8000,
    WM_ASKCBFORMATNAME = 0x030C,
    WM_CANCELJOURNAL = 0x004B,
    WM_CANCELMODE = 0x001F,
    WM_CAPTURECHANGED = 0x0215,
    WM_CHANGECBCHAIN = 0x030D,
    WM_CHANGEUISTATE = 0x0127,
    WM_CHAR = 0x0102,
    WM_CHARTOITEM = 0x002F,
    WM_CHILDACTIVATE = 0x0022,
    WM_CLEAR = 0x0303,
    WM_CLOSE = 0x0010,
    WM_COMMAND = 0x0111,
    WM_COMPACTING = 0x0041,
    WM_COMPAREITEM = 0x0039,
    WM_CONTEXTMENU = 0x007B,
    WM_COPY = 0x0301,
    WM_COPYDATA = 0x004A,
    WM_CREATE = 0x0001,
    WM_CTLCOLORBTN = 0x0135,
    WM_CTLCOLORDLG = 0x0136,
    WM_CTLCOLOREDIT = 0x0133,
    WM_CTLCOLORLISTBOX = 0x0134,
    WM_CTLCOLORMSGBOX = 0x0132,
    WM_CTLCOLORSCROLLBAR = 0x0137,
    WM_CTLCOLORSTATIC = 0x0138,
    WM_CUT = 0x0300,
    WM_DEADCHAR = 0x0103,
    WM_DELETEITEM = 0x002D,
    WM_DESTROY = 0x0002,
    WM_DESTROYCLIPBOARD = 0x0307,
    WM_DEVICECHANGE = 0x0219,
    WM_DEVMODECHANGE = 0x001B,
    WM_DISPLAYCHANGE = 0x007E,
    WM_DRAWCLIPBOARD = 0x0308,
    WM_DRAWITEM = 0x002B,
    WM_DROPFILES = 0x0233,
    WM_ENABLE = 0x000A,
    WM_ENDSESSION = 0x0016,
    WM_ENTERIDLE = 0x0121,
    WM_ENTERMENULOOP = 0x0211,
    WM_ENTERSIZEMOVE = 0x0231,
    WM_ERASEBKGND = 0x0014,
    WM_EXITMENULOOP = 0x0212,
    WM_EXITSIZEMOVE = 0x0232,
    WM_FONTCHANGE = 0x001D,
    WM_GETDLGCODE = 0x0087,
    WM_GETFONT = 0x0031,
    WM_GETHOTKEY = 0x0033,
    WM_GETICON = 0x007F,
    WM_GETMINMAXINFO = 0x0024,
    WM_GETOBJECT = 0x003D,
    WM_GETTEXT = 0x000D,
    WM_GETTEXTLENGTH = 0x000E,
    WM_HANDHELDFIRST = 0x0358,
    WM_HANDHELDLAST = 0x035F,
    WM_HELP = 0x0053,
    WM_HOTKEY = 0x0312,
    WM_HSCROLL = 0x0114,
    WM_HSCROLLCLIPBOARD = 0x030E,
    WM_ICONERASEBKGND = 0x0027,
    WM_IME_CHAR = 0x0286,
    WM_IME_COMPOSITION = 0x010F,
    WM_IME_COMPOSITIONFULL = 0x0284,
    WM_IME_CONTROL = 0x0283,
    WM_IME_ENDCOMPOSITION = 0x010E,
    WM_IME_KEYDOWN = 0x0290,
    WM_IME_KEYLAST = 0x010F,
    WM_IME_KEYUP = 0x0291,
    WM_IME_NOTIFY = 0x0282,
    WM_IME_REQUEST = 0x0288,
    WM_IME_SELECT = 0x0285,
    WM_IME_SETCONTEXT = 0x0281,
    WM_IME_STARTCOMPOSITION = 0x010D,
    WM_INITDIALOG = 0x0110,
    WM_INITMENU = 0x0116,
    WM_INITMENUPOPUP = 0x0117,
    WM_INPUTLANGCHANGE = 0x0051,
    WM_INPUTLANGCHANGEREQUEST = 0x0050,
    WM_KEYDOWN = 0x0100,
    WM_KEYFIRST = 0x0100,
    WM_KEYLAST = 0x0108,
    WM_KEYUP = 0x0101,
    WM_KILLFOCUS = 0x0008,
    WM_LBUTTONDBLCLK = 0x0203,
    WM_LBUTTONDOWN = 0x0201,
    WM_LBUTTONUP = 0x0202,
    WM_MBUTTONDBLCLK = 0x0209,
    WM_MBUTTONDOWN = 0x0207,
    WM_MBUTTONUP = 0x0208,
    WM_MDIACTIVATE = 0x0222,
    WM_MDICASCADE = 0x0227,
    WM_MDICREATE = 0x0220,
    WM_MDIDESTROY = 0x0221,
    WM_MDIGETACTIVE = 0x0229,
    WM_MDIICONARRANGE = 0x0228,
    WM_MDIMAXIMIZE = 0x0225,
    WM_MDINEXT = 0x0224,
    WM_MDIREFRESHMENU = 0x0234,
    WM_MDIRESTORE = 0x0223,
    WM_MDISETMENU = 0x0230,
    WM_MDITILE = 0x0226,
    WM_MEASUREITEM = 0x002C,
    WM_MENUCHAR = 0x0120,
    WM_MENUCOMMAND = 0x0126,
    WM_MENUDRAG = 0x0123,
    WM_MENUGETOBJECT = 0x0124,
    WM_MENURBUTTONUP = 0x0122,
    WM_MENUSELECT = 0x011F,
    WM_MOUSEACTIVATE = 0x0021,
    WM_MOUSEFIRST = 0x0200,
    WM_MOUSEHOVER = 0x02A1,
    WM_MOUSELAST = 0x020D,
    WM_MOUSELEAVE = 0x02A3,
    WM_MOUSEMOVE = 0x0200,
    WM_MOUSEWHEEL = 0x020A,
    WM_MOUSEHWHEEL = 0x020E,
    WM_MOVE = 0x0003,
    WM_MOVING = 0x0216,
    WM_NCACTIVATE = 0x0086,
    WM_NCCALCSIZE = 0x0083,
    WM_NCCREATE = 0x0081,
    WM_NCDESTROY = 0x0082,
    WM_NCHITTEST = 0x0084,
    WM_NCLBUTTONDBLCLK = 0x00A3,
    WM_NCLBUTTONDOWN = 0x00A1,
    WM_NCLBUTTONUP = 0x00A2,
    WM_NCMBUTTONDBLCLK = 0x00A9,
    WM_NCMBUTTONDOWN = 0x00A7,
    WM_NCMBUTTONUP = 0x00A8,
    WM_NCMOUSEMOVE = 0x00A0,
    WM_NCPAINT = 0x0085,
    WM_NCRBUTTONDBLCLK = 0x00A6,
    WM_NCRBUTTONDOWN = 0x00A4,
    WM_NCRBUTTONUP = 0x00A5,
    WM_NCUAHDRAWCAPTION = 0x00AE,
    WM_NCUAHDRAWFRAME = 0x00AF,
    WM_NEXTDLGCTL = 0x0028,
    WM_NEXTMENU = 0x0213,
    WM_NOTIFY = 0x004E,
    WM_NOTIFYFORMAT = 0x0055,
    WM_NULL = 0x0000,
    WM_PAINT = 0x000F,
    WM_PAINTCLIPBOARD = 0x0309,
    WM_PAINTICON = 0x0026,
    WM_PALETTECHANGED = 0x0311,
    WM_PALETTEISCHANGING = 0x0310,
    WM_PARENTNOTIFY = 0x0210,
    WM_PASTE = 0x0302,
    WM_PENWINFIRST = 0x0380,
    WM_PENWINLAST = 0x038F,
    WM_POWER = 0x0048,
    WM_POWERBROADCAST = 0x0218,
    WM_PRINT = 0x0317,
    WM_PRINTCLIENT = 0x0318,
    WM_QUERYDRAGICON = 0x0037,
    WM_QUERYENDSESSION = 0x0011,
    WM_QUERYNEWPALETTE = 0x030F,
    WM_QUERYOPEN = 0x0013,
    WM_QUEUESYNC = 0x0023,
    WM_QUIT = 0x0012,
    WM_RBUTTONDBLCLK = 0x0206,
    WM_RBUTTONDOWN = 0x0204,
    WM_RBUTTONUP = 0x0205,
    WM_RENDERALLFORMATS = 0x0306,
    WM_RENDERFORMAT = 0x0305,
    WM_SETCURSOR = 0x0020,
    WM_SETFOCUS = 0x0007,
    WM_SETFONT = 0x0030,
    WM_SETHOTKEY = 0x0032,
    WM_SETICON = 0x0080,
    WM_SETREDRAW = 0x000B,
    WM_SETTEXT = 0x000C,
    WM_SETTINGCHANGE = 0x001A,
    WM_SHOWWINDOW = 0x0018,
    WM_SIZE = 0x0005,
    WM_SIZECLIPBOARD = 0x030B,
    WM_SIZING = 0x0214,
    WM_SPOOLERSTATUS = 0x002A,
    WM_STYLECHANGED = 0x007D,
    WM_STYLECHANGING = 0x007C,
    WM_SYNCPAINT = 0x0088,
    WM_SYSCHAR = 0x0106,
    WM_SYSCOLORCHANGE = 0x0015,
    WM_SYSCOMMAND = 0x0112,
    WM_SYSDEADCHAR = 0x0107,
    WM_SYSKEYDOWN = 0x0104,
    WM_SYSKEYUP = 0x0105,
    WM_TCARD = 0x0052,
    WM_TIMECHANGE = 0x001E,
    WM_TIMER = 0x0113,
    WM_UNDO = 0x0304,
    WM_UNINITMENUPOPUP = 0x0125,
    WM_USER = 0x0400,
    WM_USERCHANGED = 0x0054,
    WM_VKEYTOITEM = 0x002E,
    WM_VSCROLL = 0x0115,
    WM_VSCROLLCLIPBOARD = 0x030A,
    WM_WINDOWPOSCHANGED = 0x0047,
    WM_WINDOWPOSCHANGING = 0x0046,
    WM_WININICHANGE = 0x001A,
    WM_XBUTTONDBLCLK = 0x020D,
    WM_XBUTTONDOWN = 0x020B,
    WM_XBUTTONUP = 0x020C
  }

  public struct DatabaseParam
  {
    public string ServerName;
    public string DatabaseName;
    //Data file parameters
    public string DataFileName;
    public string DataPathName;
    public int DataFileSize;
    public string DataFileGrowth;
    //Log file parameters
    public string LogFileName;
    public string LogPathName;
    public int LogFileSize;
    public string LogFileGrowth;
  }

  public enum SystemModes
  {
    Monitor = 0,
    Manual = 1,
    Automatic = 2,
    Design = 3
  }

  //list sıralama yöntemi kalibrasyonda kullanılacak.
  //calParams.Sort( (CalibrationParameters p1, CalibrationParameters p2) => { return p1.Xvalue.CompareTo(p2.Xvalue); });
  /// <summary>
  /// General Functions for programming
  /// </summary>
  public static class Functions
  {

    #region Math Functions
    public static float GetRadian(float val)
    {
      return (float)(val * Math.PI / 180);
    }
    public static string BitInvert(ref byte value, byte DoNo, byte MaxLegth)
    {
      byte tempbyte = (byte)(value & (byte)(Math.Pow(2, DoNo)));
      if (tempbyte == 0)
        value |= (byte)Math.Pow(2, DoNo);
      else
      {
        tempbyte = (byte)(Math.Pow(2, DoNo));
        tempbyte = (byte)~tempbyte;
        value &= (byte)(tempbyte);
      }
      string temp = String.Format("{0:X}", value);
      if (temp.Length != MaxLegth)
        temp = temp.PadLeft(MaxLegth, '0');
      return temp;
    }
    public static string CheckSum(string data)
    {
      int temp = 0;
      foreach (char _chr in data)
        temp += Convert.ToInt32(_chr);
      temp = temp % 256;
      return String.Format("{0:X}", temp);
    }

    public static bool CheckSum(List<byte> data)
    {
      int temp = 0;
      for (int i = 0; i < data.Count - 2; i++)
        temp += data[i];
      return temp == BitConverterExtented.ToInt16(data.ToArray(), data.Count - 2, false);
    }

    public static byte[] CheckSum(byte[] data, bool isLittleEndian)
    {
      int temp = 0;
      for (int i = 0; i < data.Length - 2; i++)
        temp += data[i];
      if (isLittleEndian)
        return BitConverterExtented.GetLittleEndianBytes(temp);
      else
        return BitConverter.GetBytes(temp);
    }

    /// <summary>
    /// Return complemantery checksum
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static byte ComplementeryCheckSum(byte[] data)
    {
      int temp = 0;
      foreach (byte byt in data)
        temp += byt;
      temp = 256 - temp % 256;
      return (byte)temp;

    }

    /// <summary>
    /// Calculate to check sum and compare last byte
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static bool ComplementeryCheckSumControl(byte[] data)
    {
      byte temp = 0;
      for (int i = 0; i < data.Length - 1; i++)
        temp += data[i];
      return (byte)(256 - temp % 256) == data[data.Length - 1];
    }

    /// <summary>
    /// Return complemantery checksum
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static byte ComplementeryCheckSum(List<byte> data)
    {
      int temp = 0;
      foreach (byte byt in data)
        temp += byt;
      temp = 256 - temp % 256;
      return (byte)temp;

    }
    public static string BitSetReset(ref byte value, byte BitNo, bool BitVal, byte MaxLength)
    {
      if (BitVal)
        value |= (byte)Math.Pow(2, BitNo);
      else
        value &= (byte)~(int)(Math.Pow(2, BitNo));
      string temp = String.Format("{0:X}", value);
      if (temp.Length != MaxLength)
        temp = temp.PadLeft(MaxLength, '0');
      return temp;
    }

    public static void BitSetReset(ref byte value, byte BitNo, bool BitVal)
    {
      if (BitVal)
        value |= (byte)Math.Pow(2, BitNo);
      else
        value &= (byte)~(int)(Math.Pow(2, BitNo));
    }

    /// <summary>
    /// If value exceed to ranges return range
    /// </summary>
    /// <param name="value"></param>
    /// <param name="maxValue"></param>
    /// <param name="minValue"></param>
    /// <returns></returns>
    public static int MaxMinControl(int value, int maxValue, int minValue)
    {
      if (value > maxValue)
        return maxValue;
      else if (value < minValue)
        return minValue;
      else
        return value;
    }

    /// <summary>
    /// If value exceed to ranges return range
    /// </summary>
    /// <param name="value"></param>
    /// <param name="maxValue"></param>
    /// <param name="minValue"></param>
    /// <returns></returns>
    public static float MaxMinControl(float value, float maxValue, float minValue)
    {
      if (value > maxValue)
        return maxValue;
      else if (value < minValue)
        return minValue;
      else
        return value;
    }

    public static bool InRange(float value, float maxValue, float minValue)
    {
      if (value > maxValue)
        return false;
      else if (value < minValue)
        return false;
      else
        return true;
    }


    /// <summary>
    /// If value exceed to ranges return range
    /// </summary>
    /// <param name="value"></param>
    /// <param name="maxValue"></param>
    /// <param name="minValue"></param>
    /// <returns></returns>
    public static double MaxMinControl(double value, double maxValue, double minValue)
    {
      if (value > maxValue)
        return maxValue;
      else if (value < minValue)
        return minValue;
      else
        return value;
    }

    /// <summary>
    /// Resampling data
    /// </summary>
    /// <param name="data"></param>
    /// <param name="threshold"></param>
    /// <returns></returns>
    public static PointF[] LargestTriangleThreeBuckets(PointF[] data, int threshold)
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

    /// <summary>
    /// Resampling data
    /// </summary>
    /// <param name="input"></param>
    /// <param name="startIndex"></param>
    /// <param name="lastIndex"></param>
    /// <param name="threshold"></param>
    /// <returns></returns>
    public static PointF[] LargestTriangleThreeBuckets(PointF[] input, int startIndex, int lastIndex, int threshold)
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
    #endregion

    #region General

    /// <summary>
    /// Return string timestamp format as yyyymmdd_hhmm_milisecond
    /// </summary>
    /// <returns></returns>
    public static string GetTimeStamp()
    {
      StringBuilder strb = new StringBuilder();
      strb.Append(DateTime.Now.Year.ToString());
      strb.Append(DateTime.Now.Month.ToString("00"));
      strb.Append(DateTime.Now.Day.ToString("00"));
      strb.Append("_");
      strb.Append(DateTime.Now.Hour.ToString("00"));
      strb.Append(DateTime.Now.Minute.ToString("00"));
      strb.Append("_");
      strb.Append(DateTime.Now.Millisecond.ToString("000"));
      return strb.ToString();
    }

    /// <summary>
    /// Checking SW is design time 
    /// If dev env is used return true else false
    /// </summary>
    /// <returns></returns>
    public static bool CheckDesignTime()
    {
      return LicenseManager.UsageMode == LicenseUsageMode.Designtime;
    }
    public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
      // Unix timestamp is seconds past epoch
      System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
      dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
      return dtDateTime;
    }
    public static PointF ConvertToPointF(string value)
    {
      int xStartPos = value.IndexOf("X=") + 2;
      int yStartPos = value.IndexOf("Y=") + 2;
      int nmXLength = yStartPos - xStartPos - 4;
      int nmYLength = value.Length - yStartPos - 1;
      float nmx = Convert.ToSingle(value.Substring(xStartPos, nmXLength));
      float nmy = Convert.ToSingle(value.Substring(yStartPos, nmYLength));

      return new PointF(nmx, nmy);
    }

    public static void ShowWaitlessMsgBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
    {

      Task.Factory.StartNew(() =>
      {
        MessageBox.Show(text, caption, buttons, icon, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
      });
    }

    static List<Error> errlist;

    public static string ConvertNumToHexString(byte number, int charcount)
    {
      string temp = String.Format("{0:X}", number);
      temp = temp.PadLeft(charcount, '0');
      return temp.Substring(temp.Length - charcount, charcount);
    }

    public static string ConvertNumToHexString(int number, int charcount)
    {
      string temp = String.Format("{0:X}", number);
      temp = temp.PadLeft(charcount, '0');
      return temp.Substring(temp.Length - charcount, charcount);
    }

    public static string ConvertNumToHexString(short number, int charcount)
    {
      string temp = String.Format("{0:X}", number);
      temp = temp.PadLeft(charcount, '0');
      return temp.Substring(temp.Length - charcount, charcount);
    }

    /// <summary>
    /// Dictionary listesi içinde gelen parametreleri verilen 
    /// path ve dosya adı ile xml formatında kaydeder.
    /// Başarılı olursa true olmaz is false döner.
    /// </summary>
    /// <param name="sets">Dictionary<string,string> (key paremetre adı, value name)</param>
    /// <param name="filename">string (path + filename) </param>
    /// <param name="header">string ( xml file header)</param>
    /// <returns></returns>
    public static bool SaveSettingAsXML(Dictionary<string, string> sets, string filename, string header)
    {
      try
      {
        new XElement(header,
            sets.Select(p => new XElement("Setting",
                new XElement("Name", p.Key),
                new XElement("Value", p.Value)))).Save(filename);
        return true;
      }
      catch
      {
        return false;
      }

    }
    /// <summary>
    /// path ve dosya adı ile xml formatında verilen dosyanın Dictionary collection ile geri döndürür.
    /// Hata oluşursa null geri döner;
    /// </summary>
    /// <param name="filename">string (path + filename)</param>
    /// <param name="header">string ( xml file header)</param>
    /// <returns></returns>
    public static Dictionary<string, string> ReadSettingFromXML(string filename, string header)
    {
      try
      {
        Dictionary<string, string> temp = new Dictionary<string, string>();
        XDocument doc = XDocument.Load(filename);
        foreach (XElement e in doc.Elements(header).Elements("Setting"))
          temp.Add(e.Element("Name").Value, e.Element("Value").Value);
        return temp;
      }
      catch
      {
        return null;
      }
    }

    

    /// <summary>
    /// Hatanın özelliklerini id ve string dil kodu ile geri döner.
    /// Bu sub ın doğru çalışabilmesi için LoadErrorList'in doğru olarak yüklenmesi gereklidir.
    /// Eğer Errorlist null ise null error değeri geri döner.
    /// </summary>
    /// <param name="errorID"></param>
    /// <param name="language = CultureInfo.Name olmalıdır"></param>
    /// <returns></returns>
    public static Error GetError(int errorID, string language)
    {
      Error err;
      if (errlist != null)
        err = errlist.Find(er => (er.Language == language && er.ID == errorID));
      else
        err = null;
      return err;
    }
    /// <summary>
    /// Sınıf içinde tanımlı errlist'sine dosyadan tüm error ları yükler.
    /// </summary>
    /// <param name="errorListFile">Error xml dosyasının yolu.</param>
    public static void LoadErrorList(string errorListFile)
    {
      if (errlist == null)
        errlist = new List<Error>();
      else
        errlist.Clear();
      ReadAllErrors(errorListFile);

    }
    /// <summary>
    /// XML error dosyasından tüm hataları okur ve errlist'e ekler.
    /// </summary>
    /// <param name="errorListFile"></param>
    private static void ReadAllErrors(string errorListFile)
    {
      XmlDocument doc = new XmlDocument();
      doc.Load(errorListFile);
      XmlNodeList lst = doc.GetElementsByTagName("Error");
      foreach (XmlNode nd in lst)
        errlist.Add(new Error(Convert.ToInt32(nd["ID"].InnerText), nd["Name"].InnerText, nd["Decription"].InnerText, nd["Lang"].InnerText, (ErrorActions)Convert.ToInt32(nd["ErrorAction"].InnerText)));
    }

    public static void ChangeControlLanguage(ResourceManager res, Control frm)
    {
      try { frm.Text = res.GetString(frm.Name); }
      catch { }
      foreach (Control ctrl in frm.Controls)
      {
        try
        {
          if (ctrl.GetType() == typeof(ToolStrip))
            ChangeToolStripLanguage(res, ctrl as ToolStrip);
          else
            ChangeControlRecursive(res, ctrl);
          ctrl.Text = res.GetString(ctrl.Name);
        }
        catch { }
      }
    }

    private static void ChangeControlRecursive(ResourceManager res, Control ctrl)
    {
      foreach (Control ctr in ctrl.Controls)
      {
        try
        {
          if (ctr.GetType() == typeof(ToolStrip))
            ChangeToolStripLanguage(res, ctr as ToolStrip);
          else
            ChangeControlRecursive(res, ctr);
          ctr.Text = res.GetString(ctr.Name);
        }
        catch { }
      }
    }

    private static void ChangeToolStripLanguage(ResourceManager res, ToolStrip ctrl)
    {
      foreach (ToolStripItem item in ctrl.Items)
      {
        try
        {
          item.Text = res.GetString(item.Name);
        }
        catch { }
      }
    }

    public static double ToDouble(string text)
    {
      double val = 0;
      double.TryParse(text, out val);
      return val;
    }

    public static float ToFloat(string text)
    {
      float val = 0;
      float.TryParse(text, out val);
      return val;
    }

    public static int ToInt(string text)
    {
      int val = 0;
      int.TryParse(text, out val);
      return val;
    }

    public static byte ToByte(string text)
    {
      byte val = 0;
      byte.TryParse(text, out val);
      return val;
    }

    public static ushort ToUshort(string text)
    {
      ushort val = 0;
      ushort.TryParse(text, out val);
      return val;
    }

    public static bool WriteStreamToFile(Stream stream, string filename)
    {
      try
      {
        using (StreamWriter streamWriter = new StreamWriter(filename))
        {
          streamWriter.Write(stream);
        }
      }
      catch
      {
        return false;
      }
      return true;
    }

    public static string ReadStreamToFile(string filename)
    {
      try
      {
        using (StreamReader streamReader = new StreamReader(filename))
        {
          return streamReader.ReadToEnd();
        }
      }
      catch
      {
        return null;
      }
    }

    public static bool IsFileLocked(string file)
    {
      try
      {
        FileInfo finf = new FileInfo(file);
        if (finf.Exists)
        {
          using (System.IO.StreamWriter tw = new System.IO.StreamWriter(file, true))
          { }
        }
        return true;
      }
      catch { return false; }
    }

    /// <summary>
    /// Copy all properties source to target
    /// </summary>
    /// <param name="target"></param>
    /// <param name="source"></param>
    public static void CopyProperties(object target, object source)
    {
      List<PropertyInfo> properties = source.GetType().GetProperties().ToList();
      foreach (PropertyInfo myProperty in properties)
      {
        PropertyInfo prop = target.GetType().GetProperty(myProperty.Name, BindingFlags.Public | BindingFlags.Instance);
        if (null != prop && prop.CanWrite)
          prop.SetValue(target, myProperty.GetValue(source, null), null);
      }
    }

    #endregion

    #region Drawing Functions
    /// <summary>
    /// To chechk control is a special (groupbox,form,tabcontrol,FlowLayoutPanel) container.
    /// </summary>
    /// <param name="control"></param>
    /// <returns></returns>
    public static bool IsContainer(Control control)
    {
      return control is GroupBox || control is Form || control is FlowLayoutPanel || control is TabControl || control is TabPage;
    }
    public static void DrawGradienEllipsText(Graphics grp, Color Fill, int cornerX, int cornerY, int diam, string s, Color textcolor, Font font)
    {
      grp.SmoothingMode = SmoothingMode.HighQuality;
      LinearGradientBrush bb = new LinearGradientBrush(new Point(cornerX, cornerY), new Point(cornerX + diam, cornerY + diam), Fill, Color.White);

      grp.FillEllipse(bb, cornerX, cornerY, diam, diam);
      grp.DrawString(s, font, new SolidBrush(textcolor), new Point(cornerX + diam / 2 - font.Height / 2, cornerY + diam / 2 - font.Height / 2));
    }

    /// <summary>
    /// Measure string in sizef
    /// </summary>
    /// <param name="s"></param>
    /// <param name="font"></param>
    /// <returns></returns>
    public static SizeF MeasureString(string s, Font font)
    {
      SizeF result;
      using (var image = new Bitmap(1, 1))
      {
        using (var g = Graphics.FromImage(image))
        {
          result = g.MeasureString(s, font);
        }
      }

      return result;
    }

    public static Font GetFontForControlHeight(float height, Font originalFont)
    {
      // What is the target size of the textbox?


      // Set the font from the existing TextBox font.
      // We use the fnt = new Font(...) method so we can ensure that
      //  we're setting the GraphicsUnit to Pixels.  This avoids all
      //  the DPI conversions between point & pixel.
      Font fnt = new Font(originalFont.FontFamily,
                          originalFont.Size,
                          originalFont.Style,
                          GraphicsUnit.Pixel);

      // TextBoxes never size below 8 pixels. This consists of the
      // 4 pixels above & 3 below of whitespace, and 1 pixel line of
      // greeked text.
      if (height < 12)
        height = 12;

      // Determine the Em sizes of the font and font line spacing
      // These values are constant for each font at the given font style.
      // and screen DPI.
      float FontEmSize = fnt.FontFamily.GetEmHeight(fnt.Style);
      float FontLineSpacing = fnt.FontFamily.GetLineSpacing(fnt.Style);

      // emSize is the target font size.  TextBoxes have a total of
      // 7 pixels above and below the FontHeight of the font.
      float emSize = (height - 10) * FontEmSize / FontLineSpacing;

      // Create the font, with the proper size.
      fnt = new Font(fnt.FontFamily, emSize, fnt.Style, GraphicsUnit.Pixel);

      return fnt;
    }

    public static Color CalculateGradientLight(Color crBase, float fGradVal)
    {

      byte r = crBase.R;
      byte g = crBase.G;
      byte b = crBase.B;

      float fact = 255.0f;
      float rGrad = (255 - r) / fact;
      float gGrad = (255 - g) / fact;
      float bGrad = (255 - b) / fact;

      r = (byte)Math.Min(r + rGrad * fGradVal, 255);
      b = (byte)Math.Min(b + bGrad * fGradVal, 255);
      g = (byte)Math.Min(g + gGrad * fGradVal, 255);

      return Color.FromArgb(r, g, b);
    }

    public static Color CalculateGradientDark(Color crBase, float fGradVal)
    {
      byte r = crBase.R;
      byte g = crBase.G;
      byte b = crBase.B;

      float fact = 255.0f;
      float rGrad = (255 - r) / fact;
      float gGrad = (255 - g) / fact;
      float bGrad = (255 - b) / fact;

      r = (byte)Math.Max(r + rGrad * fGradVal, 0);
      b = (byte)Math.Max(b + bGrad * fGradVal, 0);
      g = (byte)Math.Max(g + gGrad * fGradVal, 0);

      return Color.FromArgb(r, g, b);

    }

    /// <summary>
    /// Interpolate color requested counts
    /// </summary>
    /// <param name="color1"></param>
    /// <param name="color2"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public static Color[] InterpolateColors(Color color1, Color color2, int count)
    {
      List<Color> colors = new List<Color>();
      byte interval_R = (byte)((color2.R - color1.R) / count);
      byte interval_G = (byte)((color2.G - color1.G) / count);
      byte interval_B = (byte)((color2.B - color1.B) / count);

      byte current_R = color1.R;
      byte current_G = color1.G;
      byte current_B = color1.B;

      for (int i = 0; i < count; i++)
      {

        //do something with color.

        //increment.
        if (i == count - 1)
        {
          current_R = color2.R;
          current_G = color2.G;
          current_B = color2.B;
          colors.Add(Color.FromArgb(current_R, current_G, current_B));
        }
        else
        {
          colors.Add(Color.FromArgb(current_R, current_G, current_B));
          current_R += interval_R;
          current_G += interval_G;
          current_B += interval_B;
        }
      }
      return colors.ToArray();
    }
    #endregion

    #region Key filter Functions
    /// <summary>
    /// Sadece numeric karakterler girmesine izin verir. 
    /// </summary>
    /// <param name="e"></param>
    /// <param name="decimalSymbol"></param>
    public static void NumericFloatInput(ref KeyPressEventArgs e, char decimalSymbol)
    {
      if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (e.KeyChar != decimalSymbol) && (e.KeyChar != '\b') && (e.KeyChar != '-')) e.Handled = true;
    }

    /// <summary>
    /// Sadece numeric karakterler girmesine izin verir. Ayrıca text içinde '-' , decimalSymbol karakterlerinin tekrarlanmasına izin vermez. '-' karakterinin sonda olmasına izin verilmez
    /// </summary>
    /// <param name="e"></param>
    /// <param name="decimalSymbol"></param>
    /// <param name="existingText"></param>
    public static void NumericFloatInput(ref KeyPressEventArgs e, char decimalSymbol, string existingText, int newCharLocation)
    {
      if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (e.KeyChar != decimalSymbol) && (e.KeyChar != '\b') && (e.KeyChar != '-')) e.Handled = true;
      if (e.KeyChar == '-' || e.KeyChar == '+')
      {
        if (existingText.Count(cr => cr == '-' || cr == '+') != 0 || newCharLocation != 0)
          e.Handled = true;
      }
      if (e.KeyChar == decimalSymbol)
      {
        if (existingText.Count(cr => cr == decimalSymbol) != 0)
          e.Handled = true;
      }

    }

    public static void NumericIntInput(ref KeyPressEventArgs e, string existingText, int newCharLocation)
    {
      if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (e.KeyChar != '\b') && (e.KeyChar != '-')) e.Handled = true;

      if (e.KeyChar == '-' || e.KeyChar == '+')
      {
        if (existingText.Count(cr => cr == '-' || cr == '+') != 0 || newCharLocation != 0)
          e.Handled = true;
      }


    }

    public static void NumericIntInput(ref KeyPressEventArgs e)
    {
      if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (e.KeyChar != '\b') && (e.KeyChar != '-')) e.Handled = true;
    }

    public static void NumericUnSignIntInput(ref KeyPressEventArgs e)
    {
      if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (e.KeyChar != '\b')) e.Handled = true;
    }
    #endregion

    #region SQL function
    public static List<string> GetSqlDataSource()
    {
      List<string> dataSource = new List<string>();
      RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
      using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
      {
        RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
        if (instanceKey != null)
        {
          foreach (var instanceName in instanceKey.GetValueNames())
            dataSource.Add(Environment.MachineName + @"\" + instanceName);
        }
      }
      return dataSource;
    }

    public static bool CheckSqlConnection(string connectionString)
    {
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        try
        {
          connection.Open();
        }
        catch { return false; }
        bool conState = connection.State == ConnectionState.Open;
        connection.Close();
        return conState;
      }
    }

    /// <summary>
    /// Check SQL server connection and get server version if return null it means server is not installed or differnt version
    /// </summary>
    /// <param name="connectionString"></param>
    /// <returns></returns>
    public static string GetSqlServerVersion(string connectionString)
    {
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        try
        {
          connection.Open();
        }
        catch { return string.Empty; }
        string str = connection.ServerVersion;
        string[] strArray = str.Split('.');
        connection.Close();
        return strArray[0];
      }
    }

    /// <summary>
    /// This function must be check other windows OP and SQL server versions
    /// Check SQL server installed or not from registry.
    /// </summary>
    /// <returns></returns>
    public static bool CheckSqlServerInstalled()
    {
      RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
      using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
      {
        RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
        return (instanceKey != null);
      }
    }

    public static List<String> EnumerateServers()
    {
      var instances = SqlDataSourceEnumerator.Instance.GetDataSources();
      if ((instances == null) || (instances.Rows.Count < 1)) return null;

      var result = new List<String>();
      foreach (DataRow instance in instances.Rows)
      {
        var serverName = instance["ServerName"].ToString();
        var instanceName = instance["InstanceName"].ToString();
        result.Add(String.IsNullOrEmpty(instanceName) ? serverName : String.Format(@"{0}\{1}", serverName, instanceName));
      }
      return result;
    }

    public static List<String> EnumerateDatabases(String connectionString)
    {
      try
      {
        using (var connection = new SqlConnection(connectionString))
        {
          connection.Open();
          var databases = connection.GetSchema("Databases");
          connection.Close();
          if ((databases == null) || (databases.Rows.Count < 1)) return null;

          var result = new List<String>();
          foreach (DataRow database in databases.Rows)
          {
            result.Add(database["database_name"].ToString());
          }
          return result;
        }
      }
      catch
      {
        return null;
      }
    }

    /// <summary>
    /// To check database exist for T-SQL
    /// </summary>
    /// <param name="dBParam"></param>
    /// <returns></returns>
    public static bool CheckDatabaseExists(string databaseName, string connectionString)
    {
      string sqlCreateDBQuery;
      bool result = false;
      try
      {
        SqlConnection tmpConn = new SqlConnection(connectionString); //"server=(local)\\SQLEXPRESS;Trusted_Connection=yes");
        sqlCreateDBQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", databaseName);
        using (tmpConn)
        {
          using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, tmpConn))
          {
            tmpConn.Open();
            object res = sqlCmd.ExecuteScalar();
            int databaseID = 0;
            if (res != null) // null is there no database
              databaseID = (int)sqlCmd.ExecuteScalar();

            tmpConn.Close();
            result = (databaseID > 0);
          }
        }
      }
      catch
      {
        result = false;
      }
      return result;
    }

    /// <summary>
    /// Check datbase status according to DATABASEPROPERTYEX sql function
    /// </summary>
    /// <param name="databaseName"></param>
    /// <param name="connectionString"></param>
    /// <returns></returns>
    public static string CheckDatabaseOnline(string databaseName, string connectionString)
    {
      string sqlCreateDBQuery;
      string result = string.Empty;
      try
      {
        SqlConnection tmpConn = new SqlConnection(connectionString);
        sqlCreateDBQuery = "Select  DATABASEPROPERTYEX('" + databaseName + "' , 'Status')";
        using (tmpConn)
        {
          using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, tmpConn))
          {
            tmpConn.Open();
            result = (string)sqlCmd.ExecuteScalar();
            tmpConn.Close();
          }
        }
      }
      catch { }
      return result;
    }

    /// <summary>
    /// To Attach database if files exist, if function complete without error return null else return exception.
    /// </summary>
    /// <param name="dBParam"></param>
    /// <param name="connectionString"></param>
    /// <returns></returns>
    public static Exception AttachDatabase(DatabaseParam dBParam, string connectionString)
    {
      SqlConnection tmpConn = new SqlConnection();
      tmpConn.ConnectionString = connectionString;
      string sqlCreateDBQuery = " CREATE DATABASE "
                         + dBParam.DatabaseName
                         + " ON PRIMARY"
                         + " (FILENAME = '" + dBParam.DataPathName + dBParam.DataFileName + ".mdf'), "
                         + " FILEGROUP " + dBParam.LogFileName
                         + " (FILENAME = '" + dBParam.LogPathName + dBParam.LogFileName + ".ldf')  FOR ATTACH";
      SqlCommand myCommand = new SqlCommand(sqlCreateDBQuery, tmpConn);
      try
      {
        tmpConn.Open();
        myCommand.ExecuteNonQuery();
        return null;
      }
      catch (Exception ex) { return ex; }
      finally { tmpConn.Close(); }
    }

    /// <summary>
    /// Create new database in SQL sql server
    /// </summary>
    /// <param name="dBParam"></param>
    /// <param name="connectionString"></param>
    /// <returns></returns>
    public static Exception CreateDatabase(DatabaseParam dBParam, string connectionString)
    {
      SqlConnection tmpConn = new SqlConnection();
      tmpConn.ConnectionString = connectionString;
      string sqlCreateDBQuery = " CREATE DATABASE "
                         + dBParam.DatabaseName
                         + " ON PRIMARY "
                         + " (NAME = " + dBParam.DataFileName + ", "
                         + " FILENAME = '" + dBParam.DataPathName + dBParam.DataFileName + ".mdf', "
                         + " SIZE = " + dBParam.DataFileSize.ToString() + "MB,"
                         + " FILEGROWTH =" + dBParam.DataFileGrowth + ") "
                         + " LOG ON (NAME =" + dBParam.LogFileName + ", "
                         + " FILENAME = '" + dBParam.LogPathName + dBParam.LogFileName + ".ldf', "
                         + " SIZE = " + dBParam.LogFileSize.ToString() + "MB,"
                         + " FILEGROWTH =" + dBParam.LogFileGrowth + ") ";
      SqlCommand myCommand = new SqlCommand(sqlCreateDBQuery, tmpConn);
      try
      {
        tmpConn.Open();
        myCommand.ExecuteNonQuery();
        return null;
      }
      catch (Exception ex) { return ex; }
      finally { tmpConn.Close(); }
    }

    /// <summary>
    /// To delete database with files, if function complete without error return null else return exception.
    /// </summary>
    /// <param name="dBParam"></param>
    /// <returns></returns>
    public static Exception DeleteDatabase(string connectionstring, string databaseName)
    {
      SqlConnection tmpConn = new SqlConnection();
      tmpConn.ConnectionString = connectionstring;
      SqlCommand myCommand = new SqlCommand("DROP DATABASE [" + databaseName + "]", tmpConn);
      try
      {
        tmpConn.Open();
        myCommand.ExecuteNonQuery();
        return null;
      }
      catch (Exception ex)
      {
        return ex;
      }
      finally { tmpConn.Close(); }
    }

    public static void DeleteControlFromDataBase(Control control, string connectionString)
    {
      SqlConnection tmpConn = new SqlConnection();
      tmpConn.ConnectionString = "data source = localhost\\SQLEXPRESS; initial catalog = sys;Integrated security=true;MultipleActiveResultSets =True;";
      tmpConn.Open();
      String insString = @"DELETE FROM Controls WHERE ControlName ='" + control.Name + "'";
      SqlCommand myCommand = new SqlCommand(insString, tmpConn);
      myCommand.ExecuteNonQuery();
      tmpConn.Close();
    }

    public static void DeleteControlsFromDataBase(List<Control> controls, string connectionString)
    {
      SqlConnection tmpConn = new SqlConnection();
      tmpConn.ConnectionString = connectionString; // "data source = localhost\\SQLEXPRESS; initial catalog = sys;Integrated security=true;MultipleActiveResultSets =True;";
      tmpConn.Open();
      String insString = @"DELETE FROM Controls WHERE";
      controls.ForEach(ct => insString += " ControlName ='" + ct.Name + "' OR");
      insString = insString.Remove(insString.Length - 3);
      SqlCommand myCommand = new SqlCommand(insString, tmpConn);
      myCommand.ExecuteNonQuery();
      tmpConn.Close();
    }

    public static void RenameControlOnDataBase(string connectionString, string oldControlName, string newControlName)
    {
      try
      {
        SqlConnection tmpConn = new SqlConnection();
        tmpConn.ConnectionString = connectionString;
        tmpConn.Open();
        String insString = @"UPDATE Controls SET Value = '" + newControlName + "' WHERE PropertyName = 'ChannelName' AND Value = '" + oldControlName + "'";
        SqlCommand myCommand = new SqlCommand(insString, tmpConn);
        myCommand.ExecuteNonQuery();
        insString = @"UPDATE PID SET Value = '" + newControlName + "' WHERE (PropertyName = 'ProcessChannel' Or PropertyName = 'OutputChannel') AND Value = '" + oldControlName + "'";
        myCommand = new SqlCommand(insString, tmpConn);
        myCommand.ExecuteNonQuery();
        tmpConn.Close();
      }
      catch (Exception ex)
      {
        throw (ex);
      }
    }

    public static void UpdateChannelOnDataBase(string connectionString, string oldAddress, string newAddress)
    {
      try
      {
        SqlConnection tmpConn = new SqlConnection();
        tmpConn.ConnectionString = connectionString;
        tmpConn.Open();
        String insString = @"UPDATE AnalogChannels SET Value = '" + newAddress + "' WHERE PropertyName = 'HardwareAddress' AND Value = '" + oldAddress + "'";
        SqlCommand myCommand = new SqlCommand(insString, tmpConn);
        myCommand.ExecuteNonQuery();
        tmpConn.Close();
      }
      catch (Exception ex)
      {
        throw (ex);
      }
    }

    public static void SaveControls(Control control, List<Type> typeList, List<Control> exceptionControls, string connectionString)
    {
      int orderNum = 0;
      SqlConnection tmpConn = new SqlConnection();
      tmpConn.ConnectionString = connectionString;
      tmpConn.Open();
      String insString = @"DELETE FROM Controls";
      SqlCommand myCommand = new SqlCommand(insString, tmpConn);
      myCommand.ExecuteNonQuery();
      RecursiveSaveProperties(tmpConn, control, typeList, exceptionControls, orderNum);
      tmpConn.Close();
    }

    public static void RecursiveSaveProperties(SqlConnection connection, Control control, List<Type> typeList, List<Control> exceptionControls, int orderNum)
    {
      if (typeList.FindLast(typ => typ == control.GetType()) != null)
      {
        if (exceptionControls.FindLast(ctrl => ctrl == control) == null)
        {
          List<PropertyInfo> properties = control.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(pi => GetCategoryAttiribute(pi) != "DoNotSave").ToList();
          String insString = @"INSERT INTO Controls (ControlName,TypeName,PropertyName,Value,OrderNum,TabPageIndex) values ";
          foreach (PropertyInfo pinf in properties)
          {
            string value = string.Empty;
            if (pinf.GetValue(control, null) != null)
            {
              TypeConverter tc = TypeDescriptor.GetConverter(pinf.PropertyType);

              if (tc.GetType() == typeof(CollectionConverter))
              {
                IList col = pinf.GetValue(control, null) as IList;
                if (col != null)
                {
                  if (col.Count > 0)
                    value = "[" + col[0].GetType().AssemblyQualifiedName + "]";
                  foreach (object el in col)
                  {
                    tc = TypeDescriptor.GetConverter(el.GetType());
                    value += "[Item]" + tc.ConvertToString(el);
                  }
                }
              }
              else
                value = tc.ConvertToString(pinf.GetValue(control, null));
              if (pinf.Name == "Parent")
                value = control.Parent.Name;
              if (value == "")
                value = pinf.GetValue(control, null).ToString();
            }


            insString = insString + "('" + control.Name.ToString() + "','" + control.GetType().AssemblyQualifiedName.ToString() + "','" + pinf.Name.ToString() + "','" + value.Replace("'", "''") + "'," + orderNum + "," + GetTabPageIndex(control) + "),";
          }
          insString = insString.TrimEnd(',');
          SqlCommand myCommand = new SqlCommand(insString, connection);
          myCommand.ExecuteNonQuery();
        }
      }
      orderNum++;
      if (IsContainer(control) || control.GetType() == typeof(MdiClient))
      {
        foreach (Control ctrl in control.Controls)
          RecursiveSaveProperties(connection, ctrl, typeList, exceptionControls, orderNum);
      }
    }

    private static string GetTabPageIndex(Control control)
    {
      if (control.GetType() == typeof(TabPage))
      {
        TabPage page = control as TabPage;
        TabControl tabControl = page.Parent as TabControl;
        return tabControl.TabPages.IndexOf(page).ToString();
      }
      else
        return "0";
    }

    public static string GetCategoryAttiribute(PropertyInfo info)
    {
      try
      {
        Attribute atr = info.GetCustomAttribute(typeof(CategoryAttribute));
        if (atr != null)
          return ((CategoryAttribute)atr).Category;
        else
          return string.Empty;
      }
      catch { return string.Empty; }
    }

    /// <summary>
    /// For give a string and indexed name to controls
    /// </summary>
    /// <param name="type">type for get number</param>
    /// <param name="controls">control collection</param>
    /// <returns></returns>
    public static string GetIndexedName(Type type, List<Control> controls)
    {
      List<Control> filtList = controls.Where(ctrl => ctrl.GetType() == type).ToList();
      List<string> testlist = new List<string>();
      filtList.ForEach(t => { testlist.Add(t.Name); });
      for (int i = 0; i < 65535; i++)
      {
        if (filtList.Find(t => t.Name == (type.FullName + i.ToString())) == null)
        {
          return type.FullName + i.ToString();
        }
      }
      return null;
    }

    /// <summary>
    /// Create controls properties table for save all controls and forms
    /// </summary>
    /// <param name="dBParam"></param>
    /// <returns></returns>
    public static Exception CheckCreateControlsTable(string connectionString)
    {
      SqlConnection tmpConn = new SqlConnection();
      tmpConn.ConnectionString = connectionString;
      using (SqlCommand cmd = tmpConn.CreateCommand())
      {
        try
        {
          cmd.CommandText =
          @"IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Controls'))
          BEGIN
          CREATE TABLE Controls
          ( 
            ControlName nvarchar(MAX),
            TypeName nvarchar(MAX),
            PropertyName nvarchar(MAX),
            Value nvarchar(MAX),
            OrderNum int,
          )          
          END";



          tmpConn.Open();
          cmd.ExecuteNonQuery();
          cmd.CommandText =
          @"
          IF COL_LENGTH('Controls','TabPageIndex') IS NULL
          BEGIN
          ALTER TABLE Controls
          ADD TabPageIndex int
          END";
          cmd.ExecuteNonQuery();
          return null;
        }
        catch (Exception ex)
        {
          return ex;
        }
        finally { tmpConn.Close(); }
      }

    }

    /// <summary>
    /// Check if not exist create new channel tables to save properties.
    /// </summary>
    /// <param name="dBParam"></param>
    /// <returns></returns>
    public static Exception CheckCrateChannelTables(string connectionString)
    {
      SqlConnection tmpConn = new SqlConnection();
      tmpConn.ConnectionString = connectionString;
      SqlCommand cmd = tmpConn.CreateCommand();
      cmd.CommandText =
      @"IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AnalogChannels'))
        BEGIN
        CREATE TABLE AnalogChannels
        ( 
            ChannelName nvarchar(MAX),
            TypeName nvarchar(MAX),
            PropertyName nvarchar(MAX),
            Value nvarchar(MAX),
        )          
        END
        IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DigitalChannels'))
        BEGIN
        CREATE TABLE DigitalChannels
        ( 
            ChannelName nvarchar(MAX),
            TypeName nvarchar(MAX),
            PropertyName nvarchar(MAX),
            Value nvarchar(MAX),
        )          
        END";
      try
      {
        tmpConn.Open();
        cmd.ExecuteNonQuery();
        return null;
      }
      catch (Exception ex) { return ex; }
      finally
      {
        cmd.Dispose();
        tmpConn.Close();
      }
    }

    public static Exception CheckCratePidTables(string connectionString)
    {
      SqlConnection tmpConn = new SqlConnection();
      tmpConn.ConnectionString = connectionString;
      SqlCommand cmd = tmpConn.CreateCommand();
      cmd.CommandText =
      @"IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PID'))
        BEGIN
        CREATE TABLE PID
        ( 
            PidName nvarchar(MAX),
            TypeName nvarchar(MAX),
            PropertyName nvarchar(MAX),
            Value nvarchar(MAX),
        )          
        END";
      try
      {
        tmpConn.Open();
        cmd.ExecuteNonQuery();
        return null;
      }
      catch (Exception ex) { return ex; }
      finally
      {
        cmd.Dispose();
        tmpConn.Close();
      }
    }

    /// <summary>
    /// Check if not exist create new calibration tables to save properties.
    /// </summary>
    /// <param name="dBParam"></param>
    /// <returns></returns>
    public static Exception CheckCrateCalibrationTables(string connectionString)
    {
      SqlConnection tmpConn = new SqlConnection();
      tmpConn.ConnectionString = connectionString;
      SqlCommand cmd = tmpConn.CreateCommand();
      cmd.CommandText =
      @"IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Calibration'))
        BEGIN
        CREATE TABLE Calibration
        ( 
            ChannelName nvarchar(MAX),
            CalibrationName nvarchar(MAX),
            TypeName nvarchar(MAX),
            PropertyName nvarchar(MAX),
            Value nvarchar(MAX),
        )          
        END
        IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CalibrationPoints'))
        BEGIN
        CREATE TABLE CalibrationPoints
        ( 
            ChannelName nvarchar(MAX),
            CalibrationName nvarchar(MAX),
            MeasurmentValue real,
            ReferenceValue real,
        )          
        END
        ";
      try
      {
        tmpConn.Open();
        cmd.ExecuteNonQuery();
        return null;
      }
      catch (Exception ex) { return ex; }
      finally
      {
        cmd.Dispose();
        tmpConn.Close();
      }
    }

    public static Exception CheckCreateFormsTable(string connectionString)
    {
      SqlConnection tmpConn = new SqlConnection();
      tmpConn.ConnectionString = connectionString;
      SqlCommand cmd = tmpConn.CreateCommand();
      cmd.CommandText =
      @"IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Forms'))
        BEGIN
        CREATE TABLE Forms
        ( 
            Name nvarchar(MAX),
            Text nvarchar(MAX),
            Icon Image,
            BackColor Int,
            Width Int,
            Height Int,
            Xposition Int,
            Yposition Int,
            WindowState Int,
            Visible bit,
        )          
        END
        ";
      try
      {
        tmpConn.Open();
        cmd.ExecuteNonQuery();
        return null;
      }
      catch (Exception ex) { return ex; }
      finally
      {
        cmd.Dispose();
        tmpConn.Close();
      }
    }

    public static Exception CheckCreateAlarmLogTable(string connectionString)
    {
      SqlConnection tmpConn = new SqlConnection(connectionString);
      SqlCommand cmd = tmpConn.CreateCommand();
      cmd.CommandText =
      @"IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AlarmLog'))
        BEGIN
        CREATE TABLE AlarmLog
        ( 
            Date date,
            Time time,
            Type int,
            Code int,
            TestId int,
            StepId int,
            Decription nvarchar(MAX),
        )          
        END
        ";
      try
      {
        tmpConn.Open();
        cmd.ExecuteNonQuery();
        cmd.CommandText =
         @"
          IF COL_LENGTH('AlarmLog','TestId') IS NULL
          BEGIN
          ALTER TABLE AlarmLog
          ADD TestId int
          END
          IF COL_LENGTH('AlarmLog','StepId') IS NULL
          BEGIN
          ALTER TABLE AlarmLog
          ADD StepId int
          END";
        cmd.ExecuteNonQuery();
        return null;
      }
      catch (Exception ex) { return ex; }
      finally
      {
        cmd.Dispose();
        tmpConn.Close();
      }
    }

    public static Exception CheckCreateSystemLogTable(string connectionString)
    {
      SqlConnection tmpConn = new SqlConnection(connectionString);
      SqlCommand cmd = tmpConn.CreateCommand();
      cmd.CommandText =
      @"IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SystemLog'))
        BEGIN
        CREATE TABLE SystemLog
        ( 
            Date date,
            Time time,
            Type int,
            Code int,
            TestId int,
            StepId int,
            Decription nvarchar(MAX),
        )          
        END
        ";
      try
      {
        tmpConn.Open();
        cmd.ExecuteNonQuery();
        cmd.CommandText =
         @"
          IF COL_LENGTH('SystemLog','TestId') IS NULL
          BEGIN
          ALTER TABLE SystemLog
          ADD TestId int
          END
          IF COL_LENGTH('SystemLog','StepId') IS NULL
          BEGIN
          ALTER TABLE SystemLog
          ADD StepId int
          END";
        cmd.ExecuteNonQuery();
        return null;
      }
      catch (Exception ex) { return ex; }
      finally
      {
        cmd.Dispose();
        tmpConn.Close();
      }
    }

    public static Exception CheckCrateUserSaveTables(string connectionString)
    {
      SqlConnection tmpConn = new SqlConnection();
      tmpConn.ConnectionString = connectionString;
      SqlCommand cmd = tmpConn.CreateCommand();
      cmd.CommandText = @"IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'USERS'))
        BEGIN
        CREATE TABLE USERS
        (
            Username nvarchar(MAX),
            Userlevel nvarchar(MAX),
            Userpassword nvarchar(MAX),
        )
        END";
      try
      {
        tmpConn.Open();
        cmd.ExecuteNonQuery();
        return null;
      }
      catch (Exception ex) { return ex; }
      finally
      {
        cmd.Dispose();
        tmpConn.Close();
      }
    }

    public static Exception TestConnection(string connectionString)
    {
      SqlConnection tmpConn = new SqlConnection();
      tmpConn.ConnectionString = connectionString;
      try
      {
        tmpConn.Open();
      }
      catch (Exception ex) { return ex; }
      finally { tmpConn.Close(); }
      return null;
    }

    public static Exception CheckCreateTestTable(string connectionString)
    {
      SqlConnection tmpConn = new SqlConnection();
      tmpConn.ConnectionString = connectionString;
      SqlCommand cmd = tmpConn.CreateCommand();
      cmd.CommandText =
      @"IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Test'))
        BEGIN
        CREATE TABLE Test
        ( 
            Id int IDENTITY(1,1),
            TestNo nvarchar(MAX),
            StepIDs nvarchar(MAX),
            Owner nvarchar(MAX), 
            Responsible nvarchar(MAX),
            RequestedDivision nvarchar(MAX),
            ProjectSubject nvarchar(MAX),
            ProductGroup nvarchar(MAX),
            BreakeChamberName nvarchar(MAX),
            BreakeChamberNo nvarchar(MAX),
            PartName nvarchar(MAX),
            PartNo nvarchar(MAX),
            BarcodeNo nvarchar(MAX),
            DMC nvarchar(MAX),
            TestAim nvarchar(MAX),
            ManufacturerCustomer nvarchar(MAX),
            Explanation nvarchar(MAX),
            TestSettingName nvarchar(MAX),
            State nvarchar(MAX),
            Result nvarchar(MAX),
            StartDate datetime,
            EndDate datetime,
        )          
        END
        ";
      try
      {
        tmpConn.Open();
        cmd.ExecuteNonQuery();
        return null;
      }
      catch (Exception ex) { return ex; }
      finally
      {
        cmd.Dispose();
        tmpConn.Close();
      }
    }

    public static Exception CheckCreateStepTable(string connectionString)
    {
      SqlConnection tmpConn = new SqlConnection();
      tmpConn.ConnectionString = connectionString;
      SqlCommand cmd = tmpConn.CreateCommand();
      cmd.CommandText =
      @"IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Step'))
        BEGIN
        CREATE TABLE Step
        ( 
            Id int IDENTITY(1,1),
            OrderNo int,
            SettingName nvarchar(MAX),
            EndLoopCount int,
            SettingLoopCount int,
            Result nvarchar(MAX),
            State nvarchar(MAX),
            Station nvarchar(MAX),
            Explanation nvarchar(MAX),
            StartDate datetime,
            EndDate datetime,
        )          
        END
        ";
      try
      {
        tmpConn.Open();
        cmd.ExecuteNonQuery();
        return null;
      }
      catch (Exception ex) { return ex; }
      finally
      {
        cmd.Dispose();
        tmpConn.Close();
      }
    }

    #endregion

    #region String Functions

    public static int CountofString(string source, string searched)
    {
      int count = 0, foundIndex = 0, startIndex = 0;
      while (foundIndex != -1)
      {
        foundIndex = source.IndexOf(searched, startIndex);
        startIndex = foundIndex + searched.Length + 1;
        if (foundIndex != -1)
          count++;
      }
      return count;
    }

    /// <summary>
    /// concatenation strings
    /// </summary>
    /// <param name="strings"></param>
    /// <param name="withSpace"></param>
    /// <param name="addNewLine"></param>
    /// <returns></returns>
    public static string ConcanteStrings(string[] strings, bool withSpace = false, bool addNewLine = false)
    {
      StringBuilder strBuider = new StringBuilder();
      for (int i = 0; i < strings.Length; i++)
      {
        strBuider.Append(strings[i]);
        if (withSpace && i != strings.Length - 1)
          strBuider.Append(" ");
      }
      if (addNewLine)
        strBuider.Append(Environment.NewLine);
      return strBuider.ToString();
    }


    /// <summary>
    /// Get line number in string at found position.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="Pos"></param>
    /// <returns></returns>
    public static int GetLineNumberFromPosition(string text, int Pos)
    {
      int result = 1;
      for (int i = 0; i <= Pos - 1; i++)
        if (text[i] == '\n') result++;
      return result;
    }

    /// <summary>
    /// Return requested chracter from end of string
    /// </summary>
    /// <param name="source"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public static string Right(string source, int count)
    {
      if (source != null)
        if (source.Length >= count)
          return source.Substring(source.Length - count, count);
        else
          return string.Empty;
      else
        return string.Empty;
    }

    /// <summary>
    /// Return requested chracter start of string
    /// </summary>
    /// <param name="source"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public static string Left(string source, int count)
    {
      if (source != null)
        if (source.Length >= count)
          return source.Substring(0, count);
        else
          return string.Empty;
      else
        return string.Empty;
    }

    public static Exception ReplaceStringInFile(string findString, string ReplacementString, string filePath)
    {
      try
      {
        string contents = File.ReadAllText(filePath);
        contents = contents.Replace(findString, ReplacementString);
        // Make files writable
        File.SetAttributes(filePath, FileAttributes.Normal);
        File.WriteAllText(filePath, contents);
      }
      catch (Exception ex)
      {
        return ex;
      }
      return null;
    }

    /// <summary>
    /// Only for Turkish
    /// Convert Timespan to string as "{0} Gün, {1}:{2}:{3}", span.Days, span.Hours, span.Minutes, span.Seconds);
    /// </summary>
    /// <param name="span"></param>
    /// <returns></returns>
    public static string ConvertTimeStampToLongFormat(TimeSpan span, CultureInfo cultureInfo)
    {
      return string.Format(cultureInfo, "{0} Gün, {1}:{2}:{3}", span.Days, span.Hours, span.Minutes, span.Seconds);
    }

    public static string ConvertTimeStampToSecondFormat(TimeSpan span, CultureInfo cultureInfo)
    {
      return string.Format(cultureInfo, "{0} sn", span.TotalSeconds);
    }
    #endregion

  }
}