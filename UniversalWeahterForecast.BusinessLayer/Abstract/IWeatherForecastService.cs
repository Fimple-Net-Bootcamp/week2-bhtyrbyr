using UniversalWeahterForecast.BusinessLayer.DTOs.WeatherForecastDTOs;
using UniversalWeahterForecast.BusinessLayer.Queries;

namespace UniversalWeahterForecast.BusinessLayer.Abstract
{
    public interface IWeatherForecastService
    {
        int TInsert(CreateWeatherForecastDTO t);
        void TDelete(int id);
        void TUpdate(int id, UpdateWeatherForecastDTO t);
        List<ViewWeatherForecastDTO> TGetList(WeatherForecastGetQueries filters);
        ViewWeatherForecastDTO TGetById(int id);
    }
}
