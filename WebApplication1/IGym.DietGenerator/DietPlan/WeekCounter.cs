using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IGym.DietGenerator.DietPlan
{
    public static class WeekCounter
    {
        private static int _weekLength = 7;

        public static void SetWeekCount(IEnumerable<DailyDietPlan> dietPlans)
        {
            var dietPlanList = dietPlans.ToList();
            int weekCount = 1;
            int counter = 1;

            for (int i = 0; i < dietPlanList.Count; i++)
            {
                var dietPlan = dietPlanList[i];
                dietPlan.Week = weekCount;
                

                if (counter % _weekLength == 0)
                {
                    weekCount++;
                }

                counter++;
            }

        }
    }
}
