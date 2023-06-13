using IGym.DietGenerator.Enums;
using Repositories;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApplication1.ValidationAttribs
{
    public class OnlyGoalIdAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int val = (int)value;
            var repos = new GoalsRepository();
            var goalList = repos.GetAll();

            var goal = goalList.SingleOrDefault(g => g.Id == val);

            if (goal != null)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Goal field invalid value");
        }
    }
}
