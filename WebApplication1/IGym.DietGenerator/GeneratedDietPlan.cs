using IGym.DietGenerator.DietPlan;
using IGym.DietGenerator.Models;
using IGym.DietGenerator.Req;
using IGym.DietGenerator.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator
{
    /// <summary>
    /// todo kérdés, mikortól legyen egy hét megmutatva?
    /// </summary>
    public class GeneratedDietPlan
    {
        public Request Request { get; set; }

        public DateTime StartDay { get; set; }

        public List<SelectedMeal> AllMeal { get; set; } = new List<SelectedMeal>();

        public List<DailyDietPlan> Diet { get; set; } = new List<DailyDietPlan>();

        public ShoppingListResponse ShoppingList { get; set; } = new ShoppingListResponse();

        public DateTime Timestamp { get; set; }
    }
}
