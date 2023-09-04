using IGym.DietGenerator.DietPlan.CalorieAllocation;
using IGym.DietGenerator.Enums;
using IGym.DietGenerator.Extensions;
using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IGym.DietGenerator.DietPlan
{
    public class WeeklyDietPlanBuilder
    {
        private readonly List<SelectedMeal> _selectedMeals;
        private readonly DailyCalorieRange _dailyCalorieRange;
        private readonly WeekNames _weekName;

        public WeeklyDietPlanBuilder(
            List<SelectedMeal> selectedMeals,
            DailyCalorieRange dailyCalorieRange,
            WeekNames weekName
            )
        {
            _selectedMeals = selectedMeals;
            _dailyCalorieRange = dailyCalorieRange;
            _weekName = weekName;
        }

        public WeeklyDietPlan Build()
        {
            var result = new WeeklyDietPlan();

            foreach (DaysOfTheWeek dayName in Enum.GetValues(typeof(DaysOfTheWeek)))
            {
                var trace = new TimeTrace();
                trace.Week = _weekName;
                trace.Day = dayName;
                var dailyBuilder = new DailyPlanBuilder(
                    _selectedMeals, 
                    _dailyCalorieRange,
                    trace
                    );

                var dailyPlan = dailyBuilder.Build();

                result[dayName.ToString()] = dailyPlan;
                result.Calorie = result.Calorie + dailyPlan.Calorie;
                result.AllMeal.AddRange(dailyPlan.AllMeal);
            }

            return result;
        }
    }
}
