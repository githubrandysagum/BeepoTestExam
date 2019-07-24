using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BeepoExamProject.BusinessLayer
{
    public abstract class BusinessLayer<TEntity> : IBusinessLayer<TEntity> where TEntity : class
    {
        private IRepository<TEntity> _db { get; set; }

        public BusinessLayer(IRepository<TEntity> db)
        {
            _db = db;
        }


        public IQueryable<TEntity> Search(string sortby, string order = "Asc")
        {
            return _db.Search(sortby, order);
        }
        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _db.GetAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _db.GetAsync(id);
        }

        public void Post(TEntity entity)
        {
            _db.Post(entity);
        }

        public async Task Update(TEntity entity)
        {
            await _db.Put(entity);

        }

        public async Task Delete(int id)
        {
            await _db.Delete(id);
        }

        public async Task SaveAsync()
        {
            await _db.SaveAsync();
        }
    }
}