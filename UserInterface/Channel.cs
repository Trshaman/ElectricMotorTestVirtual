using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
  /// <summary>
  /// Use for during to editing user interface of channel 
  /// </summary>
  public class Channel
  {
    public string Name { get; set; }
    public float Max { get; set; }
    public float Min { get; set; }

    public byte Precision { get; set; }

    public string Unit { get; set; }

    public Channel(string name, float max, float min, byte precision, string unit)
    {
      Name = name;
      Max = max;
      Min = min;
      Precision = precision;
      Unit = unit;
    }
    public override string ToString()
    {
      return Name;
    }


  }
}
