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
    public class WeatherTypeManager : IWeatherTypeService
    {
        private readonly IWeatherTypeDal _dal;

        public WeatherTypeManager(IWeatherTypeDal dal)
        {
            _dal = dal;
        }

        public void TDelete(int id)
        {
            _dal.Delete(id);
        }

        public WeatherType TGetByID(int id)
        {
            return _dal.GetByID(id);
        }

        public List<WeatherType> TGetList()
        {
            return _dal.GetList();
        }

        public void TInsert(WeatherType t)
        {
            _dal.Insert(t);
        }

        public void TUpdate(WeatherType t)
        {
            _dal.Update(t);
        }
    }
}
