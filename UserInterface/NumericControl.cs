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
  public partial class NumericControl : AnalogBase
  {

    #region Properties variables
    private Image _powerOnImage;
    private Image _powerOffImage;
    private Color _numericBackColor = SystemColors.Window;
    private Color _numericForeColor = SystemColors.WindowText;
    #endregion

    #region Ctor
    public NumericControl()
    {

      InitializeComponent();
      headerWithUnit1.HeaderBackColor = Color.Maroon;
      headerWithUnit1.ForeColor = Color.White;


      WidthHeightRatio = 2.8f;
      this.UIType = UserInterfaceUsingTypes.Control;
      numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;

      _powerOnImage = UserInterface.Properties.Resources.powerOn;
      _powerOffImage = UserInterface.Properties.Resources.powerOff;
      pictureBox1.Image = _powerOffImage;
      pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      pictureBox1.Click += pictureBox1_Click;
      this.SizeChanged += (object sender, EventArgs e) => { ChangeSize(); };

    }

    #endregion

    #region Properties
    [Browsable(false), Category("Appearance")]
    public override Color ForeColor
    {
      get
      {
        return base.ForeColor;
      }
      set
      {
        base.ForeColor = value;
      }
    }

    [Category("DoNotSave"), Description("Value of the data")]
    public override float Value
    {
      get
      {
        return base.Value;
      }
      set
      {
        value = Functions.MaxMinControl(value, HighValue, LowValue);
        base.Value = value;
        CrossThreadHelper.SetNumericControlOfValue(numericUpDown1, (decimal)value);

      }
    }

    [Category("Behavior"), Description("Indicates the minimum value for the numeric textbox control.")]
    public override float LowValue
    {
      get { return base.LowValue; }
      set
      {
        numericUpDown1.Minimum = (decimal)value;
        base.LowValue = value;
        Value = base.Value; // For Recheck value according to changed low value
      }
    }

    [Category("Behavior"), Description("Indicates the maximum value for the numeric textbox control.")]
    public override float HighValue
    {
      get { return base.HighValue; }
      set
      {
        numericUpDown1.Maximum = (decimal)value;
        base.HighValue = value;
        Value = base.Value; // For Recheck value according to changed high value
      }
    }
    public override int Precision
    {
      get
      {
        return base.Precision;
      }
      set
      {
        base.Precision = value;
        numericUpDown1.DecimalPlaces = base.Precision;
      }
    }
    [Category("Behavior"), Description("Indicates whether the background should change if the warning value is exceeded.")]
    public bool EnableWarningValue { get; set; }

    [Category("Behavior"), Description("Indicates whether the background should change if the error value is exceeded.")]
    public bool EnableAlarmValue { get; set; }

    [Category("Behavior"), Description("Indicates whether the numeric textbox control will increment and decrement the value when the UP ARROW and DOWN ARROW keys are pressed.")]
    public bool InterceptArrowKeys
    {
      get { return numericUpDown1.InterceptArrowKeys; }
      set { numericUpDown1.InterceptArrowKeys = value; }
    }

    [Category("Behavior"), Description("Indicates the amount to increment or decrement on each UP or DOWN ARROW press.")]
    public decimal Increment
    {
      get { return numericUpDown1.Increment; }
      set { numericUpDown1.Increment = value; }
    }

    [Category("Behavior"), Description("Indicates whether the thousands separator will be inserted between every three decimal digits.")]
    public bool ThousandsSeparator
    {
      get { return numericUpDown1.ThousandsSeparator; }
      set { numericUpDown1.ThousandsSeparator = value; }
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

    [Browsable(false), Category("Appearance")]
    public override Font HeaderFont
    {
      get { return base.HeaderFont; }
    }

    public override string Unit
    {
      get { return base.Unit; }
      set
      {
        headerWithUnit1.Unit = value;
        base.Unit = value;
      }
    }

    public override Color HeaderBackColor
    {
      get
      {
        return headerWithUnit1.HeaderBackColor;
      }
      set
      {
        headerWithUnit1.HeaderBackColor = value;
        Invalidate();
      }
    }

    public override Color HeaderForeColor
    {
      get
      {
        return base.HeaderForeColor;
      }
      set
      {
        base.HeaderForeColor = value;
        headerWithUnit1.ForeColor = value;
      }
    }

    [Browsable(false), Category("Appearance")]
    public override HeaderPosition HeaderPosition
    {
      get { return base.HeaderPosition; }
    }

    [Browsable(true), Category("Appearance")]
    public override bool HeaderVisible
    {
      set
      {
        base.HeaderVisible = value;
        headerWithUnit1.Visible = value;
        ChangeSize();
      }
      get { return base.HeaderVisible; }
    }

    public override string Header
    {
      get
      {
        return base.Header;
      }
      set
      {
        headerWithUnit1.Header = value;
        base.Header = value;
      }
    }

    [Browsable(true), Category("Appearance")]
    public Color NumericBackColor
    {
      get { return _numericBackColor; }
      set
      {
        if (value != LowAlarmColor && value != HighAlarmColor && value != LowWarnColor && value != HighWarnColor)
        {
          _numericBackColor = value;
          numericUpDown1.BackColor = value;
        }
      }
    }


    [Browsable(true), Category("Appearance")]
    public Color NumericForeColor
    {
      get { return _numericForeColor; }
      set
      {
        _numericForeColor = value;
        numericUpDown1.ForeColor = value;
      }
    }


    [Browsable(false), Category("DoNotSave")]
    public override bool DesignModeActive
    {
      get
      {
        return base.DesignModeActive;
      }
      set
      {
        base.DesignModeActive = value;
        numericUpDown1.Enabled = !value;
        headerWithUnit1.Enabled = !value;
        pictureBox1.Enabled = !value;
      }
    }

    [Browsable(false), Category("DoNotSave")]
    public override bool ControlEnable
    {
      get
      {
        return base.ControlEnable;
      }
      set
      {
        base.ControlEnable = value;
        //if (ActualUserLevel == User.UserLevels.Admin)
         pictureBox1.Image = ControlEnable ? _powerOnImage : _powerOffImage;
        //else
        //  pictureBox1.Image = _powerOffImage;

      }
    }


    #endregion

    #region Events
    private void pictureBox1_Click(object sender, EventArgs e)
    {

      if (SystemMode == SystemModes.Manual || SystemMode == SystemModes.Automatic)
        ControlEnable = !ControlEnable;
      else
        ControlEnable = false;

    }
    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
      if (Functions.InRange((float)numericUpDown1.Value, HighValue, LowValue))
        base.Value = (float)numericUpDown1.Value;
      else
        numericUpDown1.Value = (decimal)base.Value;
      Color c = NumericBackColor;

      if (EnableAlarmValue && Value <= LowAlarmValue)
        c = LowAlarmColor;
      else if (EnableAlarmValue && Value >= HighAlarmValue)
        c = HighAlarmColor;
      else if (EnableWarningValue && Value <= LowWarnValue)
        c = LowWarnColor;
      else if (EnableWarningValue && Value >= HighWarnValue)
        c = HighWarnColor;
      numericUpDown1.BackColor = c;
    }

    #endregion

    #region Local Method
    private void ChangeSize()
    {
      if (this.Width == 0 || this.Height == 0)
        return;
      Rectangle rcClient = new Rectangle();
      rcClient = ClientRectangle;
      if (BorderStyle == System.Windows.Forms.BorderStyle.Fixed3D)
        rcClient.Inflate(-SystemInformation.Border3DSize.Width, -SystemInformation.Border3DSize.Height);
      else if (BorderStyle == System.Windows.Forms.BorderStyle.FixedSingle)
        rcClient.Inflate(-SystemInformation.BorderSize.Width, -SystemInformation.BorderSize.Height);
      Font font;
      int numHeight = 0;
      if (HeaderVisible)
      {
        numHeight = (int)(rcClient.Height * 1.8f / 3f);
        font = Functions.GetFontForControlHeight(rcClient.Height * 1.8f / 3f, Font);
        headerWithUnit1.Left = rcClient.X;
        headerWithUnit1.Top = rcClient.Y;
        headerWithUnit1.Width = rcClient.Width;
        headerWithUnit1.Height = (int)(rcClient.Height * 1.2 / 3f);
        numericUpDown1.Width = rcClient.Width - numHeight;
        numericUpDown1.Top = (int)(headerWithUnit1.Bottom * 1.05f);

      }
      else
      {
        numHeight = rcClient.Height;
        font = Functions.GetFontForControlHeight(rcClient.Height, Font);
        numericUpDown1.Width = rcClient.Width - numHeight;
        numericUpDown1.Top = rcClient.X;
      }
      numericUpDown1.Font = font;
      numericUpDown1.Left = rcClient.X + rcClient.Width - numericUpDown1.Width;

      pictureBox1.Width = pictureBox1.Height = (int)(numHeight * 0.8f);
      pictureBox1.Top = numericUpDown1.Top + ((int)((numHeight - pictureBox1.Height) / 2f));
      pictureBox1.Left = rcClient.X + (int)((numericUpDown1.Left - pictureBox1.Width) / 2f);
      this.Invalidate();
    }
    #endregion

  }
}