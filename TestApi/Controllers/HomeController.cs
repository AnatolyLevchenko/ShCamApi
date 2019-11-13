using System.Threading.Tasks;
using System.Web.Mvc;
using TestApi.Entities;
using TestApi.Repositories;

namespace TestApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Customer> _customerRepository;

        public HomeController(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ActionResult> Index()
        {
            var res = await _customerRepository.GetAllAsync();
            return Json(res, JsonRequestBehavior.AllowGet);


            return View();
        }

        public async Task<ActionResult> Insert()
        {
            await _customerRepository.InsertAsync(new Customer() { Name = "valera", PathToRootOfFiles = "lal" });

            return Content("OK");
        }
    }
}
