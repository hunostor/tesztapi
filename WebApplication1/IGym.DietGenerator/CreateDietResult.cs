using IGym.DietGenerator.DietPlan;
using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator
{
    public class CreateDietResult
    {
        public List<DailyDietPlan> DietPlan { get; set; }

        public IEnumerable<DailyIngridientList> IngredientLists { get; set; }
    }
}
