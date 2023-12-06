using System.ComponentModel.DataAnnotations.Schema;

namespace UniversalWeahterForecast.EntityLayer.Entitys
{
    public class WeatherType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
