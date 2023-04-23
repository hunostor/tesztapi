using IGym.DietGenerator.Factories;
using IGym.DietGenerator.Models;
using IGym.DietGenerator.Repositories.Interfaces;
using System.Collections.Generic;

namespace IGym.DietGenerator.Repositories
{
    public class DummyIngredientRepository : IRepository<Ingredient>
    {
        public IEnumerable<Ingredient> GetAll()
        {
            var factory = new DummyFoodIngredientFactory();

            return factory.GetIngredient(200);
        }
    }
}
