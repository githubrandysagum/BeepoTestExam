using BeepoExamProject.Authentication;
using BeepoExamProject.BusinessLayer;
using BeepoExamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace BeepoExamProject.Controllers
{
    [EnableCors("*", "*", "*")]
    [JwtAuthentication]
    public class ClientsController : ApiController
    {
        IBusinessLayer<tblClient> _db;
       
        public ClientsController(IBusinessLayer<tblClient> db)
        {
            _db = db;
        }

        [HttpGet]
        public IHttpActionResult Search(  string sortby, int page = 1, int listnumber = 10, string order="Asc")
        {
            try
            {
                var clients = _db.Search(sortby, order)
                    .Skip(listnumber * (page-1))
                    .Take(listnumber).ToList();

                if (clients == null)
                {
                    return NotFound();
                }

                return Ok(clients);
            }
            catch
            {
                return InternalServerError();
            }


        }

        // GET api/values
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var clients = await _db.GetAsync();

                if(clients == null)
                {
                    return NotFound();
                }

                return Ok(clients);
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }


        }

        // GET api/values/5
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var client = await _db.GetAsync(id);

                if (client == null)
                {
                    return NotFound();
                }

                return Ok(client);
            }
            catch
            {
                return InternalServerError();
            }
            
        }

        // POST api/values
        [HttpPost]
        [ResponseType(typeof(tblClient))]
        public async Task<IHttpActionResult> Post([FromBody]tblClient client)
        {

            try
            {
                _db.Post(client);
                await _db.SaveAsync();

               return  Ok();
            }
            catch
            {
                return InternalServerError();
            }

        }

        // PUT api/values/5
        [HttpPut]
        [ResponseType(typeof(tblClient))]
        public async Task<IHttpActionResult>Update([FromBody]tblClient client)
        {

            try
            {
                await _db.Update(client);
                await _db.SaveAsync();
                return Ok();
            }
            catch
            {
              return  InternalServerError();
            }
          
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task <IHttpActionResult> Delete(int id)
        {

            try
            {
                await _db.Delete(id);
                await _db.SaveAsync();
                return Ok();
            }
            catch
            {
                return InternalServerError();
            }
          
        }
    }
}
