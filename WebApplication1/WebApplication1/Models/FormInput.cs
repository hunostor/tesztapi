using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication1.ValidationAttribs;

namespace WebApplication1.Models
{
    public class FormInput
    {
        [Required]
        [StringLength(100)]
        [OnlyGenderValues]
        public string Gender { get; set; }

        [Range(18, 120)]
        public int Age { get; set; }

        [Range(140, 230)]
        public int Heigth { get; set; }

        [Range(40, 250)]
        public int Weight { get; set; }

        [Required]
        public WeeklyWorkout WeeklyWorkout{ get; set; }

        [Required]
        [StringLength(100)]
        [OnlyGoalValues]
        public string Goal { get; set; }

        [Required]
        [OnlyExclusionConditionId]
        [ExclusionConditionAllowedCount(5)]
        public int[] ExclusionConditions { get; set; }
    }
}
