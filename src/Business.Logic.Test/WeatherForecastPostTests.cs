using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoilerPlateCore.Data.Repositories.Interfaces;
using Moq;
using BoilerPlateCore.Common.Validation;
using BoilerPlateCore.Entities;
using BoilerPlateCore.TestBase.Builder;

namespace BoilerPlateCore.Business.Logic.Tests
{
    [TestClass]
    public class WeatherForecastPostTests
    {
        private Mock<IWeatherForecastPostRepository> _weatherforecastRepository;
        private Mock<IValidator<WeatherForecast>> _validator;

        [TestInitialize]
        public void Initialize()
        {
            _weatherforecastRepository = new Mock<IWeatherForecastPostRepository>();
            _validator = new Mock<IValidator<WeatherForecast>>();
        }

        [TestMethod]
        public void SaveTest()
        {
            //Arrange
            var entity = WeatherForecastBuilder.Builder().Build();
            var sut = new WeatherForecastPost(_weatherforecastRepository.Object, _validator.Object);

            //Act
            sut.Save(entity);

            //Assert
            _weatherforecastRepository.Verify(x => x.Save(It.IsAny<WeatherForecast>()), Times.Once);
            _validator.Verify(x => x.ThrowIfInvalid(It.IsAny<WeatherForecast>()), Times.Once);
        }
    }
}
