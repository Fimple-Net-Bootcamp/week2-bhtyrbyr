using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
        DbSet<WeatherType> WeatherTypes { get; set; }
        int SaveChanges();
    }
}
