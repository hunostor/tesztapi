using IGym.DietGenerator.DietPlan.Interfaces;
using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IGym.DietGenerator.DietPlan
{
    public class IngridientListForShopping: IIngridientListCreator
    {
        private IList<ShoppingListIngredient> _ingredientList
            = new List<ShoppingListIngredient>();

        public IList<ShoppingListIngredient> GetList()
        {
            return _ingredientList;
        }

        public void Add(MealIngredient ingredient)
        {
            if (_ingredientList.Any(x => x.IngredientId == ingredient.IngredientId))
            {
                var ing = _ingredientList.Single(x => x.IngredientId == ingredient.IngredientId);
                ing.Quantity = ing.Quantity + ingredient.Quantity;
            }
            else
            {
                var shoppingListIngredient = new ShoppingListIngredient();
                shoppingListIngredient.IngredientId = ingredient.IngredientId;
                shoppingListIngredient.IngredientName = ingredient.IngredientName;
                shoppingListIngredient.Unit = ingredient.Unit;
                shoppingListIngredient.Quantity = ingredient.Quantity;
                shoppingListIngredient.CategoryId = ingredient.CategoryId;
                shoppingListIngredient.CategoryName = ingredient.CategoryName;

                _ingredientList.Add(shoppingListIngredient);
            }
        }
    }
}
