using IGym.DietGenerator.CalorieCalculator.Interfaces;
using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.CalorieCalculator.Modifiers.Workouts
{
    public class MaleLightWorkout : Workout
    {
        protected override int _caloriesToBeAdded { get; set; } = 50;

        
    }
}
