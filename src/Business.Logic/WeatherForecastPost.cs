using BoilerPlateCore.Business.Logic.Interfaces;
using BoilerPlateCore.Common.Validation;
using BoilerPlateCore.Data.Repositories.Interfaces;
using BoilerPlateCore.Entities;

namespace BoilerPlateCore.Business.Logic
{
    public class WeatherForecastPost : IWeatherForecastPost
    {
        private readonly IWeatherForecastPostRepository _weatherForecastPostRepository;
        private readonly IValidator<WeatherForecast> _validator;

        public WeatherForecastPost(
            IWeatherForecastPostRepository weatherForecastPostRepository,
            IValidator<WeatherForecast> validator
            )
        {
            _weatherForecastPostRepository = weatherForecastPostRepository;
            _validator = validator;
        }

        public void Save(WeatherForecast weatherForecast)
        {
            _validator.ThrowIfInvalid(weatherForecast);

            _weatherForecastPostRepository.Save(weatherForecast);
        }
    }
}
