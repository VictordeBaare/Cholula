using BoilerPlateCore.Common;
using BoilerPlateCore.Data.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace BoilerPlateCore.Specflow.Test.Mock
{
    public class EntityContextFactoryMock : IEntityContextFactory
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public EntityContextFactoryMock(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public EntityContext Create()
        {
            var options = new DbContextOptionsBuilder<EntityContext>()
                .UseInMemoryDatabase(databaseName: "BoilerPlateCoreDb")
                .Options;

            return new EntityContext(options, _dateTimeProvider);
        }
    }
}
