using Microsoft.EntityFrameworkCore;
using UniversalWeahterForecast.DataAccessLayer.Abstract;
using UniversalWeahterForecast.DataAccessLayer.DBOperations;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.DataAccessLayer.EntityFramework
{
    public class EfWeatherForecastDal : IWeatherForecastDal
    {
        private readonly IUniversalWeatherForecastDbContext _context;
        public EfWeatherForecastDal(IUniversalWeatherForecastDbContext context)
        {
            _context = context;
        }
        public void Delete(int t)
        {
            var item = GetByID(t);
            if (item is null)
                throw new ArgumentNullException("Girilen ID'ye ait veri bulunamadı!");
            _context.Remove(item);
            _context.SaveChanges();

        }

        public WeatherForecast GetByID(int id)
        {
            var item = _context.WeatherForecasts.Include(x => x.Body).Include(x => x.Type).SingleOrDefault(x => x.Id == id);
            if (item.Id == 0)
                throw new ArgumentNullException("Girilen ID'ye ait veri bulunamadı!");
            return item;
        }

        public List<WeatherForecast> GetList()
        {
            return _context.WeatherForecasts.ToList();
        }

        public IQueryable<WeatherForecast> GetQuariable()
        {
            return _context.WeatherForecasts.AsQueryable();
        }

        public void Insert(WeatherForecast t)
        {
            try
            {
                if (!_context.CelestalBodies.Any(x => x.Id == t.Id)) throw new InvalidOperationException("Geçerli bir gök cismi ID'si giriniz!");
                if (!_context.WeatherTypes.Any(x => x.Id == t.Id)) throw new InvalidOperationException("Tanımlı bir hava olayı ID'si giriniz!");
                _context.WeatherForecasts.Add(t);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(WeatherForecast t)
        {
            try
            {
                _context.Update(t);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new MissingFieldException("Veri kaydedilirken bir hata oluştu!");
            }
        }
    }
}
