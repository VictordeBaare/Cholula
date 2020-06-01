using System;
using BoilerPlateCore.Specflow.Test.Mock;
using TechTalk.SpecFlow;

namespace BoilerPlateCore.Specflow.Test.Steps
{
    [Binding]
    public class DateTimeProviderMockSteps
    {
        private readonly DateTimeProviderMock _dateTimeProviderMock;

        public DateTimeProviderMockSteps(DateTimeProviderMock dateTimeProviderMock)
        {
            _dateTimeProviderMock = dateTimeProviderMock;
        }

        [Given(@"The currend date is (.*)")]
        public void GivenTheCurrendDateIs(DateTime datetime)
        {
            _dateTimeProviderMock.SetDateTimeTodayMock(datetime);
            _dateTimeProviderMock.SetDateTimeNowMock(datetime);
        }
    }
}
