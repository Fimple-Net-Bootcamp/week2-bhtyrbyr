using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalWeahterForecast.BusinessLayer.DTOs.WeatherForecastDTOs;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.BusinessLayer.Abstract
{
    public interface IWeatherForecastService<T> where T : class
    {
        void TInsert(T t);
        void TDelete(T t);
        void TUpdate(T t);
        List<ViewWeatherForecastDTO> TGetList();
        T TGetByID(int id);
    }
}
