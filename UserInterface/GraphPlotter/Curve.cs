using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace UserInterface.GraphPlotter
{
  [TypeConverter(typeof(CurveConverter))]
  public class Curve
  {

    public delegate void CurveChangeHandler(Curve curve);

    #region PublicVariable
    public PointF[] Points;
    public List<PointF> MarkPoints;
    public List<PointF> MarkPlottedPoints;
    public List<PointF> MarkScaledPlottedPoints;
    public float MaxValueTemp;
    public float MinValueTemp;
    internal event CurveChangeHandler CurveChanged;
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
    private volatile int _currentIndex;
    private int _bufferSize = 100000;
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

    internal int CurrentIndex
    {
      get
      {
        int RetVal = 0;
        RetVal = _currentIndex;
        _currentIndex++;
        LastIndex = _currentIndex;
        return RetVal;
      }
      set
      {
        LastIndex = _currentIndex = value;
      }
    }
    public int FirstIndex { get; private set; }

    internal int BufferSize
    {
      get { return _bufferSize; }
      set
      {
        if (value > 1000)
          _bufferSize = value;
        else
          _bufferSize = 1000;
        Points = new PointF[_bufferSize];
      }
    }
    public int LastIndex { get; private set; }

    public void Clear()
    {
      CurrentIndex = FirstIndex = 0;
      MarkPoints.Clear();
    }

    #endregion

    #region Ctor
    public Curve(string name, float maxvalue, float minvalue, int precision, Color curvecolor, string unit)
    {
      Name = name;
      MaxValue = maxvalue;
      MinValue = minvalue;
      Precision = precision;
      CurveColor = curvecolor;
      Unit = unit;
      nfi.NumberDecimalSeparator = ".";
      nfi.NumberGroupSeparator = "";
      Points = new PointF[BufferSize];
      MarkPoints = new List<PointF>();
      MarkPlottedPoints = new List<PointF>();
      MarkScaledPlottedPoints = new List<PointF>();

    }
    public Curve()
    {
      nfi.NumberDecimalSeparator = ".";
      nfi.NumberGroupSeparator = "";
      Points = new PointF[BufferSize];
      MarkPoints = new List<PointF>();
      MarkPlottedPoints = new List<PointF>();
      MarkScaledPlottedPoints = new List<PointF>();
    }
    #endregion

    #region Subs
    public void AddRange(PointF[] list)
    {
      for (int i = 0; i < list.Length; i++)
      {
        if (LastIndex >= BufferSize)
        {
          PointF[] coppyArray = new PointF[BufferSize];
          Array.Copy(Points, BufferSize / 5, coppyArray, 0, BufferSize - BufferSize / 5);
          CurrentIndex = BufferSize - BufferSize / 5;
          Points = coppyArray;
        }
        Points[CurrentIndex] = list[i];
      }

    }
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