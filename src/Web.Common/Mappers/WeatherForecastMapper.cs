using BoilerPlateCore.Entities;
using BoilerPlateCore.Web.Common.Models;

namespace BoilerPlateCore.Web.Common.Mappers
{
    public static class WeatherForecastMapper
    {
        public static WeatherForecastExt MapToWeb(WeatherForecast weatherForecast)
        {
            return new WeatherForecastExt
            {
                Date = weatherForecast.Date,
                Summary = weatherForecast.Summary,
                TemperatureC = weatherForecast.TemperatureC,
                TemperatureF = weatherForecast.TemperatureF,
            };
        }

        public static WeatherForecast MapToBusiness(WeatherForecastExt weatherForecastExt)
        {
            return new WeatherForecast
            {
                Date = weatherForecastExt.Date,
                Summary = weatherForecastExt.Summary,
                TemperatureC = weatherForecastExt.TemperatureC,
            };
        }
    }
}
