using IGym.DietGenerator.CalorieCalculator;
using IGym.DietGenerator.DietPlan.CalorieAllocation;
using IGym.DietGenerator.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator
{
    public class DietCalculatorBuilder
    {
        public DietCalculator Build(Config config, int dummyMealCount)
        {
            var calorieCalculator = new HumanDailyCalorieRequirementCalculator();
            DietCalculator dietCalculator = new DietCalculator(
                calorieCalculator,
                new DummyMealRepository(dummyMealCount),
                new CallorieAllocationHandler()
                );




            return dietCalculator;
        }
    }
}
