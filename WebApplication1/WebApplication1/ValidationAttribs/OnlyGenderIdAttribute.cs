using IGym.DietGenerator.Enums;
using IGym.DietGenerator.Repositories;
using Repositories;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApplication1.ValidationAttribs
{
    public class OnlyGenderIdAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int val = (int)value;
            var repos = new GenderRepository();
            var genderList = repos.GetAll();

            var gender = genderList.SingleOrDefault(g => g.Id == val);

            if (gender != null) 
            {
                return ValidationResult.Success;
            }


            return new ValidationResult("Gender field invalid value");
        }
    }
}
