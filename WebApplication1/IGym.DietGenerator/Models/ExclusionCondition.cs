using IGym.DietGenerator.Enums;
using IGym.DietGenerator.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Models
{
    public class ExclusionCondition: IMealTag
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ExclusionConditionTypes Type { get; set; }

        public string Description { get; set; }
    }
}
