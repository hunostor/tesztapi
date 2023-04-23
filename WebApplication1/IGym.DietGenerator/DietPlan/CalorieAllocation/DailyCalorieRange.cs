using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace IGym.DietGenerator.DietPlan.CalorieAllocation
{
    public class DailyCalorieRange
    {
        public CalorieRange Breakfast { get; set; }
        public CalorieRange Snack1 { get; set; }
        public CalorieRange Lunch { get; set; }
        public CalorieRange Snack2 { get; set; }
        public CalorieRange Dinner { get; set; }

        public CalorieRange this[string name]
        {
            get
            {
                var properties = typeof(DailyCalorieRange)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var property in properties)
                {
                    if (property.Name == name && property.CanRead)
                        return (CalorieRange) property.GetValue(this, null);
                }

                throw new ArgumentException($"Property name: `{name}`, Can t find property");
            }
            set
            {
                return;
            }
        }
    }
}
