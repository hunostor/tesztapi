using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.CalorieCalculator.Modifiers.Workouts
{
    public class FemaleLightWorkout: Workout
    {
        protected override int _caloriesToBeAdded { get; set; } = 40;
    }
}
