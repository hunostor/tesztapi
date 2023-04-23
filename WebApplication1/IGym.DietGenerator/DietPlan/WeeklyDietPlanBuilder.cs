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
        private readonly List<Meal> _originalMealList;
        private readonly List<SelectedMeal> _selectedMeals;
        private readonly Calorie _dailyCalorieRequirement;
        private readonly DailyCalorieRange _dailyCalorieRange;
        private readonly WeekNames _weekName;

        public WeeklyDietPlanBuilder(
            IEnumerable<Meal> meals,
            List<SelectedMeal> selectedMeals,
            Calorie dailyCalorieRequirement, 
            DailyCalorieRange dailyCalorieRange,
            WeekNames weekName
            )
        {
            _originalMealList = meals.ToList();
            _selectedMeals = selectedMeals;
            _dailyCalorieRequirement = dailyCalorieRequirement;
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
                    _originalMealList,
                    _selectedMeals, 
                    _dailyCalorieRequirement, 
                    _dailyCalorieRange,
                    trace
                    );

                var dailyPlan = dailyBuilder.Build();

                result[dayName.ToString()] = dailyPlan;
                result.Calorie = result.Calorie + dailyPlan.Calorie;
                result.AllMeal.AddRange(dailyPlan.AllMeal);

                //removeMeal(dailyPlan.Breakfast, _selectedMeals);
                //removeMeal(dailyPlan.Snack1, _selectedMeals);
                //removeMeal(dailyPlan.Lunch, _selectedMeals);
                //removeMeal(dailyPlan.Snack2, _selectedMeals);
                //removeMeal(dailyPlan.Dinner, _selectedMeals);
            }

            return result;
        }

        private void removeMeal(Meal meal, List<SelectedMeal> meals)
        {
            meals.RemoveAll(m => m.MealId == meal.MealId && m.Name == meal.Name);
        }
    }
}
