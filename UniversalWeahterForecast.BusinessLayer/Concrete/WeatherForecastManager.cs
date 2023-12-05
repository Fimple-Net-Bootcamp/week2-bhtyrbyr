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
    public class WeatherForecastManager : IWeatherForecastService
    {
        private readonly IUniversalWeatherForecastDbContext _dbContext;
        private readonly IMapper _mapper;

        public WeatherForecastManager(IUniversalWeatherForecastDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        /*
        public void TDelete(WeatherForecast t)
        {
            _weatherForecastDal.Delete(t);
        }
        */
        public ViewWeatherForecastDTO TGetByID(int id)
        {
            // Verilerin alınması
            var item = _dbContext.WeatherForecasts.Include(x => x.Body).Include(x => x.Type).SingleOrDefault(record => record.Id == id);

            // Filtrelerin uygulanması
            var itemDTO = _mapper.Map<ViewWeatherForecastDTO>(item);

            return itemDTO;
        }
        
        public List<ViewWeatherForecastDTO> TGetList(Dictionary<string, string> filters)
        {
            // Verilerin alınması
            var list = _dbContext.WeatherForecasts.Include(x => x.Body).Include(x => x.Type).ToList();

            foreach(var filter in filters)
            {
                Console.WriteLine($"{filter.Key} {filter.Value}");
            }

            // Filtrelerin uygulanması
            var olist = new List<ViewWeatherForecastDTO>(_mapper.Map<List<ViewWeatherForecastDTO>>(list));
            return olist;
        }
        /*
        public void TInsert(WeatherForecast t)
        {
            _weatherForecastDal.Insert(t);
        }

        public void TUpdate(WeatherForecast t)
        {
            _weatherForecastDal.Update(t);
        }*/
    }
}
