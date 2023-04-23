using IGym.DietGenerator.CalorieCalculator.Interfaces;
using IGym.DietGenerator.CalorieCalculator.Modifiers.Goals;
using IGym.DietGenerator.CalorieCalculator.Modifiers.Sex;
using IGym.DietGenerator.CalorieCalculator.Modifiers.Workouts;
using IGym.DietGenerator.Models;
using IGym.DietGenerator.Req;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.CalorieCalculator
{
    public class HumanDailyCalorieRequirementCalculator: ICalorieCalculator
    {
        private ICalorieModifier _hardWorkout;

        private ICalorieModifier _lightWorkout;

        private IHumanCalorieCalculator _baseCalorieCalc;

        private IGoalCalorieModifier _goalCalorieModifier;

        public Calorie CalculateDaliyCalorie(Request request)
        {
            this.init(request);
            var baseCalorie = this._baseCalorieCalc.DaliyCalorieCalculator(request.Human);

            baseCalorie = this.calculateWorkout(baseCalorie, request);

            baseCalorie = this._goalCalorieModifier.ModifyDalyCalories(baseCalorie, request.Human.Weight, request.Gooal);

            return baseCalorie;
        }

        private Calorie calculateWorkout(Calorie baseCalorie, Request request)
        {
            for (int i = 0; i < request.WeeklyWorkout.Hard; i++)
            {
                baseCalorie = _hardWorkout.ModifyDalyCalories(baseCalorie);
            }

            for (int i = 0; i < request.WeeklyWorkout.Light; i++)
            {
                baseCalorie = _lightWorkout.ModifyDalyCalories(baseCalorie);
            }

            return baseCalorie;
        }

        private void init(Request request)
        {
            if (request.Human.Gender == Enums.Genders.Female)
            {
                this._baseCalorieCalc = new Female();
                this._lightWorkout = new FemaleLightWorkout();
                this._hardWorkout = new FemaleHardWorkout();
                this._goalCalorieModifier = new FemaleGoalCalorieModifier();
            }

            if (request.Human.Gender == Enums.Genders.Male)
            {
                this._baseCalorieCalc = new Male();
                this._lightWorkout = new MaleLightWorkout();
                this._hardWorkout = new MaleHardWorkout();
                this._goalCalorieModifier = new MaleGoalCalorieModifier();
            }
        }
    }
}
