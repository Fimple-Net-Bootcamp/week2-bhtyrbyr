using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalWeahterForecast.DataAccessLayer.Abstract;
using UniversalWeahterForecast.DataAccessLayer.DBOperations;

namespace UniversalWeahterForecast.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly UniversalWeatherForecastDbContext _context;

        public GenericRepository(UniversalWeatherForecastDbContext context)
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

        public T GetByID(int id)
        {
            var item = _context.Set<T>().Find(id);
            if (item is null)
                throw new ArgumentNullException("Girilen ID'ye ait veri bulunamadı!");
            return item;
        }

        public List<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            try
            {
                _context.Add(t);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new MissingFieldException("Veri kaydedilirken bir hata oluştu!");
            }
        }

        public void Update(T t)
        {
            try
            {
                _context.Update(t);
                _context.SaveChanges();
            }catch(Exception ex)
            {
                throw new MissingFieldException("Veri kaydedilirken bir hata oluştu!");
            }
        }
    }
}
