using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BoilerPlateCore.Common.Validation
{
    public abstract class ValidatorBase<T> : IValidator<T>
    {
        public void ThrowIfInvalid(T entity)
        {
            var validationResult = Validate(entity).FirstOrDefault();
            if (validationResult != null)
            {
                throw new ValidationException(validationResult.ErrorMessage);
            }
        }

        public IEnumerable<ValidationResult> Validate(T entity)
        {
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults, true);

            var customErrors = ValidateCustomRules(entity);
            return validationResults.Union(customErrors).ToList();
        }

        protected abstract IEnumerable<ValidationResult> ValidateCustomRules(T entity);
    }
}
