using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ValidationAttribs
{
    public class EnumerableStringLengthAttribute : ValidationAttribute
    {
        private int _stringLength;

        public EnumerableStringLengthAttribute(int stringLength)
        {
            _stringLength = stringLength;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var val = value as IEnumerable<string>;

            foreach (var item in val)
            {
                if (item.Length > _stringLength)
                {
                    return new ValidationResult($"Condition name must not be longer than {_stringLength} letters");
                }
            }

            return ValidationResult.Success;
        }
    }
}
