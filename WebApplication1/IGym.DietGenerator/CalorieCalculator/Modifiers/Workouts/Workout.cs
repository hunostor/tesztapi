using IGym.DietGenerator.CalorieCalculator.Interfaces;
using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.CalorieCalculator.Modifiers.Workouts
{
    public class Workout: ICalorieModifier
    {
        protected virtual int _caloriesToBeAdded { get; set; }

        public virtual Calorie ModifyDalyCalories(Calorie calorie)
        {
            var value = calorie.Value;
            value += this._caloriesToBeAdded;
            return new Calorie(value);
        }
    }
}
