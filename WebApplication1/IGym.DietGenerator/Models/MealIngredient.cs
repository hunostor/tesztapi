using IGym.DietGenerator.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Models
{
    public class MealIngredient
    {
        public int IngredientId { get; set; }

        public string IngredientName { get; set; }

        public UnitOfMeasurements Unit { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public decimal Quantity { get; set; }
    }
}
