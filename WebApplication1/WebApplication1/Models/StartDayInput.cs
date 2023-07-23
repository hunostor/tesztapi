using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class StartDayInput
    {
        [Required]
        public int Year { get; set; }

        [Required]
        public int Month { get; set; }
        
        [Required]
        public int Day { get; set; }
    }
}
