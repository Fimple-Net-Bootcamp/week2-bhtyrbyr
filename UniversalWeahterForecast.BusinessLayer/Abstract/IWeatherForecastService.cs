using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalWeahterForecast.BusinessLayer.DTOs.WeatherForecastDTOs;
using UniversalWeahterForecast.BusinessLayer.Queries;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.BusinessLayer.Abstract
{
    public interface IWeatherForecastService
    {
        //void TInsert(WeatherForecast t);
        void TDelete(int id);
        //void TUpdate(WeatherForecast t);
        List<ViewWeatherForecastDTO> TGetList(WeatherForecastGelAllQueries filters);
        ViewWeatherForecastDTO TGetById(int id);

        IQueryable<WeatherForecast> CreateQuery(WeatherForecastGelAllQueries filters);
    }
}
