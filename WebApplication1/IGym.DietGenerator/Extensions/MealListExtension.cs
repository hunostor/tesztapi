using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IGym.DietGenerator.Extensions
{
    public static class MealListExtension
    {
        public static IEnumerable<Meal> DeepClone(this IEnumerable<Meal> meals)
        {
            return meals.Select(meal => meal.Clone());
        }

        public static List<SelectedMeal> ToSelected(this IEnumerable<Meal> meals)
        {
            return meals.Select(m => m.ToSelected()).ToList();
        }
    }
}
