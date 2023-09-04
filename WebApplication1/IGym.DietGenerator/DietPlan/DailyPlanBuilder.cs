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
        private readonly List<SelectedMeal> _selectedMeals;
        private readonly DailyCalorieRange _dailyCalorieRange;
        private readonly TimeTrace _timeTrace;
        public List<SelectedMeal> MealCache { get; set; } = new List<SelectedMeal>();

        public DailyPlanBuilder(
            IEnumerable<SelectedMeal> selectedMeals,
            DailyCalorieRange dailyCalorieRange,
            TimeTrace timeTrace
            )
        {
            _selectedMeals = selectedMeals.ToList();
            _dailyCalorieRange = dailyCalorieRange;
            _timeTrace = timeTrace;
        }

        private TimeTrace setTimeTrace(TimeTrace timeTrace, MealTimeOfDay mealTimeOfDay)
        {
            var tt = new TimeTrace()
            {
                Week = timeTrace.Week,
                Day = timeTrace.Day,
                DayName = timeTrace.DayName,
                TimeOfDay = mealTimeOfDay,
                DateTime = timeTrace.DateTime,
            };

            return tt;
        }

        public DailyDietPlan Build()
        {
            var result = new DailyDietPlan();

            result.Breakfast = selectMeal(MealTimeOfDay.Breakfast, _selectedMeals);
            result.Breakfast.Trace.Add(setTimeTrace(_timeTrace, MealTimeOfDay.Breakfast));            
            result.AllMeal.Add(result.Breakfast);

            result.Snack1 = selectMeal(MealTimeOfDay.Snack1, _selectedMeals);
            result.Snack1.Trace.Add(setTimeTrace(_timeTrace, MealTimeOfDay.Snack1));
            result.AllMeal.Add(result.Snack1);

            result.Lunch = selectMeal(MealTimeOfDay.Lunch, _selectedMeals);
            result.Lunch.Trace.Add(setTimeTrace(_timeTrace, MealTimeOfDay.Lunch));
            result.AllMeal.Add(result.Lunch);

            result.Snack2 = selectMeal(MealTimeOfDay.Snack2, _selectedMeals);
            result.Snack2.Trace.Add(setTimeTrace(_timeTrace, MealTimeOfDay.Snack2));
            result.AllMeal.Add(result.Snack2);

            result.Dinner = selectMeal(MealTimeOfDay.Dinner, _selectedMeals);
            result.Dinner.Trace.Add(setTimeTrace(_timeTrace, MealTimeOfDay.Dinner));
            result.AllMeal.Add(result.Dinner);

            result.Calorie = addToAllCalorie(result);

            return result;
        }

        private int addToAllCalorie(DailyDietPlan dailyDietPlan)
        {
            Calorie result = new Calorie(0);

            result += new Calorie(dailyDietPlan.Breakfast.Calorie);
            result += new Calorie(dailyDietPlan.Snack1.Calorie);
            result += new Calorie(dailyDietPlan.Lunch.Calorie);
            result += new Calorie(dailyDietPlan.Snack2.Calorie);
            result += new Calorie(dailyDietPlan.Dinner.Calorie);

            return (int)result.Value;
        }

        private SelectedMeal selectMeal(MealTimeOfDay mealTimeOfDay, List<SelectedMeal> mealList)
        {
            // Ha van tobb adagos kaja, akkor azt kell betenni, nincsen valasztas
            // todo finomitani kell, mi van ha az etel tobbadagos nem csak ketto
            if (MealCache.Any(m => m.Trace.Any(t => t.TimeOfDay == mealTimeOfDay))) 
            {
                var portionMeal = MealCache.Single(m => m.Trace.Any(t => t.TimeOfDay == mealTimeOfDay));
                // torolni a felhasznalt meal-t
                MealCache.Remove(portionMeal);
                return portionMeal;
            }


            var rand = new Random();
            var timeOfDay = mealTimeOfDay.ToString();
            var calorieRange = _dailyCalorieRange[timeOfDay];
            
            var available = mealList
                .Where(m => (m.Calorie < calorieRange.High.Value && m.Calorie > calorieRange.Low.Value) &&
                    m.MealTimeOfDay.Any(m => m == mealTimeOfDay) && m.Trace.Count == 0);

            if (available.Count() == 0)
            {
                available = mealList
                .Where(m => (m.Calorie < calorieRange.High.Value && m.Calorie > calorieRange.Low.Value) &&
                    m.MealTimeOfDay.Any(m => m == mealTimeOfDay) && m.Trace.Count > 0);
            }

            var availableList = available.ToList();
            var selectedMeal = availableList[rand.Next(availableList.Count)];

            // tobb adagos kajak mentese ide
            if (selectedMeal.Portion > 1) 
            {
                MealCache.Add(selectedMeal);
            }

            return selectedMeal;
        }
    }
}
