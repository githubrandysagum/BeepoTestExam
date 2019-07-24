using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BeepoExamProject.Models;

namespace BeepoExamProject.BusinessLayer
{
    public class UserRepository : IRepository<tblUser>
    {
        private ClientContext _db { get; set; }

        public UserRepository()
        {
            _db = new ClientContext();
        }


        public IQueryable<tblUser> Search(string sortby, string order)
        {
            if (order != "Desc")
            {
                switch (sortby)
                {
                    case "strUserName": return _db.tblUsers.OrderBy(e => e.strUserName);
                    case "strPassword": return _db.tblUsers.OrderBy(e => e.strPassword);
                    default: return _db.tblUsers.OrderBy(e => e.intUserId);
                };
            }
            else
            {
                switch (sortby)
                {
                    case "strUserName": return _db.tblUsers.OrderByDescending(e => e.strUserName);
                    case "strPassword": return _db.tblUsers.OrderByDescending(e => e.strPassword);
                    default: return _db.tblUsers.OrderByDescending(e => e.intUserId);

                };
            }


        }

        public async Task<tblUser> GetAsync(int id)
        {
            return await _db.tblUsers.FindAsync(id);
        }

        public void Post(tblUser user)
        {
            _db.tblUsers.Add(user);
        }

        public tblUser GetUser(string username)
        {
            return _db.tblUsers.FirstOrDefault(u => u.strUserName.Equals(username));
        }


        public async Task<IEnumerable<tblUser>> GetAsync()
        {
            return await _db.tblUsers.Take(10).ToListAsync();
        }

        public async Task Put(tblUser entity)
        {
            var client = await _db.tblUsers.FindAsync(entity.intUserId);
            client.strUserName = entity.strUserName;
            client.strPassword = entity.strPassword;
        }

        public async Task Delete(int id)
        {
            var client = await _db.tblUsers.FindAsync(id);
            if (client != null)
                _db.tblUsers.Remove(client);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

    }
}