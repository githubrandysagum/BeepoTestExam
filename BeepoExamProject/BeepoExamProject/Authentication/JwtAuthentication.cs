using BeepoExamProject.BusinessLayer;
using BeepoExamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BeepoExamProject.Authentication
{
    public class JwtAuthentication : AuthorizationFilterAttribute
    {
        UserRepository _db = new UserRepository();
      


        public override void OnAuthorization(HttpActionContext context)
        {
            var request = context.Request;
            var authorization = request.Headers.Authorization;

            if (authorization == null || authorization.Scheme != "Bearer")
            {
                 context.Response = context.Request.CreateResponse(HttpStatusCode.Unauthorized);

            }else if (string.IsNullOrEmpty(authorization.Parameter))
            {
                context.Response = context.Request.CreateResponse(HttpStatusCode.Unauthorized);

            }
            else
            {
                string authToken = context.Request.Headers.Authorization.Parameter;


                var user  = JwtManager.ValidateToken(authToken);
                
                if(user == null)
                {
                    context.Response = context.Request.CreateResponse(HttpStatusCode.Unauthorized);

                }
              

            }



        }

       
    }
}