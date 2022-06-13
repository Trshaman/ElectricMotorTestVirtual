using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;

namespace UserInterface.GraphPlotter
{
  public class CurveConverter : ExpandableObjectConverter  
  {


    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
      if (sourceType == typeof(string))
      {
        return true;
      }
      return base.CanConvertFrom(context, sourceType);
    }

    public new bool CanConvertFrom(Type sourceType)
    {
      return sourceType == typeof(string);
    }

    // Overrides the ConvertFrom method of TypeConverter.
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (value is string)
      {
        try
        {
          string[] v = ((string)value).Split(new char[] { ';' });
          Color clr = Color.FromArgb(int.Parse(v[4]));
          Curve crv = new Curve(v[0], float.Parse(v[1]), float.Parse(v[2]), int.Parse(v[3]),clr, v[5]);
          crv.CurveNo = int.Parse(v[7]);
          crv.Width = float.Parse(v[6]);
          return crv;
        }
        catch
        {
          return null;
        }
      }
      return base.ConvertFrom(context, culture, value);
    }

  


    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType == typeof(string))
      {
        if (value.GetType() == typeof(Curve))
        {
          Curve crv = (Curve)value;
          string str = string.Empty;
          str = crv.Name + ";" + crv.MaxValue.ToString() + ";" + crv.MinValue.ToString() + ";" + crv.Precision.ToString() + ";" + crv.CurveColor.ToArgb().ToString() + ";" + crv.Unit + ";" + crv.Width.ToString() + ";" + crv.CurveNo.ToString() ;
          return str;
        }
        else
          return null;
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }

   
  }
}
