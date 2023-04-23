﻿using IGym.DietGenerator.Enums;
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

        public Goals Gooal { get; set; }

        public IEnumerable<ExclusionCondition> ExclusionConditions { get; set; }
    }
}