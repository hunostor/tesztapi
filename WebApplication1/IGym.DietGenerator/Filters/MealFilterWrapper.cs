using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Filters
{
    public class MealFilterWrapper
    {
        private readonly ExclusionConditionFilter _exclusionConditionFilter;

        public MealFilterWrapper(ExclusionConditionFilter exclusionConditionFilter) 
        {
            _exclusionConditionFilter = exclusionConditionFilter;
        }

        public ExclusionConditionFilter ExclusionConditionFilter
        { get { return _exclusionConditionFilter; } }
    }
}
