using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeepoExamProject.Models
{
    public class tblClient
    {
        [Key]
        public int intClientId { get; set; }

        public string strClientId { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        public string strFirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        public string strLastName { get; set; }
        public string strAddress { get; set; }
        public string strPhoneNumber { get; set; }

        [Required(ErrorMessage = "Email Name is Required")]
        public string strEmail { get; set; }

        [Required(ErrorMessage = "Please Enter Birth Name")]

        public DateTime dtmBirthDate { get; set; }

    }
}