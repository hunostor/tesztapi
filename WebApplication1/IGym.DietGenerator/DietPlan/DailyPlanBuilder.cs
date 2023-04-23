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
    public class DailyPlanBuilder
    {
        private readonly List<Meal> _meals;
        private readonly List<SelectedMeal> _selectedMeals;
        private readonly Calorie _dailyCalorieRequirement;
        private readonly DailyCalorieRange _dailyCalorieRange;
        private readonly TimeTrace _timeTrace;

        public DailyPlanBuilder(
            IEnumerable<Meal> originalMealList,
            IEnumerable<SelectedMeal> selectedMeals,
            Calorie dailyCalorieRequirement, 
            DailyCalorieRange dailyCalorieRange,
            TimeTrace timeTrace
            )
        {
            _meals = originalMealList.ToList();
            _selectedMeals = selectedMeals.ToList();
            _dailyCalorieRequirement = dailyCalorieRequirement;
            _dailyCalorieRange = dailyCalorieRange;
            _timeTrace = timeTrace;
        }

        public DailyDietPlan Build()
        {
            //var clonedMeals = _meals.DeepClone().ToList();
            var result = new DailyDietPlan();

            result.Breakfast = selectMeal(MealTimeOfDay.Breakfast, _selectedMeals);
            var timeTrace = new TimeTrace()
            {
                Week = _timeTrace.Week,
                Day = _timeTrace.Day,
                TimeOfDay = MealTimeOfDay.Breakfast
            };
            result.Breakfast.Trace.Add(timeTrace);            
            result.AllMeal.Add(result.Breakfast);

            result.Snack1 = selectMeal(MealTimeOfDay.Snack1, _selectedMeals);
            timeTrace = new TimeTrace()
            {
                Week = _timeTrace.Week,
                Day = _timeTrace.Day,
                TimeOfDay = MealTimeOfDay.Snack1
            };
            result.Snack1.Trace.Add(timeTrace);
            result.AllMeal.Add(result.Snack1);

            result.Lunch = selectMeal(MealTimeOfDay.Lunch, _selectedMeals);
            timeTrace = new TimeTrace()
            {
                Week = _timeTrace.Week,
                Day = _timeTrace.Day,
                TimeOfDay = MealTimeOfDay.Lunch
            };
            result.Lunch.Trace.Add(timeTrace);           
            result.AllMeal.Add(result.Lunch);

            result.Snack2 = selectMeal(MealTimeOfDay.Snack2, _selectedMeals);
            timeTrace = new TimeTrace()
            {
                Week = _timeTrace.Week,
                Day = _timeTrace.Day,
                TimeOfDay = MealTimeOfDay.Snack2
            };
            result.Snack2.Trace.Add(timeTrace);
            result.AllMeal.Add(result.Snack2);

            result.Dinner = selectMeal(MealTimeOfDay.Dinner, _selectedMeals);
            timeTrace = new TimeTrace()
            {
                Week = _timeTrace.Week,
                Day = _timeTrace.Day,
                TimeOfDay = MealTimeOfDay.Dinner
            };
            result.Dinner.Trace.Add(timeTrace);            
            result.AllMeal.Add(result.Dinner);

            result.Calorie = addToAllCalorie(result);

            return result;
        }

        private Calorie addToAllCalorie(DailyDietPlan dailyDietPlan)
        {
            Calorie result = new Calorie(0);

            result += dailyDietPlan.Breakfast.Calorie;
            result += dailyDietPlan.Snack1.Calorie;
            result += dailyDietPlan.Lunch.Calorie;
            result += dailyDietPlan.Snack2.Calorie;
            result += dailyDietPlan.Dinner.Calorie;

            return result;
        }

        private void removeSelectedMeal(Meal selectedMeal, List<SelectedMeal> mealList)
        {
            var deletedMeals = mealList.RemoveAll(m => m.MealId == selectedMeal.MealId);
        }

        private SelectedMeal selectMeal(MealTimeOfDay mealTimeOfDay, List<SelectedMeal> mealList)
        {
            var rand = new Random();
            var timeOfDay = mealTimeOfDay.ToString();
            var calorieRange = _dailyCalorieRange[timeOfDay];
            
            var available = mealList
                .Where(m => (m.Calorie < calorieRange.High && m.Calorie > calorieRange.Low) &&
                    m.MealTimeOfDay.Any(m => m == mealTimeOfDay) && m.Trace.Count == 0);

            if (available.Count() == 0)
            {
                available = mealList
                .Where(m => (m.Calorie < calorieRange.High && m.Calorie > calorieRange.Low) &&
                    m.MealTimeOfDay.Any(m => m == mealTimeOfDay) && m.Trace.Count > 0);
            }

            var availableList = available.ToList();
            var selectedMeal = availableList[rand.Next(availableList.Count)];
            //removeSelectedMeal(selectedMeal, mealList);
            return selectedMeal;
        }
    }
}
