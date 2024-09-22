using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.DietPlan.Interfaces
{
    public interface IIngridientListCreator
    {
        IList<ShoppingListIngredient> GetList();
        void Add(MealIngredient ingredient);
    }
}
