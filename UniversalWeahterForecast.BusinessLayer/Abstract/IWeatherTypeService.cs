﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalWeahterForecast.BusinessLayer.DTOs.WeatherForecastDTOs;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.BusinessLayer.Abstract
{
    public interface IWeatherTypeService
    {
        void TInsert(WeatherType t);
        void TDelete(int id);
        void TUpdate(WeatherType t);
        List<WeatherType> TGetList();
        WeatherType TGetByID(int id);
    }
}
