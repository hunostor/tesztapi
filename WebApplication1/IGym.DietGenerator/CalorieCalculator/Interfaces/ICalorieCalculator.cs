using IGym.DietGenerator.Models;
using IGym.DietGenerator.Req;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.CalorieCalculator.Interfaces
{
    public interface ICalorieCalculator
    {
        public Calorie CalculateDaliyCalorie(Request request);
    }
}
