﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.RawData
{
    public class Tire
    {
        private double tirePressure;

        private int tireAge;

        public Tire(double tirePressure, int tireAge)
        {
            this.TirePressure = tirePressure;
            this.TireAge = tireAge;
        }

        public double TirePressure { get; set; }
        public int TireAge { get; set; }              
                
    }
}
