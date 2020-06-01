using BoilerPlateCore.Data.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BoilerPlateCore.Business.Logic.Tests
{
    [TestClass]
    public class WeatherForecastGetterTests
    {
        private Mock<IWeatherForecastGetterRepository> _weatherforecastRepository;

        [TestInitialize]
        public void Initialize()
        {
            _weatherforecastRepository = new Mock<IWeatherForecastGetterRepository>();
        }

        [TestMethod]
        public void GetForecastsTest()
        {
            //Arrange
            var sut = new WeatherForecastGetter(_weatherforecastRepository.Object);

            //Act
            sut.GetForecasts();

            //Assert
            _weatherforecastRepository.Verify(x => x.Get(), Times.Once);
        }
    }
}
