using IGym.DietGenerator.CalorieCalculator.Interfaces;
using IGym.DietGenerator.CalorieCalculator.Modifiers.Goals.WeightDependecies;
using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.CalorieCalculator.Modifiers.Goals
{
    public class MaleGoalCalorieModifier : IGoalCalorieModifier
    {
        private IGoalCalorieModifier _goalCalorieModifier;

        public Calorie ModifyDalyCalories(Calorie calorie, int bodyWeight, Enums.Goals goal)
        {
            if (goal == Enums.Goals.WeightGain)
            {
                this._goalCalorieModifier = new MaleWeightGain();
            }

            if (goal == Enums.Goals.WeightLoss)
            {
                this._goalCalorieModifier = new MaleWeightLoss();
            }

            return this._goalCalorieModifier.ModifyDalyCalories(calorie, bodyWeight, goal);
        }
    }
}
