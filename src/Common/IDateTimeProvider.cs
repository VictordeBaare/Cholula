using System;

namespace BoilerPlateCore.Common
{
    public interface IDateTimeProvider
    {
        DateTime Today { get; }

        DateTime Now { get; }
    }
}
