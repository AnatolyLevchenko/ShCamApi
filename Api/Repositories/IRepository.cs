using Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task DeleteRowAsync(int id);
        Task<T> GetAsync(int id);
        Task<int> SaveRangeAsync(IEnumerable<T> list);
        Task UpdateAsync(T t);
        Task<T> InsertAsync(T t);
        T Filter(string column, object value);
    }
}
