using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IGym.DietGenerator.DietPlan.TimeOfDays
{
    public class MealTimeOfDay
    {
        private readonly List<string> _items;

        public MealTimeOfDay(IEnumerable<string> items)
        {
            _items = items.ToList();
        }

        public List<string> Items { get { return _items; } }
    }
}
