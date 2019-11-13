using System.Collections.Generic;
using TestApi.Entities;
using static TestApi.Repositories.DapperExtensions;

namespace TestApi.Repositories
{
    public  class DapperRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly string _connectionString;

        public DapperRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public T GetById(int id)
        {
            return QueryFirst<T>($"select * from {typeof(T).Name} where Id={id}", _connectionString);
        }

        public List<T> GetAll()
        {
            return Query<T>($"select * from {typeof(T).Name}", _connectionString);
        }

        public void Insert(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(IEnumerable<T> entities)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(IEnumerable<T> entities)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(IEnumerable<T> entities)
        {
            throw new System.NotImplementedException();
        }

    }
}
