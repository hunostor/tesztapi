using IGym.DietGenerator.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApplication1.ValidationAttribs
{
    public class OnlyExclusionConditionIdAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var repos = new DummyExclusionConditionRepository();
            var conditions = repos.GetAll();
            var conditionIds = value as int[];

            foreach ( var id in conditionIds) 
            {
                var condition = conditions.SingleOrDefault(c => c.Id == id); 
                if(condition == null)
                    return new ValidationResult($"Exclusion Condition not found, id: {id}");
            }          

            return ValidationResult.Success;
        }
    }
}
