using System.Collections.Generic;

namespace PostBridge.Domain
{
    public interface IBaseRepository<T>
    {
        void Create(T entity);
        void Create(IEnumerable<T> entities);
        T GetById(long id);
        List<T> GetAll();
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(IEnumerable<long> ids);
    }
}
