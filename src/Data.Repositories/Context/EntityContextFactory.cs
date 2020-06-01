using BoilerPlateCore.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BoilerPlateCore.Data.Repositories.Context
{
    public class EntityContextFactory : IEntityContextFactory
    {
        private readonly IConfiguration _configuration;
        private readonly IDateTimeProvider _dateTimeProvider;

        public EntityContextFactory(IConfiguration configuration, IDateTimeProvider dateTimeProvider)
        {
            _configuration = configuration;
            _dateTimeProvider = dateTimeProvider;
        }

        public EntityContext Create()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<EntityContext>();
            dbContextOptionsBuilder.UseSqlServer(_configuration.GetConnectionString("BoilerPlateCoreConnectionString"));
            var context = new EntityContext(dbContextOptionsBuilder.Options, _dateTimeProvider);
#if DEBUG
            context.Database.EnsureCreated();
#endif
            return context;
        }
    }
}
