using BoilerPlateCore.Entities;

namespace BoilerPlateCore.Data.Repositories.Interfaces
{
    public interface IWeatherForecastPostRepository
    {
        void Save(WeatherForecast weatherForecast);
    }
}
