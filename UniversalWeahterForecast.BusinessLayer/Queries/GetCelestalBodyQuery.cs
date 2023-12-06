using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalWeahterForecast.BusinessLayer.Queries
{
    public class GetCelestalBodyQuery
    {
        public GetCelestalBodyQuery()
        {
            SortingCriterion = new();
        }
        public string? CelestalBodyType { get; set; }
        public List<string> SortingCriterion { get; set; }
    }
}
