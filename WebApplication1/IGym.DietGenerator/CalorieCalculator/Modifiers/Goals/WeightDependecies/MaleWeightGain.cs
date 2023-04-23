using IGym.DietGenerator.CalorieCalculator.Interfaces;
using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.CalorieCalculator.Modifiers.Goals.WeightDependecies
{
    public class MaleWeightGain : IGoalCalorieModifier
    {
        public Calorie ModifyDalyCalories(Calorie calorie, int bodyWeight, Enums.Goals goal)
        {
            if (bodyWeight < 65)
            {
                calorie = calorie + new Calorie(500);                
            }
            else if (bodyWeight > 75)
            {
                calorie = calorie + new Calorie(200);
            }
            else if (bodyWeight >= 65 && bodyWeight <= 75)
            {
                calorie = calorie + new Calorie(300);
            }

            return calorie;
        }
    }
}
