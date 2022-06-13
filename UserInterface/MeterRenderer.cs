

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using OtamSoft.IndustrialCtrls.Utils;

namespace OtamSoft.IndustrialCtrls.Meters
{
	/// <summary>
	/// Base class for the renderers of the analog meter
	/// </summary>
    public class OtamAnalogMeterRenderer
	{
		#region Variables
		/// <summary>
		/// Control to render
		/// </summary>
        private OtamAnalogMeter meter = null;
		#endregion
		
		#region Properties
        public OtamAnalogMeter AnalogMeter
		{
			set { this.meter = value; }
			get { return this.meter; }
		}
		#endregion
		
		#region Virtual method
		/// <summary>
		/// Draw the background of the control
		/// </summary>
		/// <param name="gr"></param>
		/// <param name="rc"></param>
		/// <returns></returns>
		public virtual bool DrawBackground( Graphics gr, RectangleF rc )
		{
			return false;
		}
		
		/// <summary>
		/// Draw the body of the control
		/// </summary>
		/// <param name="Gr"></param>
		/// <param name="rc"></param>
		/// <returns></returns>
		public virtual bool DrawBody( Graphics Gr, RectangleF rc )
		{
			return false;
		}
		
		/// <summary>
		/// Draw the scale of the control
		/// </summary>
		/// <param name="Gr"></param>
		/// <param name="rc"></param>
		/// <returns></returns>
		public virtual bool DrawDivisions( Graphics Gr, RectangleF rc )
		{
			return false;
		}
		
		/// <summary>
		/// Draw the low alert
		/// </summary>
		/// <param name="gr"></param>
		/// <param name="rc"></param>
		/// <returns></returns>
		public virtual bool DrawLowAlert( Graphics gr, RectangleF rc )
		{
			return false;
		}

        /// <summary>
        /// Draw the low warning
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawLowWarning(Graphics gr, RectangleF rc)
        {
            return false;
        }

        /// <summary>
        /// Draw the high alert
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawHighAlert(Graphics gr, RectangleF rc)
        {
            return false;
        }

        /// <summary>
        /// Draw the high warning
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawHighWarning(Graphics gr, RectangleF rc)
        {
            return false;
        }

		/// <summary>
		/// Drawt the unit measure of the control
		/// </summary>
		/// <param name="gr"></param>
		/// <param name="rc"></param>
		/// <returns></returns>
		public virtual bool DrawUM( Graphics gr, RectangleF rc )
		{
			return false;
		}
		
		/// <summary>
		/// Draw the current value in numerical form
		/// </summary>
		/// <param name="gr"></param>
		/// <param name="rc"></param>
		/// <returns></returns>
		public virtual bool DrawValue( Graphics gr, RectangleF rc )
		{
			return false;
		}
		
		/// <summary>
		/// Draw the needle 
		/// </summary>
		/// <param name="Gr"></param>
		/// <param name="rc"></param>
		/// <returns></returns>
		public virtual bool DrawNeedle( Graphics Gr, RectangleF rc )
		{
			return false;
		}
		
		/// <summary>
		/// Draw the needle cover at the center
		/// </summary>
		/// <param name="Gr"></param>
		/// <param name="rc"></param>
		/// <returns></returns>
		public virtual bool DrawNeedleCover( Graphics Gr, RectangleF rc )
		{
			return false;
		}
		
		/// <summary>
		/// Draw the glass effect
		/// </summary>
		/// <param name="Gr"></param>
		/// <param name="rc"></param>
		/// <returns></returns>
		public virtual bool DrawGlass( Graphics Gr, RectangleF rc )
		{
			return false;
		}
		#endregion
	}

	
	/// <summary>
	/// Default renderer class for the analog meter
	/// </summary>
    public class OtamDefaultAnalogMeterRenderer : OtamAnalogMeterRenderer
	{
		public override bool DrawBackground( Graphics gr, RectangleF rc )
		{
			if ( this.AnalogMeter == null )
				return false;
			
			Color c = this.AnalogMeter.Parent.BackColor;
			SolidBrush br = new SolidBrush ( c );
			Pen pen = new Pen ( c );
			
			Rectangle _rcTmp = new Rectangle(0, 0, this.AnalogMeter.Width, this.AnalogMeter.Height );
			gr.DrawRectangle ( pen, _rcTmp );
			gr.FillRectangle ( br, rc );
			
			return true;
		}
		
		public override bool DrawBody( Graphics Gr, RectangleF rc )
		{
			if ( this.AnalogMeter == null )
				return false;

            if (rc.Width == 0 || rc.Height == 0)
            {
                rc.Width = 100;
                rc.Height = 100;
            }

			Color bodyColor = this.AnalogMeter.BodyColor;
            Color cDark = OtamColorManager.StepColor(bodyColor, 20);
			
			LinearGradientBrush br1 = new LinearGradientBrush ( rc, 
			                                                   bodyColor,
			                                                   cDark,
			                                                   45 );
			Gr.FillEllipse ( br1, rc );
			
			float drawRatio = this.AnalogMeter.GetDrawRatio();
			
			RectangleF _rc = rc;
			_rc.X += 3 * drawRatio;
			_rc.Y += 3 * drawRatio;
			_rc.Width -= 6 * drawRatio;
			_rc.Height -= 6 * drawRatio;

			LinearGradientBrush br2 = new LinearGradientBrush ( _rc,
			                                                   cDark,
			                                                   bodyColor,
			                                                   45 );
			Gr.FillEllipse ( br2, _rc );
			
			return true;
		}

        public override bool DrawLowAlert(Graphics gr, RectangleF rc)
        {
            if (this.AnalogMeter == null)
                return false;

            float startAngle = this.AnalogMeter.GetStartAngle();
            float endAngle = this.AnalogMeter.GetEndAngle();
            float minValue = this.AnalogMeter.MinValue;
            float maxValue = this.AnalogMeter.MaxValue;
            float lowAlertValue = this.AnalogMeter.LowAlertValue;
            Color lowAlertColor = this.AnalogMeter.LowAlertColor;
            float stAngle = 0;
            float sweepAngle = 0;

            float w = rc.Width;
            float gap = w * 0.05F;
            float rangeOfIndicator = maxValue - minValue;
            float angleRange = endAngle - startAngle;

            stAngle = startAngle;
            if (lowAlertValue > maxValue) sweepAngle = angleRange;
            else if (lowAlertValue < minValue) sweepAngle = 0;
            else sweepAngle = (angleRange * (lowAlertValue - minValue)) / (rangeOfIndicator);

            SolidBrush br = new SolidBrush(lowAlertColor);
            Pen pen = new Pen(lowAlertColor, w / 25);

            RectangleF _rc = rc;

            if (_rc.Width == 0 || _rc.Height == 0)
            {
                _rc.Width = 100;
                _rc.Height = 100;
            }

            RectangleF _rcTmp = new RectangleF(_rc.X + gap, _rc.Y + gap, _rc.Width - gap * 2, _rc.Height - gap * 2);
            gr.DrawArc(pen, _rcTmp, stAngle, sweepAngle);

            return true;
        }

        public override bool DrawLowWarning(Graphics gr, RectangleF rc)
        {
            if (this.AnalogMeter == null)
                return false;

            float startAngle = this.AnalogMeter.GetStartAngle();
            float endAngle = this.AnalogMeter.GetEndAngle();
            float minValue = this.AnalogMeter.MinValue;
            float maxValue = this.AnalogMeter.MaxValue;
            float lowWarningValue = this.AnalogMeter.LowWarningValue;
            Color lowWarningColor = this.AnalogMeter.LowWarningColor;
            float lowAlertValue = this.AnalogMeter.LowAlertValue;
            float stAngle = 0;
            float sweepAngle = 0;

            float w = rc.Width;
            float gap = w * 0.06F;
            float rangeOfIndicator = maxValue - minValue;
            float angleRange = endAngle - startAngle;

            stAngle = startAngle;
            if (lowWarningValue <= minValue)
            {
                sweepAngle = 0;
            }

            else if (lowWarningValue >= maxValue)
            {
                if (lowAlertValue <= minValue)
                {
                    sweepAngle = angleRange;
                }
                else
                {
                    if (lowAlertValue <= maxValue)
                    {
                        stAngle = startAngle + angleRange * (lowAlertValue - minValue) / rangeOfIndicator;
                        sweepAngle = endAngle - stAngle;
                    }
                    else
                    {
                        stAngle = endAngle;
                        sweepAngle = 0;
                    }
                }
            }

            else
            {
                if (lowAlertValue <= minValue)
                {
                    sweepAngle = angleRange * (lowWarningValue - minValue) / rangeOfIndicator;
                }
                else
                {
                    if (lowAlertValue <= maxValue && lowWarningValue >= lowAlertValue)
                    {
                        stAngle = startAngle + angleRange * (lowAlertValue - minValue) / rangeOfIndicator;
                        sweepAngle = angleRange * (lowWarningValue - lowAlertValue) / rangeOfIndicator;
                    }
                    else
                    {
                        stAngle = endAngle;
                        sweepAngle = 0;
                    }
                }
            }

            SolidBrush br = new SolidBrush(lowWarningColor);
            Pen pen = new Pen(lowWarningColor, w / 50);

            RectangleF _rc = rc;

            if (_rc.Width == 0 || _rc.Height == 0)
            {
                _rc.Width = 100;
                _rc.Height = 100;
            }

            RectangleF _rcTmp = new RectangleF(_rc.X + gap, _rc.Y + gap, _rc.Width - gap * 2, _rc.Height - gap * 2);
            gr.DrawArc(pen, _rcTmp, stAngle, sweepAngle);

            return true;
        }

        public override bool DrawHighAlert(Graphics gr, RectangleF rc)
        {
            if (this.AnalogMeter == null)
                return false;

            float startAngle = this.AnalogMeter.GetStartAngle();
            float endAngle = this.AnalogMeter.GetEndAngle();
            float minValue = this.AnalogMeter.MinValue;
            float maxValue = this.AnalogMeter.MaxValue;
            float highAlertValue = this.AnalogMeter.HighAlertValue;
            Color highAlertColor = this.AnalogMeter.HighAlertColor;
            float stAngle;
            float sweepAngle;

            float w = rc.Width;
            float gap = w * 0.05F;
            float rangeOfIndicator = maxValue - minValue;
            float angleRange = endAngle - startAngle;

            stAngle = endAngle;
            if (highAlertValue < minValue) sweepAngle = -angleRange;
            else if (highAlertValue > maxValue) sweepAngle = 0;
            else sweepAngle = -angleRange * (maxValue - highAlertValue) / (rangeOfIndicator);

            SolidBrush br = new SolidBrush(highAlertColor);
            Pen pen = new Pen(highAlertColor, w / 25);

            RectangleF _rc = rc;

            if (_rc.Width == 0 || _rc.Height == 0)
            {
                _rc.Width = 100;
                _rc.Height = 100;
            }

            RectangleF _rcTmp = new RectangleF(_rc.X + gap, _rc.Y + gap, _rc.Width - gap * 2, _rc.Height - gap * 2);
            gr.DrawArc(pen, _rcTmp, stAngle, sweepAngle);

            return true;
        }

        public override bool DrawHighWarning(Graphics gr, RectangleF rc)
        {
            if (this.AnalogMeter == null)
                return false;

            float startAngle = this.AnalogMeter.GetStartAngle();
            float endAngle = this.AnalogMeter.GetEndAngle();
            float minValue = this.AnalogMeter.MinValue;
            float maxValue = this.AnalogMeter.MaxValue;
            float highWarningValue = this.AnalogMeter.HighWarningValue;
            Color highWarningColor = this.AnalogMeter.HighWarningColor;
            float highAlertValue = this.AnalogMeter.HighAlertValue;
            float stAngle = 0;
            float sweepAngle = 0;

            float w = rc.Width;
            float gap = w * 0.06F;
            float rangeOfIndicator = maxValue - minValue;
            float angleRange = endAngle - startAngle;

            stAngle = endAngle;
            if (highWarningValue >= maxValue)
            {
                sweepAngle = 0;
            }

            else if (highWarningValue <= minValue)
            {
                if (highAlertValue >= maxValue)
                {
                    sweepAngle = -angleRange;
                }
                else
                {
                    if (highAlertValue >= minValue)
                    {
                        stAngle = endAngle - angleRange * (maxValue - highAlertValue) / rangeOfIndicator;
                        sweepAngle = startAngle - stAngle;
                    }
                    else
                    {
                        stAngle = endAngle;
                        sweepAngle = 0;
                    }
                }
            }

            else
            {
                if (highAlertValue >= maxValue)
                {
                    sweepAngle = -angleRange * (maxValue - highWarningValue) / rangeOfIndicator;
                }
                else
                {
                    if (highAlertValue >= minValue && highWarningValue <= highAlertValue)
                    {
                        stAngle = endAngle - angleRange * (maxValue - highAlertValue) / rangeOfIndicator;
                        sweepAngle = - angleRange * (highAlertValue - highWarningValue) / rangeOfIndicator;
                    }
                    else
                    {
                        stAngle = endAngle;
                        sweepAngle = 0;
                    }
                }
            }

            SolidBrush br = new SolidBrush(highWarningColor);
            Pen pen = new Pen(highWarningColor, w / 50);

            RectangleF _rc = rc;

            if (_rc.Width == 0 || _rc.Height == 0)
            {
                _rc.Width = 100;
                _rc.Height = 100;
            }

            RectangleF _rcTmp = new RectangleF(_rc.X + gap, _rc.Y + gap, _rc.Width - gap * 2, _rc.Height - gap * 2);
            gr.DrawArc(pen, _rcTmp, stAngle, sweepAngle);

            return true;
        }

		public override bool DrawDivisions( Graphics Gr, RectangleF rc )
		{
            if ( this.AnalogMeter == null )
                return false;
			
			PointF needleCenter = this.AnalogMeter.GetNeedleCenter();
			float startAngle = this.AnalogMeter.GetStartAngle();
			float endAngle = this.AnalogMeter.GetEndAngle();
			float scaleDivisions = this.AnalogMeter.ScaleDivisions;
			float scaleSubDivisions = this.AnalogMeter.ScaleSubDivisions;
			float drawRatio = this.AnalogMeter.GetDrawRatio();
			double minValue = this.AnalogMeter.MinValue;
			double maxValue = this.AnalogMeter.MaxValue;
            double lowAlertValue = this.AnalogMeter.LowAlertValue;
			Color scaleColor = this.AnalogMeter.ScaleColor;
			
			float cx = needleCenter.X;
			float cy = needleCenter.Y;
			float w = rc.Width;
			float h = rc.Height;

            float incr = OtamMath.GetRadian((endAngle - startAngle) / ((scaleDivisions - 1) * (scaleSubDivisions + 1)));
            float currentAngle = OtamMath.GetRadian(startAngle);
			float radius = (float)(w / 2 - ( w * 0.08));
			float rulerValue = (float)minValue;

			Pen pen = new Pen ( scaleColor, ( 2 * drawRatio ) );
			SolidBrush br = new SolidBrush ( scaleColor );
			
			PointF ptStart = new PointF(0,0);
			PointF ptEnd = new PointF(0,0);
			int n = 0;
			for( ; n < scaleDivisions; n++ )
			{
					//Draw Thick Line
				ptStart.X = (float)(cx + radius * Math.Cos(currentAngle));
				ptStart.Y = (float)(cy + radius * Math.Sin(currentAngle));
				ptEnd.X = (float)(cx + (radius - w/20) * Math.Cos(currentAngle));
				ptEnd.Y = (float)(cy + (radius - w/20) * Math.Sin(currentAngle));
				Gr.DrawLine( pen, ptStart, ptEnd );
				
       				//Draw Strings
                if (drawRatio <= 0)
                {
                    drawRatio = 10F;
                }
       			Font font = new Font ( this.AnalogMeter.Font.FontFamily, (float)( 6F * drawRatio ) );
		
				float tx = (float)(cx + (radius - ( 25 * drawRatio )) * Math.Cos(currentAngle));
		        float ty = (float)(cy + (radius - ( 20 * drawRatio )) * Math.Sin(currentAngle));
                float val = rulerValue;
                String str = val.ToString("0.#");
		
				SizeF size = Gr.MeasureString ( str, font );
				Gr.DrawString ( str, 
				                font, 
				                br, 
				                tx - (float)( size.Width * 0.5 ), 
				                ty - (float)( size.Height * 0.2 ) );

				rulerValue += (float)(( maxValue - minValue) / (scaleDivisions - 1));
		
				if ( n == scaleDivisions -1)
					break;
		
				if ( scaleDivisions <= 0 )
					currentAngle += incr;
				else
				{
			        for (int j = 0; j <= scaleSubDivisions; j++)
			        {
						currentAngle += incr;
						ptStart.X = (float)(cx + radius * Math.Cos(currentAngle));
						ptStart.Y = (float)(cy + radius * Math.Sin(currentAngle));
						ptEnd.X = (float)(cx + (radius - w/50) * Math.Cos(currentAngle));
						ptEnd.Y = (float)(cy + (radius - w/50) * Math.Sin(currentAngle));
						Gr.DrawLine( pen, ptStart, ptEnd );
			        }
				}
			}
			
			return true;
		}
		
		public override bool DrawUM( Graphics gr, RectangleF rc )
		{
			return false;
		}
		
		public override bool DrawValue( Graphics gr, RectangleF rc )
		{
			return false;
		}
		
		public override bool DrawNeedle( Graphics Gr, RectangleF rc )
		{
			if ( this.AnalogMeter == null )
				return false;
			
			float w, h ;		
			w = rc.Width;
			h = rc.Height;
		
			double minValue = this.AnalogMeter.MinValue;
			double maxValue = this.AnalogMeter.MaxValue;
			double currValue = this.AnalogMeter.Value;
			float startAngle = this.AnalogMeter.GetStartAngle();
			float endAngle = this.AnalogMeter.GetEndAngle();
			PointF needleCenter = this.AnalogMeter.GetNeedleCenter();
			
			float radius = (float)(w / 2 - ( w * 0.13));
			float val = (float)(maxValue - minValue);
		
			val = (float)((100 * ( currValue - minValue )) / val);
			val = (( endAngle - startAngle ) * val) / 100;
		    val += startAngle;

            float angle = OtamMath.GetRadian(val);
		    
		    float cx = needleCenter.X;
		    float cy = needleCenter.Y;
		    
		    PointF ptStart = new PointF(0,0);
		    PointF ptEnd = new PointF(0,0);

		    GraphicsPath pth1 = new GraphicsPath();
				    
		    ptStart.X = cx;
		    ptStart.Y = cy;
            angle = OtamMath.GetRadian(val + 10);
			ptEnd.X = (float)(cx + (w * .09F) * Math.Cos(angle));
		    ptEnd.Y = (float)(cy + (w * .09F) * Math.Sin(angle));
		    pth1.AddLine ( ptStart, ptEnd );
		    
		    ptStart = ptEnd;
            angle = OtamMath.GetRadian(val);
		    ptEnd.X = (float)(cx + radius * Math.Cos(angle));
		    ptEnd.Y = (float)(cy + radius * Math.Sin(angle));
			pth1.AddLine ( ptStart, ptEnd );

		    ptStart = ptEnd;
            angle = OtamMath.GetRadian(val - 10);
			ptEnd.X = (float)(cx + (w * .09F) * Math.Cos(angle));
		    ptEnd.Y = (float)(cy + (w * .09F) * Math.Sin(angle));
		    pth1.AddLine ( ptStart, ptEnd );
			
		    pth1.CloseFigure();
		    
			SolidBrush br = new SolidBrush( this.AnalogMeter.NeedleColor );
		    Pen pen = new Pen ( this.AnalogMeter.NeedleColor );
			Gr.DrawPath ( pen, pth1 );
			Gr.FillPath ( br, pth1 );
			
			return true;
		}
		
		public override bool DrawNeedleCover( Graphics Gr, RectangleF rc )
		{
			if ( this.AnalogMeter == null )
				return false;

            //BURAYA BAK!!!////

			Color clr = this.AnalogMeter.NeedleColor;
            PointF needleCenter = this.AnalogMeter.GetNeedleCenter();
            float drawRatio = this.AnalogMeter.GetDrawRatio();
			RectangleF _rc = rc;
            float cx = needleCenter.X;
            float cy = needleCenter.Y;
            float width = 20;
            float height = 20;
            RectangleF _rcTmp1 = new RectangleF(cx - width / 2, cy - width / 2, width, height);
            Color clr1 = Color.FromArgb(70, clr);
            SolidBrush brTransp = new SolidBrush(clr1);
            
            Gr.FillEllipse(brTransp, _rcTmp1);
			//_rc.Inflate ( 5 * drawRatio, 5 * drawRatio );
            width = 10;
            height = 10;
			clr1 = clr;
            Color clr2 = OtamColorManager.StepColor(clr, 75);
            RectangleF _rcTmp2 = new RectangleF(cx - width / 2, cy - width / 2, width, height);
			LinearGradientBrush br1 = new LinearGradientBrush ( _rcTmp2, clr1, clr2, 45 );
			
            Gr.FillEllipse ( br1, _rcTmp2 );
			return true;
		}
		
		public override bool DrawGlass( Graphics Gr, RectangleF rc )
		{
			if ( this.AnalogMeter == null )
				return false;
			
			if ( this.AnalogMeter.ViewGlass == false )
				return true;
			
			Color clr1 = Color.FromArgb( 40, 200, 200, 200 );
			
			Color clr2 = Color.FromArgb( 0, 200, 200, 200 );
			LinearGradientBrush br1 = new LinearGradientBrush( rc,
			                                                   clr1,
			                                                   clr2,
			                                                   45 );
			Gr.FillEllipse ( br1, rc );
			
			return true;
		}
	}
}
