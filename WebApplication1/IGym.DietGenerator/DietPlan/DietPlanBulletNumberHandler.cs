using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.DietPlan
{
    public static class DietPlanBulletNumberHandler
    {
        public static void SetBulletNumber(List<DailyDietPlan> dailyDietPlans)
        {
            for (int i = 1; i < dailyDietPlans.Count; i++)             
            {
                var plan = dailyDietPlans[i];
                plan.BulletNumber = i;
            }
        }
    }
}
