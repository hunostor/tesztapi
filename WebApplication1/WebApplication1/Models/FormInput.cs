using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication1.ValidationAttribs;

namespace WebApplication1.Models
{
    public class FormInput
    {
        [Required]
        [StringLength(50)]
        public string UserId { get; set; }

        [Required]
        [OnlyGenderId]
        public int Gender { get; set; }

        [Range(18, 120)]
        [Required]
        public int Age { get; set; }

        [Range(140, 230)]
        [Required]
        public int Heigth { get; set; }

        [Range(40, 250)]
        [Required]
        public int Weight { get; set; }

        [Required]
        public WeeklyWorkout WeeklyWorkout{ get; set; }

        [Required]
        [OnlyGoalId]
        public int Goal { get; set; }

        [Required]
        [OnlyExclusionConditionId]
        [ExclusionConditionAllowedCount(5)]
        public int[] ExclusionConditions { get; set; }
    }
}
