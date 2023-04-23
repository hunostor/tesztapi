using IGym.DietGenerator.CalorieCalculator;
using IGym.DietGenerator.CalorieCalculator.Interfaces;
using IGym.DietGenerator.DietPlan;
using IGym.DietGenerator.DietPlan.CalorieAllocation;
using IGym.DietGenerator.Models;
using IGym.DietGenerator.Repositories.Interfaces;
using IGym.DietGenerator.Req;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IGym.DietGenerator
{
    /// <summary>
    /// Összetevők esetén két választási lehetőség
    /// összetevőhöz kötelezően előírt mértékegység pl. minden esetben gramm
    /// és akkor a bevásárlólistánál is szépen grammra megmondjuk mennyit kell vennie
    /// 
    /// vagy a mostani megoldás az, hogy a recepthez alkalmazkodva adja a mértékegységet
    /// ebben az esetben viszont kijöhet az, hogy pl. az egyik receptnél az étrendben 1 kanál liszt van
    /// a másik receptben 200 gramm liszt van, ebben az esetben a bevásárló listán nem vonható össze a kettő
    /// tétel és kb. így szerepelne, hogy "liszt 200 gramm"
    ///                                   "liszt 3 evőkanál"
    ///                    
    /// 
    /// pl. só kizárása a bevásárló listából? mert olyan termék amiből csak kevés kell és
    /// mindenkinek van otthon, fura lenne, ha a bevásárló lista tartalmazna ilyen tételt
    /// hogy "só 1.5 gramm"
    /// 
    /// 
    /// 
    /// étel tag-s, nál nem csak kizáró pl. "mogyoróallergia" feltétleek vannak, 
    /// hanem befogalók is tehát pl. "vegán" máshogy kell vele eljárni.
    /// </summary>
    public class DietCalculator
    {
        private readonly ICalorieCalculator _calorieCalculator;
        private readonly IRepository<Meal> _mealRepository;
        private readonly CallorieAllocationHandler _callorieAllocation;

        public DietCalculator(
            ICalorieCalculator calorieCalculator, 
            IRepository<Meal> mealRepository, 
            CallorieAllocationHandler callorieAllocation
            )
        {
            _calorieCalculator = calorieCalculator;
            _mealRepository = mealRepository;
            _callorieAllocation = callorieAllocation;
        }

        public GeneratedDietPlan Calculate(Request request)
        {
            var allMeal = _mealRepository.GetAll();

            var dailyCalorie = _calorieCalculator.CalculateDaliyCalorie(request);
            var calorieRange = _callorieAllocation.Calculate(dailyCalorie);
            var builder = new MonthlyDietPlanBuilder(allMeal, dailyCalorie, calorieRange);
            var dietPlan = builder.Build();
            
            
            var result = new GeneratedDietPlan();
            result.Request = request;
            result.Diet = dietPlan;
            result.Timestamp = DateTime.UtcNow;
            result.ShoppingList = generateShoppingList(dietPlan);

            return result;
        }

        private ShoppingList generateShoppingList(MonthlyDietPlan monthlyDietPlan)
        {
            var result = new ShoppingList();
            // monthly
            generateMonthlyList(result, monthlyDietPlan);
            generateFirstWeek(result, monthlyDietPlan);
            generateSecondWeek(result, monthlyDietPlan);
            generateThirdWeek(result, monthlyDietPlan);
            generateFourhtWeek(result, monthlyDietPlan);

            return result;
        }

        private void generateFourhtWeek(ShoppingList result, MonthlyDietPlan monthlyDietPlan)
        {
            foreach (var meal in monthlyDietPlan.FourhtWeek.AllMeal)
            {
                foreach (var mealIngredient in meal.Ingredients)
                {
                    if (result.FourhtWeek.Any(x => x.IngredientId == mealIngredient.IngredientId))
                    {
                        var ing = result.FourhtWeek.Single(x => x.IngredientId == mealIngredient.IngredientId);
                        ing.Quantity = ing.Quantity + mealIngredient.Quantity;
                    }
                    else
                    {
                        var shoppingListIngredient = new ShoppingListIngredient();
                        shoppingListIngredient.IngredientId = mealIngredient.IngredientId;
                        shoppingListIngredient.IngredientName = mealIngredient.IngredientName;
                        shoppingListIngredient.Unit = mealIngredient.Unit;
                        shoppingListIngredient.Quantity = mealIngredient.Quantity;

                        result.FourhtWeek.Add(shoppingListIngredient);
                    }
                }
            }
        }

        private void generateThirdWeek(ShoppingList result, MonthlyDietPlan monthlyDietPlan)
        {
            foreach (var meal in monthlyDietPlan.ThirdWeek.AllMeal)
            {
                foreach (var mealIngredient in meal.Ingredients)
                {
                    if (result.ThirdWeek.Any(x => x.IngredientId == mealIngredient.IngredientId))
                    {
                        var ing = result.ThirdWeek.Single(x => x.IngredientId == mealIngredient.IngredientId);
                        ing.Quantity = ing.Quantity + mealIngredient.Quantity;
                    }
                    else
                    {
                        var shoppingListIngredient = new ShoppingListIngredient();
                        shoppingListIngredient.IngredientId = mealIngredient.IngredientId;
                        shoppingListIngredient.IngredientName = mealIngredient.IngredientName;
                        shoppingListIngredient.Unit = mealIngredient.Unit;
                        shoppingListIngredient.Quantity = mealIngredient.Quantity;

                        result.ThirdWeek.Add(shoppingListIngredient);
                    }
                }
            }
        }

        private void generateSecondWeek(ShoppingList result, MonthlyDietPlan monthlyDietPlan)
        {
            foreach (var meal in monthlyDietPlan.SecondWeek.AllMeal)
            {
                foreach (var mealIngredient in meal.Ingredients)
                {
                    if (result.SecondWeek.Any(x => x.IngredientId == mealIngredient.IngredientId))
                    {
                        var ing = result.SecondWeek.Single(x => x.IngredientId == mealIngredient.IngredientId);
                        ing.Quantity = ing.Quantity + mealIngredient.Quantity;
                    }
                    else
                    {
                        var shoppingListIngredient = new ShoppingListIngredient();
                        shoppingListIngredient.IngredientId = mealIngredient.IngredientId;
                        shoppingListIngredient.IngredientName = mealIngredient.IngredientName;
                        shoppingListIngredient.Unit = mealIngredient.Unit;
                        shoppingListIngredient.Quantity = mealIngredient.Quantity;

                        result.SecondWeek.Add(shoppingListIngredient);
                    }
                }
            }
        }

        private void generateFirstWeek(ShoppingList result, MonthlyDietPlan monthlyDietPlan)
        {
            foreach (var meal in monthlyDietPlan.FirstWeek.AllMeal)
            {
                foreach (var mealIngredient in meal.Ingredients)
                {
                    if (result.FirstWeek.Any(x => x.IngredientId == mealIngredient.IngredientId))
                    {
                        var ing = result.FirstWeek.Single(x => x.IngredientId == mealIngredient.IngredientId);
                        ing.Quantity = ing.Quantity + mealIngredient.Quantity;
                    }
                    else
                    {
                        var shoppingListIngredient = new ShoppingListIngredient();
                        shoppingListIngredient.IngredientId = mealIngredient.IngredientId;
                        shoppingListIngredient.IngredientName = mealIngredient.IngredientName;
                        shoppingListIngredient.Unit = mealIngredient.Unit;
                        shoppingListIngredient.Quantity = mealIngredient.Quantity;

                        result.FirstWeek.Add(shoppingListIngredient);
                    }
                }
            }
        }

        private void generateMonthlyList(ShoppingList result, MonthlyDietPlan monthlyDietPlan)
        {
            foreach (var meal in monthlyDietPlan.AllMeal)
            {
                foreach (var mealIngredient in meal.Ingredients)
                {
                    if (result.Monthly.Any(x => x.IngredientId == mealIngredient.IngredientId))
                    {
                        var ing = result.Monthly.Single(x => x.IngredientId == mealIngredient.IngredientId);
                        ing.Quantity = ing.Quantity + mealIngredient.Quantity;
                    }
                    else
                    {
                        var shoppingListIngredient = new ShoppingListIngredient();
                        shoppingListIngredient.IngredientId = mealIngredient.IngredientId;
                        shoppingListIngredient.IngredientName = mealIngredient.IngredientName;
                        shoppingListIngredient.Unit = mealIngredient.Unit;
                        shoppingListIngredient.Quantity = mealIngredient.Quantity;

                        result.Monthly.Add(shoppingListIngredient);
                    }
                }
            }
        }
    }
}
