using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalWeahterForecast.BusinessLayer.DTOs.CelestalBodyDTOs
{
    public class CreateCelestalBodyDTO
    {
        public string Name { get; set; }
        public bool CelestalBodyType { get; set; }
        public int WhoseSatellite { get; set; }
    }
}
