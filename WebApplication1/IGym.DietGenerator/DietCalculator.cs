using IGym.DietGenerator.CalorieCalculator;
using IGym.DietGenerator.CalorieCalculator.Interfaces;
using IGym.DietGenerator.DietPlan;
using IGym.DietGenerator.DietPlan.CalorieAllocation;
using IGym.DietGenerator.DietPlan.Ingredients;
using IGym.DietGenerator.DietPlan.TimeOfDays;
using IGym.DietGenerator.Enums;
using IGym.DietGenerator.Extensions;
using IGym.DietGenerator.Filters;
using IGym.DietGenerator.Filters.Mods;
using IGym.DietGenerator.Models;
using IGym.DietGenerator.Models.Values;
using IGym.DietGenerator.Repositories.Interfaces;
using IGym.DietGenerator.Req;
using IGym.DietGenerator.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace IGym.DietGenerator
{
    public class DietCalculator
    {
        private readonly ICalorieCalculator _calorieCalculator;
        private readonly IRepository<Meal> _mealRepository;
        private readonly CallorieAllocationHandler _callorieAllocation;
        private readonly MealFilterWrapper _mealFilterWrapper;
        private readonly int _dayCount = 28;

        public DietCalculator(
            ICalorieCalculator calorieCalculator, 
            IRepository<Meal> mealRepository, 
            CallorieAllocationHandler callorieAllocation,
            MealFilterWrapper mealFilterWrapper
            )
        {
            _calorieCalculator = calorieCalculator;
            _mealRepository = mealRepository;
            _callorieAllocation = callorieAllocation;
            _mealFilterWrapper = mealFilterWrapper;
        }

        public GeneratedDietPlan Calculate(Request request)
        {
            var result = new GeneratedDietPlan();
            var allMeal = _mealRepository.GetAll();

            // filter
            allMeal = _mealFilterWrapper.ExclusionConditionFilter.Action(request.ExclusionConditions, allMeal);
            // mods
            var prefixGlutenFree = new MealNamePrefix("Gluténmentes");
            var prefixLactoseFree = new MealNamePrefix("Laktózmentes");
            allMeal = allMeal.PrefixGlutenFree(prefixGlutenFree, request.ExclusionConditions);
            allMeal = allMeal.PrefixGlutenFree(prefixLactoseFree, request.ExclusionConditions);

            var dailyCalorie = _calorieCalculator.CalculateDaliyCalorie(request);
            var calorieRange = _callorieAllocation.Calculate(dailyCalorie);
            
            var createDietResult = createDiet(allMeal, calorieRange, request.StartDay, _dayCount);
            
            result.StartDay = request.StartDay;
            result.Request = request;
            result.Diet = createDietResult.ToList();
            result.AllMeal = generateAllMeal(createDietResult.ToList());
            result.Timestamp = DateTime.UtcNow;

            // load all meal
            //foreach (var dailyPlan in result.Diet)
            //{
            //    result.AllMeal.AddRange(dailyPlan.Meals);
            //}

            ShoppingList shoppingList = generateShoppingList(createDietResult);
            // monthly
            generateMonthlyList(shoppingList, result.AllMeal);

            // generate categoryzed shopping list
            // one week
            ShoppingListResponseItem cIOne = categoryzedIngredients(shoppingList.FirstWeek, request.StartDay, 6);
            ShoppingListResponseItem cITwo = categoryzedIngredients(shoppingList.SecondWeek, cIOne.End, 7);
            ShoppingListResponseItem cIThree = categoryzedIngredients(shoppingList.ThirdWeek, cITwo.End, 7);
            ShoppingListResponseItem cIFouth = categoryzedIngredients(shoppingList.FourhtWeek, cIThree.End, 7);

            result.ShoppingList.Weeks.Add(cIOne);
            result.ShoppingList.Weeks.Add(cITwo);
            result.ShoppingList.Weeks.Add(cIThree);
            result.ShoppingList.Weeks.Add(cIFouth);

            return result;
        }

        private ShoppingList generateShoppingList(IEnumerable<DailyDietPlan> createDietResult)
        {
            var result = new ShoppingList();

            var dietWeekGroups = createDietResult.GroupBy(d => d.Week);

            foreach (var dietWeek in dietWeekGroups)
            {
                var meals = new List<SelectedMeal>();
                foreach (var dailyPlan in dietWeek)
                {
                    meals.AddRange(dailyPlan.Meals);
                }
                generateWeekShoppingList(result, meals, dietWeek.Key);
            }

            return result;
        }

        //private List<WeekIngredientList> generateIngredientsByWeeks(IEnumerable<DailyIngridientList> ingredientLists)
        //{
        //    // todo heti bontas hogy allithato elo, ha nincsen kezenfekvo adat hozza?
        //    // todo ingredients by weeks
        //    var result = new List<WeekIngredientList>();
        //    //var groupByWeeks = ingredientLists.GroupBy(i => i.)

        //    foreach (var dailyIngredientList in ingredientLists)
        //    {
                
        //    }

        //    return result;
        //}

        //private ShoppingList generateShoppingList(GeneratedDietPlan dietPlan)
        //{
        //    var result = new ShoppingList();

        //    // monthly
        //    generateMonthlyList(result, dietPlan.AllMeal);

        //    var dietWeekGroups = dietPlan.Diet.GroupBy(d => d.Week);

        //    foreach (var dietWeek in dietWeekGroups)
        //    {
        //        var meals = new List<SelectedMeal>();
        //        foreach (var dailyPlan in dietWeek) 
        //        {
        //            meals.AddRange(dailyPlan.Meals);                    
        //        }
        //        generateWeekShoppingList(result, meals, dietWeek.Key);
        //    }                       

        //    return result;
        //}

        private void generateWeekShoppingList(ShoppingList result, List<SelectedMeal> meals, int weekCount)
        {
            var weekIngredients = new List<MealIngredient>();
            var weekShoppingList = new WeekShoppingList(weekCount);

            foreach (var meal in meals)
            {
                weekIngredients.AddRange(meal.Ingredients);
                var weekIngredientsGroup = weekIngredients.GroupBy(i => i.IngredientId);

                foreach (var ingredientGroup in weekIngredientsGroup)
                {
                    var shoppingListIngredient = new ShoppingListIngredient();
                    shoppingListIngredient.IngredientId = ingredientGroup.First().IngredientId;
                    shoppingListIngredient.IngredientName = ingredientGroup.First().IngredientName;
                    shoppingListIngredient.Unit = ingredientGroup.First().Unit;
                    shoppingListIngredient.Quantity = ingredientGroup.First().Quantity;
                    shoppingListIngredient.CategoryId = ingredientGroup.First().CategoryId;
                    shoppingListIngredient.CategoryName = ingredientGroup.First().CategoryName;

                    weekShoppingList.IngredientList.Add(shoppingListIngredient);
                }

                result.List.Add(weekShoppingList);
            }
        }

        private List<SelectedMeal> generateAllMeal(List<DailyDietPlan> dayList)
        {
            var result = new List<SelectedMeal>();

            foreach (var day in dayList) 
            {
                result.AddRange(day.Meals);
            }

            return result;
        }

        private IEnumerable<DailyDietPlan> createDiet(
            IEnumerable<Meal> allMeals, DailyCalorieRange dailyCalorieRange, DateTime startDay, int dayCount)
        {
            var cultureInfo = new CultureInfo("hu-HU");
            var dietPlanDateHandler = new DietPlanDateHandler(cultureInfo);
            var fiveMealTimeOfDay = new FiveMealTimeOfDay(new List<string>() 
            {"Breakfast", "Snack1", "Lunch", "Snack2", "Dinner"});
            var mealDistributor = new DietPlanMealDistributor(allMeals.ToSelected(), dailyCalorieRange, fiveMealTimeOfDay);

            List<DailyDietPlan> dietPlan = EmptyDietPlanCreator.Create(new DietPlanLength(_dayCount));
            DietPlanBulletNumberHandler.SetBulletNumber(dietPlan);
            dietPlanDateHandler.Set(dietPlan, new DietStartDay(startDay.Year, startDay.Month, startDay.Day));
            WeekCounter.SetWeekCount(dietPlan);
            mealDistributor.Fill(dietPlan);
                DailyIngredientListCreator.Create(dietPlan, cultureInfo);

            SumCalorieCalculator.DailyCalc(dietPlan);

            return dietPlan;
        }

        private ShoppingListResponseItem categoryzedIngredients(IList<ShoppingListIngredient> oneWeek, DateTime startDay, int addDays)
        {
            // start and end date
            var result = new ShoppingListResponseItem();
            var endDate = startDay.AddDays(addDays);
            result.Start = startDay;
            result.End = endDate;

            var categoryGroups1 = oneWeek.GroupBy(x => new FoodIngredientCategory { Id = x.CategoryId, Name = x.CategoryName});
            var categoryGroups = oneWeek.GroupBy(x => new { x.CategoryId, x.CategoryName } );

            foreach ( var group in categoryGroups) 
            {
                var category = new ShoppingListCategory();
                category.CategoryId = group.Key.CategoryId;
                category.CategoryName = group.Key.CategoryName;
                category.Items = group.ToList();

                result.Categories.Add(category);
            }

            return result;
        }       

        private void generateMonthlyList(ShoppingList result, List<SelectedMeal> allMeal)
        {
            foreach (var meal in allMeal)
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
                        shoppingListIngredient.CategoryId = mealIngredient.CategoryId;
                        shoppingListIngredient.CategoryName = mealIngredient.CategoryName;

                        result.Monthly.Add(shoppingListIngredient);
                    }
                }
            }
        }
    }
}
