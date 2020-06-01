using System;

namespace BoilerPlateCore.Common
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Today => DateTime.Today;

        public DateTime Now => DateTime.Now;
    }
}
