using System.ComponentModel.DataAnnotations.Schema;

namespace UniversalWeahterForecast.EntityLayer.Entitys
{
    public class CelestalBody
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPlanet { get; set; }
        public int WhoseSatellite { get; set; }
    }
}
