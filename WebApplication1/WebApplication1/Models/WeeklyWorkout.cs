using System.ComponentModel.DataAnnotations;
using WebApplication1.ValidationAttribs;

namespace WebApplication1.Models
{
    public class WeeklyWorkout
    {
        [Required]
        [WeeklyMaxWorkout]
        [Range(0, 7)]
        public int Hard { get; set; }

        [Required]
        [WeeklyMaxWorkout]
        [Range(0, 7)]
        public int Light { get; set; }
    }
}
