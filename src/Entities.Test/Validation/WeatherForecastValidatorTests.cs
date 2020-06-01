using System;
using BoilerPlateCore.Entities.Validation;
using BoilerPlateCore.TestBase.Builder;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace BoilerPlateCore.Entities.Test.Validation
{
    [TestClass]
    public class WeatherForecastValidatorTests
    {
        [TestMethod]
        [DataRow("2010-01-01", 1)]
        [DataRow("2011-01-01", 0)]
        [DataRow("2020-01-01", 0)]
        [DataRow("2021-01-01", 1)]
        public void ValidateDate(string dateTime, int errorCount)
        {
            //Arrange
            var forecast = WeatherForecastBuilder.Builder().WithDate(DateTime.Parse(dateTime)).Build();
            var sut = new WeatherForecastValidator();

            //Act
            var validationResult = sut.Validate(forecast);

            //Assert
            validationResult.Should().HaveCount(errorCount);
        }
    }
}
