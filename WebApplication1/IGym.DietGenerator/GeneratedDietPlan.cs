using IGym.DietGenerator.DietPlan;
using IGym.DietGenerator.Req;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator
{
    public class GeneratedDietPlan
    {
        public Request Request { get; set; }

        public MonthlyDietPlan Diet { get; set; }

        public ShoppingList ShoppingList { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
