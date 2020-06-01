using System.Collections.Generic;
using BoilerPlateCore.Business.Logic.Interfaces;
using BoilerPlateCore.Data.Repositories.Interfaces;
using BoilerPlateCore.Entities;

namespace BoilerPlateCore.Business.Logic
{
    public class WeatherForecastGetter : IWeatherForecastGetter
    {
        private readonly IWeatherForecastGetterRepository _weatherForecastGetterRepository;

        public WeatherForecastGetter(IWeatherForecastGetterRepository weatherForecastGetterRepository)
        {
            _weatherForecastGetterRepository = weatherForecastGetterRepository;
        }

        public IEnumerable<WeatherForecast> GetForecasts()
        {
            return _weatherForecastGetterRepository.Get();
        }
    }
}
