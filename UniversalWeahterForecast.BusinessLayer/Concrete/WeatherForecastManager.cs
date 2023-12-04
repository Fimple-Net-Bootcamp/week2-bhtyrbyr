using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalWeahterForecast.BusinessLayer.Abstract;
using UniversalWeahterForecast.DataAccessLayer.Abstract;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.BusinessLayer.Concrete
{
    internal class WeatherForecastManager : IWeatherForecastService
    {
        private readonly IWeatherForecastDal _dal;

        public WeatherForecastManager(IWeatherForecastDal dal)
        {
            _dal = dal;
        }

        public void TDelete(WeatherForecast t)
        {
            _dal.Delete(t);
        }

        public WeatherForecast TGetByID(int id)
        {
            return _dal.GetByID(id);
        }

        public List<WeatherForecast> TGetList()
        {
            return _dal.GetList();
        }

        public void TInsert(WeatherForecast t)
        {
            _dal.Insert(t);
        }

        public void TUpdate(WeatherForecast t)
        {
            _dal.Update(t);
        }
    }
}
