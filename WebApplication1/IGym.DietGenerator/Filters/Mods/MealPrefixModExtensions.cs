using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IGym.DietGenerator.Filters.Mods
{
    public static class MealPrefixModExtensions
    {
        public static IEnumerable<Meal> PrefixGlutenFree(
            this IEnumerable<Meal> mealList, 
            MealNamePrefix prefix,
            IEnumerable<ExclusionCondition> conditions
            )
        {
            if (conditions.Any(c => c.Id == 1))
            {
                foreach (var meal in mealList)
                {
                    if (meal.GlutenFree)
                    {
                        meal.Name = prefix.GetPrefix() + " " + meal.Name;

                        foreach (var ingridient in meal.Ingredients)
                        {
                            if (ingridient.GlutenFree)
                            {
                                ingridient.IngredientName = prefix.GetPrefix() + " " + ingridient.IngredientName;
                            }
                        }
                    }
                }
            }          

            return mealList;
        }

        public static IEnumerable<Meal> PrefixLactoseFree(
            this IEnumerable<Meal> mealList,
            MealNamePrefix prefix,
            IEnumerable<ExclusionCondition> conditions
            )
        {
            if (conditions.Any(c => c.Id == 1))
            {
                foreach (var meal in mealList)
                {
                    if (meal.LactoseFree)
                    {
                        meal.Name = prefix.GetPrefix() + " " + meal.Name;

                        foreach (var ingridient in meal.Ingredients)
                        {
                            if (ingridient.LactoseFree)
                            {
                                ingridient.IngredientName = prefix.GetPrefix() + " " + ingridient.IngredientName;
                            }
                        }
                    }
                }
            }


            return mealList;
        }
    }
}
