using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace IGym.DietGenerator.DietPlan.Ingredients
{
    public static class DailyIngredientListCreator
    {
        public static void Create(List<DailyDietPlan> dailyDietPlanList, CultureInfo cultureInfo)
        {

            foreach (var dailyDietPlan in dailyDietPlanList)
            {
                var ingredientList = new DailyIngridientList(new IngridientListForShopping())
                {
                    Day = dailyDietPlan.Day
                };

                foreach (var meal in dailyDietPlan.Meals)
                {
                    if (meal is SelectedMeal)
                    {
                        ingredientList.Add(meal);

                    }                   
                }

                dailyDietPlan.Ingridients = ingredientList;
            }
        }
    }
}
