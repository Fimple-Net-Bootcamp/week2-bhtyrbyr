using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.DataAccessLayer.Abstract
{
    public interface IWeatherForecastDal
    {
        IQueryable<WeatherForecast> GetQuariable();
        void Insert(WeatherForecast t);
        void Delete(int t);
        void Update(WeatherForecast t);
        List<WeatherForecast> GetList();
        WeatherForecast GetByID(int id);
    }
}
