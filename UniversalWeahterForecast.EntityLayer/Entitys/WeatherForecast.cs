﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalWeahterForecast.EntityLayer.Entitys
{
    public class WeatherForecast
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CelestialBodyId { get; set; }
        public int WeatherTypeId { get; set; }
        public int Temprature { get; set; }
        public DateTime? WeatherTime { get; set; }
    }
}
