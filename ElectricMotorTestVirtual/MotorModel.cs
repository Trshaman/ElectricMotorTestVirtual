using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectricMotorTestVirtual
{
    public class MotorModel
    {
        private int motorModelType;
        private int motorMagnetCouple;
        private int motorPowerVoltage;
        private double loadTestFirstNm;
        private double loadTestSecondNm;
        private string motorBarcode;
        private string rotorBarcode;
        private Coefficent coefficentR1;
        private Coefficent coefficentR2;
        private Coefficent coefficentR3;
        private Coefficent coefficentL1;
        private Coefficent coefficentL2;
        private Coefficent coefficentL3;
        private Coefficent unloadRpm;
        private Coefficent loadRpmPoint1;
        private Coefficent loadRpmPoint2;
        


        public int MotorModelType
        {
            get => default;
            set
            {
            }
        }

        public int MotorMagnetCouple
        {
            get => default;
            set
            {
            }
        }

        public int MotorPowerVoltage
        {
            get => default;
            set
            {
            }
        }

        public double LoadTestFirstNm
        {
            get => default;
            set
            {
            }
        }

        public double LoadTestSecondNm
        {
            get => default;
            set
            {
            }
        }

        public string MotorBarcode { get; set; }

        public string RotorBarcode { get; set; }
        public Coefficent CoefficentL1 { get; set; }

        public Coefficent CoefficentL2 { get; set; }

        public Coefficent CoefficentL3 { get; set; }

        public Coefficent CoefficentR1 { get; set; }

        public Coefficent CoefficentR2 { get; set; }

        public Coefficent CoefficentR3 { get; set; }

        public Coefficent UnloadRpm { get; set; }

        public Coefficent LoadRpmPoint1 { get; set; }

        public Coefficent LoadRpmPoint2 { get; set; }
    }
}