using BeepoExamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BeepoExamProject.BusinessLayer
{
    public class ClientBl :  BusinessLayer<tblClient>, IBusinessLayer<tblClient>
    {
        private IRepository<tblClient> _db { get; set; }

        public ClientBl(IRepository<tblClient> db) : base (db) {
            _db = db;
        }
    }
}