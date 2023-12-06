using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.DataAccessLayer.DBOperations
{
    public class UniversalWeatherForecastDbContext : DbContext, IUniversalWeatherForecastDbContext
    {
        public UniversalWeatherForecastDbContext(DbContextOptions<UniversalWeatherForecastDbContext> options) : base(options)
        { }

        public DbSet<CelestalBody> CelestalBodies { get; set; }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        public DbSet<WeatherType> WeatherTypes { get; set; }


        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override EntityEntry Update(object entity)
        {
            return base.Update(entity);
        }

        public override EntityEntry Remove(object entity)
        {
            return base.Remove(entity);
        }
    }
}
