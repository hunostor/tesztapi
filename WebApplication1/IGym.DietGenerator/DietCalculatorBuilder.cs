using IGym.DietGenerator.CalorieCalculator;
using IGym.DietGenerator.DietPlan.CalorieAllocation;
using IGym.DietGenerator.Filters;
using IGym.DietGenerator.Models;
using IGym.DietGenerator.Repositories;
using IGym.DietGenerator.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator
{
    public class DietCalculatorBuilder
    {
        private readonly IRepository<Meal> _mealRepository;
        private readonly MealFilterWrapper _mealFilterWrapper;

        public DietCalculatorBuilder(IRepository<Meal> mealRepository, MealFilterWrapper mealFilterWrapper)
        {
            _mealRepository = mealRepository;
            _mealFilterWrapper = mealFilterWrapper;
        }

        public DietCalculator Build(Config config)
        {
            var calorieCalculator = new HumanDailyCalorieRequirementCalculator();
            DietCalculator dietCalculator = new DietCalculator(
                calorieCalculator,
                _mealRepository,
                new CallorieAllocationHandler(),
                _mealFilterWrapper
                );




            return dietCalculator;
        }
    }
}
