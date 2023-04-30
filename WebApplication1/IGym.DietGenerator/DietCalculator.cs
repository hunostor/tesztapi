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
using System.Runtime.InteropServices;
using System.Text;

namespace IGym.DietGenerator
{
    /// <summary>
    /// "Az alábbiak közül van-e valamilyen táplálékallergiád vagy intoleranciád? (Többet is jelölhetsz)
    /// -- Gluténérzékeny vagyok 
    /// -- Laktózérzékeny vagyok"
    /// 
    /// type: intolerance or food_allergy
    /// 
    /// "Jelöld ki azokat a hús és halféléket, amelyeket NEM szívesen fogyasztanál céljaid eléréséhez:
    /// (nem kötelező jelölnöd) 
    /// -- Szárnyasok(csirke, pulyka)
    /// -- Vörös húsok(marha, sertés)
    /// -- Belsőségek(máj, aprólék)
    /// -- Nem eszem húst
    /// -- Édesvízi- és tengeri halfilék
    /// -- Olajos tonhalak
    /// -- Rák, kagyló"
    /// 
    /// type: meat_and_fish
    /// 
    /// "Jelöld ki azokat a köreteket, amelyeket NEM szívesen fogyasztanál céljaid eléréséhez: 
    /// (nem kötelező jelölnöd) 
    /// -- Burgonya, édesburgonya 
    /// -- Rizs, barnarizs
    /// -- Köles
    /// -- Quinoa
    /// -- Bulgur
    /// -- Tészta, durumtészta
    /// -- Amaránt
    /// -- Kuszkusz 
    ///"
    ///
    /// type: side_dish
    /// 
    ///
    /// "Jelöld ki azokat a gyümölcsöket amelyeket NEM szívesen fogyasztanál céljaid eléréséhez:
    /// (nem kötelező jelölnöd) 
    /// -- Alma 
    /// -- Körte
    /// -- Banán
    /// -- Erdei bogyós gyümölcsök(áfonya, málna, eper, szeder, ribizli)
    /// -- Narancs
    /// -- Mandarin
    /// -- Ananász 
    /// -- Dinnye
    /// -- Szőlő
    /// -- Kivi
    ///"
    ///
    /// type: fruit
    ///
    /// "Jelöld ki azokat a zöldségeket amelyeket NEM szívesen fogyasztanál céljaid eléréséhez: 
    /// (nem kötelező jelölnöd)
    /// -- Paradicsom(hagyományos, koktél)
    /// -- Paprika(zöld-, kalifornia-, kápia-,)
    /// -- Uborka(kovászos-, csemege-, kígyó-,)
    /// -- Retek(vaj-, hónapos-, fekete-, jég-,)
    /// -- Tökfélék(cukkíni, padlizsán, sütőtök)
    /// -- Sárgarépa 
    /// -- Brokkoli
    /// -- Spenót
    /// -- Avokádó
    /// -- Saláták(jég-, madár-, radicchio-, rukkola-,)
    ///"
    ///
    /// type: vegetable
    ///
    /// "Jelöld ki azokat az élelmiszereket amelyeket NEM szívesen fogyasztanál céljaid eléréséhez: 
    /// (nem kötelező jelölnöd)
    /// -- Tej, növényi italok(szója-, mandula-, kókusz-, rizsital)
    /// -- Tojás
    /// -- Joghurt(natúr, görög, zsírszegény)
    /// -- Tejföl
    /// -- Túró, Cottage cheese
    /// -- Sajtfélék
    /// -- Gombafélék
    /// -- Hüvelyesek(bab, borsó, lencse)
    /// -- Olajos magvak(mandula, kesudió, mogyoró)
    /// -- Húspótlók(tofu, szejtán, tempeh)
    ///"
    ///
    /// type: food_stuff
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
