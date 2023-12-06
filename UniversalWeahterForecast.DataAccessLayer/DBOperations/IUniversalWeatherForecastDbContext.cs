using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.DataAccessLayer.DBOperations
{
    public interface IUniversalWeatherForecastDbContext
    {
        DbSet<CelestalBody> CelestalBodies { get; set; }
        DbSet<WeatherForecast> WeatherForecasts { get; set; }
        DbSet<WeatherType> WeatherTypes { get; set; }
        int SaveChanges();
        EntityEntry Update(object entity);
        EntityEntry Remove(object entity);
    }
}
