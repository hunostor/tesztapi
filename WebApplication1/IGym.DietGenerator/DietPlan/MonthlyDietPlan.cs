using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.DietPlan
{
    public class MonthlyDietPlan
    {
        public Calorie Calorie { get; set; } = new Calorie(0);
        public List<SelectedMeal> AllMeal { get; set; } = new List<SelectedMeal>();
        public WeeklyDietPlan FirstWeek { get; set; }
        public WeeklyDietPlan SecondWeek { get; set; }
        public WeeklyDietPlan ThirdWeek { get; set; }
        public WeeklyDietPlan FourhtWeek { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
