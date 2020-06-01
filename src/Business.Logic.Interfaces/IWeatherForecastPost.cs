using BoilerPlateCore.Entities;

namespace BoilerPlateCore.Business.Logic.Interfaces
{
    public interface IWeatherForecastPost
    {
        void Save(WeatherForecast weatherForecast);
    }
}
