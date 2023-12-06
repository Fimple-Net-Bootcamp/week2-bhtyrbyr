using Microsoft.AspNetCore.JsonPatch;
using UniversalWeahterForecast.BusinessLayer.DTOs.WeatherForecastDTOs;
using UniversalWeahterForecast.BusinessLayer.Queries.WeatherForecastQueries;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.BusinessLayer.Abstract
{
    public interface IWeatherForecastService
    {
        int TInsert(CreateWeatherForecastDTO t);
        void TDelete(int id);
        void TUpdate(int id, UpdateWeatherForecastDTO t);
        void TUpdate(int id, JsonPatchDocument<WeatherForecast> t);
        List<ViewWeatherForecastDTO> TGetList(GetWeatherForeceastListQuery filters);
        List<ViewWeatherForecastDTO> TGetListByCelestalBodyId(int id, GetWeatherForecastListQueryByCelestalBody filters);
        ViewWeatherForecastDTO TGetById(int id);
    }
}
