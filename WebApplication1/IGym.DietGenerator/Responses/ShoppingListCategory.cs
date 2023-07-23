using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Responses
{
    public class ShoppingListCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public IList<ShoppingListIngredient> Items { get; set; }
            = new List<ShoppingListIngredient>();
    }
}
