using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Filters.Mods
{
    public class MealNamePrefix
    {
        private readonly string _prefix;

        public MealNamePrefix(string prefix)
        {
            _prefix = prefix;
        }

        public string GetPrefix() { return _prefix; }
    }
}
