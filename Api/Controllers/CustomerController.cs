using Api.Entities;
using Api.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Api.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerController(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var customers = await _customerRepository.GetAllAsync();
            return customers;
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var c = await _customerRepository.GetAsync(id);
            if (c == null)
                return NotFound();
            return Ok(c);
        }

        public async Task<IHttpActionResult> Post([FromBody]Customer value)
        {
            var customer = await _customerRepository.InsertAsync(value);
            return CreatedAtRoute("DefaultApi", new { Id = customer.Id }, customer);
        }

        public async Task<IHttpActionResult> Delete(int id)
        {
            await _customerRepository.DeleteRowAsync(id);
            return Ok();
        }


        public async Task<OkResult> Patch([FromBody]Customer customer)
        {
            await _customerRepository.UpdateAsync(customer);
            return Ok();
        }



    }
}
