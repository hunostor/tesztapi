using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Models.Values
{
    public class DietPlanLength
    {
        private readonly int _length;

        public DietPlanLength(int length)
        {
            if (length <= 0) 
            {
                throw new ArgumentOutOfRangeException("Diet length day cannot be zero or less");
            }

            _length = length;
        }

        public int Value 
        {
            get { return _length; }
        }
    }
}
