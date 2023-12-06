using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.DataAccessLayer.Abstract
{
    public interface ICelestalBodyDal
    {
        public IQueryable<CelestalBody> GetQuariable();
        void Insert(CelestalBody t);
        void Delete(int t);
        void Update(CelestalBody t);
        List<CelestalBody> GetList();
        CelestalBody GetByID(int id);
    }
}
