using System.Collections.Generic;
using System.Linq;
using BoilerPlateCore.Business.Logic.Interfaces;
using BoilerPlateCore.Web.Common.Mappers;
using BoilerPlateCore.Web.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastGetter _weatherForecastGetter;
        private readonly IWeatherForecastPost _weatherForecastPost;

        public WeatherForecastController(
            IWeatherForecastGetter weatherForecastGetter,
            IWeatherForecastPost weatherForecastPost
            )
        {
            _weatherForecastGetter = weatherForecastGetter;
            _weatherForecastPost = weatherForecastPost;
        }

        [HttpGet]
        public IEnumerable<WeatherForecastExt> Get()
        {
            var forecasts = _weatherForecastGetter.GetForecasts();

            return forecasts.Select(WeatherForecastMapper.MapToWeb).ToList();
        }

        [HttpPost]
        public void Post(WeatherForecastExt weatherForecastExt)
        {
            _weatherForecastPost.Save(WeatherForecastMapper.MapToBusiness(weatherForecastExt));
        }
    }
}
