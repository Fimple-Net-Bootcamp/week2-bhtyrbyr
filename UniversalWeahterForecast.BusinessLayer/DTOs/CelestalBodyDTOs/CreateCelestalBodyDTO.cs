namespace UniversalWeahterForecast.BusinessLayer.DTOs.CelestalBodyDTOs
{
    public class CreateCelestalBodyDTO
    {
        public string Name { get; set; }
        public string CelestalBodyType { get; set; }
        public int AssociatedCelestalBody { get; set; }
    }
}
