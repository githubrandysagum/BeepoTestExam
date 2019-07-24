using BeepoExamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeepoExamProject.BusinessLayer
{
    public class UserBl : BusinessLayer<tblUser>, IBusinessLayer<tblUser>
    {
        private IRepository<tblUser> _db;
        public UserBl(IRepository<tblUser> db) : base(db)
        {
            _db = db;
        }
    }
}