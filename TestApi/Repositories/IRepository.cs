using System.Collections.Generic;
using TestApi.Entities;

namespace TestApi.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        
        T GetById(int id);
        List<T> GetAll();
        void Insert(T entity);
        void Insert(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
    }
}
