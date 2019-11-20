using Api.Entities;
using Api.Repositories;
using System.Web.Http;

namespace Api.Controllers
{
    public class BaseApiController : ApiController
    {
        public User User
        {
            get
            {
                return null;
                //var repository=new DapperRepository<Tokens>(Helper.ConnectionString);

                //var present = Request.Headers.TryGetValues("token", out var token);
                //if (present == false)
                //    return null;

                //var fromDb= repository.Filter("Token", string.Join("",token));

                //return fromDb?.UserId ?? 0;
            }
        }
    }
}