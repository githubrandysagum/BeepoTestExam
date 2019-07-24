using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BeepoExamProject.Models;

namespace BeepoExamProject.BusinessLayer
{
    public class ClientRepository : IRepository<tblClient>
    {
        private ClientContext _db { get; set; }

        public ClientRepository()
        {
            _db = new ClientContext();
        }

       
        public  IQueryable<tblClient> Search(string sortby, string order)
        {
            if(order != "Desc")
            {
                switch (sortby)
                {
                    case "strClientId": return _db.tblClients.OrderBy(e => e.strAddress);
                    case "strFirstName": return _db.tblClients.OrderBy(e => e.strFirstName);
                    case "strLastName": return _db.tblClients.OrderBy(e => e.strLastName);
                    case "strAddress": return _db.tblClients.OrderBy(e => e.strAddress);
                    case "strPhoneNumber": return _db.tblClients.OrderBy(e => e.strPhoneNumber);
                    case "strEmail": return _db.tblClients.OrderBy(e => e.strEmail);
                    case "dtmBirthDate": return _db.tblClients.OrderBy(e => e.dtmBirthDate);
                    default: return _db.tblClients.OrderBy(e => e.intClientId);
                };
            }
            else
            {
                switch (sortby)
                {
                    case "strClientId": return _db.tblClients.OrderByDescending(e => e.strAddress);
                    case "strFirstName": return _db.tblClients.OrderByDescending(e => e.strFirstName);
                    case "strLastName": return _db.tblClients.OrderByDescending(e => e.strLastName);
                    case "strAddress": return _db.tblClients.OrderByDescending(e => e.strAddress);
                    case "strPhoneNumber": return _db.tblClients.OrderByDescending(e => e.strPhoneNumber);
                    case "strEmail": return _db.tblClients.OrderByDescending(e => e.strEmail);
                    case "dtmBirthDate": return _db.tblClients.OrderByDescending(e => e.dtmBirthDate);
                    default: return _db.tblClients.OrderByDescending(e => e.intClientId);

                };
            }
          
           
        }

        public async  Task<tblClient> GetAsync(int id)
        {
            return  await _db.tblClients.FindAsync(id);
        }

        public void Post(tblClient client)
        {
            _db.tblClients.Add(client);
        }



        public async Task<IEnumerable<tblClient>> GetAsync()
        {
           return await _db.tblClients.Take(10).ToListAsync();
        }

        public async Task Put(tblClient entity)
        {
            var client = await _db.tblClients.FindAsync(entity.intClientId);
            client.strClientId = entity.strClientId;
            client.strFirstName = entity.strFirstName;
            client.strLastName = entity.strLastName;
            client.strAddress = entity.strAddress;
            client.strEmail = entity.strEmail;
            client.strPhoneNumber = entity.strPhoneNumber;
            client.dtmBirthDate = entity.dtmBirthDate;
        }

        public async Task Delete(int id)
        {
            var client = await _db.tblClients.FindAsync(id);
            if(client != null)
                 _db.tblClients.Remove(client);
        }

        public async Task SaveAsync()
        {
           await _db.SaveChangesAsync();
        }

        
    }
}