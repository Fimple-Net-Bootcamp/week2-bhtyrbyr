using System.Linq.Dynamic.Core;
using UniversalWeahterForecast.BusinessLayer.Abstract;
using UniversalWeahterForecast.DataAccessLayer.Abstract;
using UniversalWeahterForecast.EntityLayer.Entitys;
using UniversalWeahterForecast.BusinessLayer.DTOs.CelestalBodyDTOs;
using AutoMapper;
using UniversalWeahterForecast.BusinessLayer.Queries;
using UniversalWeahterForecast.BusinessLayer.DTOs.Validator.CelestalBodyValidator;
using FluentValidation;

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

            if (string.Equals(filters.CelestalBodyType, "planet")) query = query.Where(x => x.IsPlanet == true);
            else if (string.Equals(filters.CelestalBodyType, "satellite")) query = query.Where(x => x.IsPlanet == false);

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

        public int TInsert(CreateCelestalBodyDTO t)
        {
            CreateCelestalBodyDTOValidator validator = new();
            validator.ValidateAndThrow(t);
            var item = _mapper.Map<CelestalBody>(t);
            _dal.Insert(item);
            return item.Id;
        }

        public void TUpdate(int id, UpdateCelestalBodyDTO model)
        {
            var item = _dal.GetByID(id);
            if (item is null) throw new InvalidDataException("Girilen ID'ye ait kayıt bulunamadı!");
            item.Name = model.Name == "string" ? item.Name : model.Name;
            if      (model.CelestalBodyType == "planet")        
                item.IsPlanet = true;
            else if (model.CelestalBodyType == "satellite")     
                item.IsPlanet = false;
            item.WhoseSatellite = Convert.ToInt32(model.AssociatedCelestalBody);
            _dal.Update(item);
        }
    }
}
