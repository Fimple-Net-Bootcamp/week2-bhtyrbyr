using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
