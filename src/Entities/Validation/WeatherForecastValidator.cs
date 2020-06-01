using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BoilerPlateCore.Common.Validation;

namespace BoilerPlateCore.Entities.Validation
{
    public class WeatherForecastValidator : ValidatorBase<WeatherForecast>
    {
        protected override IEnumerable<ValidationResult> ValidateCustomRules(WeatherForecast entity)
        {
            return Enumerable.Empty<ValidationResult>();
        }
    }
}
