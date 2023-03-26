using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ValidationAttribs
{
    public class OnlyGenderValuesAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string val = value as string;            
            
            if (val == "man")
            {
                return ValidationResult.Success;
            }

            if (val == "woman")
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Gender field invalid value");
        }
    }
}
