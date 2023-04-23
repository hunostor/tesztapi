using IGym.DietGenerator.Enums;
using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.DietPlan
{
    public class DailyDietPlan
    {
        public DaysOfTheWeek DayName { get; set; }
        public List<SelectedMeal> AllMeal { get; set; } = new List<SelectedMeal>();
        public Calorie Calorie { get; set; } = new Calorie(0);
        public SelectedMeal Breakfast { get; set; }
        public SelectedMeal Snack1 { get; set; }
        public SelectedMeal Lunch { get; set; }
        public SelectedMeal Snack2 { get; set; }
        public SelectedMeal Dinner { get; set; }

    }
}
