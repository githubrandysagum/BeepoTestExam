using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeepoExamProject.Models
{

    public class User
    {
        public enum UserRole
        {
            NORMAL,
            ADMIN
        }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}