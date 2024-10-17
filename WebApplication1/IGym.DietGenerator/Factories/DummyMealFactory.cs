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

            var newMeal = new Meal
            {
                Name = Guid.NewGuid().ToString(),
                MealId = mealId,
                Calorie = new Calorie(rand.Next(_lowCalorie, _maxCalorie)),
                MealTimeOfDay = mealTimeOfDay,
                MealTags = conditions,
                Ingredients = generateIngredients(mealId),
                Portion = randomPortion(rand),
                ImageUrl = "https://receptneked.hu/wp-content/uploads/2015/12/ozgerinc.jpg",
                Protein = calculateProtein(rand),
                Carboydrate = calculateCarboydrate(rand),
                Fat = calcuateFat(rand),
                Rating = calcualateRating(rand),
                PreparationTime = calculatePreparationTime(rand),
                PreparationSteps = createPreparationSteps(rand)
            };

            newMeal.GlutenFree = randomGlutenOrLactoseFree(rand, newMeal);
            newMeal.LactoseFree = randomGlutenOrLactoseFree(rand, newMeal);

            return newMeal;
        }

        private IEnumerable<PreparationStep> createPreparationSteps(Random rand)
        {
            List<PreparationStep> result = new List<PreparationStep>();

            int steps = rand.Next(3, 11);

            for (int i = 0; i < steps; i++)
            {
                PreparationStep step = new PreparationStep();
                step.Number = i+1;
                step.Text = "Fusce efficitur orci eget massa efficitur, nec " +
                    "pellentesque neque molestie. Nulla vitae quam nec purus posuere bibendum. " +
                    "In vitae massa at sapien porta ullamcorper.";

                result.Add(step);
            }

            return result;
        }

        private int calculatePreparationTime(Random rand)
        {
            return rand.Next(30, 120);
        }

        private int calcualateRating(Random rand)
        {
            return rand.Next(0, 5);
        }

        private int calcuateFat(Random rand)
        {
            return rand.Next(5, 35);
        }

        private int calculateCarboydrate(Random rand)
        {
            return rand.Next(5, 35);
        }

        private int calculateProtein(Random rand)
        {
            return rand.Next(5, 35);
        }

        private bool randomGlutenOrLactoseFree(Random rand, Meal meal)
        {
            bool result = false;

            int randomCount = rand.Next(1, 5);

            if (randomCount < 1) 
            {
                return result;
            }
            else
            {
                result = true;

                foreach (var ingridient in meal.Ingredients) 
                {
                    ingridient.GlutenFree = rand.Next(1, 5) > 1 ? false : true;
                    ingridient.LactoseFree = rand.Next(1, 5) > 1 ? false : true;
                }
            }

            return result;
        }

        private int randomPortion(Random rand)
        {
            var randomInt = rand.Next(1, 10);

            if (randomInt < 5) 
            {
                return 1;
            }
            else 
            {
                return rand.Next(2, _maxPortion + 1);
            }
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
            var tags = meal.MealTags;

            for (int i = 0; i < variationCount; i++)
            {
                var newMeal = new Meal()
                {
                    Name = Guid.NewGuid().ToString(),
                    MealId = mealId,
                    Calorie = new Calorie(rand.Next(_lowCalorie, _maxCalorie)),
                    MealTimeOfDay = mealTimeOfDay,
                    MealTags = tags,
                    Ingredients = meal.Ingredients,
                    Portion = meal.Portion,
                    ImageUrl = "https://receptneked.hu/wp-content/uploads/2015/12/ozgerinc.jpg",
                    Protein = calculateProtein(rand),
                    Carboydrate = calculateCarboydrate(rand),
                    Fat = calcuateFat(rand),
                    Rating = calcualateRating(rand),
                    PreparationTime = calculatePreparationTime(rand),
                    PreparationSteps = createPreparationSteps(rand)
                };

                result.Add(newMeal);
            }

            return result;
        }

        private IEnumerable<string> loadMealOfTimeDay()
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
            var result = new List<string>();

            int howManyPieces = rand.Next(1, 5);

            for (int i = 0; i < howManyPieces; i++)
            {
                var MealTimeOfDay = mealOfTimes[rand.Next(5)];
                while (result.Any(m => m == MealTimeOfDay.ToString()))
                {
                    MealTimeOfDay = mealOfTimes[rand.Next(5)];
                }
                result.Add(MealTimeOfDay.ToString());
            }

            return result;
        }

        private IEnumerable<ExclusionCondition> loadConditions()
        {
            var conditions = new List<ExclusionCondition>();
            var repository = new DummyExclusionConditionRepository();
            var availableConditions = repository.GetAll().ToList();
            var random = new Random();
            
            var beCondition = random.Next(4);

            // no conditions
            if(beCondition == 0 || beCondition == 1)
            {
                return conditions;
            }

            // there are conditions
            if (beCondition > 1)
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
