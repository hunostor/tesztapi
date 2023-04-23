using IGym.DietGenerator.CalorieCalculator.Interfaces;
using IGym.DietGenerator.Enums;
using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.CalorieCalculator.Modifiers.Sex
{
    public abstract class Gender
    {
        public abstract Genders SexName { get; }
        
        protected abstract int _baseCalorie { get; }

        protected abstract int _baseAge { get; }

        protected abstract int _baseHeight { get; }
        
        protected abstract int _baseWeight { get; }

        /// <summary>
        /// 1 year
        /// </summary>
        protected abstract int _modifierForAge { get; }

        /// <summary>
        /// 1 cm
        /// </summary>
        protected abstract int _modifierForHeight { get; }

        /// <summary>
        /// 1 kg
        /// </summary>
        protected abstract int _modifierForWeight { get; }
    }
}
