using BeepoExamProject.Authentication;
using BeepoExamProject.BusinessLayer;
using BeepoExamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BeepoExamProject.ControllersApi
{
    [AllowAnonymous]
    [EnableCors("*", "*", "*")]

    public class LoginController : ApiController
    {
        IBusinessLayer<tblUser> _db;

        public LoginController(IBusinessLayer<tblUser> db)
        {
            _db = db;
        }
        [HttpPost]
        public HttpResponseMessage Login([FromBody]tblUser user)
        {
            tblUser u = new UserRepository().GetUser(user.strUserName);
            if (u == null)
                return Request.CreateResponse(HttpStatusCode.NotFound,
                     "The user was not found.");
            bool credentials = u.strPassword.Equals(user.strPassword);
            if (!credentials) return Request.CreateResponse(HttpStatusCode.Forbidden,
                "The username/password combination was wrong.");
            return Request.CreateResponse(HttpStatusCode.OK,
                 JwtManager.GenerateToken(user.strUserName));
        }

        [HttpGet]
        public HttpResponseMessage Validate(string token, string username)
        {
            bool exists = new UserRepository().GetUser(username) != null;
            if (!exists) return Request.CreateResponse(HttpStatusCode.NotFound,
                 "The user was not found.");
           var tokenUsername = JwtManager.ValidateToken(token);
            if (tokenUsername != null)
                return Request.CreateResponse(HttpStatusCode.OK);
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
