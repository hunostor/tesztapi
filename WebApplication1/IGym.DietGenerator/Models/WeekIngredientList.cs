using IGym.DietGenerator.DietPlan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IGym.DietGenerator.Models
{
    public class WeekIngredientList
    {
        public int Week { get; }

        private readonly IIngridientListCreator _ingridientListCreator;

        public WeekIngredientList(int weekCount, IIngridientListCreator ingridientListCreator)
        {
            Week = weekCount;
            _ingridientListCreator = ingridientListCreator;
        }        

        public IList<ShoppingListIngredient> GetList()
        {
            return _ingridientListCreator.GetList();
        }

        public void Add(SelectedMeal meal)
        {
            foreach (var mealIngredient in meal.Ingredients)
            {
                _ingridientListCreator.Add(mealIngredient);
            }
        }
    }
}
