using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.DietPlan
{
    public class SumCalorieCalculator
    {
        public static void DailyCalc(IEnumerable<DailyDietPlan> DailyDietPlan)
        {
            foreach (var item in DailyDietPlan)
            {
                foreach (var meal in item.Meals)
                {
                    item.Calorie = item.Calorie + meal.Calorie;
                }
            }
        }
    }
}
