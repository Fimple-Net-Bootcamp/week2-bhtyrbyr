using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.DataAccessLayer.Abstract
{
    public interface IWeatherForecastDal : IGenericDal<WeatherForecast>
    {
    }
}
