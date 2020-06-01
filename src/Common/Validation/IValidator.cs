using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoilerPlateCore.Common.Validation
{
    public interface IValidator<T>
    {
        void ThrowIfInvalid(T entity);

        IEnumerable<ValidationResult> Validate(T entity);
    }
}
