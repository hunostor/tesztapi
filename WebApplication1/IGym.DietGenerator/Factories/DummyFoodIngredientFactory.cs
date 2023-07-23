using IGym.DietGenerator.Enums;
using IGym.DietGenerator.Models;
using IGym.DietGenerator.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Factories
{
    public class DummyFoodIngredientFactory
    {
        public IEnumerable<Ingredient> GetIngredient(int count)
        {
            var categoryRepo = new FoodIngredientCategoryRepository();
            
            var result = new List<Ingredient>();

            for (int i = 1; i < count+1; i++)
            {
                var category = categoryRepo.Random();
                var ingredient = new Ingredient()
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString(),
                    Unit = selectMeasurementsUnit(),
                    CategoryId = category.Id,
                    CategoryName = category.Name,
                };

                result.Add(ingredient);
            }

            return result;
        }

        private UnitOfMeasurements selectMeasurementsUnit()
        {
            var random = new Random();
            Array values = Enum.GetValues(typeof(UnitOfMeasurements));
            return (UnitOfMeasurements)values.GetValue(random.Next(values.Length));
        }
    }
}
