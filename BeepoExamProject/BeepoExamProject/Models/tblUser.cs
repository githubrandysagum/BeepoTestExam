using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace BeepoExamProject.Models
{
    public class tblUser
    {
        [Key]
        public int intUserId { get; set; }
        public string strUserName { get; set; }
        public string strPassword { get; set; }
    }
}