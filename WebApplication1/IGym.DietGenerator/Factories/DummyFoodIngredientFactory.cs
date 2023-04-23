using IGym.DietGenerator.Enums;
using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Factories
{
    public class DummyFoodIngredientFactory
    {
        public IEnumerable<Ingredient> GetIngredient(int count)
        {
            var result = new List<Ingredient>();

            for (int i = 1; i < count+1; i++)
            {
                var ingredient = new Ingredient()
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString(),
                    Unit = selectMeasurementsUnit()
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
