using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GlobalFunctions;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Collections;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace UserInterface
{
  public delegate void AnalogValueChangedEventHandler(Object Sender, float oldValue, float newValue);
  public delegate void AnalogChannelChangedEventHandler(AnalogBase UIobject, string oldChannelName, string newChannelName);


  [DefaultProperty("ChannelName")]
  public  partial class AnalogBase : UIBase
  {

    public event AnalogValueChangedEventHandler ValueChanged;
    public event AnalogChannelChangedEventHandler ChannelChanged;
   

    #region Local Variable
    private string _unit = "Unit";
    private float _highValue = 100;
    private float _lowValue = 0;
    private Color _highAlarmColor = Color.Red;
    private Color _highWarnColor = Color.Yellow;
    private Color _lowWarnColor = Color.Yellow;
    private Color _lowAlarmColor = Color.Red;
    private float _highAlarmValue = 100;
    private float _highWarnValue = 100;
    private float _lowWarnValue = 0;
    private float _lowAlarmValue = 0;
    //private string _channelName;
    private float _value;
    private bool _noEvent;
    private int _precision;


    #endregion

    #region Properties
  
    [EditorAttribute(typeof(SelEditor), typeof(UITypeEditor)), Category("AnalogBase"), DefaultValue(null)]
    public override string ChannelName
    {
      get { SelEditor.ChannelList = ChannelList; return base.ChannelName; }
      set
      {
        base.ChannelName = value;
        if (ChannelChanged != null)
          ChannelChanged(this, base.ChannelName, value);
        base.ChannelName = value;
        Header = value;
      }
    }

    [Category("Behavior"), Description("Precision of the value (0-6 digits)")]
    public virtual int Precision
    {
      get { return _precision; }
      set
      {
        _precision = Functions.MaxMinControl(value, 6, 0);
        Invalidate();
      }
    }

    [Category("DoNotSave")]
    public virtual float Value
    {
      get { return _value; }
      set
      {
        if (this.ValueChanged != null && !_noEvent)
          ValueChanged(this, _value, value);
        if (_value != value)
          Invalidate();
        _value = value;
        _noEvent = false;

      }
    }

    [Category("Appearance"), Description("Unit of channel")]
    public virtual string Unit { get { return _unit; } set { _unit = value; Invalidate(); } }
    [Category("Limits"), Description("Maximum value of the data")]
    public virtual float HighValue { get { return _highValue; } set { _highValue = value; Invalidate(); } }
    [Category("Limits"), Description("Minumum value of the data")]
    public virtual float LowValue { get { return _lowValue; } set { _lowValue = value; Invalidate(); } }
    [Category("Alarm Colors"), Description("High Alarm Color")]
    public virtual Color HighAlarmColor { get { return _highAlarmColor; } set { _highAlarmColor = value; } }
    [Category("Alarm Colors"), Description("Low Alarm Color")]
    public virtual Color LowAlarmColor { get { return _lowAlarmColor; } set { _lowAlarmColor = value; } }
    [Category("Warning Colors"), Description("High Warning Color")]
    public virtual Color HighWarnColor { get { return _highWarnColor; } set { _highWarnColor = value; } }
    [Category("Warning Colors"), Description("Low Warning Color")]
    public virtual Color LowWarnColor { get { return _lowWarnColor; } set { _lowWarnColor = value; } }
    [Category("Alarm Limits"), Description("High Alarm Value")]
    public virtual float HighAlarmValue { get { return _highAlarmValue; } set { _highAlarmValue = value; } }
    [Category("Warning Limits"), Description("High Warning Value")]
    public virtual float HighWarnValue { get { return _highWarnValue; } set { _highWarnValue = value; } }
    [Category("Warning Limits"), Description("Low Warning Value")]
    public virtual float LowWarnValue { get { return _lowWarnValue; } set { _lowWarnValue = value; } }
    [Category("Alarm Limits"), Description("Low Alarm Value")]
    public virtual float LowAlarmValue { get { return _lowAlarmValue; } set { _lowAlarmValue = value; } }

  
    //TODO: Alarm warn struct iptal edilecek.
    //[Browsable(false),Category("GaugeBase")]
    // public virtual AlarmWarnStruct AlarmWarn { get; set; }
    #endregion

    #region Ctor
    public AnalogBase()
    {
      //Size değişikliğinde paint eventinin kalkması için konuldu
      SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
      SetStyle(ControlStyles.UserPaint, true);
      SizeChanged += (object sender, EventArgs e) => { Invalidate(); };
      InitializeComponent();
    }
    #endregion

    #region Events

    #endregion

    #region Subs
    /// <summary>
    /// For set digital outs value externaly 
    /// </summary>
    /// <param name="value"></param>
    public virtual void SetValue(float value)
    {
      _noEvent = true; // To prevent fire event for set Digital Outs value extern.
    }

    public virtual void OnChannelChanged(AnalogBase UIobject, string oldChannelName, string newChannelName)
    {
      AnalogChannelChangedEventHandler handler = ChannelChanged;
      if (handler != null)
        handler(UIobject, oldChannelName, newChannelName);
    }

  
    #endregion

  }

}
