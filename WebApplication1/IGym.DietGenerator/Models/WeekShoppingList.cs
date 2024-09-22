using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Models
{
    public class WeekShoppingList
    {
        public WeekShoppingList(int weekCount)
        {
            Week = weekCount;
        }

        public int Week { get; }

        public IList<ShoppingListIngredient> IngredientList { get; set; }
            = new List<ShoppingListIngredient>();
    }
}
