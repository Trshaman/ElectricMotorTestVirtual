using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using GlobalFunctions;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
namespace UserInterface
{
  public delegate void DigitalValueChangedEventHandler(object Sender,bool oldValue ,bool newValue);
//  public delegate void DigitalValueChangeEventHandler(object sender, ValueChangeEventArgs e); Event leri bu hale getir
  public delegate void DigitalChannelChangedEventHandler(DigitalBase UIobject, string oldChannelName, string newChannelName);
  [DefaultProperty("ChannelName")]
  public partial class DigitalBase : UIBase
  {
    public event DigitalValueChangedEventHandler ValueChanged;
    public event DigitalChannelChangedEventHandler ChannelChanged;

    #region Local Variable

    private bool _value;


    #endregion    

    internal bool ValueChangeEventEnabled = false;
    #region Properties

    [EditorAttribute(typeof(SelEditor), typeof(UITypeEditor)),Category("DigitalBase"),DefaultValue(null)]
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
    [Category("DoNotSave")]
    public virtual bool Value
    {
      get { return _value; }
      set 
      {
        if (_value != value)
          Invalidate();
        _value = value;
        if (this.ValueChanged != null && ValueChangeEventEnabled)
        {
          ValueChangeEventEnabled = false;
          ValueChanged(this, _value, value);
        }
      
      }
    }

   // public virtual bool ControlEnable
    //{
    //  get;
    //  set;
    //}
    #endregion

    #region Ctor
    public DigitalBase()
    { 
      //Size değişikliğinde paint eventinin kalkması için konuldu
      SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
      SizeChanged += (object sender, EventArgs e) => { Invalidate(); };
      InitializeComponent();
    }
    #endregion

    #region Events

    #endregion

  }

  public class ValueChangeEventArgs : EventArgs
  {
    public bool Handeled { get; set; }
    public bool OldValue { get; set; }
    public bool NewValue { get; set; }
  }
}
