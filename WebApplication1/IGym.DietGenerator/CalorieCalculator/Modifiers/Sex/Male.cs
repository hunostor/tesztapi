using IGym.DietGenerator.CalorieCalculator.Interfaces;
using IGym.DietGenerator.Enums;
using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.CalorieCalculator.Modifiers.Sex
{
    public class Male : Gender, IHumanCalorieCalculator
    {
        public override Genders SexName => Genders.Male;

        protected override int _baseCalorie => 1600;

        protected override int _baseAge => 18;

        protected override int _baseHeight => 150;

        protected override int _baseWeight => 60;

        protected override int _modifierForAge => 5;

        protected override int _modifierForHeight => 6;

        protected override int _modifierForWeight => 10;

        public Calorie DaliyCalorieCalculator(Human human)
        {
            int resultCal = this._baseCalorie;
            var ageCal = (human.Age - this._baseAge) * this._modifierForAge;
            var heightCal = (human.Heigth - this._baseHeight) * this._modifierForHeight;
            var weightCal = (human.Weight - this._baseWeight) * this._modifierForWeight;

            resultCal = resultCal - ageCal + heightCal + weightCal;
            return new Calorie(resultCal);
        }
    }
}
