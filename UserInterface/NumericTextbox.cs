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
using System.Threading;

namespace UserInterface
{

  public partial class NumericTextbox : TextBox
  {
    public delegate void ValuChangedEventHandler(object sender);
    public event ValuChangedEventHandler ValueChanged;
    private double _value;
    public enum InputTypes
    {
      Integer,
      Double,
      UnSignedInteger,
    }

    public InputTypes InputType { get; set; }

    public double MaxValue { get; set; }

    public double MinValue { get; set; }

    public double Value
    {
      get { return _value; }
      set
      {
        if (value != _value && ValueChanged != null)
        {
          _value = value;
          ValueChanged(this);
        }
        CrossThreadHelper.SetControlOfText(value.ToString(), this);
        _value = value;
      }
    }

    public char NumberDecimalSeparator { get;  set; }

    public NumericTextbox()
    {

      InitializeComponent();
      InputType = InputTypes.Integer;
      this.KeyPress += this_KeyPress;
      this.TextAlign = HorizontalAlignment.Right;
      this.LostFocus += NumericTextbox_LostFocus;
    }

    

    private void NumericTextbox_LostFocus(object sender, EventArgs e)
    {
      Value = Functions.MaxMinControl(Functions.ToDouble(this.Text), MaxValue, MinValue);
    }

    private void this_KeyPress(object sender, KeyPressEventArgs e)
    {
      if(NumberDecimalSeparator == 0)
        NumberDecimalSeparator = Thread.CurrentThread.CurrentUICulture.NumberFormat.NumberDecimalSeparator[0];

      if (e.KeyChar == '\r')
        Value = Functions.MaxMinControl(Functions.ToDouble(this.Text), MaxValue, MinValue);
      else if (InputType == InputTypes.Double)
        Functions.NumericFloatInput(ref e, NumberDecimalSeparator, this.Text, this.SelectionStart);
      else if (InputType == InputTypes.Integer)
        Functions.NumericIntInput(ref e, this.Text, this.SelectionStart);
      else
        Functions.NumericUnSignIntInput(ref e);
    }

  }
}
