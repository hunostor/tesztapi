using IGym.DietGenerator.Enums;
using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Req
{
    public class Request
    {
        public Human Human { get; set; }

        public WeeklyWorkout WeeklyWorkout { get; set; } = new WeeklyWorkout();

        public Goals Goal { get; set; }

        public DateTime StartDay { get; set; }

        public IList<ExclusionCondition> ExclusionConditions { get; set; } = new List<ExclusionCondition>(); 
    }
}
