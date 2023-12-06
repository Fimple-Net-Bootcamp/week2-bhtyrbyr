namespace UniversalWeahterForecast.BusinessLayer.Queries.CelestalBodyQueries
{
    public class GetCelestalBodyQuery
    {
        public GetCelestalBodyQuery()
        {
            SortingCriterion = new();
        }
        public string CelestalBodyType { get; set; }
        public List<string> SortingCriterion { get; set; }
    }
}
