using BeepoExamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeepoExamProject.BusinessLayer
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Search(string sortby, string order);
        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAsync();
        void Post(TEntity entity);
        Task Put(TEntity entity);
        Task Delete(int id);
        Task SaveAsync();
    }
}
