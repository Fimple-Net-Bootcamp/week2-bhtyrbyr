namespace UniversalWeahterForecast.BusinessLayer.Queries
{
    public class GetWeatherForeceastListQuery
    {
        public GetWeatherForeceastListQuery()
        {
            Sort = new();
            DelistingIds = new();
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> Sort { get; set; }
        public List<int> DelistingIds { get; set; }
    }
}
