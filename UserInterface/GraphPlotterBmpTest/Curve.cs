using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.GraphPlotter
{
  [TypeConverter(typeof(CurveConverter))]
  public class Curve
  {

    public delegate void CurveChangeHandler(Curve curve);

    #region PublicVariable
    public List<PointF> Points;
    public List<PointF> BufPoints;
    public List<PointF> MarkPoints;
    public List<PointF> MarkPlottedPoints;
    public List<PointF> MarkScaledPlottedPoints;
    public bool Buf1Ready = false;
    public bool Buf2Ready = false;
    public float MaxValueTemp;
    public float MinValueTemp;
    internal event CurveChangeHandler CurveChanged;
    internal volatile int LastDrawnPointCount;
    #endregion

    #region Local Variable

    string _name;
    string _unit = "Unit";
    float _maxValue = 10;
    float _minValue = 0;
    float _maxAlarm;
    float _minAlarm;
    float _maxWarn;
    float _minWarn;
    Color _curveColor;
    Color _alarmColor;
    Color _warnColor;
    int _precision;
    bool _showCurve = true;
    PointF _value;
    int _curveNo;
    const int Xaxis = 0;
    const int Yaxis = 1;
    const int AxisMax = 0;
    const int AxisMin = 1;
    NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
    private float _width = 2f;
    #endregion

    #region Properties
    public float Width
    {
      get { return _width; }
      set
      {
        _width = value;
        RaiseCurveChangeEvent();
      }
    }
    public int CurveNo
    {
      get { return _curveNo; }
      set { _curveNo = value; }
    }
    public int Precision
    {
      get { return _precision; }
      set
      {
        _precision = value;
        RaiseCurveChangeEvent();

      }
    }

    /// <summary>
    /// For testing software use for channel name
    /// </summary>
    public string Name
    {
      get { return _name; }
      set
      {
        _name = value;
        RaiseCurveChangeEvent();
      }
    }

    public string Unit
    {
      get { return _unit; }
      set
      {
        _unit = value;
        RaiseCurveChangeEvent();
      }
    }
    public float MaxValue
    {
      get { return _maxValue; }
      set
      {
        _maxValue = value;
        MaxValueTemp = value;
        RaiseCurveChangeEvent();
      }
    }
    public float MinValue
    {
      get { return _minValue; }
      set
      {
        _minValue = value;
        MinValueTemp = value;
        RaiseCurveChangeEvent();
      }
    }
    public Color CurveColor
    {
      get { return _curveColor; }
      set { _curveColor = value; }
    }
    public float MaxAlarm
    {
      get { return _maxAlarm; }
      set { _maxAlarm = value; }
    }
    public float MinAlarm
    {
      get { return _minAlarm; }
      set { _minAlarm = value; }
    }
    public float MaxWarn
    {
      get { return _maxWarn; }
      set { _maxWarn = value; }
    }
    public float MinWarn
    {
      get { return _minWarn; }
      set { _minWarn = value; }
    }
    public Color AlarmColor
    {
      get { return _alarmColor; }
      set { _alarmColor = value; }
    }
    public Color WarnColor
    {
      get { return _warnColor; }
      set { _warnColor = value; }
    }
    public bool ShowCurve
    {
      get { return _showCurve; }
      set { _showCurve = value; }
    }
    public PointF Value
    {
      get { return _value; }
      set { _value = value; }
    }
    public void Clear()
    {
      Points.Clear();
      MarkPoints.Clear();
    }

    public Bitmap CurveBitmap { get; set; }

    #endregion

    #region Ctor
    public Curve(string name, float maxvalue, float minvalue, int precision, Color curvecolor, string unit):this()
    {

      Name = name;
      MaxValue = maxvalue;
      MinValue = minvalue;
      Precision = precision;
      CurveColor = curvecolor;
      Unit = unit;
      //nfi.NumberDecimalSeparator = ".";
      //nfi.NumberGroupSeparator = "";
      //Points = new List<PointF>();
      //MarkPoints = new List<PointF>();
      //MarkPlottedPoints = new List<PointF>();
      //MarkScaledPlottedPoints = new List<PointF>();

    }
    public Curve()
    {
      CurveBitmap = new Bitmap(100, 1000);
      CurveBitmap.SetResolution(256f, 256f);
      //CurveBitmap.MakeTransparent();
      nfi.NumberDecimalSeparator = ".";
      nfi.NumberGroupSeparator = "";
      Points = new List<PointF>();
      BufPoints = new List<PointF>();
      MarkPoints = new List<PointF>();
      MarkPlottedPoints = new List<PointF>();
      MarkScaledPlottedPoints = new List<PointF>();
    }
    #endregion

    #region Subs

    private void RaiseCurveChangeEvent()
    {
      if (CurveChanged != null)
        CurveChanged(this);
    }
    #endregion

    public override string ToString()
    {
      return this.Name;
    }
  }
}
