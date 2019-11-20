using Api.Entities;
using Api.Repositories;
using System.Web.Http;

namespace Api.Controllers
{
    public class BaseApiController : ApiController
    {
        public new User User
        {
            get
            {
                var repository = new UserRepository();

                var present = Request.Headers.TryGetValues("token", out var token);
                if (present == false)
                    return null;

                return repository.FindUserByToken(string.Join("",token));
            }
        }
    }
}