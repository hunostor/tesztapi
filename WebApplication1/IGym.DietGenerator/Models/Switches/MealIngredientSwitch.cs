using IGym.DietGenerator.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Models.Switches
{
    public class MealIngredientSwitch
    {
        public string MealId { get; set; }

        public int IngredientId { get; set; }        

        public decimal Quantity { get; set; }
    }
}
