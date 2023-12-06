using System.Linq.Dynamic.Core;
using UniversalWeahterForecast.BusinessLayer.Abstract;
using UniversalWeahterForecast.DataAccessLayer.Abstract;
using UniversalWeahterForecast.EntityLayer.Entitys;
using UniversalWeahterForecast.BusinessLayer.DTOs.CelestalBodyDTOs;
using AutoMapper;
using UniversalWeahterForecast.BusinessLayer.Queries;

namespace UniversalWeahterForecast.BusinessLayer.Concrete
{
    public class CelestalBodyManager : ICelestalBodyService
    {
        private readonly ICelestalBodyDal _dal;
        private readonly IMapper _mapper;

        public CelestalBodyManager(ICelestalBodyDal dal, IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }

        private IQueryable<CelestalBody> CreateQuery(GetCelestalBodyQuery filters)
        {
            // Sorgunun Hazırlanması - Başlangıç

            var query = _dal.GetQuariable();

            if (string.Equals(filters.CelestalBodyType, "planet"))          query = query.Where(x => x.IsPlanet == true);
            else if (string.Equals(filters.CelestalBodyType, "satellite"))  query = query.Where(x => x.IsPlanet == false);

            foreach (var item in filters.SortingCriterion)
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

            return query;
        }

        public void TDelete(int id)
        {
            _dal.Delete(id);
        }

        public ViewCelestalBodyDTO TGetByID(int id)
        {
            var item = _dal.GetByID(id);
            return _mapper.Map<ViewCelestalBodyDTO>(item);
        }

        public List<ViewCelestalBodyDTO> TGetList(GetCelestalBodyQuery filter)
        {
            var query = CreateQuery(filter);
            var list = query.ToList();
            return new List<ViewCelestalBodyDTO>(_mapper.Map<List<ViewCelestalBodyDTO>>(list));
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
