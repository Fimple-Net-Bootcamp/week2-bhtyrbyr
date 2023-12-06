using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalWeahterForecast.BusinessLayer.Queries
{
    public class GetWeatherForecastListQueryByCelestalBody
    {
        public GetWeatherForecastListQueryByCelestalBody()
        {
            Sort = new();
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> Sort { get; set; }
    }
}
