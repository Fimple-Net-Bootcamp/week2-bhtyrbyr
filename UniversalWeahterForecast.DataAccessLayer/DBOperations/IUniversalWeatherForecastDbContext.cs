using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.DataAccessLayer.DBOperations
{
    public interface IUniversalWeatherForecastDbContext
    {
        DbSet<CelestalBody> CelestalBodies { get; set; }
        DbSet<WeatherForecast> WeatherForecasts { get; set; }
        DbSet<WeatherTypes> WeatherTypes { get; set; }
        int SaveChanges();
    }
}
