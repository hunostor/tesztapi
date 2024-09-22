using IGym.DietGenerator.DietPlan.CalorieAllocation;
using IGym.DietGenerator.DietPlan.TimeOfDays;
using IGym.DietGenerator.Enums;
using IGym.DietGenerator.Extensions;
using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IGym.DietGenerator.DietPlan
{
    public class DietPlanMealDistributor
    {
        private readonly List<SelectedMeal> _selectedMeals;
        private readonly DailyCalorieRange _dailyCalorieRange;
        private readonly TimeOfDays.MealTimeOfDay _mealTimeOfDay;
        private readonly int _weekLength = 7;

        public DietPlanMealDistributor(
            IEnumerable<SelectedMeal> selectedMeals,
            DailyCalorieRange dailyCalorieRange,
            TimeOfDays.MealTimeOfDay mealTimeOfDay
            )
        {
            _selectedMeals = selectedMeals.ToList();
            _dailyCalorieRange = dailyCalorieRange;
            _mealTimeOfDay = mealTimeOfDay;
        }

        public void Fill(List<DailyDietPlan> dailyDietPlans)
        {
            var rand = new Random();

            for (int i = 0; i < dailyDietPlans.Count; i++)
            {                
                DailyDietPlan currentPlan = dailyDietPlans[i];
                //WeekIngredientList currentWeekIngredientList = ingredientLists.Single(il => il.Week == currentPlan.Week);

                foreach (string mealTimeOfDay in _mealTimeOfDay.Items)
                {
                    // ha be van töltve a planba egy étel erre az időpontra, akkor az többadagos étel
                    // nem kell csinálni semmit, tovább kell lépni
                    var select = currentPlan.Meals.Any(m =>
                        m.Trace.Any(t => t.TimeOfDay == mealTimeOfDay && t.DateTime == currentPlan.Day.Date));
                    if (select)
                    {
                        continue;
                    };

                    var calorieRange = _dailyCalorieRange[mealTimeOfDay];

                    // melyik ételek nem voltak még felhasználva korábbi napokon 
                    var available = _selectedMeals
                        .Where(m => (m.Calorie < calorieRange.High.Value && m.Calorie > calorieRange.Low.Value) &&
                            m.MealTimeOfDay.Any(m => m == mealTimeOfDay) && m.Trace.Count == 0);

                    // ha nincsen ilyen étel, akkor azokat rendezi listába, amelyek korábban már választva voltak
                    if (available.Count() == 0)
                    {
                        available = _selectedMeals
                        .Where(m => (m.Calorie < calorieRange.High.Value && m.Calorie > calorieRange.Low.Value) &&
                            m.MealTimeOfDay.Any(m => m == mealTimeOfDay) && m.Trace.Count > 0);
                    }
                    var availableList = available.ToList();

                    // kiválasztja az ételt
                    var selectedMeal = availableList[rand.Next(availableList.Count)];

                    // ha az étel többadagos
                    if (selectedMeal.Portion > 1)
                    {
                        // elore hozzadjuk a kovetkezo napokhoz a tobbadagos eteleket
                        for (int y = 0; y < selectedMeal.Portion; y++)
                        {
                            // nincsennek olyan napok amihez hozzá lehetne adni, mert a nap lista vége felé jár
                            int dietPlansCounter = i + y;
                            if (dailyDietPlans.Count <= dietPlansCounter)
                            {
                                dietPlansCounter = i + 1;
                                continue;
                            }

                            var selectedPlan = dailyDietPlans[dietPlansCounter];
                            var currentTimeTrace = new TimeTrace()
                            {
                                Week = 1,
                                DateTime = selectedPlan.Day.Date,
                                DayName = selectedPlan.Day.Name,
                                TimeOfDay = mealTimeOfDay
                            };
                            selectedMeal.Trace.Add(currentTimeTrace);
                            

                            // a legelso maradjon SelectedMeal
                            // a tobbi viszont legyen PreparedMeal
                            if (y == 0)
                            {
                                selectedPlan.Meals.Add(selectedMeal);
                            }
                            else
                            {
                                var preparedMeal = selectedMeal.ToPrepared(selectedMeal, selectedMeal.Portion - y);
                                selectedPlan.Meals.Add(preparedMeal);
                            }
                        }
                    }
                    else
                    {
                        // add TimeTrace for SelectedMeal
                        var timeTrace = new TimeTrace()
                        {
                            Week = 1,
                            DateTime = currentPlan.Day.Date,
                            DayName = currentPlan.Day.Name,
                            TimeOfDay = mealTimeOfDay
                        };

                        selectedMeal.Trace.Add(timeTrace);

                        // add SelectedMeal for Daily Meal List
                        currentPlan.Meals.Add(selectedMeal);
                    }                    
                }
            }
        }
    }
}
