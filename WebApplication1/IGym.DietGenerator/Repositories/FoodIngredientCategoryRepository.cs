using IGym.DietGenerator.Models;
using IGym.DietGenerator.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IGym.DietGenerator.Repositories
{
    public class FoodIngredientCategoryRepository : IRepository<FoodIngredientCategory>
    {
        private List<FoodIngredientCategory> _foodIngredientCategories = new List<FoodIngredientCategory> 
        {
            new FoodIngredientCategory()
            {
                Id = 0,
                Name = "Gabonák, magvak és termékeik"
            },
            new FoodIngredientCategory()
            {
                Id = 1,
                Name = "Zöldség- és főzelékfélék"
            },
            new FoodIngredientCategory()
            {
                Id = 2,
                Name = "Gombák, gombakészítmények"
            },
            new FoodIngredientCategory()
            {
                Id = 3,
                Name = "Gyümölcsök"
            },
            new FoodIngredientCategory()
            {
                Id = 4,
                Name = "Diófélék, olajos magvak"
            },
            new FoodIngredientCategory()
            {
                Id = 5,
                Name = "Növényi olajok, zsiradékok"
            },
            new FoodIngredientCategory()
            {
                Id = 6,
                Name = "Húsok és vágóhídi termékek"
            },
            new FoodIngredientCategory()
            {
                Id = 7,
                Name = "Gabonák, magvak és termékeik"
            },
            new FoodIngredientCategory()
            {
                Id = 8,
                Name = "Halak és halkészítmények"
            },
            new FoodIngredientCategory()
            {
                Id = 9,
                Name = "Tej és tejtermékek"
            },
            new FoodIngredientCategory()
            {
                Id = 10,
                Name = "Tojás"
            },
            new FoodIngredientCategory()
            {
                Id = 11,
                Name = "Édességek, sütemények, tészták"
            },
            new FoodIngredientCategory()
            {
                Id = 12,
                Name = "Készételek"
            },
            new FoodIngredientCategory()
            {
                Id = 13,
                Name = "Italok"
            },
            new FoodIngredientCategory()
            {
                Id = 14,
                Name = "Egyéb"
            },
        };

        public IEnumerable<FoodIngredientCategory> GetAll()
        {
            return _foodIngredientCategories;
        }

        public FoodIngredientCategory Random()
        {
            var random = new Random();
            var count = random.Next(1, _foodIngredientCategories.Count);
            return _foodIngredientCategories.Single(c => c.Id == count);
        }
    }
}
