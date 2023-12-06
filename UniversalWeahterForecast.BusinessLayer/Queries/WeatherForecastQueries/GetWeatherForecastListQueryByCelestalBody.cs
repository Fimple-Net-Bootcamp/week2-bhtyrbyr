namespace UniversalWeahterForecast.BusinessLayer.Queries.WeatherForecastQueries
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
