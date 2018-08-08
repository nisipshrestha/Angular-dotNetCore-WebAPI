using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace WebApi.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        int Add(T t);

        List<T> GetAll();

        T Get(int id);

        int Edit(T t, int id);

        int Delete(int id);
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        IConfiguration _configuration;

        public GenericRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnection() =>
            _configuration.GetConnectionString("ProductContext");

        public int Add(T t)
        {
            throw new System.NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public int Edit(T t, int id)
        {
            throw new System.NotImplementedException();
        }

        public T Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
