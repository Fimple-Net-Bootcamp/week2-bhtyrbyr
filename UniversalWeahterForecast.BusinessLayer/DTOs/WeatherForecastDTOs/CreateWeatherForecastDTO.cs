namespace UniversalWeahterForecast.BusinessLayer.DTOs.WeatherForecastDTOs
{
    public class CreateWeatherForecastDTO
    {
        public int BodyId { get; set; }
        public int TypeId { get; set; }
        public int Temprature { get; set; }
        public DateTime? WeatherTime { get; set; }
    }
}
