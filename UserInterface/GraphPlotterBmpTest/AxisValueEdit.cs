using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.GraphPlotter
{
  internal enum EditValueTypes
    {
      None,
      Xmin,
      Xmax,
      Y1min,
      Y1max,
      Y2min,
      Y2max,
      Y3min,
      Y3max,
      Y4min,
      Y4max,
    }
  /// <summary>
  /// To use edit axises values
  /// </summary>
  internal class AxisValueEdit
  {
    internal Rectangle LocationRectangle { get; set; }
    internal string EditedValue { get; set; }
    internal EditValueTypes EditValueType { get; set; }
    public AxisValueEdit(Rectangle locationReactangle, string editedValue, EditValueTypes editValueType)
    {
      LocationRectangle = locationReactangle;
      EditedValue = editedValue;
      EditValueType = editValueType;
    }
  }
}
