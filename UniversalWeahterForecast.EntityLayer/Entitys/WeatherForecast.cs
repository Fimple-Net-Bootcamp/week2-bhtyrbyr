using System.ComponentModel.DataAnnotations.Schema;

namespace UniversalWeahterForecast.EntityLayer.Entitys
{
    public class WeatherForecast
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BodyId { get; set; }
        public CelestalBody Body { get; set; }
        public int TypeId { get; set; }
        public WeatherType Type { get; set; }
        public int Temprature { get; set; }
        public DateTime? WeatherTime { get; set; }
    }
}
