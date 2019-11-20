using Api.Entities;
using Api.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Api
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            IEnumerable<string> access_token;

            if (!actionContext.Request.Headers.TryGetValues("token", out access_token))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return;
            }

            IRepository<Tokens> repo = new TokensRepository();
            var token=repo.Filter("Token", string.Join("",access_token));


            if (token == null || DateTime.UtcNow>token.ExpiredUTC)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return;
            }

            // OK
            return;
        }
    }
}