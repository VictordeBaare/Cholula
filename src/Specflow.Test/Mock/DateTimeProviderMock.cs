using System;
using BoilerPlateCore.Common;

namespace BoilerPlateCore.Specflow.Test.Mock
{
    public class DateTimeProviderMock : IDateTimeProvider
    {
        public DateTime Today { get; private set; } = DateTime.Today;

        public DateTime Now { get; private set; } = DateTime.Now;

        public void SetDateTimeTodayMock(DateTime dateTime)
        {
            Today = dateTime;
        }

        public void SetDateTimeNowMock(DateTime dateTime)
        {
            Today = dateTime;
        }
    }
}
