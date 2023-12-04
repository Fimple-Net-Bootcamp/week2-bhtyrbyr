using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalWeahterForecast.EntityLayer.Entitys
{
    internal class WeatherForecast
    {
        internal int Id { get; set; }
        internal int CelestialBodyId { get; set; }
        internal WeatherTypes WeatherType { get; set; }
        internal DateTime? WeatherTime { get; set; }
    }
}
