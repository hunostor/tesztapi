using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.CalorieCalculator.Interfaces
{
    public interface ISexModifier
    {
        public string SexName { get; }

        protected int _aseCalorie { get; }

        protected int _baseAge { get; }

        protected int _baseHeight { get; }

        protected int _baseWeigth { get; }
    }
}
