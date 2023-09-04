using IGym.DietGenerator.Enums;
using IGym.DietGenerator.Models;
using IGym.DietGenerator.Models.Switches;
using IGym.DietGenerator.Models.Wrappers;
using IGym.DietGenerator.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IGym.DietGenerator.Factories
{
    public class DummyMealFactory
    {
        private readonly int _conditionsCount = 1;

        private readonly int _lowCalorie = 150;
        private readonly int _maxCalorie = 1250;

        private readonly int _maxPortion = 4;

        public IEnumerable<Meal> GetMeals(int count)
        {
            var result = new List<Meal>();
            var rand = new Random();

            for (int i = 0; i < count; i++)
            {
                var newMeal = generateMeal();
                var newMeals = generateMealVariations(newMeal, rand.Next(1, 5));

                result.Add(newMeal);
                result.AddRange(newMeals);
            }
            
            return result;
        }

        private Meal generateMeal()
        {            
            var rand = new Random();
            string mealId = Guid.NewGuid().ToString();
            var mealTimeOfDay = loadMealOfTimeDay();
            var conditions = loadConditions();

            return new Meal
            {
                Name = Guid.NewGuid().ToString(),
                MealId = mealId,
                Calorie = new Calorie(rand.Next(_lowCalorie, _maxCalorie)),
                MealTimeOfDay = mealTimeOfDay,
                MealTags = conditions,
                Ingredients = generateIngredients(mealId),
                Portion = rand.Next(1, _maxPortion+1),
            };
        }

        private IEnumerable<MealIngredient> generateIngredients(string mealId)
        {
            var result = new List<MealIngredient>();

            var random = new Random();
            var ingredientsRepo = new DummyIngredientRepository();
            var ingredientList = ingredientsRepo.GetAll().ToList();

            int ingCount = random.Next(3, 11);

            for (int i = 0; i < ingCount; i++)
            {
                var ingrident = ingredientList[random.Next(ingredientList.Count())];


                var mealIng = new MealIngredient();
                mealIng.IngredientId = ingrident.Id;
                mealIng.IngredientName = ingrident.Name;
                mealIng.Quantity = random.Next(1, 25);
                mealIng.Unit = ingrident.Unit;
                mealIng.CategoryId = ingrident.CategoryId;
                mealIng.CategoryName = ingrident.CategoryName;
                result.Add(mealIng);
            }

            return result;
        }

        private IEnumerable<Meal> generateMealVariations(Meal meal, int variationCount)
        {
            var result = new List<Meal>();
            var rand = new Random();

            string mealId = meal.MealId;
            var mealTimeOfDay = meal.MealTimeOfDay;
            var conditions = meal.MealTags;

            for (int i = 0; i < variationCount; i++)
            {
                var newMeal = new Meal()
                {
                    Name = Guid.NewGuid().ToString(),
                    MealId = mealId,
                    Calorie = new Calorie(rand.Next(_lowCalorie, _maxCalorie)),
                    MealTimeOfDay = mealTimeOfDay,
                    MealTags = conditions,
                    Ingredients = meal.Ingredients,
                    Portion = meal.Portion,
                };

                result.Add(newMeal);
            }

            return result;
        }

        private IEnumerable<MealTimeOfDay> loadMealOfTimeDay()
        {
            var mealOfTimes = new List<MealTimeOfDay>()
            {
                MealTimeOfDay.Breakfast,
                MealTimeOfDay.Snack1,
                MealTimeOfDay.Lunch,
                MealTimeOfDay.Snack2,
                MealTimeOfDay.Dinner
            };

            var rand = new Random();
            var result = new List<MealTimeOfDay>();

            int howManyPieces = rand.Next(1, 5);

            for (int i = 0; i < howManyPieces; i++)
            {
                var MealTimeOfDay = mealOfTimes[rand.Next(5)];
                while (result.Any(m => m == MealTimeOfDay))
                {
                    MealTimeOfDay = mealOfTimes[rand.Next(5)];
                }
                result.Add(MealTimeOfDay);
            }

            return result;
        }

        private IEnumerable<ExclusionCondition> loadConditions()
        {
            var conditions = new List<ExclusionCondition>();
            var repository = new DummyExclusionConditionRepository();
            var availableConditions = repository.GetAll().ToList();
            var random = new Random();
            
            var beCondition = random.Next(2);

            // no conditions
            if(beCondition == 0 || beCondition == 1)
            {
                return conditions;
            }

            // there are conditions
            if (beCondition == 2)
            {
                for (int i = 0; i < this._conditionsCount; i++)
                {
                    conditions.Add(availableConditions[random.Next(availableConditions.Count)]);
                    return conditions;
                }

            }

            return conditions;
        }


    }
}
