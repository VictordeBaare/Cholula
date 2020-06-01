using BoilerPlateCore.Business.Logic;
using BoilerPlateCore.Business.Logic.Interfaces;
using BoilerPlateCore.Common;
using BoilerPlateCore.Common.Validation;
using BoilerPlateCore.Data.Repositories;
using BoilerPlateCore.Data.Repositories.Context;
using BoilerPlateCore.Data.Repositories.Interfaces;
using BoilerPlateCore.Entities;
using BoilerPlateCore.Entities.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace BoilerPlateCore.CompositionRoot
{
    public static class IServiceCollectionExtensions
    {
        public static void AddBusinessComponents(this IServiceCollection service)
        {
            service.AddTransient<IWeatherForecastGetter, WeatherForecastGetter>();
            service.AddTransient<IWeatherForecastPost, WeatherForecastPost>();
        }

        public static void AddDataRepositories(this IServiceCollection service)
        {
            service.AddTransient<IWeatherForecastGetterRepository, WeatherForecastGetterRepository>();
            service.AddTransient<IWeatherForecastPostRepository, WeatherForecastPostRepository>();
            service.AddTransient<IEntityContextFactory, EntityContextFactory>();
        }

        public static void AddSharedComponents(this IServiceCollection service)
        {
            service.AddTransient<IDateTimeProvider, DateTimeProvider>();
            service.AddTransient<IValidator<WeatherForecast>, WeatherForecastValidator>();
        }
    }
}
