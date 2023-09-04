using IGym.DietGenerator.CalorieCalculator;
using IGym.DietGenerator.CalorieCalculator.Interfaces;
using IGym.DietGenerator.DietPlan;
using IGym.DietGenerator.DietPlan.CalorieAllocation;
using IGym.DietGenerator.Enums;
using IGym.DietGenerator.Models;
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
        private readonly int _dayCount = 28;

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

            var builder = new MonthlyDietPlanBuilder(allMeal, calorieRange);
            var dietPlan = builder.Build();

            //List<DailyDietPlan> dayList = transformDayList(dietPlan, request.StartDay);            
            List<DailyDietPlan> dayList = createDiet(allMeal, calorieRange, request.StartDay, _dayCount);
            
            var result = new GeneratedDietPlan();
            result.StartDay = request.StartDay;
            result.Request = request;
            result.Diet = dayList;
            result.AllMeal = generateAllMeal(dayList);
            result.Timestamp = DateTime.UtcNow;
            //ShoppingList shoppingList = generateShoppingList(dietPlan);
            ShoppingList shoppingList = generateShoppingList(result);

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

        private ShoppingList generateShoppingList(GeneratedDietPlan dietPlan)
        {
            var result = new ShoppingList();
            // monthly
            generateMonthlyList(result, dietPlan.AllMeal);

            var firstWeek = dietPlan.Diet.Where(m => m.Week == WeekNames.FirstWeek).ToList();
            var secondWeek = dietPlan.Diet.Where(m => m.Week == WeekNames.SecondWeek).ToList();
            var thirdWeek = dietPlan.Diet.Where(m => m.Week == WeekNames.ThirdWeek).ToList();
            var fourhtWeek = dietPlan.Diet.Where(m => m.Week == WeekNames.FourhtWeek).ToList();

            var meals = new List<SelectedMeal>();
            foreach ( var dailyDietPlan in firstWeek ) 
            {
                meals.AddRange(dailyDietPlan.AllMeal);
            }
            generateFirstWeek(result, dietPlan.AllMeal);

            meals = new List<SelectedMeal>();
            foreach (var dailyDietPlan in secondWeek)
            {
                meals.AddRange(dailyDietPlan.AllMeal);
            }
            generateSecondWeek(result, dietPlan.AllMeal);

            meals = new List<SelectedMeal>();
            foreach (var dailyDietPlan in thirdWeek)
            {
                meals.AddRange(dailyDietPlan.AllMeal);
            }
            generateThirdWeek(result, dietPlan.AllMeal);

            meals = new List<SelectedMeal>();
            foreach (var dailyDietPlan in fourhtWeek)
            {
                meals.AddRange(dailyDietPlan.AllMeal);
            }
            generateFourhtWeek(result, dietPlan.AllMeal);

            return result;
        }

        private ShoppingList generateShoppingList(MonthlyDietPlan monthlyDietPlan)
        {
            var result = new ShoppingList();
            // monthly
            generateMonthlyList(result, monthlyDietPlan.AllMeal);
            generateFirstWeek(result, monthlyDietPlan.FirstWeek.AllMeal);
            generateSecondWeek(result, monthlyDietPlan.SecondWeek.AllMeal);
            generateThirdWeek(result, monthlyDietPlan.ThirdWeek.AllMeal);
            generateFourhtWeek(result, monthlyDietPlan.ThirdWeek.AllMeal);

            return result;
        }

        private List<SelectedMeal> generateAllMeal(List<DailyDietPlan> dayList)
        {
            var result = new List<SelectedMeal>();

            foreach (var day in dayList) 
            {
                result.AddRange(day.AllMeal);
            }

            return result;
        }

        private List<DailyDietPlan> createDiet(
            IEnumerable<Meal> allMeals, DailyCalorieRange dailyCalorieRange, DateTime startDay, int dayCount)
        {
            var result = new List<DailyDietPlan>();

            var selectedMealList = allMeals.Select(m => m.ToSelected()).ToList();
            var culture = new CultureInfo("hu-HU");
            var dateTimeFormatInfo = culture.DateTimeFormat;
            var dayNames = dateTimeFormatInfo.DayNames;

            for (int i = 0; i < dayCount; i++) 
            {
                var date = startDay.AddDays(i);
                int dayOfWeekCount = (int)date.DayOfWeek;
                var dayName = dayNames[dayOfWeekCount];
                var timeTrace = new TimeTrace()
                {
                    DateTime = date,
                    DayName = dayName,
                };
                var builder = new DailyPlanBuilder(selectedMealList, dailyCalorieRange, timeTrace);
                var plan = builder.Build();
                plan.Date = date;
                plan.DayName = dayName;
                plan.Week = setWeekName(i);
                result.Add(plan);
            }

            return result;
        }

        private WeekNames setWeekName(int dayCount)
        {
            if (dayCount >= 0 && dayCount <= 6)
            {
                return WeekNames.FirstWeek;
            } 
            else if ((dayCount >= 7 && dayCount <= 13))
            {
                return WeekNames.SecondWeek;
            }
            else if ((dayCount >= 14 && dayCount <= 20))
            {
                return WeekNames.ThirdWeek;
            }
            else if ((dayCount >= 21 && dayCount <= 27))
            {
                return WeekNames.FourhtWeek;
            }
            else
            {
                return WeekNames.FirstWeek;
            }
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

        private List<DailyDietPlan> transformDayList(MonthlyDietPlan dietPlan, DateTime startDay)
        {
            var dayList = new List<DailyDietPlan>();
            var dayCounter = 0;
            var culture = new CultureInfo("hu-HU");
            var dateTimeFormatInfo = culture.DateTimeFormat;
            foreach (DaysOfTheWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                dayCounter = setListToDailyPlan(dietPlan.FirstWeek, startDay, dayList, dayCounter, day, dateTimeFormatInfo);

            }

            foreach (DaysOfTheWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                dayCounter = setListToDailyPlan(dietPlan.SecondWeek, startDay, dayList, dayCounter, day, dateTimeFormatInfo);

            }

            foreach (DaysOfTheWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                dayCounter = setListToDailyPlan(dietPlan.ThirdWeek, startDay, dayList, dayCounter, day, dateTimeFormatInfo);

            }

            foreach (DaysOfTheWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                dayCounter = setListToDailyPlan(dietPlan.FourhtWeek, startDay, dayList, dayCounter, day, dateTimeFormatInfo);

            }

            return dayList;
        }

        private static int setListToDailyPlan(
            WeeklyDietPlan dietPlan, 
            DateTime startDay, 
            List<DailyDietPlan> dayList, 
            int dayCounter, 
            DaysOfTheWeek day,
            DateTimeFormatInfo dateTimeFormatInfo
            )
        {
            var dayNames = dateTimeFormatInfo.DayNames;
            var plan = dietPlan[day.ToString()];
            var date = startDay.AddDays(dayCounter);
            int dayOfWeekCount = (int)date.DayOfWeek;
            plan.Date = date;
            plan.DayName = dayNames[dayOfWeekCount];
            dayList.Add(plan);
            dayCounter++;

            return dayCounter;
        }
        

        private void generateFourhtWeek(ShoppingList result, List<SelectedMeal> allMeal)
        {
            foreach (var meal in allMeal)
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
                        shoppingListIngredient.CategoryId = mealIngredient.CategoryId;
                        shoppingListIngredient.CategoryName = mealIngredient.CategoryName;

                        result.FourhtWeek.Add(shoppingListIngredient);
                    }
                }
            }
        }

        private void generateThirdWeek(ShoppingList result, List<SelectedMeal> allMeal)
        {
            var item = new ShoppingListResponseItem();
            
            foreach (var meal in allMeal)
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
                        shoppingListIngredient.CategoryId = mealIngredient.CategoryId;
                        shoppingListIngredient.CategoryName = mealIngredient.CategoryName;

                        result.ThirdWeek.Add(shoppingListIngredient);
                    }
                }
            }
        }

        private void generateSecondWeek(ShoppingList result, List<SelectedMeal> allMeal)
        {
            foreach (var meal in allMeal)
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
                        shoppingListIngredient.CategoryId = mealIngredient.CategoryId;
                        shoppingListIngredient.CategoryName = mealIngredient.CategoryName;

                        result.SecondWeek.Add(shoppingListIngredient);
                    }
                }
            }
        }

        private void generateFirstWeek(ShoppingList result, List<SelectedMeal> allMeal)
        {
            foreach (var meal in allMeal)
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
                        shoppingListIngredient.CategoryId = mealIngredient.CategoryId;
                        shoppingListIngredient.CategoryName = mealIngredient.CategoryName;

                        result.FirstWeek.Add(shoppingListIngredient);
                    }
                }
            }
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
