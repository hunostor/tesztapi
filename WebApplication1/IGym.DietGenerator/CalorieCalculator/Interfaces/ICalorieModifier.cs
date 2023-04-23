using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.CalorieCalculator.Interfaces
{
    public interface ICalorieModifier
    {
        public Calorie ModifyDalyCalories(Calorie calorie);
    }
}
