﻿using IGym.DietGenerator.CalorieCalculator.Interfaces;
using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.CalorieCalculator.Modifiers.Goals.WeightDependecies
{
    public class FemaleWeightLoss : IGoalCalorieModifier
    {
        public Calorie ModifyDalyCalories(Calorie calorie, int bodyWeight, Enums.Goals goal)
        {
            calorie = calorie - new Calorie(300);

            return calorie;
        }
    }
}
