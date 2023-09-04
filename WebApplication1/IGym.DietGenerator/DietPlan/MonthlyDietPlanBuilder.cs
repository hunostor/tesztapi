using IGym.DietGenerator.DietPlan.CalorieAllocation;
using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IGym.DietGenerator.DietPlan
{
    public class MonthlyDietPlanBuilder
    {
        private readonly List<Meal> _originalMealList;
        private readonly DailyCalorieRange _dailyCalorieRange;

        public MonthlyDietPlanBuilder(IEnumerable<Meal> meals, DailyCalorieRange dailyCalorieRange)
        {
            _originalMealList = meals.ToList();
            _dailyCalorieRange = dailyCalorieRange;
        }


        public MonthlyDietPlan Build()
        {
            var result = new MonthlyDietPlan();
            var selectedMealList = _originalMealList.Select(m => m.ToSelected()).ToList();

            var weeklyPlanBuilder = new WeeklyDietPlanBuilder(
                selectedMealList,
                _dailyCalorieRange, 
                Enums.WeekNames.FirstWeek);
            result.FirstWeek = weeklyPlanBuilder.Build();
            result.Calorie = result.Calorie + result.FirstWeek.Calorie;
            result.AllMeal.AddRange(result.FirstWeek.AllMeal);

            weeklyPlanBuilder = new WeeklyDietPlanBuilder(
                selectedMealList,
                _dailyCalorieRange, 
                Enums.WeekNames.SecondWeek);
            result.SecondWeek = weeklyPlanBuilder.Build();
            result.Calorie = result.Calorie + result.SecondWeek.Calorie;
            result.AllMeal.AddRange(result.SecondWeek.AllMeal);

            weeklyPlanBuilder = new WeeklyDietPlanBuilder(
                selectedMealList,
                _dailyCalorieRange, 
                Enums.WeekNames.ThirdWeek);
            result.ThirdWeek = weeklyPlanBuilder.Build();
            result.Calorie = result.Calorie + result.ThirdWeek.Calorie;
            result.AllMeal.AddRange(result.ThirdWeek.AllMeal);

            weeklyPlanBuilder = new WeeklyDietPlanBuilder(
                selectedMealList,
                _dailyCalorieRange, 
                Enums.WeekNames.FourhtWeek);
            result.FourhtWeek = weeklyPlanBuilder.Build();
            result.Calorie = result.Calorie + result.FourhtWeek.Calorie;
            result.AllMeal.AddRange(result.FourhtWeek.AllMeal);

            result.Timestamp = DateTime.UtcNow;

            return result;
        }
    }
}
