using BeepoExamProject.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BeepoExamProject.ControllersApi
{
    public class AuthenticationController : ApiController
    {
        [EnableCors("*", "*", "*")]
        [JwtAuthentication]
        [HttpGet]
        public bool Get()
        {
                return true;
        }
    }
}
