
using Microsoft.AspNetCore.JsonPatch;
using UniversalWeahterForecast.BusinessLayer.DTOs.CelestalBodyDTOs;
using UniversalWeahterForecast.BusinessLayer.Queries;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.BusinessLayer.Abstract
{
    public interface ICelestalBodyService
    {
        int TInsert(CreateCelestalBodyDTO t);
        void TDelete(int id);
        void TUpdate(int id, UpdateCelestalBodyDTO model);
        void TUpdate(int id, JsonPatchDocument<CelestalBody> model);
        List<ViewCelestalBodyDTO> TGetList(GetCelestalBodyQuery filter);
        ViewCelestalBodyDTO TGetByID(int id);
    }
}
