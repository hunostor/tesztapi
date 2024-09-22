using IGym.DietGenerator.Enums;
using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.DietPlan
{
    public class DailyDietPlan
    {
        public ADay Day { get; set; }
        public int BulletNumber { get; set; }
        public int Week { get; set; }
        public int Calorie { get; set; } = 0;

        public DailyIngridientList Ingridients { get; set; }

        public List<SelectedMeal> Meals { get; } = new List<SelectedMeal>();

    }
}
