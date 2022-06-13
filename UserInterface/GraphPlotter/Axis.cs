using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.GraphPlotter
{
  /// <summary>
  /// Reğresent of Axis properties
  /// </summary>
  [TypeConverter(typeof(AxisConverter))]
  public class Axis
  {
    private float _max;
    private float _min;
    private int _tickCount = 5;
    private float _division;


    [Category("Appearance")]
    public int TickCount
    {
      get { return _tickCount; }
      set
      {
        if (value < 2) value = 2;
        if (value > 7) value = 7;
        _tickCount = value;
      }
    }

    public string Name { get; set; }

    public string Unit { get; set; }

    public float Max
    {
      get { return _max; }
      set
      {
        ReplacedMax = _max = value;
        _division = (_max - _min) / TickCount;
      }
    }

    public float Min
    {
      get { return _min; }
      set
      {
        ReplacedMin = _min = value;
        _division = (_max - _min) / TickCount;
      }
    }

    internal float ReplacedMax { get; set; }

    internal float ReplacedMin { get; set; }

    public float Division 
    {
      get { return _division; } 
      set
      {
        _division = value;
        ReplacedMax = ReplacedMin + Division * (TickCount - 1);
      }
    }

    public int Precision { get; set; }

    public Color AxisColor { get; set; }

    public override string ToString()
    {
      return Name;
    }

    public Axis(string name, string unit, Color axisColor, float max, float min, int precision, int tickCount)
    {
      TickCount = tickCount;
      Name = name;
      Unit = unit;
      Max = max;
      Min = min;
      Precision = precision;
      AxisColor = axisColor;
      
    }

    public Axis()
    {
    }



  }

  public class AxisConverter : ExpandableObjectConverter
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
          Color clr = Color.FromArgb(int.Parse(v[2]));
          Axis axis = new Axis(v[0], v[1], clr, float.Parse(v[3]), float.Parse(v[4]), int.Parse(v[5]), int.Parse(v[6]));

          return axis;
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
        if (value.GetType() == typeof(Axis))
        {
          Axis axis = (Axis)value;
          string str = string.Empty;
          str = axis.Name + ";" + axis.Unit + ";" + axis.AxisColor.ToArgb().ToString() + ";" + axis.Max.ToString() + ";" + axis.Min.ToString() + ";" + axis.Precision.ToString() + ";" + axis.TickCount.ToString();
          return str;
        }
        else
          return null;
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }


  }
}
