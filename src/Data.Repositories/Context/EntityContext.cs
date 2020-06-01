using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BoilerPlateCore.Common;
using BoilerPlateCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoilerPlateCore.Data.Repositories.Context
{
    public class EntityContext : DbContext
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public EntityContext(DbContextOptions options, IDateTimeProvider dateTimeProvider) : base(options)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public DbSet<WeatherForecast> WeatherForecast { get; set; }

        public override int SaveChanges()
        {
            UpdateModified();
            return base.SaveChanges();
        }        

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateModified();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateModified()
        {
            var changes = ChangeTracker.Entries().Where(e => e.Entity is EntityBase && (e.State == EntityState.Modified || e.State == EntityState.Added));
            foreach(var entry in changes)
            {
                var entity = entry.Entity as EntityBase;
                entity.ModifiedOn = _dateTimeProvider.Now;
                entity.ModifiedOnUtc = _dateTimeProvider.Now;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherForecast>()
                .HasData(new WeatherForecast { Id = 1, Date = DateTime.Today, TemperatureC = 20, Summary = "Warm" }, 
                         new WeatherForecast { Id = 2, Date = DateTime.Today.AddDays(1), TemperatureC = 30, Summary = "Balmy" },
                         new WeatherForecast { Id = 3, Date = DateTime.Today.AddDays(2), TemperatureC = 40, Summary = "Hot" },
                         new WeatherForecast { Id = 4, Date = DateTime.Today.AddDays(3), TemperatureC = 50, Summary = "Sweltering" },
                         new WeatherForecast { Id = 5, Date = DateTime.Today.AddDays(4), TemperatureC = 60, Summary = "Scorching" }
                         );

            base.OnModelCreating(modelBuilder);
        }
    }
}
