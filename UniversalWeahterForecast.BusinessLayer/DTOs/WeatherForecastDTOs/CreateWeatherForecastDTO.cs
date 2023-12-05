using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.BusinessLayer.DTOs.WeatherForecastDTOs
{
    public class CreateWeatherForecastDTO
    {
        public int BodyId { get; set; }
        public int TypeId { get; set; }
        public int Temprature { get; set; }
        public DateTime? WeatherTime { get; set; }
    }
}
