using IGym.DietGenerator.Models.Values;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace IGym.DietGenerator.DietPlan
{
    public static class EmptyDietPlanCreator
    {
        public static List<DailyDietPlan> Create(DietPlanLength length)
        {
            var result = new List<DailyDietPlan>();

            for(int i = 0; i < length.Value; i++)
            {
                var plan = new DailyDietPlan();
                result.Add(plan);
            }

            return result;
        }
    }
}
