using System.Collections.Generic;
using BoilerPlateCore.Entities;

namespace BoilerPlateCore.Data.Repositories.Interfaces
{
    public interface IWeatherForecastGetterRepository
    {
        IEnumerable<WeatherForecast> Get();
    }
}
