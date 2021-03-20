﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals
{
    public abstract class Bird : Animal
    {
        protected Bird(string name,
            double weight,            
            HashSet<string> allowedFoods,
            double weightModifier,
            double wingSize) 
            : base(name, weight, allowedFoods, weightModifier)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; set; }
               
        public override string ToString()
        {
            return $"{GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
