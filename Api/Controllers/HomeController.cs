using System.Web.Mvc;
using Api.Entities;
using Api.Repositories;

namespace Api.Controllers
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
