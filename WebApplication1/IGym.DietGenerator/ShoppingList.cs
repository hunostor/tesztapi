using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator
{
    public class ShoppingList
    {
        public IList<ShoppingListIngredient> Monthly { get; set; }
            = new List<ShoppingListIngredient>();

        public IList<ShoppingListIngredient> FirstWeek { get; set; }
            = new List<ShoppingListIngredient>();
        
        public IList<ShoppingListIngredient> SecondWeek { get; set; }
            = new List<ShoppingListIngredient>();
        
        public IList<ShoppingListIngredient> ThirdWeek { get; set; }
            = new List<ShoppingListIngredient>();

        public IList<ShoppingListIngredient> FourhtWeek { get; set; }
            = new List<ShoppingListIngredient>();
    }
}
