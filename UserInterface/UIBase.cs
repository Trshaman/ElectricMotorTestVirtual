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
//using System.Drawing.Design;
using System.Drawing.Drawing2D;

namespace UserInterface
{
  public delegate void ControlEnableChangedEventHandler(UIBase UIobject);
  public delegate void SystemModeChangedEventHandler(UIBase UIobject);
  public enum UserInterfaceTypes
  {
    None,
    TabControl,
    GroupBox,
    AnalogGauge,
    LinearGauge,
    TemperatureGauge,
    HydraulicCylinder,
    DigitalDisplay,
    RealTimeGraph,
    SteeringWheel,
    Knob,
    NumericControl,
    ToggleSwitch,
    LedDisplay,
    Header,
    ToggleSwitchVertical,
    PictureControl,
    TextBox,
    Label,
    PushButton,
    XYGraph,
    EventButton,
  }

  //Must Be set to properly show channel list
  public enum UserInterfaceUsingTypes
  {
    Indicator, Control,
    RealTimeIndicator,
    Decorative
  }
  // Summary:
  //     Specifies the edge of the control at which to position the caption.
  public enum HeaderPosition
  {
    // Summary:
    //     The caption appears at the top edge of the control.
    Top = 0,
    //
    // Summary:
    //     The caption appears at the bottom edge of the control.
    Bottom = 1,
    //
    // Summary:
    //     The caption appears at the left edge of the control.
    Left = 2,
    //
    // Summary:
    //     The caption appears at the right edge of the control.
    Right = 3,
  }
  [ToolboxItem(false)]
  public partial class UIBase : UserControl
  {
    public event ControlEnableChangedEventHandler ControlEnableChanged;
    //public event ControlEnableChangedEventHandler SystemModeChanged;
    #region Local Variable
    private static List<UIBase> _listOfControls = new List<UIBase>();
    private bool _designModeActive = false;
    private string _header = "Header";
    private Font _headerFont = SystemFonts.DefaultFont;
    private Color _headerForeColor = Color.Black;
    private Color _headerBackColor = Color.WhiteSmoke;
    private Color _backGradientColor = Color.White;
    private float _widthHeightRatio;
    private UserInterfaceUsingTypes _uIType;
    private bool _headerVisible = true;
    private string _channelName;
    private bool _controlEnable = true;
    private SystemModes _systemMode = SystemModes.Manual;
    private UserLevels _actualUserLevel = UserLevels.Admin;
    private UserLevels _userAccessLevel = UserLevels.Operator;

    #endregion

    #region Properties

    internal bool CanUserAccess
    {
      get
      {
        if (UserAccessLevel == ActualUserLevel)
          return true;
        else if (ActualUserLevel == UserLevels.Admin)
          return true;
        else
          return false;
      }
    }

    [Browsable(false), DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
    public virtual UserLevels ActualUserLevel
    {
      get { return _actualUserLevel; }
      set { _actualUserLevel = value; }
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual UserLevels UserAccessLevel
    {
      get { return _userAccessLevel; }
      set { _userAccessLevel = value; }
    }

    [DefaultValue(true)]
    [Category("DoNotSave"), Browsable(false)]
    public virtual bool ControlEnable
    {
      get { return _controlEnable; }
      set
      {
        if (_controlEnable != value && ControlEnableChanged != null)
        {
          _controlEnable = value; //Before event raise must be set..
          ControlEnableChanged(this);
        }
        _controlEnable = value;
      }
    }

    [DefaultValue(SystemModes.Manual), Category("DoNotSave")]
    public virtual SystemModes SystemMode
    {
      get
      {
        return _systemMode;
      }
      set
      {
        _systemMode = value;
        if (value == SystemModes.Monitor)
          this.ControlEnable = false;
        //CrossThreadHelper.SetControlOfEnable((value == SystemModes.Automatic || value == SystemModes.Manual) && UserLevel == User.UserLevels.Admin, this);
      }
    }

    [Category("UIBase")]
    public virtual string ChannelName
    {
      get { return _channelName; }
      set { _channelName = value; }
    }

    [Browsable(false), Category("UIBase")]
    public bool PropertyEditMode { get; set; }

    [Browsable(false), Category("DoNotSave")]
    public UserInterfaceUsingTypes UIType { get { return _uIType; } internal set { _uIType = value; } }

    [Browsable(false), Category("DoNotSave")]
    public virtual bool DesignModeActive { get { return _designModeActive; } set { _designModeActive = value; } }

    [Browsable(false), Category("UIBase")]
    public string ContainerFormName { get; set; }

    /// <summary>
    /// Store Channel name list for selection
    /// </summary>
    [Browsable(false), Category("DoNotSave")]
    public List<Channel> ChannelList { get; set; }

    [Category("Appearance")]
    public virtual string Header { get { return _header; } set { _header = value; Invalidate(); } }

    [Browsable(false)]
    public override string Text
    {
      get
      {
        return _header;
      }
      set
      {
        _header = value;
      }
    }

    [Category("Appearance")]
    public virtual Font HeaderFont { get { return _headerFont; } set { _headerFont = value; Invalidate(); } }

    [Category("Appearance"), Description("Header Font Color")]
    public virtual Color HeaderForeColor { get { return _headerForeColor; } set { _headerForeColor = value; Invalidate(); } }

    [Category("Appearance")]
    public virtual Color HeaderBackColor { get { return _headerBackColor; } set { _headerBackColor = value; Invalidate(); } }

    [Category("Appearance")]
    public virtual HeaderPosition HeaderPosition { get; set; }

    [Category("Appearance"), Description("Show/Hide Header")]
    public virtual bool HeaderVisible { get { return _headerVisible; } set { _headerVisible = value; Invalidate(); } }

    [Category("UIBase"), Browsable(false)]
    public bool Selected { get; set; }

    [Category("UIBase"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
    public virtual BackFillTypes BackFillType { get; set; }

    [Category("UIBase")]
    public virtual Color BackGradientColor { get { return _backGradientColor; } set { _backGradientColor = value; Invalidate(); } }

    [Category("UIBase")]
    public virtual LinearGradientMode BackGradientMode { get; set; }

    /// <summary>
    /// To make ratio width and height
    /// WidthHeightRatio=0 disabled
    /// </summary>
    [Browsable(false), Category("DoNotSave")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public float WidthHeightRatio { get { return _widthHeightRatio; } set { _widthHeightRatio = value; Invalidate(); } }
    #endregion

    #region Ctor

    public UIBase()
    {
      InitializeComponent();
      _listOfControls.Add(this);
      this.Disposed += UIBase_Disposed;
      this.MouseClick += UIBase_MouseClick;
    }

    private void UIBase_MouseClick(object sender, MouseEventArgs e)
    {
      this.FindForm().Focus();
    }

    void UIBase_Disposed(object sender, EventArgs e)
    {
      _listOfControls.Remove(this);
    }

    #endregion

    #region Subs
    /// <summary>
    /// To set channel name without raise channel changed event
    /// </summary>
    /// <param name="channelName"></param>
    public void SetChannelName(string channelName)
    {
      _channelName = channelName;
    }
    #endregion
  }
}
