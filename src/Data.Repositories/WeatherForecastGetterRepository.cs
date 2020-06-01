using System.Collections.Generic;
using System.Linq;
using BoilerPlateCore.Data.Repositories.Context;
using BoilerPlateCore.Data.Repositories.Interfaces;
using BoilerPlateCore.Entities;

namespace BoilerPlateCore.Data.Repositories
{
    public class WeatherForecastGetterRepository : IWeatherForecastGetterRepository
    {
        private readonly IEntityContextFactory _entityContextFactory;

        public WeatherForecastGetterRepository(IEntityContextFactory entityContextFactory)
        {
            _entityContextFactory = entityContextFactory;
        }

        public IEnumerable<WeatherForecast> Get()
        {
            using var context = _entityContextFactory.Create();
            return context.WeatherForecast.ToList();
        }
    }
}
