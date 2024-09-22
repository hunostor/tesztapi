using IGym.DietGenerator.DietPlan.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Models
{
    public class DailyIngridientList
    {
        private readonly IIngridientListCreator _ingridientListCreator;

        public DailyIngridientList(IIngridientListCreator ingridientListCreator)
        {
            _ingridientListCreator = ingridientListCreator;
        }

        public ADay Day { get; set; }

        public void Add(SelectedMeal meal)
        {
            foreach (var ingredient in meal.Ingredients)
            {
                _ingridientListCreator.Add(ingredient);
            }            
        }

        public IList<ShoppingListIngredient> GetList()
        {
            return _ingridientListCreator.GetList();
        }
    }
}
