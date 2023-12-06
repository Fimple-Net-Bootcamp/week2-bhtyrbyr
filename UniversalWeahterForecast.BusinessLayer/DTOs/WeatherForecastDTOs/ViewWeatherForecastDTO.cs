namespace UniversalWeahterForecast.BusinessLayer.DTOs.WeatherForecastDTOs
{
    public class ViewWeatherForecastDTO
    {
        public int Id { get; set; }
        public int BodyId { get; set; }
        public string BodyName { get; set; }
        public string TypeName { get; set; }
        public int Temprature { get; set; }
        public string WeatherTime { get; set; }
    }
}
