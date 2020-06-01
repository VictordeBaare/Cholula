using BoilerPlateCore.Data.Repositories.Context;
using BoilerPlateCore.Data.Repositories.Interfaces;
using BoilerPlateCore.Entities;

namespace BoilerPlateCore.Data.Repositories
{
    public class WeatherForecastPostRepository : IWeatherForecastPostRepository
    {
        private readonly IEntityContextFactory _entityContextFactory;

        public WeatherForecastPostRepository(IEntityContextFactory entityContextFactory)
        {
            _entityContextFactory = entityContextFactory;
        }

        public void Save(WeatherForecast weatherForecast)
        {
            using var context = _entityContextFactory.Create();
            context.WeatherForecast.Add(weatherForecast);
            context.SaveChanges();
        }
    }
}
