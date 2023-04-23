using IGym.DietGenerator.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ValidationAttribs
{
    public class OnlyGoalValuesAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string val = value as string;

            if (val == Goals.WeightGain.ToString())
            {
                return ValidationResult.Success;
            }

            if (val == Goals.WeightLoss.ToString())
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Goal field invalid value");
        }
    }
}
