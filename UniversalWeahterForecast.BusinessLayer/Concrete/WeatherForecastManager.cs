using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using UniversalWeahterForecast.BusinessLayer.Abstract;
using UniversalWeahterForecast.BusinessLayer.DTOs.Validator.WeatherForecastValidator;
using UniversalWeahterForecast.BusinessLayer.DTOs.WeatherForecastDTOs;
using UniversalWeahterForecast.BusinessLayer.Queries;
using UniversalWeahterForecast.DataAccessLayer.Abstract;
using UniversalWeahterForecast.DataAccessLayer.DBOperations;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.BusinessLayer.Concrete
{
    public class WeatherForecastManager : IWeatherForecastService
    {
        //private readonly IUniversalWeatherForecastDbContext _dbContext;
        private readonly IWeatherForecastDal _dal;
        private readonly IMapper _mapper;

        public WeatherForecastManager(IUniversalWeatherForecastDbContext dbContext, IWeatherForecastDal dal, IMapper mapper)
        {
            //_dbContext = dbContext;
            _dal = dal;
            _mapper = mapper;
        }

        public IQueryable<WeatherForecast> CreateQuery(WeatherForecastGetQueries filters)
        {
            // Sorgunun Hazırlanması - Başlangıç

            var query = _dal.GetQuariable();
            if ((filters.EndDate > filters.StartDate) && (filters.EndDate != DateTime.MinValue))
            {
                if (filters.StartDate != DateTime.MinValue) query = query.Where(record => record.WeatherTime >= filters.StartDate);
                if (filters.EndDate != DateTime.MinValue)   query = query.Where(record => record.WeatherTime <= filters.EndDate);
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
            return query = query.Where(x => !filters.DelistingIds.Contains(x.BodyId));
        }
        
        public List<ViewWeatherForecastDTO> TGetList(WeatherForecastGetQueries filters)
        {
            // Sorgunun Hazırlanması 
            var query = CreateQuery(filters);

            //Sorgunun yapılması ve verilerin birleştirilmesi
            var list = query.Include(x => x.Body).Include(x => x.Type).ToList();

            // Filtrelerin uygulanması
            var olist = new List<ViewWeatherForecastDTO>(_mapper.Map<List<ViewWeatherForecastDTO>>(list));
            return olist;
        }

        public List<ViewWeatherForecastDTO> TGetListByCelestalBodyId(int id, WeatherForecastGetQueries filters, bool type)
        {
            // Sorgunun Hazırlanması 
            var query = CreateQuery(filters);

            //Sorgunun yapılması ve verilerin birleştirilmesi
            var list = query.Include(x => x.Body).Include(x => x.Type).Where(x => x.Body.Id == id && x.Body.IsPlanet == type).ToList();

            if (list.Count == 0) throw new InvalidDataException("Girilen ID'ye ait bir gök cismi bulunamadı!");
            // Filtrelerin uygulanması
            var olist = new List<ViewWeatherForecastDTO>(_mapper.Map<List<ViewWeatherForecastDTO>>(list));
            return olist;
        }

        public ViewWeatherForecastDTO TGetById(int id)
        {
            // Verilerin alınması
            var item = _dal.GetByID(id);
            if (item is null)
                throw new ArgumentNullException("Girilen ID'ye ait bir veri bulunmadı!");
            // Filtrelerin uygulanması
            var itemDTO = _mapper.Map<ViewWeatherForecastDTO>(item);

            return itemDTO;
        }


        public void TDelete(int id)
        {
           _dal.Delete(id);
        }
        

        public int TInsert(CreateWeatherForecastDTO t)
        {
            CreateWeatherForecastDTOValidator validator = new();
            validator.ValidateAndThrow(t);
            var model = _mapper.Map<WeatherForecast>(t);
            _dal.Insert(model);
            return model.Id;
        }
        
        public void TUpdate(int id, UpdateWeatherForecastDTO t)
        {
            UpdateWeatherForecastDTOValidator validator = new();
            var item = _dal.GetByID(id);
            if (item is null) throw new Exception("Girilen ID'ye ait güncellenebilir bir veri bulunamadı!");
            validator.ValidateAndThrow(t);
            item.BodyId = t.BodyId == default ? item.BodyId : t.BodyId;
            item.TypeId = t.TypeId == default ? item.TypeId : t.TypeId;
            item.Temprature = t.Temprature == default ? item.Temprature : t.Temprature;
            _dal.Update(item);
        }
    }
}
