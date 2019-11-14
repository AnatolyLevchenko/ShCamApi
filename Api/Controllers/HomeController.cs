using Api.Auth;
using Api.Entities;
using Api.Repositories;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Tokens> _tokensRepository;

        public HomeController(IRepository<User> userRepository, IRepository<Tokens> tokensRepository)
        {
            _userRepository = userRepository;
            _tokensRepository = tokensRepository;
        }

        public ActionResult Index()
        {
            return Content("WebApi");
        }

        public async Task<JsonResult> Register(string login, string password)
        {
            var user = new User { Login = login, Password = password };
            var exist = _userRepository.Filter(nameof(user.Login), login);

            string message;

            if (exist != null)
            {
                message = "User already exists";
            }
            else
            {
                try
                {
                    var salt = EncryptionHelper.CreateSaltKey(50);
                    var hash = EncryptionHelper.CreatePasswordHash(user.Password, salt);
                    user.Salt = salt;
                    user.Password = hash;
                    user.RoleId = user.CustomerId = 6;

                    await _userRepository.InsertAsync(user);
                    message = "OK";
                }
                catch (Exception e)
                {
                    message = e.Message;
                }
            }


            return Json(message, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Authorize(string login, string password)
        {
            var user = _userRepository.Filter("Login", login);

            if (user != null)
            {
                if (string.Equals(user.Password, EncryptionHelper.CreatePasswordHash(password, user.Salt)))
                {
                    var tokens = new Tokens
                    {
                        UserId = user.Id,
                        ExpiredUTC = DateTime.UtcNow.AddHours(1),
                        Token = EncryptionHelper.CreateSaltKey(100)
                    };
                    var res = _tokensRepository.InsertAsync(tokens);

                    return Json(new { res }, JsonRequestBehavior.AllowGet);
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
        }

    }
}
