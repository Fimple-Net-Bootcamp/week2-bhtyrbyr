using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using UniversalWeahterForecast.BusinessLayer.Abstract;
using UniversalWeahterForecast.BusinessLayer.DTOs.WeatherForecastDTOs;
using UniversalWeahterForecast.BusinessLayer.Queries;
using UniversalWeahterForecast.DataAccessLayer.DBOperations;

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
        
        public List<ViewWeatherForecastDTO> TGetList(WeatherForecastGelAllQueries filters)
        {
            // Sorgunun Hazırlanması - Başlangıç
            var query = _dbContext.WeatherForecasts.AsQueryable();
            if ((filters.StartDate > filters.EndDate) && (filters.EndDate != DateTime.MinValue))
            {
                throw new ArgumentOutOfRangeException("Başlangıç tarihi, bitiş tarihinden sonra olamaz!");
            }
            else if (filters.StartDate != DateTime.MinValue && filters.EndDate != DateTime.MinValue)
            {
                query = query.Where(record => record.WeatherTime >= filters.StartDate).Where(record => record.WeatherTime <=  filters.EndDate);
            }
            else
            {
                if      (filters.StartDate != DateTime.MinValue) query = query.Where(record => record.WeatherTime >= filters.StartDate);
                else if (filters.EndDate   != DateTime.MinValue) query = query.Where(record => record.WeatherTime <= filters.EndDate);
            }
            foreach (var item in filters.Sort)
            {
                List<string> sortDirection = item.Split(',').ToList();
                if (sortDirection[1] == "asc")
                {
                    query = query.OrderBy(sortDirection[0]);
                }
                else if (sortDirection[1] == "desc")
                {
                    query = query.OrderBy(sortDirection[0] + " descending");
                }
            }
            query = query.Where(x =>!filters.DelistingIds.Contains(x.BodyId));
            // Sorgunun Hazırlanması - Bitiş

            //Sorgunun yapılması ve verilerin birleştirilmesi
            var list = query.Include(x => x.Body).Include(x => x.Type).ToList();

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
