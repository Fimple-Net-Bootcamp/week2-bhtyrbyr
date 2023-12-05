using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalWeahterForecast.BusinessLayer.Abstract;
using UniversalWeahterForecast.DataAccessLayer.EntityFramework;
using UniversalWeahterForecast.DataAccessLayer.Abstract;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.BusinessLayer.Concrete
{
    public class CelestalBodyManager : ICelestalBodyService
    {
        private readonly ICelestalBodyDal _dal;

        public CelestalBodyManager(ICelestalBodyDal dal)
        {
            _dal = dal;
        }

        public void TDelete(int id)
        {
            _dal.Delete(id);
        }

        public CelestalBody TGetByID(int id)
        {
            return _dal.GetByID(id);
        }

        public List<CelestalBody> TGetList()
        {
            return _dal.GetList();
        }

        public void TInsert(CelestalBody t)
        {
            _dal.Insert(t);
        }

        public void TUpdate(CelestalBody t)
        {
            _dal.Update(t);
        }
    }
}
