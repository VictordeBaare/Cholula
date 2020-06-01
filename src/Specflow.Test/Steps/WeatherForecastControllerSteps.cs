using System.Collections.Generic;
using BoilerPlateCore.Web.Common.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebApi.Controllers;

namespace BoilerPlateCore.Specflow.Test.Steps
{
    [Binding]
    [Scope(Tag = "WeatherForecastController")]
    public class WeatherForecastControllerSteps
    {
        private readonly WeatherForecastController _weatherForecastController;
        private readonly ScenarioContext _scenarioContext;

        public WeatherForecastControllerSteps(
            WeatherForecastController weatherForecastController,
            ScenarioContext scenarioContext)
        {
            _weatherForecastController = weatherForecastController;
            _scenarioContext = scenarioContext;
        }

        [Given(@"There is a weatherforecast with the following data")]
        public void GivenThereIsAWeatherforecastWithTheFollowingData(Table table)
        {
            var forecasts = table.CreateSet<WeatherForecastExt>();
            foreach(var forecast in forecasts)
            {
                _weatherForecastController.Post(forecast);
            }
        }

        [When(@"the get method from WeatherForecastController is called")]
        public void WhenTheGetMethodFromWeatherForecastControllerIsCalled()
        {
            var forecasts = _weatherForecastController.Get();
            _scenarioContext.Add("WeatherForecast_Get", forecasts);
        }

        [Then(@"I expect these weatherforecasts")]
        public void ThenIExpectTheseWeatherforecasts(Table table)
        {
            table.CompareToSet(_scenarioContext.Get<IEnumerable<WeatherForecastExt>>("WeatherForecast_Get"));
        }
    }
}
