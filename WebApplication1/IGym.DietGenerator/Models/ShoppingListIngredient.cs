using IGym.DietGenerator.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Models
{
    public class ShoppingListIngredient
    {
        public int IngredientId { get; set; }

        public string IngredientName { get; set; }

        public UnitOfMeasurements Unit { get; set; }

        public decimal Quantity { get; set; }
    }
}
