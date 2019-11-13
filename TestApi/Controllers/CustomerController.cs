using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TestApi.Entities;
using TestApi.Repositories;

namespace TestApi.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerController(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>>Get()
        {
           var customers= await _customerRepository.GetAllAsync();
           return customers;
        }

        public async Task<Customer> Get(int id)
        {
            return await _customerRepository.GetAsync(id);
        }

        // POST api/values
        public async void Post([FromBody]Customer value)
        {
            await _customerRepository.InsertAsync(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
