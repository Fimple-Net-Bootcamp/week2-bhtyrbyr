using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalWeahterForecast.BusinessLayer.Abstract;
using UniversalWeahterForecast.BusinessLayer.DTOs.WeatherForecastDTOs;
using UniversalWeahterForecast.DataAccessLayer.Abstract;
using UniversalWeahterForecast.DataAccessLayer.DBOperations;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.BusinessLayer.Concrete
{
    public class WeatherForecastManager : IWeatherForecastService<WeatherForecast>
    {
        //private readonly IUniversalWeatherForecastDbContext _dbContext;
        private readonly ICelestalBodyDal _celestalBodyDal;
        private readonly IWeatherForecastDal _weatherForecastDal;
        private readonly IWeatherTypeDal _weatherTypeDal;
        private readonly IUniversalWeatherForecastDbContext _dbContext;
        private readonly IMapper _mapper;

        public WeatherForecastManager(ICelestalBodyDal celestalBodyDal, IWeatherForecastDal weatherForecastDal, IWeatherTypeDal weatherTypeDal, IUniversalWeatherForecastDbContext dbContext, IMapper mapper)
        {
            _celestalBodyDal = celestalBodyDal;
            _weatherForecastDal = weatherForecastDal;
            _weatherTypeDal = weatherTypeDal;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void TDelete(WeatherForecast t)
        {
            _weatherForecastDal.Delete(t);
        }

        public WeatherForecast TGetByID(int id)
        {
            return _weatherForecastDal.GetByID(id);
        }

        public List<ViewWeatherForecastDTO> TGetList()
        {
            var weatherForecasts = _weatherForecastDal.GetList();
            var celestalBodys = _celestalBodyDal.GetList();
            var weatherTypes = _weatherTypeDal.GetList();

            var list = _dbContext.WeatherForecasts.Include(x => x.Body).Include(x => x.Type).ToList();
            var olist = new List<ViewWeatherForecastDTO>(_mapper.Map<List<ViewWeatherForecastDTO>>(list));

            return olist;
        }

        public void TInsert(WeatherForecast t)
        {
            _weatherForecastDal.Insert(t);
        }

        public void TUpdate(WeatherForecast t)
        {
            _weatherForecastDal.Update(t);
        }
    }
}
