@WeatherForecastController
Feature: WeatherForecastController

Background: 
Given The currend date is 01-06-2020

Scenario: Get the Weatherforecasts from the controller
Given There is a weatherforecast with the following data
| Date       | TemperatureC | Summary |
| 01-01-2019 | 5            | Chilly  |
When the get method from WeatherForecastController is called
Then I expect these weatherforecasts
| Date       | TemperatureC | Summary |
| 01-01-2019 | 5            | Chilly  |
