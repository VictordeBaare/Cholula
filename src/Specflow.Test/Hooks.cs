using BoDi;
using BoilerPlateCore.Common;
using BoilerPlateCore.CompositionRoot;
using BoilerPlateCore.Data.Repositories.Context;
using BoilerPlateCore.Specflow.Test.Mock;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;
using WebApi.Controllers;

namespace BoilerPlateCore.Specflow.Test
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario]
        public static void BeforeScenario(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddBusinessComponents();
            serviceCollection.AddDataRepositories();
            serviceCollection.AddSharedComponents();
            serviceCollection.AddTransient(x => scenarioContext);
            serviceCollection.AddTransient<WeatherForecastController>();
            serviceCollection.AddSingleton<IDateTimeProvider, DateTimeProviderMock>();            
            serviceCollection.AddSingleton<IEntityContextFactory, EntityContextFactoryMock>();
            var provider = serviceCollection.BuildServiceProvider();

            objectContainer.RegisterInstanceAs(provider.GetService<IDateTimeProvider>());
            objectContainer.RegisterInstanceAs(provider.GetService<WeatherForecastController>());
        }
    }
}
