using System.Collections.Generic;
using BoilerPlateCore.Entities;

namespace BoilerPlateCore.Business.Logic.Interfaces
{
    public interface IWeatherForecastGetter
    {
        IEnumerable<WeatherForecast> GetForecasts();
    }
}
