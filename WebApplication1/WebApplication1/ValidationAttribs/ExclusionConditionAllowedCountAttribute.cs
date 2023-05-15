using IGym.DietGenerator.Repositories;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ValidationAttribs
{
    public class ExclusionConditionAllowedCountAttribute : ValidationAttribute
    {
        private int _count;

        public ExclusionConditionAllowedCountAttribute(int count)
        {
            _count = count;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var conditionIds = value as int[];

            if (conditionIds.Length > _count)
            {
                return new ValidationResult($"Exclusion Condition max number of: {_count}");
            }          

            return ValidationResult.Success;
        }
    }
}
