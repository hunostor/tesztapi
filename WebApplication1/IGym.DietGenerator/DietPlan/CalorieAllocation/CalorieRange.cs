using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.DietPlan.CalorieAllocation
{
    public class CalorieRange
    {
        public Calorie Low { get; set; }
        public Calorie Middle { get; set; }
        public Calorie High { get; set; }
    }
}
