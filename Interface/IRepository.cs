using RestauranteAPI.Entity;

namespace RestauranteAPI.Interface
{
    public interface IRepository<T> where T : Entidade
    {
        IList<T> GetAll();
        T GetById(int id);
        void AddNew(T entidade);
        void Update(T entidade);
        void Delete(int id);
    }
}
