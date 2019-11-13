using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Api.Entities;
using Api.Repositories;

namespace Api.Controllers
{
    public class SupplierController : ApiController
    {
        private readonly IRepository<Supplier> _supplier;

        public SupplierController(IRepository<Supplier> supplier)
        {
            _supplier = supplier;
        }

        public async Task<IEnumerable<Supplier>> GetAll()
        {
            return await _supplier.GetAllAsync();
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var s = await _supplier.GetAsync(id);
            if (s == null)
                return NotFound();
            return Ok();
        }

        public async Task<IHttpActionResult> Post([FromBody]Supplier value)
        {
            var supplier = await _supplier.InsertAsync(value);
            return CreatedAtRoute("DefaultApi", new {supplier.Id }, supplier);
        }

        public async Task<IHttpActionResult> Delete(int id)
        {
            await _supplier.DeleteRowAsync(id);
            return Ok();
        }

        public async Task<OkResult> Patch([FromBody]Supplier s)
        {
            await _supplier.UpdateAsync(s);
            return Ok();
        }

    }
}
