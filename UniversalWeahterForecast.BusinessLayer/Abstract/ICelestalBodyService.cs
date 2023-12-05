
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.BusinessLayer.Abstract
{
    public interface ICelestalBodyService
    {
        void TInsert(CelestalBody t);
        void TDelete(int id);
        void TUpdate(CelestalBody t);
        List<CelestalBody> TGetList();
        CelestalBody TGetByID(int id);
    }
}
