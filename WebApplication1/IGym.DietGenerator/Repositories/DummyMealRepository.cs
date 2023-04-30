using IGym.DietGenerator.Enums;
using IGym.DietGenerator.Factories;
using IGym.DietGenerator.Models;
using IGym.DietGenerator.Models.Interfaces;
using IGym.DietGenerator.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Repositories
{
    public class DummyMealRepository : Interfaces.IRepository<Meal>
    {        
        private int _generatedMealCount = 0;

        public DummyMealRepository(int generatedMealCount)
        {
            _generatedMealCount = generatedMealCount;
        }

        public IEnumerable<Meal> GetAll()
        {
            var factory = new DummyMealFactory();

            return factory.GetMeals(_generatedMealCount);
        }
    }
}
