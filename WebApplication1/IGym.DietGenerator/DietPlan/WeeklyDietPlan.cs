using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IGym.DietGenerator.DietPlan
{
    public class WeeklyDietPlan
    {
        public List<SelectedMeal> AllMeal { get; set; } = new List<SelectedMeal>();
        public int Calorie { get; set; } = 0;
        public DailyDietPlan Monday { get; set; }
        public DailyDietPlan Tuesday { get; set; }
        public DailyDietPlan Wednesday { get; set; }
        public DailyDietPlan Thursday { get; set; }
        public DailyDietPlan Friday { get; set; }
        public DailyDietPlan Saturday { get; set; }
        public DailyDietPlan Sunday { get; set; }

        public DailyDietPlan this[string name]
        {
            get
            {
                var properties = typeof(WeeklyDietPlan)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var property in properties)
                {
                    if (property.Name == name && property.CanRead)
                        return (DailyDietPlan)property.GetValue(this, null);
                }

                throw new ArgumentException($"Property name: `{name}`, Can t find property");
            }
            set
            {
                var properties = typeof(WeeklyDietPlan)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance);

                if (! properties.Any(p => p.Name == name))
                {
                    throw new ArgumentException($"Property name: `{name}`, Can t find property");
                }

                foreach (var property in properties)
                {
                    if (property.Name == name && property.CanRead)
                        property.SetValue(this, value);
                }                
            }
        }
    }
}
