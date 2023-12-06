using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalWeahterForecast.BusinessLayer.DTOs.CelestalBodyDTOs
{
    public class ViewCelestalBodyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CelestalBodyType { get; set; }
        public string AssociatedCelestalBody { get; set; }
    }
}
