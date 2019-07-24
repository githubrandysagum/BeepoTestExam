using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BeepoExamProject.Models
{
    public class ClientContext : DbContext
    {
        public ClientContext() : base("ClientContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ClientContext>(null);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<tblClient> tblClients { get; set; }
        public DbSet<tblStartingNumber> tblStartingNumbers { get; set; }
        public DbSet<tblUser> tblUsers { get; set; }


    }
}