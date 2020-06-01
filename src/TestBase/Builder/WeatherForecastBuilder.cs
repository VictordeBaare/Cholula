using System;
using BoilerPlateCore.Entities;

namespace BoilerPlateCore.TestBase.Builder
{
    public class WeatherForecastBuilder
    {
        private readonly WeatherForecast _weatherForecast;

        private WeatherForecastBuilder()
        {
            _weatherForecast = new WeatherForecast
            {
                Date = new DateTime(2019, 1, 1),
                TemperatureC = 10,
                Summary = "Test Summary",
            };
        }

        public static WeatherForecastBuilder Builder()
        {
            return new WeatherForecastBuilder();
        }

        public WeatherForecast Build()
        {
            return _weatherForecast;
        }

        public WeatherForecastBuilder WithDate(DateTime dateTime)
        {
            _weatherForecast.Date = dateTime;
            return this;
        }
    }
}
