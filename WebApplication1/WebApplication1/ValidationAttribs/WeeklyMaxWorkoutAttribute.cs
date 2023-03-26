using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.ValidationAttribs
{
    public class WeeklyMaxWorkoutAttribute : ValidationAttribute
    {


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var obj = (WeeklyWorkout) validationContext.ObjectInstance;

            if (obj.Hard + obj.Light > 7)
            {
                return new ValidationResult("A hard and light workout total of 7 can be");
            }            

            return ValidationResult.Success;
        }
    }
}
