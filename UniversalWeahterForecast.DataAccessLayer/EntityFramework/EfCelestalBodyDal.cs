using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalWeahterForecast.DataAccessLayer.DBOperations;
using UniversalWeahterForecast.DataAccessLayer.Abstract;
using UniversalWeahterForecast.DataAccessLayer.Repositories;
using UniversalWeahterForecast.EntityLayer.Entitys;
using Microsoft.EntityFrameworkCore;

namespace UniversalWeahterForecast.DataAccessLayer.EntityFramework
{
    public class EfCelestalBodyDal : ICelestalBodyDal
    {
        private readonly IUniversalWeatherForecastDbContext _context;
        public EfCelestalBodyDal(IUniversalWeatherForecastDbContext context)
        {
            _context = context;
        }

        public IQueryable<CelestalBody> GetQuariable()
        {
            return _context.CelestalBodies.AsQueryable();
        }

        public void Delete(int t)
        {
            var item = GetByID(t);
            if (item is null)
                throw new ArgumentNullException("Girilen ID'ye ait veri bulunamadı!");
            _context.Remove(item);
            _context.SaveChanges();

        }

        public CelestalBody GetByID(int id)
        {
            var item = _context.CelestalBodies.SingleOrDefault(x => x.Id == id);
            if (item is null)
                throw new ArgumentNullException("Girilen ID'ye ait veri bulunamadı!");
            return item;
        }

        public List<CelestalBody> GetList()
        {
            return _context.CelestalBodies.ToList();
        }

        public void Insert(CelestalBody t)
        {
            try
            {
                _context.CelestalBodies.Add(t);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(CelestalBody t)
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
