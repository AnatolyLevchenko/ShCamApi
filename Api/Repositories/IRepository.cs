using Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task DeleteByIdAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T t);
        Task<T> InsertAsync(T t);
        T Filter(string column, object value);
    }
}
