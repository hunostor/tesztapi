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
        private readonly Calorie _dailyCalorieRequirement;
        private readonly DailyCalorieRange _dailyCalorieRange;

        public MonthlyDietPlanBuilder(IEnumerable<Meal> meals, Calorie dailyCalorieRequirement, DailyCalorieRange dailyCalorieRange)
        {
            _originalMealList = meals.ToList();
            _dailyCalorieRequirement = dailyCalorieRequirement;
            _dailyCalorieRange = dailyCalorieRange;
        }


        public MonthlyDietPlan Build()
        {
            var result = new MonthlyDietPlan();
            var selectedMealList = _originalMealList.Select(m => m.ToSelected()).ToList();

            var weeklyPlanBuilder = new WeeklyDietPlanBuilder(
                _originalMealList,
                selectedMealList,
                _dailyCalorieRequirement, 
                _dailyCalorieRange, 
                Enums.WeekNames.FirstWeek);
            result.FirstWeek = weeklyPlanBuilder.Build();
            result.Calorie = result.Calorie + result.FirstWeek.Calorie;
            result.AllMeal.AddRange(result.FirstWeek.AllMeal);

            weeklyPlanBuilder = new WeeklyDietPlanBuilder(
                _originalMealList,
                selectedMealList,
                _dailyCalorieRequirement, 
                _dailyCalorieRange, 
                Enums.WeekNames.SecondWeek);
            result.SecondWeek = weeklyPlanBuilder.Build();
            result.Calorie = result.Calorie + result.SecondWeek.Calorie;
            result.AllMeal.AddRange(result.SecondWeek.AllMeal);

            weeklyPlanBuilder = new WeeklyDietPlanBuilder(
                _originalMealList,
                selectedMealList,
                _dailyCalorieRequirement, 
                _dailyCalorieRange, 
                Enums.WeekNames.ThirdWeek);
            result.ThirdWeek = weeklyPlanBuilder.Build();
            result.Calorie = result.Calorie + result.ThirdWeek.Calorie;
            result.AllMeal.AddRange(result.ThirdWeek.AllMeal);

            weeklyPlanBuilder = new WeeklyDietPlanBuilder(
                _originalMealList,
                selectedMealList,
                _dailyCalorieRequirement, 
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
