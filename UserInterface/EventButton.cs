using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using GlobalFunctions;
using System.Drawing.Drawing2D;

namespace UserInterface
{
  public partial class EventButton : UIBase
  {

    private Button _pushButton;
    private string _buttonImageLocation;
    private string _buttonBackgroundImageLocation;
    public EventButton()
    {
      InitializeComponent();
      _pushButton = new Button();
      this.Controls.Add(_pushButton);
      _pushButton.Dock = DockStyle.Fill;
      _pushButton.MouseDown += _pushButton_MouseDown;
      _pushButton.MouseUp += _pushButton_MouseUp;
      _pushButton.MouseCaptureChanged += (object sender, EventArgs e) => { OnMouseCaptureChanged(e); };
      _pushButton.MouseDown += (object sender, MouseEventArgs e) => { this.OnMouseDown(ConvertArgumentToParent(e)); };
      _pushButton.MouseEnter += (object sender, EventArgs e) => { OnMouseEnter(e); };
      _pushButton.Click += (object sender, EventArgs e) => { OnClick(e); };
      _pushButton.MouseHover += (object sender, EventArgs e) => { OnMouseHover(e); };
      _pushButton.MouseLeave += (object sender, EventArgs e) => { OnMouseLeave(e); };
      _pushButton.MouseMove += (object sender, MouseEventArgs e) => { OnMouseMove(ConvertArgumentToParent(e)); };
      _pushButton.MouseUp += (object sender, MouseEventArgs e) => { OnMouseUp(ConvertArgumentToParent(e)); };
      _pushButton.MouseWheel += (object sender, MouseEventArgs e) => { OnMouseWheel(ConvertArgumentToParent(e)); };
      this.UIType = UserInterfaceUsingTypes.Decorative;
      _pushButton.BackColor = SystemColors.Control;
      _pushButton.FlatAppearance.BorderColor = Color.Empty;
      _pushButton.FlatAppearance.MouseDownBackColor = Color.Empty;
      _pushButton.FlatStyle = FlatStyle.Standard;
      _pushButton.UseVisualStyleBackColor = true;
      _pushButton.AutoSize = false;

    }

    void _pushButton_MouseUp(object sender, MouseEventArgs e)
    {

    }

    void _pushButton_MouseDown(object sender, MouseEventArgs e)
    {

    }

    protected override void OnClick(EventArgs e)
    {
      if (CanUserAccess && !DesignMode)
        base.OnClick(e);
    }
    private MouseEventArgs ConvertArgumentToParent(MouseEventArgs e)
    {
      //_pushButton.ImageAlign 
      int xTrans = e.X;
      int yTrans = e.Y;
      if (BorderStyle == System.Windows.Forms.BorderStyle.Fixed3D)
      {
        xTrans += SystemInformation.Border3DSize.Width;
        yTrans += SystemInformation.Border3DSize.Height;
      }
      else if (BorderStyle == System.Windows.Forms.BorderStyle.FixedSingle)
      {
        xTrans += SystemInformation.BorderSize.Width;
        yTrans += SystemInformation.BorderSize.Height;
      }
      return new MouseEventArgs(e.Button, e.Clicks, xTrans, yTrans, e.Delta);
    }

    [Localizable(true)]
    [RefreshProperties(RefreshProperties.All)]
    [EditorAttribute(typeof(ExtentedFileNameEditor), typeof(UITypeEditor)), DefaultValue("")]
    public string ButtonImageLocation
    {
      get { return _buttonImageLocation; }
      set
      {
        try
        {

          _buttonImageLocation = value;
          _pushButton.Image = Image.FromFile(value);
        }
        catch
        {
          _pushButton.Image = null;
          _pushButton.Refresh();
        }
      }
    }

    public ContentAlignment ButtonImageAlign
    {
      get { return _pushButton.ImageAlign; }
      set { _pushButton.ImageAlign = value; }
    }

    public ContentAlignment ButtonTextAlign
    {
      get { return _pushButton.TextAlign; }
      set { _pushButton.TextAlign = value; }
    }

    public TextImageRelation ButtonTextImageRelation
    {
      get { return _pushButton.TextImageRelation; }
      set { _pushButton.TextImageRelation = value; }
    }

    public FlatStyle ButtonFlatStyle
    {
      get { return _pushButton.FlatStyle; }
      set { _pushButton.FlatStyle = value; }
    }

    public Color ButtonBackColor
    {
      get { return _pushButton.BackColor; }
      set { _pushButton.BackColor = value; }
    }

    [Localizable(true)]
    [RefreshProperties(RefreshProperties.All)]
    [EditorAttribute(typeof(ExtentedFileNameEditor), typeof(UITypeEditor)), DefaultValue("")]
    public string ButtonBackgroundImageLocation
    {
      get { return _buttonBackgroundImageLocation; }
      set
      {
        try
        {
          _buttonBackgroundImageLocation = value;
          _pushButton.BackgroundImage = Image.FromFile(value);
        }
        catch
        {
          _pushButton.BackgroundImage = null;
          _pushButton.Refresh();
        }
      }
    }

    public ImageLayout ButtonBackgroundImageLayout
    {
      get { return _pushButton.BackgroundImageLayout; }
      set { _pushButton.BackgroundImageLayout = value; }
    }

    public override SystemModes SystemMode
    {
      get
      {
        return base.SystemMode;
      }
      set
      {
        base.SystemMode = value;
        CrossThreadHelper.SetControlOfEnable(value == SystemModes.Automatic || value == SystemModes.Manual, _pushButton);
      }
    }

    public override bool DesignModeActive
    {
      get
      {
        return base.DesignModeActive;
      }
      set
      {
        base.DesignModeActive = value;
      }
    }
    public override UserLevels ActualUserLevel
    {
      get
      {
        return base.ActualUserLevel;
      }
      set
      {
        base.ActualUserLevel = value;
        _pushButton.Enabled = CanUserAccess;
      }
    }

    public override UserLevels UserAccessLevel
    {
      get
      {
        return base.UserAccessLevel;
      }
      set
      {
        base.UserAccessLevel = value;
        _pushButton.Enabled = CanUserAccess;

      }
    }
    #region Property Hidden

    [Browsable(false), Category("Appearance")]
    public override BackFillTypes BackFillType
    {
      get
      {
        return base.BackFillType;
      }
      set
      {
        base.BackFillType = value;
      }
    }

    [Browsable(false), Category("Appearance")]
    public override Color BackGradientColor
    {
      get
      {
        return base.BackGradientColor;
      }
      set
      {
        base.BackGradientColor = value;
      }
    }

    [Browsable(false), Category("Appearance")]
    public override LinearGradientMode BackGradientMode
    {
      get
      {
        return base.BackGradientMode;
      }
      set
      {
        base.BackGradientMode = value;
      }
    }

    [Browsable(false)]
    public override Color BackColor
    {
      get
      {
        return base.BackColor;
      }
      set
      {
        base.BackColor = value;
      }
    }

    [Browsable(false)]
    public override string Header
    {
      get
      {
        return base.Header;
      }
      set
      {
        base.Header = value;
        // _pushButton.Text = value;
      }
    }

    [Browsable(false)]
    public override Color HeaderBackColor
    {
      get
      {
        return base.HeaderBackColor;
      }
      set
      {
        base.HeaderBackColor = value;
      }
    }

    [Browsable(false)]
    public override Font HeaderFont
    {
      get
      {
        return base.HeaderFont;
      }
      set
      {
        base.HeaderFont = value;
      }
    }

    [Browsable(false)]
    public override Color HeaderForeColor
    {
      get
      {
        return base.HeaderForeColor;
      }
      set
      {
        base.HeaderForeColor = value;
      }
    }

    [Browsable(false)]
    public override HeaderPosition HeaderPosition
    {
      get
      {
        return base.HeaderPosition;
      }
      set
      {
        base.HeaderPosition = value;
      }
    }

    [Browsable(false)]
    public override bool HeaderVisible
    {
      get
      {
        return base.HeaderVisible;
      }
      set
      {
        base.HeaderVisible = value;
      }
    }

    [Browsable(false), Category("Appearance")]
    public override string ChannelName
    {
      get
      {
        return base.ChannelName;
      }
      set
      {
        base.ChannelName = value;
        //_pushButton.Text = value;
      }
    }

    [Browsable(true)]
    public override string Text
    {
      get
      {
        return base.Text;
      }
      set
      {
        base.Text = value;
        _pushButton.Text = value;
      }
    }

    #endregion

  }

}
