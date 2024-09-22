using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Models.Values
{
    public class DietStartDay
    {
        private readonly DateTime _value;

        public DietStartDay(int year, int month, int day)
        {
            _value = new DateTime(year, month, day);
        }

        public DateTime Value { get { return _value; } }
    }
}
