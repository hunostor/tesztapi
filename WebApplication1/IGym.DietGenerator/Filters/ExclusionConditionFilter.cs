using IGym.DietGenerator.Models;
using IGym.DietGenerator.Req;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IGym.DietGenerator.Filters
{
    public class ExclusionConditionFilter
    {
        public IEnumerable<Meal> Action(IEnumerable<ExclusionCondition> conditions, IEnumerable<Meal> meals)
        {
            var result = new List<Meal>();

            var conditionList = conditions.ToList();

            foreach (var meal in meals)
            {
                // no condition
                if (meal.MealTags.Count() == 0)
                {
                    result.Add(meal);
                    continue;
                }

                // has condtion
                if (ifInExclusions(conditionList, meal))
                {
                    continue;
                }

                result.Add(meal);
            }


            return result;
        }

        private bool ifInExclusions(IEnumerable<ExclusionCondition> exclusions, Meal meal)
        {
            foreach (var exclusion in exclusions)
            {
                if (meal.MealTags.Any(t => t.Id == exclusion.Id))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
