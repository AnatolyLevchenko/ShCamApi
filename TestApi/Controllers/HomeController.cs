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

        public ActionResult Index()
        {
            return Content("WebApi");
        }

    }
}
