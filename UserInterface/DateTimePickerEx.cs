using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace UserInterface
{
  public partial class DateTimePickerEx : DateTimePicker
  {
    public DateTimePickerEx(): base()
    {
      InitializeComponent();
      //MCS_DAYSTATE has to be set during initialization for the bolded dates to be applied later
      Style style = (Style)SendMessage(new HandleRef(this, this.Handle), DTM_GETMCSTYLE, IntPtr.Zero, IntPtr.Zero);
      Console.WriteLine("SendMessage Error: " + Marshal.GetLastWin32Error());
      style |= Style.MCS_DAYSTATE; // | Style.MCS_NOSELCHANGEONNAV | Style.MCS_WEEKNUMBERS;

      Style prevStyle = (Style)SendMessage(new HandleRef(this, this.Handle), DTM_SETMCSTYLE, IntPtr.Zero, (IntPtr)style);
      Console.WriteLine("SendMessage Error: " + Marshal.GetLastWin32Error());
    }

    [Flags()]
    private enum Style
    {
      MCS_DAYSTATE = 0x0001,
      MCS_MULTISELECT = 0x0002,
      MCS_WEEKNUMBERS = 0x0004,
      MCS_NOTODAYCIRCLE = 0x0008,
      MCS_NOTODAY = 0x0010,
      MCS_NOTRAILINGDATES = 0x0040,
      MCS_SHORTDAYSOFWEEK = 0x0080,
      MCS_NOSELCHANGEONNAV = 0x0100
    }


    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern int GetWindowLong(IntPtr h, int index);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern int SetWindowLong(IntPtr h, int index, int value);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, int wParam, UInt32[] lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, ref Style lParam);

    private const int DTM_FIRST = 0x1000;
    private const int MCM_FIRST = 0x1000;

    private const int DTM_GETMONTHCAL = (DTM_FIRST + 8);
    private const int MCM_SETDAYSTATE = (MCM_FIRST + 8);
    private const int MCN_GETDAYSTATE = (MCM_FIRST + 3);
    private const int GWL_STYLE = (-16);
    private const int DTM_GETMCSTYLE = (DTM_FIRST + 12);
    private const int DTM_SETMCSTYLE = (DTM_FIRST + 11);

    /// <summary>
    /// Gets or sets the bolded dates.
    /// </summary>
    /// <value>The bolded dates.</value>
    public DateTime[] BoldedDates
    {
      get;
      set;
    }

    private EventHandler onBeforeDropDown;

    protected virtual void OnBeforeDropDown(EventArgs eventargs)
    {
      if (this.onBeforeDropDown != null)
      {
        this.onBeforeDropDown(this, eventargs);
      }
    }

    public event EventHandler BeforeDropDown
    {
      add
      {
        this.onBeforeDropDown = (EventHandler)Delegate.Combine(this.onBeforeDropDown, value);
      }
      remove
      {
        this.onBeforeDropDown = (EventHandler)Delegate.Remove(this.onBeforeDropDown, value);
      }
    }


    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.DateTimePicker.DropDown"></see> event.
    /// </summary>
    /// <param name="eventargs">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected override void OnDropDown(EventArgs eventargs)
    {
      OnBeforeDropDown(EventArgs.Empty);

      //
      IntPtr monthCalHandle = SendMessage(new HandleRef(this, this.Handle), DTM_GETMONTHCAL, IntPtr.Zero, IntPtr.Zero);
      Console.WriteLine("SendMessage Error: " + Marshal.GetLastWin32Error());

      uint[] dayState = GetBoldedDatesDayState();

      IntPtr retVal = SendMessage(new HandleRef(this, monthCalHandle), MCM_SETDAYSTATE, dayState.Length, dayState);
      Console.WriteLine("SendMessage Error: " + Marshal.GetLastWin32Error());
      Console.WriteLine(Convert.ToBoolean(retVal.ToInt32()));

      base.OnDropDown(eventargs);
    }

    /// <summary>
    /// Sets the bit for each day in BoldedDates that is in the visible month
    /// </summary>
    /// <returns></returns>
    private uint[] GetBoldedDatesDayState()
    {
      int size = 3;
      uint[] dayState = new uint[size]; // [0] = end of previous month, [1] = current month, [2] = start of next month
      uint currentMonthDayState = 0;
      if (BoldedDates != null)
      {
        foreach (DateTime d in BoldedDates)
        {
          if (d.Year == this.Value.Year && d.Month == this.Value.Month)
            currentMonthDayState = BoldDay(d.Day, currentMonthDayState);
        }
      }
      dayState[0] = 0; // bold fifth day (5^2) of current month
      dayState[1] = currentMonthDayState;
      dayState[2] = 0;

      return dayState;
    }

    /// <summary>
    /// Sets the bit corresponding to the day to indicate bold
    /// </summary>
    /// <param name="dayState"></param>
    /// <param name="day">the day of the month 1-31</param>
    /// <returns></returns>
    private uint BoldDay(int day, uint dayState = 0)
    {
      if (day > 0 && day < 32) (dayState) |= ((uint)0x00000001 << (day - 1));
      return dayState;
    }
  }
}
