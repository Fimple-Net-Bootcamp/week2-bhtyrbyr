using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.BusinessLayer.DTOs.CelestalBodyDTOs
{
    internal class ViewPlanetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CelestalBody> Satellites { get; set; }
    }
}
