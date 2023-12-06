namespace UniversalWeahterForecast.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T t);
        void Delete(int t);
        void Update(T t);
        List<T> GetList();
        T GetByID(int id);
    }
}
