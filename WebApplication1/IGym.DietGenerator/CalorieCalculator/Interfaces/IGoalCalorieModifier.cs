using IGym.DietGenerator.Enums;
using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.CalorieCalculator.Interfaces
{
    public interface IGoalCalorieModifier
    {
        public Calorie ModifyDalyCalories(Calorie calorie, int bodyWeight, Goals goal);
    }
}
