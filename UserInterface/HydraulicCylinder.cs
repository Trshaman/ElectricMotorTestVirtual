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
using GlobalFunctions;
using System.Drawing.Design;

namespace UserInterface
{
  [ToolboxItem(true)]
  public partial class HydraulicCylinder : AnalogBase
  {
    #region Variables
    private float _positionValue;
    private float _forceValue;
    private string _positionUnit;
    private string _forceUnit;
    private List<string> _channelName;
    private Color _cylinderRodColor;
    private Color _cylinderBodyColor;
    private Color _cylinderBodyGradientColor;
    private Color _cylinderRodGradientColor;
    private float _positionHighValue;
    private float _positionLowValue;
    private float _forceHighValue;
    private float _forceLowValue;
    private string _forceChannel;
    private string _positionChannel;
    #endregion

    #region Properties
    [EditorAttribute(typeof(SelEditor), typeof(UITypeEditor)), Category("Behavior"), DefaultValue(null)]
    public string ForceChannel
    {
      get { SelEditor.ChannelList = ChannelList; return _forceChannel; }
      set
      {
        OnChannelChanged(this, _forceChannel, value);
        _forceChannel = value;
      }
    }

    [EditorAttribute(typeof(SelEditor), typeof(UITypeEditor)), Category("Behavior"), DefaultValue(null)]
    public string PositionChannel
    {
      get { SelEditor.ChannelList = ChannelList; return _positionChannel; }
      set
      {
        OnChannelChanged(this, _positionChannel, value);
        _positionChannel = value;
      }
    }

    [Category("Appearance"), Description("Cylinder body color")]
    public Color CylinderBodyColor
    {
      get { return _cylinderBodyColor; }
      set
      {
        _cylinderBodyColor = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Cylinder body gradient color")]
    public Color CylinderBodyGradientColor
    {
      get { return _cylinderBodyGradientColor; }
      set
      {
        _cylinderBodyGradientColor = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Cylinder rod color")]
    public Color CylinderRodColor
    {
      get { return _cylinderRodColor; }
      set
      {
        _cylinderRodColor = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Cylinder rod gradient color")]
    public Color CylinderRodGradientColor
    {
      get { return _cylinderRodGradientColor; }
      set
      {
        _cylinderRodGradientColor = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Force Unit")]
    public string UnitForce
    {
      get { return _forceUnit; }
      set
      {
        _forceUnit = value;
        Invalidate();
      }
    }

    [Category("Appearance"), Description("Position Unit")]
    public string UnitPosition
    {
      get { return _positionUnit; }
      set
      {
        _positionUnit = value;
        Invalidate();
      }
    }

    [Category("DoNotSave"), Description("Value of Position"), Browsable(false)]
    public override float Value
    {
      get
      {
        return base.Value;
      }
      set
      {
        base.Value = value;
      }
    }

    [Category("DoNotSave"), Description("Value of Position")]
    public float PositionValue
    {
      get { return _positionValue; }
      set
      {
        if (_positionValue != value)
          Invalidate();
        _positionValue = value;
      }
    }

    [Category("DoNotSave"), Description("Value of Force")]
    public float ForceValue
    {
      get { return _forceValue; }
      set
      {
        if (_forceValue != value)
          Invalidate();
        _forceValue = value;
      }
    }

    [Category("Behavior"), Description("Maximum value of Position")]
    public float PositionHighValue
    {
      get
      {
        return _positionHighValue;
      }
      set
      {
        _positionHighValue = value;
        Invalidate();
      }
    }

    [Category("Behavior"), Description("Minimum value of Position")]
    public float PositionLowValue
    {
      get
      {
        return _positionLowValue;
      }
      set
      {
        _positionLowValue = value;
        Invalidate();
      }
    }

    [Category("Behavior"), Description("Maximum value of Force")]
    public float ForceHighValue
    {
      get
      {
        return _forceHighValue;
      }
      set
      {
        _forceHighValue = value;
        Invalidate();
      }
    }

    [Category("Behavior"), Description("Minimum value of Force")]
    public float ForceLowValue
    {
      get
      {
        return _forceLowValue;
      }
      set
      {
        _forceLowValue = value;
        Invalidate();
      }
    }
    #endregion

    #region Hiding Property
    [Browsable(false), Category("DoNotSave")]
    public override string ChannelName
    {
      get
      {
        return base.ChannelName;
      }
      set
      {
        base.ChannelName = value;
      }
    }

    [Browsable(false)]
    public override float HighValue
    {
      get
      {
        return base.HighValue;
      }
      set
      {
        base.HighValue = value;
      }
    }

    [Browsable(false)]
    public override float LowValue
    {
      get
      {
        return base.LowValue;
      }
      set
      {
        base.LowValue = value;
      }
    }

    [Browsable(false)]
    public override string Unit
    {
      get
      {
        return base.Unit;
      }
      set
      {
        base.Unit = value;
      }
    }

    [Browsable(false)]
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

    [Browsable(false)]
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

    [Browsable(false)]
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
    public override Color LowAlarmColor
    {
      get
      {
        return base.LowAlarmColor;
      }
      set
      {
        base.LowAlarmColor = value;
      }
    }

    [Browsable(false)]
    public override float LowAlarmValue
    {
      get
      {
        return base.LowAlarmValue;
      }
      set
      {
        base.LowAlarmValue = value;
      }
    }

    [Browsable(false)]
    public override Color LowWarnColor
    {
      get
      {
        return base.LowWarnColor;
      }
      set
      {
        base.LowWarnColor = value;
      }
    }

    [Browsable(false)]
    public override float LowWarnValue
    {
      get
      {
        return base.LowWarnValue;
      }
      set
      {
        base.LowWarnValue = value;
      }
    }

    [Browsable(false)]
    public override Color HighAlarmColor
    {
      get
      {
        return base.HighAlarmColor;
      }
      set
      {
        base.HighAlarmColor = value;
      }
    }

    [Browsable(false)]
    public override float HighAlarmValue
    {
      get
      {
        return base.HighAlarmValue;
      }
      set
      {
        base.HighAlarmValue = value;
      }
    }

    [Browsable(false)]
    public override Color HighWarnColor
    {
      get
      {
        return base.HighWarnColor;
      }
      set
      {
        base.HighWarnColor = value;
      }
    }

    [Browsable(false)]
    public override float HighWarnValue
    {
      get
      {
        return base.HighWarnValue;
      }
      set
      {
        base.HighWarnValue = value;
      }
    }
    #endregion

    #region Ctor

    public HydraulicCylinder()
    {
      InitializeComponent();
      WidthHeightRatio = 0f;
      CylinderBodyColor = Color.FromArgb(1, 82, 138);
      CylinderRodColor = Color.Gray;
      CylinderBodyGradientColor = Color.CornflowerBlue;
      CylinderRodGradientColor = Color.White;
      // BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      _forceUnit = "N";
      _positionUnit = "mm";
      _channelName = new List<string>();
      _channelName.Add("");
      _channelName.Add("");
    }

    #endregion

    #region Events
    public override void OnChannelChanged(AnalogBase UIobject, string oldChannelName, string newChannelName)
    {
      base.OnChannelChanged(UIobject, oldChannelName, newChannelName);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      if ((this.Width > 20) && (this.Height > 20))
      {
        Rectangle rcHeader = new Rectangle();
        if (HeaderVisible)
        {
          //////////////////////// Başlık ////////////////////////////////////////////////////////////////////////////////////////////////////
          rcHeader.Size = new Size(Width, (int)(Height * .1f));
          StringFormat sf = new StringFormat();
          sf.LineAlignment = StringAlignment.Center;
          sf.Alignment = StringAlignment.Center;
          Pen penBorder = new Pen(Color.FromArgb(175, 175, 175));
          SizeF headerSize = e.Graphics.MeasureString(Header, HeaderFont);

          LinearGradientBrush brBorder = new LinearGradientBrush(rcHeader, Color.Gray, Color.Linen, 0f, true);
          brBorder.SetSigmaBellShape(.5f, .6f);
          GraphicsPath path = RoundedRectangle.Create(0, 0, rcHeader.Width, rcHeader.Height, 1);
          e.Graphics.FillPath(brBorder, path);
          e.Graphics.DrawPath(penBorder, path);
          Font font1 = new Font(HeaderFont.Name, rcHeader.Height / 1.5f);
          SolidBrush brHeader = new SolidBrush(this.HeaderForeColor);
          float tx = (float)((rcHeader.Width) / 2);
          float ty = (float)((rcHeader.Height) / 2);
          e.Graphics.DrawString(Header, font1, brHeader, tx, ty, sf);
          penBorder.Dispose();
          brBorder.Dispose();
          brHeader.Dispose();
        }

        SizeF ratioRecCylBody = new SizeF(0.8f, 0.55f);
        SizeF ratioRecCylFlange = new SizeF(0.8f, 0.1f);
        SizeF ratioRecCylRod = new SizeF(0.3f, 0.1f);
        Rectangle recCylBody = new Rectangle((int)(Width * (1 - ratioRecCylBody.Width)) / 2, Height - (int)(Height * ratioRecCylBody.Height), (int)(Width * ratioRecCylBody.Width), (int)(Height * ratioRecCylBody.Height));
        float recCylBodyMaxY = rcHeader.Bottom + (Height * 0.01f);
        float recCylBodyMinY = recCylBody.Y - Height * (ratioRecCylFlange.Height + 0.01f);
        float recCylBodyY = 0f;
        if ((PositionHighValue - PositionLowValue) != 0)
        {
          float aConst = (recCylBodyMaxY - recCylBodyMinY) / (PositionHighValue - PositionLowValue);
          float bConst = recCylBodyMaxY - aConst * PositionHighValue;
          recCylBodyY = aConst * Functions.MaxMinControl(PositionValue, PositionHighValue, PositionLowValue) + bConst;
        }
        else
          recCylBodyY = recCylBodyMinY;
        Rectangle recCylFlange = new Rectangle(recCylBody.X, (int)(recCylBodyY), (int)(Width * ratioRecCylFlange.Width), (int)(Height * ratioRecCylFlange.Height));
        Rectangle recCylRod = new Rectangle((int)(Width * (1 - ratioRecCylRod.Width)) / 2, recCylFlange.Bottom, (int)(Width * ratioRecCylRod.Width), recCylBody.Top - recCylFlange.Bottom);
        if (recCylBody.Width != 0 && recCylBody.Height != 0 && recCylFlange.Width != 0 && recCylFlange.Height != 0 && recCylRod.Width != 0 && recCylRod.Height != 0)
        {
          using (LinearGradientBrush brsh = new LinearGradientBrush(recCylBody, CylinderBodyColor, CylinderBodyGradientColor, 0f, true))
          {
            brsh.SetSigmaBellShape(.5f, .6f);
            e.Graphics.FillRectangle(brsh, recCylBody);
          }
          using (LinearGradientBrush brsh = new LinearGradientBrush(recCylFlange, CylinderBodyColor, CylinderBodyGradientColor, LinearGradientMode.Horizontal))
          {
            brsh.SetSigmaBellShape(.5f, .6f);
            e.Graphics.FillRectangle(brsh, recCylFlange);
          }
          using (LinearGradientBrush brsh = new LinearGradientBrush(recCylRod, CylinderRodColor, CylinderRodGradientColor, 0f, true))
          {
            brsh.SetSigmaBellShape(.5f, .6f);
            e.Graphics.FillRectangle(brsh, recCylRod);
          }
        }
        Font = new System.Drawing.Font(Font.FontFamily, recCylFlange.Height / 2f);
        SolidBrush brFont = new SolidBrush(HeaderForeColor);
        SizeF forceTextSize = e.Graphics.MeasureString(ForceValue.ToString() + UnitForce, Font);
        e.Graphics.DrawString(ForceValue.ToString() + UnitForce, Font, brFont, new PointF(recCylFlange.X + (recCylFlange.Width - forceTextSize.Width) / 2, recCylFlange.Y + (recCylFlange.Height - forceTextSize.Height) / 2));
        forceTextSize = e.Graphics.MeasureString(PositionValue.ToString() + UnitPosition, Font);
        StringFormat drawFormat = new System.Drawing.StringFormat(StringFormatFlags.DirectionVertical);
        e.Graphics.DrawString(PositionValue.ToString() + UnitPosition, Font, brFont, new PointF(recCylBody.X + (recCylBody.Width - forceTextSize.Height) / 2, recCylBody.Y + (recCylBody.Height - forceTextSize.Width) / 2), drawFormat);

      }
    }

    #endregion

  }
}
