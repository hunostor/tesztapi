using IGym.DietGenerator.CalorieCalculator.Interfaces;
using IGym.DietGenerator.CalorieCalculator.Modifiers.Goals.WeightDependecies;
using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.CalorieCalculator.Modifiers.Goals
{
    public class FemaleGoalCalorieModifier : IGoalCalorieModifier
    {
        private IGoalCalorieModifier _goalCalorieModifier;

        public Calorie ModifyDalyCalories(Calorie calorie, int bodyWeight, Enums.Goals goal)
        {
            if(goal == Enums.Goals.WeightGain)
            {
                this._goalCalorieModifier = new FemaleWeightGain();
            }

            if(goal == Enums.Goals.WeightLoss)
            {
                this._goalCalorieModifier = new FemaleWeightLoss();
            }

            return this._goalCalorieModifier.ModifyDalyCalories(calorie, bodyWeight, goal);
        }
    }
}
