using IGym.DietGenerator.Models.Switches;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Models.Wrappers
{
    public class IngredientWrapper
    {
        public Ingredient Ingredient { get; set; }

        public MealIngredientSwitch Switch { get; set; }
    }
}
