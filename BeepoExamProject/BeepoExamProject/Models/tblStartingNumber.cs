using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeepoExamProject.Models
{
    public class tblStartingNumber
    {
        [Key]
        public int intStartingNumberId { get; set; }
        public string strTableName { get; set; }
        public int intCurrentNumber { get; set; }
    }
}