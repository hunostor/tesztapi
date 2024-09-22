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

        public bool Vegan { get; set; } = false;

        public bool Vegetarian { get; set; } = false;

        public bool LactoseFree { get; set; } = false;

        public bool GlutenFree { get; set; } = false;
    }
}
