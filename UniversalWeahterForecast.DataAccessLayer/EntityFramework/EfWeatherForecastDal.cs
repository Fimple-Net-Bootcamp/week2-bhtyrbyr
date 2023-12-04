using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalWeahterForecast.DataAccessLayer.Abstract;
using UniversalWeahterForecast.DataAccessLayer.DBOperations;
using UniversalWeahterForecast.DataAccessLayer.Repositories;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.DataAccessLayer.EntityFramework
{
    public class EfWeatherForecastDal : GenericRepository<WeatherForecast>, IWeatherForecastDal
    {
        public EfWeatherForecastDal(UniversalWeatherForecastDbContext context) : base(context)
        {
        }
    }
}
