using IGym.DietGenerator.Enums;
using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.DietPlan.CalorieAllocation
{
    public class CallorieAllocationHandler
    {
        private Dictionary<string, decimal> _distribution =
            new Dictionary<string, decimal>();

        private decimal _devitationInPercent = 3;

        public CallorieAllocationHandler()
        {
            this._distribution.Add(MealTimeOfDay.Breakfast.ToString(), 20);
            this._distribution.Add(MealTimeOfDay.Snack1.ToString(), 15);
            this._distribution.Add(MealTimeOfDay.Lunch.ToString(), 35);
            this._distribution.Add(MealTimeOfDay.Snack2.ToString(), 10);
            this._distribution.Add(MealTimeOfDay.Dinner.ToString(), 20);
        }

        public DailyCalorieRange Calculate(Calorie dailyCalorie)
        {
            var result = new DailyCalorieRange();

            result.Breakfast = calculateRange(dailyCalorie, this._distribution[MealTimeOfDay.Breakfast.ToString()]);
            result.Snack1 = calculateRange(dailyCalorie, this._distribution[MealTimeOfDay.Snack1.ToString()]);
            result.Lunch = calculateRange(dailyCalorie, this._distribution[MealTimeOfDay.Lunch.ToString()]);
            result.Snack2 = calculateRange(dailyCalorie, this._distribution[MealTimeOfDay.Snack2.ToString()]);
            result.Dinner = calculateRange(dailyCalorie, this._distribution[MealTimeOfDay.Dinner.ToString()]);

            return result;
        }

        private CalorieRange calculateRange(Calorie calorie, decimal percent)
        {
            var result = new CalorieRange();

            var onePercentCalorie = calorie.Value / 100;
            result.Middle = new Calorie(Math.Round(onePercentCalorie * percent));
            result.High = new Calorie(Math.Round((onePercentCalorie * percent) + (onePercentCalorie * _devitationInPercent)));
            result.Low = new Calorie(Math.Round((onePercentCalorie * percent) - (onePercentCalorie * _devitationInPercent)));

            return result;
        }
    }
}
