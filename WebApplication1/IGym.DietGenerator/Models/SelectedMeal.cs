using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Models
{
    public class SelectedMeal: Meal
    {
        public IList<TimeTrace> Trace { get; set; } = new List<TimeTrace>();
    }
}
