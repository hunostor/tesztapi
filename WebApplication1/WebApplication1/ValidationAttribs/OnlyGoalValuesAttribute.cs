using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ValidationAttribs
{
    public class OnlyGoalValuesAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string val = value as string;

            if (val == "weightGain")
            {
                return ValidationResult.Success;
            }

            if (val == "weightLoss")
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Goal field invalid value");
        }
    }
}
