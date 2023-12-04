using HotelProject.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.DataAccessLayer.Abstract
{
    internal interface IWeatherTypeDal : IGenericDal<WeatherType>
    {
    }
}
